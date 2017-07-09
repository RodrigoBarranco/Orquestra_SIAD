using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class AutomaticTask
    {
        private int codautomatictaskexecution, codtask, coduser;

        public int CodUser
        {
            get { return coduser; }
            set { coduser = value; }
        }

        public int CodTask
        {
            get { return codtask; }
            set { codtask = value; }
        }

        public int CodAutomaticTaskExecution
        {
            get { return codautomatictaskexecution; }
            set { codautomatictaskexecution = value; }
        }
    }
}