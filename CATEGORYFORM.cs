using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace ShopMgt
{
    public partial class CATEGORYFORM : Form
    {
        private MySqlConnection con;
        private string URL = @"datasource=127.0.0.1;port=3307;username=root;password=;database=Shoprite";
        public CATEGORYFORM()
        {
            InitializeComponent();
        }
      //  SqlConnection Con= new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= C: \Users\GENERAL MOSQUITO\Documents\mysalesdb.mdf;Integrated Security=True;Connect Timeout=30");
        private object pro;

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               using(con=new MySqlConnection(URL))
                {con.Open();
                    string query = "insert into Categorytb (Categoryname, Cardesc) values('" + CatNameTbl.Text + "','" + CatDescTbl.Text + "')";
                   MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category Added Succesfully");
                 
                }
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void populate()
        {
           using(con=new MySqlConnection(URL))
            {
                string query = "select * from categorytb";
                MySqlDataAdapter sda = new MySqlDataAdapter(query, con);
               
                var ds = new DataSet();
                sda.Fill(ds);
                CatDGV.DataSource = ds;
                
                
            }
           
        }
        private void CATEGORYFORM_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIdTbl.Text = CatDGV.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTbl.Text = CatDGV.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTbl.Text = CatDGV.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(CatIdTbl.Text == "")
            //    {
            //        MessageBox.Show("Select the Category to Delete ");
            //    }
            //    else
            //    {
            //        Con.Open();
            //        string query = "delete from CategoryTbl where Catd=" + CatIdTbl.Text + "";
            //        SqlCommand cmd = new SqlCommand(query, Con);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Category Deleted Successfully");
            //        Con.Close();
            //        populate();
            //    }
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if(CatIdTbl.Text=="" || CatNameTbl.Text=="" || CatDescTbl.Text=="")
            //    {
            //        MessageBox.Show("Missing Information");
            //    }
            //    else { 
            //        Con.Open();
            //        string query="update CategoryTbl set CatName='"+CatNameTbl.Text+"' ,CatDesc='" + CatDescTbl.Text+ "' where Catd=" + CatIdTbl.Text + ";";
            //        SqlCommand cmd = new SqlCommand(query, Con);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Category Succesfully Updated");
            //        Con.Close();
            //        populate();
            //    }
            //}
            //catch (Exception ex)
           //{
              //  MessageBox.Show(ex.Message);
           // }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
