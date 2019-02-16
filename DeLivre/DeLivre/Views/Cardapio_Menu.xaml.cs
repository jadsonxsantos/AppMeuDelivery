using DeLivre.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cardapio_Menu : ContentPage
	{
        ObservableCollection<Cardapio> ListaPedido = new ObservableCollection<Cardapio>();
        Estabelecimento Estabeleciment;
        List<Cardapio> cardapi;
        string Testes;

        public Cardapio_Menu(Estabelecimento estab)
		{
			InitializeComponent ();

            Estabeleciment = new Estabelecimento();
            Estabeleciment = estab;
            cardapi = new List<Cardapio>();
            cardapi = estab.Cardapios;
            Title = Estabeleciment.Nome;
            Testes = Estabeleciment.Cardapios.ToString();
            DadosEstabelecimentos();
            ListaCardapio.ItemsSource = Estabeleciment.Cardapios;
            MainScroll.ParallaxView = HeaderView;
        }

        private void DadosEstabelecimentos()
        {
            ImagemEstab.Source = Estabeleciment.Logo;
            EstabFuncionamento.Text = Estabeleciment.Horario_Funcionamento;
            EstabLocal.Text = Estabeleciment.Local;
            EstabFrete.Text = Estabeleciment.Frete;
            EstabEntrega.Text = Estabeleciment.Entrega_;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnAppearing();
        }

        private async void ListaCardapio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            #region DisabledSelectionHighlighting
            ((ListView)sender).SelectedItem = null;
            #endregion
            if (e.SelectedItem != null)
            {
                Cardapio item = (Cardapio)e.SelectedItem;
                var selection = e.SelectedItem as ObservableCollection<Cardapio>;

                if (item != null)
                {
                    ListaPedido.Add(item);
                    //await Navigation.PushAsync(new Pedido(ListaPedido));
                }
            }
        }

        private void CardapioPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListaCardapio.BeginRefresh();
            var texto = CardapioPesquisa.Text;

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ListaCardapio.ItemsSource = Estabeleciment.Cardapios;
            else
                ListaCardapio.ItemsSource = Estabeleciment.Cardapios.Where(x => x.Nome.ToLower().Contains(texto.ToLower()));

            ListaCardapio.EndRefresh();

        }

        private async void MenuItem1_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Page1());
        }
    }
}