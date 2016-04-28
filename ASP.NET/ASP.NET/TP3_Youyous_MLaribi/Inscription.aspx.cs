using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Youyous_MLaribi
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(IsPostBack)
          {
            
          }
        }
        protected void ButtonEnvoyer_Click(object sender, EventArgs e)
        {

            if(Page.IsPostBack && Page.IsValid)
            {
            //Ajout d'un usager dans la base de données
            
            //Entité LINQ
                MagasinJouetsEntities1 entityUsager = new MagasinJouetsEntities1();

            Usagers usagerAjout = new Usagers
            {
               
               
                pseudo = this.txtPseudo.Text,
                motPasse = EncrypterMdp(this.TextBoxMotPasse.Text),
                nom = this.txtNom.Text,
                prenom = this.txtPrenom.Text,
                type = this.drdType.SelectedValue.ToString(),
                adresse =this.txtAdresse.Text,
                ville = this.txtVille.Text,
                codePostal = this.txtCodeP.Text,
                téléphone = this.txtTelephone.Text
                
            };

            entityUsager.Usagers.Add(usagerAjout);
            entityUsager.SaveChanges();
            this.messagePost.Text = "L'usager a bien été ajouté!";
  
            }
            
        }

        //Fonction qui va encrypter le mot de passe de l'usager 
        private string EncrypterMdp(string pwd)
        {

            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(pwd);
            string encrypted = Convert.ToBase64String(bytes);
            return encrypted; 
        }
    }
}