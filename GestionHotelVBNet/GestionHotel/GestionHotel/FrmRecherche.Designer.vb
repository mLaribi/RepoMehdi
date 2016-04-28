<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecherche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecherche))
        Me.txtMotsCles = New System.Windows.Forms.TextBox()
        Me.dgvRecherche = New System.Windows.Forms.DataGridView()
        Me.BtnRecherche = New System.Windows.Forms.Button()
        CType(Me.dgvRecherche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMotsCles
        '
        Me.txtMotsCles.Location = New System.Drawing.Point(111, 12)
        Me.txtMotsCles.Name = "txtMotsCles"
        Me.txtMotsCles.Size = New System.Drawing.Size(160, 21)
        Me.txtMotsCles.TabIndex = 1
        '
        'dgvRecherche
        '
        Me.dgvRecherche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecherche.Location = New System.Drawing.Point(0, 48)
        Me.dgvRecherche.Name = "dgvRecherche"
        Me.dgvRecherche.Size = New System.Drawing.Size(500, 203)
        Me.dgvRecherche.TabIndex = 2
        '
        'BtnRecherche
        '
        Me.BtnRecherche.Location = New System.Drawing.Point(304, 11)
        Me.BtnRecherche.Name = "BtnRecherche"
        Me.BtnRecherche.Size = New System.Drawing.Size(98, 23)
        Me.BtnRecherche.TabIndex = 4
        Me.BtnRecherche.Text = "Recherche"
        Me.BtnRecherche.UseVisualStyleBackColor = True
        '
        'FrmRecherche
        '
        Me.AcceptButton = Me.BtnRecherche
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(500, 326)
        Me.Controls.Add(Me.BtnRecherche)
        Me.Controls.Add(Me.dgvRecherche)
        Me.Controls.Add(Me.txtMotsCles)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRecherche"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recherche"
        CType(Me.dgvRecherche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMotsCles As System.Windows.Forms.TextBox
    Friend WithEvents dgvRecherche As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRecherche As System.Windows.Forms.Button
End Class
