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
        }

        private void noveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vendasMensaisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form2 loginForm = new Form2();
            loginForm.MdiParent = this;
            if(!Form2.isLogged)
            {
                loginForm.Show();
            }
        }

        public void Atualizar(string nome)
        {
            toolStripButton6.Text = nome;
        }
        
    }
}
