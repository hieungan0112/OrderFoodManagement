namespace QLDH
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelTen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelQuyen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstQuanLyNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDanhMucKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDanhMucHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstDanhMucNhaCungCap = new System.Windows.Forms.ToolStripMenuItem();
            this.hàngHóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstHangHoaNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstHangHoaXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstHangHoaDat = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstThanhToanChi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstThanhToanThu = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoNhapHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoXuatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoTonKho = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoCongNo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBaoCaoCongNoKH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstBCCNNCC = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::QLDH.Properties.Resources.Menu;
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelTen,
            this.toolStripStatusLabelQuyen,
            this.toolStripStatusLabelTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 25, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1370, 35);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelTen
            // 
            this.toolStripStatusLabelTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelTen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabelTen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelTen.Name = "toolStripStatusLabelTen";
            this.toolStripStatusLabelTen.Size = new System.Drawing.Size(563, 28);
            this.toolStripStatusLabelTen.Spring = true;
            this.toolStripStatusLabelTen.Text = "Người dùng hiện tại:";
            // 
            // toolStripStatusLabelQuyen
            // 
            this.toolStripStatusLabelQuyen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabelQuyen.Name = "toolStripStatusLabelQuyen";
            this.toolStripStatusLabelQuyen.Size = new System.Drawing.Size(563, 28);
            this.toolStripStatusLabelQuyen.Spring = true;
            this.toolStripStatusLabelQuyen.Text = "Quyền truy cập:";
            // 
            // toolStripStatusLabelTime
            // 
            this.toolStripStatusLabelTime.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStripStatusLabelTime.Name = "toolStripStatusLabelTime";
            this.toolStripStatusLabelTime.Size = new System.Drawing.Size(216, 28);
            this.toolStripStatusLabelTime.Text = "toolStripStatusLabel3";
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip.BackgroundImage")));
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.mnstDanhMuc,
            this.hàngHóaToolStripMenuItem,
            this.thanhToánToolStripMenuItem,
            this.báoCáoToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(11, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1370, 85);
            this.menuStrip.Stretch = false;
            this.menuStrip.TabIndex = 1;
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstQuanLyNguoiDung,
            this.mnstDoiMatKhau,
            this.mnstDangXuat});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hệThốngToolStripMenuItem.Image = global::QLDH.Properties.Resources.HeThong;
            this.hệThốngToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(162, 79);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnstQuanLyNguoiDung
            // 
            this.mnstQuanLyNguoiDung.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstQuanLyNguoiDung.Image = global::QLDH.Properties.Resources.hrm;
            this.mnstQuanLyNguoiDung.Name = "mnstQuanLyNguoiDung";
            this.mnstQuanLyNguoiDung.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnstQuanLyNguoiDung.Size = new System.Drawing.Size(384, 36);
            this.mnstQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.mnstQuanLyNguoiDung.Click += new System.EventHandler(this.mnstQuanLyNguoiDung_Click);
            // 
            // mnstDoiMatKhau
            // 
            this.mnstDoiMatKhau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDoiMatKhau.Image = global::QLDH.Properties.Resources.DoiMK;
            this.mnstDoiMatKhau.Name = "mnstDoiMatKhau";
            this.mnstDoiMatKhau.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnstDoiMatKhau.Size = new System.Drawing.Size(384, 36);
            this.mnstDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnstDoiMatKhau.Click += new System.EventHandler(this.mnstDoiMatKhau_Click);
            // 
            // mnstDangXuat
            // 
            this.mnstDangXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDangXuat.Image = global::QLDH.Properties.Resources.Logout;
            this.mnstDangXuat.Name = "mnstDangXuat";
            this.mnstDangXuat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnstDangXuat.Size = new System.Drawing.Size(384, 36);
            this.mnstDangXuat.Text = "Đăng xuất";
            this.mnstDangXuat.Click += new System.EventHandler(this.mnstDangXuat_Click);
            // 
            // mnstDanhMuc
            // 
            this.mnstDanhMuc.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstDanhMucKhachHang,
            this.mnstDanhMucHangHoa,
            this.mnstDanhMucNhaCungCap});
            this.mnstDanhMuc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.mnstDanhMuc.Image = global::QLDH.Properties.Resources.DanhMuc;
            this.mnstDanhMuc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnstDanhMuc.Name = "mnstDanhMuc";
            this.mnstDanhMuc.Size = new System.Drawing.Size(172, 79);
            this.mnstDanhMuc.Text = "Danh mục";
            // 
            // mnstDanhMucKhachHang
            // 
            this.mnstDanhMucKhachHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDanhMucKhachHang.Image = global::QLDH.Properties.Resources.KhachHang;
            this.mnstDanhMucKhachHang.Name = "mnstDanhMucKhachHang";
            this.mnstDanhMucKhachHang.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.mnstDanhMucKhachHang.Size = new System.Drawing.Size(326, 36);
            this.mnstDanhMucKhachHang.Text = "Khách hàng";
            this.mnstDanhMucKhachHang.Click += new System.EventHandler(this.mnstKhachHang_Click);
            // 
            // mnstDanhMucHangHoa
            // 
            this.mnstDanhMucHangHoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDanhMucHangHoa.Image = global::QLDH.Properties.Resources.HangHoa;
            this.mnstDanhMucHangHoa.Name = "mnstDanhMucHangHoa";
            this.mnstDanhMucHangHoa.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnstDanhMucHangHoa.Size = new System.Drawing.Size(326, 36);
            this.mnstDanhMucHangHoa.Text = "Hàng hóa";
            this.mnstDanhMucHangHoa.Click += new System.EventHandler(this.mnstHangHoa_Click);
            // 
            // mnstDanhMucNhaCungCap
            // 
            this.mnstDanhMucNhaCungCap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstDanhMucNhaCungCap.Image = global::QLDH.Properties.Resources.NhaCC;
            this.mnstDanhMucNhaCungCap.Name = "mnstDanhMucNhaCungCap";
            this.mnstDanhMucNhaCungCap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnstDanhMucNhaCungCap.Size = new System.Drawing.Size(326, 36);
            this.mnstDanhMucNhaCungCap.Text = "Nhà cung cấp";
            this.mnstDanhMucNhaCungCap.Click += new System.EventHandler(this.mnstNhaCungCap_Click);
            // 
            // hàngHóaToolStripMenuItem
            // 
            this.hàngHóaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstHangHoaNhap,
            this.mnstHangHoaXuat,
            this.mnstHangHoaDat});
            this.hàngHóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hàngHóaToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.hàngHóaToolStripMenuItem.Image = global::QLDH.Properties.Resources.DMHangHoa;
            this.hàngHóaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hàngHóaToolStripMenuItem.Name = "hàngHóaToolStripMenuItem";
            this.hàngHóaToolStripMenuItem.Size = new System.Drawing.Size(167, 79);
            this.hàngHóaToolStripMenuItem.Text = "Hàng hóa";
            // 
            // mnstHangHoaNhap
            // 
            this.mnstHangHoaNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstHangHoaNhap.Image = global::QLDH.Properties.Resources.NhapHang;
            this.mnstHangHoaNhap.Name = "mnstHangHoaNhap";
            this.mnstHangHoaNhap.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnstHangHoaNhap.Size = new System.Drawing.Size(357, 36);
            this.mnstHangHoaNhap.Text = "Nhập hàng";
            this.mnstHangHoaNhap.Click += new System.EventHandler(this.mnstHangHoaNhap_Click);
            // 
            // mnstHangHoaXuat
            // 
            this.mnstHangHoaXuat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstHangHoaXuat.Image = global::QLDH.Properties.Resources.XuatHang;
            this.mnstHangHoaXuat.Name = "mnstHangHoaXuat";
            this.mnstHangHoaXuat.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.mnstHangHoaXuat.Size = new System.Drawing.Size(357, 36);
            this.mnstHangHoaXuat.Text = "Xuất hàng";
            this.mnstHangHoaXuat.Click += new System.EventHandler(this.mnstHangHoaXuat_Click);
            // 
            // mnstHangHoaDat
            // 
            this.mnstHangHoaDat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstHangHoaDat.Image = global::QLDH.Properties.Resources.DatHang;
            this.mnstHangHoaDat.Name = "mnstHangHoaDat";
            this.mnstHangHoaDat.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.mnstHangHoaDat.Size = new System.Drawing.Size(357, 36);
            this.mnstHangHoaDat.Text = "Đặt hàng";
            this.mnstHangHoaDat.Click += new System.EventHandler(this.mnstHangHoaDat_Click);
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstThanhToanChi,
            this.mnstThanhToanThu});
            this.thanhToánToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thanhToánToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.thanhToánToolStripMenuItem.Image = global::QLDH.Properties.Resources.ThanhToan;
            this.thanhToánToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(185, 79);
            this.thanhToánToolStripMenuItem.Text = "Thanh toán";
            // 
            // mnstThanhToanChi
            // 
            this.mnstThanhToanChi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstThanhToanChi.Image = global::QLDH.Properties.Resources.ChiTien;
            this.mnstThanhToanChi.Name = "mnstThanhToanChi";
            this.mnstThanhToanChi.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnstThanhToanChi.Size = new System.Drawing.Size(271, 36);
            this.mnstThanhToanChi.Text = "Chi tiền";
            this.mnstThanhToanChi.Click += new System.EventHandler(this.mnstThanhToanChi_Click);
            // 
            // mnstThanhToanThu
            // 
            this.mnstThanhToanThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstThanhToanThu.Image = global::QLDH.Properties.Resources.ThuTien;
            this.mnstThanhToanThu.Name = "mnstThanhToanThu";
            this.mnstThanhToanThu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnstThanhToanThu.Size = new System.Drawing.Size(271, 36);
            this.mnstThanhToanThu.Text = "Thu tiền";
            this.mnstThanhToanThu.Click += new System.EventHandler(this.mnstThanhToanThu_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstBaoCaoHangHoa,
            this.mnstBaoCaoCongNo});
            this.báoCáoToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.báoCáoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.báoCáoToolStripMenuItem.Image = global::QLDH.Properties.Resources.BaoCao;
            this.báoCáoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(149, 79);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // mnstBaoCaoHangHoa
            // 
            this.mnstBaoCaoHangHoa.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstBaoCaoNhapHang,
            this.mnstBaoCaoXuatHang,
            this.mnstBaoCaoTonKho});
            this.mnstBaoCaoHangHoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstBaoCaoHangHoa.Image = global::QLDH.Properties.Resources.DMHangHoa1;
            this.mnstBaoCaoHangHoa.Name = "mnstBaoCaoHangHoa";
            this.mnstBaoCaoHangHoa.Size = new System.Drawing.Size(270, 36);
            this.mnstBaoCaoHangHoa.Text = "Hàng hóa";
            // 
            // mnstBaoCaoNhapHang
            // 
            this.mnstBaoCaoNhapHang.Image = global::QLDH.Properties.Resources.NhapHang;
            this.mnstBaoCaoNhapHang.Name = "mnstBaoCaoNhapHang";
            this.mnstBaoCaoNhapHang.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.N)));
            this.mnstBaoCaoNhapHang.Size = new System.Drawing.Size(365, 36);
            this.mnstBaoCaoNhapHang.Text = "Hàng nhập";
            this.mnstBaoCaoNhapHang.Click += new System.EventHandler(this.mnstBaoCaoNhapHang_Click);
            // 
            // mnstBaoCaoXuatHang
            // 
            this.mnstBaoCaoXuatHang.Image = global::QLDH.Properties.Resources.XuatHang1;
            this.mnstBaoCaoXuatHang.Name = "mnstBaoCaoXuatHang";
            this.mnstBaoCaoXuatHang.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.X)));
            this.mnstBaoCaoXuatHang.Size = new System.Drawing.Size(365, 36);
            this.mnstBaoCaoXuatHang.Text = "Hàng xuất";
            this.mnstBaoCaoXuatHang.Click += new System.EventHandler(this.mnstBaoCaoXuatHang_Click);
            // 
            // mnstBaoCaoTonKho
            // 
            this.mnstBaoCaoTonKho.Image = global::QLDH.Properties.Resources.TonKho;
            this.mnstBaoCaoTonKho.Name = "mnstBaoCaoTonKho";
            this.mnstBaoCaoTonKho.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.mnstBaoCaoTonKho.Size = new System.Drawing.Size(365, 36);
            this.mnstBaoCaoTonKho.Text = "Hàng tồn kho";
            this.mnstBaoCaoTonKho.Click += new System.EventHandler(this.mnstBaoCaoTonKho_Click);
            // 
            // mnstBaoCaoCongNo
            // 
            this.mnstBaoCaoCongNo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnstBaoCaoCongNoKH,
            this.mnstBCCNNCC});
            this.mnstBaoCaoCongNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnstBaoCaoCongNo.Image = global::QLDH.Properties.Resources.CongNo;
            this.mnstBaoCaoCongNo.Name = "mnstBaoCaoCongNo";
            this.mnstBaoCaoCongNo.Size = new System.Drawing.Size(270, 36);
            this.mnstBaoCaoCongNo.Text = "Công nợ";
            // 
            // mnstBaoCaoCongNoKH
            // 
            this.mnstBaoCaoCongNoKH.Image = global::QLDH.Properties.Resources.KhachHang;
            this.mnstBaoCaoCongNoKH.Name = "mnstBaoCaoCongNoKH";
            this.mnstBaoCaoCongNoKH.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.F6)));
            this.mnstBaoCaoCongNoKH.Size = new System.Drawing.Size(369, 36);
            this.mnstBaoCaoCongNoKH.Text = "Khách hàng";
            this.mnstBaoCaoCongNoKH.Click += new System.EventHandler(this.mnstBaoCaoCongNoKH_Click);
            // 
            // mnstBCCNNCC
            // 
            this.mnstBCCNNCC.Image = global::QLDH.Properties.Resources.NhaCC;
            this.mnstBCCNNCC.Name = "mnstBCCNNCC";
            this.mnstBCCNNCC.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.mnstBCCNNCC.Size = new System.Drawing.Size(369, 36);
            this.mnstBCCNNCC.Text = "Nhà cung cấp";
            this.mnstBCCNNCC.Click += new System.EventHandler(this.mnstBCCNNCC_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1364, 736);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đơn hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnstQuanLyNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnstDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnstDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnstDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnstDanhMucKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnstDanhMucHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnstDanhMucNhaCungCap;
        private System.Windows.Forms.ToolStripMenuItem hàngHóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnstHangHoaNhap;
        private System.Windows.Forms.ToolStripMenuItem mnstHangHoaXuat;
        private System.Windows.Forms.ToolStripMenuItem mnstHangHoaDat;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnstThanhToanChi;
        private System.Windows.Forms.ToolStripMenuItem mnstThanhToanThu;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoHangHoa;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoNhapHang;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoXuatHang;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoTonKho;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoCongNo;
        private System.Windows.Forms.ToolStripMenuItem mnstBaoCaoCongNoKH;
        private System.Windows.Forms.ToolStripMenuItem mnstBCCNNCC;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelQuyen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTime;
        private System.Windows.Forms.Timer timer;
    }
}