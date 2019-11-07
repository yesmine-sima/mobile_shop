using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace shop
{
    public partial class show_ph_record : Form
    {
        SqlDataAdapter sda;

        DataTable dt;
        public show_ph_record()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from addphone Where Model_Name like '%" + textBox1.Text + "%'OR  IMEI like '%" + textBox1.Text + "%' OR Company like  '%" + textBox1.Text + "%'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());


                    }
                } textBox2.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }


            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[7].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());


                    }
                } textBox3.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

            try
            {
                if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox4.Text = (Convert.ToDouble(textBox3.Text) - Convert.ToDouble(textBox2.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                sda = new SqlDataAdapter("select * from addphone", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());


                    }
                } textBox2.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[7].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value.ToString());


                    }
                } textBox3.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

            try
            {
                if (!string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox4.Text = (Convert.ToDouble(textBox3.Text) - Convert.ToDouble(textBox2.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            add_phone isd = new add_phone();
            isd.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
