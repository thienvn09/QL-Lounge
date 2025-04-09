using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public class BanDAL
    {

        private KetNoi KetNoi = new KetNoi();
        public List<Ban> GetAllBan()
        {
            List<Ban> dsban = new List<Ban>();
            string query = "select * from Ban";
            SqlCommand cmd = new SqlCommand(query, KetNoi.GetConnect());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Ban ban = new Ban();
                ban.MaBan = reader.GetInt32(0);
                ban.SoBan = reader.GetString(1);
                ban.SoChoNgoi = reader.GetInt32(2);
                ban.KhuVuc = reader.GetString(3);
                ban.TrangThai = reader.GetString(4);
                dsban.Add(ban);
            }
            KetNoi.GetConnect().Close();
            return dsban;
        }
        public Ban getbanByid(int maban)
        {
            string query = "SELECT * FROM Ban WHERE MaBan = @MaBan";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@MaBan", maban)
            };
            DataTable dt = KetNoi.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Ban
                {
                    MaBan = Convert.ToInt32(row["MaBan"]),
                    SoBan = row["SoBan"].ToString(),
                    SoChoNgoi = Convert.ToInt32(row["SoChoNgoi"]),
                    KhuVuc = row["KhuVuc"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
            }
            return null;
        }
        public Ban GetBanBySoBan(string soBan)
        {
            string query = "SELECT * FROM Ban WHERE SoBan = @SoBan";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@SoBan", soBan)
            };
            DataTable dt = KetNoi.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Ban
                {
                    MaBan = Convert.ToInt32(row["MaBan"]),
                    SoBan = row["SoBan"].ToString(),
                    SoChoNgoi = Convert.ToInt32(row["SoChoNgoi"]),
                    KhuVuc = row["KhuVuc"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
            }
            return null;
        }

        public bool AddNewBan(Ban ban)
        {
            // Kiểm tra bàn đã tồn tại chưa
            var existingBan = GetBanBySoBan(ban.SoBan);
            if (existingBan != null)
            {
                // Bàn đã có, xử lý mở form ở phần gọi hàm
                ban.MaBan = existingBan.MaBan;
                return false; // báo false để bên Form biết là không cần thêm mới
            }

            string query = "INSERT INTO Ban(SoBan, SoChoNgoi, KhuVuc, TrangThai) VALUES(@SoBan, @SoChoNgoi, @KhuVuc, @TrangThai)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@SoBan", ban.SoBan),
                new SqlParameter("@SoChoNgoi", ban.SoChoNgoi),
                new SqlParameter("@KhuVuc", ban.KhuVuc),
                new SqlParameter("@TrangThai", ban.TrangThai)
            };

            int result = KetNoi.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

    }

}
