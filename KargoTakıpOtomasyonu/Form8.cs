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
    public partial class Form8 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            String m1 = textBox1.Text;
            String m2 = textBox2.Text;
            Decimal m3 = Convert.ToDecimal(textBox3.Text);
            Decimal m4 = Convert.ToDecimal(textBox4.Text);
            Decimal m5 = Convert.ToDecimal(textBox5.Text);
            Decimal m6 = Convert.ToDecimal(textBox6.Text);
            Decimal sonuc = (m4*m5*m6) / 3000;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SistemİndirimHesapla(@Sehir1, @Sehir2, @Agirlik, @Desi, @Hassaslık)", con);
            cmd.Parameters.AddWithValue("@Sehir1",m1);
            cmd.Parameters.AddWithValue("@Sehir2",m2);
            cmd.Parameters.AddWithValue("@Agirlik",m3);
            cmd.Parameters.AddWithValue("@Desi",sonuc);
            if (checkBox1.Checked)
            {
                cmd.Parameters.AddWithValue("@Hassaslık",1);
                
            }
            else { cmd.Parameters.AddWithValue("@Hassaslık",0);  }
            Decimal s1 = 0;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
            {
                s1 = Convert.ToDecimal(dr["IndirimliUcret"]);
            }
            textBox7.Text =s1.ToString();
            con.Close();
        }
    }
}
