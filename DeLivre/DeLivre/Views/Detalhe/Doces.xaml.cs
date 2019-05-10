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
	public partial class Doces : PopupPage
	{
        Cardapio MeusPedido;       
        double Qt_pedido, CalculoValorxQtd = 0.00;
        string Tamanho;

        public Doces (Cardapio pedido)
		{
			InitializeComponent ();
            MeusPedido = pedido;
            Load_Itens();
        }

        private void Load_Itens()
        {   
            lbl_Tipo_lanche.Text = "x " + MeusPedido.Tipo + ",";
            lbl_Nome_lanche.Text = MeusPedido.Nome;
            lbl_Descricao.Text = "(" + MeusPedido.Descricao + ")";

            if(!String.IsNullOrEmpty(MeusPedido.Valor_P))
            {
                Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);             
            }
            else
            {
                Tipo_P.IsVisible = false;
            }

            if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
            {
                Tipo_I.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);               
            }
            else
            {
                Tipo_I.IsVisible = false;
            }

            if (!String.IsNullOrEmpty(MeusPedido.Valor_M))
            {
                Tipo_M.Text = String.Format(MeusPedido.Valor_M_Title + " - R$ {0:C}", MeusPedido.Valor_M);              
            }
            else
            {
                Tipo_M.IsVisible = false;
            }

            if (!String.IsNullOrEmpty(MeusPedido.Valor_G))
            {
                Tipo_G.Text = String.Format(MeusPedido.Valor_G_Title + " - R$ {0:C}", MeusPedido.Valor_G);               
            }
            else
            {
                Tipo_G.IsVisible = false;
            }
           
            Application.Current.Properties["_TrocaInfo"] = Lbl_Troca.Text;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Qt_pedido = e.NewValue;
        }

        private void EnviarPedido(int quantidade)
        {
            App.Meus_Pedidos.Add(new Cardapio()
            {
                Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                Nome = lbl_Nome_lanche.Text + ": " + Tamanho + " ",
                Descricao = lbl_Descricao.Text,
                ValorUnit = Convert.ToDouble(MeusPedido.Valor_RB),
                ValorTotal = CalculoValorxQtd,
                Quantidade = quantidade,
                TrocaInfo = Lbl_Troca.Text
            });
            //await Navigation.PushAsync(new Pedido(App.Meus_Pedidos));
            DependencyService.Get<IMessage>().ShortAlert("Pedido Adicionado ao Carrinho!");
            OnClose();
        }
        private async void Btn_selecionar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Tipo_P.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_P;
                    Tamanho = MeusPedido.Valor_P_Title;
                }
                if (Tipo_M.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_M;
                    Tamanho = MeusPedido.Valor_M_Title;
                }
                if (Tipo_I.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_B;
                    Tamanho = MeusPedido.Valor_B_Title;
                }
                if (Tipo_G.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_G;
                    Tamanho = MeusPedido.Valor_G_Title;
                }

                double valorunit = 0.00;

                int Qt_item = Convert.ToInt32(Qt_Pedido.Text);

                valorunit = Convert.ToDouble(MeusPedido.Valor_RB);
                CalculoValorxQtd = Qt_item * valorunit;

                EnviarPedido(Qt_item);
                // Verificando se o mesmo produto esta no pedido!
                //Cardapio Check_Nome = App.Meus_Pedidos.FirstOrDefault(cf => cf.Nome.Contains(lbl_Nome_lanche.Text));

                //if (Check_Nome == null)
                //{
                //    Cardapio Check_Tipo = App.Meus_Pedidos.FirstOrDefault(cf => cf.Tipo.Contains(lbl_Tipo_lanche.Text));

                //    if(Check_Tipo == null)
                //    {
                //        App.Meus_Pedidos.Add(new Cardapio()
                //        {
                //            Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                //            Nome = lbl_Nome_lanche.Text + ": " + Tamanho + " ",
                //            Descricao = lbl_Descricao.Text,
                //            ValorUnit = Convert.ToDouble(MeusPedido.Valor_RB),
                //            ValorTotal = CalculoValorxQtd,
                //            Quantidade = Qt_item,
                //            TrocaInfo = Lbl_Troca.Text
                //        });
                //        //await Navigation.PushAsync(new Pedido(App.Meus_Pedidos));
                //        DependencyService.Get<IMessage>().ShortAlert("Pedido Adicionado ao Carrinho!");
                //        OnClose();
                //    }
                //    else
                //    {
                //        await DisplayAlert("Atenção!", "Você já adicionou esse Lanche ao Pedido!", "OK");
                //        OnClose();
                //    }                    
                //}
                //else
                //{
                //    await DisplayAlert("Atenção!", "Você já adicionou esse Lanche ao Pedido!", "OK");
                //    OnClose();
                //}
            }
            catch (Exception)
            {
                await DisplayAlert("Atenção!", "Selecione o tipo/tamanho!", "OK");
            }
           
        }

        private void OnClose()
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}