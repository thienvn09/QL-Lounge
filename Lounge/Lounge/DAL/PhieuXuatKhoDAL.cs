using System;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class PhieuXuatKhoDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetAllPhieuXuatKho()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT PX.MaPhieuXuat, PX.NgayXuat, PX.MaNhanVien, PX.GhiChu, NV.HoTen AS TenNhanVien
                FROM PhieuXuatKho PX
                LEFT JOIN NhanVien NV ON PX.MaNhanVien = NV.MaNV";
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

        public bool AddPhieuXuatKho(PhieuXuatKho px)
        {
            string query = @"
                INSERT INTO PhieuXuatKho (NgayXuat, MaNhanVien, GhiChu)
                VALUES (@NgayXuat, @MaNhanVien, @GhiChu)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayXuat", px.NgayXuat);
                    cmd.Parameters.AddWithValue("@MaNhanVien", (object)px.MaNhanVien ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)px.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}