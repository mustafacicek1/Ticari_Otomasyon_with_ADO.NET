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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleNotlar()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_NOTLAR",sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void Temizle()
        {
            txtHitap.Text = "";
            txtId.Text = "";
            txtOlusturan.Text = "";
            txtBaslik.Text = "";
            mskSaat.Text = "";
            mskTarih.Text = "";
            rchDetay.Text = "";
        }
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            ListeleNotlar();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)",sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rchDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Not bilgisi sisteme eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ListeleNotlar();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow!=null)
            {
                txtId.Text = dataRow["ID"].ToString();
                mskTarih.Text = dataRow["TARIH"].ToString();
                mskSaat.Text = dataRow["SAAT"].ToString();
                txtBaslik.Text = dataRow["BASLIK"].ToString();
                rchDetay.Text = dataRow["DETAY"].ToString();
                txtOlusturan.Text = dataRow["OLUSTURAN"].ToString();
                txtHitap.Text = dataRow["HITAP"].ToString();

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_NOTLAR where ID=@P1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Not bilgisi sistemden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ListeleNotlar();
            Temizle();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_NOTLAR set TARIH=@P1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@P7", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", mskTarih.Text);
            komut.Parameters.AddWithValue("@p2", mskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", rchDetay.Text);
            komut.Parameters.AddWithValue("@p5", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p6", txtHitap.Text);
            komut.Parameters.AddWithValue("@p7", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Not bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleNotlar();
            Temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay frmNotDetay = new FrmNotDetay();
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow!=null)
            {
                frmNotDetay.notDetay = dataRow["DETAY"].ToString();
            }
            frmNotDetay.Show();
        }
    }
}
