using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5VP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int Customer_Id=int.Parse(textBox1.Text);
            String CompanyName=textBox2.Text;
            String ContactName=textBox3.Text;
            String Phone=textBox4.Text;

            String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\lab5VP\lab5VP\softtech.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);

            String query= "INSERT INTO customer(CompanyName,ContactName,Phone) VALUES ('"+ CompanyName + "' , '" + ContactName + "' , '" +Phone+"')";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("Data Inserted");

            }
            else if (i == 0)
            {
                MessageBox.Show("Sorry! No insertion");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mootu & Patlu\source\repos\lab5VP\lab5VP\softtech.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from customer", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
    }
}
