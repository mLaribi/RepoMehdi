<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.mstFermer = New System.Windows.Forms.MenuStrip()
        Me.FermerSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FermerApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabPrincipal = New System.Windows.Forms.TabControl()
        Me.tabClients = New System.Windows.Forms.TabPage()
        Me.btnAjoutRes = New System.Windows.Forms.Button()
        Me.btnReinitialiserLst = New System.Windows.Forms.Button()
        Me.btnAffResClient = New System.Windows.Forms.Button()
        Me.txtRecherche = New System.Windows.Forms.TextBox()
        Me.btnModifierClient = New System.Windows.Forms.Button()
        Me.btnRecherche = New System.Windows.Forms.Button()
        Me.btnAjouterClient = New System.Windows.Forms.Button()
        Me.dgvClients = New System.Windows.Forms.DataGridView()
        Me.tabChambres = New System.Windows.Forms.TabPage()
        Me.btnAffResChambre = New System.Windows.Forms.Button()
        Me.btnModifChambre = New System.Windows.Forms.Button()
        Me.btnAjoutChambre = New System.Windows.Forms.Button()
        Me.dgvChambres = New System.Windows.Forms.DataGridView()
        Me.tabUsagers = New System.Windows.Forms.TabPage()
        Me.btnActDesUsa = New System.Windows.Forms.Button()
        Me.btnModifierUsager = New System.Windows.Forms.Button()
        Me.btnAjoutUsager = New System.Windows.Forms.Button()
        Me.dgvUsagers = New System.Windows.Forms.DataGridView()
        Me.lblNomUtilisateur = New System.Windows.Forms.Label()
        Me.GestErreur = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.mstFermer.SuspendLayout()
        Me.tabPrincipal.SuspendLayout()
        Me.tabClients.SuspendLayout()
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabChambres.SuspendLayout()
        CType(Me.dgvChambres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabUsagers.SuspendLayout()
        CType(Me.dgvUsagers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GestErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mstFermer
        '
        Me.mstFermer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mstFermer.AutoSize = False
        Me.mstFermer.BackColor = System.Drawing.Color.Transparent
        Me.mstFermer.Dock = System.Windows.Forms.DockStyle.None
        Me.mstFermer.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mstFermer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FermerSessionToolStripMenuItem, Me.FermerApplicationToolStripMenuItem})
        Me.mstFermer.Location = New System.Drawing.Point(349, 0)
        Me.mstFermer.Name = "mstFermer"
        Me.mstFermer.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.mstFermer.Size = New System.Drawing.Size(354, 27)
        Me.mstFermer.TabIndex = 1
        Me.mstFermer.Text = "Fin opérations"
        '
        'FermerSessionToolStripMenuItem
        '
        Me.FermerSessionToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FermerSessionToolStripMenuItem.Image = CType(resources.GetObject("FermerSessionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FermerSessionToolStripMenuItem.Name = "FermerSessionToolStripMenuItem"
        Me.FermerSessionToolStripMenuItem.Size = New System.Drawing.Size(124, 23)
        Me.FermerSessionToolStripMenuItem.Text = "Fermer session"
        '
        'FermerApplicationToolStripMenuItem
        '
        Me.FermerApplicationToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.FermerApplicationToolStripMenuItem.Image = CType(resources.GetObject("FermerApplicationToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FermerApplicationToolStripMenuItem.Name = "FermerApplicationToolStripMenuItem"
        Me.FermerApplicationToolStripMenuItem.Size = New System.Drawing.Size(141, 23)
        Me.FermerApplicationToolStripMenuItem.Text = "Fermer application"
        '
        'tabPrincipal
        '
        Me.tabPrincipal.Controls.Add(Me.tabClients)
        Me.tabPrincipal.Controls.Add(Me.tabChambres)
        Me.tabPrincipal.Controls.Add(Me.tabUsagers)
        Me.tabPrincipal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPrincipal.Location = New System.Drawing.Point(3, 51)
        Me.tabPrincipal.Name = "tabPrincipal"
        Me.tabPrincipal.SelectedIndex = 0
        Me.tabPrincipal.Size = New System.Drawing.Size(606, 350)
        Me.tabPrincipal.TabIndex = 2
        '
        'tabClients
        '
        Me.tabClients.BackgroundImage = CType(resources.GetObject("tabClients.BackgroundImage"), System.Drawing.Image)
        Me.tabClients.Controls.Add(Me.btnAjoutRes)
        Me.tabClients.Controls.Add(Me.btnReinitialiserLst)
        Me.tabClients.Controls.Add(Me.btnAffResClient)
        Me.tabClients.Controls.Add(Me.txtRecherche)
        Me.tabClients.Controls.Add(Me.btnModifierClient)
        Me.tabClients.Controls.Add(Me.btnRecherche)
        Me.tabClients.Controls.Add(Me.btnAjouterClient)
        Me.tabClients.Controls.Add(Me.dgvClients)
        Me.tabClients.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabClients.Location = New System.Drawing.Point(4, 23)
        Me.tabClients.Name = "tabClients"
        Me.tabClients.Padding = New System.Windows.Forms.Padding(3)
        Me.tabClients.Size = New System.Drawing.Size(598, 323)
        Me.tabClients.TabIndex = 0
        Me.tabClients.Text = "Clients"
        Me.tabClients.UseVisualStyleBackColor = True
        '
        'btnAjoutRes
        '
        Me.btnAjoutRes.Location = New System.Drawing.Point(11, 287)
        Me.btnAjoutRes.Name = "btnAjoutRes"
        Me.btnAjoutRes.Size = New System.Drawing.Size(143, 30)
        Me.btnAjoutRes.TabIndex = 7
        Me.btnAjoutRes.Text = "Ajouter réservation"
        Me.btnAjoutRes.UseVisualStyleBackColor = True
        '
        'btnReinitialiserLst
        '
        Me.btnReinitialiserLst.Location = New System.Drawing.Point(457, 3)
        Me.btnReinitialiserLst.Name = "btnReinitialiserLst"
        Me.btnReinitialiserLst.Size = New System.Drawing.Size(127, 30)
        Me.btnReinitialiserLst.TabIndex = 4
        Me.btnReinitialiserLst.Text = "Réinitialiser la liste"
        Me.btnReinitialiserLst.UseVisualStyleBackColor = True
        '
        'btnAffResClient
        '
        Me.btnAffResClient.Location = New System.Drawing.Point(160, 287)
        Me.btnAffResClient.Name = "btnAffResClient"
        Me.btnAffResClient.Size = New System.Drawing.Size(143, 30)
        Me.btnAffResClient.TabIndex = 5
        Me.btnAffResClient.Text = "Afficher réservation"
        Me.btnAffResClient.UseVisualStyleBackColor = True
        '
        'txtRecherche
        '
        Me.txtRecherche.Location = New System.Drawing.Point(46, 8)
        Me.txtRecherche.Name = "txtRecherche"
        Me.txtRecherche.Size = New System.Drawing.Size(200, 20)
        Me.txtRecherche.TabIndex = 6
        '
        'btnModifierClient
        '
        Me.btnModifierClient.Location = New System.Drawing.Point(457, 288)
        Me.btnModifierClient.Name = "btnModifierClient"
        Me.btnModifierClient.Size = New System.Drawing.Size(138, 29)
        Me.btnModifierClient.TabIndex = 6
        Me.btnModifierClient.Text = "Modifier le client"
        Me.btnModifierClient.UseVisualStyleBackColor = True
        '
        'btnRecherche
        '
        Me.btnRecherche.Location = New System.Drawing.Point(284, 3)
        Me.btnRecherche.Name = "btnRecherche"
        Me.btnRecherche.Size = New System.Drawing.Size(124, 30)
        Me.btnRecherche.TabIndex = 4
        Me.btnRecherche.Text = "Rechercher"
        Me.btnRecherche.UseVisualStyleBackColor = True
        '
        'btnAjouterClient
        '
        Me.btnAjouterClient.Location = New System.Drawing.Point(309, 287)
        Me.btnAjouterClient.Name = "btnAjouterClient"
        Me.btnAjouterClient.Size = New System.Drawing.Size(142, 30)
        Me.btnAjouterClient.TabIndex = 5
        Me.btnAjouterClient.Text = "Ajouter un client"
        Me.btnAjouterClient.UseVisualStyleBackColor = True
        '
        'dgvClients
        '
        Me.dgvClients.AllowUserToDeleteRows = False
        Me.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvClients.Location = New System.Drawing.Point(0, 38)
        Me.dgvClients.Name = "dgvClients"
        Me.dgvClients.Size = New System.Drawing.Size(602, 246)
        Me.dgvClients.TabIndex = 4
        '
        'tabChambres
        '
        Me.tabChambres.BackgroundImage = CType(resources.GetObject("tabChambres.BackgroundImage"), System.Drawing.Image)
        Me.tabChambres.Controls.Add(Me.btnAffResChambre)
        Me.tabChambres.Controls.Add(Me.btnModifChambre)
        Me.tabChambres.Controls.Add(Me.btnAjoutChambre)
        Me.tabChambres.Controls.Add(Me.dgvChambres)
        Me.tabChambres.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabChambres.Location = New System.Drawing.Point(4, 23)
        Me.tabChambres.Name = "tabChambres"
        Me.tabChambres.Padding = New System.Windows.Forms.Padding(3)
        Me.tabChambres.Size = New System.Drawing.Size(598, 323)
        Me.tabChambres.TabIndex = 1
        Me.tabChambres.Text = "Chambres"
        Me.tabChambres.UseVisualStyleBackColor = True
        '
        'btnAffResChambre
        '
        Me.btnAffResChambre.Location = New System.Drawing.Point(31, 284)
        Me.btnAffResChambre.Name = "btnAffResChambre"
        Me.btnAffResChambre.Size = New System.Drawing.Size(142, 30)
        Me.btnAffResChambre.TabIndex = 8
        Me.btnAffResChambre.Text = "Afficher réservations"
        Me.btnAffResChambre.UseVisualStyleBackColor = True
        '
        'btnModifChambre
        '
        Me.btnModifChambre.Location = New System.Drawing.Point(439, 284)
        Me.btnModifChambre.Name = "btnModifChambre"
        Me.btnModifChambre.Size = New System.Drawing.Size(142, 30)
        Me.btnModifChambre.TabIndex = 7
        Me.btnModifChambre.Text = "Modifier la chambre"
        Me.btnModifChambre.UseVisualStyleBackColor = True
        '
        'btnAjoutChambre
        '
        Me.btnAjoutChambre.Location = New System.Drawing.Point(238, 284)
        Me.btnAjoutChambre.Name = "btnAjoutChambre"
        Me.btnAjoutChambre.Size = New System.Drawing.Size(142, 30)
        Me.btnAjoutChambre.TabIndex = 6
        Me.btnAjoutChambre.Text = "Ajouter une chambre"
        Me.btnAjoutChambre.UseVisualStyleBackColor = True
        '
        'dgvChambres
        '
        Me.dgvChambres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChambres.Location = New System.Drawing.Point(0, 0)
        Me.dgvChambres.Name = "dgvChambres"
        Me.dgvChambres.Size = New System.Drawing.Size(601, 278)
        Me.dgvChambres.TabIndex = 0
        '
        'tabUsagers
        '
        Me.tabUsagers.BackgroundImage = CType(resources.GetObject("tabUsagers.BackgroundImage"), System.Drawing.Image)
        Me.tabUsagers.Controls.Add(Me.btnActDesUsa)
        Me.tabUsagers.Controls.Add(Me.btnModifierUsager)
        Me.tabUsagers.Controls.Add(Me.btnAjoutUsager)
        Me.tabUsagers.Controls.Add(Me.dgvUsagers)
        Me.tabUsagers.Location = New System.Drawing.Point(4, 23)
        Me.tabUsagers.Name = "tabUsagers"
        Me.tabUsagers.Size = New System.Drawing.Size(598, 323)
        Me.tabUsagers.TabIndex = 2
        Me.tabUsagers.Text = "Usagers"
        Me.tabUsagers.UseVisualStyleBackColor = True
        '
        'btnActDesUsa
        '
        Me.btnActDesUsa.Location = New System.Drawing.Point(419, 284)
        Me.btnActDesUsa.Name = "btnActDesUsa"
        Me.btnActDesUsa.Size = New System.Drawing.Size(142, 36)
        Me.btnActDesUsa.TabIndex = 9
        Me.btnActDesUsa.Text = "Activer/Désactiver l'usager"
        Me.btnActDesUsa.UseVisualStyleBackColor = True
        '
        'btnModifierUsager
        '
        Me.btnModifierUsager.Location = New System.Drawing.Point(220, 284)
        Me.btnModifierUsager.Name = "btnModifierUsager"
        Me.btnModifierUsager.Size = New System.Drawing.Size(142, 30)
        Me.btnModifierUsager.TabIndex = 8
        Me.btnModifierUsager.Text = "Modifier l'usager"
        Me.btnModifierUsager.UseVisualStyleBackColor = True
        '
        'btnAjoutUsager
        '
        Me.btnAjoutUsager.Location = New System.Drawing.Point(22, 284)
        Me.btnAjoutUsager.Name = "btnAjoutUsager"
        Me.btnAjoutUsager.Size = New System.Drawing.Size(142, 30)
        Me.btnAjoutUsager.TabIndex = 7
        Me.btnAjoutUsager.Text = "Ajouter un usager"
        Me.btnAjoutUsager.UseVisualStyleBackColor = True
        '
        'dgvUsagers
        '
        Me.dgvUsagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsagers.Location = New System.Drawing.Point(0, 0)
        Me.dgvUsagers.Name = "dgvUsagers"
        Me.dgvUsagers.Size = New System.Drawing.Size(598, 278)
        Me.dgvUsagers.TabIndex = 0
        '
        'lblNomUtilisateur
        '
        Me.lblNomUtilisateur.AutoSize = True
        Me.lblNomUtilisateur.BackColor = System.Drawing.Color.Transparent
        Me.lblNomUtilisateur.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomUtilisateur.ForeColor = System.Drawing.Color.White
        Me.lblNomUtilisateur.Location = New System.Drawing.Point(5, 23)
        Me.lblNomUtilisateur.Name = "lblNomUtilisateur"
        Me.lblNomUtilisateur.Size = New System.Drawing.Size(62, 16)
        Me.lblNomUtilisateur.TabIndex = 3
        Me.lblNomUtilisateur.Text = "Bonjour "
        '
        'GestErreur
        '
        Me.GestErreur.ContainerControl = Me
        '
        'FrmPrincipal
        '
        Me.AcceptButton = Me.btnRecherche
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(621, 446)
        Me.Controls.Add(Me.lblNomUtilisateur)
        Me.Controls.Add(Me.mstFermer)
        Me.Controls.Add(Me.tabPrincipal)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mstFermer
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hôtel le Tamoul"
        Me.mstFermer.ResumeLayout(False)
        Me.mstFermer.PerformLayout()
        Me.tabPrincipal.ResumeLayout(False)
        Me.tabClients.ResumeLayout(False)
        Me.tabClients.PerformLayout()
        CType(Me.dgvClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabChambres.ResumeLayout(False)
        CType(Me.dgvChambres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabUsagers.ResumeLayout(False)
        CType(Me.dgvUsagers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GestErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mstFermer As System.Windows.Forms.MenuStrip
    Friend WithEvents FermerSessionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FermerApplicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabPrincipal As System.Windows.Forms.TabControl
    Friend WithEvents tabClients As System.Windows.Forms.TabPage
    Friend WithEvents tabChambres As System.Windows.Forms.TabPage
    Friend WithEvents tabUsagers As System.Windows.Forms.TabPage
    Friend WithEvents lblNomUtilisateur As System.Windows.Forms.Label
    Friend WithEvents dgvClients As System.Windows.Forms.DataGridView
    Friend WithEvents btnRecherche As System.Windows.Forms.Button
    Friend WithEvents dgvChambres As System.Windows.Forms.DataGridView
    Friend WithEvents dgvUsagers As System.Windows.Forms.DataGridView
    Friend WithEvents btnModifierClient As System.Windows.Forms.Button
    Friend WithEvents btnAjouterClient As System.Windows.Forms.Button
    Friend WithEvents btnAffResClient As System.Windows.Forms.Button
    Friend WithEvents txtRecherche As System.Windows.Forms.TextBox
    Friend WithEvents btnReinitialiserLst As System.Windows.Forms.Button
    Friend WithEvents btnModifChambre As System.Windows.Forms.Button
    Friend WithEvents btnAjoutChambre As System.Windows.Forms.Button
    Friend WithEvents btnModifierUsager As System.Windows.Forms.Button
    Friend WithEvents btnAjoutUsager As System.Windows.Forms.Button
    Friend WithEvents btnAffResChambre As System.Windows.Forms.Button
    Friend WithEvents btnAjoutRes As System.Windows.Forms.Button
    Friend WithEvents btnActDesUsa As System.Windows.Forms.Button
    Friend WithEvents GestErreur As System.Windows.Forms.ErrorProvider

End Class
