using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNho.DAL
{
    public class Database
    {
        public string KetNoi = "Data Source=THIEN\\SQLEXPRESS;Initial Catalog=QL_NHAHANG;Integrated Security=True;Trust Server Certificate=True ";
        public SqlConnection GetConnect()
        {
            SqlConnection con = new SqlConnection(KetNoi);
            con.Open();
            return con;
        }
        public string GetKetNoi()
        {
            return KetNoi;
        }
        public int ExecuteNonQuery(string query, List<SqlParameter> parameters = null) //
        {
            int data = 0; //

            // Sử dụng 'using' để tự động đóng kết nối
            using (SqlConnection conn = new SqlConnection(KetNoi))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray()); // Thêm tham số vào câu lệnh
                    }
                    data = cmd.ExecuteNonQuery();  // Thực thi câu lệnh
                }
            }
            return data;
        }
    }
}
