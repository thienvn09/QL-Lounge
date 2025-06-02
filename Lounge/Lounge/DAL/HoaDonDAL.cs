using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model; // Đảm bảo Model.HoaDon đã được cập nhật

namespace Lounge.DAL
{
    public class HoaDonDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public List<HoaDon> GetAllHoaDon()
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();
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

            using (SqlConnection connection = ketNoi.GetConnect()) // Giả sử GetConnect() trả về SqlConnection mới, chưa mở
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
                                    // MaKhachHang trong DB HoaDon là NOT NULL
                                    MaKhachHang = reader.GetInt32(reader.GetOrdinal("MaKhachHang")),
                                    TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "Khách vãng lai" : reader.GetString(reader.GetOrdinal("TenKhachHang")),

                                    MaNhanVien = (int)(reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaNhanVien"))),
                                    TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")),

                                    MaBan = (int)(reader.IsDBNull(reader.GetOrdinal("MaBan")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaBan"))),
                                    SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "Mang về" : reader.GetString(reader.GetOrdinal("SoBan")),

                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),

                                    TongTien = (float)(reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongTien"))),
                                    TienGiamGia = (float)(reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TienGiamGia"))),
                                    TongThueVAT = (float)(reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongThueVAT"))),
                                    ThanhToan = (float)(reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0m : reader.GetDecimal(reader.GetOrdinal("ThanhToan"))), // Cột tính toán trong DB

                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "Không xác định" : reader.GetString(reader.GetOrdinal("TrangThai")),

                                    NguoiTao = (int)(reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("NguoiTao"))),
                                    TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao"))
                                };
                                dsHoaDon.Add(hd);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] GetAllHoaDon: {ex.Message}");
                    // throw; // Xem xét việc throw lại lỗi để tầng trên xử lý nếu cần
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
                                    TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "Khách vãng lai" : reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                    MaNhanVien = (int)(reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaNhanVien"))),
                                    TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")),
                                    MaBan =  (int)(reader.IsDBNull(reader.GetOrdinal("MaBan")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaBan"))),
                                    SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "Mang về" : reader.GetString(reader.GetOrdinal("SoBan")),
                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),
                                    TongTien = (float)(reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongTien"))),
                                    TienGiamGia = (float)(reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TienGiamGia"))),
                                    TongThueVAT = (float)(reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongThueVAT"))),
                                    ThanhToan = (float)(reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0m : reader.GetDecimal(reader.GetOrdinal("ThanhToan"))),
                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "Không xác định" : reader.GetString(reader.GetOrdinal("TrangThai")),
                                    NguoiTao = (int)(reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("NguoiTao"))),
                                    TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] LayHoaDonTheoMa ({maHoaDon}): {ex.Message}");
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
                        // MaKhachHang là NOT NULL trong DB
                        cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                        cmd.Parameters.AddWithValue("@MaNhanVien", (object)hoaDon.MaNhanVien ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaBan", (object)hoaDon.MaBan ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@NgayDat", hoaDon.NgayDat);
                        cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                        cmd.Parameters.AddWithValue("@TienGiamGia", hoaDon.TienGiamGia);
                        cmd.Parameters.AddWithValue("@TongThueVAT", hoaDon.TongThueVAT);
                        cmd.Parameters.AddWithValue("@TrangThai", hoaDon.TrangThai);
                        cmd.Parameters.AddWithValue("@NguoiTao", (object)hoaDon.NguoiTao ?? DBNull.Value);

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            newHoaDonId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] ThemHoaDon: {ex.Message}");
                    // throw;
                }
            }
            return newHoaDonId;
        }

        public bool CapNhatTongTienHoaDon(int maHoaDon)
        {
            // Trigger trg_UpdateHoaDonTotals trong CSDL sẽ tự động cập nhật TongTien và TongThueVAT
            // dựa trên thay đổi của ChiTietHoaDon.
            // Hàm này trong C# có thể không cần thiết nếu bạn chỉ dựa vào trigger.
            // Tuy nhiên, nếu bạn cập nhật TienGiamGia trực tiếp trên HoaDon và muốn ThanhToan (cột tính toán)
            // được tính lại, bạn có thể cần trigger phức tạp hơn hoặc gọi 1 stored procedure để tính toán lại tất cả.
            // Hoặc, hàm này có thể được dùng để tính lại nếu không có trigger.
            // Hiện tại, mình sẽ giữ lại câu lệnh UPDATE này như một cách để đồng bộ từ C# nếu cần.
            string query = @"
                UPDATE hd
                SET 
                    hd.TongTien = ISNULL(ct.SumThanhTien, 0),
                    hd.TongThueVAT = ISNULL(ct.SumTienThue, 0)
                    -- ThanhToan là cột tính toán dựa trên TongTien, TongThueVAT, TienGiamGia
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
                    Console.WriteLine($"[DATABASE ERROR] CapNhatTongTienHoaDon ({maHoaDon}): {ex.Message}");
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
                    Console.WriteLine($"[DATABASE ERROR] CapNhatTrangThaiHoaDon ({maHoaDon}): {ex.Message}");
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
                                    TenKhachHang = reader.IsDBNull(reader.GetOrdinal("TenKhachHang")) ? "Khách vãng lai" : reader.GetString(reader.GetOrdinal("TenKhachHang")),
                                    MaNhanVien = (int)(reader.IsDBNull(reader.GetOrdinal("MaNhanVien")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaNhanVien"))),
                                    TenNhanVienLap = reader.IsDBNull(reader.GetOrdinal("TenNhanVienLap")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNhanVienLap")),
                                    MaBan = (int)(reader.IsDBNull(reader.GetOrdinal("MaBan")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("MaBan"))),
                                    SoBan = reader.IsDBNull(reader.GetOrdinal("SoBan")) ? "Mang về" : reader.GetString(reader.GetOrdinal("SoBan")),
                                    NgayDat = reader.GetDateTime(reader.GetOrdinal("NgayDat")),
                                    TongTien = (float)(reader.IsDBNull(reader.GetOrdinal("TongTien")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongTien"))),
                                    TienGiamGia = (float)(reader.IsDBNull(reader.GetOrdinal("TienGiamGia")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TienGiamGia"))),
                                    TongThueVAT = (float)(reader.IsDBNull(reader.GetOrdinal("TongThueVAT")) ? 0m : reader.GetDecimal(reader.GetOrdinal("TongThueVAT"))),
                                    ThanhToan = (float)(reader.IsDBNull(reader.GetOrdinal("ThanhToan")) ? 0m : reader.GetDecimal(reader.GetOrdinal("ThanhToan"))),
                                    TrangThai = reader.IsDBNull(reader.GetOrdinal("TrangThai")) ? "Không xác định" : reader.GetString(reader.GetOrdinal("TrangThai")),
                                    NguoiTao = (int)(reader.IsDBNull(reader.GetOrdinal("NguoiTao")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("NguoiTao"))),
                                    TenNguoiTao = reader.IsDBNull(reader.GetOrdinal("TenNguoiTao")) ? "N/A" : reader.GetString(reader.GetOrdinal("TenNguoiTao"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] LayHoaDonChuaThanhToanTheoMaBan ({maBan}): {ex.Message}");
                    // throw;
                }
            }
            return hd;
        }

        public bool DeleteHoaDon(int maHoaDon)
        {
            // Cảnh báo: Nên cân nhắc việc không xóa cứng hóa đơn mà chỉ đổi trạng thái.
            // Nếu CSDL đã thiết lập ON DELETE CASCADE cho ChiTietHoaDon -> HoaDon thì không cần xóa chi tiết thủ công.
            string deleteDetailsQuery = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon";
            string deleteHoaDonQuery = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Bước 1: Xóa các chi tiết hóa đơn liên quan (nếu không có ON DELETE CASCADE)
                    using (SqlCommand cmdDetails = new SqlCommand(deleteDetailsQuery, connection, transaction))
                    {
                        cmdDetails.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        cmdDetails.ExecuteNonQuery();
                    }

                    // Bước 2: Xóa hóa đơn chính
                    using (SqlCommand cmdHoaDon = new SqlCommand(deleteHoaDonQuery, connection, transaction))
                    {
                        cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                        result = cmdHoaDon.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    try { transaction.Rollback(); } catch { /* Ignored */ }
                    Console.WriteLine($"[DATABASE ERROR] DeleteHoaDon ({maHoaDon}): {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        // Hàm này có vẻ hơi thừa nếu đã có LayHoaDonTheoMa(int maHoaDon) trả về đối tượng HoaDon đầy đủ.
        // Nếu chỉ để kiểm tra sự tồn tại, một hàm trả về bool có thể tốt hơn.
        // Hoặc nếu mục đích là khác, bạn có thể làm rõ thêm.
        public int LayMaHoaDonTheoMa(int maHoaDon) // Đổi tên hàm để rõ ràng hơn
        {
            int resultId = 0; // Trả về 0 nếu không tìm thấy hoặc lỗi
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
                            resultId = Convert.ToInt32(objResult);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] LayMaHoaDonTheoMa ({maHoaDon}): {ex.Message}");
                }
            }
            return resultId;
        }
    }
}
