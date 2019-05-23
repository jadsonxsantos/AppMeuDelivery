using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
    public class Pedido
    {     
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estabelecimento { get; set; }
        public string DataPedido { get; set; }
        public string NomePedido { get; set; }
        public string ValorPedido { get; set; }
    }
}
