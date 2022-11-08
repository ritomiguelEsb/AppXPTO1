using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaçao
{
    public partial class Form2 : Form
    {

        private Dictionary<string, string> utilizadores = new Dictionary<string, string>();
        public static bool isLogged = false;

        public Form2()
        {
            InitializeComponent();
            utilizadores.Add("ProfPaulo", "69");
            utilizadores.Add("Rito", "passsecreta");
            utilizadores.Add("Guest", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var utilizador in utilizadores)
            {
                if(textBox2.Text == utilizador.Key && textBox1.Text == utilizador.Value)
                {
                    isLogged = true;
                    Form1.instance.AtualizarLoginNome(textBox2.Text);
                }
            }
            
            this.Close();
        }

    private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Shown(object sender, EventArgs e)
        {

        }
    }
}
