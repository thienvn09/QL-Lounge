using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public class ChiTietBanDAL
    {
        private KetNoi KetNoi = new KetNoi();
        ChiTietBan ChiTietBan = new ChiTietBan();
        // Phương thức để lấy danh sách chi tiết bàn từ cơ sở dữ liệu
        public List<ChiTietBan> GetChiTietBanList()
        {
            List<ChiTietBan> chiTietBanList = new List<ChiTietBan>();
            string query = "SELECT * FROM ChiTietBan"; // Câu lệnh SQL để lấy dữ liệu
            using (SqlConnection conn = new SqlConnection(KetNoi.GetConnectionString()))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ChiTietBan chiTietBan = new ChiTietBan
                        {
                            MaBan = reader.GetInt32(0),
                            SoBan = reader.GetString(1),
                            KhuVuc = reader.GetString(2),
                            TrangThai = reader.GetString(3),
                            MaHoaDon = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            TenSanPham = reader.GetString(5),
                            SoLuong = reader.GetInt32(6),
                            Gia = reader.GetDecimal(7),
                            ThueVAT = reader.GetDecimal(8)
                        };
                        chiTietBanList.Add(chiTietBan);
                    }
                }
            }
            return chiTietBanList;
        }
    }
}
