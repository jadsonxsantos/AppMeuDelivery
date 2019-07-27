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
        public int Quantidade { get; set; }
        public string Valor { get; set; }
        public double ValorTotal { get; set; }
        public string Escolha { get; set; }
        public string TitleAdcorSab { get; set; }
        public double ValorAdicionais { get; set; }
        public double ValorUnit { get; set; }
        public string Valor_P { get; set; }
        public string Valor_P_Title { get; set; }
        public string Valor_M { get; set; }
        public string Valor_M_Title { get; set; }
        public string Valor_G { get; set; }
        public string Valor_G_Title { get; set; }
        public string Valor_B { get; set; }
        public string Valor_B_Title { get; set; }
        public string Valor_F { get; set; }
        public string Valor_F_Title { get; set; }
        public string TrocaInfo { get; set; }
        public string Troco { get; set; }
        public string Valor_RB { get; set; }
        public string Valor_AD { get; set; }
        public string Adicionais_itens { get; set; }
      
        public List<Adicional> Adicionais { get; set; }

        public string Valores
        {
            get
            {
                return string.Format("R$: {0:C} • P: R$ {1:C} • M: {2:C} • G: {3:C} • B: {4:C} ", Valor, Valor_P, Valor_M, Valor_G, Valor_B);
            }
        }

        public string ValorExibicao
        {
            get
            {
                if(Valor == "-----")
                  return string.Format("a partir de R$ {0:C}", Valor_P);
                else
                  return string.Format("R$ {0:C}", Valor); ;
            }
        }       

        public string Pedidos
        {       
            get
            {
                return string.Format("{0}x {1} • {2} - Valor Total {3} ", Quantidade, Nome, Valor, ValorTotal);
            }
        }

        public string ValorTotaleAdicionais
        {            
            get
            {
                if(ValorAdicionais > 0)
                   return string.Format("{0:C} + Total Adicionais: {1:C}", ValorTotal, ValorAdicionais);
                else
                   return string.Format("{0:C}", ValorTotal);
            }
        }

    }
}
