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
    public partial class frmInPhieuChi : Form
    {
        public frmInPhieuChi()
        {
            InitializeComponent();
        }

        private void frmInPhieuChi_Load(object sender, EventArgs e)
        {
            DataSet1 ds = new DataSet1();
            // TODO: This line of code loads data into the 'DataSet1.dtChi' table. You can move, or remove it, as needed.
            string connString = cPublic.StrCon;
            // TODO: This line of code loads data into the 'DataSet1.dtThu' table. You can move, or remove it, as needed.
            string str = "SELECT CHITIEN.MAPHIEUCT, CHITIEN.DIENGIAI, CHITIEN.NGAYCT, CHITIEN.SOTIEN, NHACUNGCAP.TENNCC, NHACUNGCAP.DIACHI FROM CHITIEN INNER JOIN NHACUNGCAP ON CHITIEN.MANCC = NHACUNGCAP.MANCC where MAPHIEUCT = '" + frmPhieuChi.MaPhieu + "'";
            SqlDataAdapter da = new SqlDataAdapter(str, connString);
            DataTable dt = new DataSet1.dtChiDataTable();
            da.Fill(dt);
            string s = ReadNumber.ByWords(decimal.Parse(dt.Rows[0]["SOTIEN"].ToString())) + " đồng.";
            dt.Rows[0]["BANGCHU"] = s; 
            this.daChi.Fill(this.DataSet1.dtChi);
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            PageSettings ps = new PageSettings();
            ps.Landscape = true;
            PaperSize size = new PaperSize();
            size.Height = 630;
            size.Width = 500;
            ps.PaperSize = size;
            ps.Margins.Bottom = 10;
            ps.Margins.Top = 10;
            ps.Margins.Left = 10;
            ps.Margins.Right = 10;
            reportViewer1.SetPageSettings(ps);
            
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.LocalReport.ReportPath = "../../rptPhieuChi.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            ds.Tables["dtChi"].Clear();
            da.Fill(ds, "dtChi");
            DataSet1TableAdapters.daChi Thu = new DataSet1TableAdapters.daChi();
            Thu.Fill(ds.dtChi);
            

            this.reportViewer1.RefreshReport();
        }
    }
}
