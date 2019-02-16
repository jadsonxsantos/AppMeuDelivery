using DeLivre.Models;
using Rg.Plugins.Popup.Services;
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
	public partial class Cardapios : ContentPage
    {
        ObservableCollection<Cardapio> ListaPedido = new ObservableCollection<Cardapio>();
        Estabelecimento MeuEstabelecimento;
        List<Cardapio> MeusCadapios;
        string Testes;

        public Cardapios(Estabelecimento MeusEstabelecimentos)
        {
            InitializeComponent();          
            MeuEstabelecimento = new Estabelecimento();
            MeuEstabelecimento = MeusEstabelecimentos;
            MeusCadapios = new List<Cardapio>();
            MeusCadapios = MeusEstabelecimentos.Cardapios;           
            DadosEstabelecimentos();
            ListaCardapio.ItemsSource = MeuEstabelecimento.Cardapios;   
        }

        private void  DadosEstabelecimentos()
        {           
            Title = MeuEstabelecimento.Nome;
            Testes = MeuEstabelecimento.Cardapios.ToString();         
            ImagemEstab.Source = MeuEstabelecimento.Logo;
            lbl_Horario_Funcionamento.Text = MeuEstabelecimento.Horario_Funcionamento;
            lbl_Local.Text = MeuEstabelecimento.Local;
            lbl_Frete.Text = MeuEstabelecimento.Frete;
            lbl_Tempo.Text = MeuEstabelecimento.Entrega_;
            lbl_Descricao.Text = MeuEstabelecimento.Descricao;        
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
              
                if(item != null)
                {
                    ListaPedido.Add(item);
                    //await Navigation.PushAsync(new Pedido(ListaPedido));            
                    var page = new Detalhes(ListaPedido);

                    await PopupNavigation.Instance.PushAsync(page);
                }                                                                                                                                                    
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

        private async void MenuItem1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pedido(/*ListaPedido*/));
        }
       
    }
}