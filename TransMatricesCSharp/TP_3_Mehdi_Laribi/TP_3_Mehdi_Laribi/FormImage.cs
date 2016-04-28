//Programmation objet 2
//Programmeur : Mehdi Laribi
//Date: 2014-05-19 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TP3_Transformations;
using Cours_420_216;

namespace TP_3_Mehdi_Laribi
{
    public partial class FormImage : Form
    {
        //Accesseur global pour l'image ImgSource, ImgTransfo
        public BitmapMatricielle ImgSource { get; set; }
        public BitmapMatricielle ImgTransfo { get; set; }

        //Variable générale pour le nombre d'itération
        int nbIterations = 0;

        public FormImage()
        {
            InitializeComponent();
        }


        #region ÉVÈNEMENTS
        /// <summary>
        /// Au lancement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormImage_Load(object sender, EventArgs e)
        {
                //Création des variables qui contiendront les deux images de type BitmapMatricielle
                this.ImgSource = new BitmapMatricielle(); // Image originale
                this.ImgTransfo = new BitmapMatricielle(); // Image Transformée
                //Inititalisation du text de la durée en ms à 100ms
                this.txtTemps.Text = "100";
                //Affichages des choix de transformations dans le comboBox.
                this.cboTransformation.DataSource = UtilEnum.GetAllDescriptions<TransformationType>();
        }

        /// <summary>
        /// Évènement sur le bouton "Charger image" qui permet de ramener une image à partir de l'ordinateur. 
        ///  </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharger_Click(object sender, EventArgs e)
        {
            //Remet le compteur d'itération à 0;
            nbIterations = 0; //Variable
            lblNbIteration.Text = "0";    //Label                   
            //Cache le message qui avertis l'utilisateur du nombre d'itération (en vert)
            this.lblAvertissement.Visible = false;
            //Variable pour le chemin de l'image
            String cheminImg;
            //Vérifie si l'utilisateur a selectionner qui (la réponse) sera stockée dans la variable reponse
            bool reponse = Cours_420_216.Utilitaire.DemanderSelectionnerFichierImage(out cheminImg);
            if (reponse)
            {

                //Si l'utilisateur a selectionner une image celle-ci est affichée dans les deux pictureVox
                this.ImgSource.ImageBitmap = (Bitmap)Bitmap.FromFile(cheminImg);
                this.ImgTransfo.ImageBitmap = (Bitmap)Bitmap.FromFile(cheminImg);
                this.pboImgOrig.Image = this.ImgSource.ImageBitmap;
                this.pboImgTransforme.Image = this.ImgTransfo.ImageBitmap;
            }
            //Sinon un message d'annulation est affiché.
            else
            {
                MessageBox.Show("Opération annulée", "Annulation");
            }
        }

        /// <summary>
        /// Bouton niveau de gris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNivGris_Click(object sender, EventArgs e)
        {
            //Validation pixel indexés
            try
            {
                //Applique le niveau de gris sur les deux images
                this.ImgSource.NiveauGris();
                this.ImgTransfo.NiveauGris();
                //Rafraichi les PictureBox
                this.pboImgTransforme.Invalidate();
                this.pboImgOrig.Invalidate();
            }

            //Retourne un message d'exception pour les pixel indexés
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        /// <summary>
        /// Bouton play 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboPlay_Click(object sender, EventArgs e)
        {
            //Affection le nombre d'itération au label
            this.lblNbIteration.Text = nbIterations.ToString();
            //Choix de la transformation en appelant la méthode static plus bas
            SwitchTransformation();
        }

        /// <summary>
        /// Bouton Avance rapide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboFast_Click(object sender, EventArgs e)
        {
            //Modifie le temps d'intevalle entre chaque tick avec le nombre saisie par l'utilisateur 
            try
            {
                int intervalTemp = int.Parse(this.txtTemps.Text);
                //Affecte l'intervalle de temps au timer
                this.tmrTransfo.Interval = intervalTemp;
            }
            //si le nombre est négatif retourne un message
            catch (ArgumentOutOfRangeException AoRe)
            {
                MessageBox.Show("Temps invalide, la transformation se fera avec un temps par défaut!", "Erreur");
            }
       
            //Lancement du timer
            this.tmrTransfo.Start();
            //Remise de la variable d'itération à 0
            nbIterations = 0;
        }

        /// <summary>
        /// Bouton arrêt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboStop_Click(object sender, EventArgs e)
        {
            //Arrete le timer
            this.tmrTransfo.Stop();
        }
        /// <summary>
        /// Bouton qui permet d'aller à une itération précise
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboPlayStop_Click(object sender, EventArgs e)
        {
            //Validation du textBox
            int allerA;
            bool allerAValide = int.TryParse(this.txtAllerA.Text, out allerA);
            //Si plus petit que 0 affiche un message
            if (allerA < 0)
            {
                allerAValide = false;
                MessageBox.Show("opération invalide (le nombre est invalide)");
            }
                //sinon exécute le reste
            else
            {

                //Boucle qui fera la transformation en arrière plan le nombre de fois écrit dans le textBox (Variable allerA) 
                for (int i = 0; i < allerA; i++)
                {
                    SwitchTransformation();
                    //Validation si le nombre saisi est trop grand
                    if (this.ImgSource == this.ImgTransfo)
                    {
                        MessageBox.Show("Nombre trop grand");
                        break;
                    }
                }
                //Affecte l'image au pictureBox et le fait rafraichir
                this.pboImgTransforme.Image = ImgTransfo.ImageBitmap;
                this.ImgTransfo = this.ImgSource;
                this.pboImgTransforme.Invalidate();
            }

            
        }
        /// <summary>
        /// Recommence depuis le début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pboGoStart_Click(object sender, EventArgs e)
        {
            //Remise des compteurs à 0
            nbIterations = 0;
            this.lblNbIteration.Text = "0";
            //Affiche le label en vert 
            this.lblAvertissement.Visible = false;
            //Remet l'image d'origine sur le pictureBox de la transformée
            this.pboImgTransforme.Image = this.ImgSource.ImageBitmap;

        }

        /// <summary>
        /// Méthode static qui contiendra le switch des transformations (choix)
        /// </summary>
        public void SwitchTransformation()
        {
            switch (cboTransformation.SelectedIndex)
            {
                    //Miroir horizontal
                case 0:
                    //Transforme l'image
                    this.ImgTransfo.MiroirHorizontal();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Miroir vertical
                case 1:
                    //Transforme l'image
                    this.ImgTransfo.MiroirVertical();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Transposition 
                case 2:
                    //Transforme l'image
                    this.ImgTransfo.Transposition();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Décalage horizontal
                case 3:
                    //Transforme l'image
                    this.ImgTransfo.DecalageHorizontal();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Décalage diagonale
                case 4:
                    //Transforme l'image
                    this.ImgTransfo.DecalageDiagonale();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Colonnes
                case 5:
                    //Transforme l'image
                    this.ImgTransfo.Colonnes();
                    //Rafraichi l'image
                    this.pboImgTransforme.Invalidate();
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    // Photomaton
                case 6:
                    //Transforme l'image
                    this.ImgTransfo.Photomaton();
                    //Réaffecte l'image d'origine à la transformée
                    this.pboImgTransforme.Image = ImgTransfo.ImageBitmap;
                    //Incrémente le nombre d'itération 
                    nbIterations++;
                    break;
                    //Boulanger
                case 7:
                    //Transforme l'image
                    this.ImgTransfo.Boulanger();
                    //Réaffecte l'image d'origine à la transformée
                    this.pboImgTransforme.Image = ImgTransfo.ImageBitmap;
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Fleur
                case 8:
                    //Transforme l'image
                    this.ImgTransfo.Fleur();
                    //Réaffecte l'image d'origine à la transformée
                    this.pboImgTransforme.Image = ImgTransfo.ImageBitmap;
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
                    //Svastika
                case 9:
                    //Transforme l'image
                    this.ImgTransfo.Svastika();
                    //Réaffecte l'image d'origine à la transformée
                    this.pboImgTransforme.Image = ImgTransfo.ImageBitmap;
                    //Incrémente le nombre d'itération
                    nbIterations++;
                    break;
            }
            //Affiche le nombre d'itération dans le label
            this.lblNbIteration.Text = nbIterations.ToString();
            //Si l'image est égale à celle d'origine elle affiche un message en vert avec le nombre d'itération totale
            if (this.ImgSource == this.ImgTransfo)
            {
                //Arrête le timer
                this.tmrTransfo.Stop();
                this.lblAvertissement.Visible = true;
                this.lblAvertissement.Text = String.Format("Transformations completée en {0} étapes!", nbIterations);
            }
        }
        /// <summary>
        /// Le timer qui fera les actions à chaque "Tick"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrTransfo_Tick(object sender, EventArgs e)
        {
            
            //Switch des transformations
            SwitchTransformation();
        }

    }

   
    #endregion
}

