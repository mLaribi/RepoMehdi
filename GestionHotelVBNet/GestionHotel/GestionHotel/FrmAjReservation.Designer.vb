<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAjReservation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAjReservation))
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.dgvSuggeChambre = New System.Windows.Forms.DataGridView()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.cboNbNuits = New System.Windows.Forms.ComboBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblnbNuits = New System.Windows.Forms.Label()
        Me.chkCuisine = New System.Windows.Forms.CheckBox()
        Me.numNbPlaces = New System.Windows.Forms.NumericUpDown()
        Me.lblNbPlaces = New System.Windows.Forms.Label()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        CType(Me.dgvSuggeChambre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNbPlaces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.BackColor = System.Drawing.Color.Transparent
        Me.lblTitre.Font = New System.Drawing.Font("Arial", 19.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblTitre.Location = New System.Drawing.Point(174, 9)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(303, 30)
        Me.lblTitre.TabIndex = 2
        Me.lblTitre.Text = "Ajout d'une réservation"
        '
        'dgvSuggeChambre
        '
        Me.dgvSuggeChambre.BackgroundColor = System.Drawing.Color.Gray
        Me.dgvSuggeChambre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuggeChambre.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgvSuggeChambre.Location = New System.Drawing.Point(12, 178)
        Me.dgvSuggeChambre.Name = "dgvSuggeChambre"
        Me.dgvSuggeChambre.Size = New System.Drawing.Size(624, 125)
        Me.dgvSuggeChambre.TabIndex = 3
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(112, 52)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(154, 21)
        Me.dtpDate.TabIndex = 4
        '
        'cboNbNuits
        '
        Me.cboNbNuits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNbNuits.FormattingEnabled = True
        Me.cboNbNuits.Location = New System.Drawing.Point(441, 54)
        Me.cboNbNuits.MaxDropDownItems = 5
        Me.cboNbNuits.Name = "cboNbNuits"
        Me.cboNbNuits.Size = New System.Drawing.Size(121, 23)
        Me.cboNbNuits.TabIndex = 5
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(36, 55)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(49, 18)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Date :"
        '
        'lblnbNuits
        '
        Me.lblnbNuits.AutoSize = True
        Me.lblnbNuits.BackColor = System.Drawing.Color.Transparent
        Me.lblnbNuits.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnbNuits.Location = New System.Drawing.Point(314, 55)
        Me.lblnbNuits.Name = "lblnbNuits"
        Me.lblnbNuits.Size = New System.Drawing.Size(111, 18)
        Me.lblnbNuits.TabIndex = 7
        Me.lblnbNuits.Text = "Nombre nuits :"
        '
        'chkCuisine
        '
        Me.chkCuisine.AutoSize = True
        Me.chkCuisine.BackColor = System.Drawing.Color.Transparent
        Me.chkCuisine.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuisine.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.chkCuisine.Location = New System.Drawing.Point(441, 107)
        Me.chkCuisine.Name = "chkCuisine"
        Me.chkCuisine.Size = New System.Drawing.Size(107, 20)
        Me.chkCuisine.TabIndex = 8
        Me.chkCuisine.Text = "Avec cuisine"
        Me.chkCuisine.UseVisualStyleBackColor = False
        '
        'numNbPlaces
        '
        Me.numNbPlaces.Location = New System.Drawing.Point(186, 106)
        Me.numNbPlaces.Name = "numNbPlaces"
        Me.numNbPlaces.Size = New System.Drawing.Size(80, 21)
        Me.numNbPlaces.TabIndex = 9
        '
        'lblNbPlaces
        '
        Me.lblNbPlaces.AutoSize = True
        Me.lblNbPlaces.BackColor = System.Drawing.Color.Transparent
        Me.lblNbPlaces.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblNbPlaces.Location = New System.Drawing.Point(36, 107)
        Me.lblNbPlaces.Name = "lblNbPlaces"
        Me.lblNbPlaces.Size = New System.Drawing.Size(122, 18)
        Me.lblNbPlaces.TabIndex = 10
        Me.lblNbPlaces.Text = "Nombre places :"
        '
        'btnAjouter
        '
        Me.btnAjouter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAjouter.Location = New System.Drawing.Point(121, 309)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(145, 39)
        Me.btnAjouter.TabIndex = 11
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAnnuler.Location = New System.Drawing.Point(356, 309)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(145, 39)
        Me.btnAnnuler.TabIndex = 12
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'FrmAjReservation
        '
        Me.AcceptButton = Me.btnAjouter
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New System.Drawing.Size(648, 360)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.lblNbPlaces)
        Me.Controls.Add(Me.numNbPlaces)
        Me.Controls.Add(Me.chkCuisine)
        Me.Controls.Add(Me.lblnbNuits)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cboNbNuits)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.dgvSuggeChambre)
        Me.Controls.Add(Me.lblTitre)
        Me.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAjReservation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajout d'une réservation"
        CType(Me.dgvSuggeChambre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNbPlaces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitre As System.Windows.Forms.Label
    Friend WithEvents dgvSuggeChambre As System.Windows.Forms.DataGridView
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboNbNuits As System.Windows.Forms.ComboBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblnbNuits As System.Windows.Forms.Label
    Friend WithEvents chkCuisine As System.Windows.Forms.CheckBox
    Friend WithEvents numNbPlaces As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblNbPlaces As System.Windows.Forms.Label
    Friend WithEvents btnAjouter As System.Windows.Forms.Button
    Friend WithEvents btnAnnuler As System.Windows.Forms.Button
End Class
