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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-HBC1R06;Initial Catalog=PersonelVeriTabani;Integrated Security=True");




        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtMeslek.Text = "";
            mskdtxtMaas.Text = "";
            cmbxSehir.Text = "";
            rdbEvli.Checked = false;
            rdbBekar.Checked = false;
            txtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.tbl_personel' table. You can move, or remove it, as needed.
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_personel);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.personelVeriTabaniDataSet.tbl_personel);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand("insert into tbl_personel(Personel_Ad,Personel_Soyad,Personel_Sehir,Personel_Maas,Personel_Meslek,Personel_Durum) values (@p1,@p2,@p3,@p4,@p5,@p6)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@p1",txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtSoyad.Text);
            sqlCommand.Parameters.AddWithValue("@p3", cmbxSehir.Text);
            sqlCommand.Parameters.AddWithValue("@p4", mskdtxtMaas.Text);
            sqlCommand.Parameters.AddWithValue("@p5", txtMeslek.Text);
            sqlCommand.Parameters.AddWithValue("@p6", label8.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void rdbEvli_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbEvli.Checked==true)
            {
                label8.Text = "true";
            }
         }

        private void rdbBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBekar.Checked==true)
            {
                label8.Text = "false";
           }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbxSehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskdtxtMaas.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtMeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text=="true")
            {
                rdbEvli.Checked = true;
            }
            if (label8.Text == "false")
            {
                rdbBekar.Checked = true;
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("delete from tbl_personel where Personel_Id=@k1",sqlConnection);
            sqlCommand.Parameters.AddWithValue("@k1", txtId.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Kayıt silindi.");



        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("update tbl_personel set Personel_Ad=@a1,Personel_Soyad=@a2,Personel_Sehir=@a3,Personel_Maas=@a4,Personel_Durum=@a5,Personel_Meslek=@a6 where Personel_Id=@a7", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@a1", txtAd.Text);
            sqlCommand.Parameters.AddWithValue("@a2", txtSoyad.Text);
            sqlCommand.Parameters.AddWithValue("@a3", cmbxSehir.Text);
            sqlCommand.Parameters.AddWithValue("@a4", mskdtxtMaas.Text);
            sqlCommand.Parameters.AddWithValue("@a5", label8.Text);
            sqlCommand.Parameters.AddWithValue("@a6", txtMeslek.Text);
            sqlCommand.Parameters.AddWithValue("@a7", txtId.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            MessageBox.Show("Bİlgiler güncellendi");

        }

        private void btnIstatistik_Click(object sender, EventArgs e)
        {
            Istatistik istatistik = new Istatistik();
            istatistik.Show();

        }

        private void btnGrafikler_Click(object sender, EventArgs e)
        {
            Grafikler grafikler = new Grafikler();
            grafikler.Show();
        }
    }
}
