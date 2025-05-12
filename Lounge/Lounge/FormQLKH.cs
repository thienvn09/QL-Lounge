using Lounge.DAL;
using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormQLKH : Form
    {
        private KhachHangDAL khachHangDAL = new KhachHangDAL();
        private List<KhachHan> dsKhachHang = new List<KhachHan>();
        private int currentIndex = -1;

        public FormQLKH()
        {
            InitializeComponent();
            InitializeComboBox();
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

        private void InitializeComboBox()
        {
            cboxThanhVien.Items.Clear();
            cboxThanhVien.Items.Add("Khách Vãng Lai");
            cboxThanhVien.Items.Add("Khách VIP");
            cboxThanhVien.SelectedIndex = 0; // Default to "Khách Vãng Lai"
        }

        private void LoadData()
        {
            dsKhachHang = khachHangDAL.GetAllKH();
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = dsKhachHang;
            lblTongTin.Text = dsKhachHang.Count.ToString();
            txtHienHanh.Text = dsKhachHang.Count > 0 ? "1" : "0";
            currentIndex = dsKhachHang.Count > 0 ? 0 : -1;
            DisplayCurrentCustomer();
            UpdateNavigation();
        }

        private void ConfigureDataGridView()
        {
            dgvKhachHang.AutoGenerateColumns = false;
            dgvKhachHang.Columns.Clear();
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhachHang", HeaderText = "Mã KH" });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ Tên" });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SDT_KH", HeaderText = "Điện Thoại" });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiKH", HeaderText = "Loại KH" });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgaySuDung", HeaderText = "Ngày Sử Dụng" });
            dgvKhachHang.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TiLeGiamGia", HeaderText = "Tỉ Lệ Giảm Giá" });
            dgvKhachHang.SelectionChanged += DgvKhachHang_SelectionChanged;
        }

        private void DgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                currentIndex = dgvKhachHang.SelectedRows[0].Index;
                DisplayCurrentCustomer();
                UpdateNavigation();
            }
        }

        private void DisplayCurrentCustomer()
        {
            if (currentIndex >= 0 && currentIndex < dsKhachHang.Count)
            {
                var kh = dsKhachHang[currentIndex];
                txtMaKH.Text = kh.MaKhachHang.ToString();
                txtTenKH.Text = kh.HoTen;
                txtDienThoai.Text = kh.SDT_KH;
                cboxThanhVien.SelectedItem = kh.LoaiKH;
                dtpNgaySinh.Value = kh.NgaySuDung;
                txtTiLeGiamGia.Text = kh.TiLeGiamGia.ToString("0.00");
                txtHienHanh.Text = (currentIndex + 1).ToString();
            }
            else
            {
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDienThoai.Text = "";
            cboxThanhVien.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            txtTiLeGiamGia.Text = "0.00";
        }

        private void UpdateNavigation()
        {
            btnDau.Enabled = dsKhachHang.Count > 0 && currentIndex > 0;
            btnTruoc.Enabled = dsKhachHang.Count > 0 && currentIndex > 0;
            btnKe.Enabled = dsKhachHang.Count > 0 && currentIndex < dsKhachHang.Count - 1;
            btnCuoi.Enabled = dsKhachHang.Count > 0 && currentIndex < dsKhachHang.Count - 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var kh = new KhachHan
                {
                    HoTen = txtTenKH.Text,
                    SDT_KH = txtDienThoai.Text,
                    LoaiKH = cboxThanhVien.SelectedItem.ToString(),
                    NgaySuDung = dtpNgaySinh.Value,
                    TiLeGiamGia = decimal.Parse(txtTiLeGiamGia.Text)
                };

                if (khachHangDAL.AddKH(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại! Số điện thoại có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput() && int.TryParse(txtMaKH.Text, out int maKhachHang))
            {
                var kh = new KhachHan
                {
                    MaKhachHang = maKhachHang,
                    HoTen = txtTenKH.Text,
                    SDT_KH = txtDienThoai.Text,
                    LoaiKH = cboxThanhVien.SelectedItem.ToString(),
                    NgaySuDung = dtpNgaySinh.Value,
                    TiLeGiamGia = decimal.Parse(txtTiLeGiamGia.Text)
                };

                if (khachHangDAL.UpdateKH(kh))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại! Số điện thoại có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaKH.Text, out int maKhachHang))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (khachHangDAL.DeleteKH(maKhachHang))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
            radMaKH.Checked = false;
            radTenKH.Checked = false;
            txt_timMaKH.Text = "";
            txt_timTenKH.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKH.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return false;
            }
            if (cboxThanhVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboxThanhVien.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTiLeGiamGia.Text, out decimal tiLeGiamGia) || tiLeGiamGia < 0 || tiLeGiamGia > 100)
            {
                MessageBox.Show("Tỉ lệ giảm giá phải là số từ 0.00 đến 100.00!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiLeGiamGia.Focus();
                return false;
            }
            return true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dsKhachHang = khachHangDAL.GetAllKH();
            if (radMaKH.Checked && !string.IsNullOrWhiteSpace(txt_timMaKH.Text) && int.TryParse(txt_timMaKH.Text, out int maKH))
            {
                dsKhachHang = dsKhachHang.Where(kh => kh.MaKhachHang == maKH).ToList();
            }
            else if (radTenKH.Checked && !string.IsNullOrWhiteSpace(txt_timTenKH.Text))
            {
                if (radTenKH.Checked && !string.IsNullOrWhiteSpace(txt_timTenKH.Text))
                {
                    dsKhachHang = dsKhachHang.Where(kh => kh.HoTen.IndexOf(txt_timTenKH.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

            }

            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = dsKhachHang;
            lblTongTin.Text = dsKhachHang.Count.ToString();
            currentIndex = dsKhachHang.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsKhachHang.Count > 0 ? "1" : "0";
            DisplayCurrentCustomer();
            UpdateNavigation();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            LoadData();
            radMaKH.Checked = false;
            radTenKH.Checked = false;
            txt_timMaKH.Text = "";
            txt_timTenKH.Text = "";
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsKhachHang.Count > 0)
            {
                currentIndex = 0;
                DisplayCurrentCustomer();
                dgvKhachHang.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsKhachHang.Count > 0)
            {
                currentIndex = dsKhachHang.Count - 1;
                DisplayCurrentCustomer();
                dgvKhachHang.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentCustomer();
                dgvKhachHang.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsKhachHang.Count - 1)
            {
                currentIndex++;
                DisplayCurrentCustomer();
                dgvKhachHang.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }
    }
}