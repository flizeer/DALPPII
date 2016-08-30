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

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
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
        }
    }
}
