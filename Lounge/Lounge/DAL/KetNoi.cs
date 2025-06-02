using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lounge
{
    public class KetNoi
    {
        // Chuỗi kết nối đến SQL Server
        private static readonly string connectionString = "Data Source=THIEN\\SQLEXPRESS;Initial Catalog=QL_NHAHANG;Integrated Security=True";

        /// <summary>
        /// Trả về đối tượng SqlConnection chưa mở
        /// </summary>
        public SqlConnection GetConnect()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Trả về đối tượng SqlConnection đã được mở sẵn
        /// </summary>
        public SqlConnection GetOpenConnect()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open(); // Quan trọng!
            }
            return conn;
        }

        /// <summary>
        /// Đóng kết nối nếu đang mở
        /// </summary>
        public void CloseConnect(SqlConnection conn)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE
        /// </summary>
        /// <param name="query">Câu lệnh SQL</param>
        /// <param name="parameters">Danh sách tham số (nếu có)</param>
        /// <returns>Số dòng bị ảnh hưởng</returns>
        public int ExecuteNonQuery(string query, List<SqlParameter> parameters = null)
        {
            int result = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    result = cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về dữ liệu dưới dạng DataTable
        /// </summary>
        /// <param name="query">Câu lệnh SELECT</param>
        /// <param name="parameters">Danh sách tham số (nếu có)</param>
        /// <returns>DataTable chứa dữ liệu kết quả</returns>
        public DataTable ExecuteQuery(string query, List<SqlParameter> parameters = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Count > 0)
                        cmd.Parameters.AddRange(parameters.ToArray());

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}
