using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.Avisos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Localizacao : PopupPage
    {
        public Localizacao()
        {
            InitializeComponent();
        }      

        private async void Btn_Minha_Cidade_Clicked(object sender, EventArgs e)
        {                                   
                string Local = "Pinhão";                
                Application.Current.Properties["_Cidade"] = Local;
                await PopupNavigation.Instance.PopAsync();
               bool ocultar = Convert.ToBoolean(Application.Current.Properties["_OcultarLocal"] = true);
                //App.Current.MainPage = new NavigationPage(new Views.Estabelecimentos(ocultar));                                                                
        }
    }
}