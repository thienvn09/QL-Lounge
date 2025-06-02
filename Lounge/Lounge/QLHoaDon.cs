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
using Lounge.Model; // Đảm bảo Model.HoaDon đã được cập nhật

namespace Lounge
{
    public partial class QLHoaDon : Form
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private List<HoaDon> dsHoaDon = new List<HoaDon>();
        private int currentIndex = -1;

        public QLHoaDon()
        {
            InitializeComponent();
        }

        private void FormQLHoaDon_Load(object sender, EventArgs e)
        {
            InitializeComboBoxes();
            ConfigureDataGridView();
            LoadData(); // Tải dữ liệu ban đầu
            WireUpButtonEvents(); // Gán sự kiện sau khi controls đã sẵn sàng
        }

        private void WireUpButtonEvents()
        {
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            btnThoat.Click += btnThoat_Click;
            btnLoc.Click += btnLoc_Click;
            btnKoLoc.Click += btnKoLoc_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnDau.Click += btnDau_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnKe.Click += btnKe_Click;
            btnCuoi.Click += btnCuoi_Click;

            // Kích hoạt các RadioButton để khi chọn, TextBox tương ứng được focus (tùy chọn)
            radMaHoaDon.CheckedChanged += (s, ev) => { if (radMaHoaDon.Checked) txtTimMaHoaDon.Focus(); };
            radTenKhachHang.CheckedChanged += (s, ev) => { if (radTenKhachHang.Checked) txtTimTenKhachHang.Focus(); };
            radTrangThai.CheckedChanged += (s, ev) => { if (radTrangThai.Checked) cboTimTrangThai.Focus(); };
            radNgayDat.CheckedChanged += (s, ev) => { if (radNgayDat.Checked) dtpTimNgayDat.Focus(); };
        }

        private void InitializeComboBoxes()
        {
            cboTimTrangThai.Items.Clear();
            cboTimTrangThai.Items.Add("Tất cả");
            cboTimTrangThai.Items.Add("Chưa thanh toán"); // Phải khớp với giá trị trong CSDL
            cboTimTrangThai.Items.Add("Đã thanh toán");   // Phải khớp với giá trị trong CSDL
            // cboTimTrangThai.Items.Add("Đã hủy"); // Thêm nếu có trạng thái này
            cboTimTrangThai.SelectedIndex = 0; // Mặc định "Tất cả"
        }

        private void ConfigureDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHoaDon", HeaderText = "Mã HĐ", Width = 70 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayDat", HeaderText = "Ngày Đặt", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKhachHang", HeaderText = "Khách Hàng", Width = 180 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoBan", HeaderText = "Bàn", Width = 70 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhToan", HeaderText = "Tổng Cộng", Width = 110, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái", Width = 120 });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNhanVienLap", HeaderText = "NV Lập Bill", Width = 150, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); // Cho cột này fill
            // dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNguoiTao", HeaderText = "Người Tạo", Width = 150 }); // Nếu muốn hiển thị thêm

            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
            dgvHoaDon.CellDoubleClick += DgvHoaDon_CellDoubleClick; // Thêm sự kiện double click
        }

        private void LoadData()
        {
            try
            {
                dsHoaDon = hoaDonDAL.GetAllHoaDon();
                dgvHoaDon.DataSource = null;
                if (dsHoaDon != null)
                {
                    dgvHoaDon.DataSource = dsHoaDon;
                    lblTongSo.Text = dsHoaDon.Count.ToString();
                    currentIndex = dsHoaDon.Count > 0 ? 0 : -1;
                    txtHienHanh.Text = dsHoaDon.Count > 0 ? "1" : "0";
                }
                else
                {
                    dsHoaDon = new List<HoaDon>(); // Khởi tạo danh sách rỗng nếu DAL trả về null
                    lblTongSo.Text = "0";
                    currentIndex = -1;
                    txtHienHanh.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsHoaDon = new List<HoaDon>();
                lblTongSo.Text = "0";
                currentIndex = -1;
                txtHienHanh.Text = "0";
            }
            DisplayCurrentHoaDon();
            UpdateNavigationButtons();
        }

        private void DgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null) // Sử dụng CurrentRow để tránh lỗi khi DataSource là null ban đầu
            {
                currentIndex = dgvHoaDon.CurrentRow.Index;
                DisplayCurrentHoaDon();
                UpdateNavigationButtons();
            }
        }
        private void DgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Khi double click vào một dòng, cũng gọi xem chi tiết
            if (e.RowIndex >= 0) // Đảm bảo không phải double click vào header
            {
                btnXemChiTiet_Click(sender, e);
            }
        }

        private void DisplayCurrentHoaDon()
        {
            if (currentIndex >= 0 && currentIndex < dsHoaDon.Count)
            {
                var hd = dsHoaDon[currentIndex];
                txtMaHoaDon.Text = hd.MaHoaDon.ToString();
                txtTenKhachHang.Text = hd.TenKhachHang;
                txtTenNhanVien.Text = hd.TenNhanVienLap; // Hiển thị tên NV lập bill
                txtSoBan.Text = hd.SoBan;
                dtpNgayDat.Value = hd.NgayDat;
                txtTongTien.Text = hd.TongTien.ToString("N0");
                txtTienGiamGia.Text = hd.TienGiamGia.ToString("N0");
                txtTongThueVAT.Text = hd.TongThueVAT.ToString("N0");
                txtThanhToan.Text = hd.ThanhToan.ToString("N0");
                txtTrangThai.Text = hd.TrangThai;
                // Bạn có thể thêm một TextBox nữa để hiển thị TenNguoiTao nếu cần
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
            txtMaHoaDon.Text = "";
            txtTenKhachHang.Text = "";
            txtTenNhanVien.Text = "";
            txtSoBan.Text = "";
            dtpNgayDat.Value = DateTime.Now; // Hoặc một giá trị mặc định khác
            txtTongTien.Text = "0";
            txtTienGiamGia.Text = "0";
            txtTongThueVAT.Text = "0";
            txtThanhToan.Text = "0";
            txtTrangThai.Text = "";
        }

        private void UpdateNavigationButtons()
        {
            bool hasData = dsHoaDon.Count > 0;
            btnDau.Enabled = hasData && currentIndex > 0;
            btnTruoc.Enabled = hasData && currentIndex > 0;
            btnKe.Enabled = hasData && currentIndex < dsHoaDon.Count - 1;
            btnCuoi.Enabled = hasData && currentIndex < dsHoaDon.Count - 1;
            btnXemChiTiet.Enabled = hasData; // Chỉ bật khi có dữ liệu
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (currentIndex >= 0 && currentIndex < dsHoaDon.Count)
            {
                int maHoaDonXem = dsHoaDon[currentIndex].MaHoaDon;
                // TODO: Mở form FormChiTietHoaDon (bạn cần tạo form này)
                // FormChiTietHoaDon frmChiTiet = new FormChiTietHoaDon(maHoaDonXem);
                // frmChiTiet.ShowDialog();
                MessageBox.Show($"Sẽ hiển thị chi tiết cho hóa đơn Mã HĐ: {maHoaDonXem}\n" +
                                $"Khách hàng: {dsHoaDon[currentIndex].TenKhachHang}\n" +
                                $"Tổng thanh toán: {dsHoaDon[currentIndex].ThanhToan:N0}đ",
                                "Thông Tin Hóa Đơn (Chi tiết)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ danh sách.", "Chưa chọn hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTimMaHoaDon.Text = "";
            txtTimTenKhachHang.Text = "";
            cboTimTrangThai.SelectedIndex = 0;
            dtpTimNgayDat.Value = DateTime.Now;
            radMaHoaDon.Checked = true; // Mặc định tìm theo mã HĐ
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            List<HoaDon> allData;
            try
            {
                allData = hoaDonDAL.GetAllHoaDon(); // Luôn lấy dữ liệu gốc từ DAL để lọc
                if (allData == null) allData = new List<HoaDon>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu để lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<HoaDon> filteredData = allData; // Bắt đầu với toàn bộ dữ liệu

            if (radMaHoaDon.Checked && !string.IsNullOrWhiteSpace(txtTimMaHoaDon.Text))
            {
                if (int.TryParse(txtTimMaHoaDon.Text, out int maHD))
                {
                    filteredData = filteredData.Where(hd => hd.MaHoaDon == maHD);
                }
                else
                {
                    MessageBox.Show("Mã hóa đơn tìm kiếm không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTimMaHoaDon.Focus();
                    return;
                }
            }
            else if (radTenKhachHang.Checked && !string.IsNullOrWhiteSpace(txtTimTenKhachHang.Text))
            {
                string searchTerm = txtTimTenKhachHang.Text.Trim().ToLower();
                filteredData = filteredData.Where(hd => hd.TenKhachHang != null && hd.TenKhachHang.ToLower().Contains(searchTerm));
            }
            else if (radTrangThai.Checked && cboTimTrangThai.SelectedItem != null && cboTimTrangThai.SelectedIndex != 0) // Bỏ qua mục "Tất cả"
            {
                string trangThaiFilter = cboTimTrangThai.SelectedItem.ToString();
                filteredData = filteredData.Where(hd => hd.TrangThai != null && hd.TrangThai.Equals(trangThaiFilter, StringComparison.OrdinalIgnoreCase));
            }
            else if (radNgayDat.Checked)
            {
                DateTime ngayDatFilter = dtpTimNgayDat.Value.Date; // Chỉ so sánh phần ngày
                filteredData = filteredData.Where(hd => hd.NgayDat.Date == ngayDatFilter);
            }
            // Nếu không có radio button nào được chọn hoặc không có giá trị tìm kiếm, filteredData sẽ vẫn là allData

            dsHoaDon = filteredData.ToList(); // Cập nhật danh sách hiện tại bằng kết quả lọc
            dgvHoaDon.DataSource = null;
            dgvHoaDon.DataSource = dsHoaDon;

            lblTongSo.Text = dsHoaDon.Count.ToString();
            currentIndex = dsHoaDon.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsHoaDon.Count > 0 ? "1" : "0";
            DisplayCurrentHoaDon();
            UpdateNavigationButtons();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            // Reset các control tìm kiếm
            txtTimMaHoaDon.Text = "";
            txtTimTenKhachHang.Text = "";
            cboTimTrangThai.SelectedIndex = 0; // Về "Tất cả"
            dtpTimNgayDat.Value = DateTime.Now;
            radMaHoaDon.Checked = true; // Hoặc false tùy bạn muốn
            radTenKhachHang.Checked = false;
            radTrangThai.Checked = false;
            radNgayDat.Checked = false;

            LoadData(); // Tải lại toàn bộ dữ liệu
        }

        // Các hàm điều hướng
        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsHoaDon.Any()) // Any() an toàn hơn Count > 0 khi list có thể null (mặc dù đã khởi tạo)
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
            if (currentIndex < dsHoaDon.Count - 1)
            {
                currentIndex++;
                SelectAndDisplayCurrent();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsHoaDon.Any())
            {
                currentIndex = dsHoaDon.Count - 1;
                SelectAndDisplayCurrent();
            }
        }

        private void SelectAndDisplayCurrent()
        {
            DisplayCurrentHoaDon();
            if (currentIndex >= 0 && currentIndex < dgvHoaDon.Rows.Count)
            {
                dgvHoaDon.ClearSelection(); // Bỏ chọn tất cả các dòng trước
                dgvHoaDon.Rows[currentIndex].Selected = true; // Chọn dòng hiện tại
                dgvHoaDon.FirstDisplayedScrollingRowIndex = currentIndex; // Cuộn đến dòng được chọn
            }
            UpdateNavigationButtons();
        }
    }
}
