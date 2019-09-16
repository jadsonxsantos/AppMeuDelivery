using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.More
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
            DestacarDia();
        }

        private void DestacarDia()
        {
            DateTime aDate = DateTime.Now;
            DateTime dateValue;

            dateValue = DateTime.Parse(aDate.ToString("MM/dd/yyyy"), CultureInfo.InvariantCulture);
            string dia = dateValue.ToString("dddd", new CultureInfo("pt-BR"));

            if (dia == "segunda-feira")
            {
                lbl_Segunda.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "terça-feira")
            {
                lbl_Terca.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "quarta-feira")
            {
                lbl_Quarta.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "quinta-feira")
            {
                lbl_Quinta.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "sexta-feira")
            {
                lbl_Sexta.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "sábado")
            {
                lbl_Sabado.FontAttributes = FontAttributes.Bold;
            }
            else if (dia == "domingo")
            {
                lbl_Domingo.FontAttributes = FontAttributes.Bold;
            }
        }

        private void DadosEstabelecimentos()
        {
            lbl_Nome.Text = MeuEstabelecimento.Nome;
            //ImagemEstab.Source = MeuEstabelecimento.Logo;
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

            if (Application.Current.Properties.ContainsKey("_AceitaCartao"))
            {
               bool AceitaCartao = Convert.ToBoolean(Application.Current.Properties["_AceitaCartao"]);

                if (AceitaCartao == false)
                    ExibirCartao.IsVisible = false;
                else
                    ExibirCartao.IsVisible = true;

            }
        }

        private void Btn_instagram_Clicked(object sender, EventArgs e)
        {
            //foreach (var item in MeuEstabelecimento.Horario_Funcionamento)
            //{

            //    int InicioExpediente = 8;
            //    int FimExpediente = 23;

            //    //Data que será verificada e tratada
            //    DateTime DataConsulta = DateTime.Now;

            //    //Verifica se o horário já ultrapassou o final do expediente
            //    if (DataConsulta.Hour >= FimExpediente)
            //    {
            //        lbl_Segunda.Text = "Fechado!";
            //    }
            //    else if (DataConsulta.Hour < InicioExpediente)
            //    {
            //        lbl_Segunda.Text = "Fechado";
            //    }
            //}


            foreach (var item in MeuEstabelecimento.Redes_Sociais)
            {
                Device.OpenUri(new Uri(item.Instagram));
            }
        }
    }
}