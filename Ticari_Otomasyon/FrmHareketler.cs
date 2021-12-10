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
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleFirmalar()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Exec FirmaHareketler", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl2.DataSource = dataTable;
        }
        void ListeleMusteriler()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Exec MusteriHareketler", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            ListeleFirmalar();
            ListeleMusteriler();
        }
    }
}
