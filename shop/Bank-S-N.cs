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
    public partial class Bank_S_N : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public Bank_S_N()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into bank2(Name,Shop,Bnk_ac_num,Account_title,Amount,S_R,Date) Values(@Name,@Shop,@Bnk_ac_num,@Account_title,@Amount,@S_R,@Date)", connection);

                    
                    cmd.Parameters.AddWithValue("@Name", textname.Text);
                    cmd.Parameters.AddWithValue("@Shop", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Bnk_ac_num", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Account_title", textBox3.Text);

           
                    cmd.Parameters.AddWithValue("@Amount", textBox4.Text);
                    cmd.Parameters.AddWithValue("@S_R", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label1.ForeColor = System.Drawing.Color.Green;

                    label1.Text = "Your Record is  successfully Upload....";

                }




            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Values As Required");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
textname.Text="";
                   textBox1.Text="";

             textBox2.Text="";
                   textBox3.Text="";

           
                     textBox4.Text="";
                     textBox5.Text="";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            
        }

        private void button12_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                this.Visible = false;
                owner_pannal so = new owner_pannal();
                so.Show();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Ctrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void Bank_S_N_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from bank2 Where   Name like '%" + textBox8.Text + "%' OR  Date like '%" + textBox8.Text + "%' OR Bnk_ac_num like  '" + textBox8.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
