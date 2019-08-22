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
        Estabelecimento MeuEstabelecimento;
        Cardapio MeusPedido;
        double Qt_pedido, CalculoValorxQtd = 0.00;
        public Detalhes(Cardapio pedido, Estabelecimento estabelecimento)
        {
            InitializeComponent();
            MeusPedido = pedido;
            MeuEstabelecimento = estabelecimento;
            Load_Itens();
           
        }

        //private void CarregarPorcoes()
        //{
        //    try
        //    {
        //        if (MeuEstabelecimento.Porcoes == null)
        //        {
        //            lbl_Adicionais.IsVisible = false;
        //            Stack_Adicionais.IsVisible = false;
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[0].Porcao_Info))
        //                Adicional_00.Text = MeuEstabelecimento.Porcoes[0].Porcao_Info;
        //            else
        //                Adicional_00.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[1].Porcao_Info.ToString()))
        //                Adicional_01.Text = MeuEstabelecimento.Porcoes[1].Porcao_Info.ToString();
        //            else
        //                Adicional_01.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[2].Porcao_Info))
        //                Adicional_02.Text = MeuEstabelecimento.Porcoes[2].Porcao_Info;
        //            else
        //                Adicional_02.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[3].Porcao_Info))
        //                Adicional_03.Text = MeuEstabelecimento.Porcoes[3].Porcao_Info;
        //            else
        //                Adicional_03.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[4].Porcao_Info))
        //                Adicional_04.Text = MeuEstabelecimento.Porcoes[4].Porcao_Info;
        //            else
        //                Adicional_04.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[5].Porcao_Info))
        //                Adicional_05.Text = MeuEstabelecimento.Porcoes[5].Porcao_Info;
        //            else
        //                Adicional_05.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[6].Porcao_Info))
        //                Adicional_06.Text = MeuEstabelecimento.Porcoes[6].Porcao_Info;
        //            else
        //                Adicional_06.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[7].Porcao_Info))
        //                Adicional_07.Text = MeuEstabelecimento.Porcoes[7].Porcao_Info;
        //            else
        //                Adicional_07.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[8].Porcao_Info))
        //                Adicional_08.Text = MeuEstabelecimento.Porcoes[8].Porcao_Info;
        //            else
        //                Adicional_08.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[9].Porcao_Info))
        //                Adicional_09.Text = MeuEstabelecimento.Porcoes[9].Porcao_Info;
        //            else
        //                Adicional_09.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[10].Porcao_Info))
        //                Adicional_10.Text = MeuEstabelecimento.Porcoes[10].Porcao_Info;
        //            else
        //                Adicional_10.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[11].Porcao_Info))
        //                Adicional_11.Text = MeuEstabelecimento.Porcoes[11].Porcao_Info;
        //            else
        //                Adicional_11.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[12].Porcao_Info))
        //                Adicional_12.Text = MeuEstabelecimento.Porcoes[12].Porcao_Info;
        //            else
        //                Adicional_12.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[13].Porcao_Info))
        //                Adicional_13.Text = MeuEstabelecimento.Porcoes[13].Porcao_Info;
        //            else
        //                Adicional_13.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[14].Porcao_Info))
        //                Adicional_14.Text = MeuEstabelecimento.Porcoes[14].Porcao_Info;
        //            else
        //                Adicional_14.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[15].Porcao_Info))
        //                Adicional_15.Text = MeuEstabelecimento.Porcoes[15].Porcao_Info;
        //            else
        //                Adicional_15.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[16].Porcao_Info))
        //                Adicional_16.Text = MeuEstabelecimento.Porcoes[16].Porcao_Info;
        //            else
        //                Adicional_16.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[17].Porcao_Info))
        //                Adicional_17.Text = MeuEstabelecimento.Porcoes[17].Porcao_Info;
        //            else
        //                Adicional_17.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[18].Porcao_Info))
        //                Adicional_18.Text = MeuEstabelecimento.Porcoes[18].Porcao_Info;
        //            else
        //                Adicional_18.IsVisible = false;

        //            if (!String.IsNullOrEmpty(MeuEstabelecimento.Porcoes[19].Porcao_Info))
        //                Adicional_19.Text = MeuEstabelecimento.Porcoes[19].Porcao_Info;
        //            else
        //                Adicional_19.IsVisible = false;
        //        }               
        //    }
        //    catch (Exception)
        //    {
        //        DependencyService.Get<IMessage>().ShortAlert("Algumas informações não foram carregadas...");
        //    }
        //}

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