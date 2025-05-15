using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class HoaDonDAL
    {
        private readonly KetNoi ketNoi = new KetNoi();

        // Thêm hóa đơn mới và trả về mã hóa đơn vừa tạo
        public int ThemHoaDon(HoaDon hoaDon)
        {
            string query = @"
                INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, NguoiTao)
                VALUES (@MaKhachHang, @MaNhanVien, @MaBan, @NgayDat, @TongTien, @TienGiamGia, @TongThueVAT, @NguoiTao);
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                        cmd.Parameters.AddWithValue("@MaNhanVien", (object)hoaDon.MaNhanVien ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaBan", (object)hoaDon.MaBan ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgayDat", hoaDon.NgayDat);
                        cmd.Parameters.AddWithValue("@TongTien", (object)hoaDon.TongTien ?? 0m);
                        cmd.Parameters.AddWithValue("@TienGiamGia", (object)hoaDon.TienGiamGia ?? 0m);
                        cmd.Parameters.AddWithValue("@TongThueVAT", (object)hoaDon.TongThueVAT ?? 0m);
                        cmd.Parameters.AddWithValue("@NguoiTao", (object)hoaDon.NguoiTao ?? DBNull.Value);

                        object result = cmd.ExecuteScalar();
                        if (result == null || result == DBNull.Value)
                        {
                            throw new Exception("Không thể lấy mã hóa đơn sau khi thêm.");
                        }
                        int maHoaDon = Convert.ToInt32(result);
                        Console.WriteLine($"ThemHoaDon: Tạo hóa đơn mới với MaHoaDon = {maHoaDon}");
                        return maHoaDon;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi ThemHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi thêm hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Cập nhật trạng thái hóa đơn
        public void CapNhatTrangThaiHoaDon(int maHoaDon, string trangThai)
        {
            string query = "UPDATE HoaDon SET TrangThai = @TrangThai WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi CapNhatTrangThaiHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi cập nhật trạng thái hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Lấy danh sách hóa đơn theo mã bàn (chưa thanh toán)
        public List<HoaDon> LayHoaDonTheoMaBan(int maBan)
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();
            string query = "SELECT * FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Chưa thanh toán'";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBan", maBan);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dsHoaDon.Add(new HoaDon
                                {
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaKhachHang = Convert.ToInt32(reader["MaKhachHang"]),
                                    MaNhanVien = (int)(reader["MaNhanVien"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaNhanVien"]) : null),
                                    MaBan = (int)(reader["MaBan"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaBan"]) : null),
                                    NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                                    TongTien = (int)(reader["TongTien"] != DBNull.Value ? Convert.ToDecimal(reader["TongTien"]) : 0m),
                                    TienGiamGia = (int)(reader["TienGiamGia"] != DBNull.Value ? Convert.ToDecimal(reader["TienGiamGia"]) : 0m),
                                    TongThueVAT = (int)(reader["TongThueVAT"] != DBNull.Value ? Convert.ToDecimal(reader["TongThueVAT"]) : 0m),
                                    ThanhToan = (int)(reader["ThanhToan"] != DBNull.Value ? Convert.ToDecimal(reader["ThanhToan"]) : 0m),
                                    NguoiTao = (int)(reader["NguoiTao"] != DBNull.Value ? (int?)Convert.ToInt32(reader["NguoiTao"]) : null),
                                    TrangThai = reader["TrangThai"] != DBNull.Value ? reader["TrangThai"].ToString() : null
                                });
                            }
                        }
                    }
                    Console.WriteLine($"LayHoaDonTheoMaBan: Tìm thấy {dsHoaDon.Count} hóa đơn cho MaBan = {maBan}");
                    return dsHoaDon;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi LayHoaDonTheoMaBan: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi lấy hóa đơn theo mã bàn {maBan}: {ex.Message}", ex);
                }
            }
        }

        // Lấy chi tiết hóa đơn theo mã hóa đơn
        public HoaDon LayHoaDonTheoMaHoaDon(int maHoaDon)
        {
            HoaDon hoaDon = null;
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";

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
                            if (reader.Read())
                            {
                                hoaDon = new HoaDon
                                {
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaKhachHang = Convert.ToInt32(reader["MaKhachHang"]),
                                    MaNhanVien =(int)( reader["MaNhanVien"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaNhanVien"]) : null),
                                    MaBan = (int)(reader["MaBan"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaBan"]) : null),
                                    NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                                    TongTien =  (int)(reader["TongTien"] != DBNull.Value ? Convert.ToDecimal(reader["TongTien"]) : 0m),
                                    TienGiamGia = (int)(reader["TienGiamGia"] != DBNull.Value ? Convert.ToDecimal(reader["TienGiamGia"]) : 0m),
                                    TongThueVAT = (int)(reader["TongThueVAT"] != DBNull.Value ? Convert.ToDecimal(reader["TongThueVAT"]) : 0m),
                                    ThanhToan = (int)(reader["ThanhToan"] != DBNull.Value ? Convert.ToDecimal(reader["ThanhToan"]) : 0m),
                                    NguoiTao = (int)(reader["NguoiTao"] != DBNull.Value ? (int?)Convert.ToInt32(reader["NguoiTao"]) : null),
                                    TrangThai = reader["TrangThai"] != DBNull.Value ? reader["TrangThai"].ToString() : null
                                };
                            }
                        }
                    }
                    return hoaDon;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi LayHoaDonTheoMaHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi lấy hóa đơn theo mã hóa đơn: {ex.Message}", ex);
                }
            }
        }

        // Cập nhật tổng tiền và thuế VAT cho hóa đơn
        public void CapNhatTongTienHoaDon(int maHoaDon)
        {
            string querySum = @"
                SELECT 
                    ISNULL(SUM(ThanhTien), 0) AS TongTien, 
                    ISNULL(SUM(TienThue), 0) AS TongThueVAT 
                FROM ChiTietHoaDon 
                WHERE MaHoaDon = @MaHoaDon";

            string queryUpdate = @"
                UPDATE HoaDon
                SET TongTien = @TongTien, TongThueVAT = @TongThueVAT
                WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                try
                {
                    conn.Open();
                    decimal tongTien = 0, tongThueVAT = 0;

                    // Tính tổng
                    using (SqlCommand cmdSum = new SqlCommand(querySum, conn))
                    {
                        cmdSum.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        using (SqlDataReader reader = cmdSum.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tongTien = Convert.ToDecimal(reader["TongTien"]);
                                tongThueVAT = Convert.ToDecimal(reader["TongThueVAT"]);
                            }
                        }
                    }

                    // Cập nhật tổng
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@TongTien", tongTien);
                        cmdUpdate.Parameters.AddWithValue("@TongThueVAT", tongThueVAT);
                        cmdUpdate.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi CapNhatTongTienHoaDon: {ex.Message}\nStackTrace: {ex.StackTrace}");
                    throw new Exception($"Lỗi khi cập nhật tổng tiền hóa đơn: {ex.Message}", ex);
                }
            }
        }
        public DataTable GetAllHoaDon()
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaHoaDon, MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, ThanhToan, TrangThai, NguoiTao FROM HoaDon";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AddHoaDon(HoaDon hd)
        {
            string query = @"INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, ThanhToan, TrangThai, NguoiTao)
                            VALUES (@MaKhachHang, @MaNhanVien, @MaBan, @NgayDat, @TongTien, @TienGiamGia, @TongThueVAT, @ThanhToan, @TrangThai, @NguoiTao)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", hd.MaKhachHang);
                    cmd.Parameters.AddWithValue("@MaNhanVien", (object)hd.MaNhanVien ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaBan", (object)hd.MaBan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayDat", hd.NgayDat);
                    cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                    cmd.Parameters.AddWithValue("@TienGiamGia", hd.TienGiamGia);
                    cmd.Parameters.AddWithValue("@TongThueVAT", hd.TongThueVAT);
                    cmd.Parameters.AddWithValue("@ThanhToan", hd.ThanhToan);
                    cmd.Parameters.AddWithValue("@TrangThai", hd.TrangThai);
                    cmd.Parameters.AddWithValue("@NguoiTao", (object)hd.NguoiTao ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateHoaDon(HoaDon hd)
        {
            string query = @"UPDATE HoaDon 
                            SET MaKhachHang = @MaKhachHang, MaNhanVien = @MaNhanVien, MaBan = @MaBan, 
                                NgayDat = @NgayDat, TongTien = @TongTien, TienGiamGia = @TienGiamGia, 
                                TongThueVAT = @TongThueVAT, ThanhToan = @ThanhToan, TrangThai = @TrangThai, 
                                NguoiTao = @NguoiTao
                            WHERE MaHoaDon = @MaHoaDon";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", hd.MaHoaDon);
                    cmd.Parameters.AddWithValue("@MaKhachHang", hd.MaKhachHang);
                    cmd.Parameters.AddWithValue("@MaNhanVien", (object)hd.MaNhanVien ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaBan", (object)hd.MaBan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayDat", hd.NgayDat);
                    cmd.Parameters.AddWithValue("@TongTien", hd.TongTien);
                    cmd.Parameters.AddWithValue("@TienGiamGia", hd.TienGiamGia);
                    cmd.Parameters.AddWithValue("@TongThueVAT", hd.TongThueVAT);
                    cmd.Parameters.AddWithValue("@ThanhToan", hd.ThanhToan);
                    cmd.Parameters.AddWithValue("@TrangThai", hd.TrangThai);
                    cmd.Parameters.AddWithValue("@NguoiTao", (object)hd.NguoiTao ?? DBNull.Value);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    

        // Thêm chi tiết hóa đơn
        public bool AddChiTietHoaDon(ChiTietHoaDon cthd)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"
                    INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, Gia, ThueVAT)
                    VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @Gia, @ThueVAT)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", cthd.MaHoaDon);
                    cmd.Parameters.AddWithValue("@MaSanPham", cthd.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", cthd.Gia);
                    cmd.Parameters.AddWithValue("@ThueVAT", cthd.ThueVAT);
                    conn.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Sửa chi tiết hóa đơn
        public bool UpdateChiTietHoaDon(ChiTietHoaDon cthd)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"
                    UPDATE ChiTietHoaDon
                    SET MaHoaDon = @MaHoaDon, MaSanPham = @MaSanPham, SoLuong = @SoLuong, 
                        Gia = @Gia, ThueVAT = @ThueVAT
                    WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietHoaDon", cthd.MaChiTietHoaDon);
                    cmd.Parameters.AddWithValue("@MaHoaDon", cthd.MaHoaDon);
                    cmd.Parameters.AddWithValue("@MaSanPham", cthd.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", cthd.SoLuong);
                    cmd.Parameters.AddWithValue("@Gia", cthd.Gia);
                    cmd.Parameters.AddWithValue("@ThueVAT", cthd.ThueVAT);
                    conn.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Xóa chi tiết hóa đơn
        public bool DeleteChiTietHoaDon(int maChiTietHoaDon)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "DELETE FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @MaChiTietHoaDon";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiTietHoaDon", maChiTietHoaDon);
                    conn.Open();
                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        // Tìm kiếm hóa đơn theo mã hoặc ngày
        public DataTable SearchHoaDon(string maHoaDon, DateTime? ngayDat)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"
                    SELECT HD.MaHoaDon, KH.HoTen AS TenKhachHang, NV.HoTen AS TenNhanVien, B.SoBan, 
                           HD.NgayDat, HD.TongTien, HD.TienGiamGia, HD.TongThueVAT, HD.ThanhToan, HD.TrangThai
                    FROM HoaDon HD
                    JOIN KhachHang KH ON HD.MaKhachHang = KH.MaKhachHang
                    LEFT JOIN NhanVien NV ON HD.MaNhanVien = NV.MaNV
                    LEFT JOIN Ban B ON HD.MaBan = B.MaBan
                    WHERE 1=1";
                if (!string.IsNullOrEmpty(maHoaDon))
                    sql += " AND HD.MaHoaDon = @MaHoaDon";
                if (ngayDat.HasValue)
                    sql += " AND CAST(HD.NgayDat AS DATE) = @NgayDat";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(maHoaDon))
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    if (ngayDat.HasValue)
                        cmd.Parameters.AddWithValue("@NgayDat", ngayDat.Value.Date);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}
