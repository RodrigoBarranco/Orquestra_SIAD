using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Accord.Statistics.Filters;
using System.Data;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class DecisionTree
    {
        Accord.MachineLearning.DecisionTrees.DecisionTree tree = null;
        
        [NonSerialized]
        Codification codebook;

        private DataTable data;

        public DataTable Data
        {
            get { return data; }
            set { data = value; }
        }

        public Codification Codebook
        {
            get { return codebook; }
            set { codebook = value; }
        }

        public StringBuilder CodFieldListSB, CodFieldListSBIsNull, DsFieldNameList;
        public List<string> codFieldList, codFieldListComDsFlowResult;
        public Dictionary<dynamic, int> fieldSymbols;

        public Accord.MachineLearning.DecisionTrees.DecisionTree Tree
        {
            get { return tree; }
            set { tree = value; }
        }

        Training training;

        public Training Training
        {
            get { return training; }
            set { training = value; }
        }

        Validation validation;

        public Validation Validation
        {
            get { return validation; }
            set { validation = value; }
        }

        Serialization serialization;

        public Serialization Serialization
        {
            get { return serialization; }
            set { serialization = value; }
        }
        
        public DecisionTree()
        {
            Serialization = new Serialization();
            Training = new Training();
            Validation = new Validation();
            CodFieldListSB = new StringBuilder();
            CodFieldListSBIsNull = new StringBuilder();
            DsFieldNameList = new StringBuilder();
            codFieldList = new List<string>();
            codFieldListComDsFlowResult = new List<string>();
            fieldSymbols = new Dictionary<dynamic, int>();
            codebook = new Codification();
        }

        public void serialize(int codTask)
        {
            Serialization.serialize(codTask, Tree);
        }

        public Accord.MachineLearning.DecisionTrees.DecisionTree deserialize(int codTask)
        {
            return Serialization.deserialize(codTask);
        }

        public void serializeTree(int codTask)
        {
            Serialization.serializeTree(codTask, this);
        }

        public Data.DecisionTree deserializeTree(int codTask)
        {
            return Serialization.deserializeTree(codTask);
        }

        public bool hasSerializedTree(int codTask)
        {
            return Serialization.hasSerializedTree(codTask);
        }
    }
}