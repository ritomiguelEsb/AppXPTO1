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
        Stream dataFile;
        string path = "./database/data.txt";
        public static Form3 instance;
        private Dictionary<int, Registo> dataBasedata;
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
        }



        private void button3_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Dispose();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            instance = null;
            this.Dispose();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardarFicheiro()
        {
            if (dataBasedata.Count < 1)
            {
                MessageBox.Show("Insira registos de avaria");
                return;
            }
            dataFile = new FileStream(path,FileMode.CreateNew, FileAccess.Write);
            StreamWriter stream = new StreamWriter(dataFile);
            for(int i=0; i < dataBasedata.Count;i++)
            {
                stream.Write(dataBasedata[i].codigo.ToString()+";");
                stream.Write(dataBasedata[i].dataTempo.ToString() + ";");
                stream.Write(dataBasedata[i].Nome.ToString() + ";");
                stream.Write(dataBasedata[i].telefone.ToString() + ";");
                stream.Write(dataBasedata[i].email.ToString() + ";");
                stream.Write(dataBasedata[i].avaria.ToString() + ";");
                stream.Write(dataBasedata[i].garantia.ToString() + ";");
                stream.Write(Environment.NewLine);

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
