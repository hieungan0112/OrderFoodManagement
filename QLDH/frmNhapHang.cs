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
    public partial class frmNhapHang : Form
    {
        SqlConnection Conn;
        DataSet DataSet_NhapHang = new DataSet();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        cPublic Public = new cPublic();
        public frmNhapHang()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }
        public void Load_Combobox_HangHoa()
        {
            try
            {
                string str = "select * from HANGHOA";
                SqlDataAdapter da = new SqlDataAdapter(str, Conn);
                da.Fill(DataSet_NhapHang, "HANGHOA");
                cbbHangHoa.DataSource = DataSet_NhapHang.Tables["HANGHOA"];
                cbbHangHoa.DisplayMember = DataSet_NhapHang.Tables["HANGHOA"].Columns[1].ToString();
                cbbHangHoa.ValueMember = DataSet_NhapHang.Tables["HANGHOA"].Columns[0].ToString();
                DataColumn[] key = new DataColumn[1];
                key[0] = DataSet_NhapHang.Tables["HANGHOA"].Columns[0];
                DataSet_NhapHang.Tables["HANGHOA"].PrimaryKey = key;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Thất bại! \n\r" + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        void InitDataSet()
        {
            string str = "select * from TONKHO";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "TONKHO");
            DataColumn[] key = new DataColumn[1];
            key[0] = DataSet_NhapHang.Tables["TONKHO"].Columns[0];
            DataSet_NhapHang.Tables["TONKHO"].PrimaryKey = key;

            str = "select * from NHAPHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "NHAPHANG");
            key = new DataColumn[1];
            key[0] = DataSet_NhapHang.Tables["NHAPHANG"].Columns[0];
            DataSet_NhapHang.Tables["NHAPHANG"].PrimaryKey = key;

            str = "select * from CHITIETNHAPHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "CHITIETNHAPHANG");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["CHITIETNHAPHANG"].Columns[0];
            key[1] = DataSet_NhapHang.Tables["CHITIETNHAPHANG"].Columns[1];
            DataSet_NhapHang.Tables["CHITIETNHAPHANG"].PrimaryKey = key;

            str = "select * from HANGHOA";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "HANGHOA");
            key = new DataColumn[1];
            key[0] = DataSet_NhapHang.Tables["HANGHOA"].Columns[0];
            DataSet_NhapHang.Tables["HANGHOA"].PrimaryKey = key;

            str = "select d.MANH, h.TENHH, c.SL, d.NGAYNH , PHINH, h.GIAGOC, THANHTIEN from HANGHOA h, NHAPHANG d, CHITIETNHAPHANG c  where c.MAHH = h.MAHH and d.MANH = c.MANH";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "THONGTIN");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["THONGTIN"].Columns[0];
            key[1] = DataSet_NhapHang.Tables["THONGTIN"].Columns[1];
            DataSet_NhapHang.Tables["THONGTIN"].PrimaryKey = key;
        }
        void LamMoi()
        {
            txtPhi.Clear();
            dtpNgay.Value = DateTime.Parse(DateTime.Now.ToShortDateString());
            cbbHangHoa.SelectedIndex = 0;
            btnDongY.Enabled = false;
            txtSoLuong.Focus();
        }
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            InitDataSet();
            Load_Combobox_HangHoa();
            dtgvDanhMucHH.DataSource = DataSet_NhapHang.Tables["THONGTIN"];
            LamMoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        bool KT_HopLe()
        {
            if (txtPhi.TextLength != 0)
                return true;
            return false;
        }       
        private void txtMaSoPhieuNhapKho_TextChanged(object sender, EventArgs e)
        {
            btnDongY.Enabled = KT_HopLe();
        }
        
        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoLuong.Text == "0" || txtSoLuong.Text==string.Empty)
                {
                    MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                    txtSoLuong.SelectAll();
                    return;
                }
                if (txtSoLuong.Text == string.Empty)
                {
                    MessageBox.Show("Phí nhập hàng không hợp lệ. Vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhi.Focus();
                    txtPhi.SelectAll();
                    return;
                }
                if (txtGia.Text == "0" || txtGia.Text == string.Empty)
                {
                    MessageBox.Show("Giá hàng không hợp lệ. Vui lòng nhập lại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGia.Focus();
                    txtGia.SelectAll();
                    return;
                }
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string ma = "NH" + Public.TaoMa("NHAPHANG", "MANH");
                DataRow dr = DataSet_NhapHang.Tables["NHAPHANG"].NewRow();
                dr["MANH"] = ma;
                dr["NGAYNH"] = dtpNgay.Value.ToShortDateString();
                dr["PHINH"] = float.Parse(txtPhi.Text);
                DataSet_NhapHang.Tables["NHAPHANG"].Rows.Add(dr);

                DataRow dr2 = DataSet_NhapHang.Tables["CHITIETNHAPHANG"].NewRow();
                dr2["MANH"] = ma;
                dr2["MAHH"] = cbbHangHoa.SelectedValue.ToString();
                dr2["SL"] = int.Parse(txtSoLuong.Text);
                dr2["GIAMUA"] = float.Parse(txtGia.Text);
                dr2["THANHTIEN"] = int.Parse(txtSoLuong.Text) * float.Parse(txtGia.Text) + float.Parse(txtPhi.Text);
                DataSet_NhapHang.Tables["CHITIETNHAPHANG"].Rows.Add(dr2);

                DataRow dr3 = DataSet_NhapHang.Tables["TONKHO"].Rows.Find(cbbHangHoa.SelectedValue.ToString());
                dr3["TONDAU"] = int.Parse(dr3["TONCUOI"].ToString());
                dr3["NHAP"] = int.Parse(dr3["NHAP"].ToString()) + int.Parse(txtSoLuong.Text);
                dr3["TONCUOI"] = int.Parse(dr3["TONDAU"].ToString()) + int.Parse(txtSoLuong.Text);
                dr3["TGTTON"] = int.Parse(dr3["TONCUOI"].ToString()) * float.Parse(txtGia.Text);

                DataRow dr4 = DataSet_NhapHang.Tables["HANGHOA"].Rows.Find(cbbHangHoa.SelectedValue.ToString());
                dr4["GIAGOC"] = float.Parse(txtGia.Text);

                string str = "select * from CHITIETDATHANG where MAHH = '" + cbbHangHoa.SelectedValue.ToString() + "' and TINHTRANG = N'Thiếu'";
                SqlDataAdapter da=new SqlDataAdapter(str, Conn);
                DataTable dt=new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i]["SLDH"].ToString()) <= int.Parse(dr3["TONCUOI"].ToString()))
                        dt.Rows[i]["TINHTRANG"] = "Đủ";
                }
                    
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
                //Update
                str = "select * from NHAPHANG";
                da = new SqlDataAdapter(str, Conn);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(da);
                da.Update(DataSet_NhapHang, "NHAPHANG");

                str = "select * from CHITIETNHAPHANG";
                da = new SqlDataAdapter(str, Conn);
                cmdb = new SqlCommandBuilder(da);
                da.Update(DataSet_NhapHang, "CHITIETNHAPHANG");

                str = "select * from TONKHO";
                da = new SqlDataAdapter(str, Conn);
                cmdb = new SqlCommandBuilder(da);
                da.Update(DataSet_NhapHang, "TONKHO");

                str = "select * from HANGHOA";
                da = new SqlDataAdapter(str, Conn);
                cmdb = new SqlCommandBuilder(da);
                da.Update(DataSet_NhapHang, "HANGHOA");

                str = "select * from CHITIETDATHANG";
                da = new SqlDataAdapter(str, Conn);
                cmdb = new SqlCommandBuilder(da);
                da.Update(dt);

                MessageBox.Show("Nhập hàng thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataSet_NhapHang.Tables.Clear();
                frmNhapHang_Load(sender, e);
                txtGia.Clear();
                txtPhi.Clear();
                txtSoLuong.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi! \n\r" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
        }

        private void dtgvDanhMucHH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 3)
            {
                if (e.Value != null)
                {
                    e.Value = string.Format("{0:#,##0}", e.Value);
                }
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
