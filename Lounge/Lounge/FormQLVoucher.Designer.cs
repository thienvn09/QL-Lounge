namespace Lounge
{
    partial class FormQLVoucher
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.dtpNgayHetHan = new System.Windows.Forms.DateTimePicker();
            this.labelNgayHetHan = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.labelGiaTri = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.labelSanPham = new System.Windows.Forms.Label();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.labelKhachHang = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMaVoucher = new System.Windows.Forms.TextBox();
            this.labelMaVoucher = new System.Windows.Forms.Label();
            this.dgvVoucher = new System.Windows.Forms.DataGridView();
            this.grpDieuHuong = new System.Windows.Forms.GroupBox();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.labelOf = new System.Windows.Forms.Label();
            this.txtHienHanh = new System.Windows.Forms.TextBox();
            this.btnKe = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.cboTimTrangThai = new System.Windows.Forms.ComboBox();
            this.radTimTrangThai = new System.Windows.Forms.RadioButton();
            this.btnKoLoc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.radTimKhachHang = new System.Windows.Forms.RadioButton();
            this.txtTimKhachHang = new System.Windows.Forms.TextBox();
            this.txtTimMaVoucher = new System.Windows.Forms.TextBox();
            this.radTimMaVoucher = new System.Windows.Forms.RadioButton();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).BeginInit();
            this.grpDieuHuong.SuspendLayout();
            this.grpTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpThongTin
            // 
            this.grpThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThongTin.BackColor = System.Drawing.Color.Transparent;
            this.grpThongTin.Controls.Add(this.cboTrangThai);
            this.grpThongTin.Controls.Add(this.labelTrangThai);
            this.grpThongTin.Controls.Add(this.dtpNgayHetHan);
            this.grpThongTin.Controls.Add(this.labelNgayHetHan);
            this.grpThongTin.Controls.Add(this.txtGiaTri);
            this.grpThongTin.Controls.Add(this.labelGiaTri);
            this.grpThongTin.Controls.Add(this.cboSanPham);
            this.grpThongTin.Controls.Add(this.labelSanPham);
            this.grpThongTin.Controls.Add(this.cboKhachHang);
            this.grpThongTin.Controls.Add(this.labelKhachHang);
            this.grpThongTin.Controls.Add(this.btnThoat);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.txtMaVoucher);
            this.grpThongTin.Controls.Add(this.labelMaVoucher);
            this.grpThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(820, 80);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(530, 420);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin Voucher";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.FormattingEnabled = true;
            this.cboTrangThai.Location = new System.Drawing.Point(190, 255);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Size = new System.Drawing.Size(310, 28);
            this.cboTrangThai.TabIndex = 5;
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Location = new System.Drawing.Point(20, 258);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(94, 20);
            this.labelTrangThai.TabIndex = 71;
            this.labelTrangThai.Text = "Trạng Thái:";
            // 
            // dtpNgayHetHan
            // 
            this.dtpNgayHetHan.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayHetHan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayHetHan.Location = new System.Drawing.Point(190, 210);
            this.dtpNgayHetHan.Name = "dtpNgayHetHan";
            this.dtpNgayHetHan.ShowCheckBox = true;
            this.dtpNgayHetHan.Size = new System.Drawing.Size(310, 27);
            this.dtpNgayHetHan.TabIndex = 4;
            // 
            // labelNgayHetHan
            // 
            this.labelNgayHetHan.AutoSize = true;
            this.labelNgayHetHan.Location = new System.Drawing.Point(20, 213);
            this.labelNgayHetHan.Name = "labelNgayHetHan";
            this.labelNgayHetHan.Size = new System.Drawing.Size(120, 20);
            this.labelNgayHetHan.TabIndex = 69;
            this.labelNgayHetHan.Text = "Ngày Hết Hạn:";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(190, 165);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(310, 27);
            this.txtGiaTri.TabIndex = 3;
            this.txtGiaTri.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelGiaTri
            // 
            this.labelGiaTri.AutoSize = true;
            this.labelGiaTri.Location = new System.Drawing.Point(20, 168);
            this.labelGiaTri.Name = "labelGiaTri";
            this.labelGiaTri.Size = new System.Drawing.Size(65, 20);
            this.labelGiaTri.TabIndex = 67;
            this.labelGiaTri.Text = "Giá Trị:";
            // 
            // cboSanPham
            // 
            this.cboSanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(190, 120);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(310, 28);
            this.cboSanPham.TabIndex = 2;
            // 
            // labelSanPham
            // 
            this.labelSanPham.AutoSize = true;
            this.labelSanPham.Location = new System.Drawing.Point(20, 123);
            this.labelSanPham.Name = "labelSanPham";
            this.labelSanPham.Size = new System.Drawing.Size(161, 20);
            this.labelSanPham.TabIndex = 65;
            this.labelSanPham.Text = "Sản Phẩm (Nếu có):";
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboKhachHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(190, 75);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(310, 28);
            this.cboKhachHang.TabIndex = 1;
            // 
            // labelKhachHang
            // 
            this.labelKhachHang.AutoSize = true;
            this.labelKhachHang.Location = new System.Drawing.Point(20, 78);
            this.labelKhachHang.Name = "labelKhachHang";
            this.labelKhachHang.Size = new System.Drawing.Size(176, 20);
            this.labelKhachHang.TabIndex = 63;
            this.labelKhachHang.Text = "Khách Hàng (Nếu có):";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(385, 320);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(115, 57);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(265, 320);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(115, 57);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(145, 320);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(115, 57);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(25, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(115, 57);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // txtMaVoucher
            // 
            this.txtMaVoucher.Location = new System.Drawing.Point(190, 30);
            this.txtMaVoucher.Name = "txtMaVoucher";
            this.txtMaVoucher.ReadOnly = true;
            this.txtMaVoucher.Size = new System.Drawing.Size(310, 27);
            this.txtMaVoucher.TabIndex = 0;
            // 
            // labelMaVoucher
            // 
            this.labelMaVoucher.AutoSize = true;
            this.labelMaVoucher.Location = new System.Drawing.Point(20, 33);
            this.labelMaVoucher.Name = "labelMaVoucher";
            this.labelMaVoucher.Size = new System.Drawing.Size(104, 20);
            this.labelMaVoucher.TabIndex = 44;
            this.labelMaVoucher.Text = "Mã Voucher:";
            // 
            // dgvVoucher
            // 
            this.dgvVoucher.AllowUserToAddRows = false;
            this.dgvVoucher.AllowUserToDeleteRows = false;
            this.dgvVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVoucher.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucher.Location = new System.Drawing.Point(30, 220);
            this.dgvVoucher.MultiSelect = false;
            this.dgvVoucher.Name = "dgvVoucher";
            this.dgvVoucher.ReadOnly = true;
            this.dgvVoucher.RowHeadersWidth = 51;
            this.dgvVoucher.RowTemplate.Height = 24;
            this.dgvVoucher.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoucher.Size = new System.Drawing.Size(760, 380);
            this.dgvVoucher.TabIndex = 4;
            // 
            // grpDieuHuong
            // 
            this.grpDieuHuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpDieuHuong.BackColor = System.Drawing.Color.Transparent;
            this.grpDieuHuong.Controls.Add(this.lblTongSo);
            this.grpDieuHuong.Controls.Add(this.labelOf);
            this.grpDieuHuong.Controls.Add(this.txtHienHanh);
            this.grpDieuHuong.Controls.Add(this.btnKe);
            this.grpDieuHuong.Controls.Add(this.btnDau);
            this.grpDieuHuong.Controls.Add(this.btnCuoi);
            this.grpDieuHuong.Controls.Add(this.btnTruoc);
            this.grpDieuHuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grpDieuHuong.Location = new System.Drawing.Point(130, 620);
            this.grpDieuHuong.Name = "grpDieuHuong";
            this.grpDieuHuong.Size = new System.Drawing.Size(580, 120);
            this.grpDieuHuong.TabIndex = 3;
            this.grpDieuHuong.TabStop = false;
            // 
            // lblTongSo
            // 
            this.lblTongSo.AutoSize = true;
            this.lblTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongSo.Location = new System.Drawing.Point(330, 80);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(19, 20);
            this.lblTongSo.TabIndex = 35;
            this.lblTongSo.Text = "0";
            // 
            // labelOf
            // 
            this.labelOf.AutoSize = true;
            this.labelOf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelOf.Location = new System.Drawing.Point(290, 80);
            this.labelOf.Name = "labelOf";
            this.labelOf.Size = new System.Drawing.Size(15, 20);
            this.labelOf.TabIndex = 34;
            this.labelOf.Text = "/";
            // 
            // txtHienHanh
            // 
            this.txtHienHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHienHanh.Location = new System.Drawing.Point(210, 77);
            this.txtHienHanh.Name = "txtHienHanh";
            this.txtHienHanh.ReadOnly = true;
            this.txtHienHanh.Size = new System.Drawing.Size(70, 27);
            this.txtHienHanh.TabIndex = 33;
            this.txtHienHanh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnKe
            // 
            this.btnKe.BackColor = System.Drawing.Color.SeaGreen;
            this.btnKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKe.ForeColor = System.Drawing.Color.Ivory;
            this.btnKe.Location = new System.Drawing.Point(310, 25);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(100, 40);
            this.btnKe.TabIndex = 2;
            this.btnKe.Text = ">";
            this.btnKe.UseVisualStyleBackColor = false;
            // 
            // btnDau
            // 
            this.btnDau.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDau.ForeColor = System.Drawing.Color.Ivory;
            this.btnDau.Location = new System.Drawing.Point(70, 25);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(100, 40);
            this.btnDau.TabIndex = 0;
            this.btnDau.Text = "<<";
            this.btnDau.UseVisualStyleBackColor = false;
            // 
            // btnCuoi
            // 
            this.btnCuoi.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuoi.ForeColor = System.Drawing.Color.Ivory;
            this.btnCuoi.Location = new System.Drawing.Point(430, 25);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(100, 40);
            this.btnCuoi.TabIndex = 3;
            this.btnCuoi.Text = ">>";
            this.btnCuoi.UseVisualStyleBackColor = false;
            // 
            // btnTruoc
            // 
            this.btnTruoc.BackColor = System.Drawing.Color.SeaGreen;
            this.btnTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruoc.ForeColor = System.Drawing.Color.Ivory;
            this.btnTruoc.Location = new System.Drawing.Point(190, 25);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(100, 40);
            this.btnTruoc.TabIndex = 1;
            this.btnTruoc.Text = "<";
            this.btnTruoc.UseVisualStyleBackColor = false;
            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.grpTimKiem.Controls.Add(this.cboTimTrangThai);
            this.grpTimKiem.Controls.Add(this.radTimTrangThai);
            this.grpTimKiem.Controls.Add(this.btnKoLoc);
            this.grpTimKiem.Controls.Add(this.btnLoc);
            this.grpTimKiem.Controls.Add(this.radTimKhachHang);
            this.grpTimKiem.Controls.Add(this.txtTimKhachHang);
            this.grpTimKiem.Controls.Add(this.txtTimMaVoucher);
            this.grpTimKiem.Controls.Add(this.radTimMaVoucher);
            this.grpTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimKiem.Location = new System.Drawing.Point(30, 80);
            this.grpTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTimKiem.Size = new System.Drawing.Size(760, 125);
            this.grpTimKiem.TabIndex = 2;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm Voucher";
            // 
            // cboTimTrangThai
            // 
            this.cboTimTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimTrangThai.FormattingEnabled = true;
            this.cboTimTrangThai.Location = new System.Drawing.Point(400, 58);
            this.cboTimTrangThai.Name = "cboTimTrangThai";
            this.cboTimTrangThai.Size = new System.Drawing.Size(160, 28);
            this.cboTimTrangThai.TabIndex = 4;
            // 
            // radTimTrangThai
            // 
            this.radTimTrangThai.AutoSize = true;
            this.radTimTrangThai.Location = new System.Drawing.Point(280, 60);
            this.radTimTrangThai.Name = "radTimTrangThai";
            this.radTimTrangThai.Size = new System.Drawing.Size(115, 24);
            this.radTimTrangThai.TabIndex = 3;
            this.radTimTrangThai.TabStop = true;
            this.radTimTrangThai.Text = "Trạng Thái:";
            this.radTimTrangThai.UseVisualStyleBackColor = true;
            // 
            // btnKoLoc
            // 
            this.btnKoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKoLoc.Location = new System.Drawing.Point(590, 70);
            this.btnKoLoc.Name = "btnKoLoc";
            this.btnKoLoc.Size = new System.Drawing.Size(150, 40);
            this.btnKoLoc.TabIndex = 6;
            this.btnKoLoc.Text = "Không Lọc";
            this.btnKoLoc.UseVisualStyleBackColor = true;
            // 
            // btnLoc
            // 
            this.btnLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Location = new System.Drawing.Point(590, 25);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(150, 40);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoc.UseVisualStyleBackColor = true;
            // 
            // radTimKhachHang
            // 
            this.radTimKhachHang.AutoSize = true;
            this.radTimKhachHang.Location = new System.Drawing.Point(20, 60);
            this.radTimKhachHang.Name = "radTimKhachHang";
            this.radTimKhachHang.Size = new System.Drawing.Size(115, 24);
            this.radTimKhachHang.TabIndex = 2;
            this.radTimKhachHang.TabStop = true;
            this.radTimKhachHang.Text = "Tên Khách:";
            this.radTimKhachHang.UseVisualStyleBackColor = true;
            // 
            // txtTimKhachHang
            // 
            this.txtTimKhachHang.Location = new System.Drawing.Point(130, 59);
            this.txtTimKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKhachHang.Name = "txtTimKhachHang";
            this.txtTimKhachHang.Size = new System.Drawing.Size(140, 27);
            this.txtTimKhachHang.TabIndex = 2;
            // 
            // txtTimMaVoucher
            // 
            this.txtTimMaVoucher.Location = new System.Drawing.Point(130, 24);
            this.txtTimMaVoucher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimMaVoucher.Name = "txtTimMaVoucher";
            this.txtTimMaVoucher.Size = new System.Drawing.Size(140, 27);
            this.txtTimMaVoucher.TabIndex = 1;
            // 
            // radTimMaVoucher
            // 
            this.radTimMaVoucher.AutoSize = true;
            this.radTimMaVoucher.Location = new System.Drawing.Point(20, 25);
            this.radTimMaVoucher.Name = "radTimMaVoucher";
            this.radTimMaVoucher.Size = new System.Drawing.Size(92, 24);
            this.radTimMaVoucher.TabIndex = 0;
            this.radTimMaVoucher.TabStop = true;
            this.radTimMaVoucher.Text = "Mã Vch:";
            this.radTimMaVoucher.UseVisualStyleBackColor = true;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.BackColor = System.Drawing.Color.Transparent;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTieuDe.Location = new System.Drawing.Point(480, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(352, 38);
            this.lblTieuDe.TabIndex = 67;
            this.lblTieuDe.Text = "QUẢN LÝ VOUCHER";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Location = new System.Drawing.Point(1180, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(170, 50);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // FormQLVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 770);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.dgvVoucher);
            this.Controls.Add(this.grpDieuHuong);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.btnLamMoi);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FormQLVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Voucher";
            this.Load += new System.EventHandler(this.FormQLVoucher_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucher)).EndInit();
            this.grpDieuHuong.ResumeLayout(false);
            this.grpDieuHuong.PerformLayout();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtMaVoucher;
        private System.Windows.Forms.Label labelMaVoucher;
        private System.Windows.Forms.DataGridView dgvVoucher;
        private System.Windows.Forms.GroupBox grpDieuHuong;
        private System.Windows.Forms.Label lblTongSo;
        private System.Windows.Forms.Label labelOf;
        private System.Windows.Forms.TextBox txtHienHanh;
        private System.Windows.Forms.Button btnKe;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Button btnKoLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.RadioButton radTimKhachHang;
        private System.Windows.Forms.TextBox txtTimKhachHang;
        private System.Windows.Forms.TextBox txtTimMaVoucher;
        private System.Windows.Forms.RadioButton radTimMaVoucher;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.Label labelKhachHang;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label labelSanPham;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label labelGiaTri;
        private System.Windows.Forms.DateTimePicker dtpNgayHetHan;
        private System.Windows.Forms.Label labelNgayHetHan;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.ComboBox cboTimTrangThai;
        private System.Windows.Forms.RadioButton radTimTrangThai;
    }
}
