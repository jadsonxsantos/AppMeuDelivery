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
           await lbCidade.FadeTo(1, 2000);
           //await btnAracaju.FadeTo(1, 1500);
           await btnPinhao.FadeTo(1, 1500);
        }

        private void BtnPinhao_Clicked(object sender, EventArgs e)
        {           
            string Local = "Pinhao";
            Application.Current.Properties["_Cidade"] = Local;
            App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Local));        
        }

        private void Btn_Parceria_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://wa.me/557996122327?text=Ol%C3%A1%2C%20tenho%20interesse%20em%20saber%20mais%20sobre%20o%20App%20Meu%20Delivery!"));
        }
    }
}
