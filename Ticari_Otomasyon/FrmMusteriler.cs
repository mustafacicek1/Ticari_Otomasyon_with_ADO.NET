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

namespace Ticari_Otomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleMusteriler()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from TBL_MUSTERILER",
                sqlBaglantisi.Baglanti());
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;

        }
        void SehirListesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", sqlBaglantisi.Baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cbxIl.Properties.Items.Add(reader[0]);
            }
            sqlBaglantisi.Baglanti().Close();
        }
        void Temizle()
        {
            txtAd.Text = "";
            txtId.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            txtVergiDairesi.Text = "";
            mskTcNo.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            cbxIl.Text = "";
            cbxIlce.Text = "";
            rchAdres.Text = "";
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            ListeleMusteriler();
            SehirListesi();
            Temizle();
        }

        private void cbxIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxIlce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@p1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", cbxIl.SelectedIndex + 1);//sql de 1 den başladığı için indexi 1 arttırdık.
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                cbxIlce.Properties.Items.Add(reader[0]);
            }
            sqlBaglantisi.Baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cbxIl.Text);
            komut.Parameters.AddWithValue("@p8", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDairesi.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Müşteri sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleMusteriler();
            Temizle();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Gerçekten silmek istiyor musunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlCommand komut = new SqlCommand("Delete from TBL_MUSTERILER where ID=@p1", sqlBaglantisi.Baglanti());
                    komut.Parameters.AddWithValue("@p1", txtId.Text);
                    komut.ExecuteNonQuery();
                    sqlBaglantisi.Baglanti().Close();
                    MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ListeleMusteriler();
                    Temizle();
                }
            }
            catch
            {
            }
          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,ADRES=@P9,VERGIDAIRE=@P10 where ID=@P11", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel1.Text);
            komut.Parameters.AddWithValue("@p4", mskTel2.Text);
            komut.Parameters.AddWithValue("@p5", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p6", txtMail.Text);
            komut.Parameters.AddWithValue("@p7", cbxIl.Text);
            komut.Parameters.AddWithValue("@p8", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p9", rchAdres.Text);
            komut.Parameters.AddWithValue("@p10", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p11", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Müşteri bilgileri güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ListeleMusteriler();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                txtId.Text = dataRow["ID"].ToString();
                txtAd.Text = dataRow["AD"].ToString();
                txtSoyad.Text = dataRow["SOYAD"].ToString();
                mskTel1.Text = dataRow["TELEFON"].ToString();
                mskTel2.Text = dataRow["TELEFON2"].ToString();
                mskTcNo.Text = dataRow["TC"].ToString();
                txtMail.Text = dataRow["MAIL"].ToString();
                cbxIl.Text = dataRow["IL"].ToString();
                cbxIlce.Text = dataRow["ILCE"].ToString();
                rchAdres.Text = dataRow["ADRES"].ToString();
                txtVergiDairesi.Text = dataRow["VERGIDAIRE"].ToString();
            }
        }
    }
}
