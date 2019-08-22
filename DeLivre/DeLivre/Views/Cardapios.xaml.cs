using DeLivre.Models;
using DeLivre.Views.Detalhe;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections;
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
        List<Cardapio> ListaPi = new List<Cardapio>();
        Estabelecimento MeuEstabelecimento;
        List<Cardapio> MeuCardapio;

        public Cardapios(Estabelecimento MeusEstabelecimentos)
        {
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();  
            MeuEstabelecimento = MeusEstabelecimentos;             
            MeuCardapio = MeusEstabelecimentos.Cardapios;
            BindingContext = MeuEstabelecimento;            
            TipoDrop.ItemsSource = MeuCardapio.Select(x => x.Tipo).Distinct().ToList();
            var ListaPis = MeuCardapio.Select(x => x.Nome).ToList();
            InfoEstabelecimento();
            CarregarCardapio();
            
        }
        private void CarregarCardapio()
        {
            ListaCardapio.BeginRefresh();
            ListaCardapio.ItemsSource = MeuCardapio;
            ListaCardapio.EndRefresh();
        }

        private void InfoEstabelecimento()
        {           
            //Armaenando o valor do Frete!    
            string ValorFrete = MeuEstabelecimento.Frete;
            Application.Current.Properties["_Frete"] = ValorFrete;
            //Armaenando o Numero do Whatsapp!
            Application.Current.Properties["_Whatsapp"] = MeuEstabelecimento.Whatsapp;
            //Nome do Estabelecimento
            Application.Current.Properties["_Estabelecimento_"] = MeuEstabelecimento.Nome;
            //Verifica se aceita cartão de credito
            Application.Current.Properties["_AceitaCartao"] = MeuEstabelecimento.Cartao_Credito;
            //Juros do Cartão caso aceite
            Application.Current.Properties["_JurosCartao"] = MeuEstabelecimento.Juros_Cartao;
            //Valor do Pedido Minimo 
            Application.Current.Properties["_PedidoMinimo"] = MeuEstabelecimento.Pedido_Minimo;
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
                        if (item.Tipo.Contains("Pizza") || item.Tipo == "Pizza Doce" || item.Tipo == "Lazanha" || item.Tipo == "Porções")
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
                                if (item.Tipo == "Sorvete" || item.Tipo == "Picolé" || item.Tipo == "Paletas")
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
                                            var page = new Detalhes(item, MeuEstabelecimento);
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
            //ListaCardapio.BeginRefresh();
            //var texto = CardapioPesquisa.Text;

            //if (string.IsNullOrWhiteSpace(e.NewTextValue))
            //    ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios;
            //else
            //    ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios.Where(x => x.Nome.ToLower().Contains(texto.ToLower()));

            //ListaCardapio.EndRefresh();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Meus_Pedidos.Clear();
            return base.OnBackButtonPressed();           
        }

        private async void OnInformacoes_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new Views.More.Info(MeuEstabelecimento));                  
        }

        private async void OnCarrinho_Clicked(object sender, EventArgs e)
        {        
            if (MeuEstabelecimento.Horario_Funcionamento != "Fechado")
            {
                if (App.Meus_Pedidos.Count > 0)
                {
                    await Navigation.PushAsync(new Pedido(App.Meus_Pedidos));
                }
                else
                {
                    await DisplayAlert("Carrinho vazio!", "Você não tem nenhum pedido no carrinho!", "OK");
                }

            }
            else
            {
                await DisplayAlert("Estamos Fechado!", "Verifique nossos horários de funcionamento e tente mais tarde!", "OK");
            }                         
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.More.Info(MeuEstabelecimento));           
        }

        private void TipoDrop_SelectedItemChanged(object sender, Plugin.InputKit.Shared.Utils.SelectedItemChangedArgs e)
        {
            //ListaCardapio.ScrollTo(((IList)ListaCardapio.ItemsSource)[0], ScrollToPosition.Start, false);
            ListaCardapio.BeginRefresh();       
            ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios.Where(x => x.Tipo.ToLower().Contains(TipoDrop.Text.ToLower()));                      
            ListaCardapio.EndRefresh();
            //ListaCardapio.ScrollTo(((IList)ListaCardapio.ItemsSource)[0], ScrollToPosition.Start, false);
        }

        private async void ListaCardapio_Refreshing(object sender, EventArgs e)
        {
            try
            {
                CarregarCardapio();
            }
            catch
            {
                await DisplayAlert("Verifique sua conexão", "Por favor verifique sua conexão e tente novamente mais tarde", "OK");
            }
            finally
            {
                ListaCardapio.EndRefresh();
            }
        }
    }
}