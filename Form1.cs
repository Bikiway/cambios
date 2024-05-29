using cambios.Modelos;
using cambios.Servicos;

namespace cambios
{
    public partial class Form1 : Form
    {
        #region
        private NetworkService networservice;
        private ApiService apiservice;
        private List<Rate> rates;
        private DialogService dialogservice;
        private DataService dataService;
        #endregion
        public Form1()
        {
            InitializeComponent();
            rates = new List<Rate>();
            networservice = new NetworkService();
            apiservice = new ApiService();
            dialogservice = new DialogService();
            dataService = new DataService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load;

            lbl_resultado.Text = "A atualizar taxas";

            var connection = networservice.CheckConnection(); //Faz a connec��o

            if (!connection.IsCompletedSuccessfully) //Caso n�o tenha sucesso
            {
                LoadLocalRates();
                load = false;
            }
            else
            {
                await LoadApiRates();
                load = true;
            }

            if (rates.Count == 0)
            {
                lbl_resultado.Text = "N�o h� liga��o � internet" + Environment.NewLine +
                    "e n�o foram previamente carregadas as taxaas." + Environment.NewLine +
                    "Tente mais tarde!";

                lbl_status.Text = "N�o tem liga��o � internet";
                return;
            }

            cbx_Origem.DataSource = rates; //Come�a no Euro
            cbx_Origem.DisplayMember = "Currency";

            cbx_Origem.BindingContext = new BindingContext(); //Tem um binding diferente para carregar as moedas. E assim corrige bug da microsoft.

            cbx_Destino.DataSource = rates.OrderBy(x => x.Currency).ToList();
            cbx_Destino.DisplayMember = "Currency";


            btn_converter.Enabled = true;
            btn_troca.Enabled = true;

            lbl_resultado.Text = "Taxas Atualizadas!";

            if (load == true)
            {
                lbl_status.Text = string.Format("Taxas carregdas da internet em {0:F}", DateTime.Now);
            }
            else
            {
                lbl_status.Text = string.Format("Taxas carregdas da Base de Dados.");
            }

            progressBar1.Value = 100;
        }


        private void LoadLocalRates()
        {
            rates = dataService.GetData(); //Quando n�o houver internet, ele vai buscar a lista guardada na Base de Dados. LoadRates()
        }

        private async Task LoadApiRates()
        {
            progressBar1.Value = 0;

            var response = await apiservice.GetRates("http://ec.europa.eu", "/budg/inforeuro/api/public/monthly-rates"); //Carrega a API

            rates = (List<Rate>)response.Result;

            //Primeiro tem que apagar para depois guardar

            dataService.DeleteData();

            //Guardar na Base de Dados

            dataService.SaveData(rates);
        }

        private void btn_converter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            if (string.IsNullOrEmpty(txt_valor.Text))
            {
                dialogservice.ShowMessage("Erro", "Insira um valor a converter");
                return;
            }

            decimal valor;

            if (!decimal.TryParse(txt_valor.Text, out valor))
            {
                dialogservice.ShowMessage("Erro de convers�o", "Valor ter� que ser num�rico");
                return;
            }

            if (cbx_Origem.SelectedItem == null)
            {
                dialogservice.ShowMessage("Erro", "Tem que selecionar uma moeda.");
                return;
            }

            if (cbx_Destino.SelectedItem == null)
            {
                dialogservice.ShowMessage("Erro", "Tem que selecionar uma moeda.");
                return;
            }

            var taxaOrigem = (Rate)cbx_Origem.SelectedItem;
            var taxaDestino = (Rate)cbx_Destino.SelectedItem;

            var valorConvertido = valor / taxaOrigem.Value * taxaDestino.Value;
            lbl_resultado.Text = string.Format("{0} {1:C2} = {2} {3:C2}", valor, taxaOrigem.IsoA2Code, valorConvertido, taxaDestino.IsoA3Code);

        }

        private void btn_troca_Click(object sender, EventArgs e)
        {
            Trocar();
        }

        public void Trocar()
        {
            var aux = cbx_Origem.SelectedItem;
            cbx_Origem.SelectedItem = cbx_Destino.SelectedItem;

            cbx_Destino.SelectedItem = aux;
            Converter();
        }
    }
}