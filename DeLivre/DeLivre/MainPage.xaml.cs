using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace DeLivre
{
    public partial class MainPage : ContentPage
    {
        // Request do JSON        
        public MainPage()
        {
            InitializeComponent();                  
        }             

        private void BtnPinhao_Clicked(object sender, EventArgs e)
        {           
            string Local = "Pinhão";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            string UrlServidor = "https://amd-pinhao.firebaseio.com/" + ".json";
            Application.Current.Properties["UrlServer"] = UrlServidor;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local, UrlServidor));        
        }

        private async void Btn_Parceria_Clicked(object sender, EventArgs e)
        {
            var supportsUri = await Launcher.CanOpenAsync("https://wa.me");
            if (supportsUri)
                await Launcher.OpenAsync("https://wa.me/5579998682289");
            //Device.OpenUri(new Uri("https://wa.me/5579998682289"));   
        }

        private void BtnAracaju_Clicked(object sender, EventArgs e)
        {
            string Local = "Aracaju";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            string UrlServidor = "https://teste-213d3.firebaseio.com/" + ".json";
            Application.Current.Properties["UrlServer"] = UrlServidor;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local, UrlServidor));
        }

        private void BtnTimon_Clicked(object sender, EventArgs e)
        {
            string Local = "Timon";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            string UrlServidor = "https://amd-timon.firebaseio.com/" + ".json";
            Application.Current.Properties["UrlServer"] = UrlServidor;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local, UrlServidor));
        }

        private void BtnEstancia_Clicked(object sender, EventArgs e)
        {
            string Local = "Estância";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            string UrlServidor = "https://amd-estancia.firebaseio.com/" + ".json";
            Application.Current.Properties["UrlServer"] = UrlServidor;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local, UrlServidor));
        }

        private void BtnItabaiana_Clicked(object sender, EventArgs e)
        {
            string Local = "Itabaiana";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            string UrlServidor = "https://amd-itabaiana.firebaseio.com/" + ".json";
            Application.Current.Properties["UrlServer"] = UrlServidor;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local, UrlServidor));
        }

        //private async void Btn_instagram_Clicked(object sender, EventArgs e)
        //{           
        //  await  Launcher.OpenAsync("https://www.instagram.com/appmeudelivery/");
        //}
    }
}
