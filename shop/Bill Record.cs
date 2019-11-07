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
    public partial class Bill_Record : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Bill_Record()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from invoice_t Where invoice_number like '" + textBox1.Text + "' OR Date like '%" + textBox1.Text + "%'OR Customer_Name like '%" + textBox1.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please Search through invoice_number OR Date OR Customer Namae");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from invoice_t ", con);
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
            
                scb = new SqlCommandBuilder(sda);
                sda.Update(dt);
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Bill_Record brg = new Bill_Record();
                brg.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                shop_Detail brg = new shop_Detail();
                brg.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Bill_Record_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet8.invoice_t' table. You can move, or remove it, as needed.
            //this.invoice_tTableAdapter.Fill(this.shopDataSet8.invoice_t);

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            try{
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

        }

        private void del_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
               
                sda = new SqlDataAdapter("select * from invoice_t Where Date BETWEEN '" + dateTimePicker1.Value + "' AND '" + dateTimePicker2.Value+ "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch (Exception)
            {
                MessageBox.Show("Please Search through invoice_number OR Date OR Customer Namae");
            }
        }
        }
    }

