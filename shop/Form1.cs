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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
             if(textBox1.Text   =="" ||textBox2.Text    =="")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
             
                SqlCommand cmd = new SqlCommand("Select * from login where username=@username and Password=@password",con);
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
            
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                  
                    this.Hide();
                    shop_Detail f1 = new shop_Detail();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch(Exception ex)
            {
                //show error
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar ='*';
              
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            textBox2.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void changepassword_Click(object sender, EventArgs e)
        {
            try{
            this.Hide();
            Update_Password ps = new Update_Password();
            ps.Show();
        } catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            About f1  = new About();
            f1.Show();
            
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      
      

      

        
    }
        }
    

