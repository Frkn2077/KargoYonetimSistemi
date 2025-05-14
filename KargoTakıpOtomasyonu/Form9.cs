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
    public partial class Form9 : Form
    {
        public string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        
        public Form9()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //sorgula
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();

            SqlCommand cmd = new SqlCommand("BıldırımGoruntule", con);
           int s1=Convert.ToInt32(textBox1.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", s1);
            cmd.ExecuteNonQuery();
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //tüm mesajları temizle
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("TumBıldırımıSıl", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int s1 = Convert.ToInt32(textBox1.Text);
            cmd.Parameters.AddWithValue("@Id", s1);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //seçili mesajı sil
        private void button2_Click(object sender, EventArgs e)
        {
            int s1 = 0;
           
            if (dataGridView1.CurrentRow != null)
            {
                int s2 = dataGridView1.SelectedRows[0].Index;
                s1 =Convert.ToInt32(dataGridView1.Rows[s2].Cells["B_ID"]);
            }
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SeciliBıldırımıSıl", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", s1);
            con.Close();

        }
    }
}
