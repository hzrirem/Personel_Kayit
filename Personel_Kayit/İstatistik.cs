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
    public partial class Istatistik : Form
    {
        public Istatistik()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-HBC1R06;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void İstatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            sqlConnection.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from tbl_personel", sqlConnection);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_personel.Text = dr1[0].ToString();
            }
            sqlConnection.Close();

            //evli personel
            sqlConnection.Open();
            SqlCommand komut2 = new SqlCommand("select count (*)from tbl_personel where Personel_Durum=1", sqlConnection);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lbl_evli.Text = dr2[0].ToString();
            }
            sqlConnection.Close();


            // bekar personel
            sqlConnection.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_personel where Personel_Durum=0", sqlConnection);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lbl_bekar.Text = dr3[0].ToString();
            }
            sqlConnection.Close();


            //farklı şehir
            sqlConnection.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(Personel_Sehir))from tbl_personel",sqlConnection);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lbl_sehir.Text = dr4[0].ToString();
            }
            sqlConnection.Close();

            //toplam maas

            sqlConnection.Open();
            SqlCommand komut5 = new SqlCommand("select sum (Personel_maas)from tbl_personel", sqlConnection);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_tplmaas.Text = dr5[0].ToString();
            }
            sqlConnection.Close();
            //ortalama maas
            sqlConnection.Open();
            SqlCommand komut6 = new SqlCommand("select avg(Personel_maas)from tbl_personel",sqlConnection);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lbl_ortmmas.Text = dr6[0].ToString();
            }
            sqlConnection.Close();

        }
    }
}
