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
            instance = null;
            this.Dispose();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
