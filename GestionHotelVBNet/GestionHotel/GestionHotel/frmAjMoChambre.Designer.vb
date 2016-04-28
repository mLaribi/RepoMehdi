<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjMoChambre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjMoChambre))
        Me.btnAjMo = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblCuisine = New System.Windows.Forms.Label()
        Me.lblNumChambre = New System.Windows.Forms.Label()
        Me.lblnbPlace = New System.Windows.Forms.Label()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.rdbOui = New System.Windows.Forms.RadioButton()
        Me.rdbNon = New System.Windows.Forms.RadioButton()
        Me.cboNbPlaces = New System.Windows.Forms.ComboBox()
        Me.cboType = New System.Windows.Forms.ComboBox()
        Me.gboDecision = New System.Windows.Forms.GroupBox()
        Me.gestErreur = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAjMo
        '
        Me.btnAjMo.Font = New System.Drawing.Font("Arial Narrow", 10.25!, System.Drawing.FontStyle.Bold)
        Me.btnAjMo.Location = New System.Drawing.Point(42, 348)
        Me.btnAjMo.Name = "btnAjMo"
        Me.btnAjMo.Size = New System.Drawing.Size(119, 32)
        Me.btnAjMo.TabIndex = 0
        Me.btnAjMo.Text = "non defini"
        Me.btnAjMo.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnnuler.Location = New System.Drawing.Point(217, 348)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(119, 32)
        Me.btnAnnuler.TabIndex = 1
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'lblTitre
        '
        Me.lblTitre.BackColor = System.Drawing.Color.Transparent
        Me.lblTitre.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.ForeColor = System.Drawing.Color.White
        Me.lblTitre.Location = New System.Drawing.Point(125, 9)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(179, 43)
        Me.lblTitre.TabIndex = 2
        Me.lblTitre.Text = "non défini"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.BackColor = System.Drawing.Color.Transparent
        Me.lblType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.ForeColor = System.Drawing.Color.White
        Me.lblType.Location = New System.Drawing.Point(39, 146)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(118, 16)
        Me.lblType.TabIndex = 3
        Me.lblType.Text = "Type de chambre"
        '
        'lblCuisine
        '
        Me.lblCuisine.AutoSize = True
        Me.lblCuisine.BackColor = System.Drawing.Color.Transparent
        Me.lblCuisine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuisine.ForeColor = System.Drawing.Color.White
        Me.lblCuisine.Location = New System.Drawing.Point(39, 215)
        Me.lblCuisine.Name = "lblCuisine"
        Me.lblCuisine.Size = New System.Drawing.Size(63, 16)
        Me.lblCuisine.TabIndex = 4
        Me.lblCuisine.Text = "Cuisine?"
        '
        'lblNumChambre
        '
        Me.lblNumChambre.AutoSize = True
        Me.lblNumChambre.BackColor = System.Drawing.Color.Transparent
        Me.lblNumChambre.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumChambre.ForeColor = System.Drawing.Color.White
        Me.lblNumChambre.Location = New System.Drawing.Point(39, 83)
        Me.lblNumChambre.Name = "lblNumChambre"
        Me.lblNumChambre.Size = New System.Drawing.Size(126, 16)
        Me.lblNumChambre.TabIndex = 5
        Me.lblNumChambre.Text = "Numéro chambre :"
        '
        'lblnbPlace
        '
        Me.lblnbPlace.AutoSize = True
        Me.lblnbPlace.BackColor = System.Drawing.Color.Transparent
        Me.lblnbPlace.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnbPlace.ForeColor = System.Drawing.Color.White
        Me.lblnbPlace.Location = New System.Drawing.Point(39, 282)
        Me.lblnbPlace.Name = "lblnbPlace"
        Me.lblnbPlace.Size = New System.Drawing.Size(131, 16)
        Me.lblnbPlace.TabIndex = 6
        Me.lblnbPlace.Text = "Nombre de places :"
        '
        'txtNum
        '
        Me.txtNum.BackColor = System.Drawing.SystemColors.Window
        Me.txtNum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNum.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtNum.Location = New System.Drawing.Point(193, 80)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(100, 22)
        Me.txtNum.TabIndex = 7
        '
        'rdbOui
        '
        Me.rdbOui.AutoSize = True
        Me.rdbOui.BackColor = System.Drawing.Color.Transparent
        Me.rdbOui.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbOui.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdbOui.Location = New System.Drawing.Point(193, 215)
        Me.rdbOui.Name = "rdbOui"
        Me.rdbOui.Size = New System.Drawing.Size(48, 20)
        Me.rdbOui.TabIndex = 8
        Me.rdbOui.TabStop = True
        Me.rdbOui.Text = "Oui"
        Me.rdbOui.UseVisualStyleBackColor = False
        '
        'rdbNon
        '
        Me.rdbNon.AutoSize = True
        Me.rdbNon.BackColor = System.Drawing.Color.Transparent
        Me.rdbNon.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbNon.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdbNon.Location = New System.Drawing.Point(285, 215)
        Me.rdbNon.Name = "rdbNon"
        Me.rdbNon.Size = New System.Drawing.Size(51, 20)
        Me.rdbNon.TabIndex = 9
        Me.rdbNon.TabStop = True
        Me.rdbNon.Text = "Non"
        Me.rdbNon.UseVisualStyleBackColor = False
        '
        'cboNbPlaces
        '
        Me.cboNbPlaces.BackColor = System.Drawing.SystemColors.Window
        Me.cboNbPlaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNbPlaces.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboNbPlaces.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboNbPlaces.FormattingEnabled = True
        Me.cboNbPlaces.Location = New System.Drawing.Point(193, 279)
        Me.cboNbPlaces.Name = "cboNbPlaces"
        Me.cboNbPlaces.Size = New System.Drawing.Size(121, 24)
        Me.cboNbPlaces.TabIndex = 10
        '
        'cboType
        '
        Me.cboType.BackColor = System.Drawing.SystemColors.Window
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(193, 146)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(121, 24)
        Me.cboType.TabIndex = 11
        '
        'gboDecision
        '
        Me.gboDecision.BackColor = System.Drawing.Color.Transparent
        Me.gboDecision.Location = New System.Drawing.Point(169, 195)
        Me.gboDecision.Name = "gboDecision"
        Me.gboDecision.Size = New System.Drawing.Size(191, 56)
        Me.gboDecision.TabIndex = 12
        Me.gboDecision.TabStop = False
        '
        'gestErreur
        '
        Me.gestErreur.ContainerControl = Me
        '
        'frmAjMoChambre
        '
        Me.AcceptButton = Me.btnAjMo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(401, 392)
        Me.Controls.Add(Me.cboType)
        Me.Controls.Add(Me.cboNbPlaces)
        Me.Controls.Add(Me.rdbNon)
        Me.Controls.Add(Me.rdbOui)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.lblnbPlace)
        Me.Controls.Add(Me.lblNumChambre)
        Me.Controls.Add(Me.lblCuisine)
        Me.Controls.Add(Me.lblType)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnAjMo)
        Me.Controls.Add(Me.gboDecision)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjMoChambre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAjMoChambre"
        CType(Me.gestErreur, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAjMo As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents lblCuisine As System.Windows.Forms.Label
    Friend WithEvents lblNumChambre As System.Windows.Forms.Label
    Friend WithEvents lblnbPlace As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents rdbOui As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNon As System.Windows.Forms.RadioButton
    Friend WithEvents cboNbPlaces As System.Windows.Forms.ComboBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents gboDecision As System.Windows.Forms.GroupBox
    Friend WithEvents gestErreur As System.Windows.Forms.ErrorProvider
End Class
