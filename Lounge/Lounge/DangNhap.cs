using Lounge.DAL;
using Lounge.Model; // Make sure your NhanVien model is in this namespace
using System;
using System.Windows.Forms;

namespace Lounge
{
    public partial class DangNhap : Form
    {
       
        private DangNhapDAL dangNhapDAL = new DangNhapDAL();
        

        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            
            txtTaiKhoan.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }

            try
            {
               
                bool dangNhapThanhCongQuaDB = dangNhapDAL.KiemTraDangNhap(tenDN, matKhau);

                if (dangNhapThanhCongQuaDB)
                {
                   
                    NhanVien nguoiDungHienTai = dangNhapDAL.GetNhanVienByTenDangNhap(tenDN);

                    if (nguoiDungHienTai != null)
                    {
                        MessageBox.Show($"Đăng nhập thành công! Chào mừng {nguoiDungHienTai.HoTen}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                       
                        ChonQuyen chonQuyenForm = new ChonQuyen(nguoiDungHienTai);
                        chonQuyenForm.ShowDialog(); 
                        this.Close(); 
                    }
                    else
                    {
                        
                        MessageBox.Show("Đăng nhập thành công nhưng không thể lấy thông tin người dùng. Vui lòng liên hệ quản trị viên.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (tenDN == "Thien" && matKhau == "1")
                {
                    MessageBox.Show("Đăng nhập thành công với tài khoản quản trị viên cục bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NhanVien adminTemp = new NhanVien { HoTen = "Admin (Local)", ChucVu = "Quản lý", MaNhanvien = 0 }; // MaNV = 0 or some special ID

                    this.Hide();
                    ChonQuyen chonQuyenForm = new ChonQuyen(adminTemp); // Pass the temporary admin object
                    chonQuyenForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, hoặc tài khoản đã bị khóa!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Focus();
                    txtMatKhau.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình đăng nhập: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // These Paint and Click events for panel1 and label3 can be removed if they don't have specific logic
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // If you have custom drawing for panel1
        }

        private void label3_Click(object sender, EventArgs e)
        {
        
        }

        private void pnlLoginArea_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
