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
    public partial class frmPhieuChi : Form
    {
        cPublic Public = new cPublic();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection Conn;
        public frmPhieuChi()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }
        static string maphieu;

        public static string MaPhieu
        {
            get { return maphieu; }
            set { maphieu = value; }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadComboBox_NH()
        {
            string str = "select * from NHAPHANG where MANH not in (select MANH from CHITIEN)";
            SqlDataAdapter da = new SqlDataAdapter(str, Conn);
            da.Fill(ds, "NHAPHANG");
            cbbMaNH.DataSource = ds.Tables["NHAPHANG"];
            cbbMaNH.ValueMember = "MANH";

        }
        public void LoadComboBox_NCC()
        {
            string str = "select * from NHACUNGCAP";
            SqlDataAdapter da = new SqlDataAdapter(str, Conn);
            da.Fill(ds, "NHACUNGCAP");
            cbbNCC.DataSource = ds.Tables["NHACUNGCAP"];
            cbbNCC.ValueMember = "MANCC";
            cbbNCC.DisplayMember = "TENNCC";
        }
        void Load_DataGridView()
        {
            string str = "select * from CHITIEN";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(ds, "CHITIEN");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["CHITIEN"].Columns[0];
            ds.Tables["CHITIEN"].PrimaryKey = key;
            str = "select MAPHIEUCT,TENNCC,DIENGIAI,NGAYCT,SOTIEN, MANH from CHITIEN,  NHACUNGCAP where NHACUNGCAP.MANCC=CHITIEN.MANCC";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(ds, "THONGTIN");
            dtgvList.DataSource = ds.Tables["THONGTIN"];
        }
        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            LoadComboBox_NH();
            LoadComboBox_NCC();
            Load_DataGridView();
            if (cbbMaNH.Items.Count == 0)
                cbbNCC.SelectedIndex = -1;
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from CHITIEN", Conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "CHITIEN");
            DataRow dr = ds.Tables["CHITIEN"].NewRow();
            dr["MAPHIEUCT"] = "CT" + Public.TaoMa("CHITIEN", "MAPHIEUCT");
            dr["MANCC"] = cbbNCC.SelectedValue.ToString();
            dr["DIENGIAI"] = txtDienGiai.Text;
            dr["NGAYCT"] = dtpNgay.Value.ToShortDateString();
            dr["SOTIEN"] = float.Parse(txtSoTien.Text);
            dr["MANH"] = cbbMaNH.SelectedValue.ToString();
            ds.Tables["CHITIEN"].Rows.Add(dr);
            da.Update(ds, "CHITIEN");
            btnLuu.Enabled = false;
            txtDienGiai.Clear();
            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ds.Tables.Clear();
            frmPhieuChi_Load(sender, e);
        }
        bool KT_HopLe()
        {
            if (txtDienGiai.Text.Trim() != string.Empty)
                return true;
            return false;
        }
        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = KT_HopLe();
        }

        private void cbbMaNH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbMaNH.SelectedValue != null)
            {
                if (cbbMaNH.SelectedValue.ToString() != null)
                {
                    if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    string str = "select * from CHITIETNHAPHANG where MANH = '" + cbbMaNH.SelectedValue.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(str, Conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    float SoTien = 0;
                    while (rdr.Read())
                    {
                        SoTien += float.Parse(rdr["THANHTIEN"].ToString());
                    }
                    rdr.Close();
                    txtSoTien.Text = SoTien.ToString("#,##0");
                    str = "select NHACUNGCAP.MANCC, NHACUNGCAP.TENNCC from NHACUNGCAP, HANGHOA, CHITIETNHAPHANG, CHITIEN where NHACUNGCAP.MANCC=HANGHOA.MANCC  and CHITIETNHAPHANG.MAHH=HANGHOA.MAHH and CHITIETNHAPHANG.MANH='" + cbbMaNH.SelectedValue.ToString() + "'";
                    cmd = new SqlCommand(str, Conn);
                    SqlDataReader rdr2 = cmd.ExecuteReader();
                    while (rdr2.Read())
                    {
                        cbbNCC.SelectedValue = rdr2["MANCC"].ToString();
                    }
                    rdr2.Close();
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                }
            }
        }
        private void dtgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0}", e.Value);
                }
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInPhieuChi frmChi = new frmInPhieuChi();
            frmChi.ShowDialog();
        }

        private void dtgvList_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgvList.CurrentRow != null)
                maphieu = dtgvList.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtDienGiai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLuu_Click(sender, e);
        }

    }
}
