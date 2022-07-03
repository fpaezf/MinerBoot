Imports System.Runtime.InteropServices
Imports System.Text

Public Class INIReadWrite
    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function GetPrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", SetLastError:=True)>
    Private Shared Function WritePrivateProfileString(ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Boolean
    End Function

    Public Shared Function ReadINI(ByVal File As String, ByVal Section As String, ByVal Key As String) As String
        Dim sb As New StringBuilder(500)
        GetPrivateProfileString(Section, Key, "", sb, sb.Capacity, File)
        Return sb.ToString
    End Function

    Public Shared Sub WriteINI(ByVal File As String, ByVal Section As String, ByVal Key As String, ByVal Value As String)
        WritePrivateProfileString(Section, Key, Value, File)
    End Sub






End Class