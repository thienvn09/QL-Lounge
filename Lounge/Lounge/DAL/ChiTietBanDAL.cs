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
       
        // Phương thức để lấy danh sách chi tiết bàn từ cơ sở dữ liệu
      
        public List<ChiTietBan> GetChiTietBans(int maBan)
        {
            List<ChiTietBan> dsChiTietBan = new List<ChiTietBan>();
            using(SqlConnection conn = KetNoi.GetConnect())
            {
                string query = "SELECT * FROM vw_ChiTietBan WHERE MaBan = @maBan";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ChiTietBan chiTietBan = new ChiTietBan
                    {
                        MaBan = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        SoBan = reader.IsDBNull(1) ? "" : reader.GetString(1),
                        KhuVuc = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        TrangThai = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        MaHoaDon = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                        TenSanPham = reader.IsDBNull(5) ? "" : reader.GetString(5),
                        SoLuong = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                        Gia = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                        ThueVAT = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8),
                    };
                    dsChiTietBan.Add(chiTietBan);
                }
                conn.Close();
                return dsChiTietBan;
            }
        }
    }
}
