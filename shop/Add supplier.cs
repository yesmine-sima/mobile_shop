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
    public partial class Add_supplier : Form
    {

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Add_supplier()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("insert into adsupplier(NICNumber,Name,Ph_Number,Email,Home_Address,Date) Values(@NICNumber,@Name,@Ph_Number,@Email,@Home_Address,@Date)", connection);

                        cmd.Parameters.AddWithValue("@NICNumber", textcnic.Text);
                        cmd.Parameters.AddWithValue("@Name", txtname.Text);
                        cmd.Parameters.AddWithValue("@Ph_Number", txtph.Text);

                        cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                        cmd.Parameters.AddWithValue("@Home_Address", textadress.Text);
                        cmd.Parameters.AddWithValue("@Date", this.dateTimePicker1.Text);
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        label7.ForeColor = System.Drawing.Color.Green;

                        label7.Text = "New Supplier Record Insert Successfully....";
                    }
                    
                   
                     catch (Exception )
            {
                MessageBox.Show("Please Insert Values As Required");
            }
                    
                    

                }




            }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Text = "";
                txtph.Text = "";
                textadress.Text = "";

                txtemail.Text = "";
                textcnic.Text = "";
                txtname.Text = "";

                txtph.Text = "";
                label7.ForeColor = System.Drawing.Color.Red;
                label7.Text = "Please Enter the New Record ....";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void label7_Click(object sender, EventArgs e)
        {

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

                sda = new SqlDataAdapter("select * from  adsupplier", con);
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
           
            
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Add_supplier_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from adsupplier Where Name like '%" + textBox1.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please search through Supplier name");
            }

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Visible = false;
                shop_Detail sd = new shop_Detail();
                sd.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

     
           
        }
      
    }

