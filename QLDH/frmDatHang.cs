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
    public partial class frmDatHang : Form
    {
        SqlConnection Conn;
        DataSet DataSet_DatHang = new DataSet();
        SqlDataAdapter DataAdapter;
        cPublic Public = new cPublic();
        public frmDatHang()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void XoaThuaMaDH()
        {
            string str = "select * from DATHANG where MADH not in (select distinct MADH from CHITIETDATHANG)";
            SqlDataAdapter da = new SqlDataAdapter(str, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "DH");
            for (int i = 0; i < ds.Tables["DH"].Rows.Count; i++)
            {
                string key = ds.Tables["DH"].Rows[i][0].ToString();
                DataRow dr = DataSet_DatHang.Tables["DATHANG"].Rows.Find(key);
                dr.Delete();
            }
            str = "select * from DATHANG";
            SqlDataAdapter da_DatHang = new SqlDataAdapter(str, Conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da_DatHang);
            da_DatHang.Update(DataSet_DatHang, "DATHANG");
        }
        
        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string str = "select * from DATHANG";
            SqlDataAdapter da_DatHang = new SqlDataAdapter(str, Conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da_DatHang);
            da_DatHang.Update(DataSet_DatHang, "DATHANG");
            str = "select * from CHITIETDATHANG";
            da_DatHang = new SqlDataAdapter(str, Conn);
            build = new SqlCommandBuilder(da_DatHang);
            da_DatHang.Update(DataSet_DatHang, "CHITIETDATHANG");
            XoaThuaMaDH();
            MessageBox.Show("Đã lưu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuuLai.Enabled = false;

        }
        void InitDataSet()
        {
            string str = "select * from HANGHOA";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "HANGHOA");
            DataColumn[] key = new DataColumn[1];
            key[0] = DataSet_DatHang.Tables["HANGHOA"].Columns[0];
            DataSet_DatHang.Tables["HANGHOA"].PrimaryKey = key;

            str = "select * from TONKHO";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "TONKHO");
            key = new DataColumn[1];
            key[0] = DataSet_DatHang.Tables["TONKHO"].Columns[0];
            DataSet_DatHang.Tables["TONKHO"].PrimaryKey = key;

            str = "select * from KHACHHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "KHACHHANG");
            key = new DataColumn[1];
            key[0] = DataSet_DatHang.Tables["KHACHHANG"].Columns[0];
            DataSet_DatHang.Tables["KHACHHANG"].PrimaryKey = key;

            str = "select * from DATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "DATHANG");
            key = new DataColumn[1];
            key[0] = DataSet_DatHang.Tables["DATHANG"].Columns[0];
            DataSet_DatHang.Tables["DATHANG"].PrimaryKey = key;

            str = "select * from CHITIETDATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "CHITIETDATHANG");
            key = new DataColumn[2];
            key[0] = DataSet_DatHang.Tables["CHITIETDATHANG"].Columns[0];
            key[1] = DataSet_DatHang.Tables["CHITIETDATHANG"].Columns[1];
            DataSet_DatHang.Tables["CHITIETDATHANG"].PrimaryKey = key;

            str = "select d.MADH, h.MAHH, h.TENHH, c.SLDH, d.NGAYDH, n.TENKH, c.TINHTRANG from HANGHOA h, DATHANG d, CHITIETDATHANG c, KHACHHANG n where c.MAHH=h.MAHH and d.MADH=c.MADH and d.MAKH=n.MAKH";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_DatHang, "THONGTIN");
            key = new DataColumn[2];
            key[0] = DataSet_DatHang.Tables["THONGTIN"].Columns[0];
            key[1] = DataSet_DatHang.Tables["THONGTIN"].Columns[1];
            DataSet_DatHang.Tables["THONGTIN"].PrimaryKey = key;
        }
        public void Load_Combobox(string TenBang, ComboBox cbb, string display, string value)
        {
            try
            {
                cbb.DataSource = DataSet_DatHang.Tables[TenBang];
                cbb.DisplayMember = display;
                cbb.ValueMember = value;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất bại! \n\r" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        public void Load_DataGridView()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                dtgvDanhSach.DataSource = DataSet_DatHang.Tables["THONGTIN"];
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmDatHang_Load(object sender, EventArgs e)
        {
            InitDataSet();
            Load_Combobox("HANGHOA", cbbTenHH, "TENHH", "MAHH");
            Load_Combobox("KHACHHANG", cbbKhachHang, "TENKH", "MAKH");
            Load_Combobox("DATHANG", cbbMaDH, "MADH", "MADH");
            Load_DataGridView();
            Enable(false);
            LoadDuLieu();
        }
        void LamMoi()
        {
            txtSoLuong.Clear();
            cbbKhachHang.SelectedIndex = cbbTenHH.SelectedIndex = -1;
            dtpkNgay.Value = DateTime.Now;
            cbbMaDH.SelectedIndex = -1;
            cbbMaDH.Focus();
        }
        void LoadDuLieu()
        {

            if (dtgvDanhSach.Rows.Count != 0)
            {
                cbbMaDH.Text = dtgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                cbbTenHH.Text = dtgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                cbbKhachHang.Text = dtgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                txtSoLuong.Text = dtgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                dtpkNgay.Value = DateTime.Parse(dtgvDanhSach.CurrentRow.Cells[4].Value.ToString());
                txtSLTon.Text = dtgvDanhSach.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                LamMoi();
            }
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

        public bool KT_TrungKhoaChinh(string Ma1, string Ma2)
        {
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            string[] key = new string[2];
            key[0] = Ma1;
            key[1] = Ma2;
            DataRow dr = DataSet_DatHang.Tables["CHITIETDATHANG"].Rows.Find(key);
            if (dr != null)
                return true;
            return false;
        }
        void Enable(bool gt)
        {
            foreach (Control item in tableLayoutPanel2.Controls)
            {
                if (item.GetType() != typeof(Label))
                    item.Enabled = gt;
            }
            cbbMaDH.Enabled = gt;
            txtSLTon.Enabled = false;
        }
        public bool KT_TrungKhoaChinh(string pTable, string pColumn, string pKey)
        {
            for (int i = 0; i < DataSet_DatHang.Tables[pTable].Rows.Count; i++)
            {
                if (DataSet_DatHang.Tables[pTable].Rows[i][pColumn].ToString() == pKey)
                    return true;
            }
            return false;
        }
        public string TaoMa()
        {
            string ma = string.Empty;
            int max = 0;
            foreach (DataRow dr in DataSet_DatHang.Tables["DATHANG"].Rows)
            {
                int x = int.Parse(dr["MADH"].ToString().Substring(2, 3));
                if (x > max)
                    max = x;
            }
            ma = "DH" + (++max).ToString("000");
            return ma;
        }
        public bool KT_Ma(string ma)
        {
            try
            {
                string s = ma.Substring(0, 2);
                int x = int.Parse(ma.Substring(2, 3));
                if (s != "DH")
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (btnThemMoi.Text == "Thêm mới")
            {
                btnThemMoi.Text = "Lưu";
                Enable(true);
                LamMoi();
            }
            else
            {
                if (cbbTenHH.SelectedValue == null)
                {
                    MessageBox.Show("Không tồn tại hàng hóa có tên: " + cbbTenHH.Text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbTenHH.Focus();
                    cbbTenHH.SelectAll();
                    return;
                }
                if (cbbKhachHang.SelectedValue == null)
                {
                    MessageBox.Show("Không tồn tại khách hành có tên: " + cbbKhachHang.Text, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbbKhachHang.Focus();
                    cbbKhachHang.SelectAll();
                    return;
                }
                if (txtSoLuong.Text == string.Empty || txtSoLuong.Text == "0")
                {
                    MessageBox.Show("Số lượng không họp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                    txtSoLuong.SelectAll();
                    return;
                }
                
                else
                {
                    try
                    {
                        string ma = cbbMaDH.Text.Trim().ToUpper();
                        if (Conn.State == ConnectionState.Closed)
                            Conn.Open();
                        if (ma == string.Empty)
                        {
                            MessageBox.Show("Không thể bỏ trống mã đặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cbbMaDH.Focus();
                            cbbMaDH.SelectAll();
                            return;
                        }
                        if (!KT_Ma(ma))
                        {
                            DialogResult r = MessageBox.Show("Mã đặt hàng không đúng định dạng. Sử dụng mã mặc định?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            if (r == DialogResult.No)
                            {
                                cbbMaDH.Focus();
                                cbbMaDH.SelectAll();
                                return;
                            }
                            else
                                ma = TaoMa();
                        }
                        if (KT_TrungKhoaChinh(ma, cbbTenHH.SelectedValue.ToString()))
                        {
                            MessageBox.Show(string.Format("\"{0}\" đã có trong đơn đặt hàng mã \"{1}\"", cbbTenHH.Text, cbbMaDH.Text), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        DataRow dr = DataSet_DatHang.Tables["DATHANG"].NewRow();

                        if (!KT_TrungKhoaChinh("DATHANG", "MADH", ma))
                        {
                            dr["MADH"] = ma;
                            dr["NGAYDH"] = dtpkNgay.Value.ToShortDateString();
                            dr["MAKH"] = cbbKhachHang.SelectedValue.ToString();
                            DataSet_DatHang.Tables["DATHANG"].Rows.Add(dr);
                        }
                        else
                        {
                            DataRow r = DataSet_DatHang.Tables["DATHANG"].Rows.Find(ma);
                            r["NgayDH"] = dtpkNgay.Value;
                        }

                        Conn.Close();
                        DataRow dr_t = DataSet_DatHang.Tables["TONKHO"].Rows.Find(cbbTenHH.SelectedValue.ToString());
                        DataRow dr2 = DataSet_DatHang.Tables["CHITIETDATHANG"].NewRow();
                        dr2["MADH"] = ma;
                        dr2["MAHH"] = cbbTenHH.SelectedValue.ToString();
                        dr2["SLDH"] = int.Parse(txtSoLuong.Text);
                        int SL_DatHang = int.Parse(txtSoLuong.Text);
                        int SL_Ton = int.Parse(dr_t["TONCUOI"].ToString());
                        if (SL_DatHang > SL_Ton)
                        {
                            dr2["TINHTRANG"] = "Thiếu";
                        }
                        else
                        {
                            dr2["TINHTRANG"] = "Đủ";
                        }
                        DataSet_DatHang.Tables["CHITIETDATHANG"].Rows.Add(dr2);
                        DataRow dr3 = DataSet_DatHang.Tables["THONGTIN"].NewRow();
                        dr3["MADH"] = ma;
                        dr3["MAHH"] = cbbTenHH.SelectedValue.ToString();
                        dr3["TENHH"] = cbbTenHH.Text;
                        dr3["SLDH"] = SL_DatHang;
                        dr3["NGAYDH"] = dtpkNgay.Value.ToShortDateString();
                        dr3["TENKH"] = cbbKhachHang.Text;
                        if (SL_DatHang > SL_Ton)
                            dr3["TINHTRANG"] = "Thiếu";
                        else
                            dr3["TINHTRANG"] = "Đủ";
                        DataSet_DatHang.Tables["THONGTIN"].Rows.Add(dr3);
                        dtgvDanhSach.Refresh();
                        LoadDuLieu();
                        btnLuuLai.Enabled = true;
                        btnThemMoi.Text = "Thêm mới";
                        Enable(false);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void dtgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvDanhSach.SelectedRows.Count > 1)
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
                btnCapNhat.Text = "Chỉnh sửa";
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnThemMoi.Enabled = true;
                LoadDuLieu();
            }
        }

        private void frmDanhSach_FormClosing(object sender, FormClosingEventArgs e)
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
        bool KT_KhoaNgoai(string pMa)
        {
            string str;
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            str = "select * from CHITIETDATHANG where MADH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            str = "select * from XUATHANG where MADH = '" + pMa + "'";
            da = new SqlDataAdapter(str, Conn);
            dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int n = dtgvDanhSach.SelectedRows.Count;
            int dem = 0;
            DialogResult r = MessageBox.Show("Bạn muốn xóa " + n + " mục đã chọn?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.OK)
            {
                foreach (DataGridViewRow item in dtgvDanhSach.SelectedRows)
                {
                    if (!KT_KhoaNgoai(item.Cells[0].Value.ToString()))
                    {
                        string[] key = { item.Cells[0].Value.ToString(), item.Cells[1].Value.ToString() };
                        DataRow dt2 = DataSet_DatHang.Tables["CHITIETDATHANG"].Rows.Find(key);
                        DataRow dt3 = DataSet_DatHang.Tables["THONGTIN"].Rows.Find(key);
                        dt2.Delete();
                        dt3.Delete();
                        dem++;
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

        private void cbbTenHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenHH.SelectedIndex == -1)
            {
                txtSLTon.Text = string.Empty;
            }
            else
            {
                try
                {

                    DataRow dr = DataSet_DatHang.Tables["TONKHO"].Rows.Find(cbbTenHH.SelectedValue.ToString());
                    if (dr != null)
                    {
                        txtSLTon.Text = "/" + dr["TONCUOI"].ToString();
                    }
                    else
                    {
                        txtSLTon.Text = "?";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thất bại! \n\r" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (btnCapNhat.Text == "Chỉnh sửa")
            {
                btnCapNhat.Text = "Lưu thay đổi";
                Enable(true);
                cbbMaDH.Enabled = false;
                cbbTenHH.Enabled = false;
                cbbTenHH_SelectedIndexChanged(sender, e);
            }
            else
            {
                try
                {
                    string[] key = { dtgvDanhSach.CurrentRow.Cells[0].Value.ToString(), dtgvDanhSach.CurrentRow.Cells[1].Value.ToString() };

                    DataRow dr1 = DataSet_DatHang.Tables["DATHANG"].Rows.Find(key[0]);
                    DataRow dr2 = DataSet_DatHang.Tables["CHITIETDATHANG"].Rows.Find(key);
                    DataRow dr3 = DataSet_DatHang.Tables["THONGTIN"].Rows.Find(key);
                    if (dr1 != null)
                    {
                        DataRow dr_t = DataSet_DatHang.Tables["TONKHO"].Rows.Find(cbbTenHH.SelectedValue.ToString());
                        dr1["NGAYDH"] = dtpkNgay.Value.ToShortDateString();
                        dr1["MAKH"] = cbbKhachHang.SelectedValue.ToString();
                        int SL_DatHang = int.Parse(txtSoLuong.Text);
                        int SL_Ton = int.Parse(dr_t["TONCUOI"].ToString());
                        dr2["SLDH"] = SL_DatHang;
                        if (SL_DatHang > SL_Ton)
                        {
                            dr2["TINHTRANG"] = "Thiếu";
                        }
                        else
                        {
                            dr2["TINHTRANG"] = "Đủ";
                        }
                        dr3["SLDH"] = SL_DatHang;
                        dr3["NGAYDH"] = dtpkNgay.Value.ToShortDateString();
                        dr3["TENKH"] = cbbKhachHang.Text;
                        if (SL_DatHang > SL_Ton)
                            dr3["TINHTRANG"] = "Thiếu";
                        else
                            dr3["TINHTRANG"] = "Đủ";
                    }
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnLuuLai.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Không thành công!");
                }
                btnCapNhat.Text = "Chỉnh sửa";
                Enable(false);
            }

        }

        private void btnTaiLai_Click(object sender, EventArgs e)
        {

            DataSet_DatHang.Clear();
            frmDatHang_Load(sender, e);
            btnThemMoi.Text = "Thêm mới";
            btnLuuLai.Enabled = false;
            Enable(false);
        }

        private void cbbMaDH_TextChanged(object sender, EventArgs e)
        {
            string MADH = cbbMaDH.Text.ToUpper();
            DataRow dr = DataSet_DatHang.Tables["DATHANG"].Rows.Find(MADH);
            if (dr != null)
            {
                cbbKhachHang.Enabled = false;
                cbbKhachHang.SelectedValue = dr["MAKH"];
            }
            else
            {
                cbbKhachHang.Enabled = true;
                cbbKhachHang.SelectedIndex = -1;
            }
        }

        private void cbbTenHH_KeyDown(object sender, KeyEventArgs e)
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
