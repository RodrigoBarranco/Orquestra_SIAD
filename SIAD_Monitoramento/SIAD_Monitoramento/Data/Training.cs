using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.DecisionTrees;
using Accord.Statistics.Filters;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class Training
    {
        private DataTable trainingData;
        
        public DataTable TrainingData
        {
            get { return trainingData; }
            set { trainingData = value; }
        }

        private int trainingCount;

        public int TrainingCount
        {
            get { return trainingCount; }
            set { trainingCount = value; }
        }

        List<DecisionSupportField> decisionVariables = new List<DecisionSupportField>();

        public void createDecisionSupportField(int codField, string dsFieldName)
        {
            new DecisionSupportField(codField, dsFieldName);
        }

        public void setTrainingCount(DataTable data)
        {
            int dataRowsCount = data.Rows.Count;
            this.TrainingCount = (int)(dataRowsCount * 0.80);
        }

        public void setTrainingData(DataTable data)
        {
            setTrainingCount(data);
            var resultTraining = (from d in data.AsEnumerable() select d).OrderBy(d => d.Field<int>("CodFlowExecuteTask")).Take(this.TrainingCount);
            this.TrainingData = resultTraining.CopyToDataTable();
        }

        public void train()
        {
            /*
            // Converte em números inteiros as strings
            Codification codebook = new Codification(trainingData, codFieldListComDsFlowResult.ToArray());

            // Montando a tabela de variáveis de decisão            
            List<DecisionVariable> decisionaVariableList = new List<DecisionVariable>();
            foreach (KeyValuePair<dynamic, int> entry in fieldSymbols.Where(p => ((DecisionSupportField)p.Key).relevante == true))
            {
                DecisionSupportField c = entry.Key;
                c.simbolos = entry.Value;
                decisionaVariableList.Add(new DecisionVariable(c.codigo.ToString(), c.simbolos + 1)); // Adicionando + 1 do possível nulo
            }

            int qtdCamposRelevantes = fieldSymbols.Count(i => ((DecisionSupportField)i.Key).relevante == true);
            DecisionVariable[] attributes = new DecisionVariable[qtdCamposRelevantes];

            // Tabela de variáveis que impactam na decisão
            attributes = decisionaVariableList.ToArray();

            List<string> DsFlowResults = getTaskResults(codTask);

            // Número de possíveis resultados para a tarefa sendo analisada
            int classCount = DsFlowResults.Count;

            // Cria a árvore de decisão
            Accord.MachineLearning.DecisionTrees.DecisionTree tree = new Accord.MachineLearning.DecisionTrees.DecisionTree(attributes, classCount);

            // Cria uma instância do algoritmo de aprendizado utilizado, o ID3
            ID3Learning id3learning = new ID3Learning(tree);

            // Traduz os dados de treino em simbolos inteiros utilizando o codebook
            DataTable symbols = codebook.Apply(trainingData);

            // Colunas de entrada
            // *** Quantidade de colunas dos inputs deve ser o mesmo número de DecisionVariables(attributes)
            int[][] inputs = symbols.ToArray<int>(codFieldList.ToArray());

            // Coluna com a saída
            int[] outputs = symbols.ToArray<int>("DsFlowResult");

            // Aprendendo com as instâncias de treino
            id3learning.Run(inputs, outputs);
             * */
        }
    }
}