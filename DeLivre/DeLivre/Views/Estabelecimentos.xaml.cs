using DeLivre.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Estabelecimentos : ContentPage
    {
        string Local_Name;
       
        // Request do JSON 
        private HttpClient _client = new HttpClient();
        ObservableCollection<Estabelecimento> Estabelecimento;
        string Url_Api;
        public Estabelecimentos(string Estab_)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Local_Name = Estab_;
            GetListEstab();
            VerificarUsuario();
        }      

        protected async void GetListEstab()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {                  
                    Url_Api = "https://meudelivery-47bcc.firebaseio.com/.json";
                    //Indicador Ativo
                    activity_indicator.IsRunning = true;
                    //Pegando os dados JSON da Web
                    HttpResponseMessage response = await _client.GetAsync(Url_Api);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // deserialize o Json para o Modelo de Dados Estabelecimento
                        var ItensJson = JsonConvert.DeserializeObject<List<Estabelecimento>>(await response.Content.ReadAsStringAsync());
                        // Adiciona os dados em uma Lista!
                        Estabelecimento = new ObservableCollection<Estabelecimento>(ItensJson);

                        //Atribui os dados para a ListaView 
                        ListaVagas.ItemsSource = Estabelecimento;
                        //Verificação da lista
                        int i = Estabelecimento.Count;
                        if (i > 0)
                        {
                            //                                          
                            activity_indicator.IsRunning = false;
                            activity_indicator.IsVisible = false;

                            //foreach (var item in Estabelecimento)
                            //{
                            //    if(item.Ativo == false)
                            //    {
                                    
                            //    }

                            //}
                        }
                       
                    }
                    else
                    {
                      await DisplayAlert("Servidor em Manutenção", "Olá, Estamos faendo manutenção nos nossos servidores, aguarde e tente mais tarde.", "OK");
                    }
                }
                catch (Exception)
                {
                    activity_indicator.IsVisible = false;
                    var resp = await DisplayAlert("Servidor em Manutenção", "Olá, Estamos faendo manutenção nos nossos servidores, aguarde e tente mais tarde.", "OK", "Atualiar");
                    if (resp)
                    {

                    }
                    else
                    {
                        GetListEstab();
                    }
                }
            }
            else
            {
                activity_indicator.IsVisible = false;
                var resp = await DisplayAlert("Sem conexão com a internet", "Conecte a internet e tente novamente", "Tentar novamente", "OK");
                if (resp)
                {

                }
                else
                {
                    GetListEstab();
                }
            }
        }      

        private async void VerificarUsuario()
        {
            if (!Application.Current.Properties.ContainsKey("Nome1"))
            {
                //await Navigation.PushAsync(new ClienteF());
                //var Nome = Application.Current.Properties["Nome"] as string;
                //// do something with id
            }
        }

        private async void NavegarToCardapio(string Nome_estabelecimento)
        {            
            try
            {             
                //Activity indicator visibility on
                activity_indicator.IsRunning = true;
                //Getting JSON data from the Web
                var content = await _client.GetStringAsync(Url_Api);
                ObservableCollection<Estabelecimento> categoriasFrases = JsonConvert.DeserializeObject<ObservableCollection<Estabelecimento>>(content);

                // Selecionar o objeto no Json.
                Estabelecimento categoriaFrasee = categoriasFrases.FirstOrDefault(cf => cf.Nome.Equals(Nome_estabelecimento));

                // Abre tela e envia os parâmetros.    
                if (categoriaFrasee != null)
                {
                    await Navigation.PushAsync(new Cardapios(categoriaFrasee));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Tapped", ex.ToString() + " ", "OK");

            }
        }        
        
        private void ListaVagas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection which results in SelectedItem being set to null
            }

            //var item = e.SelectedItem as MenuItem; //This is what I DON'T want to use because it references my Model directly.
            var item = (Estabelecimento)e.Item;
            switch (item.Nome.ToString()) //This is what I need. I can't get this unless I reference my Model "TableMainMenuItems" directly.
            {
                case "Robertinho Lanches":
                    NavegarToCardapio("Robertinho Lanches");
                    break;

                case "Coxinhas da Lia":
                    NavegarToCardapio("Coxinhas da Lia");
                    break;
            }
            lv.SelectedItem = null;
        }             
    }
}
