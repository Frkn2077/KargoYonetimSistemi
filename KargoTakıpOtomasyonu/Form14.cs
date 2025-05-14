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
    public partial class Form14 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form14()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KuryeEkle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Adsoyad",textBox1.Text);
            cmd.Parameters.AddWithValue("@Telefon",textBox6.Text);
            cmd.Parameters.AddWithValue("@PLAKA ",textBox5.Text);
            cmd.Parameters.AddWithValue("@SaatlikUcret",textBox3.Text);
            cmd.Parameters.AddWithValue("@Email",textBox5.Text);
            cmd.Parameters.AddWithValue("@İL",textBox7.Text);
            cmd.Parameters.AddWithValue("@DetaylıAdres",textBox8.Text);
            MessageBox.Show("Kurye Başarılı Bir şekilde Eklendi");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
