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
    public partial class ProductForm : Form
    {
       private MySqlConnection con;
     private   string URL = @"datasource=127.0.0.1;port=3307;username=root;password=;database=Shoprite";
        public ProductForm()
        {
            InitializeComponent();
        }
      
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void fillcombo()
        {
            //Binding the Combobox with the Database
            using (con = new MySqlConnection(URL))
            {
                con.Open();
                List<string> listt = new List<string>();
                MySqlDataAdapter newl = new MySqlDataAdapter("select * from products", con);

                DataTable dt = new DataTable();
                DataGridView NG = ProdDGV;
                newl.Fill(dt);
                ProdDGV.DataSource = dt;

                MySqlCommand cmdd = new MySqlCommand("select Categoryname from categorytb", con);
                MySqlDataReader newlist = cmdd.ExecuteReader();
                if (newlist.HasRows)
                {
                    while (newlist.Read())
                    {
                        if (!listt.Contains(newlist.GetString(0))){
                            listt.Add(newlist.GetString(0));
                        }
                       



                    }
                }
                newlist.Close();
                  foreach(var v in listt)
                {
                    comboBox1.Items.Add(v);
                }
            }


            //if (adapter.HasRows)
            //{
            //    while (adapter.Read())
            //    {
            //        int id = adapter.GetInt32("id");
            //        string cat = adapter.GetString("category");
            //        string catd=adapter.G

            //    }
            //}
        
               
                
            
              
          
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillcombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CATEGORYFORM cat = new CATEGORYFORM();
            cat.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using(con = new MySqlConnection(URL))
                {
                    con.Open();
                    int ids=1;
                    MySqlCommand cmdd = new MySqlCommand("select id from categorytb where categoryname='"+comboBox1.Text+"' ", con);
                    MySqlDataReader newlist = cmdd.ExecuteReader();
                    if (newlist.HasRows)
                    {
                        while (newlist.Read())
                        {
                            ids = newlist.GetInt32(0);


                        }
                    }
                    newlist.Close();
                    string query = "insert into products (name, quantity, price, category) values('" + ProdName.Text + "','" + ProdQty.Text+
                        "','" + ProdPrice.Text +"','" +ids+ "')";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Added Succesfully");
                    fillcombo();
                    //populate();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdId.Text = ProdDGV.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = ProdDGV.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdDGV.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.selectedValue = ProdDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
