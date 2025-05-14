using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data;
using System.Data.SqlClient;

namespace KargoTakıpOtomasyonu
{
    public partial class Form7 : Form
    {
        string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            String m1 = textBox1.Text;
            String m2 = textBox2.Text;
            m1=m1.ToUpper();
            m2=m2.ToUpper();
            SqlCommand cmd=new SqlCommand("Select dbo.TahminiSure(@sehir1,@sehir2)",con);
            cmd.Parameters.AddWithValue("@sehir1",m1);
            cmd.Parameters.AddWithValue("@sehir2",m2);
            var sonuc=cmd.ExecuteScalar();
            label5.Text = "Gönderinizin tahmini varış süresi"+" "+sonuc.ToString()+" "+" Gündür ";
            con.Close();
        }
    }
}
