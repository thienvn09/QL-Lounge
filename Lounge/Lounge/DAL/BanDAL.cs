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
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public BanDAL()
        {
            MaBan = 0;
            TenBan = "";
            TrangThai = "";
            GhiChu = "";
        }
        public BanDAL(int maban, string tenban, string trangthai, string ghichu)
        {
            MaBan = maban;
            TenBan = tenban;
            TrangThai = trangthai;
            GhiChu = ghichu;
        }
        public void XemSoBan()
        {
            KetNoi kn = new KetNoi();
            string query = "select * from Ban";
            List<SqlParameter> parameters = new List<SqlParameter>();
            DataTable dt = kn.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine("Mã bàn: " + row["MaBan"]);
                    Console.WriteLine("Tên bàn: " + row["TenBan"]);
                    Console.WriteLine("Trạng thái: " + row["TrangThai"]);
                    Console.WriteLine("Ghi chú: " + row["GhiChu"]);
                }
            }
            else
            {
                Console.WriteLine("Không có dữ liệu trong bảng Ban.");
            }
        }

    }
}
