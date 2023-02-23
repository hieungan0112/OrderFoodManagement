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
    public partial class frmDanhMucNhaCungCap : Form
    {
        SqlConnection Conn;
        DataSet DataSet_NCC = new DataSet();
        SqlDataAdapter DataAdapter;
        cPublic Public = new cPublic();
        public frmDanhMucNhaCungCap()
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
            txtTenNCC.Focus();
        }
        void LoadDuLieu()
        {
            if (dtgvDanhMucNCC.Rows.Count != 0)
            {
                txtTenNCC.Text = dtgvDanhMucNCC.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dtgvDanhMucNCC.CurrentRow.Cells[2].Value.ToString();
                txtNoDK.Text = dtgvDanhMucNCC.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                LamMoi();
            }
        }
        public string TaoMa(string Table, string Column)
        {
            string ma = string.Empty;
            int max = 0;
            foreach (DataRow dr in DataSet_NCC.Tables["NHACUNGCAP"].Rows)
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
                    DataRow dr = DataSet_NCC.Tables["NHACUNGCAP"].NewRow();
                    dr["MANCC"] = "NC" + TaoMa("NHACUNGCAP", "MANCC");
                    dr["TENNCC"] = txtTenNCC.Text;
                    dr["NODK"] = float.Parse(txtNoDK.Text);
                    dr["DIACHI"] = txtDiaChi.Text;
                    DataSet_NCC.Tables["NHACUNGCAP"].Rows.Add(dr);
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
            string str = "select * from NHACUNGCAP";
            SqlDataAdapter da_KhachHang = new SqlDataAdapter(str, Conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da_KhachHang);
            da_KhachHang.Update(DataSet_NCC, "NHACUNGCAP");
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
                    string MaHH = dtgvDanhMucNCC.CurrentRow.Cells[0].Value.ToString();

                    DataRow dr = DataSet_NCC.Tables["NHACUNGCAP"].Rows.Find(MaHH);

                    if (dr != null)
                    {
                        dr["TENNCC"] = txtTenNCC.Text;
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
                    if (txtTenNCC.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenNCC.Focus();
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
            str = "select * from HANGHOA where MANCC = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            str = "select * from CHITIEN where MANCC = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int n = dtgvDanhMucNCC.SelectedRows.Count;
            int dem = 0;
            DialogResult r = MessageBox.Show("Bạn muốn xóa " + n + " mục đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.OK)
            {
                for (int i = dtgvDanhMucNCC.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtgvDanhMucNCC.Rows[i].Selected)
                    {
                        if (!KT_KhoaNgoai(dtgvDanhMucNCC.Rows[i].Cells[0].Value.ToString()))
                        {
                            dtgvDanhMucNCC.Rows.RemoveAt(i);
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
            DataSet_NCC.Tables.Clear();
            frmDanhMucNhaCungCap_Load(sender, e);
            btnLuuLai.Enabled = false;
            btnThemMoi.Text = "Thêm mới";
            btnCapNhat.Text = "Cập nhật";
        }
        public void Enable(bool pValue)
        {
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item.GetType() != typeof(Label) && item.GetType() != typeof(DataGridView))
                    item.Enabled = pValue;
            }
        }
        private void frmDanhMucNhaCungCap_Load(object sender, EventArgs e)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string str = "select * from NHACUNGCAP";
                DataAdapter = new SqlDataAdapter(str, Conn);
                DataAdapter.Fill(DataSet_NCC, "NHACUNGCAP");
                DataColumn[] key = new DataColumn[1];
                key[0] = DataSet_NCC.Tables["NHACUNGCAP"].Columns[0];
                DataSet_NCC.Tables["NHACUNGCAP"].PrimaryKey = key;
                dtgvDanhMucNCC.DataSource = DataSet_NCC.Tables["NHACUNGCAP"];
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
            if (txtTenNCC.Text.Trim().Length != 0 &&
                txtDiaChi.Text.Trim().Length != 0 && txtNoDK.TextLength != 0)
                return true;
            return false;
        }

        private void txtMaNCC_TextChanged(object sender, EventArgs e)
        {
            if (btnThemMoi.Text != "Thêm mới")
                btnThemMoi.Enabled = KT_HopLe();
        }

        private void txtNoDK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtMaNCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnThemMoi.Text == "Lưu")
                    btnThemMoi_Click(sender, e);
                else
                    btnCapNhat_Click(sender, e);
            }
        }

        private void dtgvDanhMucNCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDanhMucNCC.SelectedRows.Count > 1)
            {
                LamMoi();
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = false;
                btnThemMoi.Enabled = false;
            }
            else
            {
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemMoi.Enabled = true;
                LoadDuLieu();
            }
        }

        private void dtgvDanhMucNCC_SelectionChanged_1(object sender, EventArgs e)
        {
            Enable(false);
            if (dtgvDanhMucNCC.SelectedRows.Count > 1)
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

        private void frmDanhMucNhaCungCap_FormClosing(object sender, FormClosingEventArgs e)
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

        private void dtgvDanhMucNCC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            string str = "SELECT * from NHACUNGCAP where MANCC like '%" + txtKey.Text + "%' or TENNCC like N'%" + txtKey.Text + "%'";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            DataAdapter.Fill(dt);
            dtgvDanhMucNCC.DataSource = dt;
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy nhà cung cấp nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text == string.Empty)
                dtgvDanhMucNCC.DataSource = DataSet_NCC.Tables["NHACUNGCAP"];
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem_Click(sender, e);
        }
    }
}
