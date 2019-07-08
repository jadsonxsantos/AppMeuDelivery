using DeLivre.Models;
using Firebase.Database;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using Xamarin.Essentials;
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
        List<Estabelecimento> ItensJson;
        string Url_Api, Url_Servidor;
        bool OcultarLocal;
        string MeuLocal;
        string Cidade;
        FirebaseClient firebase = new FirebaseClient("https://meudelivery-47bcc.firebaseio.com/");
        public Estabelecimentos(string cidade, string urlservidor)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();           
            Cidade = cidade;
            Url_Servidor = urlservidor;
            CarregarEstabelecimentos(Url_Servidor);
        }
        
        private async void CarregarEstabelecimentos(string UrlServer)
        {
            if (Application.Current.Properties.ContainsKey("_OcultarLocal"))
            {
                OcultarLocal = Convert.ToBoolean(Application.Current.Properties["_OcultarLocal"] as string);
            }

            if (Application.Current.Properties.ContainsKey("_Nome"))
            {
                string Nome = Application.Current.Properties["_Nome"] as string;
                lbl_Nome.Text = "Olá, " + Nome + "!";
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
                        ItensJson = JsonConvert.DeserializeObject<List<Estabelecimento>>(await response.Content.ReadAsStringAsync());
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
                    GetAllEstabelecimentos();
                }
                Check_Update();
            }
            else
            {
                activity_indicator.IsVisible = true;

                if (Estabelecimento_ == null)
                    stck_Listalimpa.IsVisible = true;

                activity_indicator.IsVisible = false;
                var resp = await DisplayAlert("Sem conexão com a internet", "Conecte a internet e tente novamente", "Tentar novamente", "OK");
                if (resp != true)
                    GetAllEstabelecimentos();
            }
        }

        protected void GetAllEstabelecimentos()
        {
            if (Application.Current.Properties.ContainsKey("_OcultarLocal"))
            {
                OcultarLocal = Convert.ToBoolean(Application.Current.Properties["_OcultarLocal"] as string);
            }

            if (Application.Current.Properties.ContainsKey("_Nome"))
            {
                string Nome = Application.Current.Properties["_Nome"] as string;
                lbl_Nome.Text = "Olá, " + Nome + "!";
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

            if (Cidade == "Pinhão")
            {
                CarregarEstabelecimentos("https://meudelivery-47bcc.firebaseio.com/" + ".json");              
            }   
            else if (Cidade == "Aracaju")
            {
                CarregarEstabelecimentos("https://teste-213d3.firebaseio.com/" + ".json");               
            }
            else if (Cidade == "Timon")
            {
                CarregarEstabelecimentos("https://amd-timon.firebaseio.com/" + ".json");
            }
        }

        private async void Check_Update()
        {
            var current = $"{VersionTracking.CurrentBuild} ({VersionTracking.CurrentVersion})";
            var Previus = $"{VersionTracking.PreviousBuild} ({VersionTracking.PreviousVersion})";

            if (VersionTracking.IsFirstLaunchForCurrentBuild)
            {
                //Avisa o usuario que existe uma versão nova e pergunta se ele quer baixar
                var update = await DisplayAlert("Nova versão disponível", "Existe uma nova versão do App Meu Delivery, deseja atualizar?", "Sim", "Não");

                if (update)
                {
                    await Launcher.OpenAsync("https://play.google.com/store/apps/details?id=com.lurasoft.AppMeuDelivery");
                }
            }
        }

        //public async Task Att_Horario(string codigo, string estabelecimento, string horario, string horarioatt)
        //{                    
        //    await firebase
        //          .Child(codigo).Child(estabelecimento).Child(horario)
        //          .PostAsync(new DeLivre.Models.Estabelecimento()
        //          {
        //              Horario_Funcionamento =  horarioatt                    
        //          });
        //}

        private async void NavegarToCardapio(string Nome_estabelecimento, string ApiUrl)
        {          
            try
            {             
                //Visibilidade do indicador
                activity_indicator.IsRunning = true;
                //Pegando os dados JSON da Servidor
                //var content = await _client.GetStringAsync(ApiUrl);
                //ObservableCollection<Estabelecimento> _Estabelecimentos = JsonConvert.DeserializeObject<ObservableCollection<Estabelecimento>>(ItensJson);
                // Selecionar o objeto no Json.
                // Adiciona os dados em uma Lista!
                Estabelecimento_ = new ObservableCollection<Estabelecimento>(ItensJson);
                Estabelecimento _Estabelecimento = Estabelecimento_.FirstOrDefault(cf => cf.Nome.Equals(Nome_estabelecimento));
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
            NavegarToCardapio(item.Nome.ToString(), Url_Api);

            lv.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }

        private async void ListaEstabelecimento_Refreshing(object sender, EventArgs e)
        {
            try
            {
                GetAllEstabelecimentos();
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
