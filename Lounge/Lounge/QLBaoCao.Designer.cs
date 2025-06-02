using FastReport.DataVisualization.Charting;
namespace NhaHang
{
    partial class QLBaoCao
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
            this.components = new System.ComponentModel.Container();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.dtpNgayBaoCao = new System.Windows.Forms.DateTimePicker();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.txtTongChiPhi = new System.Windows.Forms.TextBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.txtSoKhachHang = new System.Windows.Forms.TextBox();
            this.txtSoSanPhamBanRa = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cboNguoiTao = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnTaoTuDong = new System.Windows.Forms.Button();
            this.btnLenLichTuDong = new System.Windows.Forms.Button();
            
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
          
            this.SuspendLayout();

            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCao.Location = new System.Drawing.Point(12, 150);
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.Size = new System.Drawing.Size(960, 200);
            this.dgvBaoCao.TabIndex = 0;
            this.dgvBaoCao.SelectionChanged += new System.EventHandler(this.dgvBaoCao_SelectionChanged);

            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(100, 12);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(150, 21);
            this.cboLoaiBaoCao.TabIndex = 1;

            // 
            // dtpNgayBaoCao
            // 
            this.dtpNgayBaoCao.Location = new System.Drawing.Point(100, 39);
            this.dtpNgayBaoCao.Name = "dtpNgayBaoCao";
            this.dtpNgayBaoCao.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayBaoCao.TabIndex = 2;

            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(100, 66);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(150, 20);
            this.txtTongDoanhThu.TabIndex = 3;

            // 
            // txtTongChiPhi
            // 
            this.txtTongChiPhi.Location = new System.Drawing.Point(100, 93);
            this.txtTongChiPhi.Name = "txtTongChiPhi";
            this.txtTongChiPhi.Size = new System.Drawing.Size(150, 20);
            this.txtTongChiPhi.TabIndex = 4;

            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(100, 120);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(150, 20);
            this.txtSoHoaDon.TabIndex = 5;

            // 
            // txtSoKhachHang
            // 
            this.txtSoKhachHang.Location = new System.Drawing.Point(350, 12);
            this.txtSoKhachHang.Name = "txtSoKhachHang";
            this.txtSoKhachHang.Size = new System.Drawing.Size(150, 20);
            this.txtSoKhachHang.TabIndex = 6;

            // 
            // txtSoSanPhamBanRa
            // 
            this.txtSoSanPhamBanRa.Location = new System.Drawing.Point(350, 39);
            this.txtSoSanPhamBanRa.Name = "txtSoSanPhamBanRa";
            this.txtSoSanPhamBanRa.Size = new System.Drawing.Size(150, 20);
            this.txtSoSanPhamBanRa.TabIndex = 7;

            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(350, 66);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(150, 74);
            this.txtGhiChu.TabIndex = 8;

            // 
            // cboNguoiTao
            // 
            this.cboNguoiTao.FormattingEnabled = true;
            this.cboNguoiTao.Location = new System.Drawing.Point(600, 12);
            this.cboNguoiTao.Name = "cboNguoiTao";
            this.cboNguoiTao.Size = new System.Drawing.Size(150, 21);
            this.cboNguoiTao.TabIndex = 9;

            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 360);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(93, 360);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(174, 360);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(255, 360);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 13;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(336, 360);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 14;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // 
            // btnTaoTuDong
            // 
            this.btnTaoTuDong.Location = new System.Drawing.Point(417, 360);
            this.btnTaoTuDong.Name = "btnTaoTuDong";
            this.btnTaoTuDong.Size = new System.Drawing.Size(75, 23);
            this.btnTaoTuDong.TabIndex = 15;
            this.btnTaoTuDong.Text = "Tạo Tự Động";
            this.btnTaoTuDong.UseVisualStyleBackColor = true;
            this.btnTaoTuDong.Click += new System.EventHandler(this.btnTaoTuDong_Click);

            // 
            // btnLenLichTuDong
            // 
            this.btnLenLichTuDong.Location = new System.Drawing.Point(498, 360);
            this.btnLenLichTuDong.Name = "btnLenLichTuDong";
            this.btnLenLichTuDong.Size = new System.Drawing.Size(100, 23);
            this.btnLenLichTuDong.TabIndex = 16;
            this.btnLenLichTuDong.Text = "Lên Lịch Tự Động";
            this.btnLenLichTuDong.UseVisualStyleBackColor = true;
         

           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Loại Báo Cáo:";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ngày Báo Cáo:";

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Tổng Doanh Thu:";

            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Tổng Chi Phí:";

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Số Hóa Đơn:";

            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Số Khách Hàng:";

            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(262, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Sản Phẩm Bán:";

            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(512, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Người Tạo:";

            // 
            // QLBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
     
            this.Controls.Add(this.btnLenLichTuDong);
            this.Controls.Add(this.btnTaoTuDong);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cboNguoiTao);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtSoSanPhamBanRa);
            this.Controls.Add(this.txtSoKhachHang);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.txtTongChiPhi);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.dtpNgayBaoCao);
            this.Controls.Add(this.cboLoaiBaoCao);
            this.Controls.Add(this.dgvBaoCao);
            this.Name = "QLBaoCao";
            this.Text = "Quản Lý Báo Cáo";
            this.Load += new System.EventHandler(this.QLBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.DateTimePicker dtpNgayBaoCao;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongChiPhi;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.TextBox txtSoKhachHang;
        private System.Windows.Forms.TextBox txtSoSanPhamBanRa;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cboNguoiTao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnTaoTuDong;
        private System.Windows.Forms.Button btnLenLichTuDong;
    
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}