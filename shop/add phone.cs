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
    public partial class add_phone : Form
    {
        public add_phone()
        {
            InitializeComponent();
        }

        private void add_phone_Load(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into addphone(Date,Company,Model_name,IMEI,colour,Purchase,sale,descripation) Values(@Date,@Company,@Model_name,@IMEI,@colour,@Purchase,@sale,@descripation)", connection);


                    cmd.Parameters.AddWithValue("@Date", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Company", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Model_name", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@IMEI", textBox2.Text);
                    cmd.Parameters.AddWithValue("@colour", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@Purchase", textBox3.Text);
                    cmd.Parameters.AddWithValue("@sale", textBox4.Text);
                    cmd.Parameters.AddWithValue("@descripation", textBox5.Text);




                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label5.ForeColor = System.Drawing.Color.Green;

                    label5.Text = "Save....";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";


                }




            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            show_ph_record sd = new show_ph_record();
            sd.Show();
        }
    }
}
