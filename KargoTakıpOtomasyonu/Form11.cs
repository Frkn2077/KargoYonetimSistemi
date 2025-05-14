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
    public partial class Form11 : Form
    {
       public  string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
       
        public Form11()
        {
            InitializeComponent();
        }
        //güncelle
        private void button2_Click(object sender, EventArgs e)
        {
            
            Decimal d1=Convert.ToDecimal(textBox4.Text);
            SqlMoney sqlMoney = new SqlMoney(d1);
            int s1=Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open(); 
            SqlCommand cmd =new SqlCommand("KuryeBilgiGuncelle",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID ",s1);
            cmd.Parameters.AddWithValue("@AdSoyad",textBox3.Text);
            cmd.Parameters.AddWithValue("@TelNo",textBox6.Text);
            cmd.Parameters.AddWithValue("@Plaka",textBox8.Text);
            cmd.Parameters.AddWithValue("@SaatUcret",sqlMoney);
            cmd.Parameters.AddWithValue("@Email",textBox5.Text);
            cmd.Parameters.AddWithValue("@İL ",textBox9.Text);
            cmd.Parameters.AddWithValue("@DetaylıAdres ",textBox7.Text );
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        //ekle
        private void button5_Click(object sender, EventArgs e)
        {
            Form14 form14 = new Form14();//açılacak form
            form14.Show();
        }
        //bulvegetir
        private void button3_Click(object sender, EventArgs e)
        {
            int S1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KuryeBilgiGetir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",S1);
            cmd.ExecuteNonQuery();
            SqlDataReader sqlDataReader =cmd.ExecuteReader();
            while (sqlDataReader.Read()) 
            {
                textBox3.Text = sqlDataReader["AdSoyad"].ToString();
                textBox6.Text = sqlDataReader["Telefon"].ToString();
                textBox8.Text = sqlDataReader["Plaka"].ToString();
                textBox4.Text = sqlDataReader["SaatlikÜcret"].ToString();
                textBox5.Text = sqlDataReader["Email"].ToString();
                textBox9.Text = sqlDataReader["İl"].ToString();
                textBox7.Text = sqlDataReader["DetaylıAdres"].ToString();
            }

            con.Close();
        }
        //Kuryenin Göndirelerini Listele
        private void button6_Click(object sender, EventArgs e)
        {
            int S1= Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KuryeGonderiGetir", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@KuryeId", S1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        //sil
        private void button4_Click(object sender, EventArgs e)
        {
            string m1 = dataGridView1.CurrentRow.Cells["KuryeID"].Value.ToString();
            int S1 = Convert.ToInt32(m1);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KuryeSıl ", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",S1);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //listele
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("KuryeLıstele ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da= new SqlDataAdapter(cmd);
           DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
