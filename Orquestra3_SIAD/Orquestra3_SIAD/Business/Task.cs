using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orquestra3_SIAD.Business
{
    public class Task
    {
        public Data.Task getTaskInfo(int codFlowExecuteTask)
        {
            return new Database.Task().getTaskInfo(codFlowExecuteTask);
        }

        public List<Data.Task> getPendingTasks(int codUser, int codTask)
        {
            return new Database.Task().getPendingTasks(codUser, codTask);
        }

    }
}