using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Accord.Statistics.Filters;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math;
using Accord.IO;
using System.Numerics;
using Orquestra3_SIAD.Data;
using Accord;
using System.Xml;

namespace Orquestra3_SIAD.Business
{
    public class DecisionSupport
    {
        public Data.DecisionTree runDecisionSupport(int codTask, int totalExecutions, int classCount)
        {
            Data.DecisionTree decisionTree = new Data.DecisionTree();

            // Utilizado se já existe uma árvore de decisão prévia criada, serve para reutilização de alguns parâmetros
            Data.DecisionTree serializedTree = null;

            // Verifica se já existe uma árvore gerada anteriormente
            bool hasSerializedTree = decisionTree.Serialization.hasSerializedTree(codTask);

            // Carregar a árvore existente
            if (hasSerializedTree)
            {
                serializedTree = decisionTree.deserializeTree(codTask);
            }

            // Número total de execuções da tarefa
            //int totalExecutions = getTotalExecutions(codTask);

            Dictionary<dynamic, int> fieldSymbols = new Dictionary<dynamic, int>();

            // Preenche o dicionário com a lista de campos do processo e a quantidade de símbolos para cada campo
            fillSymbolsCount(codTask, ref fieldSymbols);

            // Preenche a relevância dos campos de acordo com a taxa de variação e de nulos
            setSymbolsRelevance(ref fieldSymbols, totalExecutions, codTask);

            StringBuilder CodFieldListSB = new StringBuilder();
            StringBuilder CodFieldListSBIsNull = new StringBuilder();
            StringBuilder DsFieldNameList = new StringBuilder();
            List<string> codFieldList = new List<string>();

            // Prepara lista de campos
            List<string> codFieldListComDsFlowResult = prepareFieldList(ref fieldSymbols, ref CodFieldListSB, ref CodFieldListSBIsNull, ref DsFieldNameList, ref codFieldList);

            // Consulta os dados de treino
            DataTable data = getData(codTask, CodFieldListSB, CodFieldListSBIsNull);

            decisionTree.Data = data;

            // Criando o objeto TRAINING
            decisionTree.Training.setTrainingData(data);

            // Preenchendo o VALIDATION do DecisionTree
            decisionTree.Validation.setValidationData(data);

            // ############################################# Passado para a classe Training.

            // Passando o data para criação do codebook
            // Converte em números inteiros as strings
            Codification codebook = new Codification(data, codFieldListComDsFlowResult.ToArray());

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

            //List<string> DsFlowResults = getTaskResults(codTask);

            // Número de possíveis resultados para a tarefa sendo analisada
            //int classCount = DsFlowResults.Count;

            // Cria a árvore de decisão
            Accord.MachineLearning.DecisionTrees.DecisionTree tree = new Accord.MachineLearning.DecisionTrees.DecisionTree(attributes, classCount);

            // Cria uma instância do algoritmo de aprendizado utilizado, o ID3
            ID3Learning id3learning = new ID3Learning(tree);

            // Traduz os dados de treino em simbolos inteiros utilizando o codebook
            DataTable symbols = codebook.Apply(decisionTree.Training.TrainingData);

            // Colunas de entrada
            // *** Quantidade de colunas dos inputs deve ser o mesmo número de DecisionVariables(attributes)
            int[][] inputs = symbols.ToArray<int>(codFieldList.ToArray());

            // Coluna com a saída
            int[] outputs = symbols.ToArray<int>("DsFlowResult");

            // Aprendendo com as instâncias de treino
            id3learning.Run(inputs, outputs);

            // ############################################# Passado para a classe Training.

            decisionTree.Tree = tree;
            
            // Atribuindo as listas de códigos de campos e nomes ao objeto decisionTree
            // Utilizado para manter o uso da palavra chave 'ref'
            decisionTree.CodFieldListSB = CodFieldListSB;
            decisionTree.CodFieldListSBIsNull = CodFieldListSBIsNull;
            decisionTree.DsFieldNameList = DsFieldNameList;
            decisionTree.codFieldList = codFieldList;
            decisionTree.codFieldListComDsFlowResult = codFieldListComDsFlowResult;
            decisionTree.fieldSymbols = fieldSymbols;
            decisionTree.Codebook = codebook;

            decisionTree.serializeTree(codTask);

            return decisionTree;
        }

        // Método que realiza o monitoramento e executa as tarefas pendentes autorizadas
        public void monitorAndExecute(System.Diagnostics.EventLog log)
        {
            //string authToken = "uQLhVpS2kx2%2b95sRUwiq1uh8iRycp%2bWro6efT7eNTFM%3d";
            string authToken = "T%2bVgaQPEbcfz%2bMbQPMd38d2pU7wL678T4nHb%2b%2fQjNI8WeISiIPYYh%2f62AqV3Uo0%2b";
            List<AutomaticTask> tarefasAutorizadas = new Business.AutomaticTaskExecution().automaticTaskExecutionList();

            // Se tem tarefas autorizadas
            if (tarefasAutorizadas.Count > 0)
            {
                foreach (AutomaticTask at in tarefasAutorizadas)
                {

                    // Para cada tarefa autorizada por um usuário, verificar a existência destas tarefas em pendência de
                    // execução sob a responsabilidade do usuário que autorizou

                    // Chama query que consulta tarefas pendentes com o codTask e na responsabilidade do usuário em questão
                    List<Data.Task> pendingTasks = new Business.Task().getPendingTasks(at.CodUser, at.CodTask);

                    // Tem dessa tarefa em andamento?
                    // Se sim, // Chamar o apoio à decisão para a tarefa, assim chama uma vez só para várias
                    // Se não tem tarefa pendente, não há por que chamar trecho de apoio à decisão e nem de finalizar
                    if(pendingTasks.Count > 0)
                    {
                        // Número total de execuções da tarefa
                        int totalExecutions = getTotalExecutions(at.CodTask);

                        // Lista de resultados da tarefa
                        List<string> DsFlowResults = getTaskResults(at.CodTask);

                        // Número de possíveis resultados para a tarefa sendo analisada
                        int classCount = DsFlowResults.Count;

                        // Chama a árvore de decisão // TODO: Usar árvore serializada
                        Data.DecisionTree dTree = runDecisionSupport(at.CodTask, totalExecutions, classCount);

                        // Para cada tarefa autorizada e pendente com o usuário, chama o apoio a decisão e depois finaliza a tarefa
                        foreach(Data.Task t in pendingTasks)
                        {

                            // Pegar a sugestão de ação para a tarefa
                            string action = getActionSuggestion(dTree, t.CodFlowExecute);

                            // Cria o objeto de referência ao webservice
                            Instance.Instance inst = new Instance.Instance();
                            //FinalizeTask02 - Finaliza a tarefa
                            XmlNode xml = inst.FinalizeTask02(authToken, t.CodFlowExecuteTask, action, "");

                            if (log != null && xml.Name == "success")
                            {
                                log.WriteEntry("A Tarefa " + t.DsTask + " do processo " + t.CodFlowExecute.ToString() + " foi finalizada automaticamente com a opção " + action + ".");
                            }

                            if (xml.Name == "success")
                            {
                                // Notificar o usuário sobre a conclusão da tarefa
                                new Business.AutomaticTaskExecution().notifyAutomaticExecution(at.CodTask, at.CodUser, t.CodFlowExecute);
                            }
                        }

                    }
                }
            }
        }
                         

        public string getActionSuggestion(Data.DecisionTree decisionTree, int codFlowExecute)
        {
            DataTable executionData = getExecutionData(codFlowExecute, decisionTree.CodFieldListSB, decisionTree.CodFieldListSBIsNull);
            List<string> fieldValuesList = getValuesListFromExecution(executionData, decisionTree.fieldSymbols);
            string answer = getAnswer(decisionTree.Tree, decisionTree.Data, executionData, decisionTree.codFieldListComDsFlowResult, fieldValuesList);
            return answer;
        }

        public double getAccuracy(Data.DecisionTree decisionTree, int codFlowExecute)
        {
            decisionTree.Validation.validate(decisionTree.fieldSymbols, decisionTree);
            return Math.Round(decisionTree.Validation.AccuracyRate, 2);
        }

        public int getTotalExecutions(int codTask)
        {
            return new Database.DecisionSupport().getTotalExecutions(codTask);
        }

        public void fillSymbolsCount(int codTask, ref Dictionary<dynamic, int> fieldSymbols)
        {
            new Database.DecisionSupport().fillSymbolsCount(codTask, ref fieldSymbols);
        }

        public void setSymbolsRelevance(ref Dictionary<dynamic, int> fieldSymbols, int totalExecutions, int codTask)
        {
            new Database.DecisionSupport().setSymbolsRelevance(ref fieldSymbols, totalExecutions, codTask);
        }

        public DataTable getData(int codTask, StringBuilder codFieldListSB, StringBuilder codFieldListSBIsNull)
        {
            return new Database.DecisionSupport().getTrainingData(codTask, codFieldListSB, codFieldListSBIsNull);
        }

        public List<string> prepareFieldList(
                                            ref Dictionary<dynamic, int> fieldSymbols, 
                                            ref StringBuilder CodFieldListSB, 
                                            ref StringBuilder CodFieldListSBIsNull,
                                            ref StringBuilder DsFieldNameList,
                                            ref List<string> codFieldList
                                            )
        {
            return new Database.DecisionSupport().prepareFieldList(
                                                                    ref fieldSymbols,
                                                                    ref CodFieldListSB,
                                                                    ref CodFieldListSBIsNull,
                                                                    ref DsFieldNameList,
                                                                    ref codFieldList
                                                                    );
        }

        public int getNullsCount(int codTask, DecisionSupportField c)
        {
            return new Database.DecisionSupport().getNullsCount(codTask, c);
        }

        public List<string> getTaskResults(int codTask)
        {
            return new Database.DecisionSupport().getTaskResults(codTask);
        }

        public DataTable getExecutionData(int codFlowExecute, StringBuilder CodFieldListSB, StringBuilder CodFieldListSBIsNull)
        {
            DataTable executionData = new Database.DecisionSupport().getExecutionData(codFlowExecute, CodFieldListSB, CodFieldListSBIsNull);
            return executionData;   
        }

        public List<string> getValuesListFromExecution(DataTable executionData, Dictionary<dynamic, int> fieldSymbols)
        {
            List<string> fieldValuesList = new List<string>();
            foreach (DataRow dr2 in executionData.Rows)
            {
                // Loop para montar o translate dos campos que se quer a resposta. - Loop nos campos relevantes
                foreach (KeyValuePair<dynamic, int> entry in fieldSymbols)
                {
                    DecisionSupportField c = entry.Key;
                    if (c.relevante)
                    {
                        fieldValuesList.Add(dr2[c.codigo.ToString()].ToString());
                    }
                }
            }
            return fieldValuesList;
        }

        public string getAnswer(Accord.MachineLearning.DecisionTrees.DecisionTree tree, DataTable trainingData, DataTable executionData, List<string> codFieldListComDsFlowResult, List<string> fieldValuesList)
        {
            trainingData.Merge(executionData);
            Codification codebookExecution = new Codification(trainingData, codFieldListComDsFlowResult.ToArray());

            // O primeiro codebook aqui deve ser o codebook original da árvore de decisão, o segundo codebook sim é o da execução.
            // Validar com itens diferentes preenchidos na execução.
            return codebookExecution.Translate("DsFlowResult", tree.Compute(codebookExecution.Translate(fieldValuesList.ToArray())));
        }
    }
}