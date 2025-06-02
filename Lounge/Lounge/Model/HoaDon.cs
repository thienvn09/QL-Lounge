// File: Lounge/Model/HoaDon.cs
using System;

namespace Lounge.Model
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; } 

        public int MaNhanVien { get; set; } 
        public string TenNhanVienLap { get; set; } 

        public int MaBan { get; set; }
        public string SoBan { get; set; } 

        public DateTime NgayDat { get; set; }
        public float TongTien { get; set; }     
        public float TienGiamGia { get; set; } 
        public float TongThueVAT { get; set; }
        public float ThanhToan { get; set; }  

        public int NguoiTao { get; set; } 
        public string TenNguoiTao { get; set; } 

        public string TrangThai { get; set; }
    }
}