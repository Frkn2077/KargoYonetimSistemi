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

namespace KargoTakıpOtomasyonu
{
   
    public partial class Form12 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int s1=Convert.ToInt32(textBox1.Text);
            Form13 form13 = new Form13(s1);//açılacak form
            form13.Show();
        }
        // sorgula
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("BorcListele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int s1 = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.AddWithValue("@MusteriID", s1);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }
    }
}
