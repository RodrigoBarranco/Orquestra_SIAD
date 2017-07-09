using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orquestra3_SIAD.Data
{
    [Serializable]
    public class DecisionSupportField
    {
        public int codigo { get; set; }
        public string nome { get; set; }
        public int simbolos { get; set; }
        public int nulos { get; set; }
        public bool relevante { get; set; }

        public DecisionSupportField(int codigo, string nome)
        {
            this.codigo = codigo;
            this.nome = nome;
        }
    }
}