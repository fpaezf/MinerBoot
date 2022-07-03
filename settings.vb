Imports System.IO
Imports System.Net


Public Class settings

    Dim FormIsStarted As Boolean = False

    Private Sub settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCFGFile(Form1.ConfigFile)
        FormIsStarted = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim SaveFileDialog1 As New SaveFileDialog
        SaveFileDialog1.InitialDirectory = Application.StartupPath
        SaveFileDialog1.Filter = "Settings files (*.cfg,*.cfg)|"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveCFGFile(SaveFileDialog1.FileName)
            MsgBox("Settings saved succesfully!", vbInformation, "Done")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.InitialDirectory = Application.StartupPath
        openFileDialog1.Filter = "Executable files (*.exe,*.exe)|"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            MinerPath.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub SendEmailsCheck_CheckedChanged(sender As Object, e As EventArgs) Handles SendEmailsCheck.CheckedChanged
        If SendEmailsCheck.Checked = True Then
            SendTo.Enabled = True
            Button4.Enabled = True
        Else
            SendTo.Enabled = False
            Button4.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If SendTo.Text = "" Then
            MsgBox("Please input a valid email address!", vbExclamation, "Missing data")
            SendTo.Focus()
            Exit Sub
        End If

        Try
            Dim request As WebRequest = WebRequest.Create("https://francescpaez.com/programas/minerboot/sendmail.php?email=" & SendTo.Text & "&temp=" & GPUMAXTemp.Text & "&action=" & MaxTempReachAction.Text)
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            response.Close()
            MsgBox("Email is sent with no errors", vbInformation, "Done")
        Catch error_t As Exception
            MsgBox("Email error:" & vbCrLf & vbCrLf & error_t.Message, vbCritical, "Error")
        End Try
    End Sub

    Private Sub StartWithWindows_CheckedChanged(sender As Object, e As EventArgs) Handles StartWithWindows.CheckedChanged
        If StartWithWindows.Checked = True And FormIsStarted = True Then
            WatchDog.Checked = True
            MsgBox("If you use the ""Start With Windows"" setting, please disable UAC notifications or application will wait for user confirmation at startup." & vbCrLf & vbCrLf & "Also, this setting needs the ""WatchDog"" option to be enabled.", vbInformation, "Advice")
        End If
    End Sub

    Private Sub WatchDog_CheckedChanged(sender As Object, e As EventArgs) Handles WatchDog.CheckedChanged
        If WatchDog.Checked = False And StartWithWindows.Checked = True Then
            MsgBox("If you disable the watchdog feature and keep the ""Start with Windows"" option enabled, MinerBoot will start itself but not the miner process. Please keep the two options enabled to start mining at Windows startup.", vbInformation, "Advice")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) = True Then
            MinerArguments.Text = ""
            MinerArguments.Paste()
        End If
    End Sub

    Private Sub LoadCFGFile(ByVal CFGFile As String)
        'MINER AND OVERHEATH SETTINGS------------------------------------------------------------------------------------------------------------------------------------------
        MinerPath.Text = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "MinerEXEPath")
        MinerArguments.Text = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "MinerEXEArguments")
        GamingArguments.Text = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "MinerGamingArguments")
        GPUMAXTemp.Value = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "GPUsMAXTemp")

        Dim ForceClose As String = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "ForceMinerClose")
        If ForceClose = "True" Then
            KillMinerProcessCheck.Checked = True
        ElseIf ForceClose = "False" Then
            KillMinerProcessCheck.Checked = False
        Else
            KillMinerProcessCheck.Checked = False
        End If

        Dim MaxTempReachedAction As String = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "MaxTempReachedAction")
        If MaxTempReachedAction = "Pause miner" Then
            MaxTempReachAction.SelectedIndex = 0
        ElseIf MaxTempReachedAction = "Hibernate" Then
            MaxTempReachAction.SelectedIndex = 1
        ElseIf MaxTempReachedAction = "Reboot" Then
            MaxTempReachAction.SelectedIndex = 2
        End If

        Dim StartWin As String = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "StartWithWindows")
        If StartWin = "True" Then
            StartWithWindows.Checked = True
        ElseIf StartWin = "False" Then
            StartWithWindows.Checked = False
        Else
            StartWithWindows.Checked = False
        End If


        'WATCHDOG SETTINGS------------------------------------------------------------------------------------------------------------------------------------------
        Dim IsWatchDogEnabled As String = INIReadWrite.ReadINI(CFGFile, "MinerSettings", "WatchDogEnbled")
        If IsWatchDogEnabled = "True" Then
            WatchDog.Checked = True
        ElseIf IsWatchDogEnabled = "False" Then
            WatchDog.Checked = False
        Else
            WatchDog.Checked = False
        End If


        'EMAIL SETTINGS------------------------------------------------------------------------------------------------------------------------------------------
        Dim SendEmails As String = INIReadWrite.ReadINI(CFGFile, "EmailSettings", "SendMail")
        If SendEmails = "True" Then
            SendEmailsCheck.Checked = True
        ElseIf SendEmails = "False" Then
            SendEmailsCheck.Checked = False
        Else
            SendEmailsCheck.Checked = False
        End If

        SendTo.Text = INIReadWrite.ReadINI(CFGFile, "EmailSettings", "SendTo")

    End Sub

    Private Sub SaveCFGFile(ByVal CFGFile As String)
        If MinerPath.Text = "" Or MinerArguments.Text = "" Or GPUMAXTemp.Text = "" Then
            MsgBox("Please fill all settings fields!", vbExclamation, "Empty values detected!")
            Exit Sub
        ElseIf SendEmailsCheck.Checked = True And SendTo.Text = "" Then
            MsgBox("Please input a valid email!", vbExclamation, "Empty email value")
            SendTo.Focus()
            Exit Sub
        End If

        'MINER AND OVERHEATH SETTINGS----------------------------------------------------------------------------------------------------------------------------------------
        INIReadWrite.WriteINI(CFGFile, "MinerSettings", "MinerEXEPath", MinerPath.Text)
        INIReadWrite.WriteINI(CFGFile, "MinerSettings", "MinerEXEArguments", MinerArguments.Text)
        INIReadWrite.WriteINI(CFGFile, "MinerSettings", "MinerGamingArguments", GamingArguments.Text)
        INIReadWrite.WriteINI(CFGFile, "MinerSettings", "GPUsMAXTemp", GPUMAXTemp.Value.ToString)
        INIReadWrite.WriteINI(CFGFile, "MinerSettings", "MaxTempReachedAction", MaxTempReachAction.Text)


        'MINER KILLING METHOD SETTINGS----------------------------------------------------------------------------------------------------------------------------------------
        If KillMinerProcessCheck.Checked = True Then
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "ForceMinerClose", "True")
        Else
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "ForceMinerClose", "False")
        End If


        'WATCHDOG SETTINGS----------------------------------------------------------------------------------------------------------------------------------------
        If WatchDog.Checked = True Then
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "WatchDogEnbled", "True")
        Else
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "WatchDogEnbled", "False")
        End If



        'EMAIL SETTINGS------------------------------------------------------------------------------------------------------------------------------------------
        If SendEmailsCheck.Checked = True Then
            INIReadWrite.WriteINI(CFGFile, "EmailSettings", "SendMail", "True")
        Else
            INIReadWrite.WriteINI(CFGFile, "EmailSettings", "SendMail", "False")
        End If

        INIReadWrite.WriteINI(CFGFile, "EmailSettings", "SendTo", SendTo.Text)

        'START WITH WINDOWS SETTINGS------------------------------------------------------------------------------------------------------------------------------------------
        If StartWithWindows.Checked = True Then
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "StartWithWindows", "True")
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
        ElseIf StartWithWindows.Checked = False Then
            INIReadWrite.WriteINI(CFGFile, "MinerSettings", "StartWithWindows", "False")
            My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim openFileDialog1 As New OpenFileDialog
        openFileDialog1.InitialDirectory = Application.StartupPath
        openFileDialog1.Filter = "Settings files (*.cfg,*.cfg)|"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadCFGFile(openFileDialog1.FileName)
            MsgBox("Settings file loaded succesfully!", vbInformation, "Done")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SaveCFGFile(Form1.ConfigFile)
        Form1.UpdateMinerSettings()
        Form1.GetMinerIcon()

        Me.Close()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) = True Then
            GamingArguments.Text = ""
            GamingArguments.Paste()
        End If
    End Sub
End Class