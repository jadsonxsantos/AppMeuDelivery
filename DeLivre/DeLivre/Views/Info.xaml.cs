using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Info : PopupPage
    {
        Estabelecimento MeuEstabelecimento; 

        public Info (Estabelecimento MeusEstabelecimentos)
		{
			InitializeComponent ();
            MeuEstabelecimento = new Estabelecimento();
            MeuEstabelecimento = MeusEstabelecimentos;
            DadosEstabelecimentos();
        }

        private void DadosEstabelecimentos()
        {
            Title = MeuEstabelecimento.Nome;
            ImagemEstab.Source = MeuEstabelecimento.Logo;
            lbl_Horario_Funcionamento.Text = String.Format("R$ {0:C}", MeuEstabelecimento.Pedido_Minimo);
            lbl_Local.Text = MeuEstabelecimento.Local;
            lbl_Frete.Text = String.Format("R$ {0:C}", MeuEstabelecimento.Frete);
            lbl_Tempo.Text = MeuEstabelecimento.Entrega_;
            lbl_Endereco.Text = MeuEstabelecimento.Endereco;
            lbl_Descricao.Text = MeuEstabelecimento.Descricao;
            //Armaenando o valor do Frete!    
            string ValorFrete = MeuEstabelecimento.Frete;
            Application.Current.Properties["_Frete"] = ValorFrete;
            //Armaenando o Numero do Whatsapp!
            Application.Current.Properties["_Whatsapp"] = MeuEstabelecimento.Whatsapp;
            //Armaenando o Numero do Whatsapp!
            Application.Current.Properties["_Estabelecimento_"] = MeuEstabelecimento.Nome;
            //Valor do Pedido Minimo 
            Application.Current.Properties["_PedidoMinimo"] = MeuEstabelecimento.Pedido_Minimo;

            foreach (var item in MeuEstabelecimento.Horarios_Funcionamento)
            {
                lbl_Segunda.Text = "SEGUNDA: " +  item.Segunda_Feira;
                lbl_Terca.Text = "TERÇA: " + item.Terca_Feira;
                lbl_Quarta.Text = "QUARTA: " + item.Terca_Feira;
                lbl_Quinta.Text = "QUINTA: " + item.Quinta_Feira;
                lbl_Sexta.Text = "SEXTA: " + item.Sexta_Feira;
                lbl_Sabado.Text = "SÁBADO: " + item.Sabado;
                lbl_Domingo.Text = "DOMINGO: " + item.Domingo;
            }
            //Carregar Horario de Funconamento dos Estabelecimentos
            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[0].Segunda_Feira))
            //    lbl_Segunda.Text = MeuEstabelecimento.Horarios_Funcionamento[0].Segunda_Feira;
            //else
            //    lbl_Segunda.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[1].Terca_Feira))
            //    lbl_Terca.Text = MeuEstabelecimento.Horarios_Funcionamento[1].Terca_Feira;
            //else
            //    lbl_Terca.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[2].Quarta_Feira))
            //    lbl_Quarta.Text = MeuEstabelecimento.Horarios_Funcionamento[2].Quarta_Feira;
            //else
            //    lbl_Quarta.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[3].Quinta_Feira))
            //    lbl_Quinta.Text = MeuEstabelecimento.Horarios_Funcionamento[3].Quinta_Feira;
            //else
            //    lbl_Quinta.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[4].Sexta_Feira))
            //    lbl_Sexta.Text = MeuEstabelecimento.Horarios_Funcionamento[4].Sexta_Feira;
            //else
            //    lbl_Sexta.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[5].Sabado))
            //    lbl_Sabado.Text = MeuEstabelecimento.Horarios_Funcionamento[5].Sabado;
            //else
            //    lbl_Sabado.Text = "Fechado";

            //if (!String.IsNullOrEmpty(MeuEstabelecimento.Horarios_Funcionamento[6].Domingo))
            //    lbl_Domingo.Text = MeuEstabelecimento.Horarios_Funcionamento[6].Domingo;
            //else
            //    lbl_Domingo.Text = "Fechado";
        }

        private void Btn_instagram_Clicked(object sender, EventArgs e)
        {
            foreach (var item in MeuEstabelecimento.Redes_Sociais)
            {
                Device.OpenUri(new Uri(item.Instagram));
            }
           
        }
    }
}