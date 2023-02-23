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
    public partial class frmBaoCaoHangXuat : Form
    {
        public frmBaoCaoHangXuat()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHangXuat_Load(object sender, EventArgs e)
        {
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSet1 ds = new DataSet1();
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables["dtHangXuat"]));
            this.reportViewer1.LocalReport.ReportPath = "../../rptBaoCaoHangXuat.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            string connString = cPublic.StrCon;
            DataSet1TableAdapters.daHangXuat HangXuat = new DataSet1TableAdapters.daHangXuat();
            HangXuat.Connection.ConnectionString = connString;
            HangXuat.ClearBeforeFill = true;
            HangXuat.Fill(ds.dtHangXuat);
            this.reportViewer1.RefreshReport();
        }
    }
}
