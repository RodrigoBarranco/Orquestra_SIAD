using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orquestra3_SIAD.Data;

namespace Orquestra3_SIAD.Business
{
    public class AutomaticTaskExecution
    {
        public void activateAutomaticExecution(int codTask, int codUser)
        {
            new Database.AutomaticTaskExecution().activateAutomaticExecution(codTask, codUser);
        }

        public void deactivateAutomaticExecution(int codTask, int codUser)
        {
            new Database.AutomaticTaskExecution().deactivateAutomaticExecution(codTask, codUser);
        }

        public bool hasAutomaticExecution(int codTask, int codUser)
        {
            return new Database.AutomaticTaskExecution().hasAutomaticExecution(codTask, codUser);
        }

        public List<AutomaticTask> automaticTaskExecutionList()
        {
            return new Database.AutomaticTaskExecution().automaticTaskExecutionList();
        }

        public void notifyAutomaticExecution(int codTask, int codUser, int codFlowExecute)
        {
            new Database.AutomaticTaskExecution().notifyAutomaticExecution(codTask, codUser, codFlowExecute);
        }
    }
}