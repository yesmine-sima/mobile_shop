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
    public partial class use_wtch_record : Form
    {
        SqlDataAdapter sda;
        
        DataTable dt;
        public use_wtch_record()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);

                sda = new SqlDataAdapter("select Item_Name,Sale_Price,Quantity,sTotal_amount,Catagories,Colour,Company_Name,IMEI from Purchase_Order Where Item_Name like '%" + textBox1.Text + "%'", con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
    
       
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            shop_Detail de = new shop_Detail();
            de.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[4].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value.ToString());


                    }
                } MessageBox.Show(sum.ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void use_wtch_record_Load(object sender, EventArgs e)
        {

        }

    }
        }
        
    

