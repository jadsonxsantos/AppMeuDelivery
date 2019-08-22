using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
   public class Porcao
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public string Porcao_Info
        {
            get
            {
                if (!String.IsNullOrEmpty(Nome) && (!String.IsNullOrEmpty(Valor)))
                    return string.Format(" {0} • R$ {1} ", Nome, Valor);
                else
                    return "";
            }
        }
    }
}
