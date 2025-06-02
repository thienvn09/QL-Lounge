using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class ChiTietPhieuNhapKhoDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetChiTietPhieuNhapKho(int maPhieuNhap)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT CTPN.MaChiTietPhieuNhap, CTPN.MaPhieuNhap, CTPN.MaSanPham, CTPN.SoLuong, CTPN.DonGia, CTPN.ThanhTien, SP.TenSanPham
                FROM ChiTietPhieuNhapKho CTPN
                JOIN SanPham SP ON CTPN.MaSanPham = SP.MaSanPham
                WHERE CTPN.MaPhieuNhap = @MaPhieuNhap";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool AddChiTietPhieuNhapKho(ChiTietPhieuNhapKho ctpn)
        {
            string query = @"
                INSERT INTO ChiTietPhieuNhapKho (MaPhieuNhap, MaSanPham, SoLuong, DonGia)
                VALUES (@MaPhieuNhap, @MaSanPham, @SoLuong, @DonGia)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieuNhap", ctpn.MaPhieuNhap);
                    cmd.Parameters.AddWithValue("@MaSanPham", ctpn.MaSanPham);
                    cmd.Parameters.AddWithValue("@SoLuong", ctpn.SoLuong);
                    cmd.Parameters.AddWithValue("@DonGia", ctpn.DonGia);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}