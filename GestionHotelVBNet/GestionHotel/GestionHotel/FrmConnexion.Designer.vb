<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnexion))
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.btnConnexion = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gboCode = New System.Windows.Forms.GroupBox()
        Me.GestionnaireErreur = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gboCode.SuspendLayout()
        CType(Me.GestionnaireErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(57, 30)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(116, 22)
        Me.txtCode.TabIndex = 1
        Me.txtCode.UseSystemPasswordChar = True
        '
        'btnConnexion
        '
        Me.btnConnexion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnexion.Location = New System.Drawing.Point(102, 101)
        Me.btnConnexion.Name = "btnConnexion"
        Me.btnConnexion.Size = New System.Drawing.Size(111, 28)
        Me.btnConnexion.TabIndex = 2
        Me.btnConnexion.Text = "Connexion"
        Me.btnConnexion.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(245, 101)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 28)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Fermer "
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'gboCode
        '
        Me.gboCode.BackColor = System.Drawing.Color.Transparent
        Me.gboCode.Controls.Add(Me.txtCode)
        Me.gboCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboCode.Location = New System.Drawing.Point(115, 26)
        Me.gboCode.Name = "gboCode"
        Me.gboCode.Size = New System.Drawing.Size(227, 68)
        Me.gboCode.TabIndex = 4
        Me.gboCode.TabStop = False
        Me.gboCode.Text = "Code d'accès :"
        '
        'GestionnaireErreur
        '
        Me.GestionnaireErreur.BlinkRate = 100
        Me.GestionnaireErreur.ContainerControl = Me
        '
        'FrmConnexion
        '
        Me.AcceptButton = Me.btnConnexion
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(460, 153)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnConnexion)
        Me.Controls.Add(Me.gboCode)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnexion"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ouverture de session"
        Me.gboCode.ResumeLayout(False)
        Me.gboCode.PerformLayout()
        CType(Me.GestionnaireErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnConnexion As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gboCode As System.Windows.Forms.GroupBox
    Friend WithEvents GestionnaireErreur As System.Windows.Forms.ErrorProvider
End Class
