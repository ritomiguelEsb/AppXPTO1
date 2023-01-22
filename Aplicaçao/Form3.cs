using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaçao
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        private Registos registos;

        public Form3()
        {
            InitializeComponent();
            if(instance != null)
            {
                instance.Close();
                instance.Dispose();
                instance = this;
            }
            else
            {
                instance = this;
            }
            if(Form4.instance != null)
            {
                Form4.instance.Close();
                Form4.instance.Dispose();
                Form4.instance = null;
            }
            StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            registos = new Registos();

            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                Registos.instance.delProduct(valorID);
                AtualizarLista();
                MessageBox.Show("O Registo " + valorID.ToString() + " foi apagado!", "Aviso");
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.CurrentRow.Selected = false;
                }
                limparInputs();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Código", "Código");
            dataGridView1.Columns.Add("Cliente", "Cliente");
            dataGridView1.Columns.Add("Data", "Data");
            dataGridView1.Columns.Add("Contacto", "Contacto");
            dataGridView1.Columns.Add("Descrição", "Descrição");
            dataGridView1.Columns.Add("Garantia", "Garantia");
            AtualizarLista();
        }

        //Funções
        private bool checkInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return true;
            try
            {
                Convert.ToInt32(textBox1.Text);
                Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text)) return true;
            if (string.IsNullOrWhiteSpace(textBox3.Text)) return true;
            if (string.IsNullOrWhiteSpace(textBox4.Text)) return true;
            if (string.IsNullOrEmpty(comboBox1.Text)) return true;
            return false;
                
        }

        private void AtualizarLista()
        {
            dataGridView1.Rows.Clear();

            for (int i = 1; i < Registos.instance.getDictLenght() + 1; i++)
            {
                Registo item;
                try
                {
                  item = Registos.instance.getRegisto(i);
                }
                catch
                {
                    Registos.instance.changeDict(i);
                    AtualizarLista();
                    break;
                }
                string souN;
                if(item.getGarantia())
                {
                    souN = "Sim";
                }
                else
                {
                    souN = "Não";
                }
                dataGridView1.Rows.Add(item.getID(), item.getCodigo().ToString(), item.getNome(), item.getDataTempo().Value, item.getTelefone(),item.getAvaria(), souN);
            }
        }

        private void limparInputs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            checkBox1.Checked = false;
        }


        //Botões

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkInputs()) throw new Exception("Preencha todos os espaços corretamente");
                Registos.instance.addRegisto(new Registo(Registos.instance.getDictLenght() + 1, Convert.ToInt32(textBox1.Text), dateTimePicker1, textBox4.Text, Convert.ToInt64(textBox2.Text), textBox3.Text, comboBox1.Text, checkBox1.Checked));
                AtualizarLista();
                limparInputs();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Aviso!");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Registos.instance.lerFicheiro();
            AtualizarLista();
            MessageBox.Show("Alterações desfeitas");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                var item = Registos.instance.getRegisto(valorID);
                textBox1.Text = item.getCodigo().ToString();
                textBox2.Text = item.getTelefone().ToString();
                textBox3.Text = item.getEmail().ToString();
                textBox4.Text = item.getNome();
                checkBox1.Checked = item.getGarantia();
                comboBox1.Text = item.getAvaria();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int valorID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var item = Registos.instance.getRegisto(valorID);
            if (checkInputs()) throw new Exception("Preencha todos os espaços corretamente");
            item.setAtributo(item.getID(), Convert.ToInt32(textBox1.Text), dateTimePicker1, textBox4.Text, Convert.ToInt64(textBox2.Text), textBox3.Text, comboBox1.Text, checkBox1.Checked);
            limparInputs();
            AtualizarLista();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Registos.instance.guardarFicheiro();
        }
    }
}
