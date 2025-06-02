using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class ChiTietHoaDonDAL
    {
        private readonly KetNoi ketNoi = new KetNoi();

        // Thêm một chi tiết hóa đơn
        public void ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = @"
                INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, Gia, ThueVAT)
                VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @Gia, @ThueVAT)";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", chiTiet.MaHoaDon);
                        cmd.Parameters.AddWithValue("@MaSanPham", chiTiet.MaSanPham);
                        cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                        cmd.Parameters.AddWithValue("@Gia", chiTiet.Gia);
                        cmd.Parameters.AddWithValue("@ThueVAT", chiTiet.ThueVAT);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi ThemChiTietHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi thêm chi tiết hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Cập nhật số lượng chi tiết hóa đơn
        public void CapNhatSoLuongChiTietHoaDon(int maHoaDon, int maSanPham, int soLuongMoi)
        {
            string query = @"
                UPDATE ChiTietHoaDon 
                SET SoLuong = @SoLuong 
                WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoLuong", soLuongMoi);
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi CapNhatSoLuongChiTietHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi cập nhật số lượng chi tiết hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Kiểm tra sản phẩm đã có trong hóa đơn chưa
        public ChiTietHoaDon KiemTraSanPhamTrongHoaDon(int maHoaDon, int maSanPham)
        {
            string query = @"
                SELECT * FROM ChiTietHoaDon 
                WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ChiTietHoaDon
                                {
                                    MaChiTietHoaDon = Convert.ToInt32(reader["MaChiTietHoaDon"]),
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    Gia = (float)Convert.ToDecimal(reader["Gia"]), // Chú ý kiểu dữ liệu
                                    ThueVAT = (float)Convert.ToDecimal(reader["ThueVAT"]), // Chú ý kiểu dữ liệu
                                    TienThue = (float)(reader["TienThue"] != DBNull.Value ? Convert.ToDecimal(reader["TienThue"]) : 0m), // Chú ý kiểu dữ liệu
                                    ThanhTien = (float)(reader["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(reader["ThanhTien"]) : 0m) // Chú ý kiểu dữ liệu
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi KiemTraSanPhamTrongHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi kiểm tra sản phẩm trong hóa đơn: {ex.Message}", ex);
                }
            }
            return null;
        }

        // Lấy danh sách chi tiết hóa đơn theo MaHoaDon
        public List<ChiTietHoaDon> LayChiTietHoaDonTheoMaHoaDon(int maHoaDon)
        {
            List<ChiTietHoaDon> dsChiTiet = new List<ChiTietHoaDon>();
            string query = @"
                SELECT c.*, s.TenSanPham 
                FROM ChiTietHoaDon c 
                JOIN SanPham s ON c.MaSanPham = s.MaSanPham 
                WHERE c.MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dsChiTiet.Add(new ChiTietHoaDon
                                {
                                    MaChiTietHoaDon = Convert.ToInt32(reader["MaChiTietHoaDon"]),
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    Gia = (float)Convert.ToDecimal(reader["Gia"]), // Chú ý kiểu dữ liệu
                                    ThueVAT = (float)Convert.ToDecimal(reader["ThueVAT"]), // Chú ý kiểu dữ liệu
                                    TienThue = (float)(reader["TienThue"] != DBNull.Value ? Convert.ToDecimal(reader["TienThue"]) : 0m), // Chú ý kiểu dữ liệu
                                    ThanhTien = (float)(reader["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(reader["ThanhTien"]) : 0m), // Chú ý kiểu dữ liệu
                                    TenSanPham = reader["TenSanPham"].ToString()
                                });
                            }
                        }
                    }
                    // Console.WriteLine($"LayChiTietHoaDonTheoMaHoaDon: Tìm thấy {dsChiTiet.Count} chi tiết cho MaHoaDon = {maHoaDon}");
                    return dsChiTiet;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi LayChiTietHoaDonTheoMaHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi lấy chi tiết hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Xóa tất cả chi tiết hóa đơn theo MaHoaDon
        public int XoaTatCaChiTietTheoMaHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            int rowsAffected = 0;

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi XoaTatCaChiTietTheoMaHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    // Bạn có thể throw exception ở đây nếu muốn lan truyền lỗi lên tầng trên
                    // throw new Exception($"Lỗi khi xóa chi tiết hóa đơn: {ex.Message}", ex);
                }
            }
            return rowsAffected; // Trả về số dòng đã bị ảnh hưởng (đã xóa)
        }
    }
}