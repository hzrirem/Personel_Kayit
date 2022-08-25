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
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-HBC1R06;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        private void Grafikler_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand g1 = new SqlCommand("select Personel_Sehir,count(*)from tbl_personel group by Personel_Sehir ",sqlConnection);
            SqlDataReader dr1 = g1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand g2 = new SqlCommand("select Personel_Meslek,avg(PErsonel_Maas)from tbl_personel group by Personel_Meslek", sqlConnection);
            SqlDataReader dr2 = g2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek_Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            sqlConnection.Close();
        }
    }
}
