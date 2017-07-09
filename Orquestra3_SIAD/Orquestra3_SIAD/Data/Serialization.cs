using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class Serialization
    {

        public void serialize(int codTask, Accord.MachineLearning.DecisionTrees.DecisionTree tree)
        {
            // Parametrizar path
            tree.Save(HttpRuntime.AppDomainAppPath + @"\tree" + codTask);
        }

        public void serializeTree(int codTask, Data.DecisionTree tree)
        {
            IFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(HttpRuntime.AppDomainAppPath + @"\tree" + codTask,
                                                FileMode.Create,
                                                FileAccess.Write, FileShare.None);
            try
            {
                formatter.Serialize(stream, tree);
            }
            catch (SerializationException e)
            {
            }
            finally
            {
                stream.Flush();
                stream.Close();
            }
        }

        public Data.DecisionTree deserializeTree(int codTask)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(HttpRuntime.AppDomainAppPath + @"\tree" + codTask,
                                            FileMode.Open,
                                            FileAccess.Read,
                                            FileShare.Read);
            
            Data.DecisionTree myObject = null;

            try
            {
                stream.Position = 0;
                myObject = (Data.DecisionTree)formatter.Deserialize(stream);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Erro");
            }
            finally
            {
                stream.Flush();
                stream.Close();
            }
            
            return myObject;
        }

        


        public Accord.MachineLearning.DecisionTrees.DecisionTree deserialize(int codTask)
        {
            return Accord.MachineLearning.DecisionTrees.DecisionTree.Load(HttpRuntime.AppDomainAppPath + @"\tree" + codTask);
        }

        public bool hasSerializedTree(int codTask)
        {
            return File.Exists(HttpRuntime.AppDomainAppPath + @"\tree" + codTask);
        }
    }
}