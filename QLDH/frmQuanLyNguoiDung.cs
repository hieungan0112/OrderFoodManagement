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
    public partial class frmQuanLyNguoiDung : Form
    {
        SqlConnection Conn;
        DataSet DataSet_NguoiDung = new DataSet();
        SqlDataAdapter DataAdapter;
        cPublic Public = new cPublic();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Load_Data()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string str = "select * from NGUOIDUNG where QUYENTC != 'Admin' and QUYENTC != N'Quản trị hệ thống'";
                DataAdapter = new SqlDataAdapter(str, Conn);
                DataAdapter.Fill(DataSet_NguoiDung, "NGUOIDUNG");
                DataColumn[] key = new DataColumn[1];
                key[0] = DataSet_NguoiDung.Tables["NGUOIDUNG"].Columns[0];
                DataSet_NguoiDung.Tables["NGUOIDUNG"].PrimaryKey = key;
                dtgvList.DataSource = DataSet_NguoiDung.Tables["NGUOIDUNG"];
                DataGridViewRow item = dtgvList.SelectedRows[0];
                DataRow dt = DataSet_NguoiDung.Tables["NGUOIDUNG"].Rows.Find(item.Cells[0].Value.ToString());
                cbbNhomTruyCap.SelectedItem=dt["QUYENTC"].ToString();
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                LoadDuLieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void dtgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value != null)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }
            
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            Load_Data();
            Enable(false);
        }
        void LamMoi()
        {
            foreach (Control c in tableLayoutPanel.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    ((TextBox)c).Clear();
            }
            txtTen.Focus();
            ptbMat.Visible = true;
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            
                if (btnThemMoi.Text == "Thêm mới")
                {
                    Enable(true);
                    btnThemMoi.Text = "Lưu";
                    LamMoi();
                    btnCapNhat.Enabled = btnXoa.Enabled = false;
                    txtTen.Focus();
                }
                else
                {
                    if (txtTen.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập tên người dùng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTen.Focus();
                        return;
                    }
                    if (txtMatKhau.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                        return;
                    }
                    if (txtMatKhau.Text.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu quá ngắn !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                        return;
                    }
                    if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    if (Public.KT_TrungKhoaChinh("NGUOIDUNG", "TENND", txtTen.Text))
                    {
                        MessageBox.Show("Tên người dùng tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTen.Focus();
                        txtTen.SelectAll();
                        return;
                    }
                    else
                    {
                        try
                        {
                            DataRow dr = DataSet_NguoiDung.Tables["NGUOIDUNG"].NewRow();
                            dr["TENND"] = txtTen.Text;
                            dr["MK"] = txtMatKhau.Text;
                            dr["QUYENTC"] = cbbNhomTruyCap.Text;
                            DataSet_NguoiDung.Tables["NGUOIDUNG"].Rows.Add(dr);
                            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDuLieu();
                            btnLuuLai.Enabled = true;
                            btnThemMoi.Text = "Thêm mới";
                            btnCapNhat.Enabled = btnXoa.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Enable(false);
                        ptbMat.Visible = false;
                    }
                }
            
            Conn.Close();
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string str = "select * from NGUOIDUNG";
            SqlDataAdapter da_HangHoa = new SqlDataAdapter(str, Conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da_HangHoa);
            da_HangHoa.Update(DataSet_NguoiDung, "NGUOIDUNG");
            MessageBox.Show("Đã lưu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuuLai.Enabled = false;
        }
        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            DataSet_NguoiDung.Tables.Clear();
            Load_Data();
            Enable(false);
            btnLuuLai.Enabled = false;
            btnThemMoi.Text = "Thêm mới";
            ptbMat.Visible = false;
        }
        void LoadDuLieu()
        {
            if (dtgvList.Rows.Count != 0)
            {
                txtTen.Text = dtgvList.CurrentRow.Cells[0].Value.ToString();
                txtMatKhau.Text = dtgvList.CurrentRow.Cells[1].Value.ToString();
                txtMatKhau.UseSystemPasswordChar = true;
                cbbNhomTruyCap.Text = dtgvList.CurrentRow.Cells[2].Value.ToString();
            }
            else
            {
                LamMoi();
            }
        }
        private void dtgvList_SelectionChanged(object sender, EventArgs e)
        {
            ptbMat.Visible = false;
            if (dtgvList.SelectedRows.Count > 1)
            {
                LamMoi();
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = false;
                btnThemMoi.Enabled = false;
                ptbMat.Visible = false;
            }
            else
            {
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemMoi.Enabled = true;
                Enable(false);
                LoadDuLieu();
                btnCapNhat.Text = "Cập nhật";
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int n = dtgvList.SelectedRows.Count;
            DialogResult r = MessageBox.Show("Bạn muốn xóa " + n + " mục đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.OK)
            {
                for (int i = dtgvList.Rows.Count - 1; i >= 0; i--)
                {
                    if (dtgvList.Rows[i].Selected)
                    {
                        dtgvList.Rows.RemoveAt(i);
                    }
                }
                btnLuuLai.Enabled = true;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Text == "Cập nhật")
            {
                btnCapNhat.Text = "Lưu thay đổi";
                Enable(true);
                txtTen.Enabled = false;
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
                ptbMat.Visible = true;
            }
            else
            {
                try
                {
                    if (txtMatKhau.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                        return;
                    }
                    if (txtMatKhau.Text.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu quá ngắn !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Focus();
                        return;
                    }
                    if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    string Ten = dtgvList.CurrentRow.Cells[0].Value.ToString();

                    DataRow dr = DataSet_NguoiDung.Tables["NGUOIDUNG"].Rows.Find(Ten);

                    if (dr != null)
                    {
                        dr["MK"] = txtMatKhau.Text;
                        dr["QUYENTC"] = cbbNhomTruyCap.Text;
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuuLai.Enabled = true;
                    txtMatKhau.Enabled = false;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Không thành công! \n\r"+ex.Message);
                }
                btnCapNhat.Text = "Cập nhật";
                Enable(false);
                LoadDuLieu();
                if(Conn.State==ConnectionState.Open)
                    Conn.Close();
            }
        }

        private void frmQuanLyNguoiDung_FormClosing(object sender, FormClosingEventArgs e)
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
        private void ptbMat_MouseDown(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = false;
        }

        private void ptbMat_MouseUp(object sender, MouseEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim().Length == 0)
                txtMatKhau.Text = string.Empty;
            else
                txtMatKhau.Text  = txtTen.Text + "123";
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = "SELECT * from NGUOIDUNG where TENND like '%" + txtKey.Text + "%' or QUYENTC like N'%" + txtKey.Text + "%'";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            DataAdapter.Fill(dt);
            dtgvList.DataSource = dt;
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy người dùng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text == string.Empty)
                dtgvList.DataSource = DataSet_NguoiDung.Tables["NGUOIDUNG"];
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnThemMoi.Text == "Lưu")
                    btnThemMoi_Click(sender, e);
                else
                    btnCapNhat_Click(sender, e);
            }
        }
    }
}
