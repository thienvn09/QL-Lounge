using Lounge.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class ChonQuyen : Form
    {
        public KetNoi ketNoi = new KetNoi();
        public NhanVienDAL nhanVienDAL = new NhanVienDAL();
        public ChonQuyen()
        {
            InitializeComponent();
        }

        private void btnBH_Click(object sender, EventArgs e)
        {
                TrangChu from = new TrangChu();
                from.Show();
        }

        private void BtnQT_Click(object sender, EventArgs e)
        {
            if (nhanVienDAL.CheckChucVuTonTai("Quản lý"))
            {
                FormQL form = new FormQL();
                form.Show();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
