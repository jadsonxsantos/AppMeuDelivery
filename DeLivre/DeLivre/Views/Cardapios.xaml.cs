using DeLivre.Models;
using DeLivre.Views.Detalhe;
using Rg.Plugins.Popup.Services;
using System;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cardapios : TabbedPage
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
            InfoEstabelecimento();
            CarregarCardapio();
            DestacarDia();           
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

            foreach (var item in MeuEstabelecimento.Horarios_Funcionamento)
            {
                lbl_Segunda.Text = "SEGUNDA-FEIRA: " + item.Segunda_Feira;
                lbl_Terca.Text = "TERÇA-FEIRA: " + item.Terca_Feira;
                lbl_Quarta.Text = "QUARTA-FEIRA: " + item.Quarta_Feira;
                lbl_Quinta.Text = "QUINTA-FEIRA: " + item.Quinta_Feira;
                lbl_Sexta.Text = "SEXTA-FEIRA: " + item.Sexta_Feira;
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

        private void DestacarDia()
        {
            DateTime aDate = DateTime.Now;
            DateTime dateValue;

            dateValue = DateTime.Parse(aDate.ToString("MM/dd/yyyy"), CultureInfo.InvariantCulture);
            string dia = dateValue.ToString("dddd", new CultureInfo("pt-BR"));

            if (dia == "segunda-feira")
            {
                lbl_Segunda.FontAttributes = FontAttributes.Bold;
                lbl_Segunda.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "terça-feira")
            {
                lbl_Terca.FontAttributes = FontAttributes.Bold;
                lbl_Terca.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "quarta-feira")
            {
                lbl_Quarta.FontAttributes = FontAttributes.Bold;
                lbl_Quarta.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "quinta-feira")
            {
                lbl_Quinta.FontAttributes = FontAttributes.Bold;
                lbl_Quinta.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "sexta-feira")
            {
                lbl_Sexta.FontAttributes = FontAttributes.Bold;
                lbl_Sexta.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "sábado")
            {
                lbl_Sabado.FontAttributes = FontAttributes.Bold;
                lbl_Sabado.TextColor = Color.FromHex("#EF5350");
            }
            else if (dia == "domingo")
            {
                lbl_Domingo.FontAttributes = FontAttributes.Bold;
                lbl_Domingo.TextColor = Color.FromHex("#EF5350");
            }
        }

        private void Btn_instagram_Clicked(object sender, EventArgs e)
        {    
            foreach (var item in MeuEstabelecimento.Redes_Sociais)
            {
                Device.OpenUri(new Uri(item.Instagram));
            }
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
                        if (item.Tipo == "Sorvete" || item.Tipo == "Picolé" || item.Tipo == "Paletas")
                        {
                            var page = new Detalhe.Frios(item, MeuEstabelecimento);
                            await PopupNavigation.Instance.PushAsync(page);
                        }
                        else
                        {
                            var page = new Detalhe.Detalhe(item, MeuEstabelecimento);
                            await PopupNavigation.Instance.PushAsync(page);
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
      
        private async void Compartilhar_Tapped(object sender, EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            { 
                Text = @"Olha o que encontrei no AppMeuDelivery: *" + MeuEstabelecimento.Nome +
@"* 
Quer agilizar sua entrega? baixe nosso app!
https://play.google.com/store/apps/details?id=com.lurasoft.AppMeuDelivery",
                Title = MeuEstabelecimento.Nome
            });
        }
    }
}