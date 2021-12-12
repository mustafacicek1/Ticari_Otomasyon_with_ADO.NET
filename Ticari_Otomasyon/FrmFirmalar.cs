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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleFirmalar()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from TBL_FIRMALAR", sqlBaglantisi.Baglanti());
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
        void CariKodAciklamalar()
        {
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR", sqlBaglantisi.Baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                rchKod1.Text = reader[0].ToString();
            }
            sqlBaglantisi.Baglanti().Close();
        }
        void Temizle()
        {
            txtAd.Text = "";
            txtId.Text = "";
            txtKod1.Text = "";
            txtKod2.Text = "";
            txtKod3.Text = "";
            txtMail.Text = "";
            txtSektor.Text = "";
            txtVergiDairesi.Text = "";
            txtYetkili.Text = "";
            txtYetkiliGorev.Text = "";
            mskFax.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            mskTel3.Text = "";
            mskYetkiliTcNo.Text = "";
            rchAdres.Text = "";
            cbxIl.Text = "";
            cbxIlce.Text = "";
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            ListeleFirmalar();
            
            SehirListesi();
            
            CariKodAciklamalar();
            
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow != null)
            {
                txtId.Text = dataRow["ID"].ToString();
                txtAd.Text = dataRow["AD"].ToString();
                txtYetkiliGorev.Text = dataRow["YETKILISTATU"].ToString();
                txtYetkili.Text = dataRow["YETKILIADSOYAD"].ToString();
                mskYetkiliTcNo.Text = dataRow["YETKILITC"].ToString();
                txtSektor.Text = dataRow["SEKTOR"].ToString();
                mskTel1.Text = dataRow["TELEFON1"].ToString();
                mskTel2.Text = dataRow["TELEFON2"].ToString();
                mskTel3.Text = dataRow["TELEFON3"].ToString();
                txtMail.Text = dataRow["MAIL"].ToString();
                mskFax.Text = dataRow["FAX"].ToString();
                cbxIl.Text = dataRow["IL"].ToString();
                cbxIlce.Text = dataRow["ILCE"].ToString();
                txtVergiDairesi.Text = dataRow["VERGIDAIRE"].ToString();
                rchAdres.Text = dataRow["ADRES"].ToString();
                txtKod1.Text = dataRow["OZELKOD1"].ToString();
                txtKod2.Text = dataRow["OZELKOD2"].ToString();
                txtKod3.Text = dataRow["OZELKOD3"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR " +
                "(AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)",
                sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskYetkiliTcNo.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cbxIl.Text);
            komut.Parameters.AddWithValue("@p12", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Firma sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleFirmalar();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Delete from TBL_FIRMALAR where ID=@p1", sqlBaglantisi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                ListeleFirmalar();
                MessageBox.Show("Firma listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Temizle();
            }
            catch
            {
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR set AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7," +
                "TELEFON3=@P8,MAIL=@P9,FAX=@P10,IL=@P11,ILCE=@P12,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 where ID=@P18",sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtYetkiliGorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskYetkiliTcNo.Text);
            komut.Parameters.AddWithValue("@p5", txtSektor.Text);
            komut.Parameters.AddWithValue("@p6", mskTel1.Text);
            komut.Parameters.AddWithValue("@p7", mskTel2.Text);
            komut.Parameters.AddWithValue("@p8", mskTel3.Text);
            komut.Parameters.AddWithValue("@p9", txtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskFax.Text);
            komut.Parameters.AddWithValue("@p11", cbxIl.Text);
            komut.Parameters.AddWithValue("@p12", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p13", txtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@p14", rchAdres.Text);
            komut.Parameters.AddWithValue("@p15", txtKod1.Text);
            komut.Parameters.AddWithValue("@p16", txtKod2.Text);
            komut.Parameters.AddWithValue("@p17", txtKod3.Text);
            komut.Parameters.AddWithValue("@p18", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Firma bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ListeleFirmalar();
            Temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
