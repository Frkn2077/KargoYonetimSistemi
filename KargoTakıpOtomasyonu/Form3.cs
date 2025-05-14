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

namespace KargoTakıpOtomasyonu
{
    public partial class Form3 : Form
    {
        string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
       
        public Form3()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String m1 = textBox1.Text;
            m1 = m1.ToUpper();
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand("GonderıSorgula", con);
            con.Open();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GonderiKodu", m1);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            String m1 = textBox1.Text;
            m1 = m1.ToUpper();
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("GonderıSil", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GonderiKodu", m1);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string m1 = textBox1.Text;
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand("SELECT dbo.GonderiKoduGetir(@GonderiKodu)", con);
            cmd.Parameters.AddWithValue("@GonderiKodu", m1);
            con.Open();
            object s1 = cmd.ExecuteScalar();
            int s2 = Convert.ToInt32(s1);
            con.Close();
            string sehir1 = dataGridView1.Rows[0].Cells["GondericiSehir"].Value?.ToString();
            string sehir2 = dataGridView1.Rows[0].Cells["AliciSehir"].Value?.ToString();
            Form16 form16 = new Form16(m1, s2,sehir1,sehir2);
            form16.Show();

        }
    }
}
