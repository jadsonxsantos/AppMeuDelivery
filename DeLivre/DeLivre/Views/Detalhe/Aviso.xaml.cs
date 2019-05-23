using DeLivre.Models;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views.Detalhe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Aviso : PopupPage
    {       
        public Aviso ()
		{
			InitializeComponent ();           
        }

        private void Btn_Video_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/watch?v=B4zwIkR5TGo"));
        }
    }
}