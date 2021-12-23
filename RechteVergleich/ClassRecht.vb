Imports System.IO
Imports System.Security.AccessControl

Public Class ClassRecht

    Public Benutzer As New List(Of String)
    Public Rechte As New List(Of String)
    Public Kontrolle As New List(Of String)

    Public Sub RechteLesen(Pfad As String)
        Dim Temp_Benutzer As New List(Of String)
        Dim Temp_Rechte As New List(Of String)

        If Directory.Exists(Pfad) Then
            Try


                Dim fsc As DirectorySecurity = Directory.GetAccessControl(Pfad)
                Dim aroll As AuthorizationRuleCollection = fsc.GetAccessRules(True, True, Type.GetType("System.Security.Principal.NTAccount"))
                Dim Hinzu As Boolean

                For Each fsar As FileSystemAccessRule In aroll
                    Hinzu = False
                    'Schauen ob der Benutzer schon da ist
                    For i = 0 To Temp_Benutzer.Count - 1
                        If Temp_Benutzer.Item(i) = Trim(fsar.IdentityReference.ToString()) Then
                            Hinzu = True
                            Temp_Rechte.Item(i) = Temp_Rechte.Item(i) + "," + fsar.FileSystemRights.ToString()
                            'Wenn Beutzer gefunden wird suche abbrechen
                            Exit For
                        End If

                    Next

                    'wen Benutzer bis jetzt noch nicht vorhanden ist zur Liste hinzufügen
                    If Not Hinzu Then
                        Temp_Benutzer.Add(Trim(fsar.IdentityReference.ToString()))
                        Temp_Rechte.Add(Trim(fsar.FileSystemRights.ToString()))
                        Kontrolle.Add(Trim(fsar.AccessControlType.ToString()))
                    End If

                Next

                'Doppelte Rechte einträge Löschen
                For i = 0 To Temp_Rechte.Count - 1
                    Temp_Rechte.Item(i) = RechteDoppeltKill(Temp_Rechte.Item(i))
                Next

                Benutzer = Temp_Benutzer
                Rechte = Temp_Rechte
            Catch ex As Exception
                MsgBox("Es wurde ein Fehler festgestellt!" + vbCrLf + vbCrLf + ex.Message)
            End Try

        Else
            MsgBox("Pfad ist nicht vorhanden")
        End If
    End Sub

    Private Function RechteDoppeltKill(Rechte As String) As String
        Dim EinzelRechte() As String
        Dim NeuRechte As New List(Of String)
        Dim Gefudnen As Boolean
        Dim NeueRechte As String

        EinzelRechte = Rechte.Split(",")

        For i = 0 To EinzelRechte.Count - 1
            Gefudnen = False
            'Testen ob das Recht schon in der Neuenliste da ist
            For iR = 0 To NeuRechte.Count - 1
                If Trim(NeuRechte.Item(iR)) = Trim(EinzelRechte(i)) Then
                    Gefudnen = True
                End If
            Next

            'Falls es noch nicht da ist Hinzufügen
            If Not Gefudnen Then
                NeuRechte.Add(Trim(EinzelRechte(i)))
            End If
        Next

        NeueRechte = ""
        For Each ERechte As String In NeuRechte
            If NeueRechte.Length = 0 Then
                NeueRechte = ERechte
            Else
                NeueRechte = NeueRechte + "," + ERechte
            End If
        Next

        Return NeueRechte
    End Function
End Class
