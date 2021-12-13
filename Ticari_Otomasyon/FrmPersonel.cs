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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListelePersonel()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV from TBL_PERSONELLER where DURUM=1", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
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
            txtGorev.Text = "";
            txtId.Text = "";
            txtMail.Text = "";
            txtSoyad.Text = "";
            mskTcNo.Text = "";
            mskTel.Text = "";
            cbxIl.Text = "";
            cbxIlce.Text = "";
            rchAdres.Text = "";
        }
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            ListelePersonel();
            SehirListesi();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel.Text);
            komut.Parameters.AddWithValue("@p4", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cbxIl.Text);
            komut.Parameters.AddWithValue("@p7", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListelePersonel();
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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow!=null)
            {
                txtId.Text = dataRow["ID"].ToString();
                txtAd.Text = dataRow["AD"].ToString();
                txtSoyad.Text = dataRow["SOYAD"].ToString();
                mskTel.Text = dataRow["TELEFON"].ToString();
                mskTcNo.Text = dataRow["TC"].ToString();
                txtMail.Text = dataRow["MAIL"].ToString();
                cbxIl.Text = dataRow["IL"].ToString();
                cbxIlce.Text = dataRow["ILCE"].ToString();
                rchAdres.Text = dataRow["ADRES"].ToString();
                txtGorev.Text = dataRow["GOREV"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
                SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set DURUM=0 where ID=@p1", sqlBaglantisi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Müşteri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                ListelePersonel();
                Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 where ID=@P10", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTel.Text);
            komut.Parameters.AddWithValue("@p4", mskTcNo.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cbxIl.Text);
            komut.Parameters.AddWithValue("@p7", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p8", rchAdres.Text);
            komut.Parameters.AddWithValue("@p9", txtGorev.Text);
            komut.Parameters.AddWithValue("@p10", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Personel güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListelePersonel();
            Temizle();
        }
    }
}
