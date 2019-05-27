using Com.OneSignal;
using DeLivre.Models;
using DLToolkit.Forms.Controls;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DeLivre
{
    public partial class App : Application
    {
       public static ObservableCollection<Cardapio> Meus_Pedidos = new ObservableCollection<Cardapio>();
        public App()
        {
            InitializeComponent();
            FlowListView.Init();
            MainPage = new MainPage();
            OneSignal.Current.StartInit("aed63aa3-9fbf-4f23-a9b2-26ee4666d096").EndInit();
        }

        protected override void OnStart()
        {
            OneSignal.Current.RegisterForPushNotifications();
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
