using System;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class PhieuNhapKhoDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetAllPhieuNhapKho()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT PN.MaPhieuNhap, PN.NgayNhap, PN.MaNV, PN.TongTienNhap, PN.GhiChu, NV.HoTen AS TenNhanVien
                FROM PhieuNhapKho PN
                JOIN NhanVien NV ON PN.MaNV = NV.MaNV";
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

        public bool AddPhieuNhapKho(PhieuNhapKho pn)
        {
            string query = @"
                INSERT INTO PhieuNhapKho (NgayNhap, MaNV, TongTienNhap, GhiChu)
                VALUES (@NgayNhap, @MaNV, @TongTienNhap, @GhiChu)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                    cmd.Parameters.AddWithValue("@MaNV", pn.MaNV);
                    cmd.Parameters.AddWithValue("@TongTienNhap", pn.TongTienNhap);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)pn.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}