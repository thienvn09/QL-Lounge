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
            this.dgvNhanVien.Location = new System.Drawing.Point(56, 204);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(1128, 498);
            this.dgvNhanVien.TabIndex = 48;
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
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(338, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 25);
            this.label3.TabIndex = 34;
            this.label3.Text = "of";
            // 
            // txtHienHanh
            // 
            this.txtHienHanh.Location = new System.Drawing.Point(128, 79);
            this.txtHienHanh.Name = "txtHienHanh";
            this.txtHienHanh.Size = new System.Drawing.Size(201, 30);
            this.txtHienHanh.TabIndex = 33;
            // 
            // btnKe
            // 
            this.btnKe.BackColor = System.Drawing.Color.SeaGreen;
            this.btnKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKe.ForeColor = System.Drawing.Color.Ivory;
            this.btnKe.Location = new System.Drawing.Point(297, 29);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(111, 44);
            this.btnKe.TabIndex = 31;
            this.btnKe.Text = ">";
            this.btnKe.UseVisualStyleBackColor = false;
            this.btnKe.Click += new System.EventHandler(this.btnKe_Click);
            // 
            // btnDau
            // 
            this.btnDau.BackColor = System.Drawing.Color.SeaGreen;
            this.btnDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDau.ForeColor = System.Drawing.Color.Ivory;
            this.btnDau.Location = new System.Drawing.Point(63, 29);
            this.btnDau.Name = "btnDau";
            this.btnDau.Size = new System.Drawing.Size(111, 44);
            this.btnDau.TabIndex = 28;
            this.btnDau.Text = "<<";
            this.btnDau.UseVisualStyleBackColor = false;
            this.btnDau.Click += new System.EventHandler(this.btnDau_Click);
            // 
            // btnCuoi
            // 
            this.btnCuoi.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuoi.ForeColor = System.Drawing.Color.Ivory;
            this.btnCuoi.Location = new System.Drawing.Point(414, 29);
            this.btnCuoi.Name = "btnCuoi";
            this.btnCuoi.Size = new System.Drawing.Size(111, 44);
            this.btnCuoi.TabIndex = 29;
            this.btnCuoi.Text = ">>";
            this.btnCuoi.UseVisualStyleBackColor = false;
            this.btnCuoi.Click += new System.EventHandler(this.btnCuoi_Click);
            // 
            // btnTruoc
            // 
            this.btnTruoc.BackColor = System.Drawing.Color.SeaGreen;
            this.btnTruoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruoc.ForeColor = System.Drawing.Color.Ivory;
            this.btnTruoc.Location = new System.Drawing.Point(180, 29);
            this.btnTruoc.Name = "btnTruoc";
            this.btnTruoc.Size = new System.Drawing.Size(111, 44);
            this.btnTruoc.TabIndex = 32;
            this.btnTruoc.Text = "<";
            this.btnTruoc.UseVisualStyleBackColor = false;
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblTongTin);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtHienHanh);
            this.groupBox3.Controls.Add(this.btnKe);
            this.groupBox3.Controls.Add(this.btnDau);
            this.groupBox3.Controls.Add(this.btnCuoi);
            this.groupBox3.Controls.Add(this.btnTruoc);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(177, 708);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 125);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.Location = new System.Drawing.Point(1518, 21);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(170, 57);
            this.btnLamMoi.TabIndex = 49;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnKoLoc);
            this.groupBox2.Controls.Add(this.btnLoc);
            this.groupBox2.Controls.Add(this.txt_timTenNV);
            this.groupBox2.Controls.Add(this.radTenNV);
            this.groupBox2.Controls.Add(this.radMaNV);
            this.groupBox2.Controls.Add(this.txt_timMaNV);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(128, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(827, 115);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnKoLoc
            // 
            this.btnKoLoc.BackColor = System.Drawing.SystemColors.Control;
            this.btnKoLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKoLoc.Location = new System.Drawing.Point(661, 23);
            this.btnKoLoc.Name = "btnKoLoc";
            this.btnKoLoc.Size = new System.Drawing.Size(147, 43);
            this.btnKoLoc.TabIndex = 46;
            this.btnKoLoc.Text = "Không Lọc";
            this.btnKoLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKoLoc.UseVisualStyleBackColor = false;
            this.btnKoLoc.Click += new System.EventHandler(this.btnKoLoc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Image = ((System.Drawing.Image)(resources.GetObject("btnLoc.Image")));
            this.btnLoc.Location = new System.Drawing.Point(509, 23);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(147, 43);
            this.btnLoc.TabIndex = 45;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // txt_timTenNV
            // 
            this.txt_timTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timTenNV.Location = new System.Drawing.Point(237, 63);
            this.txt_timTenNV.Name = "txt_timTenNV";
            this.txt_timTenNV.Size = new System.Drawing.Size(234, 30);
            this.txt_timTenNV.TabIndex = 17;
            // 
            // radTenNV
            // 
            this.radTenNV.AutoSize = true;
            this.radTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTenNV.Location = new System.Drawing.Point(44, 64);
            this.radTenNV.Name = "radTenNV";
            this.radTenNV.Size = new System.Drawing.Size(178, 29);
            this.radTenNV.TabIndex = 16;
            this.radTenNV.TabStop = true;
            this.radTenNV.Text = "Tên nhân viên:";
            this.radTenNV.UseVisualStyleBackColor = true;
            // 
            // radMaNV
            // 
            this.radMaNV.AutoSize = true;
            this.radMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMaNV.Location = new System.Drawing.Point(44, 28);
            this.radMaNV.Name = "radMaNV";
            this.radMaNV.Size = new System.Drawing.Size(170, 29);
            this.radMaNV.TabIndex = 15;
            this.radMaNV.TabStop = true;
            this.radMaNV.Text = "Mã nhân viên:";
            this.radMaNV.UseVisualStyleBackColor = true;
            // 
            // txt_timMaNV
            // 
            this.txt_timMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timMaNV.Location = new System.Drawing.Point(237, 25);
            this.txt_timMaNV.Name = "txt_timMaNV";
            this.txt_timMaNV.Size = new System.Drawing.Size(234, 30);
            this.txt_timMaNV.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkGreen;
            this.label17.Location = new System.Drawing.Point(544, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(411, 42);
            this.label17.TabIndex = 55;
            this.label17.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 44;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 25);
            this.label7.TabIndex = 46;
            this.label7.Text = "Tên nhân viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(202, 38);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(293, 30);
            this.txtMaNV.TabIndex = 47;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(202, 112);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(293, 30);
            this.txtTenNV.TabIndex = 49;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 25);
            this.label14.TabIndex = 56;
            this.label14.Text = "Điện thoại:";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(15, 530);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(123, 57);
            this.btnThem.TabIndex = 60;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(200, 182);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(293, 30);
            this.txtDienThoai.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 25);
            this.label11.TabIndex = 65;
            this.label11.Text = "Ngày vào làm:";
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(144, 530);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 57);
            this.btnSua.TabIndex = 61;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Transparent;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(270, 530);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(122, 57);
            this.btnXoa.TabIndex = 62;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Email:";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(412, 530);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(111, 57);
            this.btnThoat.TabIndex = 63;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(205, 345);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(291, 30);
            this.txtEmail.TabIndex = 67;
            // 
            // dtpNgayVaoLam
            // 
            this.dtpNgayVaoLam.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayVaoLam.Location = new System.Drawing.Point(207, 287);
            this.dtpNgayVaoLam.Name = "dtpNgayVaoLam";
            this.dtpNgayVaoLam.Size = new System.Drawing.Size(291, 30);
            this.dtpNgayVaoLam.TabIndex = 69;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.txtChucVu);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.dtpNgayVaoLam);
            this.groupBox4.Controls.Add(this.txtEmail);
            this.groupBox4.Controls.Add(this.btnThoat);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.btnXoa);
            this.groupBox4.Controls.Add(this.btnSua);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtDienThoai);
            this.groupBox4.Controls.Add(this.btnThem);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtTenNV);
            this.groupBox4.Controls.Add(this.txtMaNV);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox4.Location = new System.Drawing.Point(1190, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(529, 667);
            this.groupBox4.TabIndex = 52;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin nhân viên";
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(202, 232);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(293, 30);
            this.txtChucVu.TabIndex = 71;
            this.txtChucVu.Visible = true; // Hide unless ChucVu is in model
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 70;
            this.label5.Text = "Chức Vụ";
            this.label5.Visible = true;
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
            this.Load += new System.EventHandler(this.FormNhanVien_Load);
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
