//Programmation objet 2
//Programmeur : Mehdi Laribi
//Date: 2014-05-19 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Cours_420_216;
using TP3_Transformations;
using TP_3_Mehdi_Laribi;


namespace Cours_420_216
{
    /// <summary>
    /// Classe représentant une image bitmap et permettant la manipulation de ses pixels avec la notation matricielle.
    /// </summary>
    public class BitmapMatricielle
    {
        #region ATTRIBUTS
        // =========
        // Attributs
        // =========

        /// <summary>
        /// L'image bitmap que représente l'objet.
        /// </summary>
        private Bitmap _imageBitmap;

        #endregion

        #region CONSTRUCTEURS
        // =============
        // Constructeurs
        // =============

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public BitmapMatricielle()
        {
            this.ImageBitmap = null;
        }

        /// <summary>
        /// Constructeur avec l'image bitmap comme paramètre.
        /// </summary>
        /// <param name="imageBitmap">Bitmap que représente l'objet.</param>
        public BitmapMatricielle(Bitmap imageBitmap)
        {
            this.ImageBitmap = imageBitmap;
        }

        #endregion

        #region ACCESSEURS
        // ==========
        // Accesseurs
        // ==========

        /// <summary>
        /// Image bitmap que représente l'objet.
        /// </summary>
        public Bitmap ImageBitmap
        {
            get { return this._imageBitmap; }
            set { this._imageBitmap = value; }
        }

        /// <summary>
        /// Hauteur de l'image.
        /// </summary>
        public int Hauteur
        {
            get { return _imageBitmap.Height; }
        }

        /// <summary>
        /// Largeur de l'image.
        /// </summary>
        public int Largeur
        {
            get { return _imageBitmap.Width; }
        }

        #endregion

        #region OPÉRATEURS
        // ==========
        // Opérateurs
        // ==========

        /// <summary>
        /// Surcharge de l'opérateur d'égalité (==)
        /// </summary>
        /// <param name="imgSource">Image de départ</param>
        /// <param name="imgTranfo">Image qu'in transforme</param>
        /// <returns>true si les deux images sont égales; false, autrement.</returns>
        public static bool operator ==(BitmapMatricielle imgSource, BitmapMatricielle imgTranfo)
        {
            // Pour gérer le cas où les deux objets reçus en paramètre sont nuls ou bien le même objet.
            if (System.Object.ReferenceEquals(imgSource, imgTranfo))
            {
                return true;
            }
            // Pour gérer le cas où un des deux objets reçus en paramètre est nul mais pas les deux (cas précédent).
            else if (((Object)imgSource == null) || ((Object)imgTranfo == null))
            {
                return false;
            }
            else
            {
                //Pour parcourir chaque pixel de l'image.
                for (int i = 0; i < imgSource.Hauteur; i++)
                {
                    for (int j = 0; j < imgSource.Largeur; j++)
                    {
                        //Si le pixel à la position [i, j] n'est pas égale dans les deux images, cela retourne false.
                        if (imgSource[i, j] != imgTranfo[i, j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Permet de vérifier si les deux objets sont égaux (Pixels)
        /// </summary>
        /// <param name="obj">Objet de type BitmapMatricielle à comparer avec l'objet courant</param>
        /// <returns>true si les deux objets sont égaux; false, autrement.</returns>
        public override bool Equals(Object obj)
        {
            // Est-ce que "obj" est du type BitmapMatricielle.
            if (obj.GetType() == typeof(BitmapMatricielle))
                return this == (BitmapMatricielle)obj;
            else
                return false;
        }

        /// <summary>
        /// Surcharge de l'opérateur d'inégalité (!=)
        /// </summary>
        /// <param name="imgSource"></param>
        /// <param name="imgTransfo"></param>
        /// <returns></returns>
        public static bool operator !=(BitmapMatricielle imgSource, BitmapMatricielle imgTransfo)
        {
            // Retourne l'inverse de l'opérateur d'égalité.
            return !(imgSource == imgTransfo);
        }

        #endregion

        #region INDEXEURS
        // =========
        // Indexeurs
        // =========

        // À COMPLÉTER : Indexeur [i, j] pour accéder et modifier les pixels de l'image (ligne=i = y = largeur, hauteur =j = x = hauteur).

        /// <summary>
        /// Indéxeur qui permet d'acceder au pixel d'une position [i, j]
        /// </summary>
        /// <param name="i">La hauteur de l'image</param>
        /// <param name="j">La largeur de l'image</param>
        /// <returns>Pixel de l'image</returns>
        public Color this[int i, int j]
        {

            get
            {
                //Validation de l'indice
                if (i < 0 || i >= this.Hauteur || j < 0 || j > this.Largeur)
                    throw new IndexOutOfRangeException("L'indice est hors des limites de l'image");
                //Retourne le pixel de l'image
                return this.ImageBitmap.GetPixel(j, i);
            }
            set
            {
                //Permet d'aller chercher 
                this.ImageBitmap.SetPixel(j, i, value);
            }
        }
        #endregion

        #region MÉTHODES
        // ========
        // Méthodes
        // ========
        #region VALIDATION

        /// <summary>
        /// Validation image à dimension paires
        /// </summary>
        private void ImagePaireValidation()
        {
            //Si le modulo n'est pas égal à 0
            //Lance une exception avec un message approprié
            if (this.Hauteur % 2 == 1 || this.Largeur % 2 == 1)
                throw new InvalidOperationException("Pour faire cette transformation, il faut une image à dimension paires!");
        }
        /// <summary>
        /// Validation image carré
        /// </summary>
        private void ImageCarréValidation()
        {
            if (this.Hauteur != this.Largeur)
                throw new InvalidOperationException("Il vous faut une image carré pour utiliser cette transformation!");
        }
        #endregion

        #region NIVEAU GRIS

        /// <summary>
        /// Méthode niveau de gris
        /// </summary>
        public void NiveauGris()
        {
            //Parcour chaque pixel de l'image ligne par ligne 
            for (int i = 0; i < this.Hauteur; i++)
            {
                for (int j = 0; j < this.Largeur; j++)
                {
                    Color c = this[i, j];
                    //Ratio du niveau de gris à mettre.
                    //Modifie chaque pixel pour le transformer en gris
                    int rgb = (int)(c.R * 0.3 + c.G * 0.59 + c.B * 0.11);
                    this[i, j] = Color.FromArgb(rgb, rgb, rgb);
                }
            }

        }
        #endregion

        #region MIROIR HORIZONTAL

        /// <summary>
        /// Transformation en miroir horizontal (Index = 0) 
        /// </summary>
        public void MiroirHorizontal()
        {
            //Variable pixel temporaire qui permet de sauver un pixel avant de l'écraser
            Color pixel;

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur; i++)
            {
                for (int j = 0; j < this.Largeur / 2; j++)
                {
                    //Affecte le pixel à la variable avant d'être écrasée
                    pixel = this[i, j];
                    // Déplacement des pixels 
                    this[i, j] = this[i, this.Largeur - j - 1];
                    //Assigne le pixel à sa nouvelle position
                    this[i, this.Largeur - 1 - j] = pixel;
                }
            }
        }
        #endregion

        #region MIROIR VERTICAL
        /// <summary>
        /// Transformation en miroir vertical (Index = 1)
        /// </summary>
        public void MiroirVertical()
        {
            //Parcour chaque pixel de l'image
            for (int j = 0; j < this.Largeur; j++)
            {
                for (int i = 0; i < this.Hauteur / 2; i++)
                {
                    //Variable pixel qui stockera le pixel avant d'être perdu
                    Color dernierPixel = this[i, j];
                    //Déplace chaque pixel
                    this[i, j] = this[this.Hauteur - i - 1, j];
                    //Assigne le pixel à sa nouvelle position
                    this[this.Hauteur - i - 1, j] = dernierPixel;
                }
            }
        }
        #endregion

        #region TRANSPOSITION

        /// <summary>
        /// Transformation transposition (Index = 2)
        /// </summary>
        public void Transposition()
        {

            //Validation taille (carré)
            ImageCarréValidation();
            //Variable pixel qui stockera le pixel avant d'être perdu
            Color pixelTempo;
            //Parcour chaque pixel de l'image
            for (int j = 0; j < this.Largeur; j++)
            {
                for (int i = 0; i < j + 1; i++)
                {
                    //pixel perdu
                    pixelTempo = this[i, j];
                    //Déplacement des pixel
                    this[i, j] = this[j, i];
                    //Assigne le pixel à sa nouvelle position
                    this[j, i] = pixelTempo;
                }
            }
        }

        #endregion

        #region DÉCALAGE HORIZONTAL

        /// <summary>
        /// Transformation par décalage horizontal (Index = 3)
        /// </summary>
        public void DecalageHorizontal()
        {

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur; i++)
            {
                //Variable pixel qui stockera le pixel avant d'être perdu
                Color dernierPixel = this[i, this.Largeur - 1];
                for (int j = this.Largeur - 1; j > 0; j--)
                {
                    //Déplacement des pixels
                    this[i, j] = this[i, j - 1];
                }
                //Assigne le pixel à sa nouvelle position
                this[i, 0] = dernierPixel;
            }
        }
        #endregion

        #region DÉCALAGE EN DIAGONALE
        /// <summary>
        /// Transformation par décalage en diagonale (Index = 4)
        /// </summary>
        public void DecalageDiagonale()
        {
            //Vecteurs temporaire qui contiendra le meme nombre de pixel que la largeur  et la hauteur
            Color[] vectTempCol = new Color[this.Hauteur - 1];
            Color[] vectTempLi = new Color[this.Largeur - 1];
            //Variable pixel qui stockera le pixel avant d'être perdu
            Color pixelTemp = this[this.Hauteur - 1, this.Largeur - 1];

            //Boucle qui remplira le vecteurs tempo avec les pixels
            for (int j = 0; j < this.Largeur - 1; j++)
            {
                vectTempLi[j] = this[this.Hauteur - 1, j];
            }
            for (int i = 0; i < this.Hauteur - 1; i++)
            {
                vectTempCol[i] = this[i, this.Largeur - 1];
            }


            //Parcour chaque pixel de l'image
            for (int i = this.Hauteur - 1; i > 0; i--)
            {
                for (int j = this.Largeur - 1; j > 0; j--)
                {

                    this[i, j] = this[i - 1, j - 1];
                }
            }

            //Déplacement des deux vecteur à leurs nouvelles positions
            for (int j = 0; j < this.Largeur - 1; j++)
            {
                this[0, j + 1] = vectTempLi[j];

            }
            for (int i = 0; i < this.Hauteur - 1; i++)
            {
                this[i + 1, 0] = vectTempCol[i];
            }

            //Assigne le pixel à sa nouvelle position de la diagonale 
            this[0, 0] = pixelTemp;
        }
        #endregion

        #region COLONNES
        /// <summary>
        /// Transformation en colonnes (Index = 5)
        /// </summary>
        public void Colonnes()
        {
            //Validation taille
            ImagePaireValidation();
            //Vecteurs temporaires
            Color[] vectPix1 = new Color[this.Largeur / 2];
            Color[] vectPix2 = new Color[this.Largeur / 2];

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur; i++)
            {
                for (int j = 0; j < this.Largeur / 2; j++)
                {
                    vectPix1[j] = this[i, j];
                    vectPix2[j] = this[i, (this.Largeur / 2) + j];
                }


                for (int j = 0; j < this.Largeur; j += 2)
                {
                    //Assigne les vecteurs à leurs nouvelles positions
                    this[i, j] = vectPix1[j / 2];
                    this[i, j + 1] = vectPix2[j / 2];
                }
            }
        }
      

        #endregion

        #region PHOTOMATON

        /// <summary>
        /// Transformation en photomaton (Index = 6)
        /// </summary>
        public void Photomaton()
        {
            //Validation dimensions
            ImagePaireValidation();
            //Création d'une nouvelle image temporaire 
            Bitmap nouvelleBtm = new Bitmap(this.Largeur, this.Hauteur, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapMatricielle imgTn = new BitmapMatricielle(nouvelleBtm);

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur / 2; i++)
            {
                for (int j = 0; j < this.Largeur / 2; j++)
                {
                    //Déplacement des pixels pour réussir la transformation
                    imgTn[i, j] = this[i * 2, j * 2];
                    imgTn[i, (this.Largeur / 2) + j] = this[i * 2, j * 2 + 1];
                    imgTn[(this.Hauteur / 2) + i, j] = this[i * 2 + 1, j * 2];
                    imgTn[(this.Hauteur / 2) + i, (this.Largeur / 2) + j] = this[i * 2 + 1, j * 2 + 1];
                }
            }
            //Affecte la nouvelle image pour pouvoir être affichée
            this.ImageBitmap = nouvelleBtm;
        }

        #endregion

        #region BOULANGER

        /// <summary>
        /// Transformation boulanger (Index = 7)
        /// </summary>
        public void Boulanger()
        {
            //Validation taille;
            ImagePaireValidation();
            //Création d'une nouvelle image temporaire 
            Bitmap nouvelleImage = new Bitmap(this.Largeur * 2, this.Hauteur / 2, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapMatricielle imgTransfo = new BitmapMatricielle(nouvelleImage);

            //Parcour chaque pixel de l'image
            for (int j = 0; j < imgTransfo.Largeur; j += 2)
            {

                for (int i = 0; i < imgTransfo.Hauteur; i++)
                {
                    //Déplacement des pixels pour réussir la premiere transformation (élargissement)
                    imgTransfo[i, j] = this[i * 2, j / 2];
                    imgTransfo[i, j + 1] = this[2 * i + 1, j / 2];
                }

            }
            //Parcour chaque pixel de l'image
            for (int i = 0; i < imgTransfo.Hauteur; i++)
            {
                for (int j = 0; j < imgTransfo.Largeur / 2; j++)
                {
                    //Déplacement des pixels pour réussir la deuxieme étape : Déplacement dans la nouvelle image
                    this[i, j] = imgTransfo[i, j];
                }
            }
            //Parcour chaque pixel de l'image
            for (int i = imgTransfo.Hauteur - 1; i >= 0; i--)
            {
                for (int j = 0; j < imgTransfo.Largeur / 2; j++)
                {
                    //Déplacement des pixels pour le découpage et l'effet miroir vertical
                    this[(imgTransfo.Hauteur * 2) - (i + 1), j] = imgTransfo[i, (imgTransfo.Largeur - 1) - j];
                }
            }
           

        }
        #endregion

        #region SVASTIKA

        /// <summary>
        /// Transformation svastika (Bonus (Index = 8))
        /// </summary>
        public void Svastika()
        {
            //Validation taille;
            ImagePaireValidation();

            //Création d'une nouvelle image temporaire 
            Bitmap nouvelleBtm = new Bitmap(this.Largeur, this.Hauteur, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapMatricielle imgTn = new BitmapMatricielle(nouvelleBtm);

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur / 2; i++)
            {
                for (int j = 0; j < this.Largeur / 2; j++)
                {
                    //Déplacement des pixels pour réussir la transformation (multiplication des images avec les effets miroirs)
                    imgTn[i, j] = this[i * 2, j * 2];
                    imgTn[j, this.Largeur - 1 - i] = this[i * 2, j * 2 + 1];
                    imgTn[this.Hauteur - 1 - j, i] = this[i * 2 + 1, j * 2];
                    imgTn[this.Hauteur - i - 1, this.Largeur - j - 1] = this[i * 2 + 1, j * 2 + 1];
                }
            }
            //Affecte la nouvelle image pour pouvoir être affichée
            this.ImageBitmap = nouvelleBtm;
        }
        #endregion

        #region FLEUR
        /// <summary>
        /// Transformation en fleur (Bonus (Index = 9))
        /// </summary>
        public void Fleur()
        {
            //Validation taille;
            ImagePaireValidation();
            //Création d'une nouvelle image temporaire 
            Bitmap nouvelleBtm = new Bitmap(this.Largeur, this.Hauteur, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            BitmapMatricielle imgTn = new BitmapMatricielle(nouvelleBtm);

            //Parcour chaque pixel de l'image
            for (int i = 0; i < this.Hauteur / 2; i++)
            {
                for (int j = 0; j < this.Largeur / 2; j++)
                {
                    //Déplacement des pixels pour réussir la transformation (multiplication des images)
                    imgTn[i, j] = this[i * 2, j * 2];
                    imgTn[i, this.Largeur - 1 - j] = this[i * 2, j * 2 + 1];
                    imgTn[this.Hauteur - i - 1, j] = this[i * 2 + 1, j * 2];
                    imgTn[this.Hauteur - i - 1, this.Largeur - j - 1] = this[i * 2 + 1, j * 2 + 1];
                }
            }
            //Affecte la nouvelle image pour pouvoir être affichée
            this.ImageBitmap = nouvelleBtm;
        }
        #endregion


        #endregion
    }
}

