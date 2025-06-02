using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public class ChiTietPhieuXuatDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetChiTietPhieuXuat(int maPhieuXuat)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT CTX.MaChiTietXuat, CTX.MaPhieuXuat, CTX.MaSanPham, CTX.SoLuong, SP.TenSanPham
                FROM ChiTietPhieuXuat CTX
                JOIN SanPham SP ON CTX.MaSanPham = SP.MaSanPham
                WHERE CTX.MaPhieuXuat = @MaPhieuXuat";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AddChiTietPhieuXuat(ChiTietPhieuXuat ctx)
        {
            string query = @"
                INSERT INTO ChiTietPhieuXuat (MaPhieuXuat, MaSanPham, SoLuong)
                VALUES (@MaPhieuXuat, @MaSanPham, @SoLuong)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuXuat", ctx.MaPhieuXuat);
                    cmd.Parameters.AddWithValue("@MaSanPham", ctx.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", ctx.SoLuong);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
