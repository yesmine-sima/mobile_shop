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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(textquantiy.Text) && !string.IsNullOrEmpty(textnumberofitem.Text))
                {
                    textBox1.Text = (Convert.ToDouble(textquantiy.Text) * Convert.ToDouble(textnumberofitem.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into add_record(Date,Name,Quantity,Cabin_Number,Price_fix,Company,Amount,[User],catagories,Id2,IMEI) Values(@Date,@Name,@Quantity,@Cabin_Number,@Price_fix,@Company,@Amount,@User,@catagories,@Id2,@IMEI)", connection);

                    cmd.Parameters.AddWithValue("@Date",this.dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Quantity", textquantiy.Text);

                    cmd.Parameters.AddWithValue("@Cabin_Number", textcabin.Text);
                    cmd.Parameters.AddWithValue("@Price_fix", textnumberofitem.Text);

                    cmd.Parameters.AddWithValue("@Company", textcompanynam.Text);
                    cmd.Parameters.AddWithValue("@Id2", textBox2.Text);

                    cmd.Parameters.AddWithValue("@Amount", textBox1.Text);
                    cmd.Parameters.AddWithValue("@User", textuser.Text);
                    cmd.Parameters.AddWithValue("@catagories", textname.Text);
                    cmd.Parameters.AddWithValue("@IMEI", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label2.ForeColor=System.Drawing.Color.Green;
                    
                    label2.Text = "Your Record is  successfully Upload....";
                    
                }




            }
            catch (Exception )
            {
                MessageBox.Show("please check your Enter 15-digit ");
            }
        }
      

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                dateTimePicker1.Text = "";
                textname.Text = "";
                textquantiy.Text = "";
                textBox3.Text = "";
                textcabin.Text = "";
                textnumberofitem.Text = "";
                textcompanynam.Text = "";
                textuser.Text = "";
                label2.ForeColor = System.Drawing.Color.Red;
                label2.Text = "Please Enter the New Record ....";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
             shop_Detail fr = new shop_Detail();
            fr.Show();
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
            this.Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        void com3()
        {

            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string s = "select * from Purchase_Order";
            DataTable dt = new DataTable();
            dt = db.bind(s);
            comboBox1.DisplayMember = "Item_Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dt;
        
        
        }
        private void Main_Load(object sender, EventArgs e)
        {
            com3();
            comboBox1.Text = "";
            textquantiy.Text = "";
            textname.Text = "";
            textcompanynam.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3V7KQ4B\SQLEXPRESS;Initial Catalog=shop;Integrated Security=True");
            //    if (comboBox1.SelectedValue != null)
            //    {
            //        String s = "select  Item_Name  from Purchase_Order where Name='" + comboBox1.SelectedItem + "' ";

            //        SqlCommand cmm = new SqlCommand(s, con);
            //        con.Open();
            //        SqlDataReader sda = cmm.ExecuteReader();
            //        DataTable dt = new DataTable();
            //        dt.Load(sda);
            //    }

            //    //textBox2.Text = dt.ToString();

            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show(f.Message);
            //}

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda;
                DataTable dt;

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select Quantity,Company_Name,Catagories,Id,IMEI from Purchase_Order Where Item_Name like '" + comboBox1.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    textquantiy.Text = row[0].ToString();
                    textcompanynam.Text = row[1].ToString();
                    textname.Text = row[2].ToString();
                   textBox2.Text = row[3].ToString();
                   textBox3.Text = row[4].ToString();

                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

        }
    }
}

              
                
