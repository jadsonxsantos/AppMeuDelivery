using Rg.Plugins.Popup.Services;
using System;
using DeLivre.Views.Avisos;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;

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
           await lbCidade.FadeTo(1, 1000);
           //await btnAracaju.FadeTo(1, 1500);
           await btnPinhao.FadeTo(1, 500);
            Check_Update();

        }

        private async void Check_Update()
        {

            var previousVersion = VersionTracking.PreviousBuild;
            var currentVersion = VersionTracking.CurrentBuild;

            //Verifica a versão atual do APP
            var isLatest = VersionTracking.IsFirstLaunchForCurrentBuild;
            if (currentVersion != previousVersion)
            {
                //Avisa o usuario que existe uma versão nova e pergunta se ele quer baixar
                var update = await DisplayAlert("Nova versão disponivel", "Existe uma nova versão deste app, deseja atualizar?", "Sim", "Não");

                if (update)
                {
                    //Abre a Loja nativa da plataforma para efetur o Download
                    await Launcher.OpenAsync("https://play.google.com/store/apps/details?id=com.lurasoft.AppMeuDelivery");
                }
            }
        }

        private void BtnPinhao_Clicked(object sender, EventArgs e)
        {           
            string Local = "Pinhão";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));        
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
            string Local = "Aracajú";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));
        }
    }
}
