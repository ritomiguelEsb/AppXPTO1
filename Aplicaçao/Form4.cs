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
            AtualizarLista();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void AtualizarLista()
        {

            listBox1.Items.Clear();
            for (int i = 0; i < Produtos.instance.getDictLenght(); i++)
            {
                var item = new Produto();
                item = Produtos.instance.getProduct(i);
                listBox1.Items.Add(item.getID().ToString() + "| " + item.getNome().ToString() + " Preço:" + item.getPreco().ToString() + "€");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                var item = Produtos.instance.getProduct(listBox1.SelectedIndex);
                int id = item.getID();
                item.setAtributo(float.Parse(textBox3.Text), Convert.ToInt32(textBox1.Text), comboBox1.Text, textBox2.Text, id);
                AtualizarLista();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(object item in comboBox1.Items)
                {
                    if (item.ToString() == comboBox1.Text)
                    {
                        Produtos.instance.addProdutos(float.Parse(textBox3.Text), Convert.ToInt32(textBox1.Text), comboBox1.Text, textBox2.Text);
                        AtualizarLista();
                        return;
                    }
                }
                MessageBox.Show("Selecione uma categoria válida", "Erro ao adicionar");

            }
            catch
            {
                MessageBox.Show("Insira corretamente os dados", "Erro ao adicionar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >-1)
            {
                var item = Produtos.instance.getProduct(listBox1.SelectedIndex);
                textBox3.Text = item.getPreco().ToString();
                textBox1.Text = item.getCodigo().ToString();
                textBox2.Text = item.getNome().ToString();
                comboBox1.Text = item.getCategoria();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
