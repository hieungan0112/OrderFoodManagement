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
    public partial class frmDanhMucHangHoa : Form
    {
        SqlConnection Conn;
        DataSet ds_HangHoa = new DataSet();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        cPublic Public = new cPublic();
        public frmDanhMucHangHoa()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Load_Combobox()
        {
            string str = "select * from NHACUNGCAP";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(ds_HangHoa, "NHACUNGCAP");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HangHoa.Tables["NHACUNGCAP"].Columns[0];
            ds_HangHoa.Tables["NHACUNGCAP"].PrimaryKey = key;
            cbbNhaCC.DataSource = ds_HangHoa.Tables["NHACUNGCAP"];
            cbbNhaCC.DisplayMember = "TENNCC";
            cbbNhaCC.ValueMember = "MANCC";
        }
        public void Enable(bool pValue)
        {
            foreach (Control item in tableLayoutPanel.Controls)
            {
                if (item.GetType() != typeof(Label) && item.GetType() != typeof(DataGridView))
                    item.Enabled = pValue;
            }
        }
        void InitDataSet()
        {
            string str = "select * from HANGHOA";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(ds_HangHoa, "HANGHOA");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds_HangHoa.Tables["HANGHOA"].Columns[0];
            ds_HangHoa.Tables["HANGHOA"].PrimaryKey = key;

            str = "select * from TONKHO";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(ds_HangHoa, "TONKHO");
            key = new DataColumn[1];
            key[0] = ds_HangHoa.Tables["TONKHO"].Columns[0];
            ds_HangHoa.Tables["TONKHO"].PrimaryKey = key;

            str = "SELECT HANGHOA.MAHH, TENHH, DVT, GIAGOC, TONCUOI, TENNCC FROM HANGHOA, TONKHO, NHACUNGCAP where HANGHOA.MAHH = TONKHO.MAHH and HANGHOA.MANCC=NHACUNGCAP.MANCC";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(ds_HangHoa, "THONGTIN");
            key = new DataColumn[1];
            key[0] = ds_HangHoa.Tables["THONGTIN"].Columns[0];
            ds_HangHoa.Tables["THONGTIN"].PrimaryKey = key;
        }


        public void Load_DataGridView()
        {
            try
            {
                dtgvDanhMucHH.DataSource = ds_HangHoa.Tables["THONGTIN"];
                LoadDuLieu();
                cbbNhaCC.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmDanhMucHangHoa_Load(object sender, EventArgs e)
        {

            InitDataSet();
            Load_Combobox();
            Load_DataGridView();
            Enable(false);
        }
        void LamMoi()
        {
            foreach (Control c in tableLayoutPanel.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                    ((TextBox)c).Clear();
            }
            cbbNhaCC.SelectedIndex = 0;
            txtTenHH.Focus();
        }
        public string TraMa(string Table, string Column, string Name, string Value)
        {
            string ma = string.Empty;
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string selectString = "select * from " + Table + " where " + Name + " = N'" + Value + "'";
                SqlCommand cmd = new SqlCommand(selectString, Conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ma = rdr[Column].ToString();
                }
                rdr.Close();
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                return ma;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại! \n\r" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                return string.Empty;
            }

        }
        public string TaoMa(string Table, string Column)
        {
            string ma = string.Empty;
            int max = 0;
            foreach (DataRow dr in ds_HangHoa.Tables["HANGHOA"].Rows)
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
                btnXoa.Enabled = btnCapNhat.Enabled = false;
            }
            else
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                if (txtTenHH.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập tên hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenHH.Focus();
                    txtTenHH.SelectAll();
                    return;
                }
                if (txtGiaGoc.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng nhập giá bán", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaGoc.Focus();
                    txtGiaGoc.SelectAll();
                    return;
                }
                else
                {
                    try
                    {
                        string ma = "HH" + TaoMa("HANGHOA", "MAHH");
                        DataRow dr = ds_HangHoa.Tables["HANGHOA"].NewRow();
                        dr["MAHH"] = ma;
                        dr["TENHH"] = txtTenHH.Text;
                        dr["DVT"] = cbbDVT.Text;
                        dr["GIAGOC"] = float.Parse(txtGiaGoc.Text);
                        dr["MANCC"] = cbbNhaCC.SelectedValue.ToString();
                        ds_HangHoa.Tables["HANGHOA"].Rows.Add(dr);
                        
                        DataRow dr2 = ds_HangHoa.Tables["TONKHO"].NewRow();
                        dr2["MAHH"] = ma;
                        dr2["TONDAU"] = 0;
                        dr2["NHAP"] = 0;
                        dr2["XUAT"] = 0;
                        dr2["TONCUOI"] = 0;
                        dr2["TGTTON"] = 0;
                        ds_HangHoa.Tables["TONKHO"].Rows.Add(dr2);

                        DataRow dr3 = ds_HangHoa.Tables["THONGTIN"].NewRow();
                        dr3["MAHH"] = ma;
                        dr3["TENHH"] = txtTenHH.Text;
                        dr3["DVT"] = cbbDVT.Text;
                        dr3["GIAGOC"] = float.Parse(txtGiaGoc.Text);
                        dr3["TONCUOI"] = 0;
                        dr3["TENNCC"] = cbbNhaCC.Text;
                        ds_HangHoa.Tables["THONGTIN"].Rows.Add(dr3);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDuLieu();
                        btnLuuLai.Enabled = true;
                        btnThemMoi.Text = "Thêm mới";
                        btnXoa.Enabled = btnCapNhat.Enabled = true;
                        Enable(false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                Conn.Close();
            }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "select * from HANGHOA";
                SqlDataAdapter da_HangHoa = new SqlDataAdapter(str, Conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da_HangHoa);
                da_HangHoa.Update(ds_HangHoa, "HANGHOA");

                str = "select * from TONKHO";
                da_HangHoa = new SqlDataAdapter(str, Conn);
                cmd = new SqlCommandBuilder(da_HangHoa);
                da_HangHoa.Update(ds_HangHoa, "TONKHO");
            }
            catch
            {

                string str = "select * from TONKHO";
                SqlDataAdapter da_HangHoa = new SqlDataAdapter(str, Conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da_HangHoa);
                da_HangHoa.Update(ds_HangHoa, "TONKHO");

                str = "select * from HANGHOA";
                da_HangHoa = new SqlDataAdapter(str, Conn);
                cmd = new SqlCommandBuilder(da_HangHoa);
                da_HangHoa.Update(ds_HangHoa, "HANGHOA");
            }
            MessageBox.Show("Đã lưu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuuLai.Enabled = false;
        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {
            ds_HangHoa.Tables.Clear();
            frmDanhMucHangHoa_Load(sender, e);
            Enable(false);
            btnLuuLai.Enabled = false;
            btnThemMoi.Text = "Thêm mới";
            btnCapNhat.Text = "Cập nhật giá";
        }

        private void txtSoLuongTon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        bool KT_HopLe()
        {
            if (txtTenHH.Text.Trim().Length != 0 &&
                cbbDVT.Text.Trim().Length != 0 && txtGiaGoc.TextLength != 0)
                return true;
            return false;
        }
        private void txtMAHH_TextChanged(object sender, EventArgs e)
        {
            if(btnThemMoi.Text!="Thêm mới")
                btnThemMoi.Enabled = KT_HopLe();
        }

        private void txtMAHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnThemMoi_Click(sender, e);
        }
        void LoadDuLieu()
        {
            if (dtgvDanhMucHH.Rows.Count != 0)
            {
                txtTenHH.Text = dtgvDanhMucHH.CurrentRow.Cells[1].Value.ToString();
                cbbDVT.Text = dtgvDanhMucHH.CurrentRow.Cells[2].Value.ToString();
                txtGiaGoc.Text = dtgvDanhMucHH.CurrentRow.Cells[3].Value.ToString();
                cbbNhaCC.Text = dtgvDanhMucHH.CurrentRow.Cells[5].Value.ToString();
            }
            else
            {
                LamMoi();
            }
        }
        private void dtgvDanhMucHH_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDanhMucHH.SelectedRows.Count > 1)
            {
                LamMoi();
                btnXoa.Enabled = true;
                btnCapNhat.Enabled = false;
                btnThemMoi.Enabled = false;
            }
            else
            {
                Enable(false);
                btnThemMoi.Text = "Thêm mới";
                btnCapNhat.Text = "Cập nhật giá";
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemMoi.Enabled = true;
                LoadDuLieu();
            }
        }
        bool KT_KhoaNgoai(string pMa)
        {
            string str;
            SqlDataAdapter da;
            DataTable dt=new DataTable();
            str = "select * from CHITIETDATHANG where MAHH = '"+pMa+"'";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
                return true;
            str = "select * from CHITIETNHAPHANG where MAHH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            str = "select * from CHITIETXUATHANG where MAHH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int n = dtgvDanhMucHH.SelectedRows.Count;
            int dem = 0;
            DialogResult r = MessageBox.Show("Bạn muốn xóa " + n + " mục đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.OK)
            {
                foreach (DataGridViewRow item in dtgvDanhMucHH.SelectedRows)
                {
                    if (!KT_KhoaNgoai(item.Cells[0].Value.ToString()))
                    {
                        DataRow dr = ds_HangHoa.Tables["HANGHOA"].Rows.Find(item.Cells[0].Value.ToString());
                        dr.Delete();
                        dr = ds_HangHoa.Tables["TONKHO"].Rows.Find(item.Cells[0].Value.ToString());
                        dr.Delete();
                        dr = ds_HangHoa.Tables["THONGTIN"].Rows.Find(item.Cells[0].Value.ToString());
                        dr.Delete();
                        dem++;
                    }
                }
                if(dem != 0)
                    btnLuuLai.Enabled = true;
            }
            if (dem == n)
                MessageBox.Show("Xóa thành công " + dem + "/" + n + " mục. \r\n" + (n - dem) + " lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Xóa thành công " + dem + "/" + n + " mục. \r\n" + (n - dem) + " lỗi. \r\nLý do lỗi: Dữ liệu đang sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Text == "Cập nhật giá")
            {
                btnCapNhat.Text = "Lưu giá mới";
                txtGiaGoc.Enabled = true;
                txtGiaGoc.Focus();
                txtGiaGoc.SelectAll();
            }
            else
            {
                try
                {
                    string MaHH = dtgvDanhMucHH.CurrentRow.Cells[0].Value.ToString();

                    DataRow dr1 = ds_HangHoa.Tables["HANGHOA"].Rows.Find(MaHH);
                    DataRow dr2 = ds_HangHoa.Tables["TONKHO"].Rows.Find(MaHH);
                    DataRow dr3 = ds_HangHoa.Tables["THONGTIN"].Rows.Find(MaHH);

                    if (dr1 != null)
                    {
                        dr1["GIAGOC"] = float.Parse(txtGiaGoc.Text);
                        dr2["TGTTON"] = float.Parse(txtGiaGoc.Text)*int.Parse(dr2["TONCUOI"].ToString());
                        dr3["GIAGOC"] = float.Parse(txtGiaGoc.Text);
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuuLai.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Không thành công!");
                }
                btnCapNhat.Text = "Cập nhật giá";
                txtGiaGoc.Enabled = false;
            }
        }

        private void frmDanhMucHangHoa_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtTenHH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsLetterOrDigit(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }

        private void dtgvDanhMucHH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
            string str = "SELECT HANGHOA.MAHH, TENHH, DVT, GIAGOC, TONCUOI, TENNCC FROM HANGHOA, TONKHO, NHACUNGCAP where HANGHOA.MAHH = TONKHO.MAHH and HANGHOA.MANCC=NHACUNGCAP.MANCC and (HANGHOA.MAHH like '%" + txtKey.Text + "%' or TENHH like N'%" + txtKey.Text + "%')";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            DataAdapter.Fill(dt);
            dtgvDanhMucHH.DataSource = dt;
            if (dt.Rows.Count == 0)
                MessageBox.Show("Không tìm thấy hàng hóa nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (txtKey.Text == string.Empty)
                dtgvDanhMucHH.DataSource = ds_HangHoa.Tables["THONGTIN"];
        }

        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnTimKiem_Click(sender, e);
        }

        private void txtGiaBan_KeyDown(object sender, KeyEventArgs e)
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
