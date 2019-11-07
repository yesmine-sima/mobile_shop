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
    public partial class owner_pannal : Form
    {
        public owner_pannal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Banking bn = new Banking();
                bn.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Bill_Record fn = new Bill_Record();
                fn.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Hide();
                shop_Detail sd = new shop_Detail();
                sd.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                add_Item_Record ud = new add_Item_Record();
                ud.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            update_Purchase pd = new update_Purchase();
            pd.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            FInd_Record fr = new FInd_Record();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment_Record fk = new Payment_Record();
            fk.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bank_S_N bsn = new Bank_S_N();
            bsn.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Purchase pr = new Purchase();
            pr.Show();
        }
    }
}
