using Lounge.DAL;
using Lounge.Model; // Assuming NhanVien model is here
using System;
using System.Windows.Forms;

namespace Lounge
{
    public partial class ChonQuyen : Form
    {
        // Store the logged-in employee's information
        private NhanVien loggedInNhanVien;
        // If you only pass MaNV, you'll need NhanVienDAL to get the ChucVu
        // private int loggedInMaNV; 

        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        // Constructor to receive NhanVien object from DangNhap form
        public ChonQuyen(NhanVien nhanVien)
        {
            InitializeComponent();
            this.loggedInNhanVien = nhanVien;
            // You can also pass MaNV and then fetch NhanVien object here if preferred
            // this.loggedInMaNV = maNV;
            // this.loggedInNhanVien = nhanVienDAL.GetNhanVienById(maNV); // Assuming GetNhanVienById exists
        }

        // Fallback constructor if no user info is passed (less secure for role checking)
        public ChonQuyen()
        {
            InitializeComponent();
            // This constructor might be used if direct access is allowed or for testing,
            // but role checking will be generic or disabled.
            // Consider if this scenario is valid for your application.
            // If not, you might remove this constructor or handle it appropriately.
            // For now, let's assume a default or no specific user for this case.
            this.loggedInNhanVien = null;
        }


        private void ChonQuyen_Load(object sender, EventArgs e)
        {
            // Set a more welcoming message, possibly with the user's name
            if (loggedInNhanVien != null && !string.IsNullOrEmpty(loggedInNhanVien.HoTen))
            {
                lblWelcome.Text = $"Chào mừng, {loggedInNhanVien.HoTen}!\nVui lòng chọn chức năng.";
            }
            else
            {
                lblWelcome.Text = "Chào mừng bạn!\nVui lòng chọn chức năng.";
            }
        }

        private void btnBH_Click(object sender, EventArgs e)
        {
            // Always allow access to TrangChu (POS interface)
            TrangChu trangChuForm = new TrangChu(); // Consider passing loggedInNhanVien.MaNV to TrangChu if needed
            trangChuForm.Show();
            // Optionally hide or close ChonQuyen form
            // this.Hide(); 
        }

        private void BtnQT_Click(object sender, EventArgs e)
        {
            bool coQuyenQuanTri = false;

            if (loggedInNhanVien != null)
            {
                // Option 1: If NhanVien model has ChucVu directly
                if (!string.IsNullOrEmpty(loggedInNhanVien.ChucVu) && loggedInNhanVien.ChucVu.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
                {
                    coQuyenQuanTri = true;
                }
                // Option 2: If you need to fetch ChucVu from DB using MaNV (if not already in loggedInNhanVien object)
                // This assumes GetNhanVienById in NhanVienDAL returns a NhanVien object with ChucVu
                // NhanVien currentUser = nhanVienDAL.GetNhanVienById(loggedInNhanVien.MaNV); // Assuming MaNV is the correct property
                // if (currentUser != null && currentUser.ChucVu.Equals("Quản lý", StringComparison.OrdinalIgnoreCase))
                // {
                //    coQuyenQuanTri = true;
                // }
            }
            else
            {
                // Fallback if no user info - for testing or if direct access is allowed (less secure)
                // This relies on your NhanVienDAL.CheckChucVuTonTai("Quản lý") which checks if *any* manager exists.
                // For a real application, this part should ideally be removed or secured.
                coQuyenQuanTri = nhanVienDAL.CheckChucVuTonTai("Quản lý"); // This is a generic check
                if (coQuyenQuanTri)
                {
                    MessageBox.Show("Cảnh báo: Đang truy cập Quản trị mà không có thông tin người dùng cụ thể.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


            if (coQuyenQuanTri)
            {
                FormQL formQL = new FormQL(); // Pass loggedInNhanVien if FormQL needs it
                formQL.Show();
                // Optionally hide or close ChonQuyen form
                // this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng Quản trị Hệ thống.", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
          
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); // Hide ChonQuyen form
                DangNhap loginForm = new DangNhap();
                loginForm.ShowDialog(); // Show login form as a dialog
                this.Close(); // Close ChonQuyen form after login form is closed
            }
        }
    }
}
