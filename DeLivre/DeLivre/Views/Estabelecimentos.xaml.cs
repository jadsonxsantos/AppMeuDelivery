using DeLivre.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        ObservableCollection<Estabelecimento> Estabelecimento_;
        string Url_Api;
        public Estabelecimentos(string Estab_)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Local_Name = Estab_;
            GetListEstab();         
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
                        Estabelecimento_ = new ObservableCollection<Estabelecimento>(ItensJson);
                        //bool StatusEstab = Estabelecimento_.Where(x => x.Aberto);
                        //if (StatusEstab == true)
                        //{

                        //}
                        //Atribui os dados para a ListaView 
                        ListaEstabelecimento.ItemsSource = Estabelecimento_.Where(x => x.Ativo == true);                                     
                        //Verificação da lista
                        int i = Estabelecimento_.Count;
                        if (i > 0)
                        {                                                                     
                            activity_indicator.IsRunning = false;
                            activity_indicator.IsVisible = false;    
                            boxLinha.IsVisible = true;
                        }                       
                    }
                    else
                    {
                      await DisplayAlert("Servidor em Manutenção", "Olá, Estamos fazendo manutenção em nossos servidores, aguarde e tente mais tarde.", "OK");
                    }
                }
                catch (Exception)
                {
                    activity_indicator.IsVisible = false;
                    var resp = await DisplayAlert("Servidor em Manutenção", "Olá, Estamos fazendo manutenção nos nossos servidores, aguarde e tente mais tarde.", "OK", "Atualizar");
                    if (resp)
                    {

                    }
                    else
                    {
                        activity_indicator.IsRunning = true;
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

        private async void NavegarToCardapio(string Nome_estabelecimento)
        {            
            try
            {             
                //Visibilidade do indicador
                activity_indicator.IsRunning = true;
                //Pegando os dados JSON da Servidor
                var content = await _client.GetStringAsync(Url_Api);
                ObservableCollection<Estabelecimento> _Estabelecimentos = JsonConvert.DeserializeObject<ObservableCollection<Estabelecimento>>(content);
                // Selecionar o objeto no Json.
                Estabelecimento _Estabelecimento = _Estabelecimentos.FirstOrDefault(cf => cf.Nome.Equals(Nome_estabelecimento));                      
                // Abre tela e envia os parâmetros.    
                if (_Estabelecimento != null)
                {
                    await Navigation.PushAsync(new Cardapios(_Estabelecimento));
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Entre em contato com o Desenvolvedor!", ex.ToString() + " ", "OK");
            }
        }        
        
        private void ListaVagas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return; //ItemSelected is called on deselection which results in SelectedItem being set to null
            }
         
            var item = (Estabelecimento)e.Item;
            NavegarToCardapio(item.Nome.ToString());

            lv.SelectedItem = null;
        }             
    }
}
