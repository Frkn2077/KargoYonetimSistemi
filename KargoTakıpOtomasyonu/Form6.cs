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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;


namespace KargoTakıpOtomasyonu
{
    public partial class Form6 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form6()
        {
            InitializeComponent();
        }
        //haftalık
        private void button1_Click(object sender, EventArgs e)
        {
            
          
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Haftalıkİstatistik", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //aylık
        private void button2_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("aylıkİstatistik", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //yıllık
        private void button4_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("Yıllıkİstatistik", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //tümgeçmişlerigörüntüle
        private void button3_Click(object sender, EventArgs e)
        {
            int s1 = Convert.ToInt32(textBox1.Text);
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("İstatistikGorüntüle", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID",s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter DA=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Rapor oluştur
        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            string path = "C:\\Users\\Furkan\\Desktop\\raporum.pdf";
            PdfWriter writer = new PdfWriter(path);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            document.Add(new Paragraph("Müşteri Bilgileri Raporu").SetFontSize(18));
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string satir = "";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        satir += cell.Value?.ToString() + " | ";
                    }
                    document.Add(new Paragraph(satir));
                }
            }

            document.Close();
            con.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT dbo.fn_EnCokGonderiYapanMusteri()", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                label4.Text = reader[0].ToString();
            }

            reader.Close();
            con.Close();
        }
    }
}
