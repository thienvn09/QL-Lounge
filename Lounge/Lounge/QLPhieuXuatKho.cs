using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class QLPhieuXuatKho : Form
    {
        private PhieuXuatKhoDAL phieuXuatKhoDAL = new PhieuXuatKhoDAL();
        private ChiTietPhieuXuatDAL chiTietPhieuXuatDAL = new ChiTietPhieuXuatDAL();
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private DataTable dtPhieuXuat;
        private int currentIndex = 0;

        public QLPhieuXuatKho()
        {
            InitializeComponent();
        }

        private void QLPhieuXuatKho_Load(object sender, EventArgs e)
        {
            LoadPhieuXuatKho();
            LoadComboBoxNhanVien();
            ClearInputFields();
        }

        private void LoadPhieuXuatKho()
        {
            dtPhieuXuat = phieuXuatKhoDAL.GetAllPhieuXuatKho();
            dgvPhieuXuat.DataSource = dtPhieuXuat;
            lblTongPhieuXuat.Text = dtPhieuXuat.Rows.Count.ToString();
            if (dtPhieuXuat.Rows.Count > 0)
            {
                currentIndex = 0;
                DisplayPhieuXuat(currentIndex);
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

        private void DisplayPhieuXuat(int index)
        {
            if (index >= 0 && index < dtPhieuXuat.Rows.Count)
            {
                var row = dtPhieuXuat.Rows[index];
                txtMaPhieuXuat.Text = row["MaPhieuXuat"].ToString();
                dtpNgayXuat.Value = Convert.ToDateTime(row["NgayXuat"]);
                cboxMaNV.SelectedValue = row["MaNhanVien"] != DBNull.Value ? row["MaNhanVien"] : null;
                txtGhiChu.Text = row["GhiChu"].ToString();
                txtHienHanh.Text = (index + 1).ToString();
                LoadChiTietPhieuXuat(Convert.ToInt32(row["MaPhieuXuat"]));
            }
        }

        private void LoadChiTietPhieuXuat(int maPhieuXuat)
        {
            var dtChiTiet = chiTietPhieuXuatDAL.GetChiTietPhieuXuat(maPhieuXuat);
            dgvChiTietPhieuXuat.DataSource = dtChiTiet;
        }

        private void ClearInputFields()
        {
            txtMaPhieuXuat.Text = "";
            dtpNgayXuat.Value = DateTime.Now;
            cboxMaNV.SelectedIndex = -1;
            txtGhiChu.Text = "";
            txt_timMaPhieuXuat.Text = "";
            dtp_timNgayXuat.Value = DateTime.Now;
            radMaPhieuXuat.Checked = false;
            radNgayXuat.Checked = false;
            dgvChiTietPhieuXuat.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e) // Thêm
        {
            if (ValidatePhieuXuatInput())
            {
                var px = new PhieuXuatKho
                {
                    NgayXuat = dtpNgayXuat.Value,
                    MaNhanVien = cboxMaNV.SelectedValue != null ? Convert.ToInt32(cboxMaNV.SelectedValue) : (int?)null,
                    GhiChu = txtGhiChu.Text
                };
                if (phieuXuatKhoDAL.AddPhieuXuatKho(px))
                {
                    MessageBox.Show("Thêm phiếu xuất kho thành công! Vui lòng thêm chi tiết phiếu xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuXuatKho();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm phiếu xuất kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Sửa
        {
            if (ValidatePhieuXuatInput() && !string.IsNullOrEmpty(txtMaPhieuXuat.Text))
            {
                var px = new PhieuXuatKho
                {
                    MaPhieuXuat = Convert.ToInt32(txtMaPhieuXuat.Text),
                    NgayXuat = dtpNgayXuat.Value,
                    MaNhanVien = cboxMaNV.SelectedValue != null ? Convert.ToInt32(cboxMaNV.SelectedValue) : (int?)null,
                    GhiChu = txtGhiChu.Text
                };
                if (UpdatePhieuXuatKho(px))
                {
                    MessageBox.Show("Sửa phiếu xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPhieuXuatKho();
                }
                else
                {
                    MessageBox.Show("Sửa phiếu xuất kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UpdatePhieuXuatKho(PhieuXuatKho px)
        {
            string query = @"
                UPDATE PhieuXuatKho 
                SET NgayXuat = @NgayXuat, MaNhanVien = @MaNhanVien, GhiChu = @GhiChu
                WHERE MaPhieuXuat = @MaPhieuXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", px.MaPhieuXuat);
                    cmd.Parameters.AddWithValue("@NgayXuat", px.NgayXuat);
                    cmd.Parameters.AddWithValue("@MaNhanVien", (object)px.MaNhanVien ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)px.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Xóa
        {
            if (!string.IsNullOrEmpty(txtMaPhieuXuat.Text))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa phiếu xuất này? Số lượng tồn kho sẽ được cập nhật.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maPhieuXuat = Convert.ToInt32(txtMaPhieuXuat.Text);
                    if (DeletePhieuXuatKho(maPhieuXuat))
                    {
                        MessageBox.Show("Xóa phiếu xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhieuXuatKho();
                        ClearInputFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu xuất kho thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeletePhieuXuatKho(int maPhieuXuat)
        {
            // Tăng số lượng tồn kho trước khi xóa chi tiết
            string queryChiTiet = "SELECT MaSanPham, SoLuong FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @MaPhieuXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(queryChiTiet, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maSanPham = reader.GetInt32(0);
                            int soLuong = reader.GetInt32(1);
                            UpdateSoLuongTonKho(maSanPham, soLuong); // Tăng số lượng tồn kho
                        }
                    }
                }
            }

            // Xóa chi tiết phiếu xuất
            string deleteChiTietQuery = "DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat = @MaPhieuXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(deleteChiTietQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Xóa phiếu xuất
            string deletePhieuXuatQuery = "DELETE FROM PhieuXuatKho WHERE MaPhieuXuat = @MaPhieuXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(deletePhieuXuatQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void btnThemCTPX_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaPhieuXuat.Text))
            {
                using (var form = new FormChiTietPhieuXuat(Convert.ToInt32(txtMaPhieuXuat.Text)))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadChiTietPhieuXuat(Convert.ToInt32(txtMaPhieuXuat.Text));
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu xuất trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSuaCTPX_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuXuat.SelectedRows.Count > 0)
            {
                int maChiTiet = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["MaChiTietXuat"].Value);
                int maSanPham = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["MaSanPham"].Value);
                int soLuongCu = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["SoLuong"].Value);

                using (var form = new FormChiTietPhieuXuat(Convert.ToInt32(txtMaPhieuXuat.Text), maChiTiet))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật số lượng tồn kho
                        int soLuongMoi = GetSoLuongMoi(maChiTiet);
                        UpdateSoLuongTonKho(maSanPham, soLuongCu - soLuongMoi); // Điều chỉnh số lượng tồn kho
                        LoadChiTietPhieuXuat(Convert.ToInt32(txtMaPhieuXuat.Text));
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết phiếu xuất để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetSoLuongMoi(int maChiTiet)
        {
            string query = "SELECT SoLuong FROM ChiTietPhieuXuat WHERE MaChiTietXuat = @MaChiTietXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietXuat", maChiTiet);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void btnXoaCTPX_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuXuat.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chi tiết phiếu xuất này? Số lượng tồn kho sẽ được cập nhật.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int maChiTiet = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["MaChiTietXuat"].Value);
                    int maSanPham = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["MaSanPham"].Value);
                    int soLuong = Convert.ToInt32(dgvChiTietPhieuXuat.SelectedRows[0].Cells["SoLuong"].Value);

                    if (DeleteChiTietPhieuXuat(maChiTiet))
                    {
                        UpdateSoLuongTonKho(maSanPham, soLuong); // Tăng số lượng tồn kho
                        MessageBox.Show("Xóa chi tiết phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadChiTietPhieuXuat(Convert.ToInt32(txtMaPhieuXuat.Text));
                    }
                    else
                    {
                        MessageBox.Show("Xóa chi tiết phiếu xuất thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một chi tiết phiếu xuất để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool DeleteChiTietPhieuXuat(int maChiTiet)
        {
            string query = "DELETE FROM ChiTietPhieuXuat WHERE MaChiTietXuat = @MaChiTietXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietXuat", maChiTiet);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void UpdateSoLuongTonKho(int maSanPham, int soLuong)
        {
            string query = "UPDATE SanPham SET SoLuongTonKho = SoLuongTonKho + @SoLuong WHERE MaSanPham = @MaSanPham";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool ValidatePhieuXuatInput()
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
                SELECT PX.MaPhieuXuat, PX.NgayXuat, PX.MaNhanVien, PX.GhiChu, NV.HoTen AS TenNhanVien
                FROM PhieuXuatKho PX
                LEFT JOIN NhanVien NV ON PX.MaNhanVien = NV.MaNV
                WHERE 1=1";
            if (radMaPhieuXuat.Checked && !string.IsNullOrEmpty(txt_timMaPhieuXuat.Text))
            {
                query += " AND PX.MaPhieuXuat = @MaPhieuXuat";
            }
            if (radNgayXuat.Checked)
            {
                query += " AND CAST(PX.NgayXuat AS DATE) = @NgayXuat";
            }
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    if (radMaPhieuXuat.Checked && !string.IsNullOrEmpty(txt_timMaPhieuXuat.Text))
                    {
                        if (!int.TryParse(txt_timMaPhieuXuat.Text, out int maPhieuXuat))
                        {
                            MessageBox.Show("Mã phiếu xuất phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    }
                    if (radNgayXuat.Checked)
                    {
                        cmd.Parameters.AddWithValue("@NgayXuat", dtp_timNgayXuat.Value.Date);
                    }
                    conn.Open();
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        dtPhieuXuat = new DataTable();
                        da.Fill(dtPhieuXuat);
                        dgvPhieuXuat.DataSource = dtPhieuXuat;
                        lblTongPhieuXuat.Text = dtPhieuXuat.Rows.Count.ToString();
                        currentIndex = dtPhieuXuat.Rows.Count > 0 ? 0 : -1;
                        if (currentIndex >= 0)
                        {
                            DisplayPhieuXuat(currentIndex);
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
            LoadPhieuXuatKho();
            ClearInputFields();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadPhieuXuatKho();
            ClearInputFields();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dtPhieuXuat.Rows.Count > 0)
            {
                currentIndex = 0;
                DisplayPhieuXuat(currentIndex);
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayPhieuXuat(currentIndex);
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dtPhieuXuat.Rows.Count - 1)
            {
                currentIndex++;
                DisplayPhieuXuat(currentIndex);
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dtPhieuXuat.Rows.Count > 0)
            {
                currentIndex = dtPhieuXuat.Rows.Count - 1;
                DisplayPhieuXuat(currentIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Thoát
        {
            this.Close();
        }

        private void dgvPhieuXuat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuXuat.SelectedRows.Count > 0)
            {
                currentIndex = dgvPhieuXuat.SelectedRows[0].Index;
                DisplayPhieuXuat(currentIndex);
            }
        }
    }
}