using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Lounge.DAL
{
    public class SanPhamDAL
    {
        private KetNoi KetNoi = new KetNoi();
        public List<SANPHAM> GetSanPhamById(int maDanhMuc)
        {
            List<SANPHAM> ds = new List<SANPHAM>();
            KetNoi.GetConnect();
            string query = "SELECT * FROM SANPHAM WHERE MaDanhMuc = @MaDanhMuc";

            using (SqlConnection conn = KetNoi.GetOpenConnect())
            {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SANPHAM sp = new SANPHAM()
                        {
                            MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                            TenSanPham = reader["TenSanPham"].ToString(),
                            Gia = Convert.ToDecimal(reader["Gia"]),
                            MaDanhMuc = Convert.ToInt32(reader["MaDanhMuc"]),
                        };
                        ds.Add(sp);
                    }
               
            }

            return ds;
        }


    }
}
