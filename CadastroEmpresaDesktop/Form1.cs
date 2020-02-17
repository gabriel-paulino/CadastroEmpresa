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
            btnExcluir.Enabled = true;
            txtCnpj.Enabled = true;

            txtNome.Enabled = true;
            txtFantasia.Enabled = false;
            txtAtividadePrincipal.Enabled = false;
            txtDataAbertura.Enabled = false;
            txtSituacao.Enabled = false;
            txtCapitalSocial.Enabled = false;
        }

        private async void btnConsultar_ClickAsync(object sender, EventArgs e)
        {

            string cnpjInformado = txtCnpj.Text;

            //Validação do CNPJ

            if (ValidaCNPJ.IsCnpj(cnpjInformado))
            {
                //CNPJ Válido:

                try
                {
                    //Removendo os caracteres do cnpj: ','; '/' e '-' para busca na web service
                    cnpjInformado = cnpjInformado.Replace(".", "").Replace("/", "").Replace("-", "");

                    // Criando rota para acesso ao web service e salvar a resposta na variavel empresa
                    var cnpjEmpresa = RestService.For<EmpresaApiService>("https://www.receitaws.com.br");
                    var empresa = await cnpjEmpresa.GetEmpresaAsync(cnpjInformado);

                    if (empresa.Status == "OK")
                    {
                        //Mostrando alguns dados obtidos na web service
                        txtNome.Text = empresa.Nome;
                        txtFantasia.Text = empresa.Fantasia;
                        txtAtividadePrincipal.Text = empresa.AtividadePrincipal[0].Text;
                        txtDataAbertura.Text = empresa.Abertura;
                        txtSituacao.Text = empresa.Situacao;

                        //Formatando o campo Capital Social para R$
                        txtCapitalSocial.Text = String.Format("{0:c}", (Convert.ToDouble(empresa.CapitalSocial)) / 100);

                        btnBuscar.Enabled = false;
                        btnAdicionar.Enabled = true;
                        empresa = null;
                    }
                    else
                    {
                        MessageBox.Show("CNPJ rejeitado pela Receita Federal", "Erro");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show($"Erro:  {erro.Message}", "Falha na Requisição");
                }

            }
            else
            {
                MessageBox.Show("Insira um CNPJ válido", "CNPJ Inválido");
                txtCnpj.Text = "";
            }
        }

        private async void btnAdicionar_Click(object sender, EventArgs e)
        {
            string cnpjInformado = txtCnpj.Text;

            if (ValidaCNPJ.IsCnpj(cnpjInformado))
            {
                try
                {
                    cnpjInformado = cnpjInformado.Replace(".", "").Replace("/", "").Replace("-", "");
                    var cnpjEmpresa = RestService.For<EmpresaApiService>("https://www.receitaws.com.br");
                    var empresa = await cnpjEmpresa.GetEmpresaAsync(cnpjInformado);

                    using (Context conn = new Context())
                    {
                        conn.Empresas.Add(new CadastroEmpresa.Serialization.Empresa()
                        {
                            Cnpj = empresa.Cnpj,
                            DataSituacao = empresa.DataSituacao,
                            Nome = empresa.Nome,
                            Efr = empresa.Efr,
                            Uf = empresa.Uf,
                            Telefone = empresa.Telefone,
                            Email = empresa.Email,
                            Situacao = empresa.Situacao,
                            Bairro = empresa.Bairro,
                            Logradouro = empresa.Logradouro,
                            Numero = empresa.Numero,
                            Cep = empresa.Cep,
                            Municipio = empresa.Municipio,
                            Porte = empresa.Porte,
                            Abertura = empresa.Abertura,
                            NaturezaJuridica = empresa.NaturezaJuridica,
                            Fantasia = empresa.Fantasia,
                            UltimaAtualizacao = empresa.UltimaAtualizacao,
                            Status = empresa.Status,
                            Tipo = empresa.Tipo,
                            Complemento = empresa.Complemento,
                            MotivoSituacao = empresa.MotivoSituacao,
                            SituacaoEspecial = empresa.SituacaoEspecial,
                            DataSituacaoEspecial = empresa.DataSituacaoEspecial,
                            CapitalSocial = empresa.CapitalSocial,
                            AtividadePrincipal = empresa.AtividadePrincipal,
                            AtividadesSecundarias = empresa.AtividadesSecundarias,
                            Qsa = empresa.Qsa
                        });
                        conn.SaveChanges();
                    }
                    MessageBox.Show("Empresa inserida no Banco de Dados com sucesso!", "Sucesso");

                    //Limpando componentes após inserção no banco de Dados
                    txtCnpj.Text = "";
                    txtNome.Text = "";
                    txtFantasia.Text = "";
                    txtAtividadePrincipal.Text = "";
                    txtDataAbertura.Text = "";
                    txtSituacao.Text = "";
                    txtCapitalSocial.Text = "";
                    empresa = null;
                    txtCnpj.Focus();
                }
                catch (Exception err)
                {
                    MessageBox.Show($"Erro na Inserção da Empresa no Banco de Dados:  {err.Message}", "Falha");
                }

            }
            else
            {
                MessageBox.Show("Insira um CNPJ válido", "CNPJ Inválido");
                txtCnpj.Text = "";
            }

        }
    }
}
