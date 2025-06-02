using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class KhoHangDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetAllKhoHang()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT KH.MaKhoHang, KH.MaSanPham, KH.SoLuongTonKho, SP.TenSanPham
                FROM KhoHang KH
                JOIN SanPham SP ON KH.MaSanPham = SP.MaSanPham";
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

        public bool UpdateSoLuongTon(int maSanPham, int soLuong)
        {
            string query = "UPDATE KhoHang SET SoLuongTon = @SoLuong WHERE MaSanPham = @MaSanPham";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", maSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}