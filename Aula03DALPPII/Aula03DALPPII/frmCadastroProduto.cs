using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace Aula03DALPPII
{
    public partial class frmCadastroProduto : Form
    {
        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Produto objProduto = new Produto();

            objProduto.NmProduto = txtNome.Text;
            objProduto.DsProduto = txtDescricao.Text;
            objProduto.VlProduto = Convert.ToDecimal(txtValor.Text);

            ProdutoDAL pDAL = new ProdutoDAL();
            pDAL.InserirProduto(objProduto);
            CarregarProdutos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);

            ProdutoDAL produtoDALL = new ProdutoDAL();

            produtoDALL.ExcluirProduto(codigo);
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            ProdutoDAL produtosDAL = new ProdutoDAL();

            dgvProdutos.DataSource = produtosDAL.ListarProdutos();
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
        }
    }
}
