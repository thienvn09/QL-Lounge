using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lounge.DAL
{
    public  class BanDAL
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
        public BanDAL()
        {
            MaBan = 0;
            TenBan = "";
            TrangThai = "";
            GhiChu = "";
        }
        public BanDAL(int maban, string tenban, string trangthai, string ghichu)
        {
            MaBan = maban;
            TenBan = tenban;
            TrangThai = trangthai;
            GhiChu = ghichu;
        }
    }
}
