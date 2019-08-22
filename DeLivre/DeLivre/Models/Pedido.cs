using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
    public class Pedido
    {             
        public string Nome { get; set; }
        public string Estabelecimento { get; set; }
        public string HoraPedido { get; set; }       
        public string ValorPedido { get; set; }       
    }
}
