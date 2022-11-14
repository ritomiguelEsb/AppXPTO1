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
    public partial class Form4 : Form
    {
        public static Form4 instance;
        public Form4()
        {
           InitializeComponent();
            
            
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
                instance = this;
            }
            else
            {
                instance = this;
            }
            StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            if (Form3.instance != null)
            {
                Form3.instance.Close();
                Form3.instance.Dispose();
                Form4.instance = null;
            }
            listBox1.Items.Clear();
            for (int i = 1; i < Produtos.instance.getDictLenght(); i++)
            {
                var item = Produtos.instance.getProduct(i);
                listBox1.Items.Add();
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Dispose();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 1; i < Produtos.instance.getDictLenght() + 1; i++)
            {
                listBox1.Items.Add(Produtos.instance.getProduct(i));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Produtos.instance.addProdutos(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(comboBox1.Text), textBox2.Text);
        }
    }
}
