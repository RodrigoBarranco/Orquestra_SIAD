using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orquestra3_SIAD.Authentication;
using System.Xml;

namespace Orquestra3_SIAD.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMsg.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string token = "";

            Authentication.Authentication Authentication = new Authentication.Authentication();
            XmlNode xmlToken = Authentication.Login01(this.txtUserName.Text, this.txtPassword.Text);
            if (xmlToken.Name == "error")
            {
                this.lblMsg.Text = "Usuário ou senha inválidos";
            }
            else
            {
                this.lblMsg.Text = "";

                token = xmlToken.SelectSingleNode("returns").InnerText;
                //Response.Write("Usuário autenticado com token " + token);
                Response.Redirect("Home.aspx?tk=" + token);
            }
            
        }
    }
}