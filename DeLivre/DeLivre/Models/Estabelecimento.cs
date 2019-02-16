using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
   public class Estabelecimento
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Whatsapp { get; set; }
        public string Notificacao { get; set; }
        public bool Ativo { get; set; }
        public string Local { get; set; }
        public string Frete { get; set; }
        public string Entrega_ { get; set; }
        public string Horario_Funcionamento { get; set; }
        public string Logo { get; set; }
        public List<Cardapio> Cardapios { get; set; }
    }
}
