using CadastroEmpresa;
using Refit;
using System;
using System.Windows.Forms;

namespace CadastroEmpresaDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configurando Componentes ao executar app
            btnAdicionar.Enabled = false;
            btnBuscar.Enabled = true;
            btnConsultar.Enabled = true;
            btnExcluir.Enabled = false;
            txtCnpj.Enabled = true;

            txtNome.Enabled = false;
            txtFantasia.Enabled = false;
            txtAtividadePrincipal.Enabled = false;
            txtDataAbertura.Enabled = false;
            txtSituacao.Enabled = false;
            txtCapitalSocial.Enabled = false;
        }

        private async void btnConsultar_ClickAsync(object sender, EventArgs e)
        {
            string cnpjInformado = txtCnpj.Text;

            //Removendo os caracteres do cnpj: ','; '/' e '-' para busca na web api
            cnpjInformado = cnpjInformado.Replace(".", "").Replace("/", "").Replace("-", "");

            // Criando rota para acesso à api e salvar a resposta na variavel empresa
            var cnpjEmpresa = RestService.For<EmpresaApiService>("https://www.receitaws.com.br");
            var empresa = await cnpjEmpresa.GetEmpresaAsync(cnpjInformado);

            //Mostrando alguns dados obtidos na web api

            txtNome.Text = empresa.Nome;
            txtFantasia.Text = empresa.Fantasia;
            txtAtividadePrincipal.Text = empresa.AtividadePrincipal[0].Text;
            txtDataAbertura.Text = empresa.Abertura;
            txtSituacao.Text = empresa.Situacao;

            double capitalSocial = Convert.ToDouble(empresa.CapitalSocial);
            capitalSocial /= 100; 
            txtCapitalSocial.Text = String.Format("{0:c}", capitalSocial);


            btnBuscar.Enabled = false;
            btnAdicionar.Enabled = true;

        }
    }
}
