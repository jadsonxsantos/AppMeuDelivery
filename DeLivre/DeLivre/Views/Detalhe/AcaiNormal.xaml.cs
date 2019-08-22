using DeLivre.Components;
using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.Detalhe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AcaiNormal : PopupPage
    {
        Cardapio MeusPedido;
        Estabelecimento MeuEstabelecimento;
        double CalculoValorxQtd = 0.00, Qt_pedido;
        string Tamanho, Adc_Item_00, Adc_Item_01, Adc_Item_02, Adc_Item_03, Adc_Item_04, Adc_Item_05,
            Adc_Item_06, Adc_Item_07, Adc_Item_08, Adc_Item_09, Adc_Item_10, Adc_Item_11, Adc_Item_12,
            Adc_Item_13, Adc_Item_14, Adc_Item_15, Adc_Item_16, Adc_Item_17, Adc_Item_18, Adc_Item_19,
            Adc_Item_20, Adc_Item_21, Adc_Item_22, Adc_Item_23, Adc_Item_24, Adc_Item_40, Adc_Item_26,
            Adc_Item_27, Adc_Item_28, Adc_Item_29, Adc_Item_30, Adc_Item_31, Adc_Item_32, Adc_Item_33,
            Adc_Item_34, Adc_Item_35, Adc_Item_36, Adc_Item_37, Adc_Item_38, Adc_Item_39, Adc_Item_25;

        double Adc_Valor_Total = 0.00, Adc_Valor_00 = 0.00, Adc_Valor_01, Adc_Valor_02, Adc_Valor_03, Adc_Valor_04, Adc_Valor_05,
           Adc_Valor_06, Adc_Valor_07, Adc_Valor_08, Adc_Valor_09, Adc_Valor_10, Adc_Valor_11, Adc_Valor_12,
           Adc_Valor_13, Adc_Valor_14, Adc_Valor_15, Adc_Valor_16, Adc_Valor_17, Adc_Valor_18, Adc_Valor_19,
           Adc_Valor_20, Adc_Valor_21, Adc_Valor_22, Adc_Valor_23, Adc_Valor_24, Adc_Valor_25, Adc_Valor_26,
            Adc_Valor_27, Adc_Valor_28, Adc_Valor_29, Adc_Valor_30, Adc_Valor_31, Adc_Valor_32, Adc_Valor_33,
            Adc_Valor_34, Adc_Valor_35, Adc_Valor_36, Adc_Valor_37, Adc_Valor_38, Adc_Valor_39, Adc_Valor_40;

      
        public AcaiNormal (Cardapio pedido, Estabelecimento estabelecimento)
		{
			InitializeComponent ();
            MeusPedido = pedido;
            MeuEstabelecimento = estabelecimento;
            Load_Itens();
            Carregar_Adicionais();
        }

        private void Carregar_Adicionais()
        {
            try
            {
                if (MeuEstabelecimento.Adicionais == null)
                {
                    lbl_Adicionais.IsVisible = false;
                    Stack_Adicionais.IsVisible = false;
                }
                else
                {               
                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[0].Adicional_Info.ToString()))
                        Adicional_00.Text = MeuEstabelecimento.Adicionais[0].Adicional_Info.ToString();
                    else
                        Adicional_00.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[1].Adicional_Info.ToString()))
                        Adicional_01.Text = MeuEstabelecimento.Adicionais[1].Adicional_Info.ToString();
                    else
                        Adicional_01.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[2].Adicional_Info.ToString()))
                        Adicional_02.Text = MeuEstabelecimento.Adicionais[2].Adicional_Info.ToString();
                    else
                        Adicional_02.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[3].Adicional_Info.ToString()))
                        Adicional_03.Text = MeuEstabelecimento.Adicionais[3].Adicional_Info.ToString();
                    else
                        Adicional_03.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[4].Adicional_Info.ToString()))
                        Adicional_04.Text = MeuEstabelecimento.Adicionais[4].Adicional_Info.ToString();
                    else
                        Adicional_04.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[5].Adicional_Info.ToString()))
                        Adicional_05.Text = MeuEstabelecimento.Adicionais[5].Adicional_Info.ToString();
                    else
                        Adicional_05.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[6].Adicional_Info.ToString()))
                        Adicional_06.Text = MeuEstabelecimento.Adicionais[6].Adicional_Info.ToString();
                    else
                        Adicional_06.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[7].Adicional_Info.ToString()))
                        Adicional_07.Text = MeuEstabelecimento.Adicionais[7].Adicional_Info.ToString();
                    else
                        Adicional_07.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[8].Adicional_Info.ToString()))
                        Adicional_08.Text = MeuEstabelecimento.Adicionais[8].Adicional_Info.ToString();
                    else
                        Adicional_08.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[9].Adicional_Info.ToString()))
                        Adicional_09.Text = MeuEstabelecimento.Adicionais[9].Adicional_Info.ToString();
                    else
                        Adicional_09.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[10].Adicional_Info.ToString()))
                        Adicional_10.Text = MeuEstabelecimento.Adicionais[10].Adicional_Info.ToString();
                    else
                        Adicional_10.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[11].Adicional_Info.ToString()))
                        Adicional_11.Text = MeuEstabelecimento.Adicionais[11].Adicional_Info.ToString();
                    else
                        Adicional_11.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[12].Adicional_Info.ToString()))
                        Adicional_12.Text = MeuEstabelecimento.Adicionais[12].Adicional_Info.ToString();
                    else
                        Adicional_12.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[13].Adicional_Info.ToString()))
                        Adicional_13.Text = MeuEstabelecimento.Adicionais[13].Adicional_Info.ToString();
                    else
                        Adicional_13.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[14].Adicional_Info.ToString()))
                        Adicional_14.Text = MeuEstabelecimento.Adicionais[14].Adicional_Info.ToString();
                    else
                        Adicional_14.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[15].Adicional_Info.ToString()))
                        Adicional_15.Text = MeuEstabelecimento.Adicionais[15].Adicional_Info.ToString();
                    else
                        Adicional_15.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[16].Adicional_Info.ToString()))
                        Adicional_16.Text = MeuEstabelecimento.Adicionais[16].Adicional_Info.ToString();
                    else
                        Adicional_16.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[17].Adicional_Info.ToString()))
                        Adicional_17.Text = MeuEstabelecimento.Adicionais[17].Adicional_Info.ToString();
                    else
                        Adicional_17.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[18].Adicional_Info.ToString()))
                        Adicional_18.Text = MeuEstabelecimento.Adicionais[18].Adicional_Info.ToString();
                    else
                        Adicional_18.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[19].Adicional_Info.ToString()))
                        Adicional_19.Text = MeuEstabelecimento.Adicionais[19].Adicional_Info.ToString();
                    else
                        Adicional_19.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[20].Adicional_Info.ToString()))
                        Adicional_20.Text = MeuEstabelecimento.Adicionais[20].Adicional_Info.ToString();
                    else
                        Adicional_20.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[21].Adicional_Info.ToString()))
                        Adicional_21.Text = MeuEstabelecimento.Adicionais[21].Adicional_Info.ToString();
                    else
                        Adicional_21.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[22].Adicional_Info.ToString()))
                        Adicional_22.Text = MeuEstabelecimento.Adicionais[22].Adicional_Info.ToString();
                    else
                        Adicional_22.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[23].Adicional_Info.ToString()))
                        Adicional_23.Text = MeuEstabelecimento.Adicionais[23].Adicional_Info.ToString();
                    else
                        Adicional_23.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[24].Adicional_Info.ToString()))
                        Adicional_24.Text = MeuEstabelecimento.Adicionais[24].Adicional_Info.ToString();
                    else
                        Adicional_24.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[25].Adicional_Info))
                        Adicional_25.Text = MeuEstabelecimento.Adicionais[25].Adicional_Info;
                    else
                        Adicional_25.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[26].Adicional_Info))
                        Adicional_26.Text = MeuEstabelecimento.Adicionais[26].Adicional_Info;
                    else
                        Adicional_26.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[27].Adicional_Info))
                        Adicional_27.Text = MeuEstabelecimento.Adicionais[27].Adicional_Info;
                    else
                        Adicional_27.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[28].Adicional_Info))
                        Adicional_28.Text = MeuEstabelecimento.Adicionais[28].Adicional_Info;
                    else
                        Adicional_28.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[29].Adicional_Info))
                        Adicional_29.Text = MeuEstabelecimento.Adicionais[29].Adicional_Info;
                    else
                        Adicional_29.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[30].Adicional_Info))
                        Adicional_30.Text = MeuEstabelecimento.Adicionais[30].Adicional_Info;
                    else
                        Adicional_30.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[31].Adicional_Info))
                        Adicional_31.Text = MeuEstabelecimento.Adicionais[31].Adicional_Info;
                    else
                        Adicional_31.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[32].Adicional_Info))
                        Adicional_32.Text = MeuEstabelecimento.Adicionais[32].Adicional_Info;
                    else
                        Adicional_32.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[33].Adicional_Info))
                        Adicional_33.Text = MeuEstabelecimento.Adicionais[33].Adicional_Info;
                    else
                        Adicional_33.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[34].Adicional_Info))
                        Adicional_34.Text = MeuEstabelecimento.Adicionais[34].Adicional_Info;
                    else
                        Adicional_34.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[35].Adicional_Info))
                        Adicional_35.Text = MeuEstabelecimento.Adicionais[35].Adicional_Info;
                    else
                        Adicional_35.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[36].Adicional_Info))
                        Adicional_36.Text = MeuEstabelecimento.Adicionais[36].Adicional_Info;
                    else
                        Adicional_36.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[37].Adicional_Info))
                        Adicional_37.Text = MeuEstabelecimento.Adicionais[37].Adicional_Info;
                    else
                        Adicional_37.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[38].Adicional_Info))
                        Adicional_38.Text = MeuEstabelecimento.Adicionais[38].Adicional_Info;
                    else
                        Adicional_38.IsVisible = false;

                    if (!String.IsNullOrEmpty(MeuEstabelecimento.Adicionais[39].Adicional_Info))
                        Adicional_39.Text = MeuEstabelecimento.Adicionais[39].Adicional_Info;
                    else
                        Adicional_39.IsVisible = false;
                }   
            }
            catch (Exception)
            {
                DependencyService.Get<IMessage>().ShortAlert("Algumas informações não foram carregadas...");
            }
        }

        private void Load_Itens()
        {
            lbl_Tipo_lanche.Text = "x " + MeusPedido.Tipo + ",";
            lbl_Nome_lanche.Text = MeusPedido.Nome;
            lbl_Descricao.Text = "(" + MeusPedido.Descricao + ")";           

                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))                
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);                
                else                
                    Tipo_P.IsVisible = false;                

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))                
                    Tipo_I.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);                
                else                
                    Tipo_I.IsVisible = false;                

                if (!String.IsNullOrEmpty(MeusPedido.Valor_M))                
                    Tipo_M.Text = String.Format(MeusPedido.Valor_M_Title + " - R$ {0:C}", MeusPedido.Valor_M);                
                else                
                    Tipo_M.IsVisible = false;                

                if (!String.IsNullOrEmpty(MeusPedido.Valor_G))                
                    Tipo_G.Text = String.Format(MeusPedido.Valor_G_Title + " - R$ {0:C}", MeusPedido.Valor_G);                
                else                
                    Tipo_G.IsVisible = false;                
                
          
            Application.Current.Properties["_TrocaInfo"] = Lbl_Troca.Text;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Qt_pedido = e.NewValue;
        }
        private void AdicionarPedidoAdicionais(string adicionais, double valoradic, int quantidade)
        {
            App.Meus_Pedidos.Add(new Cardapio()
            {
                Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                Nome = lbl_Nome_lanche.Text + ": " + Tamanho,
                Descricao = lbl_Descricao.Text,
                Adicionais_itens = adicionais,
                ValorAdicionais = valoradic,
                TitleAdcorSab = "Adicionais",
                ValorUnit = Convert.ToDouble(MeusPedido.Valor_RB),
                ValorTotal = CalculoValorxQtd,
                Quantidade = quantidade,
                TrocaInfo = Lbl_Troca.Text
            });
            //await Navigation.PushAsync(new Pedido(App.Meus_Pedidos));
            DependencyService.Get<IMessage>().ShortAlert("Pedido Adicionado ao Carrinho!");
            OnClose();
        }

        private void Btn_selecionar_Clicked(object sender, EventArgs e)
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

                if (MeusPedido.Descricao.Contains("complementos") || MeusPedido.Descricao.Contains("porções"))
                {
                    if (Adicional_00.IsChecked == true)
                    {
                        Adc_Item_00 = MeuEstabelecimento.Adicionais[0].Nome + "; ";
                    }
                    if (Adicional_01.IsChecked == true)
                    {
                        Adc_Item_01 = MeuEstabelecimento.Adicionais[1].Nome + "; ";
                    }
                    if (Adicional_02.IsChecked == true)
                    {
                        Adc_Item_02 = MeuEstabelecimento.Adicionais[2].Nome + "; ";
                    }
                    if (Adicional_03.IsChecked == true)
                    {
                        Adc_Item_03 = MeuEstabelecimento.Adicionais[3].Nome + "; ";
                    }
                    if (Adicional_04.IsChecked == true)
                    {
                        Adc_Item_04 = MeuEstabelecimento.Adicionais[4].Nome + "; ";
                    }
                    if (Adicional_05.IsChecked == true)
                    {
                        Adc_Item_05 = MeuEstabelecimento.Adicionais[5].Nome + "; ";
                    }
                    if (Adicional_06.IsChecked == true)
                    {
                        Adc_Item_06 = MeuEstabelecimento.Adicionais[6].Nome + "; ";
                    }
                    if (Adicional_07.IsChecked == true)
                    {
                        Adc_Item_07 = MeuEstabelecimento.Adicionais[7].Nome + "; ";
                    }
                    if (Adicional_08.IsChecked == true)
                    {
                        Adc_Item_08 = MeuEstabelecimento.Adicionais[8].Nome + "; ";
                    }
                    if (Adicional_09.IsChecked == true)
                    {
                        Adc_Item_09 = MeuEstabelecimento.Adicionais[9].Nome + "; ";
                    }
                    if (Adicional_10.IsChecked == true)
                    {
                        Adc_Item_10 = MeuEstabelecimento.Adicionais[10].Nome + "; ";
                    }
                    if (Adicional_11.IsChecked == true)
                    {
                        Adc_Item_11 = MeuEstabelecimento.Adicionais[11].Nome + "; ";
                    }
                    if (Adicional_12.IsChecked == true)
                    {
                        Adc_Item_12 = MeuEstabelecimento.Adicionais[12].Nome + "; ";
                    }
                    if (Adicional_13.IsChecked == true)
                    {
                        Adc_Item_13 = MeuEstabelecimento.Adicionais[13].Nome + "; ";
                    }
                    if (Adicional_14.IsChecked == true)
                    {
                        Adc_Item_14 = MeuEstabelecimento.Adicionais[14].Nome + "; ";
                    }
                    if (Adicional_15.IsChecked == true)
                    {
                        Adc_Item_15 = MeuEstabelecimento.Adicionais[15].Nome + "; ";
                    }
                    if (Adicional_16.IsChecked == true)
                    {
                        Adc_Item_16 = MeuEstabelecimento.Adicionais[16].Nome + "; ";
                    }
                    if (Adicional_17.IsChecked == true)
                    {
                        Adc_Item_17 = MeuEstabelecimento.Adicionais[17].Nome + "; ";
                    }
                    if (Adicional_18.IsChecked == true)
                    {
                        Adc_Item_18 = MeuEstabelecimento.Adicionais[18].Nome + "; ";
                    }
                    if (Adicional_19.IsChecked == true)
                    {
                        Adc_Item_19 = MeuEstabelecimento.Adicionais[19].Nome + "; ";
                    }
                    if (Adicional_20.IsChecked == true)
                    {
                        Adc_Item_20 = MeuEstabelecimento.Adicionais[20].Nome + "; ";
                    }
                    if (Adicional_21.IsChecked == true)
                    {
                        Adc_Item_21 = MeuEstabelecimento.Adicionais[21].Nome + "; ";
                    }
                    if (Adicional_22.IsChecked == true)
                    {
                        Adc_Item_22 = MeuEstabelecimento.Adicionais[22].Nome + "; ";
                    }
                    if (Adicional_23.IsChecked == true)
                    {
                        Adc_Item_23 = MeuEstabelecimento.Adicionais[23].Nome + "; ";
                    }
                    if (Adicional_24.IsChecked == true)
                    {
                        Adc_Item_24 = MeuEstabelecimento.Adicionais[24].Nome + "; ";
                    }
                    if (Adicional_25.IsChecked == true)
                    {
                        Adc_Item_25 = MeuEstabelecimento.Adicionais[25].Nome + "; ";
                    }
                    if (Adicional_26.IsChecked == true)
                    {
                        Adc_Item_26 = MeuEstabelecimento.Adicionais[26].Nome + "; ";
                    }
                    if (Adicional_27.IsChecked == true)
                    {
                        Adc_Item_27 = MeuEstabelecimento.Adicionais[27].Nome + "; ";
                    }
                    if (Adicional_28.IsChecked == true)
                    {
                        Adc_Item_28 = MeuEstabelecimento.Adicionais[28].Nome + "; ";
                    }
                    if (Adicional_29.IsChecked == true)
                    {
                        Adc_Item_29 = MeuEstabelecimento.Adicionais[29].Nome + "; ";
                    }
                    if (Adicional_30.IsChecked == true)
                    {
                        Adc_Item_30 = MeuEstabelecimento.Adicionais[30].Nome + "; ";
                    }
                    if (Adicional_31.IsChecked == true)
                    {
                        Adc_Item_31 = MeuEstabelecimento.Adicionais[31].Nome + "; ";
                    }
                    if (Adicional_32.IsChecked == true)
                    {
                        Adc_Item_32 = MeuEstabelecimento.Adicionais[32].Nome + "; ";
                    }
                    if (Adicional_33.IsChecked == true)
                    {
                        Adc_Item_33 = MeuEstabelecimento.Adicionais[33].Nome + "; ";
                    }
                    if (Adicional_34.IsChecked == true)
                    {
                        Adc_Item_34 = MeuEstabelecimento.Adicionais[34].Nome + "; ";
                    }
                    if (Adicional_35.IsChecked == true)
                    {
                        Adc_Item_35 = MeuEstabelecimento.Adicionais[35].Nome + "; ";
                    }
                    if (Adicional_36.IsChecked == true)
                    {
                        Adc_Item_36 = MeuEstabelecimento.Adicionais[36].Nome + "; ";
                    }
                    if (Adicional_37.IsChecked == true)
                    {
                        Adc_Item_37 = MeuEstabelecimento.Adicionais[37].Nome + "; ";
                    }
                    if (Adicional_38.IsChecked == true)
                    {
                        Adc_Item_38 = MeuEstabelecimento.Adicionais[38].Nome + "; ";
                    }
                    if (Adicional_39.IsChecked == true)
                    {
                        Adc_Item_39 = MeuEstabelecimento.Adicionais[39].Nome + "; ";
                    }

                    string MeusAdicionais = Adc_Item_00 + Adc_Item_01 + Adc_Item_02 + Adc_Item_03 + Adc_Item_04 + Adc_Item_05 +
                            Adc_Item_06 + Adc_Item_07 + Adc_Item_08 + Adc_Item_09 + Adc_Item_10 + Adc_Item_11 + Adc_Item_12 +
                            Adc_Item_13 + Adc_Item_14 + Adc_Item_15 + Adc_Item_16 + Adc_Item_17 + Adc_Item_18 + Adc_Item_19 +
                            Adc_Item_20 + Adc_Item_21 + Adc_Item_22 + Adc_Item_23 + Adc_Item_24 + Adc_Item_25 + Adc_Item_26 +
                            Adc_Item_27 + Adc_Item_28 + Adc_Item_29 + Adc_Item_30 + Adc_Item_31 + Adc_Item_32 + Adc_Item_33 + 
                            Adc_Item_34 + Adc_Item_35 + Adc_Item_36 + Adc_Item_37 + Adc_Item_38 + Adc_Item_39;


                    double valorunit = 0.00;

                    int Qt_item = Convert.ToInt32(Qt_Pedido.Text);

                    valorunit = Convert.ToDouble(MeusPedido.Valor_RB);
                    CalculoValorxQtd = Qt_item * valorunit;
                    AdicionarPedidoAdicionais(MeusAdicionais, 0, Qt_item);
                    //AdicionarPedido(MeusAdicionais, Qt_item);                   
                }
                else
                {
                    if (Adicional_00.IsChecked == true)
                    {
                        Adc_Item_00 = Adicional_00.Text + ", ";
                        Adc_Valor_00 = Convert.ToDouble(MeuEstabelecimento.Adicionais[0].Valor);
                    }
                    if (Adicional_01.IsChecked == true)
                    {
                        Adc_Item_01 = Adicional_01.Text + ", ";
                        Adc_Valor_01 = Convert.ToDouble(MeuEstabelecimento.Adicionais[1].Valor);
                    }
                    if (Adicional_02.IsChecked == true)
                    {
                        Adc_Item_02 = Adicional_02.Text + ", ";
                        Adc_Valor_02 = Convert.ToDouble(MeuEstabelecimento.Adicionais[2].Valor);
                    }
                    if (Adicional_03.IsChecked == true)
                    {
                        Adc_Item_03 = Adicional_03.Text + ", ";
                        Adc_Valor_03 = Convert.ToDouble(MeuEstabelecimento.Adicionais[3].Valor);
                    }
                    if (Adicional_04.IsChecked == true)
                    {
                        Adc_Item_04 = Adicional_04.Text + ", ";
                        Adc_Valor_04 = Convert.ToDouble(MeuEstabelecimento.Adicionais[4].Valor);
                    }
                    if (Adicional_05.IsChecked == true)
                    {
                        Adc_Item_05 = Adicional_05.Text + ", ";
                        Adc_Valor_05 = Convert.ToDouble(MeuEstabelecimento.Adicionais[5].Valor);
                    }
                    if (Adicional_06.IsChecked == true)
                    {
                        Adc_Item_06 = Adicional_06.Text + ", ";
                        Adc_Valor_06 = Convert.ToDouble(MeuEstabelecimento.Adicionais[6].Valor);
                    }
                    if (Adicional_07.IsChecked == true)
                    {
                        Adc_Item_07 = Adicional_07.Text + ", ";
                        Adc_Valor_07 = Convert.ToDouble(MeuEstabelecimento.Adicionais[7].Valor);
                    }
                    if (Adicional_08.IsChecked == true)
                    {
                        Adc_Item_08 = Adicional_08.Text + ", ";
                        Adc_Valor_08 = Convert.ToDouble(MeuEstabelecimento.Adicionais[8].Valor);
                    }
                    if (Adicional_09.IsChecked == true)
                    {
                        Adc_Item_09 = Adicional_09.Text + ", ";
                        Adc_Valor_09 = Convert.ToDouble(MeuEstabelecimento.Adicionais[9].Valor);
                    }
                    if (Adicional_10.IsChecked == true)
                    {
                        Adc_Item_10 = Adicional_10.Text + ", ";
                        Adc_Valor_10 = Convert.ToDouble(MeuEstabelecimento.Adicionais[10].Valor);
                    }
                    if (Adicional_11.IsChecked == true)
                    {
                        Adc_Item_11 = Adicional_11.Text + ", ";
                        Adc_Valor_11 = Convert.ToDouble(MeuEstabelecimento.Adicionais[11].Valor);
                    }
                    if (Adicional_12.IsChecked == true)
                    {
                        Adc_Item_12 = Adicional_12.Text + ", ";
                        Adc_Valor_12 = Convert.ToDouble(MeuEstabelecimento.Adicionais[12].Valor);
                    }
                    if (Adicional_13.IsChecked == true)
                    {
                        Adc_Item_13 = Adicional_13.Text + ", ";
                        Adc_Valor_13 = Convert.ToDouble(MeuEstabelecimento.Adicionais[13].Valor);
                    }
                    if (Adicional_14.IsChecked == true)
                    {
                        Adc_Item_14 = Adicional_14.Text + ", ";
                        Adc_Valor_14 = Convert.ToDouble(MeuEstabelecimento.Adicionais[14].Valor);
                    }
                    if (Adicional_15.IsChecked == true)
                    {
                        Adc_Item_15 = Adicional_15.Text + ", ";
                        Adc_Valor_15 = Convert.ToDouble(MeuEstabelecimento.Adicionais[15].Valor);
                    }
                    if (Adicional_16.IsChecked == true)
                    {
                        Adc_Item_16 = Adicional_16.Text + ", ";
                        Adc_Valor_16 = Convert.ToDouble(MeuEstabelecimento.Adicionais[16].Valor);
                    }
                    if (Adicional_17.IsChecked == true)
                    {
                        Adc_Item_17 = Adicional_17.Text + ", ";
                        Adc_Valor_17 = Convert.ToDouble(MeuEstabelecimento.Adicionais[17].Valor);
                    }
                    if (Adicional_18.IsChecked == true)
                    {
                        Adc_Item_18 = Adicional_18.Text + ", ";
                        Adc_Valor_18 = Convert.ToDouble(MeuEstabelecimento.Adicionais[18].Valor);

                    }
                    if (Adicional_19.IsChecked == true)
                    {
                        Adc_Item_19 = Adicional_19.Text + ", ";
                        Adc_Valor_19 = Convert.ToDouble(MeuEstabelecimento.Adicionais[19].Valor);
                    }
                    if (Adicional_20.IsChecked == true)
                    {
                        Adc_Item_20 = Adicional_20.Text + ", ";
                        Adc_Valor_20 = Convert.ToDouble(MeuEstabelecimento.Adicionais[20].Valor);
                    }
                    if (Adicional_21.IsChecked == true)
                    {
                        Adc_Item_21 = Adicional_21.Text + ", ";
                        Adc_Valor_21 = Convert.ToDouble(MeuEstabelecimento.Adicionais[21].Valor);
                    }
                    if (Adicional_22.IsChecked == true)
                    {
                        Adc_Item_22 = Adicional_22.Text + ", ";
                        Adc_Valor_22 = Convert.ToDouble(MeuEstabelecimento.Adicionais[22].Valor);
                    }
                    if (Adicional_23.IsChecked == true)
                    {
                        Adc_Item_23 = Adicional_23.Text + ", ";
                        Adc_Valor_23 = Convert.ToDouble(MeuEstabelecimento.Adicionais[23].Valor);
                    }
                    if (Adicional_24.IsChecked == true)
                    {
                        Adc_Item_24 = Adicional_24.Text + ", ";
                        Adc_Valor_24 = Convert.ToDouble(MeuEstabelecimento.Adicionais[24].Valor);
                    }
                    if (Adicional_25.IsChecked == true)
                    {
                        Adc_Item_25 = Adicional_25.Text + ", ";
                        Adc_Valor_25 = Convert.ToDouble(MeuEstabelecimento.Adicionais[25].Valor);
                    }
                    if (Adicional_26.IsChecked == true)
                    {
                        Adc_Item_26 = Adicional_26.Text + ", ";
                        Adc_Valor_26 = Convert.ToDouble(MeuEstabelecimento.Adicionais[26].Valor);
                    }
                    if (Adicional_27.IsChecked == true)
                    {
                        Adc_Item_27 = Adicional_27.Text + ", ";
                        Adc_Valor_27 = Convert.ToDouble(MeuEstabelecimento.Adicionais[27].Valor);
                    }
                    if (Adicional_28.IsChecked == true)
                    {
                        Adc_Item_28 = Adicional_28.Text + ", ";
                        Adc_Valor_28 = Convert.ToDouble(MeuEstabelecimento.Adicionais[28].Valor);
                    }
                    if (Adicional_29.IsChecked == true)
                    {
                        Adc_Item_29 = Adicional_29.Text + ", ";
                        Adc_Valor_29 = Convert.ToDouble(MeuEstabelecimento.Adicionais[29].Valor);
                    }
                    if (Adicional_30.IsChecked == true)
                    {
                        Adc_Item_30 = Adicional_30.Text + ", ";
                        Adc_Valor_30 = Convert.ToDouble(MeuEstabelecimento.Adicionais[30].Valor);
                    }
                    if (Adicional_31.IsChecked == true)
                    {
                        Adc_Item_31 = Adicional_31.Text + ", ";
                        Adc_Valor_31 = Convert.ToDouble(MeuEstabelecimento.Adicionais[31].Valor);
                    }
                    if (Adicional_32.IsChecked == true)
                    {
                        Adc_Item_32 = Adicional_32.Text + ", ";
                        Adc_Valor_32 = Convert.ToDouble(MeuEstabelecimento.Adicionais[32].Valor);
                    }
                    if (Adicional_33.IsChecked == true)
                    {
                        Adc_Item_33 = Adicional_33.Text + ", ";
                        Adc_Valor_33 = Convert.ToDouble(MeuEstabelecimento.Adicionais[33].Valor);
                    }
                    if (Adicional_34.IsChecked == true)
                    {
                        Adc_Item_34 = Adicional_34.Text + ", ";
                        Adc_Valor_34 = Convert.ToDouble(MeuEstabelecimento.Adicionais[34].Valor);
                    }
                    if (Adicional_35.IsChecked == true)
                    {
                        Adc_Item_35 = Adicional_35.Text + ", ";
                        Adc_Valor_35 = Convert.ToDouble(MeuEstabelecimento.Adicionais[35].Valor);
                    }
                    if (Adicional_36.IsChecked == true)
                    {
                        Adc_Item_36 = Adicional_36.Text + ", ";
                        Adc_Valor_36 = Convert.ToDouble(MeuEstabelecimento.Adicionais[36].Valor);
                    }
                    if (Adicional_37.IsChecked == true)
                    {
                        Adc_Item_37 = Adicional_37.Text + ", ";
                        Adc_Valor_37 = Convert.ToDouble(MeuEstabelecimento.Adicionais[37].Valor);
                    }
                    if (Adicional_38.IsChecked == true)
                    {
                        Adc_Item_38 = Adicional_38.Text + ", ";
                        Adc_Valor_38 = Convert.ToDouble(MeuEstabelecimento.Adicionais[38].Valor);
                    }
                    if (Adicional_39.IsChecked == true)
                    {
                        Adc_Item_39 = Adicional_39.Text + ", ";
                        Adc_Valor_39 = Convert.ToDouble(MeuEstabelecimento.Adicionais[39].Valor);
                    }

                    string MeusAdicionais = Adc_Item_00 + Adc_Item_01 + Adc_Item_02 + Adc_Item_03 + Adc_Item_04 + Adc_Item_05 +
                            Adc_Item_06 + Adc_Item_07 + Adc_Item_08 + Adc_Item_09 + Adc_Item_10 + Adc_Item_11 + Adc_Item_12 +
                            Adc_Item_13 + Adc_Item_14 + Adc_Item_15 + Adc_Item_16 + Adc_Item_17 + Adc_Item_18 + Adc_Item_19 +
                            Adc_Item_20 + Adc_Item_21 + Adc_Item_22 + Adc_Item_23 + Adc_Item_24 + Adc_Item_25 + Adc_Item_26 +
                            Adc_Item_27 + Adc_Item_28 + Adc_Item_29 + Adc_Item_30 + Adc_Item_31 + Adc_Item_32 + Adc_Item_33 +
                            Adc_Item_34 + Adc_Item_35 + Adc_Item_36 + Adc_Item_37 + Adc_Item_38 + Adc_Item_39;

                    double valorAdcionais = Adc_Valor_00 + Adc_Valor_01 + Adc_Valor_02 + Adc_Valor_03 + Adc_Valor_04 + Adc_Valor_05 +
                           Adc_Valor_06 + Adc_Valor_07 + Adc_Valor_08 + Adc_Valor_09 + Adc_Valor_10 + Adc_Valor_11 + Adc_Valor_12 +
                           Adc_Valor_13 + Adc_Valor_14 + Adc_Valor_15 + Adc_Valor_16 + Adc_Valor_17 + Adc_Valor_18 + Adc_Valor_19 +
                           Adc_Valor_20 + Adc_Valor_21 + Adc_Valor_22 + Adc_Valor_23 + Adc_Valor_24 + Adc_Valor_25 + Adc_Valor_26 +
                           Adc_Valor_27 + Adc_Valor_28 + Adc_Valor_29 + Adc_Valor_30 + Adc_Valor_31 + Adc_Valor_32 + Adc_Valor_33 +
                           Adc_Valor_34 + Adc_Valor_35 + Adc_Valor_36 + Adc_Valor_37 + Adc_Valor_38 + Adc_Valor_39 + Adc_Valor_40;

                    double valorunit = 0.00;

                    int Qt_item = Convert.ToInt32(Qt_Pedido.Text);

                    valorunit = Convert.ToDouble(MeusPedido.Valor_RB);
                    CalculoValorxQtd = Qt_item * valorunit;

                    AdicionarPedidoAdicionais(MeusAdicionais, valorAdcionais, Qt_item);

                    // Verificando se o mesmo produto esta no pedido!
                    //Cardapio Check_Nome = App.Meus_Pedidos.FirstOrDefault(cf => cf.Nome.Contains(lbl_Nome_lanche.Text));

                    //if (Check_Nome == null)
                    //{
                    //    Cardapio Check_Tipo = App.Meus_Pedidos.FirstOrDefault(cf => cf.Tipo.Contains(lbl_Tipo_lanche.Text));

                    //    if (Check_Tipo == null)
                    //    {

                    //        App.Meus_Pedidos.Add(new Cardapio()
                    //        {
                    //            Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                    //            Nome = lbl_Nome_lanche.Text + ": " + Tamanho,
                    //            Descricao = lbl_Descricao.Text,
                    //            Adicionais_itens = MeusAdicionais,
                    //            ValorAdicionais = valorAdcionais,
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
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void OnClose()
        {
            PopupNavigation.Instance.PopAsync();
        }
    }
}