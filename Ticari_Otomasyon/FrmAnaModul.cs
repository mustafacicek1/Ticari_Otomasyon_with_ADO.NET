using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }
        FrmUrunler frmUrunler;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmUrunler == null || frmUrunler.IsDisposed)
            {
                frmUrunler = new FrmUrunler();
                frmUrunler.MdiParent = this;     
                frmUrunler.Show();
            }

        }

        public string kullanici;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (frmAnaSayfa == null )
            {
                frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.MdiParent = this;
                frmAnaSayfa.Show();
            }
        }
        FrmMusteriler frmMusteriler;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmMusteriler==null || frmMusteriler.IsDisposed)
            {
                frmMusteriler = new FrmMusteriler();
                frmMusteriler.MdiParent = this;
                frmMusteriler.Show();
            }
        }

        FrmFirmalar frmFirmalar;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmFirmalar==null || frmFirmalar.IsDisposed)
            {
                frmFirmalar = new FrmFirmalar();
                frmFirmalar.MdiParent = this;
                frmFirmalar.Show();
            }
        }

        FrmPersonel frmPersonel;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmPersonel==null || frmPersonel.IsDisposed)
            {
                frmPersonel = new FrmPersonel();
                frmPersonel.MdiParent = this;
                frmPersonel.Show();
            }
        }

        FrmRehber frmRehber;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmRehber==null || frmRehber.IsDisposed)
            {
                frmRehber = new FrmRehber();
                frmRehber.MdiParent = this;
                frmRehber.Show();
            }
        }

        FrmGiderler frmGiderler;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmGiderler==null || frmGiderler.IsDisposed)
            {
                frmGiderler = new FrmGiderler();
                frmGiderler.MdiParent = this;
                frmGiderler.Show();
            }
        }

        FrmBankalar frmBankalar;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmBankalar==null || frmBankalar.IsDisposed)
            {
                frmBankalar = new FrmBankalar();
                frmBankalar.MdiParent = this;
                frmBankalar.Show();
            }
        }

        FrmFaturalar frmFaturalar;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmFaturalar==null || frmFaturalar.IsDisposed)
            {
                frmFaturalar = new FrmFaturalar();
                frmFaturalar.MdiParent = this;
                frmFaturalar.Show();
            }
        }

        FrmNotlar frmNotlar;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmNotlar==null || frmNotlar.IsDisposed)
            {
                frmNotlar = new FrmNotlar();
                frmNotlar.MdiParent = this;
                frmNotlar.Show();
            }
        }

        FrmHareketler frmHareketler;
        private void BtnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmHareketler==null || frmHareketler.IsDisposed)
            {
                frmHareketler = new FrmHareketler();
                frmHareketler.MdiParent = this;
                frmHareketler.Show();
            }
        }

        FrmRaporlar frmRaporlar;
        private void BtnRaporlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmRaporlar == null || frmRaporlar.IsDisposed)
            {
                frmRaporlar = new FrmRaporlar();
                frmRaporlar.MdiParent = this;
                frmRaporlar.Show();
            }
        }

        FrmStoklar frmStoklar;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmStoklar==null || frmStoklar.IsDisposed)
            {
                frmStoklar = new FrmStoklar();
                frmStoklar.MdiParent = this;
                frmStoklar.Show();
            }
        }

        FrmAyarlar frmAyarlar;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAyarlar == null || frmAyarlar.IsDisposed)
            {
                frmAyarlar = new FrmAyarlar();
                frmAyarlar.Show();
            }
        }

        FrmKasa frmKasa;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmKasa==null || frmKasa.IsDisposed)
            {
                frmKasa = new FrmKasa();
                frmKasa.ad = kullanici;
                frmKasa.MdiParent = this;
                frmKasa.Show();
            }
        }

        FrmAnaSayfa frmAnaSayfa;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frmAnaSayfa==null || frmAnaSayfa.IsDisposed)
            {
                frmAnaSayfa = new FrmAnaSayfa();
                frmAnaSayfa.MdiParent = this;
                frmAnaSayfa.Show();
            }
        }

        private bool Kapatsorgu;
        DialogResult dr = DialogResult.No;
        private void FrmAnaModul_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Kapatsorgu) // ! False ise 
            {
                dr = MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Kapatsorgu = dr == DialogResult.Yes;
            }
            if (dr == DialogResult.Yes)
            {
                if (Kapatsorgu) // True ise
                {
                    //sorularımızın cevaplarını aldığımız yer.
                    Application.Exit();
                }
                Kapatsorgu = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }

}
