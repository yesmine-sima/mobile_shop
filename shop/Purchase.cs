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
    public partial class Purchase : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        int total = 0;
        public Purchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                

            
           
        }

        private void button2_Click(object sender, EventArgs e)
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

                sda = new SqlDataAdapter("select * from  Purchase_Order", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[8].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value.ToString());


                    }
                } textBox2.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[10].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString());


                    }
                } textBox3.Text = sum.ToString();
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

        private void button7_Click(object sender, EventArgs e)
            
        
      {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Visible = false;
                owner_pannal sd = new  owner_pannal();
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

        private void txtpurchase_TextChanged(object sender, EventArgs e)
        {
           
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void quntty_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from Purchase_Order Where  Party_Name like '%" + textBox1.Text + "%' OR Bill_number like '" + textBox1.Text + "' OR Item_Name like '%" + textBox1.Text + "%' OR Company_Name like '%" + textBox1.Text + "%'", con);

                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[8].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value.ToString());


                    }
                } textBox2.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[10].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value.ToString());


                    }
                } textBox3.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
          

        }

        private void Purchase_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        }
    
}
