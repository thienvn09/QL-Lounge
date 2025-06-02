using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class BaoCao
    {
        public int MaBaoCao { get; set; }
        public string LoaiBaoCao { get; set; }
        public DateTime NgayBaoCao { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongChiPhi { get; set; }
        public int SoHoaDon { get; set; }
        public int SoKhachHang { get; set; }
        public int SoSanPhamBanRa { get; set; }
        public int? NguoiTao { get; set; }
        public string GhiChu { get; set; }
        public decimal LoiNhuan { get; internal set; }
        public string TenNguoiTao { get; internal set; }
    }
}
