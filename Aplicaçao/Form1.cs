using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaçao
{
    public partial class Form1 : Form
    {
        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
            HabilitarFunc(false);
        }

        private void menuVendas()
        {
            Form3 produtos = new Form3();
            produtos.MdiParent = this;
            produtos.Show();
        }

        private void noveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuVendas();
        }

        private void vendasMensaisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            if(!Form2.isLogged)
            {
                Form2 loginForm = new Form2();
                loginForm.MdiParent = this;
                loginForm.Show();
            }
            else
            {
                DialogResult result = MessageBox.Show("Deseja fazer o logout?","Logout", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Form1.instance.HabilitarFunc(false);
                    Form2.isLogged = false;
                    AtualizarLoginNome("Login");
                }
            }
        }

        public void HabilitarFunc(bool habilitar)
        {
            abrirToolStripMenuItem.Enabled = habilitar;
            vendaToolStripMenuItem.Enabled = habilitar;
            produtosToolStripMenuItem.Enabled = habilitar;
            toolStripButton1.Enabled = habilitar;
            toolStripButton2.Enabled = habilitar;
            toolStripButton3.Enabled = habilitar;
            toolStripButton4.Enabled = habilitar;
            toolStripButton5.Enabled = habilitar;
        }

        public void AtualizarLoginNome(string nome)
        {
            toolStripButton6.Text = nome;
        }
        
    }
}
