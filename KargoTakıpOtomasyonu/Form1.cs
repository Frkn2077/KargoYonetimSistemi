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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            string connect = "Data Source=Furkan\\SQLEXPRESS;Initial Catalog=KargoVt;Integrated Security=True";
            SqlConnection con = new SqlConnection(connect);

        }
        //gonderi oluştur
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();//açılacak form
            form2.Show();
        }
        //gönderi sorgula
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();//açılacak form
            form3.Show();
           
        }
        //iletişim bilgilerini değiştir
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();//açılacak form
            form4.Show();
            
        }
        //kargo fiyatlarını görüntüle
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();//açılacak form
            form5.Show();
           
        }
     

        //yaklaşık gönderi teslimat süresi hesapla
        private void button7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();//açılacak form
            form7.Show();
           
           
        }
        //kargo fiyatını hesapla
        private void button8_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();//açılacak form
            form8.Show();

        }
      
        
        //en yakın şube
        private void button10_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();//açılacak form
            form10.Show();

        }
        //Kuryelerle ilgili işlemler
        private void button11_Click(object sender, EventArgs e)
        {

            Form11 form11 = new Form11();//açılacak form
            form11.Show();
        }
        //Borç sorgula /öde
        private void button12_Click(object sender, EventArgs e)
        {

            Form12 form12 = new Form12();//açılacak form
            form12.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 form9= new Form9();//açılacak form
            form9.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form15 form15= new Form15();//açılacak form
            form15.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form19 form19= new Form19();
            form19.Show();
        }
        //kargo geçmişi görüntüle
        private void button5_Click_1(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();//açılacak form
            form6.Show();
        }
    }
}
