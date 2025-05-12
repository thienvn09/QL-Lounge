using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Lounge.DAL
{
    public class SanPhamDAL
    {
        private KetNoi ketNoi = new KetNoi();
        public List<SANPHAM> GetSanPhamById(int maDanhMuc)
        {
            List<SANPHAM> ds = new List<SANPHAM>();
            ketNoi.GetConnect();
            string query = "SELECT * FROM SANPHAM WHERE MaDanhMuc = @MaDanhMuc";

            using (SqlConnection conn = ketNoi.GetOpenConnect())
            {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SANPHAM sp = new SANPHAM()
                        {
                            MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                            TenSanPham = reader["TenSanPham"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            MaDanhMuc = Convert.ToInt32(reader["MaDanhMuc"]),
                        };
                        ds.Add(sp);
                    }
               
            }

            return ds;
        }
        public List<SANPHAM> GetAllSP()
        {
            List<SANPHAM> dsSanPham = new List<SANPHAM>();
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "SELECT * FROM SANPHAM";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SANPHAM sp = new SANPHAM
                        {
                            MaSanPham = reader.GetInt32(0),
                            TenSanPham = reader.GetString(1),
                            MaDanhMuc = reader.GetInt32(2),
                            MaNhaCungCap = reader.GetInt32(3),
                            Gia = reader.GetDecimal(4),
                            MoTa = reader.IsDBNull(5) ? null : reader.GetString(5),
                            SoLuongTonKho = reader.GetInt32(6)
                        };
                        dsSanPham.Add(sp);
                    }
                }
            }
            return dsSanPham;
        }

        public bool AddSP(SANPHAM sp)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"INSERT INTO SANPHAM (TenSanPham, MaDanhMuc, MaNhaCungCap, Gia, MoTa, SoLuongTonKho)
                             VALUES (@TenSanPham, @MaDanhMuc, @MaNhaCungCap, @Gia, @MoTa, @SoLuongTonKho)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);
                    cmd.Parameters.AddWithValue("@MaDanhMuc", sp.MaDanhMuc);
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", sp.MaNhaCungCap);
                    cmd.Parameters.AddWithValue("@Gia", sp.Gia);
                    cmd.Parameters.AddWithValue("@MoTa", (object)sp.MoTa ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", sp.SoLuongTonKho);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle foreign key or other errors
                    }
                }
            }
        }

        public bool UpdateSP(SANPHAM sp)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"UPDATE SANPHAM 
                             SET TenSanPham = @TenSanPham, MaDanhMuc = @MaDanhMuc, MaNhaCungCap = @MaNhaCungCap, 
                                 Gia = @Gia, MoTa = @MoTa, SoLuongTonKho = @SoLuongTonKho
                             WHERE MaSanPham = @MaSanPham";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSanPham", sp.MaSanPham);
                    cmd.Parameters.AddWithValue("@TenSanPham", sp.TenSanPham);
                    cmd.Parameters.AddWithValue("@MaDanhMuc", sp.MaDanhMuc);
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", sp.MaNhaCungCap);
                    cmd.Parameters.AddWithValue("@Gia", sp.Gia);
                    cmd.Parameters.AddWithValue("@MoTa", (object)sp.MoTa ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoLuongTonKho", sp.SoLuongTonKho);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle foreign key or other errors
                    }
                }
            }
        }

        public bool DeleteSP(int maSanPham)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "DELETE FROM SANPHAM WHERE MaSanPham = @MaSanPham";
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
                        return false; // Handle foreign key constraints
                    }
                }
            }
        }

    }
}
