using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace shop
{
    public partial class Expenses : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Expenses()
        {
            InitializeComponent();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            textBox4.Text = dateTimePicker1.Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into expen(Expenses_Title,Descripation,Amount,Date) Values(@Expenses_Title,@Descripation,@Amount,@Date)", connection);


                    cmd.Parameters.AddWithValue("@Expenses_Title",comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Descripation", textBox2.Text);

                    cmd.Parameters.AddWithValue("@Amount", textBox1.Text);
                     cmd.Parameters.AddWithValue("@Date", textBox4.Text);
                    
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label2.ForeColor = System.Drawing.Color.Green;

                    label2.Text = "Saved...";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                    


                




            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Visible = false;
                shop_Detail sd = new  shop_Detail();
                sd.Show();
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

        private void button7_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Ctrl_keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from expen Where Expenses_Title like '%" + textBox3.Text + "%'OR Amount like '%" + textBox3.Text + "%' OR Date like '%" + textBox3.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Please search through Expenses_Title OR Amount");
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
