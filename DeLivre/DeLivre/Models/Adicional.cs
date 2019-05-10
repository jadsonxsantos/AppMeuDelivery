using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
   public class Adicional
    {
        public string Nome { get; set; }       
        public string Valor { get; set; }
        public string Ad_Nome { get; set; }
        public string Ad_Valor { get; set; }

        public string Adicional_Info
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
