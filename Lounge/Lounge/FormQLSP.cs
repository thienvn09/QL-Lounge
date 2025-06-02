using Lounge.DAL;
using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormQLSP : Form
    {
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private DanhMucSPDAL danhMucDAL = new DanhMucSPDAL();
        private NhaCungCapDAL nhaCungCapDAL = new NhaCungCapDAL();
        private List<SANPHAM> dsSanPham = new List<SANPHAM>();
        private List<DanhMucSanPham> dsDanhMuc = new List<DanhMucSanPham>();
        private List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();
        private int currentIndex = -1;

        public FormQLSP()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadData();
            ConfigureDataGridView();
            UpdateNavigation();
            // Wire up button events
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            btnLoc.Click += btnLoc_Click;
            btnKoLoc.Click += btnKoLoc_Click;
            btnDau.Click += btnDau_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnKe.Click += btnKe_Click;
            btnCuoi.Click += btnCuoi_Click;
        }

        private void InitializeComboBoxes()
        {
            dsDanhMuc = danhMucDAL.GetAllDanhMucSP();
            cboxDanhMuc.DataSource = dsDanhMuc;
            cboxDanhMuc.DisplayMember = "TenDanhMuc";
            cboxDanhMuc.ValueMember = "MaDanhMuc";
            cboxDanhMuc.SelectedIndex = dsDanhMuc.Count > 0 ? 0 : -1;

            dsNhaCungCap = nhaCungCapDAL.GetAllNhaCungCap();
            cboxNhaCungCap.DataSource = dsNhaCungCap;
            cboxNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboxNhaCungCap.ValueMember = "MaNhaCungCap";
            cboxNhaCungCap.SelectedIndex = dsNhaCungCap.Count > 0 ? 0 : -1;
        }

        private void LoadData()
        {
            dsSanPham = sanPhamDAL.GetAllSP();
            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = dsSanPham;
            lblTongTin.Text = dsSanPham.Count.ToString();
            txtHienHanh.Text = dsSanPham.Count > 0 ? "1" : "0";
            currentIndex = dsSanPham.Count > 0 ? 0 : -1;
            DisplayCurrentProduct();
            UpdateNavigation();
        }

        private void ConfigureDataGridView()
        {
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.Columns.Clear();
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSanPham", HeaderText = "Mã SP" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Tên Sản Phẩm" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDanhMuc", HeaderText = "Mã Danh Mục" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNhaCungCap", HeaderText = "Mã NCC" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Gia", HeaderText = "Giá" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MoTa", HeaderText = "Mô Tả" });
            dgvSanPham.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoLuongTonKho", HeaderText = "SL Tồn Kho" });
            dgvSanPham.SelectionChanged += DgvSanPham_SelectionChanged;
        }

        private void DgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                currentIndex = dgvSanPham.SelectedRows[0].Index;
                DisplayCurrentProduct();
                UpdateNavigation();
            }
        }

        private void DisplayCurrentProduct()
        {
            if (currentIndex >= 0 && currentIndex < dsSanPham.Count)
            {
                var sp = dsSanPham[currentIndex];
                txtMaSP.Text = sp.MaSanPham.ToString();
                txtTenSP.Text = sp.TenSanPham;
                cboxDanhMuc.SelectedValue = sp.MaDanhMuc;
                cboxNhaCungCap.SelectedValue = sp.MaNhaCungCap;
                txtGia.Text = sp.Gia.ToString("0.00");
                txtMoTa.Text = sp.MoTa ?? "";
                txtSoLuongTonKho.Text = sp.SoLuongTonKho.ToString();
                txtHienHanh.Text = (currentIndex + 1).ToString();
            }
            else
            {
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            cboxDanhMuc.SelectedIndex = dsDanhMuc.Count > 0 ? 0 : -1;
            cboxNhaCungCap.SelectedIndex = dsNhaCungCap.Count > 0 ? 0 : -1;
            txtGia.Text = "0.00";
            txtMoTa.Text = "";
            txtSoLuongTonKho.Text = "0";
        }

        private void UpdateNavigation()
        {
            btnDau.Enabled = dsSanPham.Count > 0 && currentIndex > 0;
            btnTruoc.Enabled = dsSanPham.Count > 0 && currentIndex > 0;
            btnKe.Enabled = dsSanPham.Count > 0 && currentIndex < dsSanPham.Count - 1;
            btnCuoi.Enabled = dsSanPham.Count > 0 && currentIndex < dsSanPham.Count - 1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
            radMaSP.Checked = false;
            radTenSP.Checked = false;
            txt_timMaSP.Text = "";
            txt_timTenSP.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return false;
            }
            if (cboxDanhMuc.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboxDanhMuc.Focus();
                return false;
            }
            if (cboxNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboxNhaCungCap.Focus();
                return false;
            }
            if (!decimal.TryParse(txtGia.Text, out decimal gia) || gia < 0)
            {
                MessageBox.Show("Giá phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return false;
            }
            if (!int.TryParse(txtSoLuongTonKho.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuongTonKho.Focus();
                return false;
            }
            return true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dsSanPham = sanPhamDAL.GetAllSP();
            if (radMaSP.Checked && !string.IsNullOrWhiteSpace(txt_timMaSP.Text) && int.TryParse(txt_timMaSP.Text, out int maSP))
            {
                dsSanPham = dsSanPham.Where(sp => sp.MaSanPham == maSP).ToList();
            }
            else if (radTenSP.Checked && !string.IsNullOrWhiteSpace(txt_timTenSP.Text))
            {
                dsSanPham = dsSanPham.Where(sp => sp.TenSanPham.IndexOf(txt_timTenSP.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            dgvSanPham.DataSource = null;
            dgvSanPham.DataSource = dsSanPham;
            lblTongTin.Text = dsSanPham.Count.ToString();
            currentIndex = dsSanPham.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsSanPham.Count > 0 ? "1" : "0";
            DisplayCurrentProduct();
            UpdateNavigation();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            LoadData();
            radMaSP.Checked = false;
            radTenSP.Checked = false;
            txt_timMaSP.Text = "";
            txt_timTenSP.Text = "";
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsSanPham.Count > 0)
            {
                currentIndex = 0;
                DisplayCurrentProduct();
                dgvSanPham.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsSanPham.Count > 0)
            {
                currentIndex = dsSanPham.Count - 1;
                DisplayCurrentProduct();
                dgvSanPham.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentProduct();
                dgvSanPham.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsSanPham.Count - 1)
            {
                currentIndex++;
                DisplayCurrentProduct();
                dgvSanPham.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var sp = new SANPHAM
                {
                    TenSanPham = txtTenSP.Text,
                    MaDanhMuc = (int)cboxDanhMuc.SelectedValue,
                    MaNhaCungCap = (int)cboxNhaCungCap.SelectedValue,
                    Gia = decimal.Parse(txtGia.Text),
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text,
                    SoLuongTonKho = int.Parse(txtSoLuongTonKho.Text)
                };

                if (sanPhamDAL.AddSP(sp))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại! Kiểm tra danh mục hoặc nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput() && int.TryParse(txtMaSP.Text, out int maSanPham))
            {
                var sp = new SANPHAM
                {
                    MaSanPham = maSanPham,
                    TenSanPham = txtTenSP.Text,
                    MaDanhMuc = (int)cboxDanhMuc.SelectedValue,
                    MaNhaCungCap = (int)cboxNhaCungCap.SelectedValue,
                    Gia = decimal.Parse(txtGia.Text),
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text,
                    SoLuongTonKho = int.Parse(txtSoLuongTonKho.Text)
                };

                if (sanPhamDAL.UpdateSP(sp))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại! Kiểm tra danh mục hoặc nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaSP.Text, out int maSanPham))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (sanPhamDAL.DeleteSP(maSanPham))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoc_Click_1(object sender, EventArgs e)
        {

        }

        private void FormQLSP_Load(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}