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

namespace Ticari_Otomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleFaturaBilgi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select FATURABILGIID,SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN from TBL_FATURABILGI where DURUM=1", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void Temizle()
        {
            txtId.Text = "";
            txtSeri.Text = "";
            txtTeslimAlan.Text = "";
            txtTeslimEden.Text = "";
            txtVergiDairesi.Text = "";
            txtAlici.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            txtSiraNo.Text = "";
        }
        void Temizle2()
        {
            txtUrunId.Text = "";
            txtUrunAd.Text = "";
            txtMiktar.Text = "";
            txtTutar.Text = "";
            txtFaturaId.Text = "";
            txtFiyat.Text = "";
            lupFirma.EditValue = null;
            lupMusteri.EditValue = null;
            lupPersonel.EditValue = null;
        }
        void PersonelListesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,(AD + ' ' + SOYAD) AS 'AD SOYAD' from TBL_PERSONELLER", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            lupPersonel.Properties.ValueMember = "ID";
            lupPersonel.Properties.DisplayMember = "AD SOYAD";
            lupPersonel.Properties.DataSource = dataTable;

        }
        void FirmaListesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,AD from TBL_FIRMALAR", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            lupFirma.Properties.ValueMember = "ID";
            lupFirma.Properties.DisplayMember = "AD";
            lupFirma.Properties.DataSource = dataTable;

        }
        void MusteriListesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,(AD + ' ' + SOYAD) AS 'AD SOYAD' from TBL_MUSTERILER", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            lupMusteri.Properties.ValueMember = "ID";
            lupMusteri.Properties.DisplayMember = "AD SOYAD";
            lupMusteri.Properties.DataSource = dataTable;

        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            ListeleFaturaBilgi();
            Temizle();
            PersonelListesi();
            FirmaListesi();
            MusteriListesi();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                txtId.Text = dataRow["FATURABILGIID"].ToString();
                txtSeri.Text = dataRow["SERI"].ToString();
                txtSiraNo.Text = dataRow["SIRANO"].ToString();
                mskTarih.Text = dataRow["TARIH"].ToString();
                mskSaat.Text = dataRow["SAAT"].ToString();
                txtVergiDairesi.Text = dataRow["VERGIDAIRE"].ToString();
                txtAlici.Text = dataRow["ALICI"].ToString();
                txtTeslimEden.Text = dataRow["TESLIMEDEN"].ToString();
                txtTeslimAlan.Text = dataRow["TESLIMALAN"].ToString();
            }
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (txtFaturaId.Text == "")
            {
                SqlCommand komut = new SqlCommand("Insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) values " +
    "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", sqlBaglantisi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtSeri.Text);
                komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", mskTarih.Text);
                komut.Parameters.AddWithValue("@p4", mskSaat.Text);
                komut.Parameters.AddWithValue("@p5", txtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p6", txtAlici.Text);
                komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
                komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Fatura bilgisi sisteme eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeleFaturaBilgi();
                Temizle();
            }

            //Firma carisi
            if (txtFaturaId.Text != "" && lupFirma.EditValue !=null && lupMusteri.EditValue==null)
            {
                double miktar, fiyat, tutar;
                miktar = Convert.ToDouble(txtMiktar.Text);
                fiyat = Convert.ToDouble(txtFiyat.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("Insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values" +
                    "(@p1,@p2,@p3,@p4,@p5)", sqlBaglantisi.Baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3",decimal.Parse( txtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4",decimal.Parse( txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();

                //Hareket Tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("Insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", sqlBaglantisi.Baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", lupPersonel.EditValue);
                komut3.Parameters.AddWithValue("@h4", lupFirma.EditValue);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();

                //Stok sayısı azaltma
                SqlCommand komut4 = new SqlCommand("Update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2",sqlBaglantisi.Baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            //Müşteri Carisi
            if (txtFaturaId.Text != "" && lupMusteri.EditValue != null && lupFirma.EditValue==null)
            {
                double miktar, fiyat, tutar;
                miktar = Convert.ToDouble(txtMiktar.Text);
                fiyat = Convert.ToDouble(txtFiyat.Text);
                tutar = miktar * fiyat;
                txtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("Insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) values" +
                    "(@p1,@p2,@p3,@p4,@p5)", sqlBaglantisi.Baglanti());
                komut2.Parameters.AddWithValue("@p1", txtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", txtFaturaId.Text);
                komut2.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();

                //Hareket Tablosuna veri girişi
                SqlCommand komut3 = new SqlCommand("Insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@h1,@h2,@h3,@h4,@h5,@h6,@h7,@h8)", sqlBaglantisi.Baglanti());
                komut3.Parameters.AddWithValue("@h1", txtUrunId.Text);
                komut3.Parameters.AddWithValue("@h2", txtMiktar.Text);
                komut3.Parameters.AddWithValue("@h3", lupPersonel.EditValue);
                komut3.Parameters.AddWithValue("@h4", lupMusteri.EditValue);
                komut3.Parameters.AddWithValue("@h5", decimal.Parse(txtFiyat.Text));
                komut3.Parameters.AddWithValue("@h6", decimal.Parse(txtTutar.Text));
                komut3.Parameters.AddWithValue("@h7", txtFaturaId.Text);
                komut3.Parameters.AddWithValue("@h8", mskTarih.Text);
                komut3.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();

                //Stok sayısı azaltma
                SqlCommand komut4 = new SqlCommand("Update TBL_URUNLER set ADET=ADET-@s1 where ID=@s2", sqlBaglantisi.Baglanti());
                komut4.Parameters.AddWithValue("@s1", txtMiktar.Text);
                komut4.Parameters.AddWithValue("@s2", txtUrunId.Text);
                komut4.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (txtFaturaId.Text != "" && lupMusteri.EditValue == null && lupFirma.EditValue == null)
            {
                MessageBox.Show("Firma veya Müşteri Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (txtFaturaId.Text != "" && lupMusteri.EditValue != null && lupFirma.EditValue != null)
            {
                MessageBox.Show("Firma veya müşteriden sadece birisini seçebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
                SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set DURUM=0 where FATURABILGIID=@p1", sqlBaglantisi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Fatura silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ListeleFaturaBilgi();
                Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 where FATURABILGIID=@P9",sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtSeri.Text);
            komut.Parameters.AddWithValue("@p2", txtSiraNo.Text);
            komut.Parameters.AddWithValue("@p3", mskTarih.Text);
            komut.Parameters.AddWithValue("@p4", mskSaat.Text);
            komut.Parameters.AddWithValue("@p5", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p6", txtAlici.Text);
            komut.Parameters.AddWithValue("@p7", txtTeslimEden.Text);
            komut.Parameters.AddWithValue("@p8", txtTeslimAlan.Text);
            komut.Parameters.AddWithValue("@p9", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Fatura bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleFaturaBilgi();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunler fr = new FrmFaturaUrunler();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT from TBL_URUNLER where ID=@p1 and DURUM=1 ", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunId.Text);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                txtUrunAd.Text = reader[0].ToString();
                txtFiyat.Text = reader[1].ToString();

            }
            sqlBaglantisi.Baglanti().Close();
        }

        private void btnTemizle2_Click(object sender, EventArgs e)
        {
            Temizle2();
        }
    }
}
