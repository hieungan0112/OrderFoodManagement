namespace QLDH
{
    partial class frmDoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMatKhau));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassCu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassMoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassLai = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThayDoi = new System.Windows.Forms.Button();
            this.ptbMat1 = new System.Windows.Forms.PictureBox();
            this.ptbMat2 = new System.Windows.Forms.PictureBox();
            this.ptbMat3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(42, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐỔI MẬT KHẨU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu cũ:";
            // 
            // txtPassCu
            // 
            this.txtPassCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassCu.Location = new System.Drawing.Point(126, 68);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(167, 26);
            this.txtPassCu.TabIndex = 0;
            this.txtPassCu.UseSystemPasswordChar = true;
            this.txtPassCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassCu_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassMoi.Location = new System.Drawing.Point(126, 103);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.Size = new System.Drawing.Size(167, 26);
            this.txtPassMoi.TabIndex = 1;
            this.txtPassMoi.UseSystemPasswordChar = true;
            this.txtPassMoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassCu_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nhập lại:";
            // 
            // txtPassLai
            // 
            this.txtPassLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassLai.Location = new System.Drawing.Point(126, 138);
            this.txtPassLai.Name = "txtPassLai";
            this.txtPassLai.Size = new System.Drawing.Size(167, 26);
            this.txtPassLai.TabIndex = 2;
            this.txtPassLai.UseSystemPasswordChar = true;
            this.txtPassLai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassCu_KeyDown);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = global::QLDH.Properties.Resources.exit;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.Location = new System.Drawing.Point(181, 200);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(115, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy    ";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThayDoi
            // 
            this.btnThayDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThayDoi.Image = global::QLDH.Properties.Resources.ThayDoi;
            this.btnThayDoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThayDoi.Location = new System.Drawing.Point(29, 200);
            this.btnThayDoi.Name = "btnThayDoi";
            this.btnThayDoi.Size = new System.Drawing.Size(115, 40);
            this.btnThayDoi.TabIndex = 3;
            this.btnThayDoi.Text = "Thay đổi";
            this.btnThayDoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThayDoi.UseVisualStyleBackColor = true;
            this.btnThayDoi.Click += new System.EventHandler(this.btnThayDoi_Click);
            // 
            // ptbMat1
            // 
            this.ptbMat1.Image = ((System.Drawing.Image)(resources.GetObject("ptbMat1.Image")));
            this.ptbMat1.Location = new System.Drawing.Point(294, 69);
            this.ptbMat1.Name = "ptbMat1";
            this.ptbMat1.Size = new System.Drawing.Size(25, 25);
            this.ptbMat1.TabIndex = 5;
            this.ptbMat1.TabStop = false;
            this.ptbMat1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbMat1_MouseDown);
            this.ptbMat1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbMat1_MouseUp);
            // 
            // ptbMat2
            // 
            this.ptbMat2.Image = ((System.Drawing.Image)(resources.GetObject("ptbMat2.Image")));
            this.ptbMat2.Location = new System.Drawing.Point(294, 104);
            this.ptbMat2.Name = "ptbMat2";
            this.ptbMat2.Size = new System.Drawing.Size(25, 25);
            this.ptbMat2.TabIndex = 6;
            this.ptbMat2.TabStop = false;
            this.ptbMat2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbMat2_MouseDown);
            this.ptbMat2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbMat2_MouseUp);
            // 
            // ptbMat3
            // 
            this.ptbMat3.Image = ((System.Drawing.Image)(resources.GetObject("ptbMat3.Image")));
            this.ptbMat3.Location = new System.Drawing.Point(294, 139);
            this.ptbMat3.Name = "ptbMat3";
            this.ptbMat3.Size = new System.Drawing.Size(25, 25);
            this.ptbMat3.TabIndex = 6;
            this.ptbMat3.TabStop = false;
            this.ptbMat3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbMat3_MouseDown);
            this.ptbMat3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbMat3_MouseUp);
            // 
            // frmDoiMatKhau
            // 
            this.AcceptButton = this.btnThayDoi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 265);
            this.Controls.Add(this.ptbMat3);
            this.Controls.Add(this.ptbMat2);
            this.Controls.Add(this.ptbMat1);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThayDoi);
            this.Controls.Add(this.txtPassLai);
            this.Controls.Add(this.txtPassMoi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassCu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(341, 307);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(341, 307);
            this.Name = "frmDoiMatKhau";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMat3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassLai;
        private System.Windows.Forms.Button btnThayDoi;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.PictureBox ptbMat1;
        private System.Windows.Forms.PictureBox ptbMat2;
        private System.Windows.Forms.PictureBox ptbMat3;
    }
}