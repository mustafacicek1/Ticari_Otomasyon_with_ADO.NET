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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleUrunler()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from TBL_URUNLER",
                sqlBaglantisi.Baglanti());
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;

        }
        void Temizle()
        {
            txtAd.Text = "";
            txtAlisFiyatı.Text = "";
            txtId.Text = "";
            txtMarka.Text = "";
            txtModel.Text = "";
            txtSatisFiyati.Text = "";
            mskYil.Text = "";
            nudAdet.Value = 0;
            rchDetay.Text = "";
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            ListeleUrunler();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //Verileri kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(nudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyatı.Text.ToString()));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyati.Text.ToString()));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleUrunler();
            Temizle();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutSil = new SqlCommand("Delete from TBL_URUNLER where ID=@p1", sqlBaglantisi.Baglanti());
                komutSil.Parameters.AddWithValue("@p1", txtId.Text);
                komutSil.ExecuteNonQuery();
                sqlBaglantisi.Baglanti();
                MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ListeleUrunler();
                Temizle();
            }
            catch
            {
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dataRow["ID"].ToString();
            txtAd.Text = dataRow["URUNAD"].ToString();
            txtMarka.Text = dataRow["MARKA"].ToString();
            txtModel.Text = dataRow["MODEL"].ToString();
            mskYil.Text = dataRow["YIL"].ToString();
            nudAdet.Value = int.Parse(dataRow["ADET"].ToString());
            txtAlisFiyatı.Text = dataRow["ALISFIYAT"].ToString();
            txtSatisFiyati.Text = dataRow["SATISFIYAT"].ToString();
            rchDetay.Text = dataRow["DETAY"].ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", txtModel.Text);
            komut.Parameters.AddWithValue("@p4", mskYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(nudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtAlisFiyatı.Text.ToString()));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtSatisFiyati.Text.ToString()));
            komut.Parameters.AddWithValue("@p8", rchDetay.Text);
            komut.Parameters.AddWithValue("@p9", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Ürün güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ListeleUrunler();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
