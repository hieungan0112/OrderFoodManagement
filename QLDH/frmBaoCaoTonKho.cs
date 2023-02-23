using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDH
{
    public partial class frmBaoCaoTonKho : Form
    {
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSet1 ds = new DataSet1();
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables["dtTonKho"]));
            this.reportViewer1.LocalReport.ReportPath = "../../rptBaoCaoTonKho.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            string connString = cPublic.StrCon;
            DataSet1TableAdapters.daTonKho TonKho = new DataSet1TableAdapters.daTonKho();
            TonKho.Connection.ConnectionString = connString;
            TonKho.ClearBeforeFill = true;
            TonKho.Fill(ds.dtTonKho);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
