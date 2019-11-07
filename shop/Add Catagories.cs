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
    public partial class Add_Catagories : Form
    {
        public Add_Catagories()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Catagories(Catagory,Date) Values(@Catagory, @Date)", connection);


                    cmd.Parameters.AddWithValue("@Catagory", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date", textBox2.Text);

                    


                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label1.ForeColor = System.Drawing.Color.Green;

                    label1.Text = "Your Record is  successfully Upload....";

                }




            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Add_Catagories_Load(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Value.ToString();
        }
    }
}
