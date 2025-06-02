using System.Drawing;
using System.Windows.Forms;

namespace Lounge
{
    partial class TrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            this.plnDanhMuc = new System.Windows.Forms.Panel();
            this.plnSanPham = new System.Windows.Forms.Panel();
            this.plnHoaDon = new System.Windows.Forms.Panel();
            this.plnBottom = new System.Windows.Forms.Panel();
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
            this.BAR.Location = new System.Drawing.Point(20, 15);
            this.BAR.Name = "BAR";
            this.BAR.Size = new System.Drawing.Size(178, 41);
            this.BAR.TabIndex = 0;
            this.BAR.Text = "LOBBY BAR";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(600, 10);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 16);
            this.lblTime.TabIndex = 2;
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Location = new System.Drawing.Point(1274, 15);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(80, 30);
            this.btnInfo.TabIndex = 3;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1360, 15);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1188, 15);
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
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(900, 10);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(72, 16);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Table: N/A";
            // 
            // lblCover
            // 
            this.lblCover.AutoSize = true;
            this.lblCover.ForeColor = System.Drawing.Color.White;
            this.lblCover.Location = new System.Drawing.Point(900, 35);
            this.lblCover.Name = "lblCover";
            this.lblCover.Size = new System.Drawing.Size(56, 16);
            this.lblCover.TabIndex = 7;
            this.lblCover.Text = "Cover: 0";
            // 
            // lblWholeCheck
            // 
            this.lblWholeCheck.AutoSize = true;
            this.lblWholeCheck.ForeColor = System.Drawing.Color.White;
            this.lblWholeCheck.Location = new System.Drawing.Point(1000, 10);
            this.lblWholeCheck.Name = "lblWholeCheck";
            this.lblWholeCheck.Size = new System.Drawing.Size(117, 16);
            this.lblWholeCheck.TabIndex = 8;
            this.lblWholeCheck.Text = "Whole Check: 0.00";
            this.lblWholeCheck.Click += new System.EventHandler(this.lblWholeCheck_Click);
            // 
            // plnBan
            // 
            this.plnBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnBan.Location = new System.Drawing.Point(0, 60);
            this.plnBan.Name = "plnBan";
            this.plnBan.Size = new System.Drawing.Size(1555, 764);
            this.plnBan.TabIndex = 1;
            // 
            // plnMain
            // 
            this.plnMain.Controls.Add(this.plnDanhMuc);
            this.plnMain.Controls.Add(this.plnSanPham);
            this.plnMain.Controls.Add(this.plnHoaDon);
            this.plnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnMain.Location = new System.Drawing.Point(0, 60);
            this.plnMain.Name = "plnMain";
            this.plnMain.Size = new System.Drawing.Size(1555, 764);
            this.plnMain.TabIndex = 2;
            this.plnMain.Visible = false;
            // 
            // plnDanhMuc
            // 
            this.plnDanhMuc.AutoScroll = true;
            this.plnDanhMuc.AutoScrollMinSize = new System.Drawing.Size(0, 850);
            this.plnDanhMuc.CausesValidation = false;
            this.plnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.plnDanhMuc.Margin = new System.Windows.Forms.Padding(4);
            this.plnDanhMuc.Name = "plnDanhMuc";
            this.plnDanhMuc.Size = new System.Drawing.Size(453, 1013);
            this.plnDanhMuc.TabIndex = 11;
            // 
            // plnSanPham
            // 
            this.plnSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plnSanPham.Location = new System.Drawing.Point(0, 0);
            this.plnSanPham.Name = "plnSanPham";
            this.plnSanPham.Size = new System.Drawing.Size(949, 764);
            this.plnSanPham.TabIndex = 1;
            // 
            // plnHoaDon
            // 
            this.plnHoaDon.Dock = System.Windows.Forms.DockStyle.Right;
            this.plnHoaDon.Location = new System.Drawing.Point(949, 0);
            this.plnHoaDon.Name = "plnHoaDon";
            this.plnHoaDon.Size = new System.Drawing.Size(606, 764);
            this.plnHoaDon.TabIndex = 2;
            // 
            // plnBottom
            // 
            this.plnBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.plnBottom.Controls.Add(this.btnSendCheck);
            this.plnBottom.Controls.Add(this.btnPrintCheck);
            this.plnBottom.Controls.Add(this.btnGuestCheck);
            this.plnBottom.Controls.Add(this.btnPaid);
            this.plnBottom.Controls.Add(this.btnCancel);
            this.plnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plnBottom.Location = new System.Drawing.Point(0, 824);
            this.plnBottom.Name = "plnBottom";
            this.plnBottom.Size = new System.Drawing.Size(1555, 74);
            this.plnBottom.TabIndex = 3;
            this.plnBottom.Visible = false;
            // 
            // btnSendCheck
            // 
            this.btnSendCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnSendCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnSendCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCheck.ForeColor = System.Drawing.Color.White;
            this.btnSendCheck.Location = new System.Drawing.Point(900, 10);
            this.btnSendCheck.Name = "btnSendCheck";
            this.btnSendCheck.Size = new System.Drawing.Size(90, 40);
            this.btnSendCheck.TabIndex = 0;
            this.btnSendCheck.Text = "Send";
            this.btnSendCheck.UseVisualStyleBackColor = false;
            this.btnSendCheck.Click += new System.EventHandler(this.btnSendCheck_Click);
            // 
            // btnPrintCheck
            // 
            this.btnPrintCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnPrintCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnPrintCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintCheck.ForeColor = System.Drawing.Color.White;
            this.btnPrintCheck.Location = new System.Drawing.Point(1000, 10);
            this.btnPrintCheck.Name = "btnPrintCheck";
            this.btnPrintCheck.Size = new System.Drawing.Size(90, 40);
            this.btnPrintCheck.TabIndex = 1;
            this.btnPrintCheck.Text = "Print";
            this.btnPrintCheck.UseVisualStyleBackColor = false;
            this.btnPrintCheck.Click += new System.EventHandler(this.btnPrintCheck_Click);
            // 
            // btnGuestCheck
            // 
            this.btnGuestCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.btnGuestCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnGuestCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuestCheck.ForeColor = System.Drawing.Color.White;
            this.btnGuestCheck.Location = new System.Drawing.Point(1100, 10);
            this.btnGuestCheck.Name = "btnGuestCheck";
            this.btnGuestCheck.Size = new System.Drawing.Size(90, 40);
            this.btnGuestCheck.TabIndex = 2;
            this.btnGuestCheck.Text = "Guest";
            this.btnGuestCheck.UseVisualStyleBackColor = false;
            this.btnGuestCheck.Click += new System.EventHandler(this.btnGuestCheck_Click);
            // 
            // btnPaid
            // 
            this.btnPaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(204)))));
            this.btnPaid.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(1200, 10);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(90, 40);
            this.btnPaid.TabIndex = 3;
            this.btnPaid.Text = "Paid";
            this.btnPaid.UseVisualStyleBackColor = false;
            this.btnPaid.Click += new System.EventHandler(this.btnPaid_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1300, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
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
            this.Name = "TrangChu";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.pneTitle.ResumeLayout(false);
            this.pneTitle.PerformLayout();
            this.plnMain.ResumeLayout(false);
            this.plnBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

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
        private Button btnSendCheck;
        private Button btnPrintCheck;
        private Button btnGuestCheck;
        private Button btnPaid;
        private Button btnCancel;
    }
}