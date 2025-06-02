using Lounge.DAL;
using Lounge.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormChiTietPhieuNhapKho : Form
    {
        private readonly int maPhieuNhap;
        private readonly int? maChiTietPhieuNhap; // null nếu thêm mới, có giá trị nếu sửa
        private readonly ChiTietPhieuNhapKhoDAL chiTietDAL = new ChiTietPhieuNhapKhoDAL();
        private readonly SanPhamDAL sanPhamDAL = new SanPhamDAL();

        public FormChiTietPhieuNhapKho(int maPhieuNhap, int? maChiTietPhieuNhap = null)
        {
            InitializeComponent();
            this.maPhieuNhap = maPhieuNhap;
            this.maChiTietPhieuNhap = maChiTietPhieuNhap;
        }

        private void FormChiTietPhieuNhapKho_Load(object sender, EventArgs e)
        {
            LoadSanPhamComboBox();
            if (maChiTietPhieuNhap.HasValue)
            {
                LoadChiTietPhieuNhap();
                labelTitle.Text = "SỬA CHI TIẾT PHIẾU NHẬP KHO";
            }
            else
            {
                labelTitle.Text = "THÊM CHI TIẾT PHIẾU NHẬP KHO";
            }
        }

        private void LoadSanPhamComboBox()
        {
            var sanPhams = sanPhamDAL.GetAllSP();
            cboxMaSanPham.DataSource = sanPhams;
            cboxMaSanPham.DisplayMember = "TenSanPham";
            cboxMaSanPham.ValueMember = "MaSanPham";
            cboxMaSanPham.SelectedIndex = -1;
        }

        private void LoadChiTietPhieuNhap()
        {
            string query = "SELECT MaSanPham, SoLuong, DonGia FROM ChiTietPhieuNhapKho WHERE MaChiTietPhieuNhap = @MaChiTietPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietPhieuNhap", maChiTietPhieuNhap.Value);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cboxMaSanPham.SelectedValue = reader.GetInt32(0);
                            txtSoLuong.Text = reader.GetInt32(1).ToString();
                            txtDonGia.Text = reader.GetDecimal(2).ToString();
                        }
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var ctpn = new ChiTietPhieuNhapKho
                {
                    MaPhieuNhap = maPhieuNhap,
                    MaSanPham = Convert.ToInt32(cboxMaSanPham.SelectedValue),
                    SoLuong = Convert.ToInt32(txtSoLuong.Text),
                    DonGia = Convert.ToDecimal(txtDonGia.Text),
                    ThanhTien = Convert.ToInt32(txtSoLuong.Text) * Convert.ToDecimal(txtDonGia.Text)
                };

                bool success;
                if (maChiTietPhieuNhap.HasValue)
                {
                    ctpn.MaChiTietPhieuNhap = maChiTietPhieuNhap.Value;
                    success = UpdateChiTietPhieuNhapKho(ctpn);
                }
                else
                {
                    success = chiTietDAL.AddChiTietPhieuNhapKho(ctpn);
                }

                if (success)
                {
                    // Cập nhật số lượng tồn kho
                    UpdateSoLuongTonKho(ctpn.MaSanPham, ctpn.SoLuong);
                    MessageBox.Show("Lưu chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lưu chi tiết phiếu nhập thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool UpdateChiTietPhieuNhapKho(ChiTietPhieuNhapKho ctpn)
        {
            string query = @"
                UPDATE ChiTietPhieuNhapKho 
                SET MaSanPham = @MaSanPham, SoLuong = @SoLuong, DonGia = @DonGia, ThanhTien = @ThanhTien
                WHERE MaChiTietPhieuNhap = @MaChiTietPhieuNhap";
            using (var conn = new KetNoi().GetConnect())
            {
                using (var cmd = new System.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietPhieuNhap", ctpn.MaChiTietPhieuNhap);
                    cmd.Parameters.AddWithValue("@MaSanPham", ctpn.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", ctpn.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", ctpn.DonGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", ctpn.ThanhTien);
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

        private bool ValidateInput()
        {
            if (cboxMaSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải là số lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}