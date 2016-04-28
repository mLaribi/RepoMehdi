<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjMoUsager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjMoUsager))
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.chkActif = New System.Windows.Forms.CheckBox()
        Me.chkGerant = New System.Windows.Forms.CheckBox()
        Me.btnAjMoUsager = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.gestErreur = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.BackColor = System.Drawing.Color.Transparent
        Me.lblTitre.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitre.Location = New System.Drawing.Point(60, 38)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(110, 32)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "nonDef"
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(138, 110)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(165, 20)
        Me.txtNom.TabIndex = 1
        '
        'lblNom
        '
        Me.lblNom.AutoSize = True
        Me.lblNom.BackColor = System.Drawing.Color.Transparent
        Me.lblNom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNom.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblNom.Location = New System.Drawing.Point(30, 110)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(82, 15)
        Me.lblNom.TabIndex = 2
        Me.lblNom.Text = "Nom usager :"
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.BackColor = System.Drawing.Color.Transparent
        Me.lblCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblCode.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCode.Location = New System.Drawing.Point(32, 159)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(80, 15)
        Me.lblCode.TabIndex = 3
        Me.lblCode.Text = "Code accès :"
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(166, 157)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 6
        '
        'chkActif
        '
        Me.chkActif.AutoSize = True
        Me.chkActif.BackColor = System.Drawing.Color.Transparent
        Me.chkActif.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkActif.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkActif.Location = New System.Drawing.Point(35, 213)
        Me.chkActif.Name = "chkActif"
        Me.chkActif.Size = New System.Drawing.Size(95, 19)
        Me.chkActif.TabIndex = 7
        Me.chkActif.Text = "Usager actif"
        Me.chkActif.UseVisualStyleBackColor = False
        '
        'chkGerant
        '
        Me.chkGerant.AutoSize = True
        Me.chkGerant.BackColor = System.Drawing.Color.Transparent
        Me.chkGerant.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.chkGerant.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkGerant.Location = New System.Drawing.Point(166, 213)
        Me.chkGerant.Name = "chkGerant"
        Me.chkGerant.Size = New System.Drawing.Size(125, 19)
        Me.chkGerant.TabIndex = 8
        Me.chkGerant.Text = "Promotion gérant"
        Me.chkGerant.UseVisualStyleBackColor = False
        '
        'btnAjMoUsager
        '
        Me.btnAjMoUsager.Location = New System.Drawing.Point(35, 269)
        Me.btnAjMoUsager.Name = "btnAjMoUsager"
        Me.btnAjMoUsager.Size = New System.Drawing.Size(107, 30)
        Me.btnAjMoUsager.TabIndex = 9
        Me.btnAjMoUsager.Text = "nonDef"
        Me.btnAjMoUsager.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.Location = New System.Drawing.Point(166, 269)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(110, 30)
        Me.btnAnnuler.TabIndex = 10
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'gestErreur
        '
        Me.gestErreur.ContainerControl = Me
        '
        'FrmAjMoUsager
        '
        Me.AcceptButton = Me.btnAjMoUsager
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(324, 337)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnAjMoUsager)
        Me.Controls.Add(Me.chkGerant)
        Me.Controls.Add(Me.chkActif)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.lblNom)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.lblTitre)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjMoUsager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "nonDef"
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents lblNom As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents chkActif As System.Windows.Forms.CheckBox
    Friend WithEvents chkGerant As System.Windows.Forms.CheckBox
    Friend WithEvents btnAjMoUsager As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents gestErreur As System.Windows.Forms.ErrorProvider
End Class
