using DeLivre.Components;
using DeLivre.Models;
using System;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedido : TabbedPage
    {       
        ObservableCollection<Cardapio> MeusPedido;          
        double Valor_Pedido, Valor_Total, Valor_Adicionais, ValorJurosCartao = 0;
        string Valor_Frete, Number_Whatsapp, Nome_Estabelecimento, Pedido_Minimo, TrocaInfo, Valor_Troco, Tipo_Pagamento, Juros_Cartao, ValorEntrega;
        string BreakLine, Endereco, ClienteDados, infoDados, Saudacao;      
        bool AceitaCartao, OcultarAviso = true;
        string tipoPedido, NomePedidoFb;

        FirebaseClient firebase = new FirebaseClient("https://amd-pedidos.firebaseio.com/");

        public Pedido(ObservableCollection<Cardapio> pedido)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MeusPedido = pedido;                
            ListaCardapio.ItemsSource = MeusPedido;
            VerificarIdentidade();
            Load_Valores();               
            CurrentPageChanged += Pedido_CurrentPageChanged;
        }

        private async void Pedido_CurrentPageChanged(object sender, EventArgs e)
        {
            VerificarIdentidade();
            var pedido = (TabbedPage) sender;
            var Content = pedido.CurrentPage.Title;

            if (Application.Current.Properties.ContainsKey("_PedidoMinimo"))
            {
                Pedido_Minimo = Application.Current.Properties["_PedidoMinimo"] as string;
            }

            if (Application.Current.Properties.ContainsKey("_OcultarAviso"))
            {
                OcultarAviso = Convert.ToBoolean(Application.Current.Properties["_OcultarAviso"] as string);
            }

            if (Content == "FINALIZAR PEDIDO")
            {
              
                double PedidoMinimo, valorTotal;
                PedidoMinimo = Convert.ToDouble(Pedido_Minimo);
                valorTotal = Convert.ToDouble(lbl_Valor_Total.Text.Replace("R$", ""));
                if (valorTotal < PedidoMinimo)
                {
                    SalvareEnviar.IsEnabled = false;
                    //CurrentPage = ctp_Pedidos;
                    SalvareEnviar.Text = "Valor Mínimo para o pedido R$: " + PedidoMinimo;
                    DependencyService.Get<IMessage>().ShortAlert("O valor mínimo do pedido é de R$: " + PedidoMinimo);
                }
                else
                {
                   if(OcultarAviso == true)                              
                      await PopupNavigation.Instance.PushAsync(new Detalhe.Aviso());                      
                }                
            }
        }      

        private void Load_Valores()
        {
            if (App.Meus_Pedidos.Count <= 0)
                stck_Listalimpa.IsVisible = true;

            try
            {
                //Pegando o Valor do Frete e atribuindo ao label 
                if (Valor_Frete.Contains("-"))
                {
                    ValorEntrega = "Taxa de entrega: A combinar!";                   
                }
                else if (Valor_Frete == "0,00")
                {
                    ValorEntrega = "Taxa de entrega: Grátis";
                }
                else
                {
                    ValorEntrega = String.Format("Taxa de entrega: R$ {0:C} ", Valor_Frete);
                }
           
                lbl_Entrega.Text = ValorEntrega;
                //Calculando o Valor de cada Pedido!
                Valor_Pedido = MeusPedido.Select(x => Convert.ToDouble(x.ValorTotal)).Sum();
                Valor_Pedido = Convert.ToDouble(Valor_Pedido.ToString());
                lbl_Total_Pedido.Text = String.Format("Total do Pedido: {0:C}", Valor_Pedido);
                //Calculando o Valor Total do Pedido + Frete + Quantidade
                double ValorPedido_ = MeusPedido.Select(x => Convert.ToDouble(x.ValorTotal)).Sum();
                string ValorFrete = Valor_Frete.Replace("R$","");
                Valor_Adicionais = MeusPedido.Select(x => x.ValorAdicionais).Sum();
              
                if(Valor_Adicionais > 0)
                {
                    lbl_Valor_Adicionais.IsVisible = true;
                    lbl_Valor_Adicionais.Text = String.Format("Total Adicionais: {0:C2}", Valor_Adicionais);
                }
                else
                {
                    lbl_Valor_Adicionais.IsVisible = false;
                }
                // Verificando se o frete é a combinar ou se é valor fixo
                if (ValorFrete.Contains("-") || ValorFrete.Contains("0,00"))
                {
                    Valor_Total = ValorPedido_ + Valor_Adicionais + ValorJurosCartao;                   
                }
                else
                {
                    Valor_Total = ValorPedido_ + Convert.ToDouble(ValorFrete) + Valor_Adicionais + ValorJurosCartao;
                }

                if(ValorFrete.Contains("-"))
                   Valor_Frete = "A combinar.";

                Valor_Total = Convert.ToDouble(Valor_Total.ToString());
                lbl_Valor_Total.Text = String.Format("{0:C2}", Valor_Total);
            }
            catch
            {
                DependencyService.Get<IMessage>().LongAlert("...");
            }        
        }
       
        private async void ListaCardapio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {          
            ((ListView)sender).SelectedItem = null;
            var item = e.SelectedItem as Cardapio;
            if (item == null)
                return;           
         
            var DeleteItem = await DisplayAlert("Quer deletar este item?", "Tem Certeza?", "Sim", "Cancelar");
            if (DeleteItem == true) // Sim
            {
                App.Meus_Pedidos.Remove(item);
                Load_Valores();
            }
            else
            {
                return;
            }
        }      

        #region ConfirmarIdentidade
        private void VerificarIdentidade()
        {
            try
            {                
                if (Application.Current.Properties.ContainsKey("_AceitaCartao"))
                {
                    AceitaCartao = Convert.ToBoolean(Application.Current.Properties["_AceitaCartao"]);

                    if (AceitaCartao == false)
                        Tipo_Cartao.IsVisible = false;
                    else
                        Tipo_Cartao.IsVisible = true;

                }
                if (Application.Current.Properties.ContainsKey("_Pagamento"))
                {
                    Tipo_Pagamento = Application.Current.Properties["_Pagamento"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_JurosCartao"))
                {
                    Juros_Cartao = Application.Current.Properties["_JurosCartao"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_TrocaInfo"))
                {
                    TrocaInfo = Application.Current.Properties["_TrocaInfo"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Frete"))
                {
                    Valor_Frete = Application.Current.Properties["_Frete"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Whatsapp"))
                {
                    Number_Whatsapp = Application.Current.Properties["_Whatsapp"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Estabelecimento_"))
                {
                    Nome_Estabelecimento = Application.Current.Properties["_Estabelecimento_"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Nome"))
                {
                    EntNome.Text = Application.Current.Properties["_Nome"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Sobrenome"))
                {
                    EntSobrenome.Text = Application.Current.Properties["_Sobrenome"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Endereco"))
                {
                    EntEndereco.Text = Application.Current.Properties["_Endereco"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Numero"))
                {
                    EntNumero.Text = Application.Current.Properties["_Numero"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Cidade"))
                {
                    EntCidade.Text = Application.Current.Properties["_Cidade"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_Bairro"))
                {
                    EntBairro.Text = Application.Current.Properties["_Bairro"] as string;
                }
                if (Application.Current.Properties.ContainsKey("_PontoReferencia"))
                {
                    EntReferencia.Text = Application.Current.Properties["_PontoReferencia"] as string;
                }
            }
            catch (Exception)
            {
                DependencyService.Get<IMessage>().LongAlert("Tente novamente");
            }
           
        }

        private void SalvarDados()
        {
            Application.Current.Properties["_Nome"] = EntNome.Text;
            Application.Current.Properties["_Sobrenome"] = EntSobrenome.Text;
            Application.Current.Properties["_Endereco"] = EntEndereco.Text;
            Application.Current.Properties["_Numero"] = EntNumero.Text;
            Application.Current.Properties["_Cidade"] = EntCidade.Text;
            Application.Current.Properties["_Bairro"] = EntBairro.Text;
            Application.Current.Properties["_PontoReferencia"] = EntReferencia.Text;
        }

        #endregion

        private async void EnviarPedido()
        {
            SalvareEnviar.Text = "Aguarde! Enviando pedido...";
            // Apresentações iniciais!
            BreakLine = Environment.NewLine;
            Endereco = EntEndereco.Text + ", %20" + "Nº: " + EntNumero.Text + " - " + EntBairro.Text + " - %20" + EntCidade.Text + " - " + EntReferencia.Text + ".";
            ClienteDados = Application.Current.Properties["_Nome"] as string + " " + Application.Current.Properties["_Sobrenome"] as string;
            infoDados = "*MEUS DADOS:* " + BreakLine + ClienteDados + BreakLine + "*LOCAL DA ENTREGA:* " + BreakLine + Endereco;
            Saudacao = "Olá, *" + Nome_Estabelecimento + "!*%20 ";
            // informações Referente a Troco
            if (!String.IsNullOrEmpty(Ent_Troco.Text))
                Valor_Troco = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "*Troco para:* R$ {0:C}", Ent_Troco.Text);
            else
                Valor_Troco = " ";

            string MeuPedido = BreakLine + "*MEU PEDIDO:* " + BreakLine;
           
            string newTrocaInfo = "";
            string newItemAdicional = "";
            foreach (Cardapio item in ListaCardapio.ItemsSource)
            {
                // Informações Complementares, Troca de algum item, ou remoção de items
                if (!String.IsNullOrEmpty(item.TrocaInfo))
                    newTrocaInfo = "_Info.: " + item.TrocaInfo + "_" + BreakLine;
                else
                    newTrocaInfo = "";
               
                // Pegando os Adicionais dos Pedidos!
                if (!String.IsNullOrEmpty(item.Adicionais_itens))
                    newItemAdicional = "_" + item.TitleAdcorSab + " : " + item.Adicionais_itens.TrimEnd() + "_" + BreakLine;
                else
                    newItemAdicional = "";

                tipoPedido = item.Tipo;
                // Passando todo o pedido para uma variavel
                MeuPedido += BreakLine + item.Quantidade + "x " + item.Tipo + " " + item.Nome + " "
                         + " - *Valor R$ " + item.ValorTotal + "*." + BreakLine + newTrocaInfo + newItemAdicional;
                NomePedidoFb = item.Tipo + " - " + item.Nome;
            }
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("pt-BR");

            string today = DateTime.Now.ToString("HH:mm");
           
            try
            {                
               await AddPedido(ClienteDados, today, NomePedidoFb, lbl_Valor_Total.Text);               
            }
            catch
            {
                DependencyService.Get<IMessage>().ShortAlert("Processando pedido...");
            }
            finally
            {
                // Passando todo o pedido para a API do Whatsapp
                Device.OpenUri(new Uri("https://wa.me/" + Number_Whatsapp + "?text="
                       + Saudacao + "%20" + BreakLine + infoDados + BreakLine
                       + MeuPedido + BreakLine
                       + "*VALOR FRETE:* " + Valor_Frete + BreakLine
                       + "*PAGAMENTO:* " + Tipo_Pagamento + BreakLine
                       + "*VALOR TOTAL:* " + lbl_Valor_Total.Text + BreakLine +
                         BreakLine +
                         Valor_Troco));
            }                      
        }       

        public async Task AddPedido(string nome, string datapedido, string pedido, string valorPedido)
        {           
            string Dia = DateTime.Now.ToString("dd-MM-yyyy");
            string Ano = DateTime.Now.Year.ToString();
            int Mes = DateTime.Now.Month;
            string mesNome = DateTimeFormatInfo.CurrentInfo.GetMonthName(Mes).ToLower();
            mesNome = char.ToUpper(mesNome[0]) + mesNome.Substring(1);

            await firebase
                  .Child(EntCidade.Text).Child(Nome_Estabelecimento).Child(Ano).Child(mesNome).Child(Dia)
                  .PostAsync(new DeLivre.Models.Pedido()
                  {                      
                      Nome = nome,                      
                      HoraPedido = datapedido,  
                      NomePedido = pedido,
                      ValorPedido = valorPedido
                  });       
        }      

        private void VerificareEnviar()
        {
            if (!String.IsNullOrEmpty(EntNome.Text) && (!String.IsNullOrEmpty(EntEndereco.Text)) && 
                (!String.IsNullOrEmpty(EntNumero.Text)) && (!String.IsNullOrEmpty(EntBairro.Text))&& 
                (!String.IsNullOrEmpty(EntReferencia.Text))) 
            {                
                double valorTotal = Convert.ToDouble(lbl_Valor_Total.Text.Replace("R$", ""));
                double valorTroco = Convert.ToDouble(Ent_Troco.Text);
                if(Tipo_Dinheiro.IsChecked == true)
                {
                    if(!String.IsNullOrEmpty(Ent_Troco.Text))
                    {
                        if (valorTroco >= valorTotal)
                        {
                            EnviarPedido();                         
                        }
                        else
                        {
                            DependencyService.Get<IMessage>().ShortAlert("Valor do toco não pode ser menor que o valor à ser pago!");
                        }
                    }
                    else
                    {                       
                        EnviarPedido();
                    }
                   
                }
                if(Tipo_Cartao.IsChecked == true)
                {                    
                    EnviarPedido();
                }                        
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Preencha todos os campos para proseguir!");
            }
        }

        private void CheckMetodoPagamento()
        {            
                // Verificando de o Estabelecimento aceita cartão de Credito
                if (Tipo_Dinheiro.IsChecked == true)
                {
                    Tipo_Pagamento = "Dinheiro";
                    Load_Valores();
                }
                if (Tipo_Cartao.IsChecked == true)
                {                  
                    Ent_Troco.Text = null;
                    if (Juros_Cartao != "")
                    {
                        Tipo_Pagamento = String.Format(@"Cartão: R$ {0}\Juros", Juros_Cartao);
                        ValorJurosCartao = Convert.ToDouble(Juros_Cartao);
                        Load_Valores();
                    }
                    else
                    {
                        Tipo_Pagamento = "Cartão";
                    }
                }                     
        }

        private void Tipo_Cartao_Clicked(object sender, EventArgs e)
        {
            stck_Troco.IsVisible = false;           
        }

        private void Tipo_Dinheiro_Clicked(object sender, EventArgs e)
        {
            stck_Troco.IsVisible = true;
        }
             
        private void SalvareEnviar_Clicked(object sender, EventArgs e)
        {                     
            SalvarDados();
            CheckMetodoPagamento();           
            VerificareEnviar();                  
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SalvareEnviar.Text = "Enviar Pedido!";        
        }
    }
}


