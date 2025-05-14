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

namespace KargoTakıpOtomasyonu
{
    public partial class Form2: Form
    {
       public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("SISTEM");
            comboBox1.Items.Add("Şube");
            comboBox2.Items.Add("1-Gönderi Oluşturuldu");
            comboBox2.Items.Add("2-Kabul Edildi");
            comboBox2.Items.Add("3-Transfer Sürecinde / Aktarma Merkezinde");
            comboBox2.Items.Add("4-Şubeye Geldi");
            comboBox2.Items.Add("5-Dağıtıma Çıktı");
            comboBox2.Items.Add("6-Teslim Edildi");
            comboBox2.Items.Add("7-Teslim Edilemedi (Alıcı Yoktu)");
            comboBox2.Items.Add("8-Şubede Bekliyor");
            comboBox2.Items.Add("9-İade Edildi");
            comboBox2.Items.Add("10-Hasarlı/Tutanaklı Teslim");
            comboBox2.Items.Add("11-Teslim Edilemedi (Adres Sorunu):");
            comboBox2.Items.Add("12-Gönderi İptal Edildi");
            comboBox2.Items.Add("13-Gümrük İşleminde");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form17 form17 = new Form17();
            form17.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          int m1=Convert.ToInt32(textBox2.Text);
          SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",m1);
            SqlDataReader dr=cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr["AD"].ToString();
                textBox4.Text = dr["SOYAD"].ToString();
                textBox5.Text = dr["EMAİL"].ToString();
                textBox6.Text = dr["TELEFON"].ToString();
                textBox7.Text = dr["Sehir"].ToString();
                textBox8.Text = dr["İlce"].ToString();
                textBox9.Text = dr["Mahalle"].ToString();
                textBox10.Text = dr["DetaylıAdres"].ToString();
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int m1 = Convert.ToInt32(textBox19.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KullanıcıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", m1);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox18.Text = dr["AD"].ToString();
                textBox17.Text = dr["SOYAD"].ToString();
                textBox16.Text = dr["EMAİL"].ToString();
                textBox15.Text = dr["TELEFON"].ToString();
                textBox14.Text = dr["Sehir"].ToString();
                textBox13.Text = dr["İlce"].ToString();
                textBox12.Text = dr["Mahalle"].ToString();
                textBox11.Text = dr["DetaylıAdres"].ToString();
            }
            con.Close ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            int S1 = Convert.ToInt32(textBox2.Text);
            int s2 = Convert.ToInt32(textBox19.Text);
            int s3=Convert.ToInt32(textBox24.Text);
            int s4=Convert.ToInt32(textBox27.Text);
            SqlDecimal D0 = Convert.ToDecimal(textBox20.Text);
            SqlDecimal D1=Convert.ToDecimal(textBox21.Text);
            SqlDecimal D2 = Convert.ToDecimal(textBox22.Text);
            SqlDecimal D3 = Convert.ToDecimal(textBox23.Text);
            SqlBinary sb = new SqlBinary(System.Text.Encoding.UTF8.GetBytes(textBox25.Text));
            SqlCommand CMD = new SqlCommand("KargoEkle1", con);
            CMD.CommandType = CommandType.StoredProcedure;
            CMD.Parameters.AddWithValue("@GonderenID", S1);
            CMD.Parameters.AddWithValue("@AliciID", s2);
            CMD.Parameters.AddWithValue("@KuryeID", s3);
            CMD.Parameters.AddWithValue("@Agirlik", D0);
            CMD.Parameters.AddWithValue("@En", D1);
            CMD.Parameters.AddWithValue("@Boy", D2);
            CMD.Parameters.AddWithValue("@Yukseklik", D3);
            CMD.Parameters.AddWithValue("@Hassaslik", sb);
            CMD.Parameters.AddWithValue("@SubeID", s4);
           
            CMD.ExecuteNonQuery();
            MessageBox.Show("Kargonuz Gönderim için sıraya alınmıştır");
           
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            float s1 = Convert.ToInt32(textBox21.Text);
            float s2 = Convert.ToInt32(textBox22.Text);
            float s3 = Convert.ToInt32(textBox23.Text);
            float desi = (s1 * s2 * s3) / 3000;
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            if (comboBox1.SelectedItem.ToString() == "SISTEM")
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.SistemİndirimHesapla(@Sehir1, @Sehir2, @Agirlik, @Desi, @Hassaslık)", con);
                byte c = 0;
                Decimal s8 = 0;
                Decimal s9 = 0;
                double s6 = Convert.ToDouble(textBox20.Text);
                cmd.Parameters.AddWithValue("@Sehir1 ", textBox7.Text);
                cmd.Parameters.AddWithValue("@Sehir2", textBox14.Text);
                cmd.Parameters.AddWithValue("@Agirlik", s6);
                cmd.Parameters.AddWithValue("@Desi", desi);
                if (checkBox1.Checked) { cmd.Parameters.AddWithValue("@Hassaslık", 1); c = 1; }
                else { cmd.Parameters.AddWithValue("@Hassaslık", 0); }
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                   
                        if (!reader.IsDBNull(reader.GetOrdinal("IndirimliUcret")))
                            s8 = Convert.ToDecimal(reader["IndirimliUcret"]);

                        if (!reader.IsDBNull(reader.GetOrdinal("NormalUcret")))
                            s9 = Convert.ToDecimal(reader["NormalUcret"]);
                   

                }
                //SqlCommand cmd1 = new SqlCommand("KargoUcretiHesapla_Sube", con);
                //cmd1.CommandType = CommandType.StoredProcedure;
                //cmd1.Parameters.AddWithValue("@Ağırlık", s6);
                //cmd1.Parameters.AddWithValue("@HassasiyetDurumu ", c);
                //cmd1.Parameters.AddWithValue("@SubeID", 2);//sistem şubesi 2 olsun
                //cmd1.Parameters.AddWithValue("@HesaplananUcret", s9);
                //cmd1.Parameters.AddWithValue("@İndirimliUcret", s8);
                //textBox1.Text = s8.ToString();
            }
            else
            {
                int s5 = Convert.ToInt32(textBox27.Text);  // @SubeID
                double s6 = Convert.ToDouble(textBox20.Text); // @Agirlik
                byte c = 0;
                decimal s8 = 0;
                decimal s9 = 0;
                decimal k1=Convert.ToDecimal(textBox22.Text);
                decimal k2 = Convert.ToDecimal(textBox23.Text);
                decimal k3 = Convert.ToDecimal(textBox24.Text);
                decimal k4 = (k1 * k2 * k3) / 3000;
                string sehir1 = textBox7.Text;
                string sehir2 = textBox14.Text;
                string hassaslik = checkBox1.Checked ? "Hassas" : "Hassasdegil";
                if (checkBox1.Checked) c = 1;
                string q1 = "SELECT * FROM dbo.SubeFiyatHesapla12(@SubeID, @Sehir1, @Sehir2, @Agirlik, @Desi, @Hassaslık)";
                SqlCommand cmd = new SqlCommand(q1, con);
                cmd.Parameters.AddWithValue("@SubeID",s5);
                cmd.Parameters.AddWithValue("@Sehir1", sehir1.ToUpper());
                cmd.Parameters.AddWithValue("@Sehir2", sehir2.ToUpper());
                cmd.Parameters.AddWithValue("@Agirlik",s6);
                cmd.Parameters.AddWithValue("@Desi",k4);
                cmd.Parameters.AddWithValue("@Hassaslık", hassaslik);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("IndirimliUcret")))
                        s8 = Convert.ToDecimal(reader["IndirimliUcret"]);

                    if (!reader.IsDBNull(reader.GetOrdinal("NormalUcret")))
                        s9 = Convert.ToDecimal(reader["NormalUcret"]);
                }
                reader.Close(); 
                textBox1.Text = s8.ToString();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox27.Text =="5") 
            {
                textBox28.Text = "Sistem";
                textBox29.Text = "Default Sistem İndirimi";
            }
            else 
            {
                string subeadi=null;
                string İndirimoranı=null;
                SqlConnection con = new SqlConnection(connect);
                String s1 = "SELECT* FROM SubeBılgıGetır1(@Id)";
                con.Open();
                SqlCommand cmd = new SqlCommand(s1, con);
                cmd.Parameters.AddWithValue("@Id", textBox27.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                  subeadi = reader["SubeAdi"].ToString();
                  İndirimoranı = reader["İndirimOranı"].ToString();
                }
                textBox28.Text =İndirimoranı;
                textBox29.Text = subeadi;

                con.Close();
            }
             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open ();
            SqlCommand cmd = new SqlCommand("GonderıLıstele", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = dt;
            con.Close ();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.MesafeDöndür(@Sehir1, @Sehir2)", con);
            cmd.Parameters.AddWithValue("@Sehir1",textBox7.Text);
            cmd.Parameters.AddWithValue("@Sehir2",textBox14.Text);
            object s1=cmd.ExecuteScalar();
            string m1=s1.ToString();
            textBox26.Text=m1;
            con.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
