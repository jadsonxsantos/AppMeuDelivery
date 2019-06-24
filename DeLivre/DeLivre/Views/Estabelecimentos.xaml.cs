using DeLivre.Models;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Services;
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
        bool OcultarLocal;
        string MeuLocal;
        string Cidade;
        FirebaseClient firebase = new FirebaseClient("https://meudelivery-47bcc.firebaseio.com/");
        public Estabelecimentos(string cidade)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();           
            Cidade = cidade;
            GetListEstab();           
        }
        
        private async void CarregarEstabelecimentos(string UrlServer)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                activity_indicator.IsRunning = true;
                try
                {
                    Url_Api = UrlServer;
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

                        //DateTime aDate = DateTime.Now;
                        //DateTime dateValue;

                        //dateValue = DateTime.Parse(aDate.ToString("MM/dd/yyyy"), CultureInfo.InvariantCulture);
                        //string dia = dateValue.ToString("dddd", new CultureInfo("pt-BR"));

                        //if (dia == "terça-feira")
                        //{
                        //    foreach (var item in ItensJson)
                        //    {

                        //        string segunda = item.Horarios_Funcionamento.Select(h => h.Segunda_Feira).ToString();
                        //        string NomeEstab = Estabelecimento_.Select(x => x.Nome).ToString();
                        //        string horario = Estabelecimento_.Select(X => X.Horario_Funcionamento).ToString();
                        //        string codigo = Estabelecimento_.Select(X => X.Id).ToString();
                        //        await Att_Horario(codigo, NomeEstab, horario, segunda);
                        //    }
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
                    var resp = await DisplayAlert("Problema na conexão", "Verifique sua internet e tente novamente!", "OK", "Atualizar");
                    if (resp != true)
                        activity_indicator.IsRunning = true;
                    GetListEstab();
                }
            }
            else
            {
                activity_indicator.IsVisible = true;

                if (Estabelecimento_ == null)
                    stck_Listalimpa.IsVisible = true;

                activity_indicator.IsVisible = false;
                var resp = await DisplayAlert("Sem conexão com a internet", "Conecte a internet e tente novamente", "Tentar novamente", "OK");
                if (resp != true)
                    GetListEstab();
            }
        }

        protected async void GetListEstab()
        {

            if (Application.Current.Properties.ContainsKey("_OcultarLocal"))
            {
                OcultarLocal = Convert.ToBoolean(Application.Current.Properties["_OcultarLocal"] as string);
            }
            if (Application.Current.Properties.ContainsKey("_Nome"))
            {
                string Nome = Application.Current.Properties["_Nome"] as string;
                lbl_Nome.Text = "Olá, " + Nome +"!";
            }
            else
            {
                lbl_Nome.Text = "Olá, Visitante!";
            }

            if (Application.Current.Properties.ContainsKey("_Cidade"))
            {
                MeuLocal = Application.Current.Properties["_Cidade"] as string;
                lbl_Local.Text = "Local: " + MeuLocal;
            }
            else
            {
                lbl_Local.Text = " ";
            }

            if (MeuLocal == "Pinhão")
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

                            //DateTime aDate = DateTime.Now;
                            //DateTime dateValue;

                            //dateValue = DateTime.Parse(aDate.ToString("MM/dd/yyyy"), CultureInfo.InvariantCulture);
                            //string dia = dateValue.ToString("dddd", new CultureInfo("pt-BR"));

                            //if (dia == "terça-feira")
                            //{
                            //    foreach (var item in ItensJson)
                            //    {

                            //        string segunda = item.Horarios_Funcionamento.Select(h => h.Segunda_Feira).ToString();
                            //        string NomeEstab = Estabelecimento_.Select(x => x.Nome).ToString();
                            //        string horario = Estabelecimento_.Select(X => X.Horario_Funcionamento).ToString();
                            //        string codigo = Estabelecimento_.Select(X => X.Id).ToString();
                            //        await Att_Horario(codigo, NomeEstab, horario, segunda);
                            //    }
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
                        var resp = await DisplayAlert("Problema na conexão", "Verifique sua internet e tente novamente!", "OK", "Atualizar");
                        if (resp != true)
                            activity_indicator.IsRunning = true;
                        GetListEstab();
                    }
                }
                else
                {
                    activity_indicator.IsVisible = true;

                    if (Estabelecimento_ == null)
                        stck_Listalimpa.IsVisible = true;

                    activity_indicator.IsVisible = false;
                    var resp = await DisplayAlert("Sem conexão com a internet", "Conecte a internet e tente novamente", "Tentar novamente", "OK");
                    if (resp != true)
                        GetListEstab();
                }
            }   
            if(MeuLocal == "Aracajú")
            {
                CarregarEstabelecimentos("https://meudelivery-47bcc.firebaseio.com/.json");
                await DisplayAlert("Teste", "Aracajú", "OK");
            }
        }

        public async Task Att_Horario(string codigo, string estabelecimento, string horario, string horarioatt)
        {            

            await firebase
                  .Child(codigo).Child(estabelecimento).Child(horario)
                  .PostAsync(new DeLivre.Models.Estabelecimento()
                  {
                      Horario_Funcionamento =  horarioatt                    
                  });
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

        private void Selecionar_Cidade_Clicked(object sender, EventArgs e)
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();          
        }

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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}
