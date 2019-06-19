using System;
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
           await lbCidade.FadeTo(1, 1000);
           //await btnAracaju.FadeTo(1, 1500);
           await btnPinhao.FadeTo(1, 500);
        }

        private void BtnPinhao_Clicked(object sender, EventArgs e)
        {           
            string Local = "Pinhão";
            Application.Current.Properties["_Cidade"] = Local;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos());        
        }

        private void Btn_Parceria_Clicked(object sender, EventArgs e)
        {           
            //App.Current.MainPage = new NavigationPage(new Views.MenuCardapio());
            Device.OpenUri(new Uri("https://www.instagram.com/appmeudelivery/"));
        }
    }
}
