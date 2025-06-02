using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model; // Đảm bảo bạn có Model.HoaDon

namespace Lounge.DAL
{
    public class HoaDonDAL
    {
        private KetNoi ketNoi = new KetNoi();
      

        // Lấy tất cả hóa đơn (có thể kèm tên khách hàng, nhân viên để hiển thị)
        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();
            // Câu lệnh SQL có thể JOIN với bảng KhachHang, NhanVien để lấy tên
            // ORDER BY NgayDat DESC để hóa đơn mới nhất lên đầu
            string query = @"
                SELECT 
                    hd.MaHoaDon, hd.MaKhachHang, kh.HoTen AS TenKhachHang, 
                    hd.MaNhanVien, nv.HoTen AS TenNhanVienLap, hd.MaBan, b.SoBan,
                    hd.NgayDat, hd.TongTien, hd.TienGiamGia, hd.TongThueVAT, 
                    hd.ThanhToan, hd.TrangThai, hd.NguoiTao, nvTao.HoTen AS TenNguoiTao
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNV 
                LEFT JOIN Ban b ON hd.MaBan = b.MaBan
                LEFT JOIN NhanVien nvTao ON hd.NguoiTao = nvTao.MaNV
                ORDER BY hd.NgayDat DESC";

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
                                HoaDon hd = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(reader.GetOrdinal("MaHoaDon")),
                                    MaKhachHang = reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    // TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenKhachHang")), // Model HoaDon cần có thuộc tính này

                                    // Nếu MaNhanVien trong Model là int (không phải int?), giá trị 0 sẽ được gán nếu DB là NULL.
                                    // Điều này ổn nếu 0 không phải là MaNhanVien hợp lệ.
                                    // Nên cân nhắc đổi MaNhanVien trong Model thành int? nếu nó có thể NULL trong DB.
                                    MaNhanVien = reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaNhanVien")),
                                    // TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")), // Model HoaDon cần có thuộc tính này

                                    MaBan = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaBan")),
                                    // SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "N/A" : reader.GetString(reader.GetOrdinal("SoBan")), // Model HoaDon cần có thuộc tính này

                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),

                                    // Model HoaDon dùng float, DB dùng decimal. Chuyển đổi ở đây.
                                    // Khuyến nghị: Nên dùng decimal trong Model cho các giá trị tiền tệ.
                                    TongTien = reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                    TienGiamGia = reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TienGiamGia")),
                                    TongThueVAT = reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongThueVAT")),
                                    ThanhToan = reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("ThanhToan")),

                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "N/A" : reader.GetString(reader.GetOrdinal("TrangThai")),

                                    NguoiTao = reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? 0 : reader.GetInt32(reader.GetOrdinal("NguoiTao"))
                                    // TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao")) // Model HoaDon cần có thuộc tính này
                                };
                                dsHoaDon.Add(hd);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy tất cả hóa đơn: " + ex.Message);
                    // throw; 
                }
            }
            return dsHoaDon;
        }

        public HoaDon LayHoaDonTheoMa(int maHoaDon)
        {
            HoaDon hd = null;
            string query = @"
                SELECT 
                    hd.MaHoaDon, hd.MaKhachHang, kh.HoTen AS TenKhachHang, 
                    hd.MaNhanVien, nv.HoTen AS TenNhanVienLap, hd.MaBan, b.SoBan,
                    hd.NgayDat, hd.TongTien, hd.TienGiamGia, hd.TongThueVAT, 
                    hd.ThanhToan, hd.TrangThai, hd.NguoiTao, nvTao.HoTen AS TenNguoiTao
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNV
                LEFT JOIN Ban b ON hd.MaBan = b.MaBan
                LEFT JOIN NhanVien nvTao ON hd.NguoiTao = nvTao.MaNV
                WHERE hd.MaHoaDon = @MaHoaDon";

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hd = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(reader.GetOrdinal("MaHoaDon")),
                                    MaKhachHang = reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    // TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenKhachHang")),

                                    MaNhanVien = reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaNhanVien")),
                                    // TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")),

                                    MaBan = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaBan")),
                                    // SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "N/A" : reader.GetString(reader.GetOrdinal("SoBan")),

                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),

                                    TongTien = reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                    TienGiamGia = reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TienGiamGia")),
                                    TongThueVAT = reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongThueVAT")),
                                    ThanhToan = reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("ThanhToan")),

                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "N/A" : reader.GetString(reader.GetOrdinal("TrangThai")),

                                    NguoiTao = reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? 0 : reader.GetInt32(reader.GetOrdinal("NguoiTao"))
                                    // TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy hóa đơn theo ID ({maHoaDon}): {ex.Message}");
                    // throw;
                }
            }
            return hd;
        }

        public int ThemHoaDon(HoaDon hoaDon)
        {
            string query = @"
                INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, TrangThai, NguoiTao)
                VALUES (@MaKhachHang, @MaNhanVien, @MaBan, @NgayDat, @TongTien, @TienGiamGia, @TongThueVAT, @TrangThai, @NguoiTao);
                SELECT SCOPE_IDENTITY();";
            int newHoaDonId = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);

                        // Nếu MaNhanVien, MaBan, NguoiTao trong Model là int và không thể null,
                        // chúng ta giả định rằng giá trị 0 (mặc định của int) có nghĩa là "không có" hoặc "không áp dụng"
                        // và sẽ truyền DBNull.Value nếu chúng là 0 (hoặc một giá trị quy ước khác).
                        // Tuy nhiên, cách tốt hơn là dùng int? trong Model nếu DB cho phép NULL.
                        cmd.Parameters.AddWithValue("@MaNhanVien", hoaDon.MaNhanVien == 0 ? (object)DBNull.Value : hoaDon.MaNhanVien);
                        cmd.Parameters.AddWithValue("@MaBan", hoaDon.MaBan == 0 ? (object)DBNull.Value : hoaDon.MaBan);
                        cmd.Parameters.AddWithValue("@NguoiTao", hoaDon.NguoiTao == 0 ? (object)DBNull.Value : hoaDon.NguoiTao);

                        cmd.Parameters.AddWithValue("@NgayDat", hoaDon.NgayDat);
                        cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien); // float sẽ được ADO.NET chuyển đổi
                        cmd.Parameters.AddWithValue("@TienGiamGia", hoaDon.TienGiamGia);
                        cmd.Parameters.AddWithValue("@TongThueVAT", hoaDon.TongThueVAT);
                        cmd.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            newHoaDonId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi thêm hóa đơn mới: {ex.Message}");
                    // throw;
                }
            }
            return newHoaDonId;
        }

        public bool CapNhatTongTienHoaDon(int maHoaDon)
        {
            string query = @"
                UPDATE hd
                SET 
                    hd.TongTien = ISNULL(ct.SumThanhTien, 0),
                    hd.TongThueVAT = ISNULL(ct.SumTienThue, 0)
                FROM HoaDon hd
                LEFT JOIN (
                    SELECT 
                        MaHoaDon, 
                        SUM(ThanhTien) as SumThanhTien, 
                        SUM(TienThue) as SumTienThue 
                    FROM ChiTietHoaDon 
                    WHERE MaHoaDon = @MaHoaDon 
                    GROUP BY MaHoaDon
                ) ct ON hd.MaHoaDon = ct.MaHoaDon
                WHERE hd.MaHoaDon = @MaHoaDon;";
            int result = 0;
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật tổng tiền hóa đơn ({maHoaDon}): {ex.Message}");
                }
            }
            return result > 0;
        }

        public bool CapNhatTrangThaiHoaDon(int maHoaDon, string trangThaiMoi)
        {
            string query = "UPDATE HoaDon SET TrangThai = @TrangThai WHERE MaHoaDon = @MaHoaDon";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật trạng thái hóa đơn ({maHoaDon}): {ex.Message}");
                    // throw;
                }
            }
            return result > 0;
        }

        public HoaDon LayHoaDonChuaThanhToanTheoMaBan(int maBan)
        {
            HoaDon hd = null;
            string query = @"
                SELECT TOP 1
                    hd.MaHoaDon, hd.MaKhachHang, kh.HoTen AS TenKhachHang, 
                    hd.MaNhanVien, nv.HoTen AS TenNhanVienLap, hd.MaBan, b.SoBan,
                    hd.NgayDat, hd.TongTien, hd.TienGiamGia, hd.TongThueVAT, 
                    hd.ThanhToan, hd.TrangThai, hd.NguoiTao, nvTao.HoTen AS TenNguoiTao
                FROM HoaDon hd
                LEFT JOIN KhachHang kh ON hd.MaKhachHang = kh.MaKhachHang
                LEFT JOIN NhanVien nv ON hd.MaNhanVien = nv.MaNV
                LEFT JOIN Ban b ON hd.MaBan = b.MaBan
                LEFT JOIN NhanVien nvTao ON hd.NguoiTao = nvTao.MaNV
                WHERE hd.MaBan = @MaBan AND hd.TrangThai = N'Chưa thanh toán'
                ORDER BY hd.NgayDat DESC";

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaBan", maBan);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hd = new HoaDon
                                {
                                    MaHoaDon = reader.GetInt32(reader.GetOrdinal("MaHoaDon")),
                                    MaKhachHang = reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    // TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                    MaNhanVien = reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaNhanVien")),
                                    // TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")),
                                    MaBan = reader.IsDBNull(reader.GetOrdinal("MaBan")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaBan")),
                                    // SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "N/A" : reader.GetString(reader.GetOrdinal("SoBan")),
                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),
                                    TongTien = reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongTien")),
                                    TienGiamGia = reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TienGiamGia")),
                                    TongThueVAT = reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("TongThueVAT")),
                                    ThanhToan = reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0f : (float)reader.GetDecimal(reader.GetOrdinal("ThanhToan")),
                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "N/A" : reader.GetString(reader.GetOrdinal("TrangThai")),
                                    NguoiTao = reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? 0 : reader.GetInt32(reader.GetOrdinal("NguoiTao"))
                                    // TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy hóa đơn chưa thanh toán theo mã bàn ({maBan}): {ex.Message}");
                    // throw;
                }
            }
            return hd;
        }

        public bool DeleteHoaDon(int maHoaDon)
        {
            string deleteDetailsQuery = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            string deleteHoaDonQuery = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand cmdDetails = new SqlCommand(deleteDetailsQuery, connection, transaction))
                    {
                        cmdDetails.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmdDetails.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdHoaDon = new SqlCommand(deleteHoaDonQuery, connection, transaction))
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        result = cmdHoaDon.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine($"Lỗi khi xóa hóa đơn ({maHoaDon}): {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }
        // LayHoaDonTheoMaHoaDon
        public int LayHoaDonTheoMaHoaDon(int maHoaDon)
        {
            int result = 0;
            string query = "SELECT MaHoaDon FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        object objResult = cmd.ExecuteScalar();
                        if (objResult != null && objResult != DBNull.Value)
                        {
                            result = Convert.ToInt32(objResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy hóa đơn theo mã ({maHoaDon}): {ex.Message}");
                }
            }
            return result;
        }
    }
}
