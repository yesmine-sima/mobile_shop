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
    public partial class update_owner_password : Form
    {
        public update_owner_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("select password from owner_login Where Password='" + textBox1.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count.ToString() == "1")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE owner_login SET Password='" + textBox3.Text + "' where password = '" + textBox1.Text + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    label1.ForeColor = System.Drawing.Color.Green;
                    label1.Text = "Your Password Is Successfully Updated....";
                }
                else
                { }

            }
            else
            {
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "Your Password Is Not Update Please Try Again??....";

            }
        }
         catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            owner_login ol = new owner_login();
            ol.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void update_owner_password_Load(object sender, EventArgs e)
        {

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
