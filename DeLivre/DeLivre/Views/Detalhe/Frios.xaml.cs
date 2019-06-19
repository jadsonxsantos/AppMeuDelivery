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
	public partial class Frios : PopupPage
	{
        Cardapio MeusPedido;
        Estabelecimento MeuEstabelecimento;
        double Qt_pedido, CalculoValorxQtd = 0.00;
        string TipoFrio;
        string Tamanho, Adc_Item_00, Adc_Item_01, Adc_Item_02, Adc_Item_03, Adc_Item_04, Adc_Item_05,
            Adc_Item_06, Adc_Item_07, Adc_Item_08, Adc_Item_09, Adc_Item_10, Adc_Item_11, Adc_Item_12,
            Adc_Item_13, Adc_Item_14, Adc_Item_15, Adc_Item_16, Adc_Item_17, Adc_Item_18, Adc_Item_19,
            Adc_Item_20, Adc_Item_21, Adc_Item_22, Adc_Item_23, Adc_Item_24, Adc_Item_25;


        List<string> ListaAdicionais = new List<string>();
        public Frios (Cardapio pedido, Estabelecimento estabelecimento)
		{
			InitializeComponent ();
            MeusPedido = pedido;
            MeuEstabelecimento = estabelecimento;
            Load_Itens();
           
        }      

        private void Load_Sabores()
        {
            if(MeusPedido.Tipo == "Sorvete")
            {
                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[0].Nome))               
                    Adicional_00.Text = MeuEstabelecimento.Sabores_Sorvete[0].Nome;
                else
                    Adicional_00.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[1].Nome))
                    Adicional_01.Text = MeuEstabelecimento.Sabores_Sorvete[1].Nome;
                else
                    Adicional_01.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[2].Nome))
                    Adicional_02.Text = MeuEstabelecimento.Sabores_Sorvete[2].Nome;
                else
                    Adicional_02.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[3].Nome))
                    Adicional_03.Text = MeuEstabelecimento.Sabores_Sorvete[3].Nome;
                else
                    Adicional_03.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[4].Nome))
                    Adicional_04.Text = MeuEstabelecimento.Sabores_Sorvete[4].Nome;
                else
                    Adicional_04.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[5].Nome))
                    Adicional_05.Text = MeuEstabelecimento.Sabores_Sorvete[5].Nome;
                else
                    Adicional_05.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[6].Nome))
                    Adicional_06.Text = MeuEstabelecimento.Sabores_Sorvete[6].Nome;
                else
                    Adicional_06.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[7].Nome))
                    Adicional_07.Text = MeuEstabelecimento.Sabores_Sorvete[7].Nome;
                else
                    Adicional_07.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[8].Nome))
                    Adicional_08.Text = MeuEstabelecimento.Sabores_Sorvete[8].Nome;
                else
                    Adicional_08.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[9].Nome))
                    Adicional_09.Text = MeuEstabelecimento.Sabores_Sorvete[9].Nome;
                else
                    Adicional_09.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[10].Nome))
                    Adicional_10.Text = MeuEstabelecimento.Sabores_Sorvete[10].Nome;
                else
                    Adicional_10.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[11].Nome))
                    Adicional_11.Text = MeuEstabelecimento.Sabores_Sorvete[11].Nome;
                else
                    Adicional_11.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[12].Nome))
                    Adicional_12.Text = MeuEstabelecimento.Sabores_Sorvete[12].Nome;
                else
                    Adicional_12.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[13].Nome))
                    Adicional_13.Text = MeuEstabelecimento.Sabores_Sorvete[13].Nome;
                else
                    Adicional_13.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[14].Nome))
                    Adicional_14.Text = MeuEstabelecimento.Sabores_Sorvete[14].Nome;
                else
                    Adicional_14.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[15].Nome))
                    Adicional_15.Text = MeuEstabelecimento.Sabores_Sorvete[15].Nome;
                else
                    Adicional_15.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[16].Nome))
                    Adicional_16.Text = MeuEstabelecimento.Sabores_Sorvete[16].Nome;
                else
                    Adicional_16.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[17].Nome))
                    Adicional_17.Text = MeuEstabelecimento.Sabores_Sorvete[17].Nome;
                else
                    Adicional_17.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[18].Nome))
                    Adicional_18.Text = MeuEstabelecimento.Sabores_Sorvete[18].Nome;
                else
                    Adicional_18.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[19].Nome))                
                    Adicional_19.Text = MeuEstabelecimento.Sabores_Sorvete[19].Nome;                                
                else                
                    Adicional_19.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[20].Nome))
                    Adicional_20.Text = MeuEstabelecimento.Sabores_Sorvete[20].Nome;
                else
                    Adicional_20.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[21].Nome))
                    Adicional_21.Text = MeuEstabelecimento.Sabores_Sorvete[21].Nome;
                else
                    Adicional_21.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[22].Nome))
                    Adicional_22.Text = MeuEstabelecimento.Sabores_Sorvete[22].Nome;
                else
                    Adicional_22.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[23].Nome))
                    Adicional_23.Text = MeuEstabelecimento.Sabores_Sorvete[23].Nome;
                else
                    Adicional_23.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[24].Nome))
                    Adicional_24.Text = MeuEstabelecimento.Sabores_Sorvete[24].Nome;
                else
                    Adicional_24.IsVisible = false;

            }
            else if(MeusPedido.Tipo == "Picolé")
            {
                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[0].Nome))
                    Adicional_00.Text = MeuEstabelecimento.Sabores_Picole[0].Nome;
                else
                    Adicional_00.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[1].Nome))
                    Adicional_01.Text = MeuEstabelecimento.Sabores_Picole[1].Nome;
                else
                    Adicional_01.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[2].Nome))
                    Adicional_02.Text = MeuEstabelecimento.Sabores_Picole[2].Nome;
                else
                    Adicional_02.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[3].Nome))
                    Adicional_03.Text = MeuEstabelecimento.Sabores_Picole[3].Nome;
                else
                    Adicional_03.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[4].Nome))
                    Adicional_04.Text = MeuEstabelecimento.Sabores_Picole[4].Nome;
                else
                    Adicional_04.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[5].Nome))
                    Adicional_05.Text = MeuEstabelecimento.Sabores_Picole[5].Nome;
                else
                    Adicional_05.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[6].Nome))
                    Adicional_06.Text = MeuEstabelecimento.Sabores_Picole[6].Nome;
                else
                    Adicional_06.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[7].Nome))
                    Adicional_07.Text = MeuEstabelecimento.Sabores_Picole[7].Nome;
                else
                    Adicional_07.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[8].Nome))
                    Adicional_08.Text = MeuEstabelecimento.Sabores_Picole[8].Nome;
                else
                    Adicional_08.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[9].Nome))
                    Adicional_09.Text = MeuEstabelecimento.Sabores_Picole[9].Nome;
                else
                    Adicional_09.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[10].Nome))
                    Adicional_10.Text = MeuEstabelecimento.Sabores_Picole[10].Nome;
                else
                    Adicional_10.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[11].Nome))
                    Adicional_11.Text = MeuEstabelecimento.Sabores_Picole[11].Nome;
                else
                    Adicional_11.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[12].Nome))
                    Adicional_12.Text = MeuEstabelecimento.Sabores_Picole[12].Nome;
                else
                    Adicional_12.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[13].Nome))
                    Adicional_13.Text = MeuEstabelecimento.Sabores_Picole[13].Nome;
                else
                    Adicional_13.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[14].Nome))
                    Adicional_14.Text = MeuEstabelecimento.Sabores_Picole[14].Nome;
                else
                    Adicional_14.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[15].Nome))
                    Adicional_15.Text = MeuEstabelecimento.Sabores_Picole[15].Nome;
                else
                    Adicional_15.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[16].Nome))
                    Adicional_16.Text = MeuEstabelecimento.Sabores_Picole[16].Nome;
                else
                    Adicional_16.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[17].Nome))
                    Adicional_17.Text = MeuEstabelecimento.Sabores_Picole[17].Nome;
                else
                    Adicional_17.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[18].Nome))
                    Adicional_18.Text = MeuEstabelecimento.Sabores_Picole[18].Nome;
                else
                    Adicional_18.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[19].Nome))
                    Adicional_19.Text = MeuEstabelecimento.Sabores_Picole[19].Nome;
                else
                    Adicional_19.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[20].Nome))
                    Adicional_20.Text = MeuEstabelecimento.Sabores_Picole[20].Nome;
                else
                    Adicional_20.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[21].Nome))
                    Adicional_21.Text = MeuEstabelecimento.Sabores_Picole[21].Nome;
                else
                    Adicional_21.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[22].Nome))
                    Adicional_22.Text = MeuEstabelecimento.Sabores_Picole[22].Nome;
                else
                    Adicional_22.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[23].Nome))
                    Adicional_23.Text = MeuEstabelecimento.Sabores_Picole[23].Nome;
                else
                    Adicional_23.IsVisible = false;

                if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[24].Nome))
                    Adicional_24.Text = MeuEstabelecimento.Sabores_Picole[24].Nome;
                else
                    Adicional_24.IsVisible = false;
            }
        }
        private void Load_Itens()
        {   
            lbl_Tipo_lanche.Text = "x " + MeusPedido.Tipo + ",";
            lbl_Nome_lanche.Text = MeusPedido.Nome;
            lbl_Descricao.Text = "(" + MeusPedido.Descricao + ")";
            Load_Sabores();
            if (MeusPedido.Tipo == "Sorvete" && MeusPedido.Nome == "Copo")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
            else if(MeusPedido.Tipo == "Sorvete" && MeusPedido.Nome == "Casquinha")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
            else if(MeusPedido.Tipo == "Sorvete" && MeusPedido.Nome == "Sandae")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
            else if(MeusPedido.Tipo == "Sorvete" && MeusPedido.Nome == "Milk Shake")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
            else if (MeusPedido.Tipo == "Sorvete" && MeusPedido.Nome == "Split")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
            else if (MeusPedido.Tipo == "Picolé")
            {
                if (!String.IsNullOrEmpty(MeusPedido.Valor_P))
                {
                    Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);
                }
                else
                {
                    Tipo_P.IsVisible = false;
                }

                if (!String.IsNullOrEmpty(MeusPedido.Valor_B))
                {
                    Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);
                }
                else
                {
                    Tipo_B.IsVisible = false;
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
            }
           
            Application.Current.Properties["_TrocaInfo"] = Lbl_Troca.Text;
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Qt_pedido = e.NewValue;
        }

        private void EnviarPedido(string adicionais, int quantidade)
        {
            App.Meus_Pedidos.Add(new Cardapio()
            {
                Tipo = lbl_Tipo_lanche.Text.Replace("x", " ").Replace(",", ":"),
                Nome = lbl_Nome_lanche.Text + ": " + TipoFrio,
                Descricao = lbl_Descricao.Text,
                Adicionais_itens = adicionais,
                TitleAdcorSab = "Sabores",
                ValorAdicionais = 0,
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
                    TipoFrio = MeusPedido.Valor_P_Title;
                }
                if (Tipo_B.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_B;
                    TipoFrio = MeusPedido.Valor_B_Title;
                }
                if (Tipo_M.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_M;
                    TipoFrio = MeusPedido.Valor_M_Title;
                }
                if (Tipo_G.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_G;
                    TipoFrio = MeusPedido.Valor_G_Title;
                }

                if (Adicional_00.IsChecked == true)
                {
                    Adc_Item_00 = Adicional_00.Text + ", ";
                }
                if (Adicional_01.IsChecked == true)
                {
                    Adc_Item_01 = Adicional_01.Text + ", ";
                }
                if (Adicional_02.IsChecked == true)
                {
                    Adc_Item_02 = Adicional_03.Text + ", ";
                }
                if (Adicional_03.IsChecked == true)
                {
                    Adc_Item_03 = Adicional_03.Text + ", ";
                }
                if (Adicional_04.IsChecked == true)
                {
                    Adc_Item_04 = Adicional_04.Text + ", ";
                }
                if (Adicional_05.IsChecked == true)
                {
                    Adc_Item_05 = Adicional_05.Text + ", ";
                }
                if (Adicional_06.IsChecked == true)
                {
                    Adc_Item_06 = Adicional_06.Text + ", ";
                }
                if (Adicional_07.IsChecked == true)
                {
                    Adc_Item_07 = Adicional_07.Text + ", ";
                }
                if (Adicional_08.IsChecked == true)
                {
                    Adc_Item_08 = Adicional_08.Text + ", ";
                }
                if (Adicional_09.IsChecked == true)
                {
                    Adc_Item_09 = Adicional_09.Text + ", ";
                }
                if (Adicional_10.IsChecked == true)
                {
                    Adc_Item_10 = Adicional_10.Text + ", ";
                }
                if (Adicional_11.IsChecked == true)
                {
                    Adc_Item_11 = Adicional_11.Text + ", ";
                }
                if (Adicional_12.IsChecked == true)
                {
                    Adc_Item_12 = Adicional_12.Text + ", ";
                }
                if (Adicional_13.IsChecked == true)
                {
                    Adc_Item_13 = Adicional_13.Text + ", ";
                }
                if (Adicional_14.IsChecked == true)
                {
                    Adc_Item_14 = Adicional_14.Text + ", ";
                }
                if (Adicional_15.IsChecked == true)
                {
                    Adc_Item_15 = Adicional_15.Text + ", ";
                }
                if (Adicional_16.IsChecked == true)
                {
                    Adc_Item_16 = Adicional_16.Text + ", ";
                }
                if (Adicional_17.IsChecked == true)
                {
                    Adc_Item_17 = Adicional_17.Text + ", ";
                }
                if (Adicional_18.IsChecked == true)
                {
                    Adc_Item_18 = Adicional_18.Text + ", ";
                }
                if (Adicional_19.IsChecked == true)
                {
                    Adc_Item_19 = Adicional_19.Text + ", ";
                }
                if (Adicional_20.IsChecked == true)
                {
                    Adc_Item_20 = Adicional_20.Text + ", ";
                }
                if (Adicional_21.IsChecked == true)
                {
                    Adc_Item_21 = Adicional_21.Text + ", ";
                }
                if (Adicional_22.IsChecked == true)
                {
                    Adc_Item_22 = Adicional_22.Text + ", ";
                }
                if (Adicional_23.IsChecked == true)
                {
                    Adc_Item_23 = Adicional_23.Text + ", ";
                }
                if (Adicional_24.IsChecked == true)
                {
                    Adc_Item_24 = Adicional_24.Text + ", ";
                }

                string MeusAdicionais = Adc_Item_00 + Adc_Item_01 + Adc_Item_02 + Adc_Item_03 + Adc_Item_04 + Adc_Item_05 +
                         Adc_Item_06 + Adc_Item_07 + Adc_Item_08 + Adc_Item_09 + Adc_Item_10 + Adc_Item_11 + Adc_Item_12 +
                         Adc_Item_13 + Adc_Item_14 + Adc_Item_15 + Adc_Item_16 + Adc_Item_17 + Adc_Item_18 + Adc_Item_19 +
                         Adc_Item_20 + Adc_Item_21 + Adc_Item_22 + Adc_Item_23 + Adc_Item_24 + Adc_Item_25;

                double valorunit = 0.00;

                int Qt_item = Convert.ToInt32(Qt_Pedido.Text);

                valorunit = Convert.ToDouble(MeusPedido.Valor_RB);
                CalculoValorxQtd = Qt_item * valorunit;
                EnviarPedido(MeusAdicionais, Qt_item);
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
                //            Nome = lbl_Nome_lanche.Text + ": " + TipoFrio,
                //            Descricao = lbl_Descricao.Text,
                //            Adicionais_itens = MeusAdicionais,
                //            ValorAdicionais = 0,
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