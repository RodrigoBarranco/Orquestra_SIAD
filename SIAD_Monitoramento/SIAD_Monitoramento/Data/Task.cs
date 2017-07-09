using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class Task
    {
        int codFlow, codFlowExecute, codTask, codFlowExecuteTask;
        string dsTask;

        public int CodFlow
        {
            get { return codFlow; }
            set { codFlow = value; }
        }

        public int CodFlowExecute
        {
            get { return codFlowExecute; }
            set { codFlowExecute = value; }
        }

        public int CodTask
        {
            get { return codTask; }
            set { codTask = value; }
        }

        public string DsTask
        {
            get { return dsTask; }
            set { dsTask = value; }
        }

        public int CodFlowExecuteTask
        {
            get { return codFlowExecuteTask; }
            set { codFlowExecuteTask = value; }
        }

    }
}