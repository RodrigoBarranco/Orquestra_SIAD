using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class Validation
    {
        DataTable validationData;

        public DataTable ValidationData
        {
            get { return validationData; }
            set { validationData = value; }
        }

        private int validationCount;

        public int ValidationCount
        {
            get { return validationCount; }
            set { validationCount = value; }
        }

        private double accuracyRate;

        public double AccuracyRate
        {
            get { return accuracyRate; }
            set { accuracyRate = value; }
        }

        public void setValidationCount(DataTable data)
        {
            int dataRowsCount = data.Rows.Count;
            this.ValidationCount = (int)(dataRowsCount * 0.20);
            if (this.ValidationCount < 1) this.ValidationCount = 1;
        }

        public void setValidationData(DataTable data)
        {
            setValidationCount(data);
            var resultValidation = (from d in data.AsEnumerable() select d).OrderByDescending(d => d.Field<int>("CodFlowExecuteTask")).Take(validationCount);
            this.ValidationData = resultValidation.CopyToDataTable();
        }

        public void validate(Dictionary<dynamic, int> fieldSymbols, Data.DecisionTree decisionTree)
        {
            int acertos = 0;
            int erros = 0;
            int semResposta = 0;

            foreach(DataRow row in ValidationData.Rows)
            {
                List<string> fieldValuesList = new List<string>();
                // Loop para montar o translate dos campos que se quer a resposta. - Loop nos campos relevantes
                foreach (KeyValuePair<dynamic, int> entry in fieldSymbols)
                {
                    DecisionSupportField field = entry.Key;
                    if (field.relevante)
                    {
                        fieldValuesList.Add(row[field.codigo.ToString()].ToString());
                    }   
                }

                string auxAnswer = decisionTree.Codebook.Translate("DsFlowResult", decisionTree.Tree.Compute(decisionTree.Codebook.Translate(fieldValuesList.ToArray())));
                if (auxAnswer != null && auxAnswer.Equals(row["DsFlowResult"]))
                {
                    acertos++;
                }
                else if (auxAnswer != null && !auxAnswer.Equals(row["DsFlowResult"]))
                {
                    erros++;
                }
                else
                {
                    semResposta++;
                }
            }

            // Controle para evitar divisão por zero
            // Se não acertou nenhum
            if (acertos == 0) { decisionTree.Validation.AccuracyRate = 0; }
            // Se acertou algum, faz o índice
            else
            {
                decisionTree.Validation.AccuracyRate = (Convert.ToDouble(acertos) / Convert.ToDouble(decisionTree.Validation.ValidationCount)) * 100;
            }
        }
    }
}