using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public class KhoHangDAL
    {
        public KetNoi ketNoi = new KetNoi();
        // Lấy danh sách tất cả sản phẩm trong kho
        public List<KhoHang> getallKho()
        {
            List<KhoHang> khoHangs = new List<KhoHang>();
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "SELECT * FROM KhoHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        KhoHang khoHang = new KhoHang
                        {
                            MaKhoHang = reader.GetInt32(0),
                            MaSanPham = reader.GetInt32(1),
                            SoLuongTonKho = reader.GetInt32(2)
                        };
                        khoHangs.Add(khoHang);
                    }
                }
                return khoHangs;
            }
        }
        // Thêm sản phẩm vào kho
        public bool AddKhoHang(KhoHang khoHang)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"INSERT INTO KhoHang (MaSanPham, SoLuongTonKho) 
                              VALUES (@MaSanPham, @SoLuongTonKho)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", khoHang.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", khoHang.SoLuongTonKho);
                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle errors (e.g., unique constraints)
                    }
                }
            }
        }
        public bool UpdateKhoHang(KhoHang khoHang)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"UPDATE KhoHang 
                               SET SoLuongTonKho = @SoLuongTonKho 
                               WHERE MaSanPham = @MaSanPham";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", khoHang.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", khoHang.SoLuongTonKho);
                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle errors (e.g., unique constraints)
                    }
                }
            }
        }
        // Xóa sản phẩm khỏi kho
        public bool DeleteKhoHang(int maSanPham)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "DELETE FROM KhoHang WHERE MaSanPham = @MaSanPham";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle errors (e.g., foreign key constraints)
                    }
                }
            }
        }
    }
}
