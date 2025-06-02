namespace Lounge
{
    partial class FormChiTietPhieuNhapKho
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMaSanPham = new System.Windows.Forms.Label();
            this.cboxMaSanPham = new System.Windows.Forms.ComboBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.labelDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelTitle.Location = new System.Drawing.Point(50, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(392, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "CHI TIẾT PHIẾU NHẬP KHO";
            // 
            // labelMaSanPham
            // 
            this.labelMaSanPham.AutoSize = true;
            this.labelMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelMaSanPham.Location = new System.Drawing.Point(30, 80);
            this.labelMaSanPham.Name = "labelMaSanPham";
            this.labelMaSanPham.Size = new System.Drawing.Size(117, 25);
            this.labelMaSanPham.TabIndex = 1;
            this.labelMaSanPham.Text = "Sản phẩm:";
            // 
            // cboxMaSanPham
            // 
            this.cboxMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cboxMaSanPham.FormattingEnabled = true;
            this.cboxMaSanPham.Location = new System.Drawing.Point(160, 80);
            this.cboxMaSanPham.Name = "cboxMaSanPham";
            this.cboxMaSanPham.Size = new System.Drawing.Size(200, 33);
            this.cboxMaSanPham.TabIndex = 2;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSoLuong.Location = new System.Drawing.Point(30, 130);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(105, 25);
            this.labelSoLuong.TabIndex = 3;
            this.labelSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoLuong.Location = new System.Drawing.Point(160, 130);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(200, 30);
            this.txtSoLuong.TabIndex = 4;
            // 
            // labelDonGia
            // 
            this.labelDonGia.AutoSize = true;
            this.labelDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelDonGia.Location = new System.Drawing.Point(30, 180);
            this.labelDonGia.Name = "labelDonGia";
            this.labelDonGia.Size = new System.Drawing.Size(93, 25);
            this.labelDonGia.TabIndex = 5;
            this.labelDonGia.Text = "Đơn giá:";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtDonGia.Location = new System.Drawing.Point(160, 180);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(200, 30);
            this.txtDonGia.TabIndex = 6;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(100, 240);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Location = new System.Drawing.Point(220, 240);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormChiTietPhieuNhapKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 318);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelMaSanPham);
            this.Controls.Add(this.cboxMaSanPham);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.labelDonGia);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormChiTietPhieuNhapKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi Tiết Phiếu Nhập Kho";
            this.Load += new System.EventHandler(this.FormChiTietPhieuNhapKho_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMaSanPham;
        private System.Windows.Forms.ComboBox cboxMaSanPham;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label labelDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}