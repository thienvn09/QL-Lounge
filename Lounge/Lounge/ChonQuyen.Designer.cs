namespace Lounge
{
    partial class ChonQuyen
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnBH = new System.Windows.Forms.Button();
            this.BtnQT = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlMain.Controls.Add(this.lblWelcome);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(800, 120);
            this.pnlMain.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(760, 80);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng bạn đến với Phần mềm Quản lý Lounge";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlButtons.Controls.Add(this.btnBH);
            this.pnlButtons.Controls.Add(this.BtnQT);
            this.pnlButtons.Location = new System.Drawing.Point(50, 150);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(708, 227);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnBH
            // 
            this.btnBH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnBH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBH.FlatAppearance.BorderSize = 0;
            this.btnBH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBH.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBH.ForeColor = System.Drawing.Color.White;
            this.btnBH.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBH.Location = new System.Drawing.Point(372, 3);
            this.btnBH.Name = "btnBH";
            this.btnBH.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.btnBH.Size = new System.Drawing.Size(333, 221);
            this.btnBH.TabIndex = 1;
            this.btnBH.Text = "\r\nTRANG CHỦ (BÁN HÀNG)";
            this.btnBH.UseVisualStyleBackColor = false;
            this.btnBH.Click += new System.EventHandler(this.btnBH_Click);
            // 
            // BtnQT
            // 
            this.BtnQT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.BtnQT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnQT.FlatAppearance.BorderSize = 0;
            this.BtnQT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQT.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQT.ForeColor = System.Drawing.Color.White;
            this.BtnQT.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnQT.Location = new System.Drawing.Point(3, 0);
            this.BtnQT.Name = "BtnQT";
            this.BtnQT.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.BtnQT.Size = new System.Drawing.Size(341, 224);
            this.BtnQT.TabIndex = 0;
            this.BtnQT.Text = "\r\nQUẢN TRỊ HỆ THỐNG";
            this.BtnQT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BtnQT.UseVisualStyleBackColor = false;
            this.BtnQT.Click += new System.EventHandler(this.BtnQT_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatAppearance.BorderSize = 0;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(546, 380);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(15, 0, 20, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(234, 58);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "  Đăng xuất";
            this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // ChonQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChonQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Chức Năng";
            this.pnlMain.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain; // Renamed from panel1
        private System.Windows.Forms.Label lblWelcome; // Renamed from label1
        private System.Windows.Forms.Button BtnQT;
        private System.Windows.Forms.Button btnBH;
        private System.Windows.Forms.Button btnDangXuat; // Renamed from button2
        private System.Windows.Forms.Panel pnlButtons;
    }
}
