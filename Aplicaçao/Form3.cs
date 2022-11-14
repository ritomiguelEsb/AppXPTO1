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
    public partial class Form3 : Form
    {
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

        public static Form3 instance;

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
    }
}
