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
    public partial class Form4 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form4()
        {
            InitializeComponent();
        }
        //getir
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int s1 =Convert.ToInt32(textBox2.Text);
            cmd.Parameters.AddWithValue("@Id", s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                textBox3.Text =reader["AD"].ToString();
                textBox4.Text = reader["SOYAD"].ToString();
                textBox5.Text = reader["EMAİL"].ToString();
                textBox6.Text = reader["TELEFON"].ToString();
                textBox7.Text = reader["Sehir"].ToString();
                textBox8.Text = reader["İlce"].ToString();
                textBox9.Text = reader["Mahalle"].ToString();
                textBox10.Text = reader["DetaylıAdres"].ToString();
            }
            con.Close();
        }
        //guncelle
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullaniciGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int s1 = Convert.ToInt32(textBox2.Text);
            cmd.Parameters.AddWithValue("@Id",s1);
            cmd.Parameters.AddWithValue("@AD", textBox3.Text);
            cmd.Parameters.AddWithValue("@SOYAD", textBox4.Text);
            cmd.Parameters.AddWithValue("@EMAIL", textBox5.Text);
            cmd.Parameters.AddWithValue("@TELEFON", textBox6.Text);
            cmd.Parameters.AddWithValue("@Sehir", textBox7.Text);
            cmd.Parameters.AddWithValue("@Ilce", textBox8.Text);
            cmd.Parameters.AddWithValue("@Mahalle", textBox9.Text);
            cmd.Parameters.AddWithValue("@DetayliAdres", textBox10.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
