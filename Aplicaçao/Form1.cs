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

        private void menuProdutos()
        {
            Form4 produtos = new Form4();
            produtos.MdiParent = this;
            produtos.Show();
        }

        private void menuVendas()
        {
            Form3 vendas = new Form3();
            vendas.MdiParent = this;
            vendas.Show();
        }

        private void noveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuProdutos();
        }

        private void vendasMensaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuVendas();
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
                    if(Form3.instance != null)
                    {                        
                        Form3.instance.Close();
                        Form3.instance.Dispose();
                        Form4.instance = null;
                    }
                    if (Form4.instance != null)
                    {
                        Form4.instance.Close();
                        Form4.instance.Dispose();
                        Form4.instance = null;
                    }
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

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuVendas();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuVendas();
        }

        private void listagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuProdutos();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuProdutos();
        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuProdutos();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuProdutos();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            toolStripStatusLabel1.Text = time;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
