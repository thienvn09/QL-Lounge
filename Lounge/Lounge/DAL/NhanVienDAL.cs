using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Lounge.DAL
{
    public class NhanVienDAL
    {
        KetNoi kn = new KetNoi();

        // Kiểm tra chức vụ đã tồn tại hay chưa
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

        // Lấy danh sách tất cả nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();

            using (SqlConnection conn = kn.GetConnect())
            {
                string query = "SELECT MaNV, HoTen, ChucVu, SDT_NV, Email_NV, DiaChi, GioiTinh, NgayTao FROM NhanVien";
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
                            ChucVu = reader.GetString(2),
                            SDT_NV = reader.GetString(3),
                            Email_NV = reader.IsDBNull(4) ? null : reader.GetString(4),
                            DiaChi = reader.IsDBNull(5) ? null : reader.GetString(5),
                            GioiTinh = reader.IsDBNull(6) ? null : reader.GetString(6),
                            NgayTao = reader.GetDateTime(7)
                        };
                        dsNhanVien.Add(nv);
                    }
                }
            }

            return dsNhanVien;
        }

        // Thêm nhân viên mới
        public void ThemNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = @"INSERT INTO NhanVien (HoTen, ChucVu, SDT_NV, Email_NV, NgayTao, DiaChi, GioiTinh)
                                 VALUES (@HoTen, @ChucVu, @SDT_NV, @Email_NV, @NgayTao, @DiaChi, @GioiTinh)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                    cmd.Parameters.AddWithValue("@SDT_NV", nv.SDT_NV);
                    cmd.Parameters.AddWithValue("@Email_NV", (object)nv.Email_NV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTao", nv.NgayTao);
                    cmd.Parameters.AddWithValue("@DiaChi", (object)nv.DiaChi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Xoá nhân viên theo mã
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

        // Sửa thông tin nhân viên theo mã
        public void SuaNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = kn.GetConnect())
            {
                string query = @"UPDATE NhanVien SET 
                                    HoTen = @HoTen,
                                    ChucVu = @ChucVu,
                                    SDT_NV = @SDT_NV,
                                    Email_NV = @Email_NV,
                                    NgayTao = @NgayTao,
                                    DiaChi = @DiaChi,
                                    GioiTinh = @GioiTinh
                                WHERE MaNV = @MaNV";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen);
                    cmd.Parameters.AddWithValue("@ChucVu", nv.ChucVu);
                    cmd.Parameters.AddWithValue("@SDT_NV", nv.SDT_NV);
                    cmd.Parameters.AddWithValue("@Email_NV", (object)nv.Email_NV ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTao", nv.NgayTao);
                    cmd.Parameters.AddWithValue("@DiaChi", (object)nv.DiaChi ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNV", nv.MaNhanvien);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
