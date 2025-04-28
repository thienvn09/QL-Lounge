using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public class HoaDonDAL
    {
        private KetNoi KetNoi = new KetNoi();
        public int ThemHoaDon(HoaDon hoaDon)
        {
            string query = @"
                       INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, NguoiTao)
                       VALUES (@MaKhachHang, @MaNhanVien, @MaBan, @NgayDat, @TongTien, @TienGiamGia, @TongThueVAT, @NguoiTao);
                       SELECT SCOPE_IDENTITY();"; // Trả về MaHoaDon vừa tạo  

            // Fix for CS0165: Initialize the 'cmd' variable before using it.  
            using (SqlCommand cmd = new SqlCommand(query, KetNoi.GetOpenConnect()))
            {
                // Fix for CS1003: Ensure proper syntax and no missing commas.  
                cmd.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                cmd.Parameters.AddWithValue("@MaNhanVien", (object)hoaDon.MaNhanVien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaBan", (object)hoaDon.MaBan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayDat", hoaDon.NgayDat);
                cmd.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                cmd.Parameters.AddWithValue("@TienGiamGia", hoaDon.TienGiamGia);
                cmd.Parameters.AddWithValue("@TongThueVAT", hoaDon.TongThueVAT);
                cmd.Parameters.AddWithValue("@NguoiTao", (object)hoaDon.NguoiTao ?? DBNull.Value);

                try
                {
                    // Ensure the connection is open before executing the command.  
                    KetNoi.GetOpenConnect();
                    int maHoaDon = Convert.ToInt32(cmd.ExecuteScalar());
                    return maHoaDon;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
                }
            }
        }
        // Fix for CS0103: The name 'query' does not exist in the current context  
        // The issue occurs because the 'query' variable is not defined in the context of the 'using' block.  
        // To fix this, ensure the 'query' variable is declared before the 'using' block.  

        public void CapNhatTrangThaiHoaDon(int maHoaDon, string trangThai)
        {
            string query = "UPDATE HoaDon SET TrangThai = @TrangThai WHERE MaHoaDon = @MaHoaDon"; // Declare 'query' here  

            using (SqlConnection conn = KetNoi.GetOpenConnect()) // Fix incorrect parentheses  
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật trạng thái hóa đơn: " + ex.Message);
                    }
                }
            }
        } 

        // Lấy danh sách hóa đơn theo MaBan
        public List<HoaDon> LayHoaDonTheoMaBan(int maBan)
        {
            List<HoaDon> dsHoaDon = new List<HoaDon>();
            string query = "SELECT * FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = N'Chưa thanh toán'";
            using (SqlConnection conn = KetNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaBan", maBan);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                HoaDon hoaDon = new HoaDon
                                {
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaKhachHang = Convert.ToInt32(reader["MaKhachHang"]),
                                    MaNhanVien = (int)(reader["MaNhanVien"] != DBNull.Value ? Convert.ToInt32(reader["MaNhanVien"]) : (int?)null),
                                    MaBan = (int)(reader["MaBan"] != DBNull.Value ? Convert.ToInt32(reader["MaBan"]) : (int?)null),
                                    NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                                    TongTien = Convert.ToSingle(reader["TongTien"]),
                                    TienGiamGia = Convert.ToSingle(reader["TienGiamGia"]),
                                    TongThueVAT = Convert.ToSingle(reader["TongThueVAT"]),
                                    NguoiTao = (int)(reader["NguoiTao"] != DBNull.Value ? Convert.ToInt32(reader["NguoiTao"]) : (int?)null)
                                };
                                dsHoaDon.Add(hoaDon);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                    }
                }
                return dsHoaDon;
            }
        }

    }
}



