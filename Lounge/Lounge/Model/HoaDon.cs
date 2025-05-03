using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public int MaNhanVien { get; set; }
        public int MaBan { get; set; }
        public DateTime NgayDat { get; set; }
        public float TongTien { get; set; }
        public float TienGiamGia { get; set; }
        public float TongThueVAT { get; set; }
        public float ThanhToan { get; set; }
        public int NguoiTao { get; set; }

    }
}
