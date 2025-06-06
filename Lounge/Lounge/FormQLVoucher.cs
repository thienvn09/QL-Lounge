using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class FormQLVoucher : Form
    {
        private VoucherDAL voucherDAL = new VoucherDAL();
        private KhachHangDAL khachHangDAL = new KhachHangDAL(); // Để load cboKhachHang
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();     // Để load cboSanPham
        private List<Voucher> dsVoucher = new List<Voucher>();
        private int currentIndex = -1;

        public FormQLVoucher()
        {
            InitializeComponent();
        }

        private void FormQLVoucher_Load(object sender, EventArgs e)
        {
            InitializeComboBoxes();
            ConfigureDataGridView();
            LoadData();
            WireUpButtonEvents();
        }

        private void WireUpButtonEvents()
        {
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            btnLoc.Click += btnLoc_Click;
            btnKoLoc.Click += btnKoLoc_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnDau.Click += btnDau_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnKe.Click += btnKe_Click;
            btnCuoi.Click += btnCuoi_Click;

            radTimMaVoucher.CheckedChanged += (s, ev) => { if (radTimMaVoucher.Checked) txtTimMaVoucher.Focus(); };
            radTimKhachHang.CheckedChanged += (s, ev) => { if (radTimKhachHang.Checked) txtTimKhachHang.Focus(); };
            radTimTrangThai.CheckedChanged += (s, ev) => { if (radTimTrangThai.Checked) cboTimTrangThai.Focus(); };
        }

        private void InitializeComboBoxes()
        {
            // ComboBox cho Trạng Thái (trong grpThongTin)
            cboTrangThai.Items.Clear();
            cboTrangThai.Items.Add("Chưa sử dụng");
            cboTrangThai.Items.Add("Đã sử dụng");
            if (cboTrangThai.Items.Count > 0)
                cboTrangThai.SelectedIndex = 0;

            // ComboBox cho Trạng Thái (trong grpTimKiem)
            cboTimTrangThai.Items.Clear();
            cboTimTrangThai.Items.Add("Tất cả");
            cboTimTrangThai.Items.Add("Chưa sử dụng");
            cboTimTrangThai.Items.Add("Đã sử dụng");
            cboTimTrangThai.SelectedIndex = 0;

            // Load ComboBox Khách Hàng
            try
            {
                List<KhachHan> dsKH = khachHangDAL.GetAllKH(); // Giả định bạn có hàm này trong KhachHangDAL
                // Thêm một lựa chọn "Không chọn" hoặc "Áp dụng chung"
                dsKH.Insert(0, new KhachHan { MaKhachHang = 0, HoTen = "(Áp dụng chung)" }); // ID 0 hoặc -1 để biểu thị không chọn

                cboKhachHang.DataSource = dsKH;
                cboKhachHang.DisplayMember = "HoTen";
                cboKhachHang.ValueMember = "MaKhachHang";
                cboKhachHang.SelectedIndex = 0; // Mặc định là "Áp dụng chung"
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Load ComboBox Sản Phẩm
            try
            {
                // Giả định bạn có hàm GetAllSP() trả về List<SANPHAM> trong SanPhamDAL
                // Hoặc một hàm tương tự chỉ lấy MaSanPham và TenSanPham
                List<SANPHAM> dsSP = sanPhamDAL.GetAllSP();
                // Thêm một lựa chọn "Không chọn" hoặc "Toàn bộ hóa đơn"
                dsSP.Insert(0, new SANPHAM { MaSanPham = 0, TenSanPham = "(Toàn bộ hóa đơn)" });

                cboSanPham.DataSource = dsSP;
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";
                cboSanPham.SelectedIndex = 0; // Mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvVoucher.AutoGenerateColumns = false;
            dgvVoucher.Columns.Clear();

            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaVoucher", HeaderText = "Mã Vch", Width = 70 });
            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKhachHang", HeaderText = "Khách Hàng", Width = 180 });
            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenSanPham", HeaderText = "Sản Phẩm", Width = 180 });
            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GiaTri", HeaderText = "Giá Trị", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayHetHan", HeaderText = "Ngày Hết Hạn", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvVoucher.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            dgvVoucher.SelectionChanged += DgvVoucher_SelectionChanged;
        }

        private void LoadData()
        {
            try
            {
                dsVoucher = voucherDAL.GetAllVouchers();
                dgvVoucher.DataSource = null;
                if (dsVoucher != null)
                {
                    dgvVoucher.DataSource = dsVoucher;
                    lblTongSo.Text = dsVoucher.Count.ToString();
                    currentIndex = dsVoucher.Count > 0 ? 0 : -1;
                    txtHienHanh.Text = dsVoucher.Count > 0 ? "1" : "0";
                }
                else
                {
                    dsVoucher = new List<Voucher>();
                    lblTongSo.Text = "0";
                    currentIndex = -1;
                    txtHienHanh.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsVoucher = new List<Voucher>();
                lblTongSo.Text = "0";
                currentIndex = -1;
                txtHienHanh.Text = "0";
            }
            DisplayCurrentVoucher();
            UpdateNavigationButtons();
        }

        private void DgvVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow != null)
            {
                currentIndex = dgvVoucher.CurrentRow.Index;
                DisplayCurrentVoucher();
                UpdateNavigationButtons();
            }
        }

        private void DisplayCurrentVoucher()
        {
            if (currentIndex >= 0 && currentIndex < dsVoucher.Count)
            {
                var v = dsVoucher[currentIndex];
                txtMaVoucher.Text = v.MaVoucher.ToString();

                cboKhachHang.SelectedValue = v.MaKhachHang.HasValue ? (object)v.MaKhachHang.Value : 0; // 0 là giá trị cho "(Áp dụng chung)"
                cboSanPham.SelectedValue = v.MaSanPham.HasValue ? (object)v.MaSanPham.Value : 0; // 0 là giá trị cho "(Toàn bộ hóa đơn)"

                txtGiaTri.Text = v.GiaTri.ToString("N0");

                if (v.NgayHetHan.HasValue)
                {
                    dtpNgayHetHan.Checked = true;
                    dtpNgayHetHan.Value = v.NgayHetHan.Value;
                }
                else
                {
                    dtpNgayHetHan.Checked = false; // Bỏ check nếu không có ngày hết hạn
                    // dtpNgayHetHan.Value = DateTime.Now; // Hoặc để trống
                }
                cboTrangThai.SelectedItem = v.TrangThai;
                txtHienHanh.Text = (currentIndex + 1).ToString();
            }
            else
            {
                ClearInputFields();
                txtHienHanh.Text = "0";
            }
        }

        private void ClearInputFields()
        {
            txtMaVoucher.Text = ""; // Mã sẽ tự tăng
            if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0; // Mặc định "(Áp dụng chung)"
            if (cboSanPham.Items.Count > 0) cboSanPham.SelectedIndex = 0;   // Mặc định "(Toàn bộ hóa đơn)"
            txtGiaTri.Text = "0";
            dtpNgayHetHan.Value = DateTime.Now.AddMonths(1); // Mặc định hết hạn sau 1 tháng
            dtpNgayHetHan.Checked = true; // Mặc định có ngày hết hạn
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0; // Mặc định "Chưa sử dụng"
        }

        private void UpdateNavigationButtons()
        {
            bool hasData = dsVoucher.Count > 0;
            btnDau.Enabled = hasData && currentIndex > 0;
            btnTruoc.Enabled = hasData && currentIndex > 0;
            btnKe.Enabled = hasData && currentIndex < dsVoucher.Count - 1;
            btnCuoi.Enabled = hasData && currentIndex < dsVoucher.Count - 1;
        }

        private bool ValidateInput()
        {
            if (!decimal.TryParse(txtGiaTri.Text, out decimal giaTri) || giaTri <= 0)
            {
                MessageBox.Show("Giá trị voucher phải là một số dương.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaTri.Focus();
                return false;
            }
            if (cboTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái cho voucher.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTrangThai.Focus();
                return false;
            }
            // Ngày hết hạn có thể không bắt buộc nếu dtpNgayHetHan.Checked = false
            if (dtpNgayHetHan.Checked && dtpNgayHetHan.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày hết hạn không được nhỏ hơn ngày hiện tại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayHetHan.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Voucher v = new Voucher
                {
                    MaKhachHang = (cboKhachHang.SelectedValue != null && (int)cboKhachHang.SelectedValue != 0) ? (int?)cboKhachHang.SelectedValue : null,
                    MaSanPham = (cboSanPham.SelectedValue != null && (int)cboSanPham.SelectedValue != 0) ? (int?)cboSanPham.SelectedValue : null,
                    GiaTri = float.Parse(txtGiaTri.Text),
                    NgayHetHan = dtpNgayHetHan.Checked ? (DateTime?)dtpNgayHetHan.Value.Date : null,
                    TrangThai = cboTrangThai.SelectedItem.ToString()
                };

                try
                {
                    if (voucherDAL.AddVoucher(v))
                    {
                        MessageBox.Show("Thêm voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Thêm voucher thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaVoucher.Text))
            {
                MessageBox.Show("Vui lòng chọn một voucher để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput())
            {
                Voucher v = new Voucher
                {
                    MaVoucher = int.Parse(txtMaVoucher.Text),
                    MaKhachHang = (cboKhachHang.SelectedValue != null && (int)cboKhachHang.SelectedValue != 0) ? (int?)cboKhachHang.SelectedValue : null,
                    MaSanPham = (cboSanPham.SelectedValue != null && (int)cboSanPham.SelectedValue != 0) ? (int?)cboSanPham.SelectedValue : null,
                    GiaTri = float.Parse(txtGiaTri.Text),
                    NgayHetHan = dtpNgayHetHan.Checked ? (DateTime?)dtpNgayHetHan.Value.Date : null,
                    TrangThai = cboTrangThai.SelectedItem.ToString()
                };

                try
                {
                    if (voucherDAL.UpdateVoucher(v))
                    {
                        MessageBox.Show("Cập nhật voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật voucher thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaVoucher.Text))
            {
                MessageBox.Show("Vui lòng chọn một voucher để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa voucher mã '{txtMaVoucher.Text}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (voucherDAL.DeleteVoucher(int.Parse(txtMaVoucher.Text)))
                    {
                        MessageBox.Show("Xóa voucher thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa voucher thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTimMaVoucher.Text = "";
            txtTimKhachHang.Text = "";
            if (cboTimTrangThai.Items.Count > 0) cboTimTrangThai.SelectedIndex = 0;
            radTimMaVoucher.Checked = true;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            List<Voucher> allData;
            try
            {
                allData = voucherDAL.GetAllVouchers();
                if (allData == null) allData = new List<Voucher>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu để lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<Voucher> filteredData = allData;

            if (radTimMaVoucher.Checked && !string.IsNullOrWhiteSpace(txtTimMaVoucher.Text))
            {
                if (int.TryParse(txtTimMaVoucher.Text, out int maVch))
                {
                    filteredData = filteredData.Where(v => v.MaVoucher == maVch);
                }
                else
                {
                    MessageBox.Show("Mã voucher tìm kiếm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (radTimKhachHang.Checked && !string.IsNullOrWhiteSpace(txtTimKhachHang.Text))
            {
                string searchTerm = txtTimKhachHang.Text.Trim().ToLower();
                filteredData = filteredData.Where(v => v.TenKhachHang != null && v.TenKhachHang.ToLower().Contains(searchTerm));
            }
            else if (radTimTrangThai.Checked && cboTimTrangThai.SelectedItem != null && cboTimTrangThai.SelectedIndex != 0) // Bỏ qua "Tất cả"
            {
                string trangThaiFilter = cboTimTrangThai.SelectedItem.ToString();
                filteredData = filteredData.Where(v => v.TrangThai != null && v.TrangThai.Equals(trangThaiFilter, StringComparison.OrdinalIgnoreCase));
            }

            dsVoucher = filteredData.ToList();
            dgvVoucher.DataSource = null;
            dgvVoucher.DataSource = dsVoucher;

            lblTongSo.Text = dsVoucher.Count.ToString();
            currentIndex = dsVoucher.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsVoucher.Count > 0 ? "1" : "0";
            DisplayCurrentVoucher();
            UpdateNavigationButtons();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            txtTimMaVoucher.Text = "";
            txtTimKhachHang.Text = "";
            if (cboTimTrangThai.Items.Count > 0) cboTimTrangThai.SelectedIndex = 0;
            radTimMaVoucher.Checked = true;
            LoadData();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsVoucher.Any())
            {
                currentIndex = 0;
                SelectAndDisplayCurrent();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                SelectAndDisplayCurrent();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsVoucher.Count - 1)
            {
                currentIndex++;
                SelectAndDisplayCurrent();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsVoucher.Any())
            {
                currentIndex = dsVoucher.Count - 1;
                SelectAndDisplayCurrent();
            }
        }

        private void SelectAndDisplayCurrent()
        {
            DisplayCurrentVoucher();
            if (currentIndex >= 0 && currentIndex < dgvVoucher.Rows.Count)
            {
                dgvVoucher.ClearSelection();
                dgvVoucher.Rows[currentIndex].Selected = true;
                dgvVoucher.FirstDisplayedScrollingRowIndex = currentIndex;
            }
            UpdateNavigationButtons();
        }
    }
}
