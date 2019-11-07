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
    public partial class FInd_Record : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;


        public FInd_Record()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);

            sda = new SqlDataAdapter("select * from add_record" ,con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection connection = new SqlConnection(cs);
                connection.Open();
                SqlCommand cfd = new SqlCommand("UPDATE add_record SET Name ='" + textBox6.Text + "' ,   Price_fix ='" + textBox3.Text + "' ,  Quantity ='" + textBox2.Text + "',  Amount='" + textBox5.Text + "' ,  IMEI ='" + textBox7.Text + "'  where Id = '" + textBox4.Text + "'", connection);
                cfd.ExecuteNonQuery();

                connection.Close();
                connection.Close();
                label2.ForeColor = System.Drawing.Color.Green;

                label2.Text = "Your Record is  successfully Upload....";
            }
            catch (Exception )
            {
                MessageBox.Show("please check your Enter 15-digit ");
            }
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from add_record Where Name like '%" + textBox1.Text + "%'OR  IMEI like '%" + textBox1.Text + "%' OR Company like  '%" + textBox1.Text + "%'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Hide();
                owner_pannal op = new owner_pannal();
                op.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try{

            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[8].Value != null)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value.ToString());


                }
            } MessageBox.Show(sum.ToString());
        } catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox5.Text = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox5.Text = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            } 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox5.Text = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void FInd_Record_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox5.Text = "";
        }
    }
}
