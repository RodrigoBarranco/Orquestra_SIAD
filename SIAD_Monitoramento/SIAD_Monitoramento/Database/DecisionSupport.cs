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
    public class DecisionSupport : Database.Base
    {

        Base b;

        public DecisionSupport()
        {
            b = new Base();
        }

        public int getTotalExecutions(int codTask)
        {
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_COUNT_TASK_EXECUTIONS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));

                    cn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int getNullsCount(int codTask, DecisionSupportField c)
        {
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_NULL_COUNT";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodField", DbType.Int32, c.codigo));

                    cn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
        }

        public List<string> getTaskResults(int codTask)
        {
            List<string> DsFlowResults = new List<string>();
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_TASK_RESULTS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));

                    cn.Open();
                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            DsFlowResults.Add(Util.Parse.ToString(reader["DsFlowResult"]));
                        }
                    }
                    return DsFlowResults;

                }
            }
        }

        public void fillSymbolsCount(int codTask, ref Dictionary<dynamic, int> fieldSymbols)
        {
            // ### Definir os campos a serem utilizados na árvore
            // 1 - Selecionar a quantidade de símbolos diferentes preenchidos em cada campo do formulário
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_SYMBOLS_COUNT";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));

                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                    using (DbDataReader reader = b.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            fieldSymbols.Add(new DecisionSupportField(Util.Parse.ToInt(reader["CodField"]), Util.Parse.ToString(reader["DsFieldName"])), Util.Parse.ToInt(reader["SymbolsCount"]));
                        }
                    }
                }
            }
        }

        public DataTable getTrainingData(int codTask, StringBuilder codFieldListSB, StringBuilder codFieldListSBIsNull)
        {
            DataTable data = new DataTable("Decision Tree");
            using (DbConnection cn = CreateConnection())
            {
                using (DbCommand cmd = CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_TRAINING_DATA";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(CreateParameter("@CodTask", DbType.Int32, codTask));
                    cmd.Parameters.Add(CreateParameter("@CodFields", DbType.String, codFieldListSB.ToString()));
                    cmd.Parameters.Add(CreateParameter("@CodFieldsIsNull", DbType.String, codFieldListSBIsNull.ToString()));

                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    // Erro - nome da coluna
                    da.Fill(data);
                    return data;
                }
            }
        }

        public List<string> prepareFieldList(
                                    ref Dictionary<dynamic, int> fieldSymbols, 
                                    ref StringBuilder CodFieldListSB, 
                                    ref StringBuilder CodFieldListSBIsNull,
                                    ref StringBuilder DsFieldNameList,
                                    ref List<string> codFieldList
                                    )
        {
            
            bool isNotFirst = false;
            foreach (KeyValuePair<dynamic, int> entry in fieldSymbols)
            {
                DecisionSupportField field = entry.Key;
                if (isNotFirst)
                {
                    if (field.relevante)
                    {
                        CodFieldListSB.Append(",");
                        CodFieldListSBIsNull.Append(",");
                        DsFieldNameList.Append(",");
                    }
                }

                if (field.relevante)
                {
                    CodFieldListSB.Append("[" + field.codigo.ToString() + "]");
                    CodFieldListSBIsNull.Append("isnull([" + field.codigo.ToString() + "],'0') as '" + field.codigo.ToString() + "'");
                    DsFieldNameList.Append("[" + field.nome + "]");
                    codFieldList.Add(field.codigo.ToString());
                    isNotFirst = true;
                }
            }

            List<string> codFieldListComDsFlowResult = new List<string>(codFieldList);
            codFieldListComDsFlowResult.Add("DsFlowResult");
            return codFieldListComDsFlowResult;
        }

        public void setSymbolsRelevance(ref Dictionary<dynamic, int> fieldSymbols, int totalExecutions, int codTask)
        {
            // ### Para cada campo, verificar se o campo tem uma variação de símbolos aceitável para utiliza-lo na árvore ###
            foreach (KeyValuePair<dynamic, int> entry in fieldSymbols)
            {
                DecisionSupportField field = entry.Key;
                field.simbolos = entry.Value;

                // Constante
                if (field.simbolos <= 1)
                {
                    field.relevante = false;
                }

                double indice = ((entry.Value * 100) / totalExecutions);

                int indexLimit = 100;
                
                if (totalExecutions >= 100) { indexLimit = 12; }
                else if (totalExecutions < 100 && totalExecutions >= 50) { indexLimit = 15; }
                else if (totalExecutions < 50 && totalExecutions >= 25) { indexLimit = 20; }
                else if (totalExecutions < 25 && totalExecutions > 10) { indexLimit = 30; }
                else if (totalExecutions <= 10 && totalExecutions > 5) { indexLimit = 50; }
                else if (totalExecutions <= 5) { indexLimit = 100; }
                
                // ? Verificar aqui se possui fonte de dados(Verificar tb o tamanho da fonte) ?
                // Se a variação de valores é pequena, este campo será utilizado
                if (indice <= indexLimit) //12
                {
                    field.relevante = true;
                }
                else
                {
                    field.relevante = false;
                }
            }

            // #### IMPORTANTE #### - Checar se os campos selecionados possuem muitos nulos. Se o número for alto, deverá ser descartado
            foreach (KeyValuePair<dynamic, int> entry in fieldSymbols)
            {
                DecisionSupportField c = entry.Key;
                if (c.relevante)
                {
                    // Gargalo - Contagem de nulos está incorreta
                    int nulls = getNullsCount(codTask, c);
                    int indiceNulls = (nulls * 100) / totalExecutions;

                    // ? CodOrder ? - Dividir nulls pelo quantidade de opções(Campo do tipo checkbox)

                    if (indiceNulls > 30)
                    {
                        c.relevante = false;
                    }

                    // Constante
                    if (c.simbolos <= 1)
                    {
                        c.relevante = false;
                    }
                }
            }
        }

        public DataTable getExecutionData(int codFlowExecute, StringBuilder CodFieldListSB, StringBuilder CodFieldListSBIsNull)
        {
            DataTable executionData = new DataTable("Execução");
            using (DbConnection cn = b.CreateConnection())
            {
                using (DbCommand cmd = b.CreateCommand(cn))
                {
                    cmd.CommandText = "wfSP_GET_EXECUTION_DATA";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(CreateParameter("@CodFlowExecute", DbType.Int32, codFlowExecute));
                    cmd.Parameters.Add(CreateParameter("@CodFields", DbType.String, CodFieldListSB.ToString()));
                    cmd.Parameters.Add(CreateParameter("@CodFieldsIsNull", DbType.String, CodFieldListSBIsNull.ToString()));

                    cn.Open();
                    SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);
                    da.Fill(executionData);
                    return executionData;
                }
            }
        }
    }
}