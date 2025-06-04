using System.Drawing;
using System.Windows.Forms;

namespace Lounge
{
    partial class FormNhanVien
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhanVien));
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.lblTongTin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHienHanh = new System.Windows.Forms.TextBox();
            this.btnKe = new System.Windows.Forms.Button();
            this.btnDau = new System.Windows.Forms.Button();
            this.btnCuoi = new System.Windows.Forms.Button();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKoLoc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.txt_timTenNV = new System.Windows.Forms.TextBox();
            this.radTenNV = new System.Windows.Forms.RadioButton();
            this.radMaNV = new System.Windows.Forms.RadioButton();
            this.txt_timMaNV = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dtpNgayVaoLam = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 200);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 80;
            this.dgvNhanVien.RowTemplate.Height = 30;
            this.dgvNhanVien.Size = new System.Drawing.Size(1100, 500);
            this.dgvNhanVien.TabIndex = 48;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.ColumnHeadersHeight = 40;
            this.dgvNhanVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvNhanVien.SelectionChanged += new System.EventHandler(this.dgvNhanVien_SelectionChanged);
            // 
            // lblTongTin
            // 
            this.lblTongTin.AutoSize = true;
            this.lblTongTin.Location = new System.Drawing.Point(365, 84);
            this.lblTongTin.Name = "lblTongTin";
            this.lblTongTin.Size = new System.Drawing.Size(70, 25);
            this.lblTongTin.TabIndex = 35;
            this.lblTongTin.Text = "label4";
            this.lblTongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "of";
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // txtHienHanh
            // 
            this.txtHienHanh.Location = new System.Drawing.Point(128, 79);
            this.txtHienHanh.Name = "txtHienHanh";
            this.txtHienHanh.Size = new System.Drawing.Size(201, 30);
            this.txtHienHanh.TabIndex = 33;
            this.txtHienHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // btnKe
            // 
            this.btnKe.Location = new System.Drawing.Point(297, 29);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(111, 44);
            this.btnKe.TabIndex = 31;
            this.btnKe.Text = ">";
            // 
            // btnDau
            // 
            this.btnDau.Location = new System.Drawing.Point(63, 29);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(111, 44);
            this.btnDau.TabIndex = 28;
            this.btnDau.Text = "<<";
            // 
            // btnCuoi
            // 
            this.btnCuoi.Location = new System.Drawing.Point(414, 29);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(111, 44);
            this.btnCuoi.TabIndex = 29;
            this.btnCuoi.Text = ">>";
            // 
            // btnTruoc
            // 
            this.btnTruoc.Location = new System.Drawing.Point(180, 29);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(111, 44);
            this.btnTruoc.TabIndex = 32;
            this.btnTruoc.Text = "<";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTongTin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtHienHanh);
            this.groupBox3.Controls.Add(this.btnKe);
            this.groupBox3.Controls.Add(this.btnDau);
            this.groupBox3.Controls.Add(this.btnCuoi);
            this.groupBox3.Controls.Add(this.btnTruoc);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(20, 710);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 125);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(1486, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(150, 60);
            this.btnLamMoi.TabIndex = 49;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(20, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1000, 120);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            this.groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // btnKoLoc
            // 
            this.btnKoLoc.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.btnKoLoc.Name = "btnKoLoc";
            this.btnKoLoc.Size = new System.Drawing.Size(150, 60);
            this.btnKoLoc.TabIndex = 46;
            this.btnKoLoc.Text = "Không Lọc";
            this.btnKoLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKoLoc.Click += new System.EventHandler(this.btnKoLoc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(150, 60);
            this.btnLoc.TabIndex = 45;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txt_timTenNV
            // 
            this.txt_timTenNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txt_timTenNV.Name = "txt_timTenNV";
            this.txt_timTenNV.Size = new System.Drawing.Size(300, 30);
            this.txt_timTenNV.TabIndex = 17;
            this.txt_timTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // radTenNV
            // 
            this.radTenNV.AutoSize = true;
            this.radTenNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.radTenNV.Name = "radTenNV";
            this.radTenNV.Size = new System.Drawing.Size(178, 29);
            this.radTenNV.TabIndex = 16;
            this.radTenNV.TabStop = true;
            this.radTenNV.Text = "Tên nhân viên:";
            this.radTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // radMaNV
            // 
            this.radMaNV.AutoSize = true;
            this.radMaNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.radMaNV.Name = "radMaNV";
            this.radMaNV.Size = new System.Drawing.Size(170, 29);
            this.radMaNV.TabIndex = 15;
            this.radMaNV.TabStop = true;
            this.radMaNV.Text = "Mã nhân viên:";
            this.radMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // txt_timMaNV
            // 
            this.txt_timMaNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txt_timMaNV.Name = "txt_timMaNV";
            this.txt_timMaNV.Size = new System.Drawing.Size(300, 30);
            this.txt_timMaNV.TabIndex = 1;
            this.txt_timMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.DarkGreen;
            this.label17.Location = new System.Drawing.Point(0, 8); // Will be centered in Resize event
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(411, 42);
            this.label17.TabIndex = 55;
            this.label17.Text = "QUẢN LÝ NHÂN VIÊN";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label17.Anchor = AnchorStyles.Top;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "Mã nhân viên:";
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "Tên nhân viên:";
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(400, 30);
            this.txtMaNV.TabIndex = 47;
            this.txtMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(400, 30);
            this.txtTenNV.TabIndex = 49;
            this.txtTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 25);
            this.label14.TabIndex = 56;
            this.label14.Text = "Điện thoại:";
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(0, 0); // Will be set by FlowLayoutPanel
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 60);
            this.btnThem.TabIndex = 60;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(400, 30);
            this.txtDienThoai.TabIndex = 58;
            this.txtDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 25);
            this.label11.TabIndex = 65;
            this.label11.Text = "Ngày vào làm:";
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(0, 0); // Will be set by FlowLayoutPanel
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 60);
            this.btnSua.TabIndex = 61;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(0, 0); // Will be set by FlowLayoutPanel
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 60);
            this.btnXoa.TabIndex = 62;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Email:";
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(0, 0); // Will be set by FlowLayoutPanel
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(150, 60);
            this.btnThoat.TabIndex = 63;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 30);
            this.txtEmail.TabIndex = 67;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(400, 30);
            this.dtpNgayVaoLam.TabIndex = 69;
            this.dtpNgayVaoLam.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(1150, 60);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(530, 700);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin nhân viên";
            this.groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(400, 30);
            this.txtChucVu.TabIndex = 71;
            this.txtChucVu.Visible = true;
            this.txtChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 0); // Will be set by TableLayoutPanel
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 70;
            this.label5.Text = "Chức Vụ";
            this.label5.Visible = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            // 
            // FormNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1686, 856);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnLamMoi);
            this.Name = "FormNhanVien";
            this.Text = "FormNhanVien";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
            this.Resize += new System.EventHandler(this.FormNhanVien_Resize);
            // 
            // Style buttons consistently
            // 
            Color buttonBackColor = System.Drawing.Color.SeaGreen;
            Color buttonForeColor = System.Drawing.Color.Ivory;
            Font buttonFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            foreach (Button btn in new[] { btnThem, btnSua, btnXoa, btnThoat, btnLoc, btnKoLoc, btnLamMoi, btnDau, btnTruoc, btnKe, btnCuoi })
            {
                btn.BackColor = buttonBackColor;
                btn.ForeColor = buttonForeColor;
                btn.Font = buttonFont;
                btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                btn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            }
            // 
            // Setup TableLayoutPanels
            // 
            SetupGroupBox2Layout();
            SetupGroupBox4Layout();
            // 
            // Center label17
            // 
            this.label17.Location = new System.Drawing.Point((this.ClientSize.Width - this.label17.Width) / 2, 8);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupGroupBox2Layout()
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 3,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new System.Drawing.Point(10, 30),
                Width = this.groupBox2.Width - 20
            };
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.Controls.Add(this.radMaNV, 0, 0);
            tableLayout.Controls.Add(this.txt_timMaNV, 1, 0);
            tableLayout.Controls.Add(this.btnLoc, 2, 0);
            tableLayout.Controls.Add(this.radTenNV, 0, 1);
            tableLayout.Controls.Add(this.txt_timTenNV, 1, 1);
            tableLayout.Controls.Add(this.btnKoLoc, 2, 1);
            this.groupBox2.Controls.Clear();
            this.groupBox2.Controls.Add(tableLayout);
        }

        private void SetupGroupBox4Layout()
        {
            TableLayoutPanel tableLayout = new TableLayoutPanel
            {
                RowCount = 6,
                ColumnCount = 2,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new System.Drawing.Point(10, 30),
                Width = this.groupBox4.Width - 20
            };
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayout.Controls.Add(this.label2, 0, 0);
            tableLayout.Controls.Add(this.txtMaNV, 1, 0);
            tableLayout.Controls.Add(this.label7, 0, 1);
            tableLayout.Controls.Add(this.txtTenNV, 1, 1);
            tableLayout.Controls.Add(this.label14, 0, 2);
            tableLayout.Controls.Add(this.txtDienThoai, 1, 2);
            tableLayout.Controls.Add(this.label5, 0, 3);
            tableLayout.Controls.Add(this.txtChucVu, 1, 3);
            tableLayout.Controls.Add(this.label11, 0, 4);
            tableLayout.Controls.Add(this.dtpNgayVaoLam, 1, 4);
            tableLayout.Controls.Add(this.label10, 0, 5);
            tableLayout.Controls.Add(this.txtEmail, 1, 5);
            this.groupBox4.Controls.Clear();
            this.groupBox4.Controls.Add(tableLayout);

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new System.Drawing.Point(10, tableLayout.Bottom + 10)
            };
            buttonPanel.Controls.Add(this.btnThem);
            buttonPanel.Controls.Add(this.btnSua);
            buttonPanel.Controls.Add(this.btnXoa);
            buttonPanel.Controls.Add(this.btnThoat);
            this.groupBox4.Controls.Add(buttonPanel);
        }

       
        

        #endregion
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Label lblTongTin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHienHanh;
        private System.Windows.Forms.Button btnKe;
        private System.Windows.Forms.Button btnDau;
        private System.Windows.Forms.Button btnCuoi;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKoLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.TextBox txt_timTenNV;
        private System.Windows.Forms.RadioButton radTenNV;
        private System.Windows.Forms.RadioButton radMaNV;
        private System.Windows.Forms.TextBox txt_timMaNV;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dtpNgayVaoLam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label label5;
    }
}