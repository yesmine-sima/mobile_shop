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
    public partial class Payment_Record : Form
    {

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Payment_Record()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from  Payment_Record", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            { }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
           

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            shop_Detail inv = new shop_Detail();
            inv.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            invoice invg = new invoice();
           invg.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from Payment_Record Where invoice_number like '" + textBox1.Text + "'OR customer_name like '%" + textBox1.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please search through Customer Name OR INvoice Number");
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
        }

        private void Payment_Record_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}