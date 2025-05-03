using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class ChiTietHoaDonDAL
    {
        private readonly KetNoi ketNoi = new KetNoi();

        // Thêm một chi tiết hóa đơn
        public void ThemChiTietHoaDon(ChiTietHoaDon chiTiet)
        {
            string query = @"
                INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, Gia, ThueVAT)
                VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @Gia, @ThueVAT)";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHoaDon", chiTiet.MaHoaDon),
                new SqlParameter("@MaSanPham", chiTiet.MaSanPham),
                new SqlParameter("@SoLuong", chiTiet.SoLuong),
                new SqlParameter("@Gia", chiTiet.Gia),
                new SqlParameter("@ThueVAT", chiTiet.ThueVAT)
            };

            using (SqlConnection conn = ketNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    try
                    {
                        conn.Open(); // Mở kết nối nếu cần
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // Cập nhật số lượng chi tiết hóa đơn
        public void CapNhatSoLuongChiTietHoaDon(int maHoaDon, int maSanPham, int soLuongMoi)
        {
            string query = @"
                UPDATE ChiTietHoaDon 
                SET SoLuong = @SoLuong 
                WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@SoLuong", soLuongMoi),
                new SqlParameter("@MaHoaDon", maHoaDon),
                new SqlParameter("@MaSanPham", maSanPham)
            };

            using (SqlConnection conn = ketNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật số lượng chi tiết hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        // Kiểm tra sản phẩm đã có trong hóa đơn chưa
        public ChiTietHoaDon KiemTraSanPhamTrongHoaDon(int maHoaDon, int maSanPham)
        {
            string query = @"
                SELECT * FROM ChiTietHoaDon 
                WHERE MaHoaDon = @MaHoaDon AND MaSanPham = @MaSanPham";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHoaDon", maHoaDon),
                new SqlParameter("@MaSanPham", maSanPham)
            };

            using (SqlConnection conn = ketNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ChiTietHoaDon
                                {
                                    MaChiTietHoaDon = Convert.ToInt32(reader["MaChiTietHoaDon"]),
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    Gia = Convert.ToSingle(reader["Gia"]),
                                    ThueVAT = Convert.ToSingle(reader["ThueVAT"]),
                                    TienThue = Convert.ToSingle(reader["TienThue"]),
                                    ThanhTien = Convert.ToSingle(reader["ThanhTien"])
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi kiểm tra sản phẩm trong hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return null;
        }

        // Lấy danh sách chi tiết hóa đơn theo MaHoaDon
        public List<ChiTietHoaDon> LayChiTietHoaDonTheoMaHoaDon(int maHoaDon)
        {
            List<ChiTietHoaDon> dsChiTiet = new List<ChiTietHoaDon>();

            string query = @"
                SELECT c.*, s.TenSanPham 
                FROM ChiTietHoaDon c 
                JOIN SanPham s ON c.MaSanPham = s.MaSanPham 
                WHERE c.MaHoaDon = @MaHoaDon";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };

            using (SqlConnection conn = ketNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChiTietHoaDon chiTiet = new ChiTietHoaDon
                                {
                                    MaChiTietHoaDon = Convert.ToInt32(reader["MaChiTietHoaDon"]),
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                    SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                    Gia = Convert.ToSingle(reader["Gia"]),
                                    ThueVAT = Convert.ToSingle(reader["ThueVAT"]),
                                    TienThue = Convert.ToSingle(reader["TienThue"]),
                                    ThanhTien = Convert.ToSingle(reader["ThanhTien"]),
                                    TenSanPham = reader["TenSanPham"].ToString()
                                };
                                dsChiTiet.Add(chiTiet);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return dsChiTiet;
        }
    }
}