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
            // Nên chỉ rõ các cột bạn cần thay vì SELECT *
            string query = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMucSanPham";
            SqlConnection connection = null; // Khai báo ở ngoài để có thể đóng trong finally
            SqlDataReader reader = null;   // Khai báo ở ngoài

            try
            {
                connection = KetNoi.GetOpenConnect(); // Giả sử hàm này trả về một SqlConnection đang mở
                SqlCommand cmd = new SqlCommand(query, connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DanhMucSanPham danhMucSP = new DanhMucSanPham();
                    // An toàn hơn khi dùng tên cột
                    danhMucSP.MaDanhMuc = reader.GetInt32(reader.GetOrdinal("MaDanhMuc"));
                    danhMucSP.TenDanhMuc = reader.GetString(reader.GetOrdinal("TenDanhMuc"));
                    dsDanhMucSP.Add(danhMucSP);
                }
            }
            catch (Exception ex)
            {
                // Bạn nên log lỗi ở đây để dễ debug
                Console.WriteLine("Lỗi khi lấy danh mục sản phẩm: " + ex.Message);
                // throw; // Hoặc throw lại lỗi nếu cần thiết
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close(); // Luôn đóng DataReader
                }
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close(); // Đóng kết nối nếu nó đang mở
                                        // Hoặc nếu lớp KetNoi có phương thức CloseConnect() thì gọi: KetNoi.CloseConnect();
                }
            }

            // Nếu bạn muốn lọc trùng tên ở đây (Cách 3 ở trên)
            // return dsDanhMucSP.GroupBy(dm => dm.TenDanhMuc)
            //                    .Select(group => group.First())
            //                    .ToList();

            return dsDanhMucSP;
        }
    }
}
