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
using System.Drawing.Printing;

namespace QLDH
{
    public partial class frmInPhieuThu : Form
    {
        public frmInPhieuThu()
        {
            InitializeComponent();
        }

        private void frmInPhieuThu_Load(object sender, EventArgs e)
        {
            string connString = cPublic.StrCon;
            // TODO: This line of code loads data into the 'DataSet1.dtThu' table. You can move, or remove it, as needed.
            string str = "SELECT THUTIEN.MAPHIEUTT, THUTIEN.DIENGIAI, THUTIEN.NGAYTT, THUTIEN.SOTIEN, KHACHHANG.TENKH, KHACHHANG.DIACHI FROM THUTIEN INNER JOIN KHACHHANG ON THUTIEN.MAKH = KHACHHANG.MAKH where MAPHIEUTT = '" + frmPhieuThu.MaPhieu + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, connString);
            DataTable dt = new DataSet1.dtThuDataTable();
            da.Fill(dt);
            string s = ReadNumber.ByWords(decimal.Parse(dt.Rows[0]["SOTIEN"].ToString())) + " đồng.";
            dt.Rows[0]["BANGCHU"] = s;
            this.daThu.Fill(this.DataSet1.dtThu);
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            PageSettings ps = new PageSettings();
            ps.Landscape = true;
            PaperSize size = new PaperSize();
            size.Height = 650;
            size.Width = 500;
            ps.PaperSize = size;
            ps.Margins.Bottom = 10;
            ps.Margins.Top = 10;
            ps.Margins.Left = 10;
            ps.Margins.Right = 10;
            reportViewer1.SetPageSettings(ps);
            DataSet1 ds = new DataSet1();
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.LocalReport.ReportPath = "../../rptPhieuThu.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            ds.Tables["dtThu"].Clear();
            da.Fill(ds, "dtThu");
            DataSet1TableAdapters.daThu Thu = new DataSet1TableAdapters.daThu();
            Thu.Fill(ds.dtThu);

            this.reportViewer1.RefreshReport();
        }
    }
}
