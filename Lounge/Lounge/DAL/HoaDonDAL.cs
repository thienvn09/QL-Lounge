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
                SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = KetNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                        conn.Open();
                        int maHoaDon = Convert.ToInt32(cmd.ExecuteScalar());
                        return maHoaDon;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        public void CapNhatTrangThaiHoaDon(int maHoaDon, string trangThai)
        {
            string query = "UPDATE HoaDon SET TrangThai = @TrangThai WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = KetNoi.GetOpenConnect())
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
                    finally
                    {
                        conn.Close();
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
                                    TongTien = Convert.ToSingle(reader["TongTien"] != DBNull.Value ? reader["TongTien"] : 0),
                                    TienGiamGia = Convert.ToSingle(reader["TienGiamGia"]),
                                    TongThueVAT = Convert.ToSingle(reader["TongThueVAT"] != DBNull.Value ? reader["TongThueVAT"] : 0),
                                    ThanhToan = Convert.ToSingle(reader["ThanhToan"] != DBNull.Value ? reader["ThanhToan"] : 0),
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
                    finally
                    {
                        conn.Close();
                    }
                }
               
            }
            return dsHoaDon;
        }

        // Lấy hóa đơn theo MaHoaDon
        public HoaDon LayHoaDonTheoMaHoaDon(int maHoaDon)
        {
            HoaDon hoaDon = null;
            string query = "SELECT * FROM HoaDon WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = KetNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hoaDon = new HoaDon
                                {
                                    MaHoaDon = Convert.ToInt32(reader["MaHoaDon"]),
                                    MaKhachHang = Convert.ToInt32(reader["MaKhachHang"]),
                                    MaNhanVien = (int)(reader["MaNhanVien"] != DBNull.Value ? Convert.ToInt32(reader["MaNhanVien"]) : (int?)null),
                                    MaBan = (int)(reader["MaBan"] != DBNull.Value ? Convert.ToInt32(reader["MaBan"]) : (int?)null),
                                    NgayDat = Convert.ToDateTime(reader["NgayDat"]),
                                    TongTien = Convert.ToSingle(reader["TongTien"] != DBNull.Value ? reader["TongTien"] : 0),
                                    TienGiamGia = Convert.ToSingle(reader["TienGiamGia"]),
                                    TongThueVAT = Convert.ToSingle(reader["TongThueVAT"] != DBNull.Value ? reader["TongThueVAT"] : 0),
                                    ThanhToan = Convert.ToSingle(reader["ThanhToan"] != DBNull.Value ? reader["ThanhToan"] : 0),
                                    NguoiTao = (int)(reader["NguoiTao"] != DBNull.Value ? Convert.ToInt32(reader["NguoiTao"]) : (int?)null)
                                };
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi lấy hóa đơn theo mã hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return hoaDon;
        }

        // Cập nhật tổng tiền hóa đơn
        public void CapNhatTongTienHoaDon(int maHoaDon)
        {
            string query = @"
                UPDATE HoaDon
                SET 
                    TongTien = (SELECT ISNULL(SUM(ThanhTien), 0) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon),
                    TongThueVAT = (SELECT ISNULL(SUM(TienThue), 0) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon)
                WHERE MaHoaDon = @MaHoaDon";

            using (SqlConnection conn = KetNoi.GetOpenConnect())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Lỗi khi cập nhật tổng tiền hóa đơn: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}