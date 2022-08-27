using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopMgt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Usernametb.Text = "";
            PassTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Usernametb.Text=="" || PassTb.Text== "")
            {
                MessageBox.Show("Enter Username ane Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                    if (Usernametb.Text == "Admin" && PassTb.Text == "Admin") 
                    {
                        ProductForm prod = new ProductForm();
                        prod.Show();
                        this.Hide();
                    }
                    else 
                    {
                        MessageBox.Show("If you are the Admin, Enter the correct ID and Password");
                    }
                }
                else if (RoleCb.SelectedItem.ToString() == "User")
                    {
                        MessageBox.Show("You are a User");
                    }
                }
                else
                {
                    MessageBox.Show("Select a role");
                }
            }
        }

        private void RoleCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
