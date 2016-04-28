using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace TP3_Youyous_MLaribi
{
    public partial class gabGeneral : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Usagers connecte = (Usagers) Session["usagerConnecte"];
            if (connecte != null)
            {
                this.connexionDiv.Visible = false;
                this.usagerConnecte.Visible = true;
                this.txtUsagerConnecte.Text = connecte.prenom.ToString()+ " \"D.\" " +connecte.nom.ToString();
                this.txtDate.Text = DateTime.Now.Date.ToString();
            }
            else
            {
                this.connexionDiv.Visible = true;
                this.usagerConnecte.Visible = false;
            }

            //Expiration des pages
            Response.AppendHeader("Expires", "0");
            Response.AppendHeader("Cache-Control", "no-store");
            Response.AppendHeader("Pragma", "no-cache");


              // Récupération du cookie; on obtient null si le cookie n'existe pas.
            HttpCookie cookiePseudo = Request.Cookies["pseudoVagabones"];

            //Affichage dans le textbox si existant
            if (cookiePseudo != null)
            {
                this.txtUsager.Text = cookiePseudo.Value;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Page.IsPostBack && Page.IsValid)
            {
                using (MagasinJouetsEntities1 magasinSkiEntite = new MagasinJouetsEntities1())
                {
                    try
                    {
                        // string mdpEncrypt = EncrypterMdp();
                        var usagerRes = (from Usagers in magasinSkiEntite.Usagers
                                         where Usagers.pseudo.Equals(this.txtUsager.Text)
                                         & Usagers.motPasse.Equals(this.txtMdp.Text)
                                         select Usagers).FirstOrDefault();
                        if (usagerRes != null)
                        {
                            Session["usagerConnecte"] = (Usagers)usagerRes;
                        }
                    }


                    catch (EntityDataSourceValidationException exc)
                    {
                        var msg = exc.Message;
                    }
                }
            }
            if(this.SeSouvenir.Checked == true)
            {
                Response.Cookies["pseudoVagabones"].Value = this.txtUsager.Text;
                Response.Cookies["pseudoVagabones"].Expires = DateTime.Now.AddMonths(3);
            }
            Response.Redirect(Request.RawUrl);
        }
      
        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect(Request.RawUrl);
        }


        //Fonction qui va Décrypter le mot de passe de l'usager 
        private string DecryptedMdp(string pwdEnc)
        {
            byte[] bytes = Convert.FromBase64String(pwdEnc);
            string decryptage = System.Text.Encoding.Unicode.GetString(bytes);
            return decryptage;
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