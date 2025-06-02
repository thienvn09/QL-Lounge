using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class FormChiTietPhieuXuat : Form
    {
        private ChiTietPhieuXuatDAL chiTietPhieuXuatDAL = new ChiTietPhieuXuatDAL();
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private int maPhieuXuat;
        private int? maChiTietXuat;

        public FormChiTietPhieuXuat(int maPhieuXuat, int? maChiTietXuat = null)
        {
            this.maPhieuXuat = maPhieuXuat;
            this.maChiTietXuat = maChiTietXuat;
            InitializeComponent();
        }

        private void FormChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadSanPhamComboBox();
            if (maChiTietXuat.HasValue)
            {
                LoadChiTietPhieuXuat(maChiTietXuat.Value);
            }
        }

        private void LoadSanPhamComboBox()
        {
            cboxMaSanPham.DataSource = sanPhamDAL.GetAllSanPham();
            cboxMaSanPham.DisplayMember = "TenSanPham";
            cboxMaSanPham.ValueMember = "MaSanPham";
            cboxMaSanPham.SelectedIndex = -1;
        }

        private void LoadChiTietPhieuXuat(int maChiTiet)
        {
            string query = "SELECT MaSanPham, SoLuong FROM ChiTietPhieuXuat WHERE MaChiTietXuat = @MaChiTietXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietXuat", maChiTiet);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cboxMaSanPham.SelectedValue = reader.GetInt32(0);
                            txtSoLuong.Text = reader.GetInt32(1).ToString();
                        }
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var ctx = new ChiTietPhieuXuat
                {
                    MaPhieuXuat = maPhieuXuat,
                    MaSanPham = Convert.ToInt32(cboxMaSanPham.SelectedValue),
                    SoLuong = Convert.ToInt32(txtSoLuong.Text)
                };

                // Kiểm tra số lượng tồn kho
                int soLuongTonKho = GetSoLuongTonKho(ctx.MaSanPham);
                int soLuongCu = maChiTietXuat.HasValue ? GetSoLuongMoi(maChiTietXuat.Value) : 0;
                int soLuongThayDoi = ctx.SoLuong - soLuongCu;
                if (soLuongTonKho < soLuongThayDoi)
                {
                    MessageBox.Show("Số lượng xuất vượt quá số lượng tồn kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success;
                if (maChiTietXuat.HasValue)
                {
                    ctx.MaChiTietXuat = maChiTietXuat.Value;
                    success = UpdateChiTietPhieuXuat(ctx);
                }
                else
                {
                    success = chiTietPhieuXuatDAL.AddChiTietPhieuXuat(ctx);
                }

                if (success)
                {
                    // Cập nhật số lượng tồn kho
                    UpdateSoLuongTonKho(ctx.MaSanPham, -soLuongThayDoi);
                    MessageBox.Show("Lưu chi tiết phiếu xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu chi tiết phiếu xuất thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UpdateChiTietPhieuXuat(ChiTietPhieuXuat ctx)
        {
            string query = @"
                UPDATE ChiTietPhieuXuat 
                SET MaSanPham = @MaSanPham, SoLuong = @SoLuong
                WHERE MaChiTietXuat = @MaChiTietXuat";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietXuat", ctx.MaChiTietXuat);
                    cmd.Parameters.AddWithValue("@MaSanPham", ctx.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", ctx.SoLuong);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private int GetSoLuongTonKho(int maSanPham)
        {
            string query = "SELECT SoLuongTonKho FROM SanPham WHERE MaSanPham = @MaSanPham";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    conn.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        private bool ValidateInput()
        {
            if (cboxMaSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text) || !int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}