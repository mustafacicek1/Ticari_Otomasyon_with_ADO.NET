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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        void ListeleMusteriBilgi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBL_MUSTERILER ", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        void ListeleFirmaBilgi()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX from TBL_FIRMALAR ", sqlBaglantisi.Baglanti());
            adapter.Fill(dataTable);
            gridControl2.DataSource = dataTable;
        }
        private void FrmRehber_Load(object sender, EventArgs e)
        {
            ListeleMusteriBilgi();
            ListeleFirmaBilgi();
           
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail  = new FrmMail();
            DataRow dataRow = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dataRow!=null)
            {
                frmMail.mail = dataRow["MAIL"].ToString();
                frmMail.Show();
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail();
            DataRow dataRow = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dataRow != null)
            {
                frmMail.mail = dataRow["MAIL"].ToString();
                frmMail.Show();
            }
        }
    }
}
