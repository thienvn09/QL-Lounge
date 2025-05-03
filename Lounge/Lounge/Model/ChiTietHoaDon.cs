using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class ChiTietHoaDon
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public float Gia { get; set; }
        public float ThueVAT { get; set; }
        public float TienThue { get; set; }
        public float ThanhTien { get; set; }
        public string TenSanPham { get; set; }
    }
}
