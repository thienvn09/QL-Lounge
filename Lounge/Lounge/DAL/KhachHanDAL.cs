using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lounge.DAL
{
    public class KhachHangDAL
    {
        private KetNoi ketNoi = new KetNoi();

        // Get all customers
        public List<KhachHan> GetAllKH()
        {
            List<KhachHan> dsKhachHang = new List<KhachHan>();
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "SELECT * FROM KhachHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        KhachHan kh = new KhachHan()
                        {
                            MaKhachHang = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            SDT_KH = reader.GetString(2),
                            LoaiKH = reader.GetString(3),
                            NgaySuDung = reader.GetDateTime(4),
                            TiLeGiamGia = reader.GetDecimal(5)
                        };
                        dsKhachHang.Add(kh);
                    }
                }
            }
            return dsKhachHang;
        }

        // Add new customer
        public bool AddKH(KhachHan kh)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"INSERT INTO KhachHang (HoTen, SDT_KH, LoaiKH, NgaySuDung, TiLeGiamGia) 
                             VALUES (@HoTen, @SDT_KH, @LoaiKH, @NgaySuDung, @TiLeGiamGia)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                    cmd.Parameters.AddWithValue("@SDT_KH", kh.SDT_KH);
                    cmd.Parameters.AddWithValue("@LoaiKH", kh.LoaiKH);
                    cmd.Parameters.AddWithValue("@NgaySuDung", kh.NgaySuDung);
                    cmd.Parameters.AddWithValue("@TiLeGiamGia", kh.TiLeGiamGia);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Unique constraint violation (e.g., duplicate SDT_KH)
                            return false;
                        throw;
                    }
                }
            }
        }

        // Update customer
        public bool UpdateKH(KhachHan kh)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"UPDATE KhachHang 
                             SET HoTen = @HoTen, SDT_KH = @SDT_KH, LoaiKH = @LoaiKH, 
                                 NgaySuDung = @NgaySuDung, TiLeGiamGia = @TiLeGiamGia
                             WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", kh.MaKhachHang);
                    cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
                    cmd.Parameters.AddWithValue("@SDT_KH", kh.SDT_KH);
                    cmd.Parameters.AddWithValue("@LoaiKH", kh.LoaiKH);
                    cmd.Parameters.AddWithValue("@NgaySuDung", kh.NgaySuDung);
                    cmd.Parameters.AddWithValue("@TiLeGiamGia", kh.TiLeGiamGia);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Unique constraint violation (e.g., duplicate SDT_KH)
                            return false;
                        throw;
                    }
                }
            }
        }

        // Delete customer
        public bool DeleteKH(int maKhachHang)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "DELETE FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Get customer by ID
        public KhachHan GetKHById(int maKhachHang)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "SELECT * FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new KhachHan()
                        {
                            MaKhachHang = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            SDT_KH = reader.GetString(2),
                            LoaiKH = reader.GetString(3),
                            NgaySuDung = reader.GetDateTime(4),
                            TiLeGiamGia = reader.GetDecimal(5)
                        };
                    }
                    return null;
                }
            }
        }
    }
}