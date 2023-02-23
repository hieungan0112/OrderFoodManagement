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
    public partial class frmXuatHang : Form
    {
        public frmXuatHang()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }
        SqlConnection Conn;
        DataSet DataSet_NhapHang = new DataSet();
        SqlDataAdapter DataAdapter = new SqlDataAdapter();
        cPublic Public = new cPublic();
        public void Load_Combobox()
        {
            string str = "select distinct MADH from CHITIETDATHANG where TINHTRANG = N'Đủ'";
            SqlDataAdapter DataAdapter = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            DataAdapter.Fill(dt);
            cbbMaSoDatHang.DataSource = dt;
            cbbMaSoDatHang.ValueMember = "MADH";
           
        }
        void InitDataSet()
        {
            string str = "select * from DATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "DATHANG");
            DataColumn[] key = new DataColumn[1];
            key[0] = DataSet_NhapHang.Tables["DATHANG"].Columns[0];
            DataSet_NhapHang.Tables["DATHANG"].PrimaryKey = key;

            str = "select * from CHITIETDATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "CHITIETDATHANG");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["CHITIETDATHANG"].Columns[0];
            key[1] = DataSet_NhapHang.Tables["CHITIETDATHANG"].Columns[1];
            DataSet_NhapHang.Tables["CHITIETDATHANG"].PrimaryKey = key;

            str = "select * from TONKHO";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "TONKHO");
            key = new DataColumn[1];
            key[0] = DataSet_NhapHang.Tables["TONKHO"].Columns[0];
            DataSet_NhapHang.Tables["TONKHO"].PrimaryKey = key;

            str = "select * from XUATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "XUATHANG");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["XUATHANG"].Columns[0];
            DataSet_NhapHang.Tables["XUATHANG"].PrimaryKey = key;

            str = "select * from CHITIETXUATHANG";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "CHITIETXUATHANG");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["CHITIETXUATHANG"].Columns[0];
            key[1] = DataSet_NhapHang.Tables["CHITIETXUATHANG"].Columns[1];
            DataSet_NhapHang.Tables["CHITIETXUATHANG"].PrimaryKey = key;

            str = "select * from HANGHOA";
            DataAdapter = new SqlDataAdapter(str, Conn);
            DataAdapter.Fill(DataSet_NhapHang, "HANGHOA");
            key = new DataColumn[2];
            key[0] = DataSet_NhapHang.Tables["HANGHOA"].Columns[0];
            DataSet_NhapHang.Tables["HANGHOA"].PrimaryKey = key;

            str = "select x.MAXH, h.TENHH, c.SL, x.NGAYXH , PHIXH, GIABAN, THANHTIEN from HANGHOA h, XUATHANG x, CHITIETXUATHANG c  where c.MAHH = h.MAHH and x.MAXH = c.MAXH";
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
            cbbMaSoDatHang.SelectedIndex = -1;
            btnDongY.Enabled = false;
            txtPhi.Focus();
        }
        private void frmXuatHang_Load(object sender, EventArgs e)
        {
            InitDataSet();
            Load_Combobox();
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
            if (txtPhi.TextLength != 0 && cbbMaSoDatHang.SelectedIndex != -1)
                return true;
            return false;
        }       
        private void txt_TextChanged(object sender, EventArgs e)
        {
            btnDongY.Enabled = KT_HopLe();
        }
        public string TaoMa()
        {
            string ma = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter("select * from XUATHANG", Conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int max = 0;
            foreach (DataRow dr in dt.Rows)
            {
                int x = int.Parse(dr["MAXH"].ToString().Substring(2, 3));
                if (x > max)
                    max = x;
            }
            ma = "XH" + (++max).ToString("000");
            return ma;
        }
        void KT_XuatHang(ref int du, ref int tong, ref DataTable pDT)
        {
            string str = "select * from CHITIETDATHANG where MADH = '" + cbbMaSoDatHang.SelectedValue.ToString() + "' and TINHTRANG = N'Đủ'";
            SqlDataAdapter da = new SqlDataAdapter(str, Conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            du = dt.Rows.Count;
            dt.Clear();
            str = "select * from CHITIETDATHANG where MADH = '" + cbbMaSoDatHang.SelectedValue.ToString() + "'";
            da = new SqlDataAdapter(str, Conn);
            da.Fill(dt);
            tong = dt.Rows.Count;
            if (du < tong)
            {
                str = "select * from CHITIETDATHANG where MADH = '" + cbbMaSoDatHang.SelectedValue.ToString() + "' and TINHTRANG = N'Thiếu'";
                da = new SqlDataAdapter(str, Conn);
                da.Fill(pDT);
            }
        }
        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuongDu = 0, tongSoLuong = 0;//Số lượng mặt hàng đặt đã đủ và tổng số mặt hàng trong đơn đặt hàng
                DataTable DT = new DataTable();
                KT_XuatHang(ref soLuongDu, ref tongSoLuong,ref DT);
                if (DT.Rows.Count == 0)
                {
                    if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    string str = "select * from CHITIETDATHANG where MADH = '" + cbbMaSoDatHang.SelectedValue.ToString() + "' and TINHTRANG = N'Đủ'";
                    SqlDataAdapter da = new SqlDataAdapter(str, Conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CHITIETDATHANG");
                    string ma = TaoMa();
                    DataRow dr = DataSet_NhapHang.Tables["XUATHANG"].NewRow();
                    DataRow dr_t = DataSet_NhapHang.Tables["DATHANG"].Rows.Find(ds.Tables["CHITIETDATHANG"].Rows[0]["MADH"].ToString());
                    dr["MAXH"] = ma;
                    dr["MAKH"] = dr_t["MAKH"].ToString();
                    dr["NGAYXH"] = dtpNgay.Value.ToShortDateString();
                    dr["PHIXH"] = float.Parse(txtPhi.Text);
                    dr["MADH"] = cbbMaSoDatHang.SelectedValue.ToString();
                    DataSet_NhapHang.Tables["XUATHANG"].Rows.Add(dr);


                    for (int i = 0; i < ds.Tables["CHITIETDATHANG"].Rows.Count; i++)
                    {
                        string s = "select GIAGOC from HANGHOA where MAHH='" + ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString() + "'";
                        SqlDataAdapter da_t = new SqlDataAdapter(s, Conn);
                        SqlCommandBuilder cmd_t = new SqlCommandBuilder(da_t);
                        DataTable dtt = new DataTable();
                        da_t.Fill(dtt);
                        float GiaBan = float.Parse(dtt.Rows[0]["GIAGOC"].ToString()) * 1.2f;
                        DataRow dr2 = DataSet_NhapHang.Tables["CHITIETXUATHANG"].NewRow();
                        dr2["MAXH"] = ma;
                        dr2["MAHH"] = ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString();
                        dr2["SL"] = int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr2["GIABAN"] = GiaBan;
                        dr2["THANHTIEN"] = int.Parse(dr2["SL"].ToString()) * GiaBan + float.Parse(txtPhi.Text);
                        DataSet_NhapHang.Tables["CHITIETXUATHANG"].Rows.Add(dr2);

                        DataRow dr3 = DataSet_NhapHang.Tables["TONKHO"].Rows.Find(ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString());
                        dr3["TONDAU"] = int.Parse(dr3["TONCUOI"].ToString());
                        dr3["XUAT"] = int.Parse(dr3["XUAT"].ToString()) + int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr3["TONCUOI"] = int.Parse(dr3["TONDAU"].ToString()) - int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr3["TGTTON"] = int.Parse(dr3["TONCUOI"].ToString()) * float.Parse(dtt.Rows[0]["GIAGOC"].ToString());

                        string[] key = new string[2];
                        key[0] = ds.Tables["CHITIETDATHANG"].Rows[i]["MADH"].ToString();
                        key[1] = ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString();
                        DataRow dr4 = DataSet_NhapHang.Tables["CHITIETDATHANG"].Rows.Find(key);
                        dr4["TINHTRANG"] = "Đã xuất hàng";
                    }
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    //Update
                    str = "select * from XUATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "XUATHANG");

                    str = "select * from CHITIETXUATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "CHITIETXUATHANG");

                    str = "select * from TONKHO";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "TONKHO");

                    str = "select * from CHITIETDATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "CHITIETDATHANG");
                    MessageBox.Show("Xuất hàng thành công " + ds.Tables["CHITIETDATHANG"].Rows.Count + " mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    frmXuatHang_Load(sender, e);
                }
                else
                {
                    string str = "select HANGHOA.MAHH, TENHH, SLDH from CHITIETDATHANG, HANGHOA where MADH='" + cbbMaSoDatHang.SelectedValue.ToString() + "' and HANGHOA.MAHH = CHITIETDATHANG.MAHH and CHITIETDATHANG.TINHTRANG=N'Thiếu'";
                    SqlDataAdapter da = new SqlDataAdapter(str, Conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DataColumn[] key=new DataColumn[1];
                    key[0]=dt.Columns[0];
                    dt.PrimaryKey=key;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Hàng hóa chưa đủ số lượng đặt:");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = DataSet_NhapHang.Tables["TONKHO"].Rows.Find(dt.Rows[i]["MAHH"].ToString());
                        sb.AppendLine(string.Format("- {0}: {1}/{2}", dt.Rows[i]["TENHH"].ToString(), dr["TONCUOI"].ToString(), dt.Rows[i]["SLDH"].ToString()));
                    }
                    sb.AppendLine("Muốn xuất các mặt hàng đủ trước không?");
                    DialogResult r = MessageBox.Show(sb.ToString(),"Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
                    if (r == DialogResult.Yes)
                    {
                        if (Conn.State == ConnectionState.Closed)
                        Conn.Open();
                    str = "select * from CHITIETDATHANG where MADH = '" + cbbMaSoDatHang.SelectedValue.ToString() + "' and TINHTRANG = N'Đủ'";
                    da = new SqlDataAdapter(str, Conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "CHITIETDATHANG");
                    string ma = TaoMa();
                    DataRow dr = DataSet_NhapHang.Tables["XUATHANG"].NewRow();
                    DataRow dr_t = DataSet_NhapHang.Tables["DATHANG"].Rows.Find(ds.Tables["CHITIETDATHANG"].Rows[0]["MADH"].ToString());
                    dr["MAXH"] = ma;
                    dr["MAKH"] = dr_t["MAKH"].ToString();
                    dr["NGAYXH"] = dtpNgay.Value.ToShortDateString();
                    dr["PHIXH"] = float.Parse(txtPhi.Text);
                    dr["MADH"] = cbbMaSoDatHang.SelectedValue.ToString();
                    DataSet_NhapHang.Tables["XUATHANG"].Rows.Add(dr);


                    for (int i = 0; i < ds.Tables["CHITIETDATHANG"].Rows.Count; i++)
                    {
                        string s = "select GIAGOC from HANGHOA where MAHH='" + ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString() + "'";
                        SqlDataAdapter da_t = new SqlDataAdapter(s, Conn);
                        SqlCommandBuilder cmd_t = new SqlCommandBuilder(da_t);
                        DataTable dtt = new DataTable();
                        da_t.Fill(dtt);
                        float GiaBan = float.Parse(dtt.Rows[0]["GIAGOC"].ToString()) * 1.2f;
                        DataRow dr2 = DataSet_NhapHang.Tables["CHITIETXUATHANG"].NewRow();
                        dr2["MAXH"] = ma;
                        dr2["MAHH"] = ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString();
                        dr2["SL"] = int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr2["GIABAN"] = GiaBan;
                        dr2["THANHTIEN"] = int.Parse(dr2["SL"].ToString()) * GiaBan + float.Parse(txtPhi.Text);
                        DataSet_NhapHang.Tables["CHITIETXUATHANG"].Rows.Add(dr2);

                        DataRow dr3 = DataSet_NhapHang.Tables["TONKHO"].Rows.Find(ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString());
                        dr3["TONDAU"] = int.Parse(dr3["TONCUOI"].ToString());
                        dr3["XUAT"] = int.Parse(dr3["XUAT"].ToString()) + int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr3["TONCUOI"] = int.Parse(dr3["TONDAU"].ToString()) - int.Parse(ds.Tables["CHITIETDATHANG"].Rows[i]["SLDH"].ToString());
                        dr3["TGTTON"] = int.Parse(dr3["TONCUOI"].ToString()) * float.Parse(dtt.Rows[0]["GIAGOC"].ToString());

                        string[] key2 = new string[2];
                        key2[0] = ds.Tables["CHITIETDATHANG"].Rows[i]["MADH"].ToString();
                        key2[1] = ds.Tables["CHITIETDATHANG"].Rows[i]["MAHH"].ToString();
                        DataRow dr4 = DataSet_NhapHang.Tables["CHITIETDATHANG"].Rows.Find(key2);
                        dr4["TINHTRANG"] = "Đã xuất hàng";
                    }
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    //Update
                    str = "select * from XUATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "XUATHANG");

                    str = "select * from CHITIETXUATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "CHITIETXUATHANG");

                    str = "select * from TONKHO";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "TONKHO");

                    str = "select * from CHITIETDATHANG";
                    da = new SqlDataAdapter(str, Conn);
                    cmd = new SqlCommandBuilder(da);
                    da.Update(DataSet_NhapHang, "CHITIETDATHANG");
                    MessageBox.Show("Xuất hàng thành công " + ds.Tables["CHITIETDATHANG"].Rows.Count + " mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LamMoi();
                    frmXuatHang_Load(sender, e);
                    }
                }
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

        private void txtPhi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar)&&!Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbMaSoDatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
