using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class ChiTietBan
    {
        public int MaBan { get; set; }
        public string SoBan { get; set; }
        public string KhuVuc { get; set; }
        public string TrangThai { get; set; }
        public int? MaHoaDon { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public decimal ThueVAT { get; set; }
        public decimal ThanhTien => Gia * SoLuong;
        public decimal TienThue => Gia * SoLuong * ThueVAT / 100;
        public decimal TongTienMon => ThanhTien + TienThue;
    }
}
