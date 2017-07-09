using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using Orquestra3_SIAD.Business;
using System.Data.SqlClient;
using System.Text;
using Orquestra3_SIAD.Data;


namespace Orquestra3_SIAD.Database
{
    public class Task : Database.Base
    {
        Base b;

        public Task()
        {
            b = new Base();
        }

        public Data.Task getTaskInfo(int codFlowExecuteTask)
        {
            // Retorno
            Data.Task t = new Data.Task();

            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_TASK_INFO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodFlowExecuteTask", DbType.Int32, codFlowExecuteTask));

                    cn.Open();

                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                            t.CodFlow = Util.Parse.ToInt(reader["CodFlow"]);
                            t.CodFlowExecute = Util.Parse.ToInt(reader["CodFlowExecute"]);
                            t.CodTask = Util.Parse.ToInt(reader["CodTask"]);
                            t.DsTask = Util.Parse.ToString(reader["DsTaskTitle"]);
                        }
                    }
                }
            }

            return t;
        }

        public List<Data.Task> getPendingTasks(int codUser, int codTask)
        {
            List<Data.Task> pendingTasks = new List<Data.Task>();

            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_PENDING_TASKS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodUser", DbType.Int32, codUser));
                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));

                    cn.Open();
                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            Data.Task t = new Data.Task();

                            t.CodFlowExecuteTask = Util.Parse.ToInt(reader["CodFlowExecuteTask"]);
                            t.CodFlow = Util.Parse.ToInt(reader["CodFlow"]);
                            t.CodFlowExecute = Util.Parse.ToInt(reader["CodFlowExecute"]);
                            t.CodTask = codTask;
                            t.DsTask = Util.Parse.ToString(reader["DsTaskTitle"]);

                            pendingTasks.Add(t);
                        }
                    }
                    return pendingTasks;

                }
            }
        }
    }
}