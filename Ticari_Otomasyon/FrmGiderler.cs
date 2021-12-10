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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleGiderler()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_GIDERLER Order By ID Asc", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void Temizle()
        {
            txtDogalgaz.Text = "";
            txtEkstra.Text = "";
            txtElektrik.Text = "";
            txtId.Text = "";
            txtInternet.Text = "";
            txtMaas.Text = "";
            txtSu.Text = "";
            cbxAy.Text = "";
            cbxYil.Text = "";
            rchNotlar.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            ListeleGiderler();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", cbxAy.Text);
            komut.Parameters.AddWithValue("@p2", cbxYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaas.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", rchNotlar.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Gider tabloya eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleGiderler();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow!=null)
            {
                txtId.Text = dataRow["ID"].ToString();
                cbxAy.Text = dataRow["AY"].ToString();
                cbxYil.Text = dataRow["YIL"].ToString();
                txtElektrik.Text = dataRow["ELEKTRIK"].ToString();
                txtSu.Text = dataRow["SU"].ToString();
                txtDogalgaz.Text = dataRow["DOGALGAZ"].ToString();
                txtInternet.Text = dataRow["INTERNET"].ToString();
                txtMaas.Text = dataRow["MAASLAR"].ToString();
                txtEkstra.Text = dataRow["EKSTRA"].ToString();
                rchNotlar.Text = dataRow["NOTLAR"].ToString();
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_GIDERLER where ID=@p1", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Gider listeden silindi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            ListeleGiderler();
            Temizle();
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_GIDERLER set AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@P10",sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", cbxAy.Text);
            komut.Parameters.AddWithValue("@p2", cbxYil.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtInternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtMaas.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", rchNotlar.Text);
            komut.Parameters.AddWithValue("@p10", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Gider bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleGiderler();
            Temizle();
        }
    }
}
