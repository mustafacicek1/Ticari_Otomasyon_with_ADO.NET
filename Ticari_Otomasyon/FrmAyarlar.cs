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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void Listele()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_ADMIN", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void Temizle()
        {
            txtKullaniciAd.Text = "";
            txtSifre.Text = "";
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                txtKullaniciAd.Text = dataRow["KULLANICIAD"].ToString();
                txtSifre.Text = dataRow["SIFRE"].ToString();
            }
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_ADMIN values (@p1,@p2)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Yeni kullanıcı sisteme kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("update TBL_ADMIN set SIFRE=@P1 where KULLANICIAD=@P2", sqlBaglantisi.Baglanti());
            komut1.Parameters.AddWithValue("@p1", txtSifre.Text);
            komut1.Parameters.AddWithValue("@p2", txtKullaniciAd.Text);
            komut1.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Kullanıcı güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_ADMIN where KULLANICIAD=@P1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtKullaniciAd.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Kullanıcı sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
