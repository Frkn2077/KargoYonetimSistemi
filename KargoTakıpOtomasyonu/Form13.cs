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
    public partial class Form13 : Form
    {
       public  string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        private int s1;
        public Form13(int s2)
        {
            InitializeComponent();
            s1 = s2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("BorcTemizle", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MusteriId",s1);
            if (checkBox1.Checked) 
            {
                cmd.Parameters.AddWithValue("@ODEMESEKLİ", "KART");
                cmd.ExecuteNonQuery();
            }
            else 
            {
                cmd.Parameters.AddWithValue("@ODEMESEKLİ", "HAVALE");
                cmd.ExecuteNonQuery();
            }

             con.Close();
            if (checkBox2.Checked) 
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }


        }

        private void Form13_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT dbo.B_TUTAR(@MusteriID)", con);
            cmd.Parameters.AddWithValue("@MusteriID",s1);
            object sonuc=cmd.ExecuteScalar();
            Decimal d1=Convert.ToDecimal(sonuc);
            label6.Text=d1.ToString();
            con.Close();
        }
    }
}
