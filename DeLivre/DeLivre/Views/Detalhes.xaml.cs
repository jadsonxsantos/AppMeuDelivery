using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
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
	public partial class Detalhes : PopupPage
	{
        ObservableCollection<Cardapio> MeuPedido;
        ObservableCollection<Cardapio> ListaPedido = new ObservableCollection<Cardapio>();
        double Qt_pedido, result = 0.00;
        public Detalhes (ObservableCollection<Cardapio> pedido)
		{
			InitializeComponent ();
            MeuPedido = pedido;
            Load_Itens();
        }

        private void Load_Itens()
        {
            foreach (var item in MeuPedido)
            {
                lbl_Tipo_lanche.Text = "x " + item.Tipo + ",";
                lbl_Nome_lanche.Text = item.Nome;                
                lbl_Descricao.Text = "(" + item.Descricao + ")";  
                lbl_Valor.Text = item.Valor;
            }
        }

        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Qt_pedido = e.NewValue;
        }

        private async void Btn_selecionar_Clicked(object sender, EventArgs e)
        {
          
            var filtrados = new ObservableCollection<Cardapio>();
            double valorunit = 0.00;
            int Qt_item = Convert.ToInt32(Qt_Pedido.Text);
            Cardapio card = new Cardapio();
           
          
            MessagingCenter.Subscribe<Detalhes>(this, "AlterarTextoLabel", (sdn) =>
            {
                foreach (var item in MeuPedido)
                {
                    valorunit = Convert.ToDouble(item.Valor);
                    result = Qt_item * valorunit;

                    card.Nome = lbl_Nome_lanche.Text;

                    //filtrados.Add(new Cardapio { Nome = lbl_Nome_lanche.Text, Tipo = lbl_Tipo_lanche.Text, Descricao = lbl_Descricao.Text, Valor = lbl_Valor.Text, ValorTotal = result.ToString(), Quantidade = Qt_item, });
                }
            });           
            await Navigation.PushAsync(new Pedido());
        }
    }
}