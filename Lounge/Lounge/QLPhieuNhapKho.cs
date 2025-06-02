using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class QLPhieuNhapKho : Form
    {
        private PhieuNhapKhoDAL phieuNhapKhoDAL = new PhieuNhapKhoDAL();
        private ChiTietPhieuNhapKhoDAL chiTietPhieuNhapKhoDAL = new ChiTietPhieuNhapKhoDAL();
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private DataTable dtPhieuNhap;
        private int currentIndex = 0;

        public QLPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void QLPhieuNhapKho_Load(object sender, EventArgs e)
        {
            LoadPhieuNhapKho();
            LoadComboBoxNhanVien();
            ClearInputFields();
            txtThanhTien.ReadOnly = true; // Thành tiền chỉ đọc, tự động tính từ chi tiết
        }

        private void LoadPhieuNhapKho()
        {
            dtPhieuNhap = phieuNhapKhoDAL.GetAllPhieuNhapKho();
            dgvPhieuNhap.DataSource = dtPhieuNhap;
            lblTongPhieuNhap.Text = dtPhieuNhap.Rows.Count.ToString();
            if (dtPhieuNhap.Rows.Count > 0)
            {
                currentIndex = 0;
                DisplayPhieuNhap(currentIndex);
            }
            else
            {
                ClearInputFields();
            }
        }

        private void LoadComboBoxNhanVien()
        {
            try
            {
                using (SqlConnection conn = new KetNoi().GetConnect()) // Giả sử KetNoi là lớp kết nối
                {
                    conn.Open();
                    string query = "SELECT MaNV, HoTen FROM NhanVien";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dtNhanVien = new DataTable();
                    adapter.Fill(dtNhanVien);

                    cboxMaNV.DataSource = dtNhanVien;
                    cboxMaNV.DisplayMember = "HoTen"; // Hiển thị tên nhân viên
                    cboxMaNV.ValueMember = "MaNV";    // Giá trị thực là MaNV
                    cboxMaNV.SelectedIndex = -1;      // Không chọn mặc định
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPhieuNhap(int index)
        {
            if (index >= 0 && index < dtPhieuNhap.Rows.Count)
            {
                try
                {
                    var row = dtPhieuNhap.Rows[index];
                    txtMaPhieuNhap.Text = row["MaPhieuNhap"].ToString();
                    dtpNgayNhap.Value = Convert.ToDateTime(row["NgayNhap"]);

                    // Kiểm tra ValueMember đã được thiết lập
                    if (string.IsNullOrEmpty(cboxMaNV.ValueMember))
                    {
                        LoadComboBoxNhanVien(); // Tải lại nếu chưa cấu hình
                    }

                    cboxMaNV.SelectedValue = row["MaNV"]; // Gán MaNV
                    txtGhiChu.Text = row["GhiChu"].ToString();
                    txtThanhTien.Text = row["TongTienNhap"].ToString();
                    txtHienHanh.Text = (index + 1).ToString();
                    LoadChiTietPhieuNhap(Convert.ToInt32(row["MaPhieuNhap"]));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi hiển thị phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadChiTietPhieuNhap(int maPhieuNhap)
        {
            var dtChiTiet = chiTietPhieuNhapKhoDAL.GetChiTietPhieuNhapKho(maPhieuNhap);
            dgvChiTietPhieuNhap.DataSource = dtChiTiet;
        }

        private void ClearInputFields()
        {
            txtMaPhieuNhap.Text = "";
            dtpNgayNhap.Value = DateTime.Now;
            cboxMaNV.SelectedIndex = -1;
            txtGhiChu.Text = "";
            txtThanhTien.Text = "";
            txt_timMaPhieuNhap.Text = "";
            dtp_timNgayNhap.Value = DateTime.Now;
            radMaPhieuNhap.Checked = false;
            radNgayNhap.Checked = false;
            dgvChiTietPhieuNhap.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            if (ValidatePhieuNhapInput())
            {
                var pn = new PhieuNhapKho
                {
                    NgayNhap = dtpNgayNhap.Value,
                    MaNV = Convert.ToInt32(cboxMaNV.SelectedValue),
                    TongTienNhap = 0, // Sẽ được cập nhật từ chi tiết
                    GhiChu = txtGhiChu.Text
                };
                if (phieuNhapKhoDAL.AddPhieuNhapKho(pn))
                {
                    MessageBox.Show("Thêm phiếu nhập kho thành công! Vui lòng thêm chi tiết phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuNhapKho();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu nhập kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Sửa
        {
            if (ValidatePhieuNhapInput() && !string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                var pn = new PhieuNhapKho
                {
                    MaPhieuNhap = Convert.ToInt32(txtMaPhieuNhap.Text),
                    NgayNhap = dtpNgayNhap.Value,
                    MaNV = Convert.ToInt32(cboxMaNV.SelectedValue),
                    TongTienNhap = string.IsNullOrEmpty(txtThanhTien.Text) ? 0 : Convert.ToDecimal(txtThanhTien.Text),
                    GhiChu = txtGhiChu.Text
                };
                if (UpdatePhieuNhapKho(pn))
                {
                    MessageBox.Show("Sửa phiếu nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuNhapKho();
                }
                else
                {
                    MessageBox.Show("Sửa phiếu nhập kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UpdatePhieuNhapKho(PhieuNhapKho pn)
        {
            string query = @"
                UPDATE PhieuNhapKho 
                SET NgayNhap = @NgayNhap, MaNV = @MaNV, TongTienNhap = @TongTienNhap, GhiChu = @GhiChu
                WHERE MaPhieuNhap = @MaPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", pn.MaPhieuNhap);
                    cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNV", pn.MaNV);
                    cmd.Parameters.AddWithValue("@TongTienNhap", pn.TongTienNhap);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)pn.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Xóa
        {
            if (!string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập này? Số lượng tồn kho sẽ được cập nhật.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maPhieuNhap = Convert.ToInt32(txtMaPhieuNhap.Text);
                    if (DeletePhieuNhapKho(maPhieuNhap))
                    {
                        MessageBox.Show("Xóa phiếu nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhieuNhapKho();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu nhập kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeletePhieuNhapKho(int maPhieuNhap)
        {
            // Giảm số lượng tồn kho trước khi xóa chi tiết
            string queryChiTiet = "SELECT MaSanPham, SoLuong FROM ChiTietPhieuNhapKho WHERE MaPhieuNhap = @MaPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(queryChiTiet, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maSanPham = reader.GetInt32(0);
                            int soLuong = reader.GetInt32(1);
                            UpdateSoLuongTonKho(maSanPham, -soLuong);
                        }
                    }
                }
            }

            // Xóa chi tiết phiếu nhập
            string deleteChiTietQuery = "DELETE FROM ChiTietPhieuNhapKho WHERE MaPhieuNhap = @MaPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(deleteChiTietQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Xóa phiếu nhập
            string deletePhieuNhapQuery = "DELETE FROM PhieuNhapKho WHERE MaPhieuNhap = @MaPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(deletePhieuNhapQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                using (var form = new FormChiTietPhieuNhapKho(Convert.ToInt32(txtMaPhieuNhap.Text)))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadChiTietPhieuNhap(Convert.ToInt32(txtMaPhieuNhap.Text));
                        UpdateTongTienNhap();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.SelectedRows.Count > 0)
            {
                int maChiTiet = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["MaChiTietPhieuNhap"].Value);
                int maSanPham = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["MaSanPham"].Value);
                int soLuongCu = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["SoLuong"].Value);

                using (var form = new FormChiTietPhieuNhapKho(Convert.ToInt32(txtMaPhieuNhap.Text), maChiTiet))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật số lượng tồn kho
                        int soLuongMoi = GetSoLuongMoi(maChiTiet);
                        UpdateSoLuongTonKho(maSanPham, soLuongMoi - soLuongCu);
                        LoadChiTietPhieuNhap(Convert.ToInt32(txtMaPhieuNhap.Text));
                        UpdateTongTienNhap();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết phiếu nhập để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetSoLuongMoi(int maChiTiet)
        {
            string query = "SELECT SoLuong FROM ChiTietPhieuNhapKho WHERE MaChiTietPhieuNhap = @MaChiTietPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietPhieuNhap", maChiTiet);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết phiếu nhập này? Số lượng tồn kho sẽ được cập nhật.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maChiTiet = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["MaChiTietPhieuNhap"].Value);
                    int maSanPham = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["MaSanPham"].Value);
                    int soLuong = Convert.ToInt32(dgvChiTietPhieuNhap.SelectedRows[0].Cells["SoLuong"].Value);

                    if (DeleteChiTietPhieuNhapKho(maChiTiet))
                    {
                        UpdateSoLuongTonKho(maSanPham, -soLuong);
                        MessageBox.Show("Xóa chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChiTietPhieuNhap(Convert.ToInt32(txtMaPhieuNhap.Text));
                        UpdateTongTienNhap();
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết phiếu nhập để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeleteChiTietPhieuNhapKho(int maChiTiet)
        {
            string query = "DELETE FROM ChiTietPhieuNhapKho WHERE MaChiTietPhieuNhap = @MaChiTietPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietPhieuNhap", maChiTiet);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void UpdateSoLuongTonKho(int maSanPham, int soLuong)
        {
            string query = "UPDATE SANPHAM SET SoLuongTonKho = SoLuongTonKho + @SoLuong WHERE MaSanPham = @MaSanPham";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateTongTienNhap()
        {
            if (!string.IsNullOrEmpty(txtMaPhieuNhap.Text))
            {
                int maPhieuNhap = Convert.ToInt32(txtMaPhieuNhap.Text);
                string query = "SELECT SUM(ThanhTien) FROM ChiTietPhieuNhapKho WHERE MaPhieuNhap = @MaPhieuNhap";
                using (var conn = new KetNoi().GetConnect())
                {
                    using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                        conn.Open();
                        var result = cmd.ExecuteScalar();
                        decimal tongTien = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                        txtThanhTien.Text = tongTien.ToString();
                        // Cập nhật TongTienNhap trong bảng PhieuNhapKho
                        string updateQuery = "UPDATE PhieuNhapKho SET TongTienNhap = @TongTienNhap WHERE MaPhieuNhap = @MaPhieuNhap";
                        using (var updateCmd = new System.Data.SqlClient.SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@TongTienNhap", tongTien);
                            updateCmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
                LoadPhieuNhapKho();
            }
        }

        private bool ValidatePhieuNhapInput()
        {
            if (cboxMaNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT PN.MaPhieuNhap, PN.NgayNhap, PN.MaNV, PN.TongTienNhap, PN.GhiChu, NV.HoTen AS TenNhanVien
                FROM PhieuNhapKho PN
                JOIN NhanVien NV ON PN.MaNV = NV.MaNV
                WHERE 1=1";
            if (radMaPhieuNhap.Checked && !string.IsNullOrEmpty(txt_timMaPhieuNhap.Text))
            {
                query += " AND PN.MaPhieuNhap = @MaPhieuNhap";
            }
            if (radNgayNhap.Checked)
            {
                query += " AND CAST(PN.NgayNhap AS DATE) = @NgayNhap";
            }
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    if (radMaPhieuNhap.Checked && !string.IsNullOrEmpty(txt_timMaPhieuNhap.Text))
                    {
                        if (!int.TryParse(txt_timMaPhieuNhap.Text, out int maPhieuNhap))
                        {
                            MessageBox.Show("Mã phiếu nhập phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    }
                    if (radNgayNhap.Checked)
                    {
                        cmd.Parameters.AddWithValue("@NgayNhap", dtp_timNgayNhap.Value.Date);
                    }
                    conn.Open();
                    using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                    {
                        dtPhieuNhap = new DataTable();
                        da.Fill(dtPhieuNhap);
                        dgvPhieuNhap.DataSource = dtPhieuNhap;
                        lblTongPhieuNhap.Text = dtPhieuNhap.Rows.Count.ToString();
                        currentIndex = dtPhieuNhap.Rows.Count > 0 ? 0 : -1;
                        if (currentIndex >= 0)
                        {
                            DisplayPhieuNhap(currentIndex);
                        }
                        else
                        {
                            ClearInputFields();
                        }
                    }
                }
            }
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            LoadPhieuNhapKho();
            ClearInputFields();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuNhapKho();
            ClearInputFields();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtPhieuNhap.Rows.Count > 0)
            {
                currentIndex = 0;
                DisplayPhieuNhap(currentIndex);
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayPhieuNhap(currentIndex);
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dtPhieuNhap.Rows.Count - 1)
            {
                currentIndex++;
                DisplayPhieuNhap(currentIndex);
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtPhieuNhap.Rows.Count > 0)
            {
                currentIndex = dtPhieuNhap.Rows.Count - 1;
                DisplayPhieuNhap(currentIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Thoát
        {
            this.Close();
        }

        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.SelectedRows.Count > 0)
            {
                currentIndex = dgvPhieuNhap.SelectedRows[0].Index;
                DisplayPhieuNhap(currentIndex);
            }
        }
    }
}