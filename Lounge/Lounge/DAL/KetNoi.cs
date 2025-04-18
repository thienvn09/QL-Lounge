using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lounge
{
    public class KetNoi
    {
        // Chuỗi kết nối
        private static readonly string connectionString = "Data Source=THIEN\\SQLEXPRESS;Initial Catalog=QL_NHAHANG1;Integrated Security=True";

        // Trả về kết nối, KHÔNG mở sẵn
        public SqlConnection GetConnect()
        {
            return new SqlConnection(connectionString);
        }

        // Thực thi lệnh INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query, List<SqlParameter> parameters = null)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        // Thực thi truy vấn SELECT → trả về DataTable
        public DataTable ExecuteQuery(string query, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        // Ví dụ cụ thể: Lấy toàn bộ dữ liệu từ bảng DangNhap
    }
}
