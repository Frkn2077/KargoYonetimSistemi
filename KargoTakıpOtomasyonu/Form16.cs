using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KargoTakıpOtomasyonu
{
    public partial class Form16 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        private string s3 = null;
        private int s4 = 0;
        private string k3 = null;
        private string k4 = null;
        public Form16 (String s1,int s2,String k1,String k2)
        {
            InitializeComponent();
            s3 = s1;
            s4 = s2;
            k3 = k1;
            k4 = k2;
            comboBox1.Items.Add("1-Gönderi Oluşturuldu");
            comboBox1.Items.Add("2-Kabul Edildi");
            comboBox1.Items.Add("3-Transfer Sürecinde / Aktarma Merkezinde");
            comboBox1.Items.Add("4-Şubeye Geldi");
            comboBox1.Items.Add("5-Dağıtıma Çıktı");
            comboBox1.Items.Add("6-Teslim Edildi");
            comboBox1.Items.Add("7-Teslim Edilemedi (Alıcı Yoktu)");
            comboBox1.Items.Add("8-Şubede Bekliyor");
            comboBox1.Items.Add("9-İade Edildi");
            comboBox1.Items.Add("10-Hasarlı/Tutanaklı Teslim");
            comboBox1.Items.Add("11-Teslim Edilemedi (Adres Sorunu):");
            comboBox1.Items.Add("12-Gönderi İptal Edildi");
            comboBox1.Items.Add("13-Gümrük İşleminde");
            textBox1.Text = s3.ToString();
        }
        //kargobilgilerini güncelle
        private void button1_Click(object sender, EventArgs e)
        {

            string m1 = comboBox1.SelectedItem.ToString();
            int s2 = 0;
            if (m1[1] == '-') 
            {
                
                string sayiStr = m1.Split('-')[0].Trim(); 
                s2= int.Parse(sayiStr);

            }
            else 
            {
                m1 = m1.Substring(0, 2);
                s2= Convert.ToInt32(m1);
            }
            int s1 = Convert.ToInt32(m1[0]);
            textBox1.Text=s3.ToString();
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_KargoDurumGuncelle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KargoID",s4);
            cmd.Parameters.AddWithValue("@SUBEID", Convert.ToInt32(textBox4.Text));
            cmd.Parameters.AddWithValue("@DurumId ",s2);
            cmd.Parameters.AddWithValue("@AĞIRLIK", Convert.ToDecimal(textBox20.Text));
            cmd.Parameters.AddWithValue("@EN", Convert.ToDecimal(textBox21.Text));
            cmd.Parameters.AddWithValue("@Boy", Convert.ToDecimal(textBox22.Text));
            cmd.Parameters.AddWithValue("@Yükseklik ", Convert.ToDecimal(textBox24.Text));
            cmd.Parameters.AddWithValue("@Hassaslık ", Convert.ToByte(textBox25.Text));
            cmd.Parameters.AddWithValue("@Fiyat", Convert.ToDecimal(textBox2.Text));
            cmd.Parameters.AddWithValue("@KuryeId ", Convert.ToInt32(textBox7.Text));
            if (s2 == 12 || s2 == 10 || s2 == 9) 
            {
                cmd.Parameters.AddWithValue("@IadeNedeni", textBox6.Text);
                cmd.ExecuteNonQuery();
            }
            else 
            {
                cmd.Parameters.AddWithValue("@IadeNedeni", "İadeYok");
                cmd.ExecuteNonQuery();
            }
            
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KargoBilgiGetir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s4);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) 
            {
                textBox4.Text = reader["SubeID"].ToString();       
                textBox20.Text = reader["Agırlık"].ToString();
                textBox21.Text = reader["En"].ToString();
                textBox22.Text = reader["Boy"].ToString();
                textBox24.Text = reader["Yükseklik"].ToString();
                textBox25.Text = reader["Hassaslık"].ToString();
                textBox3.Text = reader["GonderenID"].ToString();
                textBox5.Text = reader["AliciID"].ToString();
                textBox2.Text = reader["İndirimliUcret"].ToString();  
                textBox7.Text = reader["KuryeId"].ToString();

            }
            if (textBox25.Text == "True") { textBox25.Text = "1"; }
            else { textBox25.Text = "0"; }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int s4 = Convert.ToInt32(textBox4.Text);
            if (s4 == 2) 
            {
                Decimal s6=Decimal.Parse(textBox20.Text);
                Decimal s1 = Decimal.Parse(textBox21.Text);
                Decimal s2 = Decimal.Parse(textBox22.Text);
                Decimal s3 = Decimal.Parse(textBox24.Text);
                Decimal sonuc = (s1 * s2 * s3) / 3000;
                byte s5=Convert.ToByte(textBox25.Text);

                SqlConnection con = new SqlConnection(connect);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SistemİndirimHesapla", con);
                cmd.Parameters.AddWithValue("@Sehir1 ", k3);
                cmd.Parameters.AddWithValue("@Sehir2", k4);
                cmd.Parameters.AddWithValue("@Agirlik", s6);
                cmd.Parameters.AddWithValue("@Desi ", sonuc);
                cmd.Parameters.AddWithValue("@Hassaslık ", s5);
                cmd.ExecuteNonQuery();
                var s10=cmd.ExecuteScalar();
                textBox2.Text=s10.ToString();
                con.Close();
            }
            else
            {
                Decimal s6 = Decimal.Parse(textBox20.Text);
                Decimal s1 = Decimal.Parse(textBox21.Text);
                Decimal s2 = Decimal.Parse(textBox22.Text);
                Decimal s3 = Decimal.Parse(textBox24.Text);
                Decimal sonuc = (s1 * s2 * s3) / 3000;
                byte s5 = Convert.ToByte(textBox25.Text);
                SqlConnection con = new SqlConnection(connect);

                con.Open();
                string sql = @"
                        SELECT 
                            dbo.SubeFiyatHesapla12(@SubeID, @Sehir1, @Sehir2, @Agirlik, @Desi, @Hassaslık) AS Ucret";

                SqlCommand cmd = new SqlCommand(sql, con);
                int s8 = Convert.ToInt32(textBox4.Text);
                cmd.Parameters.AddWithValue("@SubeID", s8);
                cmd.Parameters.AddWithValue("@Sehir1", textBox3.Text);
                cmd.Parameters.AddWithValue("@Sehir2", textBox5.Text);
                cmd.Parameters.AddWithValue("@Agirlik", s6);
                cmd.Parameters.AddWithValue("@Desi", sonuc);
                cmd.Parameters.AddWithValue("@Hassaslık", s5);
                object s9 = cmd.ExecuteReader();
                textBox2.Text = s9 != null ? s9.ToString() : "0";
                con.Close();

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand("GonderıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
