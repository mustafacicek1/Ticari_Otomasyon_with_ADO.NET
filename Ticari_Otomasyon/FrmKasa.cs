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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void MusteriHareket()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Execute MusteriHareketler", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void FirmaHareket()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Execute FirmaHareketler", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl2.DataSource = dataTable;
        }
        void GiderListesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_GIDERLER", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControlGider.DataSource = dataTable;
        }
        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblAktifKullanici.Text = ad;
            MusteriHareket();
            FirmaHareket();
            GiderListesi();

            //Toplam tutarı hesaplama
            SqlCommand komut1 = new SqlCommand("Select SUM(TUTAR) from TBL_FATURADETAY", sqlBaglantisi.Baglanti());
            SqlDataReader reader1 = komut1.ExecuteReader();
            while (reader1.Read())
            {
                lblKasaToplam.Text = reader1[0].ToString() + " ₺";
            }
            sqlBaglantisi.Baglanti().Close();

            //Son ayın faturaları
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc",sqlBaglantisi.Baglanti());
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                lblOdemeler.Text = reader2[0].ToString() + " ₺";
            }
            sqlBaglantisi.Baglanti().Close();

            //Son ayın personel Maaşları
            SqlCommand komut3 = new SqlCommand("Select MAASLAR FROM TBL_GIDERLER order by ID asc", sqlBaglantisi.Baglanti());
            SqlDataReader reader3 = komut3.ExecuteReader();
            while (reader3.Read())
            {
                lblPersonelMaaslari.Text = reader3[0].ToString() + " ₺";
            }
            sqlBaglantisi.Baglanti().Close();

            //Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("Select Count(*) from TBL_MUSTERILER where DURUM=1", sqlBaglantisi.Baglanti());
            SqlDataReader reader4 = komut4.ExecuteReader();
            while (reader4.Read())
            {
                lblMusteriSayisi.Text = reader4[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();

            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("Select Count(*) from TBL_FIRMALAR where DURUM=1", sqlBaglantisi.Baglanti());
            SqlDataReader reader5 = komut5.ExecuteReader();
            while (reader5.Read())
            {
                lblFirmaSayisi.Text = reader5[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();

            //Toplam Firma Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("Select Count(Distinct(IL)) from TBL_FIRMALAR where DURUM=1", sqlBaglantisi.Baglanti());
            SqlDataReader reader6 = komut6.ExecuteReader();
            while (reader6.Read())
            {
                lblSehirSayisi.Text = reader6[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();

            //Toplam Müşteri Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("Select Count(Distinct(IL)) from TBL_MUSTERILER where DURUM=1", sqlBaglantisi.Baglanti());
            SqlDataReader reader7 = komut7.ExecuteReader();
            while (reader7.Read())
            {
                lblSehirSayisi2.Text = reader7[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();

            //Toplam Ürün Sayısı
            SqlCommand komut9 = new SqlCommand("Select Sum(ADET) from TBL_URUNLER where DURUM=1", sqlBaglantisi.Baglanti());
            SqlDataReader reader9 = komut9.ExecuteReader();
            while (reader9.Read())
            {
                lblStokSayisi.Text = reader9[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();

        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik
            if (sayac>0 && sayac<=5)
            {

                groupControl10.Text = "ELEKTRİK";
                chartControl1.Series["Aylar"].View.Color = Color.Black;
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader10 = komut10.ExecuteReader();
                while (reader10.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader10[0], reader10[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Su
            if (sayac>5 && sayac<=10)
            {
                groupControl10.Text = "SU";
                chartControl1.Series["Aylar"].View.Color = Color.Purple;
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Dogalgaz
            if (sayac >10 && sayac <= 15)
            {
                groupControl10.Text = "DOGALGAZ";
                chartControl1.Series["Aylar"].View.Color = Color.Yellow;
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //İnternet
            if (sayac > 15 && sayac <= 20)
            {
                groupControl10.Text = "İNTERNET";
                chartControl1.Series["Aylar"].View.Color = Color.Red;
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Ekstra
            if (sayac > 20 && sayac <= 25)
            {
                groupControl10.Text = "EKSTRA";
                chartControl1.Series["Aylar"].View.Color = Color.Brown;
                chartControl1.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl1.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }
            if (sayac==26)
            {
                sayac = 0;
            }
        }

        int sayac2;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;

            //Ekstra
            if (sayac2 > 0 && sayac2 <= 5)
            {
                groupControl11.Text = "EKSTRA";
                chartControl2.Series["Aylar"].View.Color = Color.Brown;
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,EKSTRA from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //İnternet
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl11.Text = "İNTERNET";
                chartControl2.Series["Aylar"].View.Color = Color.Red;
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,INTERNET from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Dogalgaz
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl11.Text = "DOGALGAZ";
                chartControl2.Series["Aylar"].View.Color = Color.Yellow;
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,DOGALGAZ from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Su
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl11.Text = "SU";
                chartControl2.Series["Aylar"].View.Color = Color.Purple;
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut11 = new SqlCommand("Select top 4 AY,SU from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader11 = komut11.ExecuteReader();
                while (reader11.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader11[0], reader11[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }

            //Elektrik
            if (sayac2 > 20 && sayac2 <= 25)
            {

                groupControl11.Text = "ELEKTRİK";
                chartControl2.Series["Aylar"].View.Color = Color.Black;
                chartControl2.Series["Aylar"].Points.Clear();
                SqlCommand komut10 = new SqlCommand("Select top 4 AY,ELEKTRIK from TBL_GIDERLER order by ID desc", sqlBaglantisi.Baglanti());
                SqlDataReader reader10 = komut10.ExecuteReader();
                while (reader10.Read())
                {
                    chartControl2.Series["Aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(reader10[0], reader10[1]));
                }
                sqlBaglantisi.Baglanti().Close();
            }
            if (sayac2 == 26)
            {
                sayac2 = 0;
            }
        }
    }
}
