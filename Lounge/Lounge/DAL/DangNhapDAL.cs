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
      
    }
}
