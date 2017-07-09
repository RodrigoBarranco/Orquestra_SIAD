using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orquestra3_SIAD.UI
{
    public partial class DecisionSupport : System.Web.UI.UserControl
    {
        private string suggestion;
        public string Suggestion
        {
            get { return suggestion; }
            set { suggestion = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            runDecisionSupport();
        }

        public void runDecisionSupport()
        {
            /*
            int codFlow = 101; // Agendar aula de tênis
            int codTask = 12168; // Informar se vai jogar tênis
            int codUserExecute = 552; // Admin
            int codFlowExecute = 113; // Execução sendo verificada

            this.Suggestion = new Business.DecisionSupport().runDecisionSupport(codFlow, codTask, codFlowExecute);
            */
        }
    }
}