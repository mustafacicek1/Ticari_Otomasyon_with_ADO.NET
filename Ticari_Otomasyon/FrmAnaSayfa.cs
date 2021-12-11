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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void Stoklar()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select URUNAD,SUM(ADET) as 'ADET' from TBL_URUNLER group by URUNAD having SUM(ADET)<=20 Order by SUM(ADET)", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControlStoklar.DataSource = dataTable;
        }
        void Ajanda()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select top 15 TARIH,SAAT,BASLIK from TBL_NOTLAR order by ID desc", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControlAjanda.DataSource = dataTable;
        }
        void FirmaHareketleri()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Exec FirmaHareket2", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControlFirmaHareket.DataSource = dataTable;
        }
        void Fihrist()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AD,TELEFON1 from TBL_FIRMALAR", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControlFihrist.DataSource = dataTable;
        }
        void Haberler()
        {
            XmlTextReader xmlOku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmlOku.Read())
            {
                if (xmlOku.Name=="title")
                {
                    listBox1.Items.Add(xmlOku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            Stoklar();
            Ajanda();
            FirmaHareketleri();
            Fihrist();

            webBrowserDoviz.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");

            Haberler();
        }
    }
}
