using DeLivre.Components;
using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.Detalhe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhes : PopupPage
	{
        Cardapio MeusPedido;       
        double Qt_pedido, CalculoValorxQtd = 0.00;
        public Detalhes (Cardapio pedido)
		{
			InitializeComponent ();
            MeusPedido = pedido;
            Load_Itens();
        }

        private void Load_Itens()
        {
            // Alimentando a tela com os dados do estabelecimento
            lbl_Tipo_lanche.Text = "x " + MeusPedido.Tipo + ",";
            lbl_Nome_lanche.Text = MeusPedido.Nome;
            lbl_Descricao.Text = "(" + MeusPedido.Descricao + ")";
            lbl_Valor.Text = String.Format("Valor Unit.: R$ {0:C}", MeusPedido.Valor);         
            Application.Current.Properties["_TrocaInfo"] = Lbl_Troca.Text;
          
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Qt_pedido = e.NewValue;
        }

        private async void Btn_selecionar_Clicked(object sender, EventArgs e)
        {           
            double valorunit = 0.00;
           
            int Qt_item = Convert.ToInt32(Qt_Pedido.Text);        

            valorunit = Convert.ToDouble(MeusPedido.Valor);
            CalculoValorxQtd = Qt_item * valorunit;
            string value = lbl_Valor.Text;
            // Verificando se o mesmo produto esta no pedido!
            Cardapio Check_Nome = App.Meus_Pedidos.FirstOrDefault(cf => cf.Nome.Contains(lbl_Nome_lanche.Text));

            if (Check_Nome == null)
            {
                Cardapio Check_Tipo = App.Meus_Pedidos.FirstOrDefault(cf => cf.Tipo.Contains(lbl_Tipo_lanche.Text));

                if (Check_Tipo == null)
                {                   
                    App.Meus_Pedidos.Add(new Cardapio()
                    {
                        Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                        Nome = lbl_Nome_lanche.Text,
                        Descricao = lbl_Descricao.Text,
                        ValorUnit = Convert.ToDouble(MeusPedido.Valor),
                        ValorTotal = CalculoValorxQtd,
                        Quantidade = Qt_item,
                        TrocaInfo = Lbl_Troca.Text
                    });
                  
                    DependencyService.Get<IMessage>().ShortAlert("Pedido Adicionado ao Carrinho!");
                    OnClose();
                }
            }
            else
            {
                await DisplayAlert("Atenção!", "Você já adicionou esse Lanche ao Pedido!", "OK");
                OnClose();
            }          
        }

        private void OnClose()
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}