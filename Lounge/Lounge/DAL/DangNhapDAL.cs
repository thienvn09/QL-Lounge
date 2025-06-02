using Lounge.Model;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace Lounge.DAL
{
    public class DangNhapDAL
    {
        private readonly KetNoi kn = new KetNoi();

        public bool KiemTraDangNhap(string tenDN, string matKhau)
        {
            try
            {
                using (SqlConnection conn = kn.GetOpenConnect())
                {
                    string sql = @"
                        SELECT COUNT(*) 
                        FROM DangNhap 
                        WHERE TenDangNhap = @tenDN 
                          AND MatKhau = @matKhau 
                          AND TrangThai = N'Hoạt động'";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@tenDN", System.Data.SqlDbType.NVarChar) { Value = tenDN });
                        cmd.Parameters.Add(new SqlParameter("@matKhau", System.Data.SqlDbType.NVarChar) { Value = matKhau });

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi kiểm tra đăng nhập: " + ex.Message,
                    "Lỗi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
                return false;
            }

        }
        // Trong DangNhapDAL.cs
        public NhanVien GetNhanVienByTenDangNhap(string tenDN)
        {
            NhanVien nv = null;
            // Câu lệnh SQL để lấy thông tin NhanVien từ TenDangNhap
            // JOIN với bảng NhanVien để lấy HoTen, ChucVu, MaNV
            string query = @"
        SELECT nv.MaNV, nv.HoTen, nv.ChucVu 
        FROM NhanVien nv
        INNER JOIN DangNhap dn ON nv.MaNV = dn.MaNV
        WHERE dn.TenDangNhap = @tenDN AND dn.TrangThai = N'Hoạt động'";

            using (SqlConnection connection = kn.GetConnect()) // Giả sử kn là đối tượng KetNoi của bạn
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tenDN", tenDN);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nv = new NhanVien
                                {
                                    MaNhanvien = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                    HoTen = reader.GetString(reader.GetOrdinal("HoTen")),
                                    ChucVu = reader.GetString(reader.GetOrdinal("ChucVu"))
                                    // Thêm các thuộc tính khác nếu cần
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy thông tin nhân viên: " + ex.Message);
                }
            }
            return nv;
        }

    }
}
