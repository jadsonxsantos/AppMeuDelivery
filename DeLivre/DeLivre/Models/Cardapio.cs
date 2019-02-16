using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DeLivre.Models
{
   public class Cardapio   
    {
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string Valor_P { get; set; }
        public string Valor_M { get; set; }
        public string Valor_G { get; set; }
        public string Valor_B { get; set; }
        public int Quantidade { get; set; }
       
        public int Values { get; set; }


        private string _ValorTotal;
        public string ValorTotal
        {
            get
            {
                return _ValorTotal;
            }
            set
            {
                _ValorTotal = value;              
            }
        }         

        public string Valores
        {
            get
            {
                return string.Format("R$: {0:C} • P: R$ {1:C} • M: {2:C} • G: {3:C} • B: {4:C} ", Valor, Valor_P, Valor_M, Valor_G, Valor_B);
            }
        }

        public string Pedidos
        {       
            get
            {
                return string.Format("{0}x {1} • {2}", Quantidade, Nome, Valor);
            }
        }

    }
}
