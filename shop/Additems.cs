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
    public partial class Additems : Form
    {
        public Additems()
        {
            InitializeComponent();
        }

        private void Additems_Load(object sender, EventArgs e)
        {

        }
        void autocomp()
        {
            SqlConnection con = new SqlConnection(@"Data Source=ADMIN;Initial Catalog=shop;Integrated Security=True");
             var myConnection = new SqlConnection(textBox1.Text);
            myConnection.Open();
            AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
            string query = @"Select calagory from Catagories";
            SqlCommand cmd = new SqlCommand(query, myConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                    namesCollection.Add(dr["id"].ToString());

            }

            dr.Close();
            myConnection.Close();

           textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;

            }

    


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
