using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Lounge.Model;

namespace Lounge.DAL
{
    public class DanhMucSPDAL
    {
        private KetNoi KetNoi = new KetNoi();
        public List<DanhMucSanPham> GetAllDanhMucSP()
        {
            List<DanhMucSanPham> dsDanhMucSP = new List<DanhMucSanPham>();
            string query = "SELECT * FROM DanhMucSanPham";
            SqlCommand cmd = new SqlCommand(query, KetNoi.GetConnect());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DanhMucSanPham danhMucSP = new DanhMucSanPham();
                danhMucSP.MaDanhMuc = reader.GetInt32(0);
                danhMucSP.TenDanhMuc = reader.GetString(1);
                dsDanhMucSP.Add(danhMucSP);
            }
            KetNoi.GetConnect().Close();
            return dsDanhMucSP;
        }
        
    }
}
