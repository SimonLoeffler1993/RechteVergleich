<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ÜberprüfungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolMnu_SpeichernUnter = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdnerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BenutzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenBenutzerAuswahl = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenBenutzerAlle = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenRechteAuswahl = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualisierenRechteAlle = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeOrdner = New System.Windows.Forms.TreeView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÜberprüfungToolStripMenuItem, Me.OrdnerToolStripMenuItem, Me.AktualisierenToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ÜberprüfungToolStripMenuItem
        '
        Me.ÜberprüfungToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÖffnenToolStripMenuItem, Me.SpeichernToolStripMenuItem, Me.ToolMnu_SpeichernUnter, Me.StartenToolStripMenuItem})
        Me.ÜberprüfungToolStripMenuItem.Name = "ÜberprüfungToolStripMenuItem"
        Me.ÜberprüfungToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.ÜberprüfungToolStripMenuItem.Text = "Überprüfung"
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen"
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SpeichernToolStripMenuItem.Text = "Speichern"
        '
        'ToolMnu_SpeichernUnter
        '
        Me.ToolMnu_SpeichernUnter.Name = "ToolMnu_SpeichernUnter"
        Me.ToolMnu_SpeichernUnter.Size = New System.Drawing.Size(157, 22)
        Me.ToolMnu_SpeichernUnter.Text = "Speichern unter"
        '
        'StartenToolStripMenuItem
        '
        Me.StartenToolStripMenuItem.Name = "StartenToolStripMenuItem"
        Me.StartenToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.StartenToolStripMenuItem.Text = "Starten"
        '
        'OrdnerToolStripMenuItem
        '
        Me.OrdnerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HinzufügenToolStripMenuItem})
        Me.OrdnerToolStripMenuItem.Name = "OrdnerToolStripMenuItem"
        Me.OrdnerToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.OrdnerToolStripMenuItem.Text = "Ordner"
        '
        'HinzufügenToolStripMenuItem
        '
        Me.HinzufügenToolStripMenuItem.Name = "HinzufügenToolStripMenuItem"
        Me.HinzufügenToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.HinzufügenToolStripMenuItem.Text = "Hinzufügen"
        '
        'AktualisierenToolStripMenuItem
        '
        Me.AktualisierenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BenutzerToolStripMenuItem, Me.RechteToolStripMenuItem})
        Me.AktualisierenToolStripMenuItem.Name = "AktualisierenToolStripMenuItem"
        Me.AktualisierenToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.AktualisierenToolStripMenuItem.Text = "Aktualisieren"
        '
        'BenutzerToolStripMenuItem
        '
        Me.BenutzerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AktualisierenBenutzerAuswahl, Me.AktualisierenBenutzerAlle})
        Me.BenutzerToolStripMenuItem.Name = "BenutzerToolStripMenuItem"
        Me.BenutzerToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BenutzerToolStripMenuItem.Text = "Benutzer"
        '
        'AktualisierenBenutzerAuswahl
        '
        Me.AktualisierenBenutzerAuswahl.Name = "AktualisierenBenutzerAuswahl"
        Me.AktualisierenBenutzerAuswahl.Size = New System.Drawing.Size(180, 22)
        Me.AktualisierenBenutzerAuswahl.Text = "Auswahl"
        '
        'AktualisierenBenutzerAlle
        '
        Me.AktualisierenBenutzerAlle.Name = "AktualisierenBenutzerAlle"
        Me.AktualisierenBenutzerAlle.Size = New System.Drawing.Size(180, 22)
        Me.AktualisierenBenutzerAlle.Text = "Alles"
        '
        'RechteToolStripMenuItem
        '
        Me.RechteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AktualisierenRechteAuswahl, Me.AktualisierenRechteAlle})
        Me.RechteToolStripMenuItem.Name = "RechteToolStripMenuItem"
        Me.RechteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.RechteToolStripMenuItem.Text = "Rechte"
        Me.RechteToolStripMenuItem.Visible = False
        '
        'AktualisierenRechteAuswahl
        '
        Me.AktualisierenRechteAuswahl.Name = "AktualisierenRechteAuswahl"
        Me.AktualisierenRechteAuswahl.Size = New System.Drawing.Size(119, 22)
        Me.AktualisierenRechteAuswahl.Text = "Auswahl"
        '
        'AktualisierenRechteAlle
        '
        Me.AktualisierenRechteAlle.Name = "AktualisierenRechteAlle"
        Me.AktualisierenRechteAlle.Size = New System.Drawing.Size(119, 22)
        Me.AktualisierenRechteAlle.Text = "Alles"
        '
        'TreeOrdner
        '
        Me.TreeOrdner.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeOrdner.Location = New System.Drawing.Point(0, 24)
        Me.TreeOrdner.Name = "TreeOrdner"
        Me.TreeOrdner.Size = New System.Drawing.Size(800, 513)
        Me.TreeOrdner.TabIndex = 8
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_Status
        '
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(119, 17)
        Me.lbl_Status.Text = "ToolStripStatusLabel1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 562)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TreeOrdner)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Rechte Überprüfen"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ÜberprüfungToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OrdnerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HinzufügenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TreeOrdner As TreeView
    Friend WithEvents ToolMnu_SpeichernUnter As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lbl_Status As ToolStripStatusLabel
    Friend WithEvents AktualisierenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BenutzerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AktualisierenBenutzerAuswahl As ToolStripMenuItem
    Friend WithEvents AktualisierenBenutzerAlle As ToolStripMenuItem
    Friend WithEvents RechteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AktualisierenRechteAuswahl As ToolStripMenuItem
    Friend WithEvents AktualisierenRechteAlle As ToolStripMenuItem
End Class
