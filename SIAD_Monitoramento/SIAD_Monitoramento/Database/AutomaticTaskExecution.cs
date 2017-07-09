using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orquestra3_SIAD.Data;
using System.Data.Common;
using System.Data;

namespace Orquestra3_SIAD.Database
{
    public class AutomaticTaskExecution : Database.Base
    {
        Base b;

        public AutomaticTaskExecution()
        {
            b = new Base();
        }

        public void activateAutomaticExecution(int codTask, int codUser)
        {
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_ACTIVATE_AUTOMATIC_TASK_EXECUTION";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodUser", DbType.Int32, codUser));

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void deactivateAutomaticExecution(int codTask, int codUser)
        {
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_DEACTIVATE_AUTOMATIC_TASK_EXECUTION";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodUser", DbType.Int32, codUser));

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool hasAutomaticExecution(int codTask, int codUser)
        {
            bool hasAutomaticExecution = false;
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_AUTOMATIC_TASK_EXECUTION";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodUser", DbType.Int32, codUser));

                    cn.Open();

                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        if (reader.HasRows)
                        {
                            hasAutomaticExecution = true;
                        }
                    }
                }
            }
            return hasAutomaticExecution;
        }

        public List<AutomaticTask> automaticTaskExecutionList()
        {
            List<AutomaticTask> automaticTasks = new List<AutomaticTask>();

            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_AUTOMATIC_TASK_EXECUTION_LIST";
                    cmd.CommandType = CommandType.StoredProcedure;                    

                    cn.Open();
                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            AutomaticTask at = new AutomaticTask();
                            at.CodAutomaticTaskExecution = Util.Parse.ToInt(reader["CodAutomaticTaskExecution"]);
                            at.CodTask = Util.Parse.ToInt(reader["CodTask"]);
                            at.CodUser = Util.Parse.ToInt(reader["CodUser"]);

                            automaticTasks.Add(at);
                        }
                    }
                    return automaticTasks;

                }
            }
        }

        public void notifyAutomaticExecution(int codTask, int codUser, int codFlowExecute)
        {
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_NOTIFY_AUTOMATIC_TASK_EXECUTION";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodUser", DbType.Int32, codUser));
                    cmd.Parameters.Add(CreateParameter("@CodFlowExecute", DbType.Int32, codFlowExecute));

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}