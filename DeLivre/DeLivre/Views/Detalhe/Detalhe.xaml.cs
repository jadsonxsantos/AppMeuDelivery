using DeLivre.Components;
using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.Detalhe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalhe : PopupPage
    {
        Cardapio MeusPedido;
        Estabelecimento MeuEstabelecimento;
        double Qt_pedido, CalculoValorxQtd = 0.00;
        string TipoFrio;
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


        List<string> ListaAdicionais = new List<string>();
        public Detalhe(Cardapio pedido, Estabelecimento estabelecimento)
        {
			InitializeComponent ();
            MeusPedido = pedido;
            MeuEstabelecimento = estabelecimento;
            Load_Itens();         
        }

        //private void Load_Sabores()
        //{
        //    if (MeuEstabelecimento.Sabores_Sorvete == null)
        //    {              
        //        lbl_Sabor.IsVisible = false;
        //        Stack_Sabor.IsVisible = false;
        //    }
        //    else if (MeusPedido.Tipo == "Sorvete")
        //    {
        //        lbl_Adicionais.IsVisible = false;
        //        Stack_Adicionais.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[0].Nome))
        //            Sabor_00.Text = MeuEstabelecimento.Sabores_Sorvete[0].Nome;
        //        else
        //            Sabor_00.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[1].Nome))
        //            Sabor_01.Text = MeuEstabelecimento.Sabores_Sorvete[1].Nome;
        //        else
        //            Sabor_01.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[2].Nome))
        //            Sabor_02.Text = MeuEstabelecimento.Sabores_Sorvete[2].Nome;
        //        else
        //            Sabor_02.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[3].Nome))
        //            Sabor_03.Text = MeuEstabelecimento.Sabores_Sorvete[3].Nome;
        //        else
        //            Sabor_03.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[4].Nome))
        //            Sabor_04.Text = MeuEstabelecimento.Sabores_Sorvete[4].Nome;
        //        else
        //            Sabor_04.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[5].Nome))
        //            Sabor_05.Text = MeuEstabelecimento.Sabores_Sorvete[5].Nome;
        //        else
        //            Sabor_05.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[6].Nome))
        //            Sabor_06.Text = MeuEstabelecimento.Sabores_Sorvete[6].Nome;
        //        else
        //            Sabor_06.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[7].Nome))
        //            Sabor_07.Text = MeuEstabelecimento.Sabores_Sorvete[7].Nome;
        //        else
        //            Sabor_07.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[8].Nome))
        //            Sabor_08.Text = MeuEstabelecimento.Sabores_Sorvete[8].Nome;
        //        else
        //            Sabor_08.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[9].Nome))
        //            Sabor_09.Text = MeuEstabelecimento.Sabores_Sorvete[9].Nome;
        //        else
        //            Sabor_09.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[10].Nome))
        //            Sabor_10.Text = MeuEstabelecimento.Sabores_Sorvete[10].Nome;
        //        else
        //            Sabor_10.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[11].Nome))
        //            Sabor_11.Text = MeuEstabelecimento.Sabores_Sorvete[11].Nome;
        //        else
        //            Sabor_11.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[12].Nome))
        //            Sabor_12.Text = MeuEstabelecimento.Sabores_Sorvete[12].Nome;
        //        else
        //            Sabor_12.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[13].Nome))
        //            Sabor_13.Text = MeuEstabelecimento.Sabores_Sorvete[13].Nome;
        //        else
        //            Sabor_13.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[14].Nome))
        //            Sabor_14.Text = MeuEstabelecimento.Sabores_Sorvete[14].Nome;
        //        else
        //            Sabor_14.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[15].Nome))
        //            Sabor_15.Text = MeuEstabelecimento.Sabores_Sorvete[15].Nome;
        //        else
        //            Sabor_15.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[16].Nome))
        //            Sabor_16.Text = MeuEstabelecimento.Sabores_Sorvete[16].Nome;
        //        else
        //            Sabor_16.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[17].Nome))
        //            Sabor_17.Text = MeuEstabelecimento.Sabores_Sorvete[17].Nome;
        //        else
        //            Sabor_17.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[18].Nome))
        //            Sabor_18.Text = MeuEstabelecimento.Sabores_Sorvete[18].Nome;
        //        else
        //            Sabor_18.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[19].Nome))
        //            Sabor_19.Text = MeuEstabelecimento.Sabores_Sorvete[19].Nome;
        //        else
        //            Sabor_19.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[20].Nome))
        //            Sabor_20.Text = MeuEstabelecimento.Sabores_Sorvete[20].Nome;
        //        else
        //            Sabor_20.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[21].Nome))
        //            Sabor_21.Text = MeuEstabelecimento.Sabores_Sorvete[21].Nome;
        //        else
        //            Sabor_21.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[22].Nome))
        //            Sabor_22.Text = MeuEstabelecimento.Sabores_Sorvete[22].Nome;
        //        else
        //            Sabor_22.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[23].Nome))
        //            Sabor_23.Text = MeuEstabelecimento.Sabores_Sorvete[23].Nome;
        //        else
        //            Sabor_23.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Sorvete[24].Nome))
        //            Sabor_24.Text = MeuEstabelecimento.Sabores_Sorvete[24].Nome;
        //        else
        //            Sabor_24.IsVisible = false;

        //    }

        //    if (MeuEstabelecimento.Sabores_Picole == null)
        //    {
        //        lbl_Sabor.IsVisible = false;
        //        Stack_Sabor.IsVisible = false;
        //    }
        //    else if (MeusPedido.Tipo == "Picolé")
        //    {
        //        lbl_Adicionais.IsVisible = false;
        //        Stack_Adicionais.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[0].Nome))
        //            Sabor_00.Text = MeuEstabelecimento.Sabores_Picole[0].Nome;
        //        else
        //            Sabor_00.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[1].Nome))
        //            Sabor_01.Text = MeuEstabelecimento.Sabores_Picole[1].Nome;
        //        else
        //            Sabor_01.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[2].Nome))
        //            Sabor_02.Text = MeuEstabelecimento.Sabores_Picole[2].Nome;
        //        else
        //            Sabor_02.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[3].Nome))
        //            Sabor_03.Text = MeuEstabelecimento.Sabores_Picole[3].Nome;
        //        else
        //            Sabor_03.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[4].Nome))
        //            Sabor_04.Text = MeuEstabelecimento.Sabores_Picole[4].Nome;
        //        else
        //            Sabor_04.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[5].Nome))
        //            Sabor_05.Text = MeuEstabelecimento.Sabores_Picole[5].Nome;
        //        else
        //            Sabor_05.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[6].Nome))
        //            Sabor_06.Text = MeuEstabelecimento.Sabores_Picole[6].Nome;
        //        else
        //            Sabor_06.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[7].Nome))
        //            Sabor_07.Text = MeuEstabelecimento.Sabores_Picole[7].Nome;
        //        else
        //            Sabor_07.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[8].Nome))
        //            Sabor_08.Text = MeuEstabelecimento.Sabores_Picole[8].Nome;
        //        else
        //            Sabor_08.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[9].Nome))
        //            Sabor_09.Text = MeuEstabelecimento.Sabores_Picole[9].Nome;
        //        else
        //            Sabor_09.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[10].Nome))
        //            Sabor_10.Text = MeuEstabelecimento.Sabores_Picole[10].Nome;
        //        else
        //            Sabor_10.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[11].Nome))
        //            Sabor_11.Text = MeuEstabelecimento.Sabores_Picole[11].Nome;
        //        else
        //            Sabor_11.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[12].Nome))
        //            Sabor_12.Text = MeuEstabelecimento.Sabores_Picole[12].Nome;
        //        else
        //            Sabor_12.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[13].Nome))
        //            Sabor_13.Text = MeuEstabelecimento.Sabores_Picole[13].Nome;
        //        else
        //            Sabor_13.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[14].Nome))
        //            Sabor_14.Text = MeuEstabelecimento.Sabores_Picole[14].Nome;
        //        else
        //            Sabor_14.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[15].Nome))
        //            Sabor_15.Text = MeuEstabelecimento.Sabores_Picole[15].Nome;
        //        else
        //            Sabor_15.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[16].Nome))
        //            Sabor_16.Text = MeuEstabelecimento.Sabores_Picole[16].Nome;
        //        else
        //            Sabor_16.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[17].Nome))
        //            Sabor_17.Text = MeuEstabelecimento.Sabores_Picole[17].Nome;
        //        else
        //            Sabor_17.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[18].Nome))
        //            Sabor_18.Text = MeuEstabelecimento.Sabores_Picole[18].Nome;
        //        else
        //            Sabor_18.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[19].Nome))
        //            Sabor_19.Text = MeuEstabelecimento.Sabores_Picole[19].Nome;
        //        else
        //            Sabor_19.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[20].Nome))
        //            Sabor_20.Text = MeuEstabelecimento.Sabores_Picole[20].Nome;
        //        else
        //            Sabor_20.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[21].Nome))
        //            Sabor_21.Text = MeuEstabelecimento.Sabores_Picole[21].Nome;
        //        else
        //            Sabor_21.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[22].Nome))
        //            Sabor_22.Text = MeuEstabelecimento.Sabores_Picole[22].Nome;
        //        else
        //            Sabor_22.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[23].Nome))
        //            Sabor_23.Text = MeuEstabelecimento.Sabores_Picole[23].Nome;
        //        else
        //            Sabor_23.IsVisible = false;

        //        if (!String.IsNullOrEmpty(MeuEstabelecimento.Sabores_Picole[24].Nome))
        //            Sabor_24.Text = MeuEstabelecimento.Sabores_Picole[24].Nome;
        //        else
        //            Sabor_24.IsVisible = false;

        //    }
        //}

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
            //Load_Sabores();
            Carregar_Adicionais();
            if(String.IsNullOrEmpty(MeusPedido.Valor_P))
                Tipo_P.Text = String.Format("R$ {0:C} - Unit.", MeusPedido.Valor);

            if (!String.IsNullOrEmpty(MeusPedido.Valor_P))            
                Tipo_P.Text = String.Format(MeusPedido.Valor_P_Title + " - R$ {0:C}", MeusPedido.Valor_P);            
            else            
                Tipo_P.IsVisible = false;            

            if (!String.IsNullOrEmpty(MeusPedido.Valor_B))            
                Tipo_B.Text = String.Format(MeusPedido.Valor_B_Title + " - R$ {0:C}", MeusPedido.Valor_B);            
            else            
                Tipo_B.IsVisible = false;            

            if (!String.IsNullOrEmpty(MeusPedido.Valor_M))            
                Tipo_M.Text = String.Format(MeusPedido.Valor_M_Title + " - R$ {0:C}", MeusPedido.Valor_M);            
            else            
                Tipo_M.IsVisible = false;            

            if (!String.IsNullOrEmpty(MeusPedido.Valor_G))            
                Tipo_G.Text = String.Format(MeusPedido.Valor_G_Title + " - R$ {0:C}", MeusPedido.Valor_G);            
            else            
                Tipo_G.IsVisible = false;

            if (!String.IsNullOrEmpty(MeusPedido.Valor_GG))
                Tipo_GG.Text = String.Format(MeusPedido.Valor_GG_Title + " - R$ {0:C}", MeusPedido.Valor_GG);
            else
                Tipo_GG.IsVisible = false; 

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
                if (Tipo_GG.IsChecked == true)
                {
                    MeusPedido.Valor_RB = MeusPedido.Valor_GG;
                    TipoFrio = MeusPedido.Valor_GG_Title;
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
                        Adc_Item_20 + Adc_Item_21 + Adc_Item_22 + Adc_Item_23 + Adc_Item_24;

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