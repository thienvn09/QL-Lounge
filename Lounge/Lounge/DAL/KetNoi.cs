using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge
{
    public class KetNoi
    {
        static string ketnoi = "Data Source=LAPTOP-HCQ7FVIS\\SQLEXPRESS;Initial Catalog=QL_NHAHANG;Integrated Security=True";
        public SqlConnection GetConnect()
        {
            SqlConnection conn = new SqlConnection(ketnoi);
            conn.Open();
            return conn;
        }
        public string GetConnectionString()
        {
            return ketnoi;
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters = null)
        {
            int data = 0;

            // Sử dụng 'using' để tự động đóng kết nối
            using (SqlConnection conn = new SqlConnection(ketnoi))
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
        // thong tin tai khoan
        public DataTable DangNhap()
        {
            DataTable tb = new DataTable();
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                conn.Open();
                string query = "select * from DangNhap";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // thong tin khach hang
        public DataTable KhachHang()
        {
            DataTable tb = new DataTable();
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                conn.Open();
                string query = "select * from KhachHang";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // thong tin nhan vien
        public DataTable NhanVien()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                con.Open();
                string query = "select * from NhanVien";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // danh muc san pham
        public DataTable DanhMucSanPham()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                con.Open();
                string query = "select * from DanhMucSanPham";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // thong tin san pham
        public DataTable SanPham()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                con.Open();
                string query = "select * from SanPham";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // thong tin bàn
        public DataTable Ban()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                con.Open();
                string query = "select * from Ban";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }
            }
            return tb;
        }
        // thong tin hoa don
        public DataTable HoaDon()
        {
            DataTable tb = new DataTable();
            using (SqlConnection con = new SqlConnection(ketnoi))
            {
                con.Open();
                string query = "select * from HoaDon";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(tb);
                }

            }
            return tb;
        }
    }
}