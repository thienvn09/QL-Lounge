using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class DanhMucSanPham 
    {
        public int MaDanhMuc { get; set; }

        public string TenDanhMuc { get; set; }

        public string Loai { get; set; } // "Đồ uống" hoặc "Món ăn"

        public decimal ThueVAT { get; set; } // 8.00 hoặc 10.00

        public string MoTa { get; set; }
    }
    
}
