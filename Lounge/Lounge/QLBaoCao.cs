using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClosedXML.Excel;

namespace NhaHang
{
    public partial class QLBaoCao : Form
    {
        private BaoCaoDAL baoCaoDAL = new BaoCaoDAL();

        public QLBaoCao()
        {
            InitializeComponent();
        }

        private void QLBaoCao_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox LoaiBaoCao
            cboLoaiBaoCao.Items.AddRange(new object[] { "Hàng Ngày", "Hàng Tháng", "Hàng Năm" });
            cboLoaiBaoCao.SelectedIndex = 0;

            // Load danh sách nhân viên vào ComboBox NguoiTao
            LoadNhanVienComboBox();

            // Load danh sách báo cáo
            LoadBaoCao();

            // Đặt các TextBox chỉ đọc khi tải form
            SetTextBoxesReadOnly(true);
        }

        private void LoadBaoCao()
        {
            try
            {
                dgvBaoCao.DataSource = baoCaoDAL.GetAllBaoCao();
                dgvBaoCao.Columns["MaBaoCao"].HeaderText = "Mã Báo Cáo";
                dgvBaoCao.Columns["LoaiBaoCao"].HeaderText = "Loại Báo Cáo";
                dgvBaoCao.Columns["NgayBaoCao"].HeaderText = "Ngày Báo Cáo";
                dgvBaoCao.Columns["TongDoanhThu"].HeaderText = "Tổng Doanh Thu";
                dgvBaoCao.Columns["TongChiPhi"].HeaderText = "Tổng Chi Phí";
                dgvBaoCao.Columns["LoiNhuan"].HeaderText = "Lợi Nhuận";
                dgvBaoCao.Columns["SoHoaDon"].HeaderText = "Số Hóa Đơn";
                dgvBaoCao.Columns["SoKhachHang"].HeaderText = "Số Khách Hàng";
                dgvBaoCao.Columns["SoSanPhamBanRa"].HeaderText = "Số Sản Phẩm Bán Ra";
                dgvBaoCao.Columns["TenNguoiTao"].HeaderText = "Người Tạo";
                dgvBaoCao.Columns["GhiChu"].HeaderText = "Ghi Chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNhanVienComboBox()
        {
            try
            {
                DataTable dtNhanVien = baoCaoDAL.GetNhanVien();
                cboNguoiTao.DataSource = dtNhanVien;
                cboNguoiTao.DisplayMember = "HoTen";
                cboNguoiTao.ValueMember = "MaNV";
                cboNguoiTao.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTextBoxesReadOnly(bool readOnly)
        {
            txtTongDoanhThu.ReadOnly = readOnly;
            txtTongChiPhi.ReadOnly = readOnly;
            txtSoHoaDon.ReadOnly = readOnly;
            txtSoKhachHang.ReadOnly = readOnly;
            txtSoSanPhamBanRa.ReadOnly = readOnly;
            txtGhiChu.ReadOnly = readOnly;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                var baoCao = new BaoCao
                {
                    LoaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString(),
                    NgayBaoCao = dtpNgayBaoCao.Value,
                    TongDoanhThu = decimal.Parse(txtTongDoanhThu.Text),
                    TongChiPhi = decimal.Parse(txtTongChiPhi.Text),
                    SoHoaDon = int.Parse(txtSoHoaDon.Text),
                    SoKhachHang = int.Parse(txtSoKhachHang.Text),
                    SoSanPhamBanRa = int.Parse(txtSoSanPhamBanRa.Text),
                    NguoiTao = cboNguoiTao.SelectedValue as int?,
                    GhiChu = txtGhiChu.Text
                };

                if (baoCaoDAL.AddBaoCao(baoCao))
                {
                    MessageBox.Show("Thêm báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBaoCao();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Thêm báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!ValidateInput()) return;

                var baoCao = new BaoCao
                {
                    MaBaoCao = (int)dgvBaoCao.SelectedRows[0].Cells["MaBaoCao"].Value,
                    LoaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString(),
                    NgayBaoCao = dtpNgayBaoCao.Value,
                    TongDoanhThu = decimal.Parse(txtTongDoanhThu.Text),
                    TongChiPhi = decimal.Parse(txtTongChiPhi.Text),
                    SoHoaDon = int.Parse(txtSoHoaDon.Text),
                    SoKhachHang = int.Parse(txtSoKhachHang.Text),
                    SoSanPhamBanRa = int.Parse(txtSoSanPhamBanRa.Text),
                    NguoiTao = cboNguoiTao.SelectedValue as int?,
                    GhiChu = txtGhiChu.Text
                };

                if (baoCaoDAL.UpdateBaoCao(baoCao))
                {
                    MessageBox.Show("Sửa báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBaoCao();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Sửa báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBaoCao.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn báo cáo để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa báo cáo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maBaoCao = (int)dgvBaoCao.SelectedRows[0].Cells["MaBaoCao"].Value;
                    if (baoCaoDAL.DeleteBaoCao(maBaoCao))
                    {
                        MessageBox.Show("Xóa báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBaoCao();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Xóa báo cáo thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string loaiBaoCao = cboLoaiBaoCao.SelectedItem?.ToString();
                DateTime? ngayBaoCao = dtpNgayBaoCao.Checked ? (DateTime?)dtpNgayBaoCao.Value : null;
                int? nguoiTao = cboNguoiTao.SelectedValue != null ? (int?)cboNguoiTao.SelectedValue : null;

                dgvBaoCao.DataSource = baoCaoDAL.SearchBaoCao(loaiBaoCao, ngayBaoCao, nguoiTao);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("BaoCao");
                    var data = (DataTable)dgvBaoCao.DataSource;

                    // Thêm tiêu đề cột
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = data.Columns[i].ColumnName;
                    }

                    // Thêm dữ liệu
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        for (int j = 0; j < data.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = data.Rows[i][j].ToString();
                        }
                    }

                    // Lưu file
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel files|*.xlsx";
                        saveFileDialog.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd}.xlsx";
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoTuDong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLoaiBaoCao.SelectedItem == null || !dtpNgayBaoCao.Checked || cboNguoiTao.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Loại Báo Cáo, Ngày Báo Cáo và Người Tạo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string loaiBaoCao = cboLoaiBaoCao.SelectedItem.ToString();
                DateTime ngayBaoCao = dtpNgayBaoCao.Value;
                int nguoiTao = (int)cboNguoiTao.SelectedValue;

                if (baoCaoDAL.TaoBaoCaoTuDong(loaiBaoCao, ngayBaoCao, nguoiTao))
                {
                    MessageBox.Show("Tạo báo cáo tự động thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBaoCao();
                }
                else
                {
                    MessageBox.Show("Tạo báo cáo tự động thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo tự động: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cboLoaiBaoCao.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!dtpNgayBaoCao.Checked)
            {
                MessageBox.Show("Vui lòng chọn ngày báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTongDoanhThu.Text) || !decimal.TryParse(txtTongDoanhThu.Text, out _))
            {
                MessageBox.Show("Tổng doanh thu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTongChiPhi.Text) || !decimal.TryParse(txtTongChiPhi.Text, out _))
            {
                MessageBox.Show("Tổng chi phí không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoHoaDon.Text) || !int.TryParse(txtSoHoaDon.Text, out _))
            {
                MessageBox.Show("Số hóa đơn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoKhachHang.Text) || !int.TryParse(txtSoKhachHang.Text, out _))
            {
                MessageBox.Show("Số khách hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoSanPhamBanRa.Text) || !int.TryParse(txtSoSanPhamBanRa.Text, out _))
            {
                MessageBox.Show("Số sản phẩm bán ra không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cboNguoiTao.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn người tạo báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            cboLoaiBaoCao.SelectedIndex = 0;
            dtpNgayBaoCao.Checked = false;
            txtTongDoanhThu.Clear();
            txtTongChiPhi.Clear();
            txtSoHoaDon.Clear();
            txtSoKhachHang.Clear();
            txtSoSanPhamBanRa.Clear();
            txtGhiChu.Clear();
            cboNguoiTao.SelectedIndex = -1;
        }

        private void dgvBaoCao_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBaoCao.SelectedRows.Count > 0)
            {
                var row = dgvBaoCao.SelectedRows[0];
                cboLoaiBaoCao.SelectedItem = row.Cells["LoaiBaoCao"].Value.ToString();
                dtpNgayBaoCao.Value = Convert.ToDateTime(row.Cells["NgayBaoCao"].Value);
                txtTongDoanhThu.Text = row.Cells["TongDoanhThu"].Value.ToString();
                txtTongChiPhi.Text = row.Cells["TongChiPhi"].Value.ToString();
                txtSoHoaDon.Text = row.Cells["SoHoaDon"].Value.ToString();
                txtSoKhachHang.Text = row.Cells["SoKhachHang"].Value.ToString();
                txtSoSanPhamBanRa.Text = row.Cells["SoSanPhamBanRa"].Value.ToString();
                cboNguoiTao.Text = row.Cells["TenNguoiTao"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
                SetTextBoxesReadOnly(false);
            }
        }
    }

    public class BaoCao
    {
        public int MaBaoCao { get; set; }
        public string LoaiBaoCao { get; set; }
        public DateTime NgayBaoCao { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongChiPhi { get; set; }
        public int SoHoaDon { get; set; }
        public int SoKhachHang { get; set; }
        public int SoSanPhamBanRa { get; set; }
        public int? NguoiTao { get; set; }
        public string GhiChu { get; set; }
    }
}