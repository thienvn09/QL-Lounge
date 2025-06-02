using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lounge.DAL
{
    public class NhanVienDAL
    {
        private readonly KetNoi kn = new KetNoi();

        // Kiểm tra chức vụ đã tồn tại hay chưa
        public bool CheckChucVuTonTai(string chucvu)
        {
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    string query = "SELECT COUNT(*) FROM NhanVien WHERE ChucVu = @ChucVu";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = chucvu;
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi kiểm tra chức vụ: {ex.Message}", ex);
            }
        }

        // Lấy nhân viên cho combobox
        public DataTable GetAllNhanVien1()
        {
            try
            {
                string query = "SELECT MaNV AS MaNhanvien, HoTen FROM NhanVien";
                using (SqlConnection conn = kn.GetConnect())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên cho combobox: {ex.Message}", ex);
            }
        }

        // Lấy danh sách tất cả nhân viên
        public List<NhanVien> GetAllNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    string query = "SELECT MaNV, HoTen, ChucVu, SDT_NV, Email_NV, NgayTao FROM NhanVien";
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
                                NgayTao = reader.GetDateTime(5)
                            };
                            dsNhanVien.Add(nv);
                        }
                    }
                }
                return dsNhanVien;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}", ex);
            }
        }

        // Thêm nhân viên mới
        public void ThemNhanVien(NhanVien nv)
        {
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    string query = @"INSERT INTO NhanVien (HoTen, ChucVu, SDT_NV, Email_NV, NgayTao)
                                    VALUES (@HoTen, @ChucVu, @SDT_NV, @Email_NV, @NgayTao)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                        cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                        cmd.Parameters.Add("@SDT_NV", SqlDbType.NVarChar).Value = nv.SDT_NV;
                        cmd.Parameters.Add("@Email_NV", SqlDbType.NVarChar).Value = (object)nv.Email_NV ?? DBNull.Value;
                        cmd.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = nv.NgayTao;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi thêm nhân viên: {ex.Message}", ex);
            }
        }

        // Xóa nhân viên theo mã
        public void XoaNhanVien(int maNV)
        {
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = maNV;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi xóa nhân viên: {ex.Message}", ex);
            }
        }

        // Sửa thông tin nhân viên theo mã
        public void SuaNhanVien(NhanVien nv)
        {
            try
            {
                using (SqlConnection conn = kn.GetConnect())
                {
                    string query = @"UPDATE NhanVien SET 
                                    HoTen = @HoTen,
                                    ChucVu = @ChucVu,
                                    SDT_NV = @SDT_NV,
                                    Email_NV = @Email_NV,
                                    NgayTao = @NgayTao
                                    WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                        cmd.Parameters.Add("@ChucVu", SqlDbType.NVarChar).Value = nv.ChucVu;
                        cmd.Parameters.Add("@SDT_NV", SqlDbType.NVarChar).Value = nv.SDT_NV;
                        cmd.Parameters.Add("@Email_NV", SqlDbType.NVarChar).Value = (object)nv.Email_NV ?? DBNull.Value;
                        cmd.Parameters.Add("@NgayTao", SqlDbType.DateTime).Value = nv.NgayTao;
                        cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = nv.MaNhanvien;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi khi sửa nhân viên: {ex.Message}", ex);
            }
        }
        // Lấy danh sách nhân viên để hiển thị trong ComboBox (chỉ cần MaNV và HoTen)
        public List<NhanVien> GetNhanVienForComboBox()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            string query = "SELECT MaNV, HoTen FROM NhanVien ORDER BY HoTen";

            using (SqlConnection connection = kn.GetConnect())
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NhanVien nv = new NhanVien
                                {
                                    MaNhanvien = reader.GetInt32(reader.GetOrdinal("MaNV")),
                                    HoTen = reader.GetString(reader.GetOrdinal("HoTen"))
                                    // Các thuộc tính khác không cần thiết cho ComboBox này
                                };
                                dsNhanVien.Add(nv);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DATABASE ERROR] GetNhanVienForComboBox: {ex.Message}");
                    // throw;
                }
            }
            return dsNhanVien;
        }
    }
}