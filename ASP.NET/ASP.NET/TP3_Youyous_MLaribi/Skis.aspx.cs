using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Youyous_MLaribi
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Usagers connecte = (Usagers) Session["usagerConnecte"];

            using(MagasinJouetsEntities1 entityArticles = new MagasinJouetsEntities1())
            {

                try
                {
                    var tousLesSkis = from skis in entityArticles.Skis 
                                      select skis;

                    this.gridSkis.DataSource = tousLesSkis.ToList();
                    gridSkis.DataBind();
                }
                catch (EntityDataSourceValidationException exc)
                {
                    var msg = exc.Message;
                }
            }

            if (connecte.type.ToString() == "e")
            {


            }
            else
            {

            }
        }
    }
}