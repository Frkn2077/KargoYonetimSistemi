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
    public partial class Form17 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form17()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("AdresEkle", con);
            cmd.Parameters.AddWithValue("@sehir", textBox7.Text);
            cmd.Parameters.AddWithValue("@ilce", textBox8.Text);
            cmd.Parameters.AddWithValue("@Mahalle", textBox9.Text);
            cmd.Parameters.AddWithValue("@DetaylıAdres", textBox10.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("MusteriEkle", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Ad", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Soyad", textBox4.Text);
            cmd1.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd1.Parameters.AddWithValue("@Telno", textBox6.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("ilgili kullanıcı eklendi");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("TumKullanıcıBılgılerıLıstele", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int s=Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıSil", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("ID",s);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı silindi");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int s = Convert.ToInt32(textBox1.Text);
            string m1 = textBox3.Text;
            string m2 = textBox4.Text;
            string m3 = textBox5.Text;
            string m4= textBox6.Text;
            string m5= textBox7.Text;
            string m6= textBox8.Text;
            string m7= textBox9.Text;
            string m8= textBox10.Text;
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s);
            cmd.Parameters.AddWithValue("@AD", m1);
            cmd.Parameters.AddWithValue("@SOYAD", m2);
            cmd.Parameters.AddWithValue("@EMAİL", m3);
            cmd.Parameters.AddWithValue("@TELEFON", m4);
            cmd.Parameters.AddWithValue("@SEHİR", m5);
            cmd.Parameters.AddWithValue("@İLCE", m6);
            cmd.Parameters.AddWithValue("@MAHALLE", m7);
            cmd.Parameters.AddWithValue("@DETAYLIADRES", m8);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcının bilgilerini güncellendi");
            con.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int S1=Convert.ToInt32(textBox1.Text);  
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıBılgılerıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", S1);
            SqlDataReader reader = cmd.ExecuteReader();
           
       
            if (reader.Read()) 
            {
                textBox3.Text=reader["AD"].ToString();
                 textBox4.Text= reader["SOYAD"].ToString();
                textBox5.Text = reader["EMAİL"].ToString();
                textBox6.Text = reader["TELEFON"].ToString();
                textBox7.Text= reader["Sehir"].ToString();
                textBox8.Text= reader["İlce"].ToString();
                textBox9.Text= reader["Mahalle"].ToString();
                textBox10.Text= reader["DetaylıAdres"].ToString();
            }
            con.Close();
        }
    }
}
