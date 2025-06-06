using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model; // Đảm bảo bạn đã có Model.Voucher, Model.KhachHang, Model.SanPham

namespace Lounge.DAL // Hoặc namespace NhaHang.DAL của bạn
{
    public class VoucherDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public List<Voucher> GetAllVouchers()
        {
            List<Voucher> dsVoucher = new List<Voucher>();
            string query = @"
                SELECT 
                    v.MaVoucher, v.MaKhachHang, kh.HoTen AS TenKhachHang,
                    v.MaSanPham, sp.TenSanPham AS TenSanPham,
                    v.GiaTri, v.NgayHetHan, v.TrangThai
                FROM Voucher v
                LEFT JOIN KhachHang kh ON v.MaKhachHang = kh.MaKhachHang
                LEFT JOIN SanPham sp ON v.MaSanPham = sp.MaSanPham
                ORDER BY v.NgayHetHan DESC, v.MaVoucher DESC"; // Sắp xếp theo ngày hết hạn, voucher mới nhất

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
                                Voucher v = new Voucher
                                {
                                    MaVoucher = reader.GetInt32(reader.GetOrdinal("MaVoucher")),
                                    MaKhachHang = reader.IsDBNull(reader.GetOrdinal("MaKhachHang")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "Áp dụng chung" : reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                    MaSanPham = reader.IsDBNull(reader.GetOrdinal("MaSanPham")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                    TenSanPham = reader.IsDBNull(reader.GetOrdinal("TenSanPham")) ? "Toàn bộ hóa đơn" : reader.GetString(reader.GetOrdinal("TenSanPham")),
                                    GiaTri = (float)reader.GetDecimal(reader.GetOrdinal("GiaTri")),
                                    NgayHetHan = reader.IsDBNull(reader.GetOrdinal("NgayHetHan")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgayHetHan")),
                                    TrangThai = reader.GetString(reader.GetOrdinal("TrangThai"))
                                };
                                dsVoucher.Add(v);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] GetAllVouchers: {ex.Message}");
                    // Cân nhắc throw lại lỗi nếu muốn tầng trên xử lý
                    // throw; 
                }
            }
            return dsVoucher;
        }

        public Voucher GetVoucherById(int maVoucher)
        {
            Voucher voucher = null;
            string query = @"
                SELECT 
                    v.MaVoucher, v.MaKhachHang, kh.HoTen AS TenKhachHang,
                    v.MaSanPham, sp.TenSanPham AS TenSanPham,
                    v.GiaTri, v.NgayHetHan, v.TrangThai
                FROM Voucher v
                LEFT JOIN KhachHang kh ON v.MaKhachHang = kh.MaKhachHang
                LEFT JOIN SanPham sp ON v.MaSanPham = sp.MaSanPham
                WHERE v.MaVoucher = @MaVoucher";

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaVoucher", maVoucher);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                voucher = new Voucher
                                {
                                    MaVoucher = reader.GetInt32(reader.GetOrdinal("MaVoucher")),
                                    MaKhachHang = reader.IsDBNull(reader.GetOrdinal("MaKhachHang")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "Áp dụng chung" : reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                    MaSanPham = reader.IsDBNull(reader.GetOrdinal("MaSanPham")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                    TenSanPham = reader.IsDBNull(reader.GetOrdinal("TenSanPham")) ? "Toàn bộ hóa đơn" : reader.GetString(reader.GetOrdinal("TenSanPham")),
                                    GiaTri = (float)reader.GetDecimal(reader.GetOrdinal("GiaTri")),
                                    NgayHetHan = reader.IsDBNull(reader.GetOrdinal("NgayHetHan")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("NgayHetHan")),
                                    TrangThai = reader.GetString(reader.GetOrdinal("TrangThai"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] GetVoucherById ({maVoucher}): {ex.Message}");
                    // throw;
                }
            }
            return voucher;
        }

        public bool AddVoucher(Voucher voucher)
        {
            string query = @"
                INSERT INTO Voucher (MaKhachHang, MaSanPham, GiaTri, NgayHetHan, TrangThai) 
                VALUES (@MaKhachHang, @MaSanPham, @GiaTri, @NgayHetHan, @TrangThai)";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", (object)voucher.MaKhachHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaSanPham", (object)voucher.MaSanPham ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@GiaTri", voucher.GiaTri);
                        cmd.Parameters.AddWithValue("@NgayHetHan", (object)voucher.NgayHetHan ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", voucher.TrangThai);

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] AddVoucher: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool UpdateVoucher(Voucher voucher)
        {
            string query = @"
                UPDATE Voucher 
                SET MaKhachHang = @MaKhachHang, MaSanPham = @MaSanPham, GiaTri = @GiaTri, 
                    NgayHetHan = @NgayHetHan, TrangThai = @TrangThai
                WHERE MaVoucher = @MaVoucher";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaVoucher", voucher.MaVoucher);
                        cmd.Parameters.AddWithValue("@MaKhachHang", (object)voucher.MaKhachHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaSanPham", (object)voucher.MaSanPham ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@GiaTri", voucher.GiaTri);
                        cmd.Parameters.AddWithValue("@NgayHetHan", (object)voucher.NgayHetHan ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TrangThai", voucher.TrangThai);

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] UpdateVoucher ({voucher.MaVoucher}): {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool DeleteVoucher(int maVoucher)
        {
            // Cân nhắc: Thay vì xóa, có thể chỉ cập nhật trạng thái thành "Đã hủy" hoặc "Không hợp lệ"
            string query = "DELETE FROM Voucher WHERE MaVoucher = @MaVoucher";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaVoucher", maVoucher);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) // Bắt lỗi SQL, ví dụ lỗi khóa ngoại nếu voucher đang được tham chiếu ở đâu đó (ít khả năng)
                {
                    Console.WriteLine($"[DATABASE ERROR] DeleteVoucher (SQL) ({maVoucher}): {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] DeleteVoucher (General) ({maVoucher}): {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        // Có thể thêm các hàm khác nếu cần, ví dụ:
        // - Lấy voucher theo khách hàng
        // - Lấy voucher theo sản phẩm
        // - Lấy các voucher còn hạn sử dụng
        // - Cập nhật trạng thái voucher (ví dụ: từ "Chưa sử dụng" sang "Đã sử dụng")
        public bool CapNhatTrangThaiVoucher(int maVoucher, string trangThaiMoi)
        {
            string query = "UPDATE Voucher SET TrangThai = @TrangThai WHERE MaVoucher = @MaVoucher";
            int result = 0;
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                        cmd.Parameters.AddWithValue("@MaVoucher", maVoucher);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] CapNhatTrangThaiVoucher ({maVoucher}): {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }
       
    }
}
