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
    public partial class frmMain : Form
    {
        public static string NguoiDungHienTai, MatKhauHienTai, QuyenTC;
        public frmMain()
        {
            InitializeComponent();
            toolStripStatusLabelTen.Text = "Người dùng hiện tại: Không xác định";
            toolStripStatusLabelQuyen.Text = "Quyền truy cập: Không xác định";
        }
        bool KT_FormMo(string name)
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child.Name == name)
                    return true;
            }
            return false;
        }
        void closeChild()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap fdn = new frmDangNhap();
            fdn.ShowDialog();
            toolStripStatusLabelTen.Text = "Người dùng hiện tại: " + NguoiDungHienTai;
            toolStripStatusLabelQuyen.Text = "Quyền truy cập: " + QuyenTC;
            timer.Start();
            switch (QuyenTC)
            {
                case "Kế toán":
                {
                    mnstQuanLyNguoiDung.Enabled = false;
                    mnstDanhMucHangHoa.Enabled = mnstDanhMucKhachHang.Enabled = mnstDanhMucNhaCungCap.Enabled = false;
                    mnstHangHoaDat.Enabled = mnstHangHoaXuat.Enabled = false; mnstHangHoaNhap.Enabled = true;
                    mnstThanhToanChi.Enabled = mnstThanhToanThu.Enabled = true;
                        //mnstBaoCaoCongNo.Enabled = mnstBaoCaoDanhThu.Enabled = mnstBaoCaoHangHoa.Enabled = false;
                        break;
                }
                case "Quản lý":
                {
                    mnstQuanLyNguoiDung.Enabled = false;
                    mnstDanhMucHangHoa.Enabled = mnstDanhMucKhachHang.Enabled = mnstDanhMucNhaCungCap.Enabled = false;
                    mnstHangHoaDat.Enabled = mnstHangHoaNhap.Enabled = mnstHangHoaXuat.Enabled = false;
                    mnstThanhToanChi.Enabled = mnstThanhToanThu.Enabled = false;
                        //mnstBaoCaoCongNo.Enabled = mnstBaoCaoDanhThu.Enabled = true;
                        mnstBaoCaoHangHoa.Enabled = false;
                    break;
                }
                case "Quản trị hệ thống":
                {
                    mnstQuanLyNguoiDung.Enabled = true;
                    mnstDanhMucHangHoa.Enabled = mnstDanhMucKhachHang.Enabled = mnstDanhMucNhaCungCap.Enabled = false;
                    mnstHangHoaDat.Enabled = mnstHangHoaNhap.Enabled = mnstHangHoaXuat.Enabled = false;
                    mnstThanhToanChi.Enabled = mnstThanhToanThu.Enabled = false;
                        /*mnstBaoCaoCongNo.Enabled = mnstBaoCaoDanhThu.Enabled = mnstBaoCaoHangHoa.Enabled = false*/;
                        break;
                }
                case "Bán hàng":
                {
                    mnstQuanLyNguoiDung.Enabled = false;
                        //mnstBaoCaoCongNo.Enabled = mnstBaoCaoDanhThu.Enabled = false;
                        mnstBaoCaoHangHoa.Enabled = true;
                    mnstHangHoaDat.Enabled = mnstHangHoaXuat.Enabled = true;
                    mnstHangHoaNhap.Enabled = false;
                    mnstThanhToanChi.Enabled = mnstThanhToanThu.Enabled = false;
                    mnstDanhMucHangHoa.Enabled = mnstDanhMucKhachHang.Enabled = mnstDanhMucNhaCungCap.Enabled = true;
                    break;
                }
                case "Admin":
                {
                    mnstQuanLyNguoiDung.Enabled = true;
                        //mnstBaoCaoCongNo.Enabled = mnstBaoCaoDanhThu.Enabled = true;
                        mnstBaoCaoHangHoa.Enabled = true;
                    mnstHangHoaDat.Enabled = mnstHangHoaXuat.Enabled = true;
                    mnstHangHoaNhap.Enabled = true;
                    mnstThanhToanChi.Enabled = mnstThanhToanThu.Enabled = true;
                    mnstDanhMucHangHoa.Enabled = mnstDanhMucKhachHang.Enabled = mnstDanhMucNhaCungCap.Enabled = true;
                    break;
                }
            }
        }

        private void mnstDangXuat_Click(object sender, EventArgs e)
        {
            toolStripStatusLabelTen.Text = "Người dùng hiện tại: Không xác định";
            toolStripStatusLabelQuyen.Text = "Quyền truy cập: Không xác định";
            closeChild();
            frmMain_Load(sender, e);
        }

        private void mnstDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDMK = new frmDoiMatKhau();
            if (!KT_FormMo(frmDMK.Name))
            {
                frmDMK.MdiParent = this;
                frmDMK.Show();
            }
            else
            {
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnstNhaCungCap_Click(object sender, EventArgs e)
        {
            frmDanhMucNhaCungCap frmNhaCC = new frmDanhMucNhaCungCap();
            if (!KT_FormMo(frmNhaCC.Name))
            {
                frmNhaCC.MdiParent = this;
                frmNhaCC.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstHangHoa_Click(object sender, EventArgs e)
        {
            frmDanhMucHangHoa frmHH = new frmDanhMucHangHoa();
            if (!KT_FormMo(frmHH.Name))
            {
                frmHH.MdiParent = this;
                frmHH.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstKhachHang_Click(object sender, EventArgs e)
        {
            frmDanhMucKhachHang frmKH = new frmDanhMucKhachHang();
            if (!KT_FormMo(frmKH.Name))
            {
                frmKH.MdiParent = this;
                frmKH.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstGioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieu frmGT = new frmGioiThieu();
            if (!KT_FormMo(frmGT.Name))
            {
                frmGT.MdiParent = this;
                frmGT.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frmND = new frmQuanLyNguoiDung();
            if (!KT_FormMo(frmND.Name))
            {
                frmND.MdiParent = this;
                frmND.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstHangHoaNhap_Click(object sender, EventArgs e)
        {
            frmNhapHang frmNH = new frmNhapHang();
            if (!KT_FormMo(frmNH.Name))
            {
                frmNH.MdiParent = this;
                frmNH.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstHangHoaXuat_Click(object sender, EventArgs e)
        {
            frmXuatHang frmXH = new frmXuatHang();
            if (!KT_FormMo(frmXH.Name))
            {
                frmXH.MdiParent = this;
                frmXH.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstThanhToanChi_Click(object sender, EventArgs e)
        {
            frmPhieuChi frmTHUCHI = new frmPhieuChi();
            if (!KT_FormMo(frmTHUCHI.Name))
            {
                frmTHUCHI.MdiParent = this;
                frmTHUCHI.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mnstThanhToanThu_Click(object sender, EventArgs e)
        {
            frmPhieuThu frmTHU = new frmPhieuThu();
            if (!KT_FormMo(frmTHU.Name))
            {
                frmTHU.MdiParent = this;
                frmTHU.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void mnstBaoCaoCongNoKH_Click(object sender, EventArgs e)
        {
            frmBaoCaoCongNoKH frmCongNoKH = new frmBaoCaoCongNoKH();
            if (!KT_FormMo(frmCongNoKH.Name))
            {
                frmCongNoKH.MdiParent = this;
                frmCongNoKH.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            //if(this.Size==MinimumSize)
            //    toolStripStatusLabelTenPM.Visible = false;
            //else
            //    toolStripStatusLabelTenPM.Visible = true;
        }

        private void mnstBaoCaoNhapHang_Click(object sender, EventArgs e)
        {
            frmBaoCaoHangNhap frmBCHN = new frmBaoCaoHangNhap();
            if (!KT_FormMo(frmBCHN.Name))
            {
                frmBCHN.MdiParent = this;
                frmBCHN.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstBaoCaoXuatHang_Click(object sender, EventArgs e)
        {
            frmBaoCaoHangXuat frmBCHX = new frmBaoCaoHangXuat();
            if (!KT_FormMo(frmBCHX.Name))
            {
                frmBCHX.MdiParent = this;
                frmBCHX.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstBaoCaoTonKho_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho frmBCTK = new frmBaoCaoTonKho();
            if (!KT_FormMo(frmBCTK.Name))
            {
                frmBCTK.MdiParent = this;
                frmBCTK.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnstBaoCaoDanhThu_Click(object sender, EventArgs e)
        {
            frmBaoCaoDanhThu frmBCDT = new frmBaoCaoDanhThu();
            if (!KT_FormMo(frmBCDT.Name))
            {
                frmBCDT.MdiParent = this;
                frmBCDT.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnstBaoCaoDanhThu_Click(object sender, EventArgs e)
        {

        }

        private void mnstBCCNNCC_Click(object sender, EventArgs e)
        {
            frmBaoCaoCongNoNCC frmBCNCC = new frmBaoCaoCongNoNCC();
            if (!KT_FormMo(frmBCNCC.Name))
            {
                frmBCNCC.MdiParent = this;
                frmBCNCC.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnstHangHoaDat_Click(object sender, EventArgs e)
        {
            frmDatHang frmDatHang = new frmDatHang();
            if (!KT_FormMo(frmDatHang.Name))
            {
                frmDatHang.MdiParent = this;
                frmDatHang.Show();
            }
            else
                MessageBox.Show("Form đang chạy !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        
    }
}
