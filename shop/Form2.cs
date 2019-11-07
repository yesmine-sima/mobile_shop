using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.progressBar1.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            label6.Text = progressBar1.Value.ToString() + "%".ToString();
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Hide();
                Form1 d = new Form1();
                d.Show();

                return;
            }
        }
    }
}
