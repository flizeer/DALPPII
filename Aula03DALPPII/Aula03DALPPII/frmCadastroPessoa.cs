using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models; //Para utilizar a camada MODELS depois de referncia ele.
using DAL;

namespace Aula03DALPPII
{
    public partial class frmCadastroPessoa : Form
    {
        public frmCadastroPessoa()
        {
            InitializeComponent(); 
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Pessoa objPessoa = new Pessoa();

            objPessoa.NmPessoa = txtNome.Text;
            objPessoa.NrCPF = mtdCPF.Text;
            objPessoa.DtNascimento = dtpDataNascimento.Value;
            objPessoa.DsLogradouro = txtLogradouro.Text;
            objPessoa.DsCidade = txtCidade.Text;
            objPessoa.DsUF = cbUF.Text;

            PessoaDAL pDAL = new PessoaDAL();
            pDAL.InserirPessoa(objPessoa);

            LimparCampos();
            CarregarPessoas();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TelaBuscar();
            int codigo = Convert.ToInt32(txtCdCliente.Text);
            PessoaDAL pDALL = new PessoaDAL ();
            Pessoa objPessoa = pDALL.SelecionarPessoaPeloCodigo(codigo);


            if (objPessoa != null)
            {
                txtNome.Text = objPessoa.NmPessoa;
                mtdCPF.Text = objPessoa.NrCPF;
                dtpDataNascimento.Value = objPessoa.DtNascimento;
                txtLogradouro.Text = objPessoa.DsLogradouro;
                txtCidade.Text = objPessoa.DsCidade;
                cbUF.Text = objPessoa.DsUF;
                
            }
            else
            {
                MessageBox.Show("Pessoa não encontrada");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            TelaInicial();
            Pessoa objPessoa = new Pessoa();

            objPessoa.CdPessoa = Convert.ToInt32(txtCdCliente.Text);
            objPessoa.NmPessoa = txtNome.Text;
            objPessoa.NrCPF = mtdCPF.Text;
            objPessoa.DtNascimento = dtpDataNascimento.Value;
            objPessoa.DsLogradouro = txtLogradouro.Text;
            objPessoa.DsCidade = txtCidade.Text;
            objPessoa.DsUF = cbUF.Text;

            PessoaDAL pDAL = new PessoaDAL();
            pDAL.AtualizarPessoa(objPessoa);
            LimparCampos();
            TelaInicial();
            CarregarPessoas();
        }

        private void btnExluir_Click(object sender, EventArgs e)
        {
            TelaInicial();
            if (MessageBox.Show("Tem certeza que deseja excluir esta pessoa ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) ;
            {
                int codigo = Convert.ToInt32(txtCdCliente.Text);
                PessoaDAL pDALL = new PessoaDAL();
                pDALL.ExcluirPessoa(codigo);

                MessageBox.Show("Pessoa Excluida com sucesso!!");
            }

            LimparCampos();
            CarregarPessoas();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            TelaInicial();
        }

        private void LimparCampos()
        {
            txtCdCliente.Text = string.Empty;
            txtNome.Text = string.Empty;
            mtdCPF.Text = string.Empty;
            dtpDataNascimento.Value = DateTime.Now;
            txtLogradouro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            cbUF.Text = string.Empty;
        }
        private void TelaInicial()
        {
            txtCdCliente.Enabled = true;
            btnBuscar.Enabled = true;
            btnAdicionar.Enabled = true;
            btnAtualizar.Enabled = false;
            btnExluir.Enabled = false;
       }
        private void TelaBuscar()
        {
            txtCdCliente.Enabled = false;
            btnBuscar.Enabled = false;
            btnAdicionar.Enabled = false;
            btnAtualizar.Enabled = true;
            btnExluir.Enabled = true;
        }

        private void frmCadastroPessoa_Load(object sender, EventArgs e)
        {
            TelaInicial();
            CarregarPessoas();
        }

        private void CarregarPessoas()
        {
            //código que vai preencher o dataGridView

            PessoaDAL pDAL = new PessoaDAL();

            dgvPessoas.DataSource = pDAL.ListarPessoas();
        }
    }
  
}
