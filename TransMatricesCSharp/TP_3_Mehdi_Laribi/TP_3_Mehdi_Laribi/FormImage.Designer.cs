namespace TP_3_Mehdi_Laribi
{
    partial class FormImage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImage));
            this.pboImgOrig = new System.Windows.Forms.PictureBox();
            this.btnCharger = new System.Windows.Forms.Button();
            this.btnNivGris = new System.Windows.Forms.Button();
            this.lblTranfo = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.txtTemps = new System.Windows.Forms.TextBox();
            this.lblAllerA = new System.Windows.Forms.Label();
            this.lblIteration = new System.Windows.Forms.Label();
            this.lblAvertissement = new System.Windows.Forms.Label();
            this.txtAllerA = new System.Windows.Forms.TextBox();
            this.cboTransformation = new System.Windows.Forms.ComboBox();
            this.lblNbIteration = new System.Windows.Forms.Label();
            this.pboImgTransforme = new System.Windows.Forms.PictureBox();
            this.pboGoStart = new System.Windows.Forms.PictureBox();
            this.pboPlayStop = new System.Windows.Forms.PictureBox();
            this.pboStop = new System.Windows.Forms.PictureBox();
            this.pboFast = new System.Windows.Forms.PictureBox();
            this.pboPlay = new System.Windows.Forms.PictureBox();
            this.tmrTransfo = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pboImgOrig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImgTransforme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboGoStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboPlayStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboFast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // pboImgOrig
            // 
            this.pboImgOrig.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pboImgOrig.Location = new System.Drawing.Point(12, 71);
            this.pboImgOrig.Name = "pboImgOrig";
            this.pboImgOrig.Size = new System.Drawing.Size(512, 512);
            this.pboImgOrig.TabIndex = 0;
            this.pboImgOrig.TabStop = false;
            // 
            // btnCharger
            // 
            this.btnCharger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharger.Location = new System.Drawing.Point(37, 12);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(100, 43);
            this.btnCharger.TabIndex = 1;
            this.btnCharger.Text = "Charger image";
            this.btnCharger.UseVisualStyleBackColor = true;
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // btnNivGris
            // 
            this.btnNivGris.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNivGris.Location = new System.Drawing.Point(155, 13);
            this.btnNivGris.Name = "btnNivGris";
            this.btnNivGris.Size = new System.Drawing.Size(92, 23);
            this.btnNivGris.TabIndex = 2;
            this.btnNivGris.Text = "Niveau gris";
            this.btnNivGris.UseVisualStyleBackColor = true;
            this.btnNivGris.Click += new System.EventHandler(this.btnNivGris_Click);
            // 
            // lblTranfo
            // 
            this.lblTranfo.AutoSize = true;
            this.lblTranfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranfo.Location = new System.Drawing.Point(156, 42);
            this.lblTranfo.Name = "lblTranfo";
            this.lblTranfo.Size = new System.Drawing.Size(91, 13);
            this.lblTranfo.TabIndex = 3;
            this.lblTranfo.Text = "Transformation";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemp.Location = new System.Drawing.Point(360, 18);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(68, 13);
            this.lblTemp.TabIndex = 5;
            this.lblTemp.Text = "Durée (ms)";
            // 
            // txtTemps
            // 
            this.txtTemps.Location = new System.Drawing.Point(434, 17);
            this.txtTemps.Name = "txtTemps";
            this.txtTemps.Size = new System.Drawing.Size(54, 20);
            this.txtTemps.TabIndex = 6;
            // 
            // lblAllerA
            // 
            this.lblAllerA.AutoSize = true;
            this.lblAllerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllerA.Location = new System.Drawing.Point(698, 27);
            this.lblAllerA.Name = "lblAllerA";
            this.lblAllerA.Size = new System.Drawing.Size(51, 13);
            this.lblAllerA.TabIndex = 13;
            this.lblAllerA.Text = "Aller à :";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIteration.Location = new System.Drawing.Point(920, 25);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(68, 15);
            this.lblIteration.TabIndex = 14;
            this.lblIteration.Text = "Itération :";
            // 
            // lblAvertissement
            // 
            this.lblAvertissement.AutoSize = true;
            this.lblAvertissement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvertissement.ForeColor = System.Drawing.Color.Green;
            this.lblAvertissement.Location = new System.Drawing.Point(563, 53);
            this.lblAvertissement.Name = "lblAvertissement";
            this.lblAvertissement.Size = new System.Drawing.Size(74, 15);
            this.lblAvertissement.TabIndex = 15;
            this.lblAvertissement.Text = "Non-défini";
            this.lblAvertissement.Visible = false;
            // 
            // txtAllerA
            // 
            this.txtAllerA.Location = new System.Drawing.Point(755, 26);
            this.txtAllerA.Name = "txtAllerA";
            this.txtAllerA.Size = new System.Drawing.Size(37, 20);
            this.txtAllerA.TabIndex = 16;
            // 
            // cboTransformation
            // 
            this.cboTransformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransformation.FormattingEnabled = true;
            this.cboTransformation.Location = new System.Drawing.Point(278, 42);
            this.cboTransformation.Name = "cboTransformation";
            this.cboTransformation.Size = new System.Drawing.Size(246, 21);
            this.cboTransformation.TabIndex = 17;
            // 
            // lblNbIteration
            // 
            this.lblNbIteration.AutoSize = true;
            this.lblNbIteration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNbIteration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNbIteration.Location = new System.Drawing.Point(994, 27);
            this.lblNbIteration.Name = "lblNbIteration";
            this.lblNbIteration.Size = new System.Drawing.Size(14, 13);
            this.lblNbIteration.TabIndex = 18;
            this.lblNbIteration.Text = "0";
            // 
            // pboImgTransforme
            // 
            this.pboImgTransforme.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pboImgTransforme.Location = new System.Drawing.Point(530, 71);
            this.pboImgTransforme.Name = "pboImgTransforme";
            this.pboImgTransforme.Size = new System.Drawing.Size(512, 512);
            this.pboImgTransforme.TabIndex = 19;
            this.pboImgTransforme.TabStop = false;
            // 
            // pboGoStart
            // 
            this.pboGoStart.Image = ((System.Drawing.Image)(resources.GetObject("pboGoStart.Image")));
            this.pboGoStart.Location = new System.Drawing.Point(855, 20);
            this.pboGoStart.Name = "pboGoStart";
            this.pboGoStart.Size = new System.Drawing.Size(38, 35);
            this.pboGoStart.TabIndex = 9;
            this.pboGoStart.TabStop = false;
            this.pboGoStart.Click += new System.EventHandler(this.pboGoStart_Click);
            // 
            // pboPlayStop
            // 
            this.pboPlayStop.Image = ((System.Drawing.Image)(resources.GetObject("pboPlayStop.Image")));
            this.pboPlayStop.Location = new System.Drawing.Point(811, 20);
            this.pboPlayStop.Name = "pboPlayStop";
            this.pboPlayStop.Size = new System.Drawing.Size(38, 35);
            this.pboPlayStop.TabIndex = 10;
            this.pboPlayStop.TabStop = false;
            this.pboPlayStop.Click += new System.EventHandler(this.pboPlayStop_Click);
            // 
            // pboStop
            // 
            this.pboStop.Image = ((System.Drawing.Image)(resources.GetObject("pboStop.Image")));
            this.pboStop.Location = new System.Drawing.Point(654, 17);
            this.pboStop.Name = "pboStop";
            this.pboStop.Size = new System.Drawing.Size(38, 35);
            this.pboStop.TabIndex = 11;
            this.pboStop.TabStop = false;
            this.pboStop.Click += new System.EventHandler(this.pboStop_Click);
            // 
            // pboFast
            // 
            this.pboFast.Image = ((System.Drawing.Image)(resources.GetObject("pboFast.Image")));
            this.pboFast.Location = new System.Drawing.Point(610, 17);
            this.pboFast.Name = "pboFast";
            this.pboFast.Size = new System.Drawing.Size(38, 35);
            this.pboFast.TabIndex = 12;
            this.pboFast.TabStop = false;
            this.pboFast.Click += new System.EventHandler(this.pboFast_Click);
            // 
            // pboPlay
            // 
            this.pboPlay.Image = ((System.Drawing.Image)(resources.GetObject("pboPlay.Image")));
            this.pboPlay.InitialImage = ((System.Drawing.Image)(resources.GetObject("pboPlay.InitialImage")));
            this.pboPlay.Location = new System.Drawing.Point(566, 17);
            this.pboPlay.Name = "pboPlay";
            this.pboPlay.Size = new System.Drawing.Size(38, 35);
            this.pboPlay.TabIndex = 8;
            this.pboPlay.TabStop = false;
            this.pboPlay.Click += new System.EventHandler(this.pboPlay_Click);
            // 
            // tmrTransfo
            // 
            this.tmrTransfo.Tick += new System.EventHandler(this.tmrTransfo_Tick);
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 592);
            this.Controls.Add(this.pboImgTransforme);
            this.Controls.Add(this.lblNbIteration);
            this.Controls.Add(this.cboTransformation);
            this.Controls.Add(this.txtAllerA);
            this.Controls.Add(this.lblAvertissement);
            this.Controls.Add(this.lblIteration);
            this.Controls.Add(this.lblAllerA);
            this.Controls.Add(this.pboFast);
            this.Controls.Add(this.pboStop);
            this.Controls.Add(this.pboPlayStop);
            this.Controls.Add(this.pboGoStart);
            this.Controls.Add(this.pboPlay);
            this.Controls.Add(this.txtTemps);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblTranfo);
            this.Controls.Add(this.btnNivGris);
            this.Controls.Add(this.btnCharger);
            this.Controls.Add(this.pboImgOrig);
            this.Name = "FormImage";
            this.Text = "Transformation sur des images (TP-3, 420-216-FX, Hivers 2014)";
            this.Load += new System.EventHandler(this.FormImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboImgOrig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboImgTransforme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboGoStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboPlayStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboFast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboImgOrig;
        private System.Windows.Forms.Button btnCharger;
        private System.Windows.Forms.Button btnNivGris;
        private System.Windows.Forms.Label lblTranfo;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.TextBox txtTemps;
        private System.Windows.Forms.Label lblAllerA;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Label lblAvertissement;
        private System.Windows.Forms.TextBox txtAllerA;
        private System.Windows.Forms.ComboBox cboTransformation;
        private System.Windows.Forms.Label lblNbIteration;
        private System.Windows.Forms.PictureBox pboImgTransforme;
        private System.Windows.Forms.PictureBox pboGoStart;
        private System.Windows.Forms.PictureBox pboPlayStop;
        private System.Windows.Forms.PictureBox pboStop;
        private System.Windows.Forms.PictureBox pboFast;
        private System.Windows.Forms.PictureBox pboPlay;
        private System.Windows.Forms.Timer tmrTransfo;
    }
}

