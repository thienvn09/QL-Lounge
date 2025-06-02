namespace Lounge
{
    partial class DangNhap
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
            this.pnlLeftBanner = new System.Windows.Forms.Panel();
            this.lblAppSlogan = new System.Windows.Forms.Label();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.picAppLogo = new System.Windows.Forms.PictureBox();
            this.pnlLoginArea = new System.Windows.Forms.Panel();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.pnlLeftBanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).BeginInit();
            this.pnlLoginArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftBanner
            // 
            this.pnlLeftBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlLeftBanner.Controls.Add(this.lblAppSlogan);
            this.pnlLeftBanner.Controls.Add(this.lblAppTitle);
            this.pnlLeftBanner.Controls.Add(this.picAppLogo);
            this.pnlLeftBanner.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftBanner.Name = "pnlLeftBanner";
            this.pnlLeftBanner.Size = new System.Drawing.Size(400, 500);
            this.pnlLeftBanner.TabIndex = 0;
            // 
            // lblAppSlogan
            // 
            this.lblAppSlogan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAppSlogan.AutoSize = true;
            this.lblAppSlogan.Font = new System.Drawing.Font("Segoe UI Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppSlogan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAppSlogan.Location = new System.Drawing.Point(105, 260);
            this.lblAppSlogan.Name = "lblAppSlogan";
            this.lblAppSlogan.Size = new System.Drawing.Size(166, 23);
            this.lblAppSlogan.TabIndex = 2;
            this.lblAppSlogan.Text = "Trải nghiệm đẳng cấp";
            this.lblAppSlogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(65, 200);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(256, 45);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "Quản lý Lounge";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picAppLogo
            // 
            this.picAppLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picAppLogo.Image = global::Lounge.Properties.Resources.logo;
            this.picAppLogo.Location = new System.Drawing.Point(140, 70);
            this.picAppLogo.Name = "picAppLogo";
            this.picAppLogo.Size = new System.Drawing.Size(131, 105);
            this.picAppLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAppLogo.TabIndex = 0;
            this.picAppLogo.TabStop = false;
            // 
            // pnlLoginArea
            // 
            this.pnlLoginArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.pnlLoginArea.Controls.Add(this.lblLoginTitle);
            this.pnlLoginArea.Controls.Add(this.lblUsername);
            this.pnlLoginArea.Controls.Add(this.txtTaiKhoan);
            this.pnlLoginArea.Controls.Add(this.lblPassword);
            this.pnlLoginArea.Controls.Add(this.txtMatKhau);
            this.pnlLoginArea.Controls.Add(this.btnDangNhap);
            this.pnlLoginArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLoginArea.Location = new System.Drawing.Point(400, 0);
            this.pnlLoginArea.Name = "pnlLoginArea";
            this.pnlLoginArea.Padding = new System.Windows.Forms.Padding(50);
            this.pnlLoginArea.Size = new System.Drawing.Size(500, 500);
            this.pnlLoginArea.TabIndex = 1;
            this.pnlLoginArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLoginArea_Paint);
            // 
            // lblLoginTitle
            // 
            this.lblLoginTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblLoginTitle.Location = new System.Drawing.Point(140, 70);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(219, 45);
            this.lblLoginTitle.TabIndex = 0;
            this.lblLoginTitle.Text = "ĐĂNG NHẬP";
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblUsername.Location = new System.Drawing.Point(70, 150);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(133, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTaiKhoan.BackColor = System.Drawing.Color.White;
            this.txtTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiKhoan.Location = new System.Drawing.Point(75, 180);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(350, 38);
            this.txtTaiKhoan.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblPassword.Location = new System.Drawing.Point(70, 240);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMatKhau.BackColor = System.Drawing.Color.White;
            this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(75, 270);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '●';
            this.txtMatKhau.Size = new System.Drawing.Size(350, 38);
            this.txtMatKhau.TabIndex = 4;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(75, 350);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(350, 55);
            this.btnDangNhap.TabIndex = 5;
            this.btnDangNhap.Text = "ĐĂNG NHẬP";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // DangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.pnlLoginArea);
            this.Controls.Add(this.pnlLeftBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập - Quản Lý Lounge";
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.pnlLeftBanner.ResumeLayout(false);
            this.pnlLeftBanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAppLogo)).EndInit();
            this.pnlLoginArea.ResumeLayout(false);
            this.pnlLoginArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftBanner;
        private System.Windows.Forms.PictureBox picAppLogo;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblAppSlogan;
        private System.Windows.Forms.Panel pnlLoginArea;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.Label lblUsername; // Đổi tên từ Label1
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label lblPassword; // Đổi tên từ Label2
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
    }
}
