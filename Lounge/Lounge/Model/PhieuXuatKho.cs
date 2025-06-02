using System;

namespace Lounge.Model
{
    public class PhieuXuatKho
    {
        public int MaPhieuXuat { get; set; }
        public DateTime NgayXuat { get; set; }
        public int? MaNhanVien { get; set; }
        public string GhiChu { get; set; }
    }
}