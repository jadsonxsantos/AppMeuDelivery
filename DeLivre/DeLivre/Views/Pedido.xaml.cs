using DeLivre.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedido : TabbedPage
    {
        public List<Cardapio> Cardapios { get; set; }
        ObservableCollection<Cardapio> MeuPedido;
        public ObservableCollection<string> Events { get; set; } = new ObservableCollection<string>();
        double Valor_Frete, Valor_Pedido, Valor_Total, ValorUnitario, Qt_Pedido;
        
        public Pedido(/*ObservableCollection<Cardapio> pedido*/)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            //MeuPedido = pedido;                
            ListaCardapio.ItemsSource = Events;                     
            ////Whatsapp = estabinfo.Whatsapp;
            ////Frete = estabinfo.Frete;
            Load_Valores();
            //VerificarIdentidade();
            //MeuPedido.Quantidade = stepper.Value.ToString();  
          
            //this.MeuPedido.CollectionChanged += this.OnCollectionChanged;

        }      

        private void Load_Valores()
        {
            MessagingCenter.Subscribe<Pedido>(this, "AlterarTextoLabel", (a) => {
                Events.Add($"Received message at {a.ToString()}");
            });
            //Pegando o Valor do Frete e atribuindo ao label
            ////Valor_Frete = ;
            //lbl_Entrega.Text = "Taxa de entrega: " + Frete.ToString();
            //Calculando o Valor de cada Pedido!
            //Valor_Pedido = MeuPedido.Select(x => Convert.ToDouble(x.ValorTotal)).Sum();
            //Valor_Pedido = Convert.ToDouble(Valor_Pedido.ToString());
            //lbl_Total_Pedido.Text = "Total do Pedido:" + Valor_Pedido;
            //Calculando o Valor Total do Pedido + Frete + Quantidade
            //Valor_Total = MeuPedido.Select(x => Convert.ToDouble(x.ValorTotal /*+ Valor_Frete*/)).Sum();
            //Valor_Total = Convert.ToDouble(Valor_Total.ToString());
            //lbl_Valor_Total.Text = String.Format("R$ {0}", Valor_Total.ToString());
        }
     
        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        { 
            //Qt_Pedido = e.NewValue;
            //double soma = 0.00;
            //foreach (var item in MeuPedido)
            //{
            //    double valorunit = Convert.ToDouble(item.Valor);

            //    soma = valorunit * Qt_Pedido;
            //    item.ValorTotal = soma.ToString();
            //}


            //_displayLabel.Text = string.Format("The Stepper value is {0}", value);

            //Cardap.Quantidade = (int)e.NewValue;
            //ValorUnitario = Convert.ToDouble(Cardap.Valor);
            //QtPedidos = Convert.ToInt32(Cardap.Quantidade);
            //ValorTotal = ValorUnitario * QtPedidos;
            //Cardap.ValorTotal = ValorTotal.ToString();
            //Debug.WriteLine(e.NewValue);

            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quantidade"));
        }

        private void ListaCardapio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            #region DisabledSelectionHighlighting
            ((ListView)sender).SelectedItem = null;
            #endregion
        }


        private async void Finalizar_Pedido_Clicked(object sender, EventArgs e)
        {
            //CurrentPage = DadosPessoais;
            //var page = new Detalhes();

            //await PopupNavigation.Instance.PushAsync(page);
        }

        #region ConfirmarIdentidade


        private void VerificarIdentidade()
        {
            if (Application.Current.Properties.ContainsKey("_Nome"))
            {
                EntNome.Text = Application.Current.Properties["_Nome"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_Sobrenome"))
            {
                EntSobrenome.Text = Application.Current.Properties["_Sobrenome"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_Endereco"))
            {
                EntEndereco.Text = Application.Current.Properties["_Endereco"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_Numero"))
            {
                EntNumero.Text = Application.Current.Properties["_Numero"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_Cidade"))
            {
                EntCidade.Text = Application.Current.Properties["_Cidade"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_Bairro"))
            {
                EntBairro.Text = Application.Current.Properties["_Bairro"] as string;
            }
        }

        private void SalvarDados()
        {
            Application.Current.Properties["_Nome"] = EntNome.Text;
            Application.Current.Properties["_Sobrenome"] = EntSobrenome.Text;
            Application.Current.Properties["_Endereco"] = EntEndereco.Text;
            Application.Current.Properties["_Numero"] = EntNumero.Text;
            Application.Current.Properties["_Cidade"] = EntCidade.Text;
            Application.Current.Properties["_Bairro"] = EntBairro.Text;
        }       

        private void SalvareEnviar_Clicked(object sender, EventArgs e)
        {
            SalvarDados();
            //DisplayAlert("Dados Salvos", "Já vamos Enviar seu pedido para o Estabelecimento!", "OK");
            string Teste = Application.Current.Properties["_Nome"] as string;
            string teste3 = EntSobrenome.Text = Application.Current.Properties["_Sobrenome"] as string;
            string Pedido = Teste + "%20" + teste3;
            Device.OpenUri(new Uri("https://wa.me/"+"5579998682289"+"?text="+ Pedido));


        }

        #endregion

    }
}