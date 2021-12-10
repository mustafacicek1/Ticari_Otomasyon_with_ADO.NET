
namespace Ticari_Otomasyon
{
    partial class FrmRaporlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRaporlar));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TBL_MUSTERILERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet = new Ticari_Otomasyon.DboTicariOtomasyonDataSet();
            this.TBL_FIRMALARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet1 = new Ticari_Otomasyon.DboTicariOtomasyonDataSet1();
            this.TBL_GIDERLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet2 = new Ticari_Otomasyon.DboTicariOtomasyonDataSet2();
            this.TBL_PERSONELLERBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DboTicariOtomasyonDataSet3 = new Ticari_Otomasyon.DboTicariOtomasyonDataSet3();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerMusteri = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerFirma = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerGider = new Microsoft.Reporting.WinForms.ReportViewer();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.reportViewerPersonel = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TBL_MUSTERILERTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSetTableAdapters.TBL_MUSTERILERTableAdapter();
            this.TBL_FIRMALARTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSet1TableAdapters.TBL_FIRMALARTableAdapter();
            this.TBL_GIDERLERTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSet2TableAdapters.TBL_GIDERLERTableAdapter();
            this.TBL_PERSONELLERTableAdapter = new Ticari_Otomasyon.DboTicariOtomasyonDataSet3TableAdapters.TBL_PERSONELLERTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_MUSTERILERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_FIRMALARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_GIDERLERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_PERSONELLERBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            this.xtraTabPage4.SuspendLayout();
            this.xtraTabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TBL_MUSTERILERBindingSource
            // 
            this.TBL_MUSTERILERBindingSource.DataMember = "TBL_MUSTERILER";
            this.TBL_MUSTERILERBindingSource.DataSource = this.DboTicariOtomasyonDataSet;
            // 
            // DboTicariOtomasyonDataSet
            // 
            this.DboTicariOtomasyonDataSet.DataSetName = "DboTicariOtomasyonDataSet";
            this.DboTicariOtomasyonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBL_FIRMALARBindingSource
            // 
            this.TBL_FIRMALARBindingSource.DataMember = "TBL_FIRMALAR";
            this.TBL_FIRMALARBindingSource.DataSource = this.DboTicariOtomasyonDataSet1;
            // 
            // DboTicariOtomasyonDataSet1
            // 
            this.DboTicariOtomasyonDataSet1.DataSetName = "DboTicariOtomasyonDataSet1";
            this.DboTicariOtomasyonDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBL_GIDERLERBindingSource
            // 
            this.TBL_GIDERLERBindingSource.DataMember = "TBL_GIDERLER";
            this.TBL_GIDERLERBindingSource.DataSource = this.DboTicariOtomasyonDataSet2;
            // 
            // DboTicariOtomasyonDataSet2
            // 
            this.DboTicariOtomasyonDataSet2.DataSetName = "DboTicariOtomasyonDataSet2";
            this.DboTicariOtomasyonDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TBL_PERSONELLERBindingSource
            // 
            this.TBL_PERSONELLERBindingSource.DataMember = "TBL_PERSONELLER";
            this.TBL_PERSONELLERBindingSource.DataSource = this.DboTicariOtomasyonDataSet3;
            // 
            // DboTicariOtomasyonDataSet3
            // 
            this.DboTicariOtomasyonDataSet3.DataSetName = "DboTicariOtomasyonDataSet3";
            this.DboTicariOtomasyonDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1924, 768);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.reportViewerMusteri);
            this.xtraTabPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.ImageOptions.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1922, 738);
            this.xtraTabPage1.Text = "Müşteri Raporları";
            // 
            // reportViewerMusteri
            // 
            this.reportViewerMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetMüsteriler";
            reportDataSource1.Value = this.TBL_MUSTERILERBindingSource;
            this.reportViewerMusteri.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerMusteri.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportMüsteri.rdlc";
            this.reportViewerMusteri.Location = new System.Drawing.Point(0, 0);
            this.reportViewerMusteri.Name = "reportViewerMusteri";
            this.reportViewerMusteri.ServerReport.BearerToken = null;
            this.reportViewerMusteri.Size = new System.Drawing.Size(1922, 738);
            this.reportViewerMusteri.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.reportViewerFirma);
            this.xtraTabPage2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.ImageOptions.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1922, 738);
            this.xtraTabPage2.Text = "Firma Raporları";
            // 
            // reportViewerFirma
            // 
            this.reportViewerFirma.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetFirmalar";
            reportDataSource2.Value = this.TBL_FIRMALARBindingSource;
            this.reportViewerFirma.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerFirma.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportFirmalar.rdlc";
            this.reportViewerFirma.Location = new System.Drawing.Point(0, 0);
            this.reportViewerFirma.Name = "reportViewerFirma";
            this.reportViewerFirma.ServerReport.BearerToken = null;
            this.reportViewerFirma.Size = new System.Drawing.Size(1922, 738);
            this.reportViewerFirma.TabIndex = 1;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.reportViewerGider);
            this.xtraTabPage4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage4.ImageOptions.Image")));
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1922, 738);
            this.xtraTabPage4.Text = "Gider Raporları";
            // 
            // reportViewerGider
            // 
            this.reportViewerGider.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSetGider";
            reportDataSource3.Value = this.TBL_GIDERLERBindingSource;
            this.reportViewerGider.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerGider.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportGider.rdlc";
            this.reportViewerGider.Location = new System.Drawing.Point(0, 0);
            this.reportViewerGider.Name = "reportViewerGider";
            this.reportViewerGider.ServerReport.BearerToken = null;
            this.reportViewerGider.Size = new System.Drawing.Size(1922, 738);
            this.reportViewerGider.TabIndex = 1;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.reportViewerPersonel);
            this.xtraTabPage5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage5.ImageOptions.Image")));
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1922, 738);
            this.xtraTabPage5.Text = "Personel Raporları";
            // 
            // reportViewerPersonel
            // 
            this.reportViewerPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSetPersonel";
            reportDataSource4.Value = this.TBL_PERSONELLERBindingSource;
            this.reportViewerPersonel.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerPersonel.LocalReport.ReportEmbeddedResource = "Ticari_Otomasyon.ReportPersonel.rdlc";
            this.reportViewerPersonel.Location = new System.Drawing.Point(0, 0);
            this.reportViewerPersonel.Name = "reportViewerPersonel";
            this.reportViewerPersonel.ServerReport.BearerToken = null;
            this.reportViewerPersonel.Size = new System.Drawing.Size(1922, 738);
            this.reportViewerPersonel.TabIndex = 1;
            // 
            // TBL_MUSTERILERTableAdapter
            // 
            this.TBL_MUSTERILERTableAdapter.ClearBeforeFill = true;
            // 
            // TBL_FIRMALARTableAdapter
            // 
            this.TBL_FIRMALARTableAdapter.ClearBeforeFill = true;
            // 
            // TBL_GIDERLERTableAdapter
            // 
            this.TBL_GIDERLERTableAdapter.ClearBeforeFill = true;
            // 
            // TBL_PERSONELLERTableAdapter
            // 
            this.TBL_PERSONELLERTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 768);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FrmRaporlar";
            this.Text = "RAPORLAR";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TBL_MUSTERILERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_FIRMALARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_GIDERLERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_PERSONELLERBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DboTicariOtomasyonDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage4.ResumeLayout(false);
            this.xtraTabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerMusteri;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerFirma;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerGider;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerPersonel;
        private System.Windows.Forms.BindingSource TBL_MUSTERILERBindingSource;
        private DboTicariOtomasyonDataSet DboTicariOtomasyonDataSet;
        private DboTicariOtomasyonDataSetTableAdapters.TBL_MUSTERILERTableAdapter TBL_MUSTERILERTableAdapter;
        private System.Windows.Forms.BindingSource TBL_FIRMALARBindingSource;
        private DboTicariOtomasyonDataSet1 DboTicariOtomasyonDataSet1;
        private DboTicariOtomasyonDataSet1TableAdapters.TBL_FIRMALARTableAdapter TBL_FIRMALARTableAdapter;
        private System.Windows.Forms.BindingSource TBL_GIDERLERBindingSource;
        private DboTicariOtomasyonDataSet2 DboTicariOtomasyonDataSet2;
        private DboTicariOtomasyonDataSet2TableAdapters.TBL_GIDERLERTableAdapter TBL_GIDERLERTableAdapter;
        private System.Windows.Forms.BindingSource TBL_PERSONELLERBindingSource;
        private DboTicariOtomasyonDataSet3 DboTicariOtomasyonDataSet3;
        private DboTicariOtomasyonDataSet3TableAdapters.TBL_PERSONELLERTableAdapter TBL_PERSONELLERTableAdapter;
    }
}