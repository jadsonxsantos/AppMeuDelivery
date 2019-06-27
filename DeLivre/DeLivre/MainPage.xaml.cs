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
            Check_Update();
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
            string Local = "Aracaju";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));
        }

        private void BtnTimon_Clicked(object sender, EventArgs e)
        {
            string Local = "Timon";
            Application.Current.Properties["_Cidade"] = Local;
            Application.Current.Properties["_OcultarLocal"] = true;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));
        }
    }
}
