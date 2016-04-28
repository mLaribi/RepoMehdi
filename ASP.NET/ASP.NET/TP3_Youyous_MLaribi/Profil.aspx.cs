using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TP3_Youyous_MLaribi
{
    public partial class profil : System.Web.UI.Page
    {

        
        
        protected void Page_Load(object sender, EventArgs e)
        {
           Usagers connecte = (Usagers) Session["usagerConnecte"];

           this.txtPseudo.Text = connecte.nom;
           this.TextBoxConfirmerMotPasse.Text = this.TextBoxMotPasse.Text = connecte.motPasse;
           this.drdType.SelectedValue = connecte.type;
           this.txtPrenom.Text = connecte.prenom;
           this.txtNom.Text = connecte.nom;
           this.txtAdresse.Text = connecte.adresse;
           this.txtCodeP.Text = connecte.codePostal;
           this.txtTelephone.Text = connecte.téléphone;
           this.txtVille.Text = connecte.ville;
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {

            Usagers connecte = (Usagers)Session["usagerConnecte"];

            try
            {
                MagasinJouetsEntities1 monEntite = new MagasinJouetsEntities1();

                var usaConnecte = from Usagers in monEntite.Usagers
                                  where Usagers.nom == connecte.nom
                                  select Usagers;

                foreach (Usagers u in usaConnecte)
                {
                    u.pseudo = this.txtPseudo.Text;
                    u.motPasse = EncrypterMdp(this.TextBoxMotPasse.Text);
                    u.nom = this.txtNom.Text;
                    u.prenom = this.txtPrenom.Text;
                    u.type = this.drdType.SelectedValue.ToString();
                    u.adresse = this.txtAdresse.Text;
                    u.ville = this.txtVille.Text;
                    u.codePostal = this.txtCodeP.Text;
                    u.téléphone = this.txtTelephone.Text;
                }

                monEntite.SaveChanges();
            }
            catch( Exception ex)
            {
                var message = ex.Message;
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