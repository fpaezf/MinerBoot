Imports System.IO
Imports System.Net
Imports LibreHardwareMonitor.Hardware

Public Class Form1

    Public ConfigFile As String = Application.StartupPath & "\config.ini"  ' Declare configuration file path
    Dim computer As Computer = New Computer With {.IsGpuEnabled = True, .IsCpuEnabled = True}  'Declare Computer for Libre Hardware Monitor readings (CPU/GPU enabled)
    'Declare all variables to store settings from config file
    Dim MinerEXEPath As String = ""
    Dim MinerEXEArguments As String = ""
    Dim MinerGamingArguments As String = ""
    Dim GPUsMAXTemp As String = ""
    Dim ForceClose As Boolean = False
    Dim MaxTempReachedAction As String = ""
    Dim WatchDogIsEnabled As Boolean = False
    Dim NotifyByEmail As Boolean = False
    Dim MailSendTo As String = ""
    Dim MyTemp As String = ""

    Private Sub SetLabelText(ByVal txt As String, ByVal lbl As Label)
        Dim fn As String = IO.Path.GetFileName(txt)
        Dim pth As String = IO.Path.GetFullPath(txt)
        Using g As Graphics = Graphics.FromHwnd(lbl.Handle)
            Dim sw As Single = g.MeasureString(txt, lbl.Font).Width
            If sw > lbl.Width Then
                pth &= "...\" & fn
                While sw > lbl.Width
                    pth = pth.Remove(pth.IndexOf("...\") - 1, 1)
                    sw = g.MeasureString(pth, lbl.Font).Width
                End While
            End If
        End Using
        lbl.Text = pth
    End Sub

    Public Sub GetMinerIcon()
        On Error Resume Next
        Dim ico As Icon = Icon.ExtractAssociatedIcon(MinerEXEPath)
        PictureBox1.Image = ico.ToBitmap
        SetLabelText(MinerEXEPath, Label3)
        'Label3.Text = MinerEXEPath
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WriteLog("Aplication started", 0)
        UpdateMinerSettings()  'Read all configuration variables from config file

        If MinerEXEPath = "" Or MinerEXEArguments = "" Or GPUsMAXTemp = "" Or MaxTempReachedAction = "" Then
            WriteLog("MinerBoot needs to be configured!", 2)
            MsgBox("Please update settings!", vbExclamation, "Empty values detected")
            settings.ShowDialog()
        End If

        Try
            computer.Open()    'Start Libre Hardware Monitor 
            For Each hardware As IHardware In computer.Hardware
                'GET CPU NAME-----------------------------------------------------------------------------------
                If hardware.HardwareType = HardwareType.Cpu Then
                    CPUName.Text = hardware.Name.ToString
                End If
            Next
            WriteLog("LHM started succesfully", 0)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical, "Critical LHM error") 'On error, exit application
            End
        End Try
        WhatsMyIP()
        WriteLog("Public IP address retrieved succesfully", 2)

        GetMinerIcon()


    End Sub 'REVISED OK

    Public Sub UpdateMinerSettings()

        If Not IO.File.Exists(ConfigFile) Then
            MsgBox("Configuration file not found at specified path:" & vbCrLf & vbCrLf & ConfigFile & vbCrLf & vbCrLf & "MinerBoot will close, please restore settings file.", vbCritical, "Critical error")
            End
        End If

        MinerEXEPath = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "MinerEXEPath")
        MinerEXEArguments = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "MinerEXEArguments")
        MinerGamingArguments = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "MinerGamingArguments")
        GPUsMAXTemp = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "GPUsMAXTemp")
        MaxTempReachedAction = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "MaxTempReachedAction")
        MailSendTo = INIReadWrite.ReadINI(ConfigFile, "EmailSettings", "SendTo")

        GPUMaxTempLabel.Text = GPUsMAXTemp

        Dim FC As String = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "ForceMinerClose")
        If FC = "True" Then
            ForceClose = True
        ElseIf FC = "False" Then
            ForceClose = False
        Else
            ForceClose = False
        End If

        Dim WIE As String = INIReadWrite.ReadINI(ConfigFile, "MinerSettings", "WatchDogEnbled")
        If WIE = "True" Then
            WatchDogIsEnabled = True
        ElseIf WIE = "False" Then
            WatchDogIsEnabled = False
        Else
            WatchDogIsEnabled = False
        End If


        Dim NBE = INIReadWrite.ReadINI(ConfigFile, "EmailSettings", "SendMail")
        If NBE = "True" Then
            NotifyByEmail = True
        ElseIf NBE = "False" Then
            NotifyByEmail = False
        Else
            NotifyByEmail = False
        End If

        WriteLog("Settings from config.ini file loaded succesfully", 0)

        If WatchDogIsEnabled = True Then
            WatchDog.Enabled = True
            WatchDogMenu.Text = "ON"
            WriteLog("WatchDog is now enabled", 0)
        ElseIf WatchDogIsEnabled = False Then
            WatchDog.Enabled = False
            WatchDogMenu.Text = "OFF"
            WriteLog("WatchDog is now disabled", 0)
        End If

    End Sub 'REVISED OK

    Private Sub PutSystemToSleep()
        WriteLog("Hibernating system...", 0)
        Application.SetSuspendState(PowerState.Suspend, True, False)
    End Sub 'REVISED OK

    Private Sub KillMiner()
        Try
            For Each proc As Process In Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(MinerEXEPath))
                If ForceClose = True Then
                    proc.Kill()
                ElseIf ForceClose = False Then
                    proc.CloseMainWindow()
                Else
                    proc.Kill()
                End If
            Next
        Catch ex As Exception
            WriteLog("Error halting miner", 1)
        End Try
    End Sub 'REVISED OK

    Private Sub LaunchMiner()
        WriteLog("Cleaning previous miner instances...", 0)
        KillMiner() ' Kill previous miner processes
        WriteLog("Reloading settings...", 0)
        UpdateMinerSettings() ' Update settings

        Try
            Dim MyNewMiner As New ProcessStartInfo
            MyNewMiner.FileName = MinerEXEPath
            MyNewMiner.Verb = "runas"

            If MiningToolStripMenuItem.Checked = True Then
                MyNewMiner.Arguments = MinerEXEArguments
            ElseIf GamingToolStripMenuItem.Checked = True Then
                MyNewMiner.Arguments = MinerGamingArguments
            End If

            MyNewMiner.WindowStyle = ProcessWindowStyle.Maximized
            Process.Start(MyNewMiner)
            WriteLog("Miner started succesfully!", 0)
        Catch ex As Exception
            KillMiner()
            WriteLog("Error starting Miner!", 1)
        End Try

    End Sub 'REVISED OK

    Private Sub Wait(ByVal seconds As Integer)
        On Error Resume Next
        For i As Integer = 0 To seconds * 100
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
        Next
    End Sub 'REVISED OK

    Public Sub AddGPUCard(ByVal ItemText As String, ByVal Temp As String, ByVal IconImage As Integer)
        On Error Resume Next
        Dim objItem As ListViewItem = ListView1.Items.Add(ItemText)
        With objItem
            .UseItemStyleForSubItems = False
            If Temp <= 60 Then
                .SubItems.Add(Temp).ForeColor = Color.Green
            ElseIf Temp > 60 And Temp <= 70 Then
                .SubItems.Add(Temp).ForeColor = Color.Orange
            ElseIf Temp > 70 Then
                .SubItems.Add(Temp).ForeColor = Color.Red
            End If
            .ImageIndex = IconImage
        End With
    End Sub 'REVISED OK

    Private Sub StartMiningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartMiningToolStripMenuItem.Click
        LaunchMiner()
    End Sub

    Private Sub StopMiningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopMiningToolStripMenuItem.Click
        WatchDog.Enabled = False
        WatchDogMenu.Text = "OFF"
        KillMiner()
        WriteLog("Miner halted by user!", 0)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        On Error Resume Next
        Dim result As DialogResult = MsgBox("Do you want to finish miner process after closing MinerBoot?", vbYesNoCancel + vbQuestion, "Please confirm")
        If result = DialogResult.Yes Then
            computer.Close()
            WriteLog("Closing MinerBoot...", 0)
            WatchDog.Enabled = False
            KillMiner()
            Application.Exit()
        ElseIf result = DialogResult.No Then
            computer.Close()
            WriteLog("Closing MinerBoot...", 0)
            WatchDog.Enabled = False
            Application.Exit()
        ElseIf result = DialogResult.Cancel Then
            Exit Sub
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        settings.ShowDialog()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            NotifyIcon1.Visible = True
            Me.Hide()
        End If
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized = True Then
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            Me.Show()
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub WhatsMyIP()
        Try
            Dim request As WebRequest = WebRequest.Create("https://api.ipify.org")
            Dim response As WebResponse = request.GetResponse()
            Dim dataStream As Stream = response.GetResponseStream()
            Dim reader As StreamReader = New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            response.Close()
            IPLabel.Text = responseFromServer
        Catch error_t As Exception
            WriteLog("Error retrieving public IP address!", 1)
            IPLabel.Text = "0.0.0.0"
        End Try
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        If AlwaysOnTopToolStripMenuItem.Checked = False Then
            AlwaysOnTopToolStripMenuItem.Checked = True
            Me.TopMost = True
        ElseIf AlwaysOnTopToolStripMenuItem.Checked = True Then
            AlwaysOnTopToolStripMenuItem.Checked = False
            Me.TopMost = False
        End If
    End Sub

    Public Sub SendMail(ByVal temp As String)
        If NotifyByEmail = True Then
            Try
                Dim request As WebRequest = WebRequest.Create("https://francescpaez.com/programas/minerboot/sendmail.php?email=" & MailSendTo & "&temp=" & temp & "&action=" & MaxTempReachedAction)
                Dim response As WebResponse = request.GetResponse()
                Dim dataStream As Stream = response.GetResponseStream()
                Dim reader As StreamReader = New StreamReader(dataStream)
                Dim responseFromServer As String = reader.ReadToEnd()
                reader.Close()
                response.Close()
                WriteLog("Notification email was sent!", 0)
            Catch error_t As Exception
                WriteLog("Notification email was not sent!", 1)
            End Try
        End If
    End Sub

    Private Sub WatchDog_Tick(sender As Object, e As EventArgs) Handles WatchDog.Tick
        Try
            Dim listProc() As Process = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(MinerEXEPath))
            If listProc.Count < 1 Then
                WriteLog("WATCHDOG: Miner not found, restarting...", 2)
                Label4.Text = "Miner not found..."
                Label4.ForeColor = Color.Red
                LaunchMiner()
            Else
                Label4.Text = "Miner found!"
                Label4.ForeColor = Color.Green
            End If
        Catch ex As Exception
            WatchDogIsEnabled = False
            WatchDog.Enabled = False
            WatchDogMenu.Text = "OFF"
            WriteLog("WATCHDOG: Error launching miner!", 1)
            WriteLog("WATCHDOG: Miner disabled", 2)
        End Try
    End Sub

    Private Sub CheckOverheath(ByVal Temp As String)
        If Temp >= GPUsMAXTemp Then
            WriteLog("GPUs overheath detected!", 2)
            If MaxTempReachedAction = "Pause miner" Then
                WatchDog.Enabled = False
                WriteLog("Closing previous miner instances...", 0)
                KillMiner()
                SendMail(Temp)
                WriteLog("Waiting 200 seconds to cooldown GPUs...", 2)
                Wait(200)
                WriteLog("Cooldown finished, restarting miner...", 2)
                'LaunchMiner()
                If WatchDogIsEnabled = True Then
                    WatchDog.Enabled = True
                End If
            ElseIf MaxTempReachedAction = "Hibernate" Then
                KillMiner()
                PutSystemToSleep()
            ElseIf MaxTempReachedAction = "Reboot" Then
                System.Diagnostics.Process.Start("shutdown", "-r -t 00")
            Else
                KillMiner()
                PutSystemToSleep()
            End If
        End If
    End Sub

    Private Sub CheckTemperaturesTimer_Tick(sender As Object, e As EventArgs) Handles CheckTemperaturesTimer.Tick
        ListView1.Items.Clear()

        Try
            For Each hardware As IHardware In computer.Hardware
                'IF GPU IS NVIDIA-----------------------------------------------------------------------------------
                If hardware.HardwareType = HardwareType.GpuNvidia Then
                    hardware.Update()
                    Dim tempSensors = hardware.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature)
                    tempSensors.ToList.ForEach(Sub(s) MyTemp = s.Value)
                    AddGPUCard(hardware.Name, MyTemp, 0)
                    CheckOverheath(MyTemp)
                    'IF GPU IS AMD-------------------------------------------------------------------------------------
                ElseIf hardware.HardwareType = HardwareType.GpuAmd Then
                    hardware.Update()
                    Dim tempSensors = hardware.Sensors.Where(Function(s) s.SensorType = SensorType.Temperature)
                    tempSensors.ToList.ForEach(Sub(s) MyTemp = s.Value)
                    AddGPUCard(hardware.Name, MyTemp, 1)
                    CheckOverheath(MyTemp)
                End If
            Next

            If ListView1.Items.Count = 0 Then
                AddGPUCard("No GPUs were detected!", "0", 2)
            End If

        Catch ex As Exception
            'ERROR READING TEMPERATURES, RISK OF OVERHEATING!: KILL MINER, PAUSE TEMPERATURE READINGS AND WATCHDOG TIMERS
            CheckTemperaturesTimer.Enabled = False
            WatchDog.Enabled = False
            KillMiner()
            WriteLog("LHM Error while reading temperatures", 1)
            WriteLog("Miner halted by LHM_CRITICAL_ERROR", 1)
        End Try
    End Sub

    Private Sub AboutMinerBootToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMinerBootToolStripMenuItem.Click
        About.ShowDialog()
    End Sub

    Private Sub DonateWithPayPalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonateWithPayPalToolStripMenuItem.Click
        On Error Resume Next
        Process.Start("https://paypal.me/fpaezcom/")
    End Sub

    Private Sub GitHubPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GitHubPageToolStripMenuItem.Click
        On Error Resume Next
        Process.Start("https://github.com/fpaezf/MinerBoot")
    End Sub

    Private Sub WatchDogMenu_Click(sender As Object, e As EventArgs) Handles WatchDogMenu.Click
        If WatchDogMenu.Text = "ON" Then
            WatchDogMenu.Text = "OFF"
            WatchDog.Enabled = False
            WriteLog("WATCHDOG: Disabled by user", 2)
        ElseIf WatchDogMenu.Text = "OFF" Then
            WatchDogMenu.Text = "ON"
            WatchDog.Enabled = True
            WriteLog("WATCHDOG: Enabled by user", 2)
        End If
    End Sub

    Public Sub WriteLog(ByVal evento As String, ByVal Icon As Integer)
        On Error Resume Next
        Dim objItem As ListViewItem = ListView2.Items.Add(DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss") & ": " & evento)
        With objItem
            .ImageIndex = Icon
        End With

        ListView2.Items(ListView2.Items.Count - 1).EnsureVisible()
    End Sub 'REVISED OK

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            ExitToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub IPLabel_Click(sender As Object, e As EventArgs) Handles IPLabel.Click
        Clipboard.SetText(IPLabel.Text, TextDataFormat.Text)
        MsgBox("Public IP address was succesfully copied!", vbInformation, "Done")
    End Sub

    Private Sub ClearEventsListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearEventsListToolStripMenuItem.Click
        ListView2.Items.Clear()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        ExitToolStripMenuItem.PerformClick()
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreToolStripMenuItem.Click
        If Me.WindowState = FormWindowState.Minimized = True Then
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            Me.Show()
            NotifyIcon1.Visible = False
        End If
    End Sub

    Private Sub UpdateIPLabel_Tick(sender As Object, e As EventArgs) Handles UpdateIPLabel.Tick
        WhatsMyIP()
    End Sub

    Private Sub MiningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MiningToolStripMenuItem.Click
        KillMiner()
        MiningToolStripMenuItem.Checked = True
        GamingToolStripMenuItem.Checked = False
        'UpdateMinerSettings()
    End Sub

    Private Sub GamingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GamingToolStripMenuItem.Click
        KillMiner()
        MiningToolStripMenuItem.Checked = False
        GamingToolStripMenuItem.Checked = True
        'UpdateMinerSettings()
    End Sub


End Class
