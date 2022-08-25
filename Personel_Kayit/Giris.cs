using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-HBC1R06;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand k1 = new SqlCommand("select*from tbl_yönetici where KullaniciAd=@p1 and Sifre=@p2", sqlConnection);
            k1.Parameters.AddWithValue("@p1", txtkullanıcıad.Text);
            k1.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = k1.ExecuteReader();
            if (dr.Read())
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre.");
            }
            sqlConnection.Close();
        }
    }
}
