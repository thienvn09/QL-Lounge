using Lounge.DAL;
using Lounge.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class QLHoaDon : Form
    {
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private KhachHangDAL khachHangDAL = new KhachHangDAL();
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private BanDAL banDAL = new BanDAL();
        private List<HoaDon> dsHoaDon = new List<HoaDon>();
        private List<KhachHan> dsKhachHang = new List<KhachHan>();
        private List<NhanVien> dsNhanVien = new List<NhanVien>();
        private List<Ban> dsBan = new List<Ban>();
        private int currentIndex = -1;

        public QLHoaDon()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadData();
            ConfigureDataGridView();
            UpdateNavigation();

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
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void InitializeComboBoxes()
        {
            try
            {
                dsKhachHang = khachHangDAL.GetAllKH();
                if (dsKhachHang == null || dsKhachHang.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboxMaKhachHang.DataSource = null;
                    cboxMaKhachHang.SelectedIndex = -1;
                }
                else
                {
                    cboxMaKhachHang.DataSource = new List<KhachHan>(dsKhachHang);
                    cboxMaKhachHang.DisplayMember = "HoTen";
                    cboxMaKhachHang.ValueMember = "MaKhachHang";
                    cboxMaKhachHang.SelectedIndex = 0;
                }

                dsNhanVien = nhanVienDAL.GetAllNhanVien();
                if (dsNhanVien == null || dsNhanVien.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboxMaNhanVien.DataSource = null;
                    cboxMaNhanVien.SelectedIndex = -1;
                    cboxNguoiTao.DataSource = null;
                    cboxNguoiTao.SelectedIndex = -1;
                }
                else
                {
                    cboxMaNhanVien.DataSource = new List<NhanVien>(dsNhanVien);
                    cboxMaNhanVien.DisplayMember = "HoTen";
                    cboxMaNhanVien.ValueMember = "MaNhanvien";
                    cboxMaNhanVien.SelectedIndex = 0;

                    cboxNguoiTao.DataSource = new List<NhanVien>(dsNhanVien);
                    cboxNguoiTao.DisplayMember = "HoTen";
                    cboxNguoiTao.ValueMember = "MaNhanvien";
                    cboxNguoiTao.SelectedIndex = 0;
                }

                dsBan = banDAL.GetAllBan();
                if (dsBan == null || dsBan.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu bàn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboxMaBan.DataSource = null;
                    cboxMaBan.SelectedIndex = -1;
                }
                else
                {
                    cboxMaBan.DataSource = new List<Ban>(dsBan);
                    cboxMaBan.DisplayMember = "SoBan";
                    cboxMaBan.ValueMember = "MaBan";
                    cboxMaBan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo ComboBox: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                var dataTable = hoaDonDAL.GetAllHoaDon();
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    dsHoaDon = new List<HoaDon>();
                    MessageBox.Show("Không có dữ liệu hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Kiểm tra các cột cần thiết
                    string[] requiredColumns = { "MaHoaDon", "MaKhachHang", "MaNhanVien", "MaBan", "NgayDat", "TongTien", "TienGiamGia", "TongThueVAT", "ThanhToan", "TrangThai", "NguoiTao" };
                    foreach (var column in requiredColumns)
                    {
                        if (!dataTable.Columns.Contains(column))
                        {
                            throw new Exception($"Cột '{column}' không tồn tại trong dữ liệu trả về từ cơ sở dữ liệu.");
                        }
                    }

                    dsHoaDon = dataTable.AsEnumerable().Select(row => new HoaDon
                    {
                        MaHoaDon = row.Field<int>("MaHoaDon"),
                        MaKhachHang = row.Field<int>("MaKhachHang"),
                        MaNhanVien = row.Field<int?>("MaNhanVien") ?? -1,
                        MaBan = row.Field<int?>("MaBan") ?? -1,
                        NgayDat = row.Field<DateTime>("NgayDat"),
                        TongTien = (float)row.Field<decimal>("TongTien"),
                        TienGiamGia = (float)row.Field<decimal>("TienGiamGia"),
                        TongThueVAT = (float)row.Field<decimal>("TongThueVAT"),
                        ThanhToan = (float)row.Field<decimal>("ThanhToan"),
                        TrangThai = row.Field<string>("TrangThai"),
                        NguoiTao = row.Field<int?>("NguoiTao") ?? -1
                    }).ToList();
                }

                dgvHoaDon.DataSource = dsHoaDon;
                lblTongTin.Text = dsHoaDon.Count.ToString();
                txtHienHanh.Text = dsHoaDon.Count > 0 ? "1" : "0";
                currentIndex = dsHoaDon.Count > 0 ? 0 : -1;
                DisplayCurrentHoaDon();
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsHoaDon = new List<HoaDon>();
                dgvHoaDon.DataSource = dsHoaDon;
                lblTongTin.Text = "0";
                txtHienHanh.Text = "0";
                currentIndex = -1;
                DisplayCurrentHoaDon();
                UpdateNavigation();
            }
        }

        private void ConfigureDataGridView()
        {
            dgvHoaDon.AutoGenerateColumns = false;
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaHoaDon", HeaderText = "Mã HĐ" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhachHang", HeaderText = "Mã KH" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNhanVien", HeaderText = "Mã NV" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaBan", HeaderText = "Mã Bàn" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayDat", HeaderText = "Ngày Đặt", DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongTien", HeaderText = "Tổng Tiền", DefaultCellStyle = { Format = "N2" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TienGiamGia", HeaderText = "Tiền Giảm Giá", DefaultCellStyle = { Format = "N2" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongThueVAT", HeaderText = "Tổng Thuế VAT", DefaultCellStyle = { Format = "N2" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThanhToan", HeaderText = "Thành Tiền", DefaultCellStyle = { Format = "N2" } });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng Thái" });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NguoiTao", HeaderText = "Người Tạo" });
            dgvHoaDon.SelectionChanged += DgvHoaDon_SelectionChanged;
        }

        private void DgvHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                currentIndex = dgvHoaDon.SelectedRows[0].Index;
                DisplayCurrentHoaDon();
                UpdateNavigation();
            }
        }

        private void DisplayCurrentHoaDon()
        {
            try
            {
                if (currentIndex >= 0 && currentIndex < dsHoaDon.Count)
                {
                    var hd = dsHoaDon[currentIndex];
                    txtMaHD.Text = hd.MaHoaDon.ToString();
                    if (hd.MaKhachHang != -1 && dsKhachHang.Any(kh => kh.MaKhachHang == hd.MaKhachHang))
                        cboxMaKhachHang.SelectedValue = hd.MaKhachHang;
                    else
                        cboxMaKhachHang.SelectedIndex = -1;

                    if (hd.MaNhanVien != -1 && dsNhanVien.Any(nv => nv.MaNhanvien == hd.MaNhanVien))
                        cboxMaNhanVien.SelectedValue = hd.MaNhanVien;
                    else
                        cboxMaNhanVien.SelectedIndex = -1;

                    if (hd.MaBan != -1 && dsBan.Any(b => b.MaBan == hd.MaBan))
                        cboxMaBan.SelectedValue = hd.MaBan;
                    else
                        cboxMaBan.SelectedIndex = -1;

                    dtpNgayDat.Value = hd.NgayDat;
                    txtTongTien.Text = hd.TongTien.ToString("N2");
                    txtTienGiamGia.Text = hd.TienGiamGia.ToString("N2");
                    txtTongThueVAT.Text = hd.TongThueVAT.ToString("N2");
                    txtThanhToan.Text = hd.ThanhToan.ToString("N2");
                    cboxTrangThai.Text = hd.TrangThai ?? "Chưa thanh toán";

                    if (hd.NguoiTao != -1 && dsNhanVien.Any(nv => nv.MaNhanvien == hd.NguoiTao))
                        cboxNguoiTao.SelectedValue = hd.NguoiTao;
                    else
                        cboxNguoiTao.SelectedIndex = -1;

                    txtHienHanh.Text = (currentIndex + 1).ToString();
                }
                else
                {
                    ClearInputFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtMaHD.Text = "";
            cboxMaKhachHang.SelectedIndex = dsKhachHang.Count > 0 ? 0 : -1;
            cboxMaNhanVien.SelectedIndex = dsNhanVien.Count > 0 ? 0 : -1;
            cboxMaBan.SelectedIndex = dsBan.Count > 0 ? 0 : -1;
            dtpNgayDat.Value = DateTime.Now;
            txtTongTien.Text = "0.00";
            txtTienGiamGia.Text = "0.00";
            txtTongThueVAT.Text = "0.00";
            txtThanhToan.Text = "0.00";
            cboxTrangThai.Text = "Chưa thanh toán";
            cboxNguoiTao.SelectedIndex = dsNhanVien.Count > 0 ? 0 : -1;
        }

        private void UpdateNavigation()
        {
            btnDau.Enabled = dsHoaDon.Count > 0 && currentIndex > 0;
            btnTruoc.Enabled = dsHoaDon.Count > 0 && currentIndex > 0;
            btnKe.Enabled = dsHoaDon.Count > 0 && currentIndex < dsHoaDon.Count - 1;
            btnCuoi.Enabled = dsHoaDon.Count > 0 && currentIndex < dsHoaDon.Count - 1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
            radMaHD.Checked = false;
            radNgayDat.Checked = false;
            txt_timMaHD.Text = "";
            dtp_timNgayDat.Value = DateTime.Now;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (cboxMaKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboxMaKhachHang.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTongTien.Text, out decimal tongTien) || tongTien < 0)
            {
                MessageBox.Show("Tổng tiền phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongTien.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTienGiamGia.Text, out decimal tienGiamGia) || tienGiamGia < 0)
            {
                MessageBox.Show("Tiền giảm giá phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTienGiamGia.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTongThueVAT.Text, out decimal tongThueVAT) || tongThueVAT < 0)
            {
                MessageBox.Show("Tổng thuế VAT phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongThueVAT.Focus();
                return false;
            }
            if (!decimal.TryParse(txtThanhToan.Text, out decimal thanhToan) || thanhToan < 0)
            {
                MessageBox.Show("Thành tiền phải là số không âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThanhToan.Focus();
                return false;
            }
            if (!new[] { "Chưa thanh toán", "Đã thanh toán" }.Contains(cboxTrangThai.Text))
            {
                MessageBox.Show("Trạng thái phải là 'Chưa thanh toán' hoặc 'Đã thanh toán'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboxTrangThai.Focus();
                return false;
            }
            return true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                var dataTable = hoaDonDAL.GetAllHoaDon();
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    dsHoaDon = new List<HoaDon>();
                    MessageBox.Show("Không có dữ liệu hóa đơn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Kiểm tra các cột cần thiết
                    string[] requiredColumns = { "MaHoaDon", "MaKhachHang", "MaNhanVien", "MaBan", "NgayDat", "TongTien", "TienGiamGia", "TongThueVAT", "ThanhToan", "TrangThai", "NguoiTao" };
                    foreach (var column in requiredColumns)
                    {
                        if (!dataTable.Columns.Contains(column))
                        {
                            throw new Exception($"Cột '{column}' không tồn tại trong dữ liệu trả về từ cơ sở dữ liệu.");
                        }
                    }

                    dsHoaDon = dataTable.AsEnumerable().Select(row => new HoaDon
                    {
                        MaHoaDon = row.Field<int>("MaHoaDon"),
                        MaKhachHang = row.Field<int>("MaKhachHang"),
                        MaNhanVien = row.Field<int?>("MaNhanVien") ?? -1,
                        MaBan = row.Field<int?>("MaBan") ?? -1,
                        NgayDat = row.Field<DateTime>("NgayDat"),
                        TongTien = (float)row.Field<decimal>("TongTien"),
                        TienGiamGia = (float)row.Field<decimal>("TienGiamGia"),
                        TongThueVAT = (float)row.Field<decimal>("TongThueVAT"),
                        ThanhToan = (float)row.Field<decimal>("ThanhToan"),
                        TrangThai = row.Field<string>("TrangThai"),
                        NguoiTao = row.Field<int?>("NguoiTao") ?? -1
                    }).ToList();

                    // Lọc dữ liệu nếu có điều kiện
                    if (radMaHD.Checked && int.TryParse(txt_timMaHD.Text, out int maHoaDon))
                    {
                        dsHoaDon = dsHoaDon.Where(hd => hd.MaHoaDon == maHoaDon).ToList();
                    }
                    else if (radNgayDat.Checked)
                    {
                        DateTime ngayDat = dtp_timNgayDat.Value.Date;
                        dsHoaDon = dsHoaDon.Where(hd => hd.NgayDat.Date == ngayDat).ToList();
                    }
                }

                dgvHoaDon.DataSource = dsHoaDon;
                lblTongTin.Text = dsHoaDon.Count.ToString();
                currentIndex = dsHoaDon.Count > 0 ? 0 : -1;
                txtHienHanh.Text = dsHoaDon.Count > 0 ? "1" : "0";
                DisplayCurrentHoaDon();
                UpdateNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsHoaDon = new List<HoaDon>();
                dgvHoaDon.DataSource = dsHoaDon;
                lblTongTin.Text = "0";
                txtHienHanh.Text = "0";
                currentIndex = -1;
                DisplayCurrentHoaDon();
                UpdateNavigation();
            }
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            LoadData();
            radMaHD.Checked = false;
            radNgayDat.Checked = false;
            txt_timMaHD.Text = "";
            dtp_timNgayDat.Value = DateTime.Now;
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsHoaDon.Count > 0)
            {
                currentIndex = 0;
                DisplayCurrentHoaDon();
                dgvHoaDon.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsHoaDon.Count > 0)
            {
                currentIndex = dsHoaDon.Count - 1;
                DisplayCurrentHoaDon();
                dgvHoaDon.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentHoaDon();
                dgvHoaDon.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsHoaDon.Count - 1)
            {
                currentIndex++;
                DisplayCurrentHoaDon();
                dgvHoaDon.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var hd = new HoaDon
                    {
                        MaKhachHang = (int)cboxMaKhachHang.SelectedValue,
                        MaNhanVien = (int)(cboxMaNhanVien.SelectedValue != null ? (int?)cboxMaNhanVien.SelectedValue : null),
                        MaBan = (int)(cboxMaBan.SelectedValue != null ? (int?)cboxMaBan.SelectedValue : null),
                        NgayDat = dtpNgayDat.Value,
                        TongTien = float.Parse(txtTongTien.Text),
                        TienGiamGia = float.Parse(txtTienGiamGia.Text),
                        TongThueVAT = float.Parse(txtTongThueVAT.Text),
                        ThanhToan = float.Parse(txtThanhToan.Text),
                        TrangThai = cboxTrangThai.Text,
                        NguoiTao = (int)(cboxNguoiTao.SelectedValue != null ? (int?)cboxNguoiTao.SelectedValue : null)
                    };

                    if (hoaDonDAL.AddHoaDon(hd))
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn thất bại! Kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput() && int.TryParse(txtMaHD.Text, out int maHoaDon))
                {
                    var hd = new HoaDon
                    {
                        MaHoaDon = maHoaDon,
                        MaKhachHang = (int)cboxMaKhachHang.SelectedValue,
                        MaNhanVien = (int)(cboxMaNhanVien.SelectedValue != null ? (int?)cboxMaNhanVien.SelectedValue : null),
                        MaBan = (int)(cboxMaBan.SelectedValue != null ? (int?)cboxMaBan.SelectedValue : null),
                        NgayDat = dtpNgayDat.Value,
                        TongTien = float.Parse(txtTongTien.Text),
                        TienGiamGia = float.Parse(txtTienGiamGia.Text),
                        TongThueVAT = float.Parse(txtTongThueVAT.Text),
                        ThanhToan = float.Parse(txtThanhToan.Text),
                        TrangThai = cboxTrangThai.Text,
                        NguoiTao = (int)(cboxNguoiTao.SelectedValue != null ? (int?)cboxNguoiTao.SelectedValue : null)
                    };

                    if (hoaDonDAL.UpdateHoaDon(hd))
                    {
                        MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hóa đơn thất bại! Kiểm tra dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtMaHD.Text, out int maHoaDon))
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (hoaDonDAL.DeleteHoaDon(maHoaDon))
                        {
                            MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Xóa hóa đơn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}