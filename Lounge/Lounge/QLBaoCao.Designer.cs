namespace Lounge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBaoCao = new System.Windows.Forms.DataGridView();
            this.grpThongTinBaoCao = new System.Windows.Forms.GroupBox();
            this.txtMaBaoCao = new System.Windows.Forms.TextBox();
            this.labelMaBaoCao = new System.Windows.Forms.Label();
            this.cboNguoiTao = new System.Windows.Forms.ComboBox();
            this.labelNguoiTao = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.labelGhiChu = new System.Windows.Forms.Label();
            this.txtSoSanPhamBanRa = new System.Windows.Forms.TextBox();
            this.labelSoSanPhamBanRa = new System.Windows.Forms.Label();
            this.txtSoKhachHang = new System.Windows.Forms.TextBox();
            this.labelSoKhachHang = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.labelSoHoaDon = new System.Windows.Forms.Label();
            this.txtTongChiPhi = new System.Windows.Forms.TextBox();
            this.labelTongChiPhi = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.labelTongDoanhThu = new System.Windows.Forms.Label();
            this.dtpNgayBaoCao = new System.Windows.Forms.DateTimePicker();
            this.labelNgayBaoCao = new System.Windows.Forms.Label();
            this.cboLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.labelLoaiBaoCao = new System.Windows.Forms.Label();
            this.grpChucNang = new System.Windows.Forms.GroupBox();
            this.btnLenLichTuDong = new System.Windows.Forms.Button();
            this.btnTaoTuDong = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).BeginInit();
            this.grpThongTinBaoCao.SuspendLayout();
            this.grpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBaoCao
            // 
            this.dgvBaoCao.AllowUserToAddRows = false;
            this.dgvBaoCao.AllowUserToDeleteRows = false;
            this.dgvBaoCao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBaoCao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBaoCao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBaoCao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaoCao.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBaoCao.Location = new System.Drawing.Point(12, 380);
            this.dgvBaoCao.MultiSelect = false;
            this.dgvBaoCao.Name = "dgvBaoCao";
            this.dgvBaoCao.ReadOnly = true;
            this.dgvBaoCao.RowHeadersWidth = 51;
            this.dgvBaoCao.RowTemplate.Height = 24;
            this.dgvBaoCao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBaoCao.Size = new System.Drawing.Size(1160, 310);
            this.dgvBaoCao.TabIndex = 2;
            this.dgvBaoCao.SelectionChanged += new System.EventHandler(this.dgvBaoCao_SelectionChanged);
            // 
            // grpThongTinBaoCao
            // 
            this.grpThongTinBaoCao.Controls.Add(this.txtMaBaoCao);
            this.grpThongTinBaoCao.Controls.Add(this.labelMaBaoCao);
            this.grpThongTinBaoCao.Controls.Add(this.cboNguoiTao);
            this.grpThongTinBaoCao.Controls.Add(this.labelNguoiTao);
            this.grpThongTinBaoCao.Controls.Add(this.txtGhiChu);
            this.grpThongTinBaoCao.Controls.Add(this.labelGhiChu);
            this.grpThongTinBaoCao.Controls.Add(this.txtSoSanPhamBanRa);
            this.grpThongTinBaoCao.Controls.Add(this.labelSoSanPhamBanRa);
            this.grpThongTinBaoCao.Controls.Add(this.txtSoKhachHang);
            this.grpThongTinBaoCao.Controls.Add(this.labelSoKhachHang);
            this.grpThongTinBaoCao.Controls.Add(this.txtSoHoaDon);
            this.grpThongTinBaoCao.Controls.Add(this.labelSoHoaDon);
            this.grpThongTinBaoCao.Controls.Add(this.txtTongChiPhi);
            this.grpThongTinBaoCao.Controls.Add(this.labelTongChiPhi);
            this.grpThongTinBaoCao.Controls.Add(this.txtTongDoanhThu);
            this.grpThongTinBaoCao.Controls.Add(this.labelTongDoanhThu);
            this.grpThongTinBaoCao.Controls.Add(this.dtpNgayBaoCao);
            this.grpThongTinBaoCao.Controls.Add(this.labelNgayBaoCao);
            this.grpThongTinBaoCao.Controls.Add(this.cboLoaiBaoCao);
            this.grpThongTinBaoCao.Controls.Add(this.labelLoaiBaoCao);
            this.grpThongTinBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinBaoCao.Location = new System.Drawing.Point(12, 38);
            this.grpThongTinBaoCao.Name = "grpThongTinBaoCao";
            this.grpThongTinBaoCao.Size = new System.Drawing.Size(862, 336);
            this.grpThongTinBaoCao.TabIndex = 0;
            this.grpThongTinBaoCao.TabStop = false;
            this.grpThongTinBaoCao.Text = "Thông tin Báo Cáo";
            // 
            // txtMaBaoCao
            // 
            this.txtMaBaoCao.Location = new System.Drawing.Point(170, 16);
            this.txtMaBaoCao.Name = "txtMaBaoCao";
            this.txtMaBaoCao.ReadOnly = true;
            this.txtMaBaoCao.Size = new System.Drawing.Size(100, 27);
            this.txtMaBaoCao.TabIndex = 0;
            this.txtMaBaoCao.Visible = false;
            // 
            // labelMaBaoCao
            // 
            this.labelMaBaoCao.AutoSize = true;
            this.labelMaBaoCao.Location = new System.Drawing.Point(23, 23);
            this.labelMaBaoCao.Name = "labelMaBaoCao";
            this.labelMaBaoCao.Size = new System.Drawing.Size(107, 20);
            this.labelMaBaoCao.TabIndex = 33;
            this.labelMaBaoCao.Text = "Mã Báo Cáo:";
            this.labelMaBaoCao.Visible = false;
           
            // 
            // cboNguoiTao
            // 
            this.cboNguoiTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNguoiTao.FormattingEnabled = true;
            this.cboNguoiTao.Location = new System.Drawing.Point(570, 35);
            this.cboNguoiTao.Name = "cboNguoiTao";
            this.cboNguoiTao.Size = new System.Drawing.Size(260, 28);
            this.cboNguoiTao.TabIndex = 5;
            // 
            // labelNguoiTao
            // 
            this.labelNguoiTao.AutoSize = true;
            this.labelNguoiTao.Location = new System.Drawing.Point(430, 38);
            this.labelNguoiTao.Name = "labelNguoiTao";
            this.labelNguoiTao.Size = new System.Drawing.Size(90, 20);
            this.labelNguoiTao.TabIndex = 32;
            this.labelNguoiTao.Text = "Người Tạo:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(570, 80);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(260, 190);
            this.txtGhiChu.TabIndex = 9;
            // 
            // labelGhiChu
            // 
            this.labelGhiChu.AutoSize = true;
            this.labelGhiChu.Location = new System.Drawing.Point(430, 83);
            this.labelGhiChu.Name = "labelGhiChu";
            this.labelGhiChu.Size = new System.Drawing.Size(75, 20);
            this.labelGhiChu.TabIndex = 30;
            this.labelGhiChu.Text = "Ghi Chú:";
            // 
            // txtSoSanPhamBanRa
            // 
            this.txtSoSanPhamBanRa.Location = new System.Drawing.Point(170, 291);
            this.txtSoSanPhamBanRa.Name = "txtSoSanPhamBanRa";
            this.txtSoSanPhamBanRa.ReadOnly = true;
            this.txtSoSanPhamBanRa.Size = new System.Drawing.Size(230, 27);
            this.txtSoSanPhamBanRa.TabIndex = 8;
            this.txtSoSanPhamBanRa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSoSanPhamBanRa
            // 
            this.labelSoSanPhamBanRa.AutoSize = true;
            this.labelSoSanPhamBanRa.Location = new System.Drawing.Point(14, 298);
            this.labelSoSanPhamBanRa.Name = "labelSoSanPhamBanRa";
            this.labelSoSanPhamBanRa.Size = new System.Drawing.Size(123, 20);
            this.labelSoSanPhamBanRa.TabIndex = 28;
            this.labelSoSanPhamBanRa.Text = "SL SP Bán Ra:";
            // 
            // txtSoKhachHang
            // 
            this.txtSoKhachHang.Location = new System.Drawing.Point(170, 247);
            this.txtSoKhachHang.Name = "txtSoKhachHang";
            this.txtSoKhachHang.ReadOnly = true;
            this.txtSoKhachHang.Size = new System.Drawing.Size(230, 27);
            this.txtSoKhachHang.TabIndex = 7;
            this.txtSoKhachHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSoKhachHang
            // 
            this.labelSoKhachHang.AutoSize = true;
            this.labelSoKhachHang.Location = new System.Drawing.Point(15, 250);
            this.labelSoKhachHang.Name = "labelSoKhachHang";
            this.labelSoKhachHang.Size = new System.Drawing.Size(131, 20);
            this.labelSoKhachHang.TabIndex = 26;
            this.labelSoKhachHang.Text = "Số Khách Hàng:";
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(170, 210);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.ReadOnly = true;
            this.txtSoHoaDon.Size = new System.Drawing.Size(230, 27);
            this.txtSoHoaDon.TabIndex = 6;
            this.txtSoHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSoHoaDon
            // 
            this.labelSoHoaDon.AutoSize = true;
            this.labelSoHoaDon.Location = new System.Drawing.Point(20, 210);
            this.labelSoHoaDon.Name = "labelSoHoaDon";
            this.labelSoHoaDon.Size = new System.Drawing.Size(105, 20);
            this.labelSoHoaDon.TabIndex = 24;
            this.labelSoHoaDon.Text = "Số Hóa Đơn:";
            // 
            // txtTongChiPhi
            // 
            this.txtTongChiPhi.Location = new System.Drawing.Point(170, 167);
            this.txtTongChiPhi.Name = "txtTongChiPhi";
            this.txtTongChiPhi.Size = new System.Drawing.Size(230, 27);
            this.txtTongChiPhi.TabIndex = 4;
            this.txtTongChiPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTongChiPhi
            // 
            this.labelTongChiPhi.AutoSize = true;
            this.labelTongChiPhi.Location = new System.Drawing.Point(15, 170);
            this.labelTongChiPhi.Name = "labelTongChiPhi";
            this.labelTongChiPhi.Size = new System.Drawing.Size(110, 20);
            this.labelTongChiPhi.TabIndex = 22;
            this.labelTongChiPhi.Text = "Tổng Chi Phí:";
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Location = new System.Drawing.Point(170, 125);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(230, 27);
            this.txtTongDoanhThu.TabIndex = 3;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelTongDoanhThu
            // 
            this.labelTongDoanhThu.AutoSize = true;
            this.labelTongDoanhThu.Location = new System.Drawing.Point(15, 128);
            this.labelTongDoanhThu.Name = "labelTongDoanhThu";
            this.labelTongDoanhThu.Size = new System.Drawing.Size(138, 20);
            this.labelTongDoanhThu.TabIndex = 20;
            this.labelTongDoanhThu.Text = "Tổng Doanh Thu:";
            // 
            // dtpNgayBaoCao
            // 
            this.dtpNgayBaoCao.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBaoCao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBaoCao.Location = new System.Drawing.Point(170, 91);
            this.dtpNgayBaoCao.Name = "dtpNgayBaoCao";
            this.dtpNgayBaoCao.Size = new System.Drawing.Size(230, 27);
            this.dtpNgayBaoCao.TabIndex = 2;
            // 
            // labelNgayBaoCao
            // 
            this.labelNgayBaoCao.AutoSize = true;
            this.labelNgayBaoCao.Location = new System.Drawing.Point(15, 96);
            this.labelNgayBaoCao.Name = "labelNgayBaoCao";
            this.labelNgayBaoCao.Size = new System.Drawing.Size(122, 20);
            this.labelNgayBaoCao.TabIndex = 18;
            this.labelNgayBaoCao.Text = "Ngày Báo Cáo:";
            // 
            // cboLoaiBaoCao
            // 
            this.cboLoaiBaoCao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiBaoCao.FormattingEnabled = true;
            this.cboLoaiBaoCao.Location = new System.Drawing.Point(170, 55);
            this.cboLoaiBaoCao.Name = "cboLoaiBaoCao";
            this.cboLoaiBaoCao.Size = new System.Drawing.Size(230, 28);
            this.cboLoaiBaoCao.TabIndex = 1;
            // 
            // labelLoaiBaoCao
            // 
            this.labelLoaiBaoCao.AutoSize = true;
            this.labelLoaiBaoCao.Location = new System.Drawing.Point(14, 63);
            this.labelLoaiBaoCao.Name = "labelLoaiBaoCao";
            this.labelLoaiBaoCao.Size = new System.Drawing.Size(116, 20);
            this.labelLoaiBaoCao.TabIndex = 16;
            this.labelLoaiBaoCao.Text = "Loại Báo Cáo:";
            // 
            // grpChucNang
            // 
            this.grpChucNang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpChucNang.Controls.Add(this.btnLenLichTuDong);
            this.grpChucNang.Controls.Add(this.btnTaoTuDong);
            this.grpChucNang.Controls.Add(this.btnXuatExcel);
            this.grpChucNang.Controls.Add(this.btnTimKiem);
            this.grpChucNang.Controls.Add(this.btnXoa);
            this.grpChucNang.Controls.Add(this.btnSua);
            this.grpChucNang.Controls.Add(this.btnThem);
            this.grpChucNang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChucNang.Location = new System.Drawing.Point(880, 70);
            this.grpChucNang.Name = "grpChucNang";
            this.grpChucNang.Size = new System.Drawing.Size(290, 290);
            this.grpChucNang.TabIndex = 1;
            this.grpChucNang.TabStop = false;
            this.grpChucNang.Text = "Chức năng";
            // 
            // btnLenLichTuDong
            // 
            this.btnLenLichTuDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLenLichTuDong.Location = new System.Drawing.Point(150, 205);
            this.btnLenLichTuDong.Name = "btnLenLichTuDong";
            this.btnLenLichTuDong.Size = new System.Drawing.Size(120, 65);
            this.btnLenLichTuDong.TabIndex = 6;
            this.btnLenLichTuDong.Text = "Lên Lịch Tự Động";
            this.btnLenLichTuDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLenLichTuDong.UseVisualStyleBackColor = true;
            // 
            // btnTaoTuDong
            // 
            this.btnTaoTuDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTuDong.Location = new System.Drawing.Point(20, 205);
            this.btnTaoTuDong.Name = "btnTaoTuDong";
            this.btnTaoTuDong.Size = new System.Drawing.Size(120, 65);
            this.btnTaoTuDong.TabIndex = 5;
            this.btnTaoTuDong.Text = "Tạo Tự Động";
            this.btnTaoTuDong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTaoTuDong.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.Location = new System.Drawing.Point(150, 120);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(120, 65);
            this.btnXuatExcel.TabIndex = 4;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(20, 120);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(120, 65);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(195, 35);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 65);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(110, 35);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 65);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(20, 35);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 65);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTieuDe.Location = new System.Drawing.Point(450, 15);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(337, 38);
            this.lblTieuDe.TabIndex = 3;
            this.lblTieuDe.Text = "QUẢN LÝ BÁO CÁO";
            // 
            // QLBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 703);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.grpChucNang);
            this.Controls.Add(this.grpThongTinBaoCao);
            this.Controls.Add(this.dgvBaoCao);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "QLBaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Báo Cáo";
            this.Load += new System.EventHandler(this.QLBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCao)).EndInit();
            this.grpThongTinBaoCao.ResumeLayout(false);
            this.grpThongTinBaoCao.PerformLayout();
            this.grpChucNang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private System.Windows.Forms.DataGridView dgvBaoCao;
        private System.Windows.Forms.GroupBox grpThongTinBaoCao;
        private System.Windows.Forms.ComboBox cboLoaiBaoCao;
        private System.Windows.Forms.Label labelLoaiBaoCao;
        private System.Windows.Forms.DateTimePicker dtpNgayBaoCao;
        private System.Windows.Forms.Label labelNgayBaoCao;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.Label labelTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongChiPhi;
        private System.Windows.Forms.Label labelTongChiPhi;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label labelSoHoaDon;
        private System.Windows.Forms.TextBox txtSoKhachHang;
        private System.Windows.Forms.Label labelSoKhachHang;
        private System.Windows.Forms.TextBox txtSoSanPhamBanRa;
        private System.Windows.Forms.Label labelSoSanPhamBanRa;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label labelGhiChu;
        private System.Windows.Forms.ComboBox cboNguoiTao;
        private System.Windows.Forms.Label labelNguoiTao;
        private System.Windows.Forms.GroupBox grpChucNang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnTaoTuDong;
        private System.Windows.Forms.Button btnLenLichTuDong;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.TextBox txtMaBaoCao;
        private System.Windows.Forms.Label labelMaBaoCao;
    }
}