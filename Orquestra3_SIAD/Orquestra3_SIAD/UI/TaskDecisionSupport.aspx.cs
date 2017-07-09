using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;

namespace Orquestra3_SIAD.UI
{
    public partial class TaskDecisionSupport : System.Web.UI.Page
    {

        private XmlNode taskCryptoInfo;
        public XmlNode TaskCryptoInfo
        {
            get { return taskCryptoInfo; }
            set { taskCryptoInfo = value; }
        }

        private string codUser;
        public string CodUser
        {
            /*
             * get 
            { 
                if (Request["uid"] != null && Request["uid"].ToString() != "")
                {
                    return Request["uid"].ToString();
                }
                return string.Empty;
            }
             * */
            get
            {
                return codUser;
            }
            set
            {
                codUser = value;
            }
        }

        private Data.Task t;
        public Data.Task Task
        {
            get { return t; }
            set { t = value; }
        }

        private string suggestion;
        public string Suggestion
        {
            get { return suggestion; }
            set { suggestion = value; }
        }

        private double accuracy;
        public double Accuracy
        {
            get { return accuracy; }
            set { accuracy = value; }
        }

        private string dstasktitle;
        public string DsTaskTitle
        {
            get { return dstasktitle; }
            set { dstasktitle = value; }
        }

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

        public string c
        {
            get
            {
                if (Request["c"] != null && Request["c"].ToString() != "")
                {
                    return Request["c"].ToString();
                }
                return string.Empty;
            }
        }

        private string codFlowExecuteTask;
        public string CodFlowExecuteTask
        {
            get { return codFlowExecuteTask; }
            set { codFlowExecuteTask = value; }
        }

        private string codflowexecute;
        public string CodFlowExecute
        {
            get { return codflowexecute; }
            set { codflowexecute = value; }
        }

        public void decryptTaskInfo()
        {
            string toDecrypt = this.c;
            string sharedKey = "askdjlk@#$329dsadkas(*#AS423S2@w";

            QueryString.QueryString query = new QueryString.QueryString();
            this.taskCryptoInfo = query.Decrypt(toDecrypt, sharedKey);

            if (this.taskCryptoInfo.Name == "error")
            {
                throw new Exception(this.taskCryptoInfo.SelectSingleNode("friendly").InnerText);
            }
            /*
            else
            {
                Response.Write(xml.SelectSingleNode("returns").InnerText);
            }
             * */
        }

        public void fillParameters()
        {
            string[] taskInfo = this.TaskCryptoInfo.SelectSingleNode("returns").InnerText.Split('&');
            foreach (string param in taskInfo)
            {
                string[] splitParam = param.Split('=');
                if (splitParam[0] == "inpCodFlowExecuteTask")
                {
                    this.CodFlowExecuteTask = splitParam[1];
                }

                if (splitParam[0] == "inpCodUser")
                {
                    this.CodUser = splitParam[1];
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            decryptTaskInfo();
            fillParameters();
            t = new Business.Task().getTaskInfo(Convert.ToInt32(this.CodFlowExecuteTask));
            this.DsTaskTitle = t.DsTask;

            checkAutomaticExecution();

            runDecisionSupport();
            
        }

        // Verifica se o usuário atual habilitou a execução automática nesta tarefa
        public void checkAutomaticExecution()
        {
            bool hasAutomaticExecution = new Business.AutomaticTaskExecution().hasAutomaticExecution(t.CodTask, Convert.ToInt32(this.CodUser));

            // Se tem execução automática ativada, então mostra a opção de desabilitar e esconde a de habilitar
            if (hasAutomaticExecution)
            {
                this.PhActvate.Visible = false;
                this.PhDeactivate.Visible = true;
            }
            // Mostra a opção de ativar a execução automática e esconde a opção de desabilitar
            else
            {
                this.PhActvate.Visible = true;
                this.PhDeactivate.Visible = false;
            }
        }

        public void runDecisionSupport()
        {
            Data.Task t = new Business.Task().getTaskInfo(Convert.ToInt32(this.CodFlowExecuteTask));

            int codFlow = t.CodFlow; // Agendar aula de tênis
            int codTask = t.CodTask; // Informar se vai jogar tênis
            int codFlowExecute = t.CodFlowExecute; // Execução sendo verificada

            // Objeto DecisionSupport
            Business.DecisionSupport decisionSupport = new Business.DecisionSupport();

            // Número total de execuções da tarefa
            int totalExecutions = decisionSupport.getTotalExecutions(t.CodTask);

            // Lista de resultados da tarefa
            List<string> DsFlowResults = decisionSupport.getTaskResults(codTask);

            // Número de possíveis resultados para a tarefa sendo analisada
            int classCount = DsFlowResults.Count;
            if(classCount < 1) { classCount = 1; }

            // Se o total de execuções for maior que o número de resultados salvos em uma tarefa
            if (totalExecutions >= 2*classCount)
            {
                Data.DecisionTree dTree = decisionSupport.runDecisionSupport(codTask, totalExecutions, classCount);
                
                this.Suggestion = decisionSupport.getActionSuggestion(dTree, t.CodFlowExecute);

                if (this.Suggestion == string.Empty || this.Suggestion == null)
                {
                    this.PhAlertResponseNull.Visible = true;
                    this.PhDecisionSupport.Visible = false;
                }
                else
                {
                    this.Accuracy = decisionSupport.getAccuracy(dTree, t.CodFlowExecute);
                }
            }
            else
            {
                // Essa atividade não possui um número suficiente de execuções para sugerir uma ação.
                this.PhAlertCantSuggest.Visible = true;
                this.PhDecisionSupport.Visible = false;
            }
        }

        protected void BtnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?tk=" + this.Token);
        }

        protected void BtnActivate_Click(object sender, EventArgs e)
        {
            t = new Business.Task().getTaskInfo(Convert.ToInt32(this.CodFlowExecuteTask));
            this.DsTaskTitle = t.DsTask;

            new Business.AutomaticTaskExecution().activateAutomaticExecution(t.CodTask, Convert.ToInt32(this.CodUser));
            this.PhActvate.Visible = false;
            this.PhDeactivate.Visible = true;
        }

        protected void BtnDeactivate_Click(object sender, EventArgs e)
        {
            t = new Business.Task().getTaskInfo(Convert.ToInt32(this.CodFlowExecuteTask));
            this.DsTaskTitle = t.DsTask;

            new Business.AutomaticTaskExecution().deactivateAutomaticExecution(t.CodTask, Convert.ToInt32(this.CodUser));

            this.PhActvate.Visible = true;
            this.PhDeactivate.Visible = false;
        }
    }
}