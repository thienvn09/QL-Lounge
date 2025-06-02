using Lounge;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang
{
    public class BaoCaoDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public DataTable GetAllBaoCao()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT BC.*, NV.HoTen AS TenNguoiTao
                FROM BaoCao BC
                LEFT JOIN NhanVien NV ON BC.NguoiTao = NV.MaNV";
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

        public DataTable GetNhanVien()
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaNV, HoTen FROM NhanVien";
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

        public bool AddBaoCao(BaoCao baoCao)
        {
            string query = @"
                INSERT INTO BaoCao (LoaiBaoCao, NgayBaoCao, TongDoanhThu, TongChiPhi, SoHoaDon, SoKhachHang, SoSanPhamBanRa, NguoiTao, GhiChu)
                VALUES (@LoaiBaoCao, @NgayBaoCao, @TongDoanhThu, @TongChiPhi, @SoHoaDon, @SoKhachHang, @SoSanPhamBanRa, @NguoiTao, @GhiChu)";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoaiBaoCao", baoCao.LoaiBaoCao);
                    cmd.Parameters.AddWithValue("@NgayBaoCao", baoCao.NgayBaoCao);
                    cmd.Parameters.AddWithValue("@TongDoanhThu", baoCao.TongDoanhThu);
                    cmd.Parameters.AddWithValue("@TongChiPhi", baoCao.TongChiPhi);
                    cmd.Parameters.AddWithValue("@SoHoaDon", baoCao.SoHoaDon);
                    cmd.Parameters.AddWithValue("@SoKhachHang", baoCao.SoKhachHang);
                    cmd.Parameters.AddWithValue("@SoSanPhamBanRa", baoCao.SoSanPhamBanRa);
                    cmd.Parameters.AddWithValue("@NguoiTao", (object)baoCao.NguoiTao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)baoCao.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateBaoCao(BaoCao baoCao)
        {
            string query = @"
                UPDATE BaoCao
                SET LoaiBaoCao = @LoaiBaoCao, NgayBaoCao = @NgayBaoCao, TongDoanhThu = @TongDoanhThu,
                    TongChiPhi = @TongChiPhi, SoHoaDon = @SoHoaDon, SoKhachHang = @SoKhachHang,
                    SoSanPhamBanRa = @SoSanPhamBanRa, NguoiTao = @NguoiTao, GhiChu = @GhiChu
                WHERE MaBaoCao = @MaBaoCao";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBaoCao", baoCao.MaBaoCao);
                    cmd.Parameters.AddWithValue("@LoaiBaoCao", baoCao.LoaiBaoCao);
                    cmd.Parameters.AddWithValue("@NgayBaoCao", baoCao.NgayBaoCao);
                    cmd.Parameters.AddWithValue("@TongDoanhThu", baoCao.TongDoanhThu);
                    cmd.Parameters.AddWithValue("@TongChiPhi", baoCao.TongChiPhi);
                    cmd.Parameters.AddWithValue("@SoHoaDon", baoCao.SoHoaDon);
                    cmd.Parameters.AddWithValue("@SoKhachHang", baoCao.SoKhachHang);
                    cmd.Parameters.AddWithValue("@SoSanPhamBanRa", baoCao.SoSanPhamBanRa);
                    cmd.Parameters.AddWithValue("@NguoiTao", (object)baoCao.NguoiTao ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object)baoCao.GhiChu ?? DBNull.Value);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteBaoCao(int maBaoCao)
        {
            string query = "DELETE FROM BaoCao WHERE MaBaoCao = @MaBaoCao";
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBaoCao", maBaoCao);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public DataTable SearchBaoCao(string loaiBaoCao, DateTime? ngayBaoCao, int? nguoiTao)
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT BC.*, NV.HoTen AS TenNguoiTao
                FROM BaoCao BC
                LEFT JOIN NhanVien NV ON BC.NguoiTao = NV.MaNV
                WHERE 1=1";
            if (!string.IsNullOrEmpty(loaiBaoCao))
                query += " AND BC.LoaiBaoCao = @LoaiBaoCao";
            if (ngayBaoCao.HasValue)
                query += " AND CAST(BC.NgayBaoCao AS DATE) = @NgayBaoCao";
            if (nguoiTao.HasValue)
                query += " AND BC.NguoiTao = @NguoiTao";

            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(loaiBaoCao))
                        cmd.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);
                    if (ngayBaoCao.HasValue)
                        cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao.Value.Date);
                    if (nguoiTao.HasValue)
                        cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao.Value);
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool TaoBaoCaoTuDong(string loaiBaoCao, DateTime ngayBaoCao, int nguoiTao)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                using (SqlCommand cmd = new SqlCommand("sp_TaoBaoCaoTuDong", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoaiBaoCao", loaiBaoCao);
                    cmd.Parameters.AddWithValue("@NgayBaoCao", ngayBaoCao);
                    cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao);
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}