namespace Lounge
{
    partial class TrangChu
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
            this.pneTitle = new System.Windows.Forms.Panel();
            this.BAR = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblCover = new System.Windows.Forms.Label();
            this.lblWholeCheck = new System.Windows.Forms.Label();
            this.plnBan = new System.Windows.Forms.Panel();
            this.plnMain = new System.Windows.Forms.Panel();
            this.plnSanPham = new System.Windows.Forms.Panel();
            this.plnDanhMuc = new System.Windows.Forms.Panel();
            this.plnHoaDon = new System.Windows.Forms.Panel();
            this.plnBottom = new System.Windows.Forms.Panel();
            this.btnApplyVoucher = new System.Windows.Forms.Button();
            this.btnSendCheck = new System.Windows.Forms.Button();
            this.btnPrintCheck = new System.Windows.Forms.Button();
            this.btnGuestCheck = new System.Windows.Forms.Button();
            this.btnPaid = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pneTitle.SuspendLayout();
            this.plnMain.SuspendLayout();
            this.plnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pneTitle
            // 
            this.pneTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pneTitle.Controls.Add(this.BAR);
            this.pneTitle.Controls.Add(this.lblTime);
            this.pneTitle.Controls.Add(this.btnInfo);
            this.pneTitle.Controls.Add(this.btnExit);
            this.pneTitle.Controls.Add(this.btnBack);
            this.pneTitle.Controls.Add(this.lblTable);
            this.pneTitle.Controls.Add(this.lblCover);
            this.pneTitle.Controls.Add(this.lblWholeCheck);
            this.pneTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pneTitle.Location = new System.Drawing.Point(0, 0);
            this.pneTitle.Name = "pneTitle";
            this.pneTitle.Size = new System.Drawing.Size(1555, 60);
            this.pneTitle.TabIndex = 0;
            // 
            // BAR
            // 
            this.BAR.AutoSize = true;
            this.BAR.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.BAR.ForeColor = System.Drawing.Color.White;
            this.BAR.Location = new System.Drawing.Point(20, 9);
            this.BAR.Name = "BAR";
            this.BAR.Size = new System.Drawing.Size(178, 41);
            this.BAR.TabIndex = 0;
            this.BAR.Text = "LOBBY BAR";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(730, 23);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(150, 20);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "HH:mm:ss dd/MM/yyyy";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(1363, 15);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(80, 30);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1459, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1267, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Quay lại";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(250, 9);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(79, 23);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Bàn: N/A";
            // 
            // lblCover
            // 
            this.lblCover.AutoSize = true;
            this.lblCover.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblCover.ForeColor = System.Drawing.Color.White;
            this.lblCover.Location = new System.Drawing.Point(250, 32);
            this.lblCover.Name = "lblCover";
            this.lblCover.Size = new System.Drawing.Size(75, 23);
            this.lblCover.TabIndex = 7;
            this.lblCover.Text = "Khách: 0";
            // 
            // lblWholeCheck
            // 
            this.lblWholeCheck.AutoSize = true;
            this.lblWholeCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblWholeCheck.ForeColor = System.Drawing.Color.Gold;
            this.lblWholeCheck.Location = new System.Drawing.Point(400, 20);
            this.lblWholeCheck.Name = "lblWholeCheck";
            this.lblWholeCheck.Size = new System.Drawing.Size(132, 23);
            this.lblWholeCheck.TabIndex = 8;
            this.lblWholeCheck.Text = "Tổng cộng: 0.00";
            this.lblWholeCheck.Click += new System.EventHandler(this.lblWholeCheck_Click);
            // 
            // plnBan
            // 
            this.plnBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.plnBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnBan.Location = new System.Drawing.Point(0, 60);
            this.plnBan.Name = "plnBan";
            this.plnBan.Size = new System.Drawing.Size(1555, 768);
            this.plnBan.TabIndex = 1;
            // 
            // plnMain
            // 
            this.plnMain.Controls.Add(this.plnSanPham);
            this.plnMain.Controls.Add(this.plnDanhMuc);
            this.plnMain.Controls.Add(this.plnHoaDon);
            this.plnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnMain.Location = new System.Drawing.Point(0, 60);
            this.plnMain.Name = "plnMain";
            this.plnMain.Size = new System.Drawing.Size(1555, 768);
            this.plnMain.TabIndex = 2;
            this.plnMain.Visible = false;
            // 
            // plnSanPham
            // 
            this.plnSanPham.AutoScroll = true;
            this.plnSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.plnSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnSanPham.Location = new System.Drawing.Point(280, 0);
            this.plnSanPham.Name = "plnSanPham";
            this.plnSanPham.Padding = new System.Windows.Forms.Padding(10);
            this.plnSanPham.Size = new System.Drawing.Size(855, 768);
            this.plnSanPham.TabIndex = 1;
            // 
            // plnDanhMuc
            // 
            this.plnDanhMuc.AutoScroll = true;
            this.plnDanhMuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.plnDanhMuc.Dock = System.Windows.Forms.DockStyle.Left;
            this.plnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.plnDanhMuc.Name = "plnDanhMuc";
            this.plnDanhMuc.Padding = new System.Windows.Forms.Padding(10);
            this.plnDanhMuc.Size = new System.Drawing.Size(280, 768);
            this.plnDanhMuc.TabIndex = 0;
            // 
            // plnHoaDon
            // 
            this.plnHoaDon.AutoScroll = true;
            this.plnHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.plnHoaDon.Dock = System.Windows.Forms.DockStyle.Right;
            this.plnHoaDon.Location = new System.Drawing.Point(1135, 0);
            this.plnHoaDon.Name = "plnHoaDon";
            this.plnHoaDon.Padding = new System.Windows.Forms.Padding(10);
            this.plnHoaDon.Size = new System.Drawing.Size(420, 768);
            this.plnHoaDon.TabIndex = 2;
            // 
            // plnBottom
            // 
            this.plnBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.plnBottom.Controls.Add(this.btnApplyVoucher);
            this.plnBottom.Controls.Add(this.btnSendCheck);
            this.plnBottom.Controls.Add(this.btnPrintCheck);
            this.plnBottom.Controls.Add(this.btnGuestCheck);
            this.plnBottom.Controls.Add(this.btnPaid);
            this.plnBottom.Controls.Add(this.btnCancel);
            this.plnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plnBottom.Location = new System.Drawing.Point(0, 828);
            this.plnBottom.Name = "plnBottom";
            this.plnBottom.Size = new System.Drawing.Size(1555, 70);
            this.plnBottom.TabIndex = 3;
            this.plnBottom.Visible = false;
            // 
            // btnApplyVoucher
            // 
            this.btnApplyVoucher.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApplyVoucher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnApplyVoucher.FlatAppearance.BorderSize = 0;
            this.btnApplyVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyVoucher.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApplyVoucher.ForeColor = System.Drawing.Color.White;
            this.btnApplyVoucher.Location = new System.Drawing.Point(254, 10);
            this.btnApplyVoucher.Name = "btnApplyVoucher";
            this.btnApplyVoucher.Size = new System.Drawing.Size(204, 50);
            this.btnApplyVoucher.TabIndex = 0;
            this.btnApplyVoucher.Text = "ÁP VOUCHER";
            this.btnApplyVoucher.UseVisualStyleBackColor = false;
            // 
            // btnSendCheck
            // 
            this.btnSendCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSendCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(76)))));
            this.btnSendCheck.FlatAppearance.BorderSize = 0;
            this.btnSendCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCheck.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSendCheck.ForeColor = System.Drawing.Color.White;
            this.btnSendCheck.Location = new System.Drawing.Point(468, 10);
            this.btnSendCheck.Name = "btnSendCheck";
            this.btnSendCheck.Size = new System.Drawing.Size(110, 50);
            this.btnSendCheck.TabIndex = 1;
            this.btnSendCheck.Text = "GỬI BẾP";
            this.btnSendCheck.UseVisualStyleBackColor = false;
            this.btnSendCheck.Click += new System.EventHandler(this.btnSendCheck_Click);
            // 
            // btnPrintCheck
            // 
            this.btnPrintCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPrintCheck.FlatAppearance.BorderSize = 0;
            this.btnPrintCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCheck.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPrintCheck.ForeColor = System.Drawing.Color.White;
            this.btnPrintCheck.Location = new System.Drawing.Point(598, 10);
            this.btnPrintCheck.Name = "btnPrintCheck";
            this.btnPrintCheck.Size = new System.Drawing.Size(110, 50);
            this.btnPrintCheck.TabIndex = 2;
            this.btnPrintCheck.Text = "IN BILL";
            this.btnPrintCheck.UseVisualStyleBackColor = false;
            this.btnPrintCheck.Click += new System.EventHandler(this.btnPrintCheck_Click);
            // 
            // btnGuestCheck
            // 
            this.btnGuestCheck.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuestCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGuestCheck.FlatAppearance.BorderSize = 0;
            this.btnGuestCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuestCheck.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnGuestCheck.ForeColor = System.Drawing.Color.White;
            this.btnGuestCheck.Location = new System.Drawing.Point(728, 10);
            this.btnGuestCheck.Name = "btnGuestCheck";
            this.btnGuestCheck.Size = new System.Drawing.Size(110, 50);
            this.btnGuestCheck.TabIndex = 3;
            this.btnGuestCheck.Text = "IN TẠM";
            this.btnGuestCheck.UseVisualStyleBackColor = false;
            this.btnGuestCheck.Click += new System.EventHandler(this.btnGuestCheck_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnPaid.FlatAppearance.BorderSize = 0;
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(858, 10);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(130, 50);
            this.btnPaid.TabIndex = 4;
            this.btnPaid.Text = "THANH TOÁN";
            this.btnPaid.UseVisualStyleBackColor = false;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1008, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 50);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1555, 898);
            this.Controls.Add(this.plnMain);
            this.Controls.Add(this.plnBan);
            this.Controls.Add(this.plnBottom);
            this.Controls.Add(this.pneTitle);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ - Hệ Thống Quản Lý Lounge";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.pneTitle.ResumeLayout(false);
            this.pneTitle.PerformLayout();
            this.plnMain.ResumeLayout(false);
            this.plnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pneTitle;
        private System.Windows.Forms.Label BAR;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblCover;
        private System.Windows.Forms.Label lblWholeCheck;
        private System.Windows.Forms.Panel plnBan;
        private System.Windows.Forms.Panel plnMain;
        private System.Windows.Forms.Panel plnDanhMuc;
        private System.Windows.Forms.Panel plnSanPham;
        private System.Windows.Forms.Panel plnHoaDon;
        private System.Windows.Forms.Panel plnBottom;
        private System.Windows.Forms.Button btnSendCheck;
        private System.Windows.Forms.Button btnPrintCheck;
        private System.Windows.Forms.Button btnGuestCheck;
        private System.Windows.Forms.Button btnPaid;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApplyVoucher;
    }
}
