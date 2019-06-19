using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuCardapio : ContentPage
	{
        HttpClient client = new HttpClient();
        public MenuCardapio ()
		{
			InitializeComponent ();
            loadDados();

        }

        private async void loadDados()
        {
            try
            {
                string url = "https://teste-213d3.firebaseio.com/.json/";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Models.Menu>>(response);
                listaProdutos.ItemsSource = produtos.OrderBy(item => item.Nome).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}