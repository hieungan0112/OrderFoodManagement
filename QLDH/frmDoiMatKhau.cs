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
    public partial class frmDoiMatKhau : Form
    {
        SqlConnection conn;
        cPublic Public = new cPublic();
        public frmDoiMatKhau()
        {
            InitializeComponent();
            conn = Public.Conn;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            if (txtPassCu.Text == frmMain.MatKhauHienTai && txtPassMoi.Text == txtPassLai.Text)
            {
                if (txtPassMoi.TextLength >= 6)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string str = "update NGUOIDUNG set MK = '" + txtPassMoi.Text + "' where TENND = '" + frmMain.NguoiDungHienTai + "'";
                        SqlCommand cmd = new SqlCommand(str, conn);
                        cmd.ExecuteNonQuery();
                        if (conn.State == ConnectionState.Open)
                            conn.Close();
                        MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Độ dài mật khẩu tối thiểu 6 kí tự", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassMoi.Focus();
                    txtPassMoi.SelectAll();
                }
            }
            else
            {
                if (txtPassCu.Text != frmMain.MatKhauHienTai)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtPassCu.Focus();
                    txtPassCu.SelectAll();
                }
                else
                {
                    MessageBox.Show("Xác nhận mật khẩu không khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtPassLai.Focus();
                    txtPassLai.SelectAll();
                }
            }
        }

        private void txtPassCu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                btnThayDoi_Click(sender, e);
        }

        private void ptbMat1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassCu.UseSystemPasswordChar = false;
        }

        private void ptbMat1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassCu.UseSystemPasswordChar = true;
        }
        private void ptbMat2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassMoi.UseSystemPasswordChar = false;
        }

        private void ptbMat2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassMoi.UseSystemPasswordChar = true;
        }
        private void ptbMat3_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassLai.UseSystemPasswordChar = false;
        }

        private void ptbMat3_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassLai.UseSystemPasswordChar = true;
        }
    }
}
