using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    public partial class shop_Detail : Form
    {
        public shop_Detail()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main fr = new Main();
            fr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_supplier ads= new Add_supplier();
            ads.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            User_Account us = new User_Account();
            us.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Banking bn= new Banking();
            bn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            invoice sr = new invoice();
            sr.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase pr = new Purchase();
            pr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void shop_Detail_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label7.Text = DateTime.Now.ToLongTimeString();
            label8.Text = DateTime.Now.ToLongDateString();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Expenses exp = new Expenses();
            exp.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Leger lg = new Leger();
            lg.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Bill_Record br = new Bill_Record();
            br.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Payment_Record pr = new Payment_Record();
            pr.Show();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            shop_Detail sd = new shop_Detail();
            sd.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            use_wtch_record uwr = new use_wtch_record();
            uwr.Show();
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            owner_login ol = new owner_login();
            ol.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
