using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lounge.DAL; // Hoặc NhaHang.DAL
using Lounge.Model; // Hoặc NhaHang.Model

namespace Lounge // Hoặc namespace NhaHang
{
    public partial class QLBaoCao : Form
    {
        private BaoCaoDAL baoCaoDAL = new BaoCaoDAL();
        private NhanVienDAL nhanVienDAL = new NhanVienDAL(); // Để load ComboBox Người Tạo
        private List<BaoCao> dsBaoCao = new List<BaoCao>();
        private int currentIndex = -1; // Chỉ số của báo cáo đang được chọn trong dsBaoCao

        public QLBaoCao()
        {
            InitializeComponent();
        }

        private void QLBaoCao_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            ConfigureDataGridView();
            LoadData();
            WireUpButtonEvents();
        }

        private void WireUpButtonEvents()
        {
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXuatExcel.Click += btnXuatExcel_Click;
            btnTaoTuDong.Click += btnTaoTuDong_Click;
            btnLenLichTuDong.Click += btnLenLichTuDong_Click;
            // dgvBaoCao.SelectionChanged đã được gán trong Designer (hoặc QLBaoCao_Load nếu bạn thêm sau)
        }

        private void LoadComboBoxes()
        {
            // Loại báo cáo
            cboLoaiBaoCao.Items.Clear();
            cboLoaiBaoCao.Items.Add("Hàng Ngày");
            cboLoaiBaoCao.Items.Add("Hàng Tháng");
            cboLoaiBaoCao.Items.Add("Hàng Năm");
            if (cboLoaiBaoCao.Items.Count > 0)
                cboLoaiBaoCao.SelectedIndex = 0;

            // Người tạo
            cboNguoiTao.DataSource = null;
            try
            {
                List<NhanVien> dsNV = nhanVienDAL.GetNhanVienForComboBox();
                if (dsNV != null)
                {
                    cboNguoiTao.DataSource = dsNV;
                    cboNguoiTao.DisplayMember = "HoTen";
                    cboNguoiTao.ValueMember = "MaNhanvien";   // SỬA Ở ĐÂY: Khớp với Model NhanVien.cs của bạn

                    if (dsNV.Any())
                        cboNguoiTao.SelectedIndex = 0;
                    else
                        cboNguoiTao.SelectedIndex = -1;
                }
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Lỗi khi binding dữ liệu cho ComboBox Người Tạo: {argEx.Message}\nKiểm tra lại tên thuộc tính trong Model.NhanVien ('{cboNguoiTao.ValueMember}') và cách gán trong NhanVienDAL.", "Lỗi Binding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách người tạo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvBaoCao.AutoGenerateColumns = false;
            dgvBaoCao.Columns.Clear();

            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaBaoCao", HeaderText = "Mã BC", Width = 70 });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoaiBaoCao", HeaderText = "Loại Báo Cáo", Width = 120 });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "NgayBaoCao", HeaderText = "Ngày Báo Cáo", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongDoanhThu", HeaderText = "Tổng Doanh Thu", Width = 130, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TongChiPhi", HeaderText = "Tổng Chi Phí", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LoiNhuan", HeaderText = "Lợi Nhuận", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoHoaDon", HeaderText = "Số HĐ", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoKhachHang", HeaderText = "Số Khách", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoSanPhamBanRa", HeaderText = "SL SP Bán", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNguoiTao", HeaderText = "Người Tạo", Width = 150 });
            dgvBaoCao.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GhiChu", HeaderText = "Ghi Chú", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void LoadData()
        {
            try
            {
                dsBaoCao = baoCaoDAL.GetAllBaoCao();
                dgvBaoCao.DataSource = null;
                if (dsBaoCao != null)
                {
                    dgvBaoCao.DataSource = dsBaoCao;
                }
                else
                {
                    dsBaoCao = new List<BaoCao>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsBaoCao = new List<BaoCao>();
            }

            if (dsBaoCao.Any())
            {
                currentIndex = 0;
                if (dgvBaoCao.Rows.Count > currentIndex)
                {
                    dgvBaoCao.Rows[currentIndex].Selected = true;
                }
                DisplayCurrentBaoCao();
            }
            else
            {
                currentIndex = -1;
                ClearInputFields();
            }
        }

        private void dgvBaoCao_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBaoCao.CurrentRow != null && dgvBaoCao.CurrentRow.Index < dsBaoCao.Count)
            {
                currentIndex = dgvBaoCao.CurrentRow.Index;
                DisplayCurrentBaoCao();
            }
        }

        private void DisplayCurrentBaoCao()
        {
            if (currentIndex >= 0 && currentIndex < dsBaoCao.Count)
            {
                BaoCao bc = dsBaoCao[currentIndex];
                txtMaBaoCao.Text = bc.MaBaoCao.ToString();
                cboLoaiBaoCao.SelectedItem = bc.LoaiBaoCao;
                dtpNgayBaoCao.Value = bc.NgayBaoCao;
                txtTongDoanhThu.Text = bc.TongDoanhThu.ToString("N0");
                txtTongChiPhi.Text = bc.TongChiPhi.ToString("N0");
                txtSoHoaDon.Text = bc.SoHoaDon.ToString();
                txtSoKhachHang.Text = bc.SoKhachHang.ToString();
                txtSoSanPhamBanRa.Text = bc.SoSanPhamBanRa.ToString();
                txtGhiChu.Text = bc.GhiChu;

                if (bc.NguoiTao.HasValue)
                {
                    if (cboNguoiTao.Items.Count > 0)
                    {
                        bool valueFound = false;
                        foreach (var item in cboNguoiTao.Items)
                        {
                            // Giả định Model.NhanVien có thuộc tính MaNhanvien (khớp với ValueMember)
                            if (item is NhanVien nvItem && nvItem.MaNhanvien == bc.NguoiTao.Value)
                            {
                                cboNguoiTao.SelectedValue = bc.NguoiTao.Value;
                                valueFound = true;
                                break;
                            }
                        }
                        if (!valueFound)
                        {
                            cboNguoiTao.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        cboNguoiTao.SelectedIndex = -1;
                    }
                }
                else
                {
                    cboNguoiTao.SelectedIndex = -1;
                }
            }
            else
            {
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txtMaBaoCao.Text = "";
            if (cboLoaiBaoCao.Items.Count > 0) cboLoaiBaoCao.SelectedIndex = 0;
            dtpNgayBaoCao.Value = DateTime.Now;
            txtTongDoanhThu.Text = "0";
            txtTongChiPhi.Text = "0";
            txtSoHoaDon.Text = "0";
            txtSoKhachHang.Text = "0";
            txtSoSanPhamBanRa.Text = "0";
            txtGhiChu.Text = "";
            if (cboNguoiTao.Items.Count > 0) cboNguoiTao.SelectedIndex = 0;
        }

        private bool ValidateInputForAddUpdate()
        {
            if (cboLoaiBaoCao.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiBaoCao.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTongDoanhThu.Text, out _)) // Sửa thành decimal nếu model BaoCao dùng decimal
            {
                MessageBox.Show("Tổng doanh thu không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongDoanhThu.Focus();
                return false;
            }
            if (!decimal.TryParse(txtTongChiPhi.Text, out _)) // Sửa thành decimal
            {
                MessageBox.Show("Tổng chi phí không hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTongChiPhi.Focus();
                return false;
            }
            if (cboNguoiTao.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người tạo báo cáo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNguoiTao.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú cho báo cáo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChu.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInputForAddUpdate())
            {
                BaoCao bc = new BaoCao
                {
                    LoaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString(),
                    NgayBaoCao = dtpNgayBaoCao.Value.Date,
                    TongDoanhThu = decimal.Parse(txtTongDoanhThu.Text), // Sửa thành decimal
                    TongChiPhi = decimal.Parse(txtTongChiPhi.Text),   // Sửa thành decimal
                    SoHoaDon = int.TryParse(txtSoHoaDon.Text, out int shd) ? shd : 0,
                    SoKhachHang = int.TryParse(txtSoKhachHang.Text, out int skh) ? skh : 0,
                    SoSanPhamBanRa = int.TryParse(txtSoSanPhamBanRa.Text, out int ssp) ? ssp : 0,
                    // Giả định Model.NhanVien có thuộc tính MaNhanvien khớp với ValueMember
                    NguoiTao = (int?)cboNguoiTao.SelectedValue,
                    GhiChu = txtGhiChu.Text
                };

                if (baoCaoDAL.AddBaoCao(bc))
                {
                    MessageBox.Show("Thêm báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBaoCao.Text))
            {
                MessageBox.Show("Vui lòng chọn báo cáo để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ValidateInputForAddUpdate())
            {
                BaoCao bc = new BaoCao
                {
                    MaBaoCao = int.Parse(txtMaBaoCao.Text),
                    LoaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString(),
                    NgayBaoCao = dtpNgayBaoCao.Value.Date,
                    TongDoanhThu = decimal.Parse(txtTongDoanhThu.Text), // Sửa thành decimal
                    TongChiPhi = decimal.Parse(txtTongChiPhi.Text),   // Sửa thành decimal
                    SoHoaDon = int.TryParse(txtSoHoaDon.Text, out int shd) ? shd : 0,
                    SoKhachHang = int.TryParse(txtSoKhachHang.Text, out int skh) ? skh : 0,
                    SoSanPhamBanRa = int.TryParse(txtSoSanPhamBanRa.Text, out int ssp) ? ssp : 0,
                    NguoiTao = (int?)cboNguoiTao.SelectedValue,
                    GhiChu = txtGhiChu.Text
                };
                if (baoCaoDAL.UpdateBaoCao(bc))
                {
                    MessageBox.Show("Cập nhật báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBaoCao.Text))
            {
                MessageBox.Show("Vui lòng chọn báo cáo để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa báo cáo này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (baoCaoDAL.DeleteBaoCao(int.Parse(txtMaBaoCao.Text)))
                {
                    MessageBox.Show("Xóa báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string loaiFilter = cboLoaiBaoCao.SelectedItem?.ToString();
            DateTime ngayFilter = dtpNgayBaoCao.Value.Date;
            int? nguoiTaoFilter = null;
            if (cboNguoiTao.SelectedValue != null && cboNguoiTao.SelectedIndex != -1)
            {
                if (int.TryParse(cboNguoiTao.SelectedValue.ToString(), out int selectedMaNV))
                {
                    nguoiTaoFilter = selectedMaNV;
                }
            }

            List<BaoCao> allData = baoCaoDAL.GetAllBaoCao();
            IEnumerable<BaoCao> filteredData = allData;

            if (!string.IsNullOrEmpty(loaiFilter) && loaiFilter != "Tất cả")
            {
                filteredData = filteredData.Where(bc => bc.LoaiBaoCao == loaiFilter);
            }

            // Bạn có thể thêm CheckBox để bật/tắt lọc theo ngày
            // if (chkLocTheoNgay.Checked) 
            // {
            filteredData = filteredData.Where(bc => bc.NgayBaoCao.Date == ngayFilter);
            // }

            if (nguoiTaoFilter.HasValue)
            {
                filteredData = filteredData.Where(bc => bc.NguoiTao == nguoiTaoFilter.Value);
            }

            dsBaoCao = filteredData.ToList();
            dgvBaoCao.DataSource = null;
            dgvBaoCao.DataSource = dsBaoCao;

            if (dsBaoCao.Any())
            {
                currentIndex = 0;
                if (dgvBaoCao.Rows.Count > currentIndex) dgvBaoCao.Rows[currentIndex].Selected = true;
            }
            else
            {
                currentIndex = -1;
            }
            DisplayCurrentBaoCao();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Xuất Excel chưa được cài đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTaoTuDong_Click(object sender, EventArgs e)
        {
            if (cboLoaiBaoCao.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboNguoiTao.SelectedValue == null || cboNguoiTao.SelectedIndex == -1) // Kiểm tra cả SelectedIndex
            {
                MessageBox.Show("Vui lòng chọn người tạo báo cáo hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loaiBC = cboLoaiBaoCao.SelectedItem.ToString();
            DateTime ngayBC = dtpNgayBaoCao.Value.Date;
            int maNguoiTao = (int)cboNguoiTao.SelectedValue;

            if (MessageBox.Show($"Bạn có muốn tạo báo cáo '{loaiBC}' cho ngày {ngayBC:dd/MM/yyyy} bởi '{cboNguoiTao.Text}' không?",
                                "Xác nhận tạo báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (baoCaoDAL.TaoBaoCaoTuDong(loaiBC, ngayBC, maNguoiTao))
                {
                    MessageBox.Show("Tạo báo cáo tự động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                // else: Lỗi đã được xử lý và thông báo trong DAL nếu là SqlException
            }
        }

        private void btnLenLichTuDong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Lên Lịch Tạo Báo Cáo Tự Động chưa được cài đặt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
