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

namespace QLDH
{
    public partial class frmBaoCaoDanhThu : Form
    {
        public frmBaoCaoDanhThu()
        {
            InitializeComponent();
        }
        cPublic Public = new cPublic();
        private void frmBaoCaoDanhThu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.dtDanhThu' table. You can move, or remove it, as needed.
            this.daDanhThu.Fill(this.DataSet1.dtDanhThu);
            this.reportViewer1.RefreshReport();
            string selectString="select MAPHIEUTT, NGAYTT, MAXH, TENKH, SOTIEN AS SOTIENTHU from THUTIEN, KHACHHANG where THUTIEN.MAKH = KHACHHANG.MAKH";
            SqlDataAdapter da = new SqlDataAdapter(selectString, Public.Conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.daDanhThu.Fill(this.DataSet1.dtDanhThu);
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            DataSet1 ds = new DataSet1();
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.LocalReport.ReportPath = "../../rptBaoCaoDanhThu.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            ds.Tables["dtDANHTHU"].Clear();

            da.Fill(ds, "dtDANHTHU");
            DataSet1TableAdapters.daDanhThu Thu = new DataSet1TableAdapters.daDanhThu();
            Thu.Fill(ds.dtDanhThu);
            selectString = "select MAPHIEUCT, NGAYCT, MANH, TENNCC, SOTIEN AS SOTIENCHI from CHITIEN, NHACUNGCAP where CHITIEN.MANCC=NHACUNGCAP.MANCC";
            da = new SqlDataAdapter(selectString, Public.Conn);
            da.Fill(dt);
            this.daDanhThu.Fill(this.DataSet1.dtDanhThu);
            ds.BeginInit();
            this.reportViewer1.LocalReport.DataSources.Add(
                new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            this.reportViewer1.LocalReport.ReportPath = "../../rptBaoCaoDanhThu.rdlc";
            this.reportViewer1.Location = new Point(0, 0);
            ds.EndInit();
            da.Fill(ds, "dtDANHTHU");
            Thu.Fill(ds.dtDanhThu);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
