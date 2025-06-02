namespace Lounge
{
    partial class FormChiTietPhieuXuat
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
            this.labelMaSanPham = new System.Windows.Forms.Label();
            this.cboxMaSanPham = new System.Windows.Forms.ComboBox();
            this.labelSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMaSanPham
            // 
            this.labelMaSanPham.AutoSize = true;
            this.labelMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelMaSanPham.Location = new System.Drawing.Point(30, 30);
            this.labelMaSanPham.Name = "labelMaSanPham";
            this.labelMaSanPham.Size = new System.Drawing.Size(149, 25);
            this.labelMaSanPham.TabIndex = 0;
            this.labelMaSanPham.Text = "Mã sản phẩm:";
            // 
            // cboxMaSanPham
            // 
            this.cboxMaSanPham.FormattingEnabled = true;
            this.cboxMaSanPham.Location = new System.Drawing.Point(200, 28);
            this.cboxMaSanPham.Name = "cboxMaSanPham";
            this.cboxMaSanPham.Size = new System.Drawing.Size(250, 33);
            this.cboxMaSanPham.TabIndex = 1;
            // 
            // labelSoLuong
            // 
            this.labelSoLuong.AutoSize = true;
            this.labelSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSoLuong.Location = new System.Drawing.Point(30, 80);
            this.labelSoLuong.Name = "labelSoLuong";
            this.labelSoLuong.Size = new System.Drawing.Size(93, 25);
            this.labelSoLuong.TabIndex = 2;
            this.labelSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSoLuong.Location = new System.Drawing.Point(200, 78);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(250, 30);
            this.txtSoLuong.TabIndex = 3;
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(200, 130);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 40);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Location = new System.Drawing.Point(350, 130);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormChiTietPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 200);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.labelSoLuong);
            this.Controls.Add(this.cboxMaSanPham);
            this.Controls.Add(this.labelMaSanPham);
            this.Name = "FormChiTietPhieuXuat";
            this.Text = "Chi tiết phiếu xuất";
            this.Load += new System.EventHandler(this.FormChiTietPhieuXuat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelMaSanPham;
        private System.Windows.Forms.ComboBox cboxMaSanPham;
        private System.Windows.Forms.Label labelSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
    }
}