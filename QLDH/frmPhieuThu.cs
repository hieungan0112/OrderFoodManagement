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
    public partial class frmPhieuThu : Form
    {
        cPublic Public = new cPublic();
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection Conn;
        public frmPhieuThu()
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
        public void LoadComboBox(string Table, string value, string display, ComboBox cbb)
        {
            try
            {
                string str = "select distinct * from " + Table;
                da = new SqlDataAdapter(str, Conn);
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Fill(ds,Table);
                cbb.DataSource = ds.Tables[Table];
                cbb.DisplayMember = display;
                cbb.ValueMember = value;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadComboBox_XH()
        {
            try
            {
                string str = "select * from XUATHANG where MAXH not in (select MAXH from THUTIEN)";
                SqlDataAdapter da = new SqlDataAdapter(str, Conn);
                da.Fill(ds, "XUATHANG");
                cbbMaXH.DataSource = ds.Tables["XUATHANG"];
                cbbMaXH.ValueMember = "MAXH";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadComboBox_KH()
        {
            try
            {
                string str = "select * from KHACHHANG";
                SqlDataAdapter da = new SqlDataAdapter(str, Conn);
                da.Fill(ds, "KHACHHANG");
                cbbKH.DataSource = ds.Tables["KHACHHANG"];
                cbbKH.ValueMember = "MAKH";
                cbbKH.DisplayMember = "TENKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Load_DataGridView()
        {
            try
            {
                string str = "select * from THUTIEN";
                da = new SqlDataAdapter(str, Conn);
                da.Fill(ds, "THUTIEN");
                DataColumn[] key = new DataColumn[1];
                key[0] = ds.Tables["THUTIEN"].Columns[0];
                ds.Tables["THUTIEN"].PrimaryKey = key;
                dtgvList.DataSource = ds.Tables["THUTIEN"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPhieuThu_Load(object sender, EventArgs e)
        {
            LoadComboBox_KH();
            LoadComboBox_XH();
            Load_DataGridView();
            if (cbbMaXH.Items.Count == 0)
                cbbKH.SelectedIndex = -1;
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from THUTIEN", Conn);
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Fill(ds, "THUTIEN");
            DataRow dr = ds.Tables["THUTIEN"].NewRow();
            dr["MAPHIEUTT"] = "TT"+Public.TaoMa("THUTIEN","MAPHIEUTT");
            dr["MAKH"] = cbbKH.SelectedValue.ToString();
            dr["DIENGIAI"] = txtDienGiai.Text;
            dr["NGAYTT"] = dtpNgay.Value.ToShortDateString();
            dr["SOTIEN"] = float.Parse(txtSoTien.Text);
            dr["MAXH"] = cbbMaXH.SelectedValue.ToString();
            ds.Tables["THUTIEN"].Rows.Add(dr);
            da.Update(ds, "THUTIEN");
            btnLuu.Enabled = false;
            txtDienGiai.Clear();
            MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            frmPhieuThu_Load(sender, e);
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

        private void cbbMaXH_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbbMaXH.SelectedValue != null)
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string str = "select * from CHITIETXUATHANG where MAXH = '" + cbbMaXH.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(str, Conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                float SoTien = 0;
                while (rdr.Read())
                {
                    SoTien += float.Parse(rdr["THANHTIEN"].ToString());
                }
                rdr.Close();
                txtSoTien.Text = SoTien.ToString("#,##0");
                str = "select * from XUATHANG where MAXH = '" + cbbMaXH.SelectedValue.ToString() + "'";
                cmd = new SqlCommand(str, Conn);
                SqlDataReader rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    cbbKH.SelectedValue = rdr2["MAKH"].ToString();
                }
                rdr2.Close();
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
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

        private void dtgvList_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgvList.CurrentRow != null)
                maphieu = dtgvList.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInPhieuThu frmIn = new frmInPhieuThu();
            frmIn.ShowDialog();
        }

        private void txtDienGiai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLuu_Click(sender, e);
        }
    }
}
