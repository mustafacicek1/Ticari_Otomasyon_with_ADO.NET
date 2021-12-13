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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select URUNAD,Sum(ADET) as 'MIKTAR' from TBL_URUNLER where DURUM=1 group by URUNAD", sqlBaglantisi.Baglanti());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;

            //Charta stok miktarı listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD,Sum(ADET) as 'MIKTAR' from TBL_URUNLER where DURUM=1 group by URUNAD", sqlBaglantisi.Baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                chartControl1.Series["Ürünler"].Points.AddPoint(Convert.ToString(reader[0]),int.Parse( reader[1].ToString()));
            }
            sqlBaglantisi.Baglanti().Close();
            chartControl1.Series["Ürünler"].LegendTextPattern = "{A}";

            //Charta sehir firma sayısı çekmed
            SqlCommand komut2 = new SqlCommand("Select IL,Count(*) from TBL_FIRMALAR where DURUM=1  Group By IL ", sqlBaglantisi.Baglanti());
            SqlDataReader reader2 = komut2.ExecuteReader();
            while (reader2.Read())
            {
                chartControl2.Series["Firmalar"].Points.AddPoint(Convert.ToString(reader2[0]), int.Parse(reader2[1].ToString()));
            }
            sqlBaglantisi.Baglanti().Close();
            chartControl2.Series["Firmalar"].LegendTextPattern = "{A}";
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
            }
            fr.Show();
        }
    }
}
