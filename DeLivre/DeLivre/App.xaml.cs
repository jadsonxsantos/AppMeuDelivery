using Com.OneSignal;
using DeLivre.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeLivre
{
    public partial class App : Application
    {
       public static ObservableCollection<Cardapio> Meus_Pedidos = new ObservableCollection<Cardapio>();     
        string MyServer, Cidade;
        public App()
        {
            InitializeComponent();
            VersionTracking.Track();
            LoadPage();
            //MainPage = new Estabelecimentos(ocultar);           
            OneSignal.Current.StartInit("aed63aa3-9fbf-4f23-a9b2-26ee4666d096").EndInit();
        }

        private void LoadPage()
        {            

            if (Application.Current.Properties.ContainsKey("_OcultarLocal") == true)
            {                       
                if (Application.Current.Properties.ContainsKey("_Cidade"))
                {
                   Cidade = Application.Current.Properties["_Cidade"] as string;                   
                }

                if (Application.Current.Properties.ContainsKey("UrlServer"))
                {
                    MyServer = Application.Current.Properties["UrlServer"] as string;
                }
                App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(Cidade, MyServer));
                //MainPage = new Estabelecimentos(Cidade, MyServer);
            }
            else
            {
                MainPage = new MainPage();
            }
        }

        protected override void OnStart()
        {
            OneSignal.Current.RegisterForPushNotifications();
            LoadPage();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {         
            // Handle when your app resumes
        }
    }
}
