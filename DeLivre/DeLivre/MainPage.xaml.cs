using DeLivre.Models;
using DeLivre.Views;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeLivre
{
    public partial class MainPage : ContentPage
    {
        // Request do JSON        
        public MainPage()
        {
            InitializeComponent();
            lbCidade.Opacity = 0;
            btnPinhao.Opacity = 0;
            //btnAracaju.Opacity = 0;
            Animacoes();
        }

        private async void Animacoes()
        {
           await lbCidade.FadeTo(1, 2000);
           //await btnAracaju.FadeTo(1, 1500);
           await btnPinhao.FadeTo(1, 1500);
        }

        private void BtnPinhao_Clicked(object sender, EventArgs e)
        {           
            string Local = "Pinhao";
            Application.Current.Properties["_Cidade"] = Local;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));
            // NavigationToEstabPinhao(Url_Pinhao);
            //Navigation.PushAsync(new Views.Estabelecimentos());
        }

        //private async void NavigationToEstabPinhao(string URL_Pinhao)
        //{
        //    if (CrossConnectivity.Current.IsConnected)
        //    {
        //        try
        //        {                   
        //            //Pegando os dados do JSON da URL
        //            var content = await _client.GetStringAsync(Url_Pinhao);
        //            //deserialize os dados do JSON em uma lista
        //            var ItensJson = JsonConvert.DeserializeObject<List<Estabelecimento>>(content);
        //            //alocando os dados em uma observablecollection
        //            ObservableCollection<Estabelecimento> Estabelecimento = new ObservableCollection<Estabelecimento>(ItensJson);
        //            Estabelecimento estab = Estabelecimento.FirstOrDefault();
        //            // Abre tela e envia os parâmetros.    
        //            if (Estabelecimento != null)
        //            {
        //                App.Current.MainPage = new NavigationPage(new Estabelecimentos(estab));
        //            }

        //        }
        //        catch (Exception ey)
        //        {
        //            await DisplayAlert("Tapped", ey.ToString() + " ", "OK");
        //        }                                                  
        //    }
        //}
    }
}
