Public Class About
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        On Error Resume Next
        Process.Start("https://github.com/LibreHardwareMonitor/LibreHardwareMonitor")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        On Error Resume Next
        Process.Start("https://github.com/fpaezf/MinerBoot")
    End Sub


End Class