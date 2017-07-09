using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Orquestra3_SIAD.UI
{
    public partial class Default : System.Web.UI.Page
    {

        public string Token
        {
            get
            {
                if (Request["tk"] != null && Request["tk"].ToString() != "")
                {
                    return Request["tk"].ToString();
                }
                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.bind();
            }
        }

        public void bind()
        {
            Workspace.Workspace work = new Workspace.Workspace();
            XmlNode xmlExecute = work.ListPending01(Token);

            if (xmlExecute.Name == "error")
            {
                // Erro ao carregar as tarefas do usuário
            }
            else
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlExecute.OuterXml);

                XmlNodeList items = xmlDoc.SelectNodes("/Tasks/Task");

                this.RptPendingTasks.DataSource = items;
                this.RptPendingTasks.DataBind();
            }

        }

        protected void lkTaskDecisionSupport_Click(object sender, System.EventArgs e)
        {
            LinkButton lnkRowSelection = (LinkButton)sender;
            string codFlowExecuteTask = lnkRowSelection.CommandArgument;

            Response.Redirect(string.Format("TaskDecisionSupport.aspx?tk={0}&cfet={1}", this.Token, codFlowExecuteTask), false);
        }
    }
}