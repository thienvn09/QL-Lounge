using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lounge.DAL
{
    public class NhaCungCapDAL
    {
        private KetNoi ketNoi = new KetNoi();

        public List<NhaCungCap> GetAllNhaCungCap()
        {
            List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "SELECT * FROM NhaCungCap";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhaCungCap ncc = new NhaCungCap
                        {
                            MaNhaCungCap = reader.GetInt32(0),
                            TenNhaCungCap = reader.GetString(1),
                            SoDienThoai = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3)
                        };
                        dsNhaCungCap.Add(ncc);
                    }
                }
            }
            return dsNhaCungCap;
        }
        public bool AddNCC(NhaCungCap ncc)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"INSERT INTO NhaCungCap (TenNhaCungCap, SoDienThoai, Email)
                             VALUES (@TenNhaCungCap, @SoDienThoai, @Email)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", ncc.TenNhaCungCap);
                    cmd.Parameters.AddWithValue("@SoDienThoai", (object)ncc.SoDienThoai ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)ncc.Email ?? DBNull.Value);

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

        public bool UpdateNCC(NhaCungCap ncc)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = @"UPDATE NhaCungCap 
                             SET TenNhaCungCap = @TenNhaCungCap, SoDienThoai = @SoDienThoai, Email = @Email
                             WHERE MaNhaCungCap = @MaNhaCungCap";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", ncc.MaNhaCungCap);
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", ncc.TenNhaCungCap);
                    cmd.Parameters.AddWithValue("@SoDienThoai", (object)ncc.SoDienThoai ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)ncc.Email ?? DBNull.Value);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle errors
                    }
                }
            }
        }

        public bool DeleteNCC(int maNhaCungCap)
        {
            using (SqlConnection conn = ketNoi.GetConnect())
            {
                string sql = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = @MaNhaCungCap";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", maNhaCungCap);

                    conn.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException)
                    {
                        return false; // Handle foreign key constraints (e.g., referenced in SANPHAM)
                    }
                }
            }
        }
    }

}