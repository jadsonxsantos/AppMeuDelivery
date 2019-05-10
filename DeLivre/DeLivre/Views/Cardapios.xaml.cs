﻿using DeLivre.Models;
using DeLivre.Views.Detalhe;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cardapios : ContentPage
    {
        ObservableCollection<Cardapio> ListaPedido = new ObservableCollection<Cardapio>();
        Estabelecimento MeuEstabelecimento;
        List<Cardapio> MeusCadapios;           

        public Cardapios(Estabelecimento MeusEstabelecimentos)
        {
            InitializeComponent();          
            MeuEstabelecimento = new Estabelecimento();
            MeuEstabelecimento = MeusEstabelecimentos;
            MeusCadapios = new List<Cardapio>();
            MeusCadapios = MeusEstabelecimentos.Cardapios;
            Title = MeuEstabelecimento.Nome;
            DadosEstabelecimentos();
            ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios;                  
        }

        private void  DadosEstabelecimentos()
        {
            //Armaenando o valor do Frete!    
            string ValorFrete = MeuEstabelecimento.Frete;
            Application.Current.Properties["_Frete"] = ValorFrete;
            //Armaenando o Numero do Whatsapp!
            Application.Current.Properties["_Whatsapp"] = MeuEstabelecimento.Whatsapp;
            //Armaenando o Numero do Whatsapp!
            Application.Current.Properties["_Estabelecimento_"] = MeuEstabelecimento.Nome;
            Application.Current.Properties["_JurosCartao"] = MeuEstabelecimento.Juros_Cartao;
        }
        
        private async void ListaCardapio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            #region DisabledSelectionHighlighting
            ((ListView)sender).SelectedItem = null;
            #endregion
            try
            {
                if (e.SelectedItem != null)
                {
                    Cardapio item = (Cardapio)e.SelectedItem;
                    var selection = e.SelectedItem as ObservableCollection<Cardapio>;
                    Estabelecimento estab = new Estabelecimento();

                    if (item != null)
                    {
                        if (item.Tipo == "Pizza" || item.Tipo == "Pizza Doce" || item.Tipo == "Lazanha")
                        {
                            var page = new Detalhe.Pizza(item);
                            await PopupNavigation.Instance.PushAsync(page);
                        }
                        else
                        {
                            if (item.Tipo == "Refrigerante" || item.Tipo == "Suco")
                            {
                                var page = new Detalhe.Refrigerante(item);
                                await PopupNavigation.Instance.PushAsync(page);
                            }
                            else
                            {
                                if (item.Tipo == "Sorvete" || item.Tipo == "Picolé")
                                {
                                    var page = new Detalhe.Frios(item, MeuEstabelecimento);
                                    await PopupNavigation.Instance.PushAsync(page);
                                }
                                else
                                {
                                    if (item.Tipo == "Açaí" || item.Tipo == "Açaí Copo" || item.Tipo == "Barca")
                                    {
                                        var page = new Detalhe.AcaiNormal(item, MeuEstabelecimento);
                                        await PopupNavigation.Instance.PushAsync(page);
                                    }
                                    else
                                    {
                                        if (item.Tipo == "Doces")
                                        {
                                            var pageDoces = new Detalhe.Doces(item);
                                            await PopupNavigation.Instance.PushAsync(pageDoces);
                                        }
                                        else
                                        {
                                            var page = new Detalhes(item);
                                            await PopupNavigation.Instance.PushAsync(page);
                                        }                                       
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Ops!", "Este item esta em atualização! em breve estará disponível!", "OK");
            }           
        }

        private void CardapioPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaCardapio.BeginRefresh();
            var texto = CardapioPesquisa.Text;

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios;
            else
                ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios.Where(x => x.Tipo.ToLower().Contains(texto.ToLower()));

            ListaCardapio.EndRefresh();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Meus_Pedidos.Clear();
            return base.OnBackButtonPressed();           
        }

        private async void OnInformacoes_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Info(MeuEstabelecimento));       
        }

        private async void OnCarrinho_Clicked(object sender, EventArgs e)
        {
            if(App.Meus_Pedidos.Count > 0)
            {
                await Navigation.PushAsync(new Pedido(App.Meus_Pedidos));               
            }
            else
            {
                await DisplayAlert("Carrinho vazio!", "Você não tem nenhum pedido no carrinho!", "OK");
            }                     
        }
    }
}