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
using shop.Properties;

namespace shop
{
    public partial class invoice : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public invoice()
        {
            InitializeComponent();
        }
        private List<Cartitems> shoppingcard = new List<Cartitems>();
        void com1()
        {
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string s = "select * from adsupplier";
            DataTable dt = new DataTable();
            dt = db.bind(s);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.DataSource = dt;
            
        }
        void com2()
        {
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            string s = "select * from Purchase_Order";
            DataTable dt = new DataTable();
            dt = db.bind(s);
            comboBox2.DisplayMember = "Item_Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = dt;


           
            
               
        }
        //void com3()
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        //    SqlConnection con = new SqlConnection(cs);
        //    string s = "select * from addphone";
        //    DataTable dt = new DataTable();
        //    dt = db.bind(s);
        //    comboBox3.DisplayMember = "Model_Name";
        //    comboBox3.ValueMember = "Id";
        //    comboBox3.DataSource = dt;
        //}
        
        private void invoice_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            //comboBox1.Text = "";
            //comboBox2.Text = "";
          //  
            // TODO: This line of code loads data into the 'shopDataSet6.invoice_t' table. You can move, or remove it, as needed.
           // this.invoice_tTableAdapter.Fill(this.shopDataSet6.invoice_t);
            string miv = "select Max(invoice_number) from invoice_t";
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmm = new SqlCommand(miv, con);
            con.Open();
            SqlDataReader sda = cmm.ExecuteReader();
            DataTable idmax = new DataTable("idmax");
            idmax.Load(sda);
            if (idmax.Rows[0][0].ToString().Trim() == "")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = Convert.ToString(Convert.ToUInt32(idmax.Rows[0][0]) + 1);

            }
        
            com1();
            com2();
            //com3();
            //comboBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
       
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlDataAdapter sda;
            //    DataTable dt;

            //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3V7KQ4B\SQLEXPRESS;Initial Catalog=shop;Integrated Security=True");
            //    sda = new SqlDataAdapter("select * from adsupplier Where Name like '%" + comboBox1.Text + "%'", con);
            //    dt = new DataTable();
            //    sda.Fill(dt);
            //    //dataGridView1.DataSource = dt;
            //}
            //catch (Exception f)
            //{
            //    MessageBox.Show(f.Message);
            //}
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda;
                DataTable dt;

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from Purchase_Order Where Item_Name like '" + comboBox2.Text + "'", con);
                dt = new DataTable();
                sda.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    textBox2.Text = row["Sale_Price"].ToString();
                    textBox6.Text = row["Quantity"].ToString();
                    textBox10.Text = row["sTotal_amount"].ToString();
                    textBox12.Text = row["Id"].ToString();
                    textBox14.Text = row["IMEI"].ToString();
                    textBox15.Text = row["Catagories"].ToString();


                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }

           
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3V7KQ4B\SQLEXPRESS;Initial Catalog=shop;Integrated Security=True");
            //    if (comboBox2.SelectedValue != null)
            //    {
            //        String s = "select  Price_fix  from  add_record where Name='" + comboBox2.SelectedItem + "' ";

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox4.Text = (Convert.ToDouble(textBox2.Text) * Convert.ToDouble(textBox3.Text)).ToString();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
            try
            {
                if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
                {
                    textBox7.Text = (Convert.ToDouble(textBox6.Text) - Convert.ToDouble(textBox3.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                  




                }




            
            

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                label13.ForeColor = System.Drawing.Color.Red;

                label13.Text = "Please Enter the New Record....";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                textBox11.Text = "";
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void show_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bill_Record br = new Bill_Record();
            br.Show();
            

        }

        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument1;
                printDialog.UseEXDialog = true;
                //Get the document
                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printDocument1.DocumentName = "Bill Print";
                    printDocument1.Print();
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Image image = Resources.jerry;
                e.Graphics.DrawImage(image, 235, 10, image.Width, image.Height);
                e.Graphics.DrawString("Invoice_Number: " + textBox1.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 130));
                e.Graphics.DrawString("Previous Total: " + textBox16.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 130));
                e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 160));
                e.Graphics.DrawString("Customer Name: " + comboBox1.Text.Trim(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(25, 190));
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, 230));
                e.Graphics.DrawString("Item Name", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(30, 250));
                e.Graphics.DrawString("Quantity", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(300, 250));
                e.Graphics.DrawString("Price", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(510, 250));
              

                e.Graphics.DrawString("Total Amount", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(660, 250));
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, 270));
                int ypos = 295;
                foreach (var i in shoppingcard)
                {

                    e.Graphics.DrawString(i.Item_Name, new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(40, ypos));
                    e.Graphics.DrawString(i.Quantity.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(320, ypos));
                    e.Graphics.DrawString(i.Price.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(510, ypos));
                   
                    e.Graphics.DrawString(i.Total_Amount.ToString(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(690, ypos));
                    ypos = ypos + 30;
                }
                e.Graphics.DrawString("--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(0, ypos));

                e.Graphics.DrawString("Total Bill:" + textBox5.Text.Trim(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(560, ypos + 30));
                e.Graphics.DrawString("Customer Payment:" + textBox8.Text.Trim(), new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(560, ypos + 60));
              

                e.Graphics.DrawString("Thanks For Your Business!", new Font("Arial", 11, FontStyle.Regular), Brushes.Black, new Point(290, ypos + 120));
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                    {
                        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value.ToString());


                    }
                } textBox5.Text = sum.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into invoice_t(invoice_number, customer_name,product_name,Price,Quantity,total_Amount,Date) Values(@invoice_number,@customer_name,@product_name,@Price,@Quantity,@total_Amount,@Date)", connection);
                    cmd.Parameters.AddWithValue("@invoice_number", textBox1.Text);
                    cmd.Parameters.AddWithValue("@customer_name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@product_name", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Quantity", textBox3.Text);
                    cmd.Parameters.AddWithValue("@total_Amount", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                  

                   
                    connection.Open();
                    SqlCommand cod = new SqlCommand("UPDATE Purchase_Order SET sTotal_amount='" + textBox11.Text + "' where Id = '" + textBox12.Text + "'", connection);
                    cod.ExecuteNonQuery();


                    connection.Close();
                    connection.Open();
                    SqlCommand cfdi = new SqlCommand("UPDATE Purchase_Order SET Quantity='" + textBox7.Text + "'    where Id = '" + textBox12.Text + "'", connection);
                    cfdi.ExecuteNonQuery();

                    connection.Close();
                    label13.ForeColor = System.Drawing.Color.Green;

                    label13.Text = "Your Record is  successfully Upload....";





                }




            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            
            try{
            Cartitems item = new Cartitems()
            {

                Item_Name = comboBox2.Text,
                Price = Convert.ToInt32(textBox2.Text.Trim()),
                Quantity = Convert.ToInt32(textBox3.Text.Trim()),
                Total_Amount = Convert.ToInt32(textBox4.Text.Trim()),


            };
            shoppingcard.Add(item);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = shoppingcard;
            decimal totalamo = shoppingcard.Sum(x => x.Total_Amount);
            textBox5.Text = totalamo.ToString();
        }
         catch (Exception )
                {
                    MessageBox.Show("Please Put All Values ");
                }
          
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox10.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
        
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Bill_Record br = new Bill_Record();
            br.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda;
                DataTable dt;

                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                sda = new SqlDataAdapter("select * from adsupplier Where Name = '" + comboBox1.Text + "'", con);
             //   sda = new SqlDataAdapter("select * from adsupplier Where Name like '%" + comboBox1.Text + "%'", con);
                
                dt = new DataTable();
                sda.Fill(dt);

                //dataGridView1.DataSource = dt;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            SqlDataAdapter sdao;
            DataTable dti;

            string cs0 = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection con0 = new SqlConnection(cs0);
            con0.Open();
            //SELECT SUM(Remaining_Payment) as total from Payment_Record where customer_name= 'usama'
            SqlCommand cmd = new SqlCommand(" SELECT SUM(Remaining_Payment) as total from Payment_Record where customer_name='"+comboBox1.Text+"'", con0);
            object result=cmd.ExecuteScalar();
            if (result != null)
            {
                textBox16.Text = result.ToString(); 

            }
            else
            {

                label20.ForeColor = System.Drawing.Color.Green;
                label20.Text = "no previous record....";
               
            }  
            con0.Close();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            invoice iv = new invoice();
            iv.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }  
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox8.Text))
                {
                    textBox9.Text = (Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox8.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(cs))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Payment_Record(invoice_number,Date, customer_name,Total_Amount,Customer_Payment,Remaining_Payment) Values(@invoice_number,@Date, @customer_name,@Total_Amount,@Customer_Payment,@Remaining_Payment)", connection);
                    cmd.Parameters.AddWithValue("@invoice_number", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Date",  DateTime.Now);
                    cmd.Parameters.AddWithValue("@customer_name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Total_Amount", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Customer_Payment", textBox8.Text);

                    cmd.Parameters.AddWithValue("@Remaining_Payment", textBox9.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    label6.ForeColor = System.Drawing.Color.Green;

                    label6.Text = "Your Record is  successfully Upload....";
                    connection.Open();
                    

                    connection.Close();





                }




            }
            catch (Exception )
            {
                MessageBox.Show("Invoice Number,Date,Customer Name,Total Payment, Customer Payment, Remaining Payment ");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    var hti = dataGridView1.HitTest(e.X, e.Y);
                    dataGridView1.Rows[hti.RowIndex].Selected = true;
                    contextMenuStrip1.Show(dataGridView1, e.X, e.Y);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                shoppingcard.RemoveAt(index);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = shoppingcard;
                decimal totalamo = shoppingcard.Sum(x => x.Total_Amount);
                textBox5.Text = totalamo.ToString();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
           
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Payment_Record pr = new Payment_Record();
            pr.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(textBox10.Text) && !string.IsNullOrEmpty(textBox4.Text))
                {
                    textBox11.Text = (Convert.ToDouble(textBox10.Text) - Convert.ToDouble(textBox4.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please Insert Value In Digits");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        //private void comboBox3_TextChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        SqlDataAdapter sda;
        //        DataTable dt;

        //        string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        //        SqlConnection con = new SqlConnection(cs);
        //        sda = new SqlDataAdapter("select * from addphone Where Model_Name like '" + comboBox3.Text + "'", con);
        //        dt = new DataTable();
        //        sda.Fill(dt);
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            textBox2.Text = row["Sale"].ToString();
        //            textBox14.Text = row["IMEI"].ToString();
        //            //textBox10.Text = row["sTotal_amount"].ToString();
        //            //textBox12.Text = row["Id"].ToString();
        //            // textBox13.Text = row["Id2"].ToString();
        //            //textBox14.Text = row["IMEI"].ToString();


        //        }
        //    }
        //    catch (Exception f)
        //    {
        //        MessageBox.Show(f.Message);
        //    }
        //}

        private void invoice_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
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