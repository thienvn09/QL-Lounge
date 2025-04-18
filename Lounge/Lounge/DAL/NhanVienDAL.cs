using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lounge.DAL
{
    public class NhanVienDAL
    {
        KetNoi kn = new KetNoi();
        public bool CheckChucVuTonTai(string chucvu)
        {
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = "SELECT COUNT(*) FROM NhanVien WHERE ChucVu = @ChucVu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ChucVu", chucvu);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = "SELECT * FROM NhanVien";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NhanVien nv = new NhanVien
                        {
                            MaNhanvien = reader.GetInt32(0),
                            HoTen = reader.GetString(1),
                            ChuVu = reader.GetString(2),
                            SDT_NV = reader.GetString(3),
                            Email_NV = reader.IsDBNull(4) ? null : reader.GetString(4),
                            NgayTao = reader.GetDateTime(5)
                        };
                        dsNhanVien.Add(nv);
                    }
                }
            }
            return dsNhanVien;
        }
        public void ThemNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = @"INSERT INTO NhanVien (HoTen, ChucVu, SDT_NV, Email_NV, NgayTao)
                                 VALUES (@HoTen, @ChucVu, @SDT_NV, @Email_NV, @NgayTao)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@ChucVu", nv.ChuVu);
                    cmd.Parameters.AddWithValue("@SDT_NV", nv.SDT_NV);
                    cmd.Parameters.AddWithValue("@Email_NV", (object)nv.Email_NV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTao", nv.NgayTao);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void XoaNhanVien(int maNV)
        {
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
