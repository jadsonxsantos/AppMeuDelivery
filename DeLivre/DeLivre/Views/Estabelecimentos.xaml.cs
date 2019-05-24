using DeLivre.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Estabelecimentos : ContentPage
    {       
        // Request do JSON 
        private HttpClient _client = new HttpClient();
        ObservableCollection<Estabelecimento> Estabelecimento_;
        string Url_Api;
        public Estabelecimento horari { get; }

        public Estabelecimentos()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            GetListEstab();           
        }      

        protected async void GetListEstab()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                activity_indicator.IsRunning = true;
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

                        DateTime aDate = DateTime.Now;
                        DateTime dateValue;
                     
                        dateValue = DateTime.Parse(aDate.ToString("MM/dd/yyyy"), CultureInfo.InvariantCulture);
                       string dia = dateValue.ToString("dddd", new CultureInfo("pt-BR"));

                        if(dia == "quarta-feira")
                        {
                            foreach (var item in Estabelecimento_)
                            {
                              var x= item.Horarios_Funcionamento;

                                foreach (var horario in x)
                                {
                                    //horari = new Horario_Funcionamento
                                    //{
                                    //    Nome = "Usuario exemplo",
                                    //    Idade = 20
                                    //};
                                    //var modelo = new Estabelecimento
                                    //{
                                    //    Horario = horario.Quarta_Feira,                                        
                                    //};
                                    
                                        //BindingContext = modelo;
                                }

                            }
                        }
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
                      await DisplayAlert("Manutenção", "Olá, Estamos fazendo manutenção em nossos servidores, aguarde e tente mais tarde.", "OK");
                    }
                }
                catch (Exception)
                {
                    activity_indicator.IsVisible = false;
                    var resp = await DisplayAlert("Manutenção", "Olá, Estamos fazendo manutenção nos nossos servidores, aguarde e tente mais tarde.", "OK", "Atualizar");
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
                activity_indicator.IsVisible = true;
                if (Estabelecimento_ == null)
                    stck_Listalimpa.IsVisible = true;

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
            catch
            {
                await DisplayAlert("Verifique sua conexão",  "por favor verifique sua conexão e tente novamente mais tarde", "OK");
            }
        }        
        
        private void ListaVagas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var lv = (ListView)sender;

            if (e.Item == null)
            {
                return; 
            }
         
            var item = (Estabelecimento)e.Item;
            NavegarToCardapio(item.Nome.ToString());

            lv.SelectedItem = null;
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    GetListEstab();
        //}

        private async void ListaEstabelecimento_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetListEstab();
            }
            catch
            {
                await DisplayAlert("Verifique sua conexão", "Por favor verifique sua conexão e tente novamente mais tarde", "OK");
            }
            finally
            {
                ListaEstabelecimento.EndRefresh();
            }  
        }
    }
}
