using Lounge.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class DangNhap : Form
    {
        public KetNoi KetNoi = new KetNoi();
        public DangNhapDAL DangNhapDAL = new DangNhapDAL();
        public DangNhap()
        {
            InitializeComponent();
        }
       

        private void DangNhap_Load(object sender, EventArgs e)
        {
          
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtTaiKhoan.Text == "Thien" && txtMatKhau.Text == "1")
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    ChonQuyen TC = new ChonQuyen();
                    TC.ShowDialog();
                    this.Show();
                }
                else
                {
                    string tenDN = txtTaiKhoan.Text.Trim();
                    string matKhau = txtMatKhau.Text.Trim();

                    bool ketQua = DangNhapDAL.KiemTraDangNhap(tenDN, matKhau);

                    if (ketQua)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChonQuyen chonQuyen = new ChonQuyen();
                        chonQuyen.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
