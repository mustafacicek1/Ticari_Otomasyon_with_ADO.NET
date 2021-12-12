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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleBankalar()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Execute BankaBilgileri", sqlBaglantisi.Baglanti());//procedure çağırma
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
        void FirmaListesi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,AD from TBL_FIRMALAR", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            lupFirma.Properties.ValueMember = "ID";
            lupFirma.Properties.DisplayMember = "AD";
            lupFirma.Properties.DataSource = dataTable;

        }
        void Temizle()
        {
            txtBankaAd.Text = "";
            txtHesapNo.Text = "";
            txtHesapTuru.Text = "";
            txtIBAN.Text = "";
            txtId.Text = "";
            txtSube.Text = "";
            txtYetkili.Text = "";
            mskTarih.Text = "";
            mskTel.Text = "";
            cbxIl.Text = "";
            cbxIlce.Text = "";
        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            ListeleBankalar();
            SehirListesi();
            FirmaListesi();
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into TBL_BANKALAR " +
                "(BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values" +
                "(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", cbxIl.Text);
            komut.Parameters.AddWithValue("@p3", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIBAN.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTel.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lupFirma.EditValue);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Banka bilgisi sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListeleBankalar();
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
            if (dataRow != null)
            {
                txtId.Text = dataRow["ID"].ToString();
                txtBankaAd.Text = dataRow["BANKAADI"].ToString();
                cbxIl.Text = dataRow["IL"].ToString();
                cbxIlce.Text = dataRow["ILCE"].ToString();
                txtSube.Text = dataRow["SUBE"].ToString();
                txtIBAN.Text = dataRow["IBAN"].ToString();
                txtHesapNo.Text = dataRow["HESAPNO"].ToString();
                txtYetkili.Text = dataRow["YETKILI"].ToString();
                mskTel.Text = dataRow["TELEFON"].ToString();
                mskTarih.Text = dataRow["TARIH"].ToString();
                txtHesapTuru.Text = dataRow["HESAPTURU"].ToString();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("Delete from TBL_BANKALAR where ID=@p1", sqlBaglantisi.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtId.Text);
                komut.ExecuteNonQuery();
                sqlBaglantisi.Baglanti().Close();
                MessageBox.Show("Banka bilgisi sistemden silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ListeleBankalar();
                Temizle();
            }
            catch 
            {
            }
           

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4," +
                "IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 where ID=@P12", sqlBaglantisi.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtBankaAd.Text);
            komut.Parameters.AddWithValue("@p2", cbxIl.Text);
            komut.Parameters.AddWithValue("@p3", cbxIlce.Text);
            komut.Parameters.AddWithValue("@p4", txtSube.Text);
            komut.Parameters.AddWithValue("@p5", txtIBAN.Text);
            komut.Parameters.AddWithValue("@p6", txtHesapNo.Text);
            komut.Parameters.AddWithValue("@p7", txtYetkili.Text);
            komut.Parameters.AddWithValue("@p8", mskTel.Text);
            komut.Parameters.AddWithValue("@p9", mskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtHesapTuru.Text);
            komut.Parameters.AddWithValue("@p11", lupFirma.EditValue);
            komut.Parameters.AddWithValue("@p12", txtId.Text);
            komut.ExecuteNonQuery();
            sqlBaglantisi.Baglanti().Close();
            MessageBox.Show("Banka bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            ListeleBankalar();
            Temizle();
        }
    }
}
