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
    public partial class frmDanhMucKhachHang : Form
    {
        SqlConnection Conn;
        DataSet DataSet_KhachHang = new DataSet();
        SqlDataAdapter DataAdapter;
        cPublic Public = new cPublic();
        public frmDanhMucKhachHang()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }
        void LamMoi()
        {
            foreach (Control c in tableLayoutPanel.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    ((TextBox)c).Clear();
            }
            txtTenKH.Focus();
        }
        void LoadDuLieu()
        {
            if (dtgvDanhMucKH.Rows.Count != 0)
            {
                txtTenKH.Text = dtgvDanhMucKH.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dtgvDanhMucKH.CurrentRow.Cells[2].Value.ToString();
                txtNoDK.Text = dtgvDanhMucKH.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                LamMoi();
            }
        }
        public void Enable(bool pValue)
        {
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item.GetType() != typeof(Label) && item.GetType() != typeof(DataGridView))
                    item.Enabled = pValue;
            }
        }
        public string TaoMa(string Table, string Column)
        {
            string ma = string.Empty;
            int max = 0;
            foreach (DataRow dr in DataSet_KhachHang.Tables["KHACHHANG"].Rows)
            {
                int x = int.Parse(dr[Column].ToString().Substring(2, 3));
                if (x > max)
                    max = x;
            }
            ma = (++max).ToString("000");
            return ma;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (btnThemMoi.Text == "Thêm mới")
            {
                btnThemMoi.Text = "Lưu";
                Enable(true);
                LamMoi();
                btnCapNhat.Enabled = btnXoa.Enabled = false;
            }
            else
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                try
                {
                    string ma = "KH" + TaoMa("KHACHHANG", "MAKH");
                    DataRow dr = DataSet_KhachHang.Tables["KHACHHANG"].NewRow();
                    dr["MAKH"] = ma;
                    dr["TENKH"] = txtTenKH.Text;
                    dr["NODK"] = float.Parse(txtNoDK.Text);
                    dr["DIACHI"] = txtDiaChi.Text;
                    DataSet_KhachHang.Tables["KHACHHANG"].Rows.Add(dr);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDuLieu();
                    btnLuuLai.Enabled = true;
                    btnThemMoi.Text = "Thêm mới";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Enable(false);
                btnCapNhat.Enabled = btnXoa.Enabled = true;
            }
            Conn.Close();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string str = "select * from KHACHHANG";
            SqlDataAdapter da_KhachHang = new SqlDataAdapter(str, Conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da_KhachHang);
            da_KhachHang.Update(DataSet_KhachHang, "KHACHHANG");
            MessageBox.Show("Đã lưu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuuLai.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Text == "Cập nhật")
            {
                btnCapNhat.Text = "Lưu thay đổi";
                Enable(true);
            }
            else
            {
                if (KT_HopLe())
                {
                    string MaHH = dtgvDanhMucKH.CurrentRow.Cells[0].Value.ToString();

                    DataRow dr = DataSet_KhachHang.Tables["KHACHHANG"].Rows.Find(MaHH);

                    if (dr != null)
                    {
                        dr["TENKH"] = txtTenKH.Text;
                        dr["NODK"] = float.Parse(txtNoDK.Text);
                        dr["DIACHI"] = txtDiaChi.Text;
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuuLai.Enabled = true;
                    btnCapNhat.Text = "Cập nhật";
                    Enable(false);
                }
                else
                {
                    if (txtTenKH.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập tên khách hàng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenKH.Focus();
                    }
                    if (txtNoDK.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập nợ đầu kỳ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNoDK.Focus();
                    }
                    if (txtDiaChi.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập địa chỉ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDiaChi.Focus();
                    }
                }
            }
        }
        bool KT_KhoaNgoai(string pMa)
        {
            string str;
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            str = "select * from DATHANG where MAKH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            str = "select * from THUTIEN where MAKH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            str = "select * from XUATHANG where MAKH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int n = dtgvDanhMucKH.SelectedRows.Count;
            int dem = 0;
            DialogResult r = MessageBox.Show("Bạn muốn xóa " + n + " mục đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.OK)
            {
                for (int i = dtgvDanhMucKH.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtgvDanhMucKH.Rows[i].Selected)
                    {
                        if (!KT_KhoaNgoai(dtgvDanhMucKH.Rows[i].Cells[0].Value.ToString()))
                        {
                            dtgvDanhMucKH.Rows.RemoveAt(i);
                            dem++;
                        }
                    }
                }
                if (dem != 0)
                    btnLuuLai.Enabled = true;
            }
            if (dem == n)
                MessageBox.Show("Xóa thành công " + dem + "/" + n + " mục. \r\n" + (n - dem) + " lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Xóa thành công " + dem + "/" + n + " mục. \r\n" + (n - dem) + " lỗi. \r\nLý do lỗi: Dữ liệu đang sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            DataSet_KhachHang.Tables.Clear();
            frmDanhMucKhachHang_Load(sender, e);
            btnLuuLai.Enabled = false;
            btnThemMoi.Text = "Thêm mới";
            btnCapNhat.Text = "Cập nhật";
        }

        private void frmDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string str = "select * from KHACHHANG";
                DataAdapter = new SqlDataAdapter(str, Conn);
                DataAdapter.Fill(DataSet_KhachHang, "KHACHHANG");
                DataColumn[] key = new DataColumn[1];
                key[0] = DataSet_KhachHang.Tables["KHACHHANG"].Columns[0];
                DataSet_KhachHang.Tables["KHACHHANG"].PrimaryKey = key;
                dtgvDanhMucKH.DataSource = DataSet_KhachHang.Tables["KHACHHANG"];
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                LoadDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Enable(false);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool KT_HopLe()
        {
            if (txtTenKH.Text.Trim().Length != 0 &&
                txtDiaChi.Text.Trim().Length != 0 && txtNoDK.TextLength != 0 )
                return true;
            return false;
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if (btnThemMoi.Text != "Thêm mới")
                btnThemMoi.Enabled = KT_HopLe();
        }

        private void txtNoDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnThemMoi.Text == "Lưu")
                    btnThemMoi_Click(sender, e);
                else
                    btnCapNhat_Click(sender, e);
            }
        }

        private void dtgvDanhMucKH_SelectionChanged(object sender, EventArgs e)
        {
            Enable(false);
            if (dtgvDanhMucKH.SelectedRows.Count > 1)
            {
                LamMoi();
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = false;
                btnThemMoi.Enabled = false;
            }
            else
            {
                btnThemMoi.Text = "Thêm mới";
                btnCapNhat.Text = "Cập nhật";
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemMoi.Enabled = true;
                LoadDuLieu();
            }
        }

        private void frmDanhMucKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnLuuLai.Enabled)
            {
                DialogResult r = MessageBox.Show("Bạn có muốn lưu mọi thay đổi ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);
                if (r == DialogResult.Yes)
                    btnLuuLai_Click(sender, e);
                else if (r == DialogResult.No)
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
        }

        private void dtgvDanhMucKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0}", e.Value);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = "SELECT * from KHACHHANG where MAKH like '%" + txtKey.Text + "%' or TENKH like N'%" + txtKey.Text + "%'";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            DataAdapter.Fill(dt);
            dtgvDanhMucKH.DataSource = dt;
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy khách hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text == string.Empty)
                dtgvDanhMucKH.DataSource = DataSet_KhachHang.Tables["KHACHHANG"];
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem_Click(sender, e);
        }
    }
}
