using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge
{
    internal class KetNoi
    {
        string sql ="LAPTOP-HCQ7FVIS\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True";
        public SqlConnection conn = null;
        public void MoKetNoi()
        {
            conn = new SqlConnection(sql);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void DongKetNoi()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        
    }
}
