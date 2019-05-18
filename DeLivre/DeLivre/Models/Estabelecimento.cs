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
        public bool Aberto { get; set; }
        public bool Cartao_Credito { get; set; }
        public string Pedido_Minimo { get; set; }
        public string Juros_Cartao { get; set; }
        public string Local { get; set; }
        public string Endereco { get; set; }
        public string Frete { get; set; }
        public string Entrega_ { get; set; }
        public string Horario { get; set; }
        public string Horario_Funcionamento { get; set; }
        public string Logo { get; set; }
        public List<Cardapio> Cardapios { get; set; }
        public List<Horario_Funcionamento> Horarios_Funcionamento { get; set; }
        public List<RedesSociais> Redes_Sociais { get; set; }
        public List<Adicional> Adicionais { get; set; }
        public List<SaboresPicole> Sabores_Picole { get; set; }
        public List<SaboresSorvete> Sabores_Sorvete { get; set; }
    }
}
