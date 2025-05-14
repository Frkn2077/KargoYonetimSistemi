using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KargoTakıpOtomasyonu
{
    public partial class Form15 : Form
    {
         public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
       
        public Form15()
        {
            InitializeComponent();
        }
        //subeekle
        private void button1_Click(object sender, EventArgs e)
        {
            float io = Convert.ToSingle(textBox4.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SubeEkle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Subeadı",textBox2.Text);
            cmd.Parameters.AddWithValue("@Telefon",textBox3.Text);
            cmd.Parameters.AddWithValue("@İndirimOranı",io);
            cmd.Parameters.AddWithValue("@Sehir",textBox5.Text);
            cmd.Parameters.AddWithValue("@ILCE ",textBox6.Text);
            cmd.Parameters.AddWithValue("@Adres",textBox7.Text);
            cmd.Parameters.AddWithValue("@email",textBox28.Text);
            cmd.Parameters.AddWithValue("@Ucret1 ", textBox8.Text);
            cmd.Parameters.AddWithValue("@Ucret2 ", textBox16.Text);
            cmd.Parameters.AddWithValue("@Ucret3", textBox17.Text);
            cmd.Parameters.AddWithValue("@Ucret4", textBox18.Text);
            cmd.Parameters.AddWithValue("@DesiFiyat", textBox20.Text);
            cmd.Parameters.AddWithValue("@MesafeFiyat", textBox21.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Şube eklendi");
            con.Close();
        }
        //gonderiListele
        private void button5_Click(object sender, EventArgs e)
        {
            int s1=Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SubeGonderiListele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubeId",s1);
            SqlDataAdapter da=new SqlDataAdapter(cmd);

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //bilgileriguncelle
        private void button3_Click(object sender, EventArgs e)
        {
            float io = Convert.ToSingle(textBox25.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            Decimal d1 = Convert.ToDecimal(textBox13.Text);
            Decimal d2 = Convert.ToDecimal(textBox15.Text);
            Decimal d3 = Convert.ToDecimal(textBox14.Text);

            Decimal d4 = Convert.ToDecimal(textBox12.Text);
            Decimal d5 = Convert.ToDecimal(textBox10.Text);
            Decimal d6 = Convert.ToDecimal(textBox9.Text);
            SqlCommand cmd = new SqlCommand("SubeGuncelle", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubeID",textBox1.Text);
            cmd.Parameters.AddWithValue("@Subeadı", textBox27.Text);
            cmd.Parameters.AddWithValue("@Telefon", textBox26.Text);
            cmd.Parameters.AddWithValue("@İndirimOranı", io);
            cmd.Parameters.AddWithValue("@Sehir", textBox24.Text);
            cmd.Parameters.AddWithValue("@ILCE ", textBox23.Text);
            cmd.Parameters.AddWithValue("@Adres", textBox22.Text);
            cmd.Parameters.AddWithValue("@email", textBox29.Text);
            cmd.Parameters.AddWithValue("@Ucret1 ", d2);
            cmd.Parameters.AddWithValue("@Ucret2 ", d3);
            cmd.Parameters.AddWithValue("@Ucret3",d1);
            cmd.Parameters.AddWithValue("@Ucret4", d4);
            cmd.Parameters.AddWithValue("@DesiFiyat",d5 );
            cmd.Parameters.AddWithValue("@MesafeFiyat", d6);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        //subesil
        private void button2_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SubeSil", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SubeID", s1);
            MessageBox.Show("Şube başarılı bir şekilde silindi");
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
          
        }
        //tumsubeleriListele
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("TumSubeleriListele", con);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("subebılgıgetir", con);
            cmd.Parameters.AddWithValue("@ID", s1);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) // veri varsa
            {
                textBox27.Text = reader["SubeAdi"].ToString();
                textBox26.Text = reader["Telefon"].ToString();
                textBox25.Text = reader["İndirimOrani"].ToString();
                textBox24.Text = reader["Sehir"].ToString();
                textBox23.Text = reader["Ilce"].ToString();
                textBox22.Text = reader["Adres"].ToString();
                textBox29.Text = reader["Email"].ToString();
                textBox15.Text = reader["Ucret1"].ToString();
                textBox14.Text = reader["Ucret2"].ToString();
                textBox13.Text = reader["Ucret3"].ToString();
                textBox12.Text = reader["Ucret4"].ToString();
                textBox10.Text = reader["DesiBasinaFiyat"].ToString();
                textBox9.Text = reader["MesafeBasınaOrtalamaFiyat"].ToString();
            }
            con.Close();
        }
    }
}
