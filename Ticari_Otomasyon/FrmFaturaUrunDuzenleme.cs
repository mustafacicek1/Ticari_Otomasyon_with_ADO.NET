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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        public string urunid;
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            txtUrunId.Text = urunid;

            SqlCommand komut = new SqlCommand("Select * from TBL_FATURADETAY where FATURAURUNID=@P1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", urunid);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                txtFiyat.Text = reader[3].ToString();
                txtMiktar.Text = reader[2].ToString();
                txtTutar.Text = reader[4].ToString();
                txtUrunAd.Text = reader[1].ToString();

                sqlBaglantisi.Baglanti().Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FATURADETAY set URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 where FATURAURUNID=@P5", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMiktar.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtTutar.Text));
            komut.Parameters.AddWithValue("@p5", txtUrunId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Değişiklikler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_FATURADETAY where FATURAURUNID=@p1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtUrunId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Ürün Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
