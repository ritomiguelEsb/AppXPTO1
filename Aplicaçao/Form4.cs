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
            
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Produtos.instance.delProduct(valorID);
                AtualizarLista();
                MessageBox.Show("Produto " + valorID.ToString() + " foi apagado!" , "Aviso");
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.CurrentRow.Selected = false;
                }
                limparInputs();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Nome", "Nome");
            dataGridView1.Columns.Add("Categoria", "Categoria");
            dataGridView1.Columns.Add("Preco", "Preco");
            dataGridView1.Columns.Add("Codigo", "Codigo");
            AtualizarLista();
        }


        private void AtualizarLista()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Rows.Clear();
            dataGridView1.ReadOnly = true;
            for (int i =1; i < Produtos.instance.getDictLenght()+1; i++)
            {
                var item = new Produto();
                try
                {
                    item = Produtos.instance.getProduct(i);
                }
                catch
                {
                    Produtos.instance.changeDict(i);
                    AtualizarLista();
                    break;
                }
                dataGridView1.Rows.Add(item.getID().ToString(),item.getNome().ToString(),item.getCategoria(),item.getPreco().ToString() + "€", item.getCodigo());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var item = Produtos.instance.getProduct(valorID);
                item.setAtributo(float.Parse(textBox3.Text), Convert.ToInt32(textBox1.Text), comboBox1.Text, textBox2.Text, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                AtualizarLista();
                MessageBox.Show("Valores de produto " + valorID.ToString() + " foram alterados!", "Aviso");
                limparInputs();
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
                        MessageBox.Show("Novo produto adicionado!", "Aviso");
                        limparInputs();
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

        public void limparInputs()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.CurrentRow.Selected = false;
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {

                
                limparInputs();
            
            /*if (listBox1.SelectedIndex > -1)
            {
                MessageBox.Show(listBox1.SelectedIndex.ToString() + Produtos.instance.getDictLenght().ToString()+ Produtos.instance.getProduct(listBox1.SelectedIndex).getNome());
                AtualizarLista();
            }*/
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var item = Produtos.instance.getProduct(valorID);
                textBox3.Text = item.getPreco().ToString();
                textBox1.Text = item.getCodigo().ToString();
                textBox2.Text = item.getNome().ToString();
                comboBox1.Text = item.getCategoria();
            }
        }
    }
}
