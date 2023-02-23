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
    public partial class frmDangNhap : Form
    {
        SqlConnection Conn;
        cPublic Public = new cPublic();
        public frmDangNhap()
        {
            InitializeComponent();
            Conn = Public.Conn;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn muốn thoát chương trình ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Cancel)
                txtTenND.Focus();
            else
                Application.Exit();
        }
        bool KQ = false;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                string caulenh = "select * from NGUOIDUNG";
                SqlCommand CMD = new SqlCommand(caulenh, Conn);
                SqlDataReader dtR = CMD.ExecuteReader();
                while (dtR.Read())
                {
                    string ten = (string)dtR[0];
                    string mk = (string)dtR[1];
                    if (ten == txtTenND.Text && mk == txtPass.Text)
                    {
                        frmMain.NguoiDungHienTai = dtR[0].ToString();
                        frmMain.MatKhauHienTai = dtR[1].ToString();
                        frmMain.QuyenTC = dtR[2].ToString();
                        MessageBox.Show("Đăng nhập thành công với quyền \"" + dtR[2].ToString() + "\"", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Close();
                        KQ = true;
                        return;
                    }
                }
                DialogResult r = MessageBox.Show("Tài khoản hoặc Mật khẩu sai. Vui lòng kiểm tra lại", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Cancel)
                    Application.Exit();
                else
                    txtTenND.Focus();

                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!KQ)
                Application.Exit();
        }

        private void txtTenND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ptbMat_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void ptbMat_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

    }
}
