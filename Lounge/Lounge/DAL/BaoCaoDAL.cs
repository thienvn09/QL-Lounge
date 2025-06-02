using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Lounge.Model; // Đảm bảo bạn có Model.BaoCao và Model.NhanVien

namespace Lounge.DAL // Hoặc namespace NhaHang.DAL của bạn
{
    public class BaoCaoDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public List<BaoCao> GetAllBaoCao()
        {
            List<BaoCao> dsBaoCao = new List<BaoCao>();
            string query = @"
                SELECT 
                    bc.MaBaoCao, bc.LoaiBaoCao, bc.NgayBaoCao, 
                    bc.TongDoanhThu, bc.TongChiPhi, bc.LoiNhuan,
                    bc.SoHoaDon, bc.SoKhachHang, bc.SoSanPhamBanRa,
                    bc.NguoiTao, nv.HoTen AS TenNguoiTao, bc.GhiChu
                FROM BaoCao bc
                LEFT JOIN NhanVien nv ON bc.NguoiTao = nv.MaNV
                ORDER BY bc.NgayBaoCao DESC, bc.MaBaoCao DESC";

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BaoCao bc = new BaoCao
                                {
                                    MaBaoCao = reader.GetInt32(reader.GetOrdinal("MaBaoCao")),
                                    LoaiBaoCao = reader.GetString(reader.GetOrdinal("LoaiBaoCao")),
                                    NgayBaoCao = reader.GetDateTime(reader.GetOrdinal("NgayBaoCao")),
                                    TongDoanhThu = reader.GetDecimal(reader.GetOrdinal("TongDoanhThu")),
                                    TongChiPhi = reader.GetDecimal(reader.GetOrdinal("TongChiPhi")),
                                    LoiNhuan = reader.GetDecimal(reader.GetOrdinal("LoiNhuan")), // Cột tính toán
                                    SoHoaDon = reader.GetInt32(reader.GetOrdinal("SoHoaDon")),
                                    SoKhachHang = reader.GetInt32(reader.GetOrdinal("SoKhachHang")),
                                    SoSanPhamBanRa = reader.GetInt32(reader.GetOrdinal("SoSanPhamBanRa")),
                                    NguoiTao = reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("NguoiTao")),
                                    TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao")),
                                    GhiChu = reader.GetString(reader.GetOrdinal("GhiChu"))
                                };
                                dsBaoCao.Add(bc);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] GetAllBaoCao: {ex.Message}");
                    // throw; 
                }
            }
            return dsBaoCao;
        }

        public bool AddBaoCao(BaoCao baoCao)
        {
            // Thông thường báo cáo được tạo tự động, hàm này có thể dùng cho việc nhập thủ công nếu cần
            string query = @"
                INSERT INTO BaoCao (LoaiBaoCao, NgayBaoCao, TongDoanhThu, TongChiPhi, 
                                    SoHoaDon, SoKhachHang, SoSanPhamBanRa, NguoiTao, GhiChu)
                VALUES (@LoaiBaoCao, @NgayBaoCao, @TongDoanhThu, @TongChiPhi, 
                        @SoHoaDon, @SoKhachHang, @SoSanPhamBanRa, @NguoiTao, @GhiChu)";
            int result = 0;
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@LoaiBaoCao", baoCao.LoaiBaoCao);
                        cmd.Parameters.AddWithValue("@NgayBaoCao", baoCao.NgayBaoCao);
                        cmd.Parameters.AddWithValue("@TongDoanhThu", baoCao.TongDoanhThu);
                        cmd.Parameters.AddWithValue("@TongChiPhi", baoCao.TongChiPhi);
                        cmd.Parameters.AddWithValue("@SoHoaDon", baoCao.SoHoaDon);
                        cmd.Parameters.AddWithValue("@SoKhachHang", baoCao.SoKhachHang);
                        cmd.Parameters.AddWithValue("@SoSanPhamBanRa", baoCao.SoSanPhamBanRa);
                        cmd.Parameters.AddWithValue("@NguoiTao", (object)baoCao.NguoiTao ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@GhiChu", baoCao.GhiChu);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] AddBaoCao: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool UpdateBaoCao(BaoCao baoCao)
        {
            // Cập nhật báo cáo (thường ít khi sửa báo cáo đã tạo, nhưng vẫn cung cấp)
            string query = @"
                UPDATE BaoCao 
                SET LoaiBaoCao = @LoaiBaoCao, NgayBaoCao = @NgayBaoCao, 
                    TongDoanhThu = @TongDoanhThu, TongChiPhi = @TongChiPhi,
                    SoHoaDon = @SoHoaDon, SoKhachHang = @SoKhachHang, 
                    SoSanPhamBanRa = @SoSanPhamBanRa, NguoiTao = @NguoiTao, GhiChu = @GhiChu
                WHERE MaBaoCao = @MaBaoCao";
            int result = 0;
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaBaoCao", baoCao.MaBaoCao);
                        cmd.Parameters.AddWithValue("@LoaiBaoCao", baoCao.LoaiBaoCao);
                        cmd.Parameters.AddWithValue("@NgayBaoCao", baoCao.NgayBaoCao);
                        cmd.Parameters.AddWithValue("@TongDoanhThu", baoCao.TongDoanhThu);
                        cmd.Parameters.AddWithValue("@TongChiPhi", baoCao.TongChiPhi);
                        cmd.Parameters.AddWithValue("@SoHoaDon", baoCao.SoHoaDon);
                        cmd.Parameters.AddWithValue("@SoKhachHang", baoCao.SoKhachHang);
                        cmd.Parameters.AddWithValue("@SoSanPhamBanRa", baoCao.SoSanPhamBanRa);
                        cmd.Parameters.AddWithValue("@NguoiTao", (object)baoCao.NguoiTao ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@GhiChu", baoCao.GhiChu);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] UpdateBaoCao: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool DeleteBaoCao(int maBaoCao)
        {
            string query = "DELETE FROM BaoCao WHERE MaBaoCao = @MaBaoCao";
            int result = 0;
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] DeleteBaoCao: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool TaoBaoCaoTuDong(string loaiBaoCao, DateTime ngayBaoCao, int maNguoiTao)
        {
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_TaoBaoCaoTuDong", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);
                        cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao.Date); // Chỉ lấy phần ngày
                        cmd.Parameters.AddWithValue("@NguoiTao", maNguoiTao);

                        // Thêm tham số đầu ra để bắt giá trị trả về từ Stored Procedure (nếu có)
                        // SqlParameter returnValue = new SqlParameter();
                        // returnValue.Direction = ParameterDirection.ReturnValue;
                        // cmd.Parameters.Add(returnValue);

                        cmd.ExecuteNonQuery();

                        // int spReturn = (int)returnValue.Value;
                        // return spReturn == 0; // Giả sử SP trả về 0 nếu thành công
                        return true; // Giả sử thành công nếu không có exception
                    }
                }
                catch (SqlException sqlEx) // Bắt lỗi SQL cụ thể, ví dụ lỗi từ RAISERROR trong SP
                {
                    Console.WriteLine($"[DATABASE ERROR] TaoBaoCaoTuDong (SQL): {sqlEx.Message}");
                    MessageBox.Show($"Lỗi từ CSDL khi tạo báo cáo: {sqlEx.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] TaoBaoCaoTuDong (General): {ex.Message}");
                    MessageBox.Show($"Lỗi không xác định khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
