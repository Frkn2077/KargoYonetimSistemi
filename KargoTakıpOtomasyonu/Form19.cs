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
 
    public partial class Form19 : Form
    {
        string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form19()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd=new SqlCommand("IADEKARGOLAR", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
           cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
