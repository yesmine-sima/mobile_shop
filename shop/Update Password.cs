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
    public partial class Update_Password : Form
    {
        public Update_Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{

            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("select password from login Where Password='"+textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count.ToString() == "1")
            {
                if (textBox2.Text == textBox3.Text)
                {
                    con.Open();
                    SqlCommand  cmd= new SqlCommand("UPDATE login SET Password='" + textBox3.Text + "' where password = '" + textBox1.Text + "'", con);

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
                label1.Text = "Your Password Is Not Update Please Try Again....";
            
            }
        } catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
            textBox3.PasswordChar = '*';
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 ol = new Form1();
            ol.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Update_Password_Load(object sender, EventArgs e)
        {

        }

        
    }
}
