using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula03DALPPII
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void pessoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroPessoa telaPessoa = new frmCadastroPessoa();

            telaPessoa.MdiParent = this; //Para dizer em qual tela ele vai abrir.
            telaPessoa.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProduto telaProduto = new frmCadastroProduto();

            telaProduto.MdiParent = this;
            telaProduto.Show();
        }
    }
}
