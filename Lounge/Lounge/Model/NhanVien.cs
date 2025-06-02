using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.Model
{
    public class NhanVien
    {
        public int MaNhanvien { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }

        public string SDT_NV { get; set; }
        public DateTime NgayTao { get; set; }
        public string Email_NV { get; set; }

    }
}
