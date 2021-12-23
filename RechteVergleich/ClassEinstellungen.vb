Imports System.IO
Public Class ClassEinstellungen
    Public Pfad As String

    Dim SettingPfad As String = Application.StartupPath + "\Einstellungen\Setting.ini"

    Public Function Speichern() As Boolean
        Dim FS As FileStream
        Dim SW As StreamWriter


        'MsgBox(SettingPfad)
        Try
            FS = New FileStream(SettingPfad, FileMode.Create)
            SW = New StreamWriter(FS)

            SW.WriteLine("LetzerSpeicherOrt:" + Pfad)

            SW.Close()

            Return True
        Catch ex As Exception
            MsgBox("Fehler beim Speichern Der Einstellungen: " + vbCrLf + vbCrLf + ex.Message)
            Return False
        End Try

    End Function

    Public Sub Laden()
        Dim FS As FileStream
        Dim SR As StreamReader

        Dim Linie As String
        Try
            If File.Exists(SettingPfad) Then
                FS = New FileStream(SettingPfad, FileMode.Open)
                SR = New StreamReader(FS)

                Do Until SR.EndOfStream
                    Linie = SR.ReadLine
                    ' MsgBox(Mid(Linie, 1, 18))
                    If Mid(Linie, 1, 18) = "LetzerSpeicherOrt:" Then
                        Pfad = Mid(Linie, 19)
                    End If
                Loop
                SR.Close()
            Else
                    Pfad = ""
            End If
        Catch ex As Exception
            Pfad = ""
        End Try
    End Sub
End Class
