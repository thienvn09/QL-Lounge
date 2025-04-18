using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

namespace Lounge.DAL
{
    public class DangNhapDAL
    {
        KetNoi kn = new KetNoi();

        public bool KiemTraDangNhap(string tenDN, string matKhau)
        {
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM DangNhap WHERE TenDangNhap = @tenDN AND MatKhau = @matKhau AND TrangThai = N'Hoạt động'";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenDN", tenDN);
                        cmd.Parameters.AddWithValue("@matKhau", matKhau);
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi kiểm tra đăng nhập: " + ex.Message, "Lỗi", (MessageBoxButton)MessageBoxButtons.OK, (MessageBoxImage)MessageBoxIcon.Error);
                return false;
            }
        }
    }
}