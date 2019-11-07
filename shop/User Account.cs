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
    public partial class User_Account : Form
    {

        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public User_Account()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into User_Account(Name,User_Type,Email,ph_num) Values(@Name,@User_Type,@Email, @Ph_num)", connection);

                 
                    cmd.Parameters.AddWithValue("@Name", textname.Text);
                    cmd.Parameters.AddWithValue("@User_Type", comboBox1.Text);

                    cmd.Parameters.AddWithValue("@Ph_num", textph.Text);
                    cmd.Parameters.AddWithValue("@Email", textemail.Text);

                  
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label4.ForeColor=System.Drawing.Color.Green;
                    
                    label4.Text = "Your Record is  successfully Upload....";
                    
                }




            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void User_Account_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet5.User_Account' table. You can move, or remove it, as needed.
            //this.user_AccountTableAdapter1.Fill(this.shopDataSet5.User_Account);
            // TODO: This line of code loads data into the 'shopDataSet1.User_Account' table. You can move, or remove it, as needed.
            //this.user_AccountTableAdapter.Fill(this.shopDataSet1.User_Account);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                comboBox1.Text = "";
                textname.Text = "";
                textemail.Text = "";
                textph.Text = "";
                label4.ForeColor = System.Drawing.Color.Red;
                label4.Text = "Please Enter the New Record ....";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void record_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void del_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void Ctrl_keyUp(object sender, KeyEventArgs e)
        {

        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from User_Account Where Name like '%" + textBox1.Text + "%'OR User_Type like '%" + textBox1.Text + "%'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.Close();
        }

        
    }
}
