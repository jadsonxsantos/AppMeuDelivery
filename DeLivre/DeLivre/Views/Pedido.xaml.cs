using DeLivre.Components;
using DeLivre.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeLivre.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pedido : TabbedPage
    {       
        ObservableCollection<Cardapio> MeusPedido;     
        double Valor_Pedido, Valor_Total, Valor_Adicionais, ValorJurosCartao = 0;
        string Valor_Frete, Number_Whatsapp, Nome_Estabelecimento, TrocaInfo, Valor_Troco, Tipo_Pagamento, Juros_Cartao, ValorEntrega;
        string BreakLine, Endereco, ClienteDados, infoDados, Saudacao;

        public Pedido(ObservableCollection<Cardapio> pedido)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            MeusPedido = pedido;                
            ListaCardapio.ItemsSource = MeusPedido;
            VerificarIdentidade();
            Load_Valores();         
        }   

        private void Load_Valores()
        {
            if(App.Meus_Pedidos.Count <= 0)
                stck_Listalimpa.IsVisible = true;

            try
            {
                //Pegando o Valor do Frete e atribuindo ao label                
                if (Valor_Frete == "0,00")
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
                Valor_Total = ValorPedido_ + Convert.ToDouble(ValorFrete) + Valor_Adicionais + ValorJurosCartao;
                //Valor_Total = Convert.ToDouble(Valor_Total.ToString());
                lbl_Valor_Total.Text = String.Format("{0:C2}", Valor_Total);
            }
            catch (Exception)
            {
                throw;
            }        
        }
       
        private async void ListaCardapio_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {          
            ((ListView)sender).SelectedItem = null;
            var item = e.SelectedItem as Cardapio;
            if (item == null)
                return;           
         
            var DeleteItem = await DisplayAlert("Quer deletar este pedido?", "Tem Certeza?", "Sim", "Cancelar");
            if (DeleteItem == true) // Sim
            {
                //await Navigation.PushAsync(new Teste());
                App.Meus_Pedidos.Remove(item);
                Load_Valores();
            }
            else
            {
                return;
            }

            //ListaCardapio.BeginRefresh();
            //ListaCardapio.EndRefresh();
        }

        private async void DeleteAllPedido_Clicked(object sender, EventArgs e)
        {
            var Delete = await DisplayAlert("Tem Certeza?", "Quer deletar todos os pedidos?", "Sim", "Cancelar");
            if (Delete == true) // Sim
            {
                App.Meus_Pedidos.Clear();
                ListaCardapio.BeginRefresh();
                ListaCardapio.EndRefresh();
                DependencyService.Get<IMessage>().LongAlert("Todos os Itens foram Deletados");
            }
            else // Cancelar
            {
                return; 
            }           
        }

        #region ConfirmarIdentidade
        private void VerificarIdentidade()
        {
            try
            {
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
                throw;
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

        private void EnviarPedido()
        {
            // Apresentações iniciais!
            BreakLine = Environment.NewLine;
            Endereco = EntEndereco.Text + ", %20" + "Nº: " + EntNumero.Text + " - " + EntBairro.Text + " - %20" + EntCidade.Text + " - " + EntReferencia.Text + ".";
            ClienteDados = Application.Current.Properties["_Nome"] as string + " " + Application.Current.Properties["_Sobrenome"] as string;
            infoDados = "*MEUS DADOS:* " + BreakLine + ClienteDados + BreakLine + "*LOCAL DA ENTREGA:* " + BreakLine + Endereco;
            Saudacao = "Olá, " + Nome_Estabelecimento + "!%20 ";
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
                if (item.TrocaInfo != null)
                    newTrocaInfo = "_Info.: " + item.TrocaInfo + "_" + BreakLine;
                else
                    newTrocaInfo = "";
                // Itens Adicionais dos Pedidos!
                if (item.Adicionais_itens != null)
                    newItemAdicional = "_Adicionais: " + item.Adicionais_itens.TrimEnd() + "_" + BreakLine;
                else
                    newItemAdicional = "";

                MeuPedido += BreakLine + item.Quantidade + "x " + item.Tipo + " " + item.Nome + " "
                         + " - *Valor R$ " + item.ValorTotal + "*." + BreakLine + newTrocaInfo + newItemAdicional;
            }
            // Passando todo o pedido para a API do Whatsapp
            Device.OpenUri(new Uri("https://wa.me/" + Number_Whatsapp + "?text="
                   + Saudacao + "%20" + BreakLine + infoDados + BreakLine
                   + MeuPedido + BreakLine + 
                   "*VALOR FRETE:* " + Valor_Frete + BreakLine
                   + "*PAGAMENTO:* " + Tipo_Pagamento + BreakLine
                   + "*VALOR TOTAL:* " + lbl_Valor_Total.Text + BreakLine +
                     BreakLine +
                     Valor_Troco));
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
            if(Tipo_Dinheiro.IsChecked == true)
            {
                Tipo_Pagamento = "Dinheiro";                  
            }
            if(Tipo_Cartao.IsChecked == true)
            {
                Ent_Troco.Text = null;
                if(Juros_Cartao != "")
                {
                    Tipo_Pagamento =  String.Format(@"Cartão: R$ {0}\Juros", Juros_Cartao);
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
    }
}


