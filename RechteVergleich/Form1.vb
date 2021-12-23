Public Class Form1
    'Variable damit beim ersten mal SPeichern immer der Pfad ausgewählt werden muss
    Dim ErsteMalSpeichern As Boolean = True


    Dim Einstellung As New ClassEinstellungen

    'Damit die Indexe der Bilder galerei nicht immer einzel angebpasst werden müssen
    Private Enum BaumSymbole As Integer
        Fragezeichen = 0
        HackenGruen = 1
        KreuzRot = 2
    End Enum

    Private Sub cmd_Add_Click(sender As Object, e As EventArgs)
        PlusPfad()
    End Sub

    Private Sub Testen()
        Dim Rechte As New ClassRecht
        Dim AktuellerORdner As String
        Dim AktuellerBenutzer As String
        Dim AktuelleRolle As String

        Dim echteRollen() As String

        'für Statistik
        Dim intStatVerztreffer As Integer = 0
        Dim intStatBenutzertreffer As Integer = 0
        Dim intStatRollen As Integer = 0

        Dim intGesamtVerzeichnisse As Integer = 0
        Dim intGesamtBenutzer As Integer = 0
        Dim intGesamtRollen As Integer = 0

        'erst alles auf Falsch Stellen
        TreeOrdner.ImageIndex = BaumSymbole.KreuzRot
        TreeOrdner.SelectedImageIndex = BaumSymbole.KreuzRot

        Dim Rolletreffer As Boolean = False
        Dim Benutertreffer As Boolean = False

        'Ordner durchgehen
        For Vi = 0 To TreeOrdner.Nodes.Count - 1
            AktuellerORdner = TreeOrdner.Nodes(Vi).Text
            If IO.Directory.Exists(AktuellerORdner) Then
                'Hacken Grün machen
                TreeOrdner.Nodes(Vi).ImageIndex = BaumSymbole.HackenGruen
                TreeOrdner.Nodes(Vi).SelectedImageIndex = BaumSymbole.HackenGruen
                intStatVerztreffer += 1
                'Benutzer Testen
                Rechte.RechteLesen(AktuellerORdner)
                For Bi = 0 To TreeOrdner.Nodes(Vi).Nodes.Count - 1
                    'benutzer Reseten
                    Benutertreffer = False
                    AktuellerBenutzer = TreeOrdner.Nodes(Vi).Nodes(Bi).Text
                    'die ganzen Benutzer auf dem Ordner durchgehen
                    'einzeln damit später getestest werden kann ob Rechte da sind weil rechte zusammen als string kommen
                    For eBi = 0 To Rechte.Benutzer.Count - 1
                        'ausgelesenen Benutzer leerzeichen entfernen 
                        If AktuellerBenutzer = Trim(Rechte.Benutzer(eBi)) Then
                            'Benutzer gefunden
                            Benutertreffer = True
                            TreeOrdner.Nodes(Vi).Nodes(Bi).ImageIndex = BaumSymbole.HackenGruen
                            TreeOrdner.Nodes(Vi).Nodes(Bi).SelectedImageIndex = BaumSymbole.HackenGruen
                            intStatBenutzertreffer += 1
                            'Rechte des Benutzer testen
                            'Rechte String in einzelne Rechte auftrennen
                            echteRollen = Rechte.Rechte(eBi).Split(",")
                            For Ri = 0 To TreeOrdner.Nodes(Vi).Nodes(Bi).Nodes.Count - 1
                                'rolle Reseten
                                Rolletreffer = False
                                AktuelleRolle = TreeOrdner.Nodes(Vi).Nodes(Bi).Nodes(Ri).Text
                                For Each eRolle As String In echteRollen
                                    'bei ausgelesener Rolle leerzeichen entfernen
                                    If Trim(eRolle) = AktuelleRolle Then
                                        'Rolle Gefunden
                                        TreeOrdner.Nodes(Vi).Nodes(Bi).Nodes(Ri).ImageIndex = BaumSymbole.HackenGruen
                                        TreeOrdner.Nodes(Vi).Nodes(Bi).Nodes(Ri).SelectedImageIndex = BaumSymbole.HackenGruen
                                        intStatRollen += 1
                                        Rolletreffer = True
                                        'aus Rolle  schleife Springen#
                                        Exit For
                                    End If

                                    'MsgBox(AktuellerORdner + vbCrLf +
                                    '       "Benutzer: " & AktuellerBenutzer + vbCrLf & "
                                    '       '" & AktuelleRolle & "' - '" & Trim(eRolle) + vbCrLf & "'
                                    '       " & Str(Rolletreffer) & "")

                                Next

                                'bei keinem Treffer Rolle ausklappen
                                If Not Rolletreffer Then
                                    TreeOrdner.Nodes(Vi).Expand()
                                    TreeOrdner.Nodes(Vi).Nodes(Bi).Expand()
                                End If

                            Next

                            'bei treffer aus Benutzer schleife springen
                            Exit For
                        End If
                    Next

                    'bei keinem Benutzer treffer Benutzer ausklappen
                    If Not Benutertreffer Then
                        TreeOrdner.Nodes(Vi).Expand()
                    End If
                Next

            End If
        Next

        'für Bessere Statistik gesamte ermitteln
        intGesamtVerzeichnisse = TreeOrdner.Nodes.Count
        For vi = 0 To TreeOrdner.Nodes.Count - 1
            intGesamtBenutzer += TreeOrdner.Nodes(vi).Nodes.Count
            For bi = 0 To TreeOrdner.Nodes(vi).Nodes.Count - 1
                intGesamtRollen += TreeOrdner.Nodes(vi).Nodes(bi).Nodes.Count
            Next
        Next

        TreeOrdner.Refresh()
        MsgBox("Überprüfung Fertig" + vbCrLf +
               "Es wurden gefunden: treffer/gesamt" + vbCrLf +
               "Verzeichnisse: " + intStatVerztreffer.ToString() + " / " + intGesamtVerzeichnisse.ToString() + vbCrLf +
               "Benutzer: " + intStatBenutzertreffer.ToString() + " / " + intGesamtBenutzer.ToString() + vbCrLf +
               "Rollen: " + intStatRollen.ToString() + " / " + intGesamtRollen.ToString())

    End Sub

    Private Function PlusPfad()
        Dim tmpPfad As String
        Dim tmpRechte() As String

        tmpPfad = PfadLesen()

        If Not tmpPfad = "Falsch" Then

            Dim Rechte As New ClassRecht
            Rechte.RechteLesen(tmpPfad)

            'MsgBox(tmpPfad)
            With TreeOrdner
                .Nodes.Add(Trim(tmpPfad))
                For i = 0 To Rechte.Benutzer.Count - 1
                    .Nodes(.Nodes.Count - 1).Nodes.Add(Trim(Rechte.Benutzer(i)))

                    'in einzelen Rechte auftrennen
                    tmpRechte = Rechte.Rechte(i).Split(",")
                    For Each Einzel As String In tmpRechte
                        .Nodes(.Nodes.Count - 1).Nodes(i).Nodes.Add(Trim(Einzel))
                    Next
                Next
            End With

        End If

    End Function

    Private Function PfadLesen()
        Dim fbd As New FolderBrowserDialog With
        {
            .RootFolder = Environment.SpecialFolder.Desktop,
            .ShowNewFolderButton = False,
            .Description = "Ordner Auswählen"
        }

        If fbd.ShowDialog = DialogResult.OK Then
            Return fbd.SelectedPath

        Else
            Return "Falsch"

        End If
    End Function

    Private Sub cmd_Kill_Click(sender As Object, e As EventArgs)
        TeilLoeschen()

    End Sub

    Private Sub TeilLoeschen()
        Dim Antwort As Integer

        If TreeOrdner.SelectedNode IsNot Nothing Then
            Select Case TreeOrdner.SelectedNode.Level
                Case 0
                    Antwort = MsgBox("Soll der Ordner '" + TreeOrdner.SelectedNode.Text + "' wirklich aus der Überprüfung entfernt werden?", vbYesNo)
                Case 1
                    Antwort = MsgBox("Soll der Benutzer '" + TreeOrdner.SelectedNode.Text + "' wirklich aus der Überprüfung entfernt werden?", vbYesNo)
                Case 2
                    Antwort = MsgBox("Soll der Berechtigung '" + TreeOrdner.SelectedNode.Text + "' wirklich aus der Überprüfung entfernt werden?", vbYesNo)
            End Select

            If Antwort = vbYes Then
                TreeOrdner.SelectedNode.Remove()
            End If
        Else
            MsgBox("Es muss zuerst etwas ausgewählt werden")
        End If
    End Sub

    Private Sub Reset()
        Dim BilderListe As New ImageList()

        BilderListe.Images.Add(Image.FromFile(Application.StartupPath + "\Symbole\fragezeichen_orange.png"))
        BilderListe.Images.Add(Image.FromFile(Application.StartupPath + "\Symbole\hacken_gruen.png"))
        BilderListe.Images.Add(Image.FromFile(Application.StartupPath + "\Symbole\kreuz_rot.png"))

        TreeOrdner.ImageList = BilderListe
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reset()


        Einstellung.Laden()
        If Einstellung.Pfad.Length > 0 Then
            Laden(Einstellung.Pfad)
        End If
    End Sub

    Private Sub HinzufügenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HinzufügenToolStripMenuItem.Click
        PlusPfad()
    End Sub

    Private Sub TreeOrdner_KeyUp(sender As Object, e As KeyEventArgs) Handles TreeOrdner.KeyUp
        If e.KeyCode = Keys.Delete Then
            TeilLoeschen()
        End If
    End Sub

    Private Sub Speichern(Optional PfadSuchen As Boolean = False)
        Dim hPfad As String

        Dim Pruefung As XElement
        Dim xelVerzeichnis As XElement
        Dim xelBenutzer As XElement
        Dim xelRechte As XElement
        Pruefung = New XElement("Pruefung")

        'beim erstenmal immer Pfad suchen
        If ErsteMalSpeichern Then
            PfadSuchen = True
        End If

        'checken ob Ort zum speichern ausgewählt werden muss
        If PfadSuchen Then
            Dim saveFD As New SaveFileDialog With
            {
                .InitialDirectory = Einstellung.Pfad,
                .Filter = "xml (*xml)|*.xml",
                .Title = "Überprüfung Speichern"
            }

            If saveFD.ShowDialog() = DialogResult.OK Then
                Einstellung.Pfad = saveFD.FileName
                Einstellung.Speichern()
            Else
                Exit Sub
            End If
        End If

        'Pfade nach und nach eintragen
        For i = 0 To TreeOrdner.Nodes.Count - 1
            xelVerzeichnis = New XElement("Verzeichnis")
            'Pfade Hinzufügen
            xelVerzeichnis.Add(New XElement("Pfad", TreeOrdner.Nodes(i).Text))

            For iB = 0 To TreeOrdner.Nodes(i).Nodes.Count - 1
                'Benutzer zu den Verzeichnissen 
                'Benutzer ebene erstellen
                xelBenutzer = New XElement("Benutzer", New XElement("Name"))
                xelBenutzer.Element("Name").Add(TreeOrdner.Nodes(i).Nodes(iB).Text)
                'Rechte Speichern
                xelRechte = New XElement("Rechte")
                For iR = 0 To TreeOrdner.Nodes(i).Nodes(iB).Nodes.Count - 1
                    xelRechte.Add(New XElement("Rolle", TreeOrdner.Nodes(i).Nodes(iB).Nodes(iR).Text))

                Next
                xelBenutzer.Add(xelRechte)
                'Benutzer elemet dem Verzeichniss element hinzufügen
                xelVerzeichnis.Add(xelBenutzer)
            Next

            Pruefung.Add(xelVerzeichnis)
        Next

        'Einstellungen Speichern damit beim nächstenmal öffen wieder da rauskommt
        lbl_Status.Text = "Datei: " + Einstellung.Pfad
        If ErsteMalSpeichern Then
            ErsteMalSpeichern = False
        End If

        Try
            Pruefung.Save(Einstellung.Pfad)
        Catch ex As Exception
            MsgBox("Fehler beim Speichern der Prüf-XML" + vbCrLf + vbCrLf + ex.Message)
        End Try

    End Sub

    Private Sub Laden(Optional LadePfad As String = "")
        Dim hlPfad As String
        TreeOrdner.Nodes.Clear()

        If LadePfad = "" Then
            Dim OpenFD As New OpenFileDialog With
            {
                .InitialDirectory = Einstellung.Pfad,
                .Filter = "xml (*.xml)|*.xml",
                .Title = "Verzeichnis Struktur Laden"
            }

            If OpenFD.ShowDialog() = DialogResult.OK Then
                hlPfad = OpenFD.FileName
            Else
                Exit Sub
            End If
        Else
            hlPfad = LadePfad
        End If


        Dim VerzeichnisID As Integer
        Dim BenutzerID As Integer

        If System.IO.File.Exists(hlPfad) Then
            Dim hPruefung As XElement = XElement.Load(hlPfad)
            'Pfad in Einstellungen Schreiben damit beim Nächsten Start Datei automatisch geöffnet wird
            Einstellung.Pfad = hlPfad
            Einstellung.Speichern()
            'Verzeichnisse auslesen
            For Each Verzeichnis In hPruefung.<Verzeichnis>
                TreeOrdner.Nodes.Add(Verzeichnis.Element("Pfad").Value.ToString())
                VerzeichnisID = TreeOrdner.Nodes.Count - 1
                'Benutzer der Verzeichnisse auslesen
                For Each Benutzer In Verzeichnis.<Benutzer>
                    TreeOrdner.Nodes(VerzeichnisID).Nodes.Add(Benutzer.Element("Name").Value.ToString())
                    BenutzerID = TreeOrdner.Nodes(VerzeichnisID).Nodes.Count - 1
                    'Rechte der Benutzer auslsen
                    For Each Rollen In Benutzer.<Rechte>.<Rolle>
                        TreeOrdner.Nodes(VerzeichnisID).Nodes(BenutzerID).Nodes.Add(Rollen.Value.ToString())
                    Next
                Next
            Next
        End If
        lbl_Status.Text = "Datei: " + hlPfad
    End Sub

    Private Sub SpeichernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeichernToolStripMenuItem.Click

        Speichern()
    End Sub

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click
        Laden()
    End Sub

    Private Sub ToolMnu_SpeichernUnter_Click(sender As Object, e As EventArgs) Handles ToolMnu_SpeichernUnter.Click
        Speichern(True)

    End Sub

    Private Sub StartenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartenToolStripMenuItem.Click
        Testen()
    End Sub

    Private Function GetAuswahlIndex() As Integer
        Dim Ordner As Integer

        If TreeOrdner.SelectedNode IsNot Nothing Then
            Select Case TreeOrdner.SelectedNode.Level
                Case 0
                    Ordner = TreeOrdner.SelectedNode.Index
                Case 1
                    Ordner = TreeOrdner.SelectedNode.Parent.Index
                Case 2
                    Ordner = TreeOrdner.SelectedNode.Parent.Parent.Index
                Case Else
                    Ordner = -1
            End Select
        Else
            MsgBox("Es zuerst etwas ausgewählt werden!")
            Ordner = -1
        End If

        Return Ordner
    End Function

    Private Sub BenutzerAktualisieren(TreeIndex As Integer, Optional Fragen As Boolean = False)
        Dim Rechte As New ClassRecht
        Dim Ordner As String
        Dim Antwort As Integer
        Dim TmpRechte() As String
        Dim BenutzerIndex As Integer

        Ordner = Trim(TreeOrdner.Nodes(TreeIndex).Text)

        If Fragen Then
            Antwort = MsgBox("Soll bei dem Ordner: '" & Ordner & "' die Benutzer Aktualisiert werden!", vbYesNo)

            If Antwort = vbNo Then
                Exit Sub
            End If
        End If


        If System.IO.Directory.Exists(Ordner) Then
            Rechte.RechteLesen(Ordner)

            'Alte Benutzer entfernen
            For i = TreeOrdner.Nodes(TreeIndex).GetNodeCount(False) - 1 To 0 Step -1
                TreeOrdner.Nodes(TreeIndex).Nodes(i).Remove()
            Next

            'Neue Hinzufügen
            For i = 0 To Rechte.Benutzer.Count - 1
                TreeOrdner.Nodes(TreeIndex).Nodes.Add(Trim(Rechte.Benutzer(i)))
                BenutzerIndex = TreeOrdner.Nodes(TreeIndex).Nodes.Count - 1

                TmpRechte = Rechte.Rechte(i).Split(",")
                For Each Re As String In TmpRechte
                    TreeOrdner.Nodes(TreeIndex).Nodes(BenutzerIndex).Nodes.Add(Trim(Re))
                Next
            Next

            If Fragen Then
                MsgBox("Benutzer wurde Aktualisiert!")
            End If
        Else
                MsgBox("Ordner ist nicht mehr Verfügbar!")
        End If
    End Sub

    Private Sub AktualisierenBenutzerAuswahl_Click(sender As Object, e As EventArgs) Handles AktualisierenBenutzerAuswahl.Click
        Dim Auswahl As Integer

        Auswahl = GetAuswahlIndex()

        'MsgBox(Auswahl.ToString)

        If Not Auswahl = -1 Then
            BenutzerAktualisieren(Auswahl, True)
        End If
    End Sub

    Private Sub AktualisierenBenutzerAlle_Click(sender As Object, e As EventArgs) Handles AktualisierenBenutzerAlle.Click
        For i = 0 To TreeOrdner.Nodes.Count - 1
            BenutzerAktualisieren(i, False)
        Next
        MsgBox("Benutzer wurden Aktualisiert")
    End Sub
End Class
