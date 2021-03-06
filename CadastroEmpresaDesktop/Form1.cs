﻿using CadastroEmpresa;
using Refit;
using System;
using System.Data.Entity;
using System.Linq;
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

            txtCnpj.Enabled = true;
            txtNome.Enabled = true;
            txtFantasia.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            txtBairro.Enabled = false;
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
                        txtLogradouro.Text = empresa.Logradouro;
                        txtNumero.Text = empresa.Numero;
                        txtBairro.Text = empresa.Bairro;
                        txtAtividadePrincipal.Text = empresa.AtividadePrincipal[0].Text;
                        txtDataAbertura.Text = empresa.Abertura;
                        txtSituacao.Text = empresa.Situacao;

                        //Formatando o campo Capital Social para R$
                        txtCapitalSocial.Text = String.Format("{0:c}", (Convert.ToDouble(empresa.CapitalSocial)) / 100);

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
                txtCnpj.Focus();
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
                    MessageBox.Show($"{empresa.Nome} inserida no Banco de Dados com sucesso!", "Sucesso");

                    //Limpando componentes após inserção no banco de Dados
                    txtCnpj.Text = "";
                    txtNome.Text = "";
                    txtFantasia.Text = "";
                    txtLogradouro.Text = "";
                    txtNumero.Text = "";
                    txtBairro.Text = "";
                    txtAtividadePrincipal.Text = "";
                    txtDataAbertura.Text = "";
                    txtSituacao.Text = "";
                    txtCapitalSocial.Text = "";
                    txtCnpj.Focus();
                    empresa = null;
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
                txtCnpj.Focus();
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cnpjInformado = txtCnpj.Text;
            cnpjInformado = cnpjInformado.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ","");

            // Consulta por CNPJ da empresa
            if (cnpjInformado != "" && txtNome.Text == "")
            {
                //Validação do CNPJ
                if (ValidaCNPJ.IsCnpj(txtCnpj.Text))
                {
                    try
                    {
                        using (Context conn = new Context())
                        {
                            var consultaEmpresa = conn.Empresas.Where(a => a.Cnpj == txtCnpj.Text).FirstOrDefault();
                            conn.Entry(consultaEmpresa).Collection(p => p.AtividadePrincipal).Load();
                            conn.Entry(consultaEmpresa).Collection(s => s.AtividadesSecundarias).Load();
                            conn.Entry(consultaEmpresa).Collection(q => q.Qsa).Load();

                            txtNome.Text = consultaEmpresa.Nome;
                            txtFantasia.Text = consultaEmpresa.Fantasia;
                            txtLogradouro.Text = consultaEmpresa.Logradouro;
                            txtNumero.Text = consultaEmpresa.Numero;
                            txtBairro.Text = consultaEmpresa.Bairro;
                            txtAtividadePrincipal.Text = consultaEmpresa.AtividadePrincipal[0].Text;
                            txtDataAbertura.Text = consultaEmpresa.Abertura;
                            txtSituacao.Text = consultaEmpresa.Situacao;
                            txtCapitalSocial.Text = String.Format("{0:c}", (Convert.ToDouble(consultaEmpresa.CapitalSocial)) / 100);
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("CNPJ não encontrado!\nVerifique se essa empresa já foi inserida na base de dados.", "CNPJ erro");
                        txtCnpj.Text = "";
                        txtCnpj.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("Insira um CNPJ válido", "CNPJ Inválido");
                    txtCnpj.Text = "";
                    txtCnpj.Focus();
                }
            }

            //Consulta por Nome da empresa
            else if (cnpjInformado == "" && txtNome.Text != "")
            {
                try
                {
                    using (Context conn = new Context())
                    {
                        var consultaEmpresa = conn.Empresas.Where(a => a.Nome == txtNome.Text).FirstOrDefault();
                        conn.Entry(consultaEmpresa).Collection(p => p.AtividadePrincipal).Load();
                        conn.Entry(consultaEmpresa).Collection(s => s.AtividadesSecundarias).Load();
                        conn.Entry(consultaEmpresa).Collection(q => q.Qsa).Load();

                        txtCnpj.Text = consultaEmpresa.Cnpj;
                        txtFantasia.Text = consultaEmpresa.Fantasia;
                        txtLogradouro.Text = consultaEmpresa.Logradouro;
                        txtNumero.Text = consultaEmpresa.Numero;
                        txtBairro.Text = consultaEmpresa.Bairro;
                        txtAtividadePrincipal.Text = consultaEmpresa.AtividadePrincipal[0].Text;
                        txtDataAbertura.Text = consultaEmpresa.Abertura;
                        txtSituacao.Text = consultaEmpresa.Situacao;
                        txtCapitalSocial.Text = String.Format("{0:c}", (Convert.ToDouble(consultaEmpresa.CapitalSocial)) / 100);
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Nome não cadastrado!\nVerifique se essa empresa já foi inserida na base de dados.", "Nome erro");
                    txtNome.Text = "";
                    txtNome.Focus();
                }

            }

            //Consulta sem parâmetros de busca ou com dois parâmetros de busca
            else
            {
                MessageBox.Show("É possível fazer consulta apenas por CNPJ ou por Nome!\nDigite um CNPJ ou um Nome da empresa que deseja buscar no BD", "Consulta não definida");
                txtCnpj.Text = "";
                txtNome.Text = "";
                txtCnpj.Focus();
            }
            
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (ValidaCNPJ.IsCnpj(txtCnpj.Text))
            {
                if (MessageBox.Show("Você tem certeza que deseja excluir este Registro?", "Confirmação de Operação", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (Context conn = new Context())
                        {
                            var deleteEmpresa = conn.Empresas.Where(c => c.Cnpj == txtCnpj.Text).FirstOrDefault();
                            conn.Entry(deleteEmpresa).Collection(p => p.AtividadePrincipal).Load();
                            conn.Entry(deleteEmpresa).Collection(s => s.AtividadesSecundarias).Load();
                            conn.Entry(deleteEmpresa).Collection(q => q.Qsa).Load();
                            conn.Entry(deleteEmpresa).State = EntityState.Deleted;
                            conn.SaveChanges();
                            MessageBox.Show($"{deleteEmpresa.Nome} deletada com Sucesso!", "Exclusão");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("CNPJ não encontrado!\nVerifique se essa empresa já foi inserida na base de dados.", "CNPJ erro");
                        txtCnpj.Text = "";
                        txtCnpj.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Operação cancelada com Sucesso!","Operação cancelada");
                }
                
            }
            else
            {
                MessageBox.Show("Insira um CNPJ válido", "CNPJ Inválido");
                txtCnpj.Text = "";
                txtCnpj.Focus();
            }

            txtCnpj.Text = "";
            txtNome.Text = "";
            txtFantasia.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtAtividadePrincipal.Text = "";
            txtDataAbertura.Text = "";
            txtSituacao.Text = "";
            txtCapitalSocial.Text = "";
            txtCnpj.Focus();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLimparTela_Click(object sender, EventArgs e)
        {
            txtCnpj.Text = "";
            txtNome.Text = "";
            txtFantasia.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtAtividadePrincipal.Text = "";
            txtDataAbertura.Text = "";
            txtSituacao.Text = "";
            txtCapitalSocial.Text = "";
            txtCnpj.Focus();
        }
    }
}

/*TO DO/TRY
 * 1.Validação web service esta disponível?
 * 2.Corrigir bug do Adicionar
 * 3.Tentar desenvolver Web API - Swagger
 * 4.Tentar desenvolver solução MVC
 * 5.Tentar desenvolver testes unitários
 * 6.Preencher README.md
 */