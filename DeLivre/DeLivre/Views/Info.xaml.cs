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
        }

        private void Btn_instagram_Clicked(object sender, EventArgs e)
        {
            foreach (var item in MeuEstabelecimento.Horario_Funcionamento)
            {

                int InicioExpediente = 8;
                int FimExpediente = 23;

                //Data que será verificada e tratada
                DateTime DataConsulta = DateTime.Now;

                //Verifica se o horário já ultrapassou o final do expediente
                if (DataConsulta.Hour >= FimExpediente)
                {
                    lbl_Segunda.Text = "Fechado!";
                }
                else if (DataConsulta.Hour < InicioExpediente)
                {
                    lbl_Segunda.Text = "Fechado";
                }               
            }

         
            //foreach (var item in MeuEstabelecimento.Redes_Sociais)
            //{
            //    Device.OpenUri(new Uri(item.Instagram));
            //}           
        }
    }
}