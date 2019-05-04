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
            lbl_Horario_Funcionamento.Text = MeuEstabelecimento.Horario_Funcionamento;
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