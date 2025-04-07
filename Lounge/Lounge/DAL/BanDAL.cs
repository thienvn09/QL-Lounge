using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

    }
   
}
