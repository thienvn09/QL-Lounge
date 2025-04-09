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
        public List<SANPHAM> GetSanPhamTheoLoai(string loai)
        {
            List<SANPHAM> ds = new List<SANPHAM>();

            string query = "SELECT * FROM SANPHAM WHERE Loai = @Loai";

            using (SqlConnection conn = KetNoi.GetConnect())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Loai", loai);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SANPHAM sp = new SANPHAM()
                    {
                        MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                        TenSanPham = reader["TenSanPham"].ToString(),
                        Gia = Convert.ToDecimal(reader["Gia"])
                        // Thêm các cột khác nếu có
                    };
                    ds.Add(sp);
                }
                conn.Close();
            }

            return ds;
        }

    }
}
