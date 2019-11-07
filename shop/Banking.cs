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
    public partial class Banking : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Banking()
        {
            InitializeComponent();
        }

        private void Banking_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Banking(Date,Day,Amount) Values(@Date,@Day,@Amount)", connection);


                    cmd.Parameters.AddWithValue("@Date", dateTimePicker2.Text);
                    cmd.Parameters.AddWithValue("@Day", comboBox4.Text);


                    cmd.Parameters.AddWithValue("@Amount", comboBox3.Text);


                    cmd.ExecuteNonQuery();
                    connection.Close();
                    
                    label13.ForeColor = System.Drawing.Color.Green;

                    label13.Text = "Your Record is  successfully Upload....";
                }
                catch (Exception f)
                {
                    MessageBox.Show(f.Message);
                }
              
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = "";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[3].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value.ToString());


                    }
                } MessageBox.Show(sum.ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from  Banking", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Visible = false;
                owner_pannal sd = new owner_pannal();
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

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            label13.ForeColor = System.Drawing.Color.Red;
            label13.Text = "Please Enter the New Record ....";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from Banking Where Date like '%" + textBox1.Text + "%'OR Day like '%" + textBox1.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please search through Date OR Day");
            }
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        } 
    }
}
