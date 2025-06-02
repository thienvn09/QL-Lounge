using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class Voucher
    {
        public int MaVoucher { get; set; }
        public int? MaKhachHang { get; set; } // Cho phép null vì trong CSDL cột này không NOT NULL
        public int? MaSanPham { get; set; }   // Cho phép null vì trong CSDL cột này không NOT NULL
        public decimal GiaTri { get; set; }    // Dùng decimal cho tiền tệ
        public DateTime? NgayHetHan { get; set; } // Cho phép null nếu ngày hết hạn không bắt buộc, hoặc DateTime nếu luôn có
        public string TrangThai { get; set; }

        // Các thuộc tính bổ sung để hiển thị tên (tùy chọn, sẽ được điền từ DAL nếu cần)
        public string TenKhachHang { get; set; }
        public string TenSanPham { get; set; }
    }
}
