using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP3_Youyous_MLaribi
{
    public partial class Acces : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["mdp"] == null)
                Response.Redirect(Request.RawUrl);
        }
    }
}