using System;
using System.Collections.Generic;
using System.Data; // Cần cho ConnectionState
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class DanhMucSPDAL
    {
        private KetNoi ketNoi = new KetNoi(); // Giữ nguyên đối tượng KetNoi của bạn

        public List<DanhMucSanPham> GetAllDanhMucSP()
        {
            List<DanhMucSanPham> dsDanhMucSP = new List<DanhMucSanPham>();
            // Lấy tất cả các cột cần thiết từ bảng DanhMucSanPham
            string query = "SELECT MaDanhMuc, TenDanhMuc, Loai, ThueVAT, MoTa FROM DanhMucSanPham ORDER BY MaDanhMuc";

            using (SqlConnection connection = ketNoi.GetConnect()) // Giả sử GetConnect() trả về một SqlConnection mới, chưa mở
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
                                DanhMucSanPham danhMucSP = new DanhMucSanPham
                                {
                                    MaDanhMuc = reader.GetInt32(reader.GetOrdinal("MaDanhMuc")),
                                    TenDanhMuc = reader.GetString(reader.GetOrdinal("TenDanhMuc")),
                                    Loai = reader.GetString(reader.GetOrdinal("Loai")),
                                    ThueVAT = reader.GetDecimal(reader.GetOrdinal("ThueVAT")),
                                    MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : reader.GetString(reader.GetOrdinal("MoTa"))
                                };
                                dsDanhMucSP.Add(danhMucSP);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy tất cả danh mục sản phẩm: " + ex.Message);
                    // throw; // Hoặc throw lại lỗi nếu bạn muốn tầng trên xử lý
                }
                // Kết nối sẽ tự động đóng khi ra khỏi khối using
            }
            return dsDanhMucSP;
        }

        public DanhMucSanPham GetDanhMucById(int maDanhMuc)
        {
            DanhMucSanPham danhMucSP = null;
            string query = "SELECT MaDanhMuc, TenDanhMuc, Loai, ThueVAT, MoTa FROM DanhMucSanPham WHERE MaDanhMuc = @MaDanhMuc";

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                danhMucSP = new DanhMucSanPham
                                {
                                    MaDanhMuc = reader.GetInt32(reader.GetOrdinal("MaDanhMuc")),
                                    TenDanhMuc = reader.GetString(reader.GetOrdinal("TenDanhMuc")),
                                    Loai = reader.GetString(reader.GetOrdinal("Loai")),
                                    ThueVAT = reader.GetDecimal(reader.GetOrdinal("ThueVAT")),
                                    MoTa = reader.IsDBNull(reader.GetOrdinal("MoTa")) ? null : reader.GetString(reader.GetOrdinal("MoTa"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi lấy danh mục sản phẩm theo ID ({maDanhMuc}): {ex.Message}");
                    // throw;
                }
            }
            return danhMucSP;
        }

        public bool AddDanhMuc(DanhMucSanPham dm)
        {
            // Kiểm tra xem Tên Danh Mục đã tồn tại chưa (nếu cần ràng buộc UNIQUE cho TenDanhMuc)
            // string checkQuery = "SELECT COUNT(*) FROM DanhMucSanPham WHERE TenDanhMuc = @TenDanhMuc";
            // using (SqlConnection checkConn = ketNoi.GetConnect()) { ... }
            // Nếu đã tồn tại, return false hoặc throw exception

            string query = @"INSERT INTO DanhMucSanPham (TenDanhMuc, Loai, ThueVAT, MoTa) 
                             VALUES (@TenDanhMuc, @Loai, @ThueVAT, @MoTa)";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenDanhMuc", dm.TenDanhMuc);
                        cmd.Parameters.AddWithValue("@Loai", dm.Loai);
                        cmd.Parameters.AddWithValue("@ThueVAT", dm.ThueVAT);
                        cmd.Parameters.AddWithValue("@MoTa", (object)dm.MoTa ?? DBNull.Value); // Xử lý MoTa có thể NULL

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) // Bắt lỗi SQL cụ thể
                {
                    Console.WriteLine($"Lỗi SQL khi thêm danh mục: {ex.Message}");
                    // Có thể kiểm tra mã lỗi cụ thể, ví dụ lỗi UNIQUE constraint
                    // if (ex.Number == 2627 || ex.Number == 2601) { // Mã lỗi cho UNIQUE constraint violation }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi không xác định khi thêm danh mục: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool UpdateDanhMuc(DanhMucSanPham dm)
        {
            // Kiểm tra xem Tên Danh Mục (nếu thay đổi) có bị trùng với một Danh Mục khác không (trừ chính nó)
            // string checkQuery = "SELECT COUNT(*) FROM DanhMucSanPham WHERE TenDanhMuc = @TenDanhMuc AND MaDanhMuc != @MaDanhMuc";

            string query = @"UPDATE DanhMucSanPham 
                             SET TenDanhMuc = @TenDanhMuc, Loai = @Loai, ThueVAT = @ThueVAT, MoTa = @MoTa
                             WHERE MaDanhMuc = @MaDanhMuc";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenDanhMuc", dm.TenDanhMuc);
                        cmd.Parameters.AddWithValue("@Loai", dm.Loai);
                        cmd.Parameters.AddWithValue("@ThueVAT", dm.ThueVAT);
                        cmd.Parameters.AddWithValue("@MoTa", (object)dm.MoTa ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@MaDanhMuc", dm.MaDanhMuc);

                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Lỗi SQL khi cập nhật danh mục: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi không xác định khi cập nhật danh mục: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }

        public bool DeleteDanhMuc(int maDanhMuc)
        {
            // Trước khi xóa, bạn có thể muốn kiểm tra xem danh mục này có đang được sử dụng trong bảng SanPham không
            // Nếu có, bạn có thể không cho xóa hoặc hiển thị thông báo.
            // string checkQuery = "SELECT COUNT(*) FROM SanPham WHERE MaDanhMuc = @MaDanhMuc";
            // ...

            string query = "DELETE FROM DanhMucSanPham WHERE MaDanhMuc = @MaDanhMuc";
            int result = 0;

            using (SqlConnection connection = ketNoi.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);
                        result = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex) // Bắt lỗi SQL, ví dụ lỗi khóa ngoại nếu danh mục đang được tham chiếu
                {
                    Console.WriteLine($"Lỗi SQL khi xóa danh mục: {ex.Message}");
                    // if (ex.Number == 547) { // Mã lỗi cho foreign key constraint violation }
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi không xác định khi xóa danh mục: {ex.Message}");
                    return false;
                }
            }
            return result > 0;
        }
    }
}
