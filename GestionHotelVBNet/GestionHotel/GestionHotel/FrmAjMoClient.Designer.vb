<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjMoClient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjMoClient))
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.txtNumDroite = New System.Windows.Forms.TextBox()
        Me.txtNumMilieu = New System.Windows.Forms.TextBox()
        Me.txtNumGauche = New System.Windows.Forms.TextBox()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.btnAjMo = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.gestErreur = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.BackColor = System.Drawing.Color.Transparent
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitre.Location = New System.Drawing.Point(122, 9)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(146, 31)
        Me.lblTitre.TabIndex = 31
        Me.lblTitre.Text = "Non défini"
        '
        'txtNumDroite
        '
        Me.txtNumDroite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumDroite.Location = New System.Drawing.Point(265, 119)
        Me.txtNumDroite.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumDroite.MaxLength = 4
        Me.txtNumDroite.Name = "txtNumDroite"
        Me.txtNumDroite.Size = New System.Drawing.Size(47, 22)
        Me.txtNumDroite.TabIndex = 30
        '
        'txtNumMilieu
        '
        Me.txtNumMilieu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumMilieu.Location = New System.Drawing.Point(226, 119)
        Me.txtNumMilieu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumMilieu.MaxLength = 3
        Me.txtNumMilieu.Name = "txtNumMilieu"
        Me.txtNumMilieu.Size = New System.Drawing.Size(33, 22)
        Me.txtNumMilieu.TabIndex = 29
        '
        'txtNumGauche
        '
        Me.txtNumGauche.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumGauche.Location = New System.Drawing.Point(187, 119)
        Me.txtNumGauche.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNumGauche.MaxLength = 3
        Me.txtNumGauche.Name = "txtNumGauche"
        Me.txtNumGauche.Size = New System.Drawing.Size(33, 22)
        Me.txtNumGauche.TabIndex = 27
        '
        'txtNom
        '
        Me.txtNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNom.Location = New System.Drawing.Point(99, 74)
        Me.txtNom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(213, 22)
        Me.txtNom.TabIndex = 25
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.BackColor = System.Drawing.Color.Transparent
        Me.lblNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumero.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblNumero.Location = New System.Drawing.Point(12, 119)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(165, 16)
        Me.lblNumero.TabIndex = 28
        Me.lblNumero.Text = "Numéro de téléphone :"
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.BackColor = System.Drawing.Color.Transparent
        Me.lblNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNom.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblNom.Location = New System.Drawing.Point(12, 74)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(48, 16)
        Me.lblNom.TabIndex = 26
        Me.lblNom.Text = "Nom :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Location = New System.Drawing.Point(12, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Note :"
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(42, 199)
        Me.txtNote.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(322, 130)
        Me.txtNote.TabIndex = 33
        '
        'btnAjMo
        '
        Me.btnAjMo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAjMo.Location = New System.Drawing.Point(99, 351)
        Me.btnAjMo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAjMo.Name = "btnAjMo"
        Me.btnAjMo.Size = New System.Drawing.Size(92, 28)
        Me.btnAjMo.TabIndex = 34
        Me.btnAjMo.Text = "Ajouter"
        Me.btnAjMo.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.Location = New System.Drawing.Point(226, 351)
        Me.btnAnnuler.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(97, 28)
        Me.btnAnnuler.TabIndex = 35
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'gestErreur
        '
        Me.gestErreur.ContainerControl = Me
        '
        'FrmAjMoClient
        '
        Me.AcceptButton = Me.btnAjMo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(401, 392)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnAjMo)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.txtNumDroite)
        Me.Controls.Add(Me.txtNumMilieu)
        Me.Controls.Add(Me.txtNumGauche)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblNumero)
        Me.Controls.Add(Me.lblNom)
        Me.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmAjMoClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Non défini"
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents txtNumDroite As System.Windows.Forms.TextBox
    Friend WithEvents txtNumMilieu As System.Windows.Forms.TextBox
    Friend WithEvents txtNumGauche As System.Windows.Forms.TextBox
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblNom As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents btnAjMo As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents gestErreur As System.Windows.Forms.ErrorProvider
End Class
