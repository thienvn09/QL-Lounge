using Lounge.Model; // Giữ lại nếu các form con có thể cần đến
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
    public partial class FormQL : Form
    {
        private Form currentChildForm; // Đổi tên biến thành viên cho rõ ràng
        private Button currentActiveButton; // Lưu trữ nút đang active

        public FormQL()
        {
            InitializeComponent();
            // Đặt một màu nền mặc định cho pnlBody nếu muốn
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
        }

        private void OpenChildForm(Form childForm, Button activeButton)
        {
            if (currentChildForm != null)
            {
                // Đóng form con hiện tại
                currentChildForm.Close();
                currentChildForm.Dispose(); // Giải phóng tài nguyên
            }
            currentChildForm = childForm; // Gán form mới vào biến thành viên

            // Cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào pnlBody (đảm bảo tên Panel đúng)
            this.pnlBody.Controls.Add(childForm); // Sử dụng this.pnlBody
            this.pnlBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Làm nổi bật nút được nhấn
            ActivateButton(activeButton);
        }

        // Phương thức làm nổi bật nút được chọn và bỏ chọn các nút khác
        private void ActivateButton(Button activeButton)
        {
            if (activeButton == null) return;

            // Màu cho nút active và không active
            Color activeColor = Color.FromArgb(40, 40, 40); // Màu nền đậm hơn cho nút active
            Color inactiveColor = Color.FromArgb(70, 70, 70); // Màu nền mặc định của các nút

            // Đặt lại màu cho tất cả các nút trong pnlButtons
            foreach (Control previousBtn in pnlButtons.Controls) // Giả sử các nút nằm trong pnlButtons
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = inactiveColor;
                    ((Button)previousBtn).ForeColor = Color.WhiteSmoke; // Màu chữ mặc định
                }
            }
            // Đặt màu cho nút được active
            activeButton.BackColor = activeColor;
            activeButton.ForeColor = Color.Cyan; // Màu chữ khác cho nút active
            currentActiveButton = activeButton;
        }


        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nhanVienForm = new FormNhanVien();
            OpenChildForm(nhanVienForm, sender as Button);
          
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLKH(), sender as Button);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
           
             FormQLNCC nhaCungCapForm = new FormQLNCC();
            OpenChildForm(nhaCungCapForm, sender as Button);
            
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
             
             FormQLSP sanPhamForm = new FormQLSP();
             OpenChildForm(sanPhamForm, sender as Button);
           
        }

        private void btnLoaiSanPham_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLDanhMucSanPham(), sender as Button);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
        
             QLPhieuNhapKho phieuNhapForm = new QLPhieuNhapKho();
             OpenChildForm(phieuNhapForm, sender as Button);
            
           
        }

        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            // Giả sử bạn có QLPhieuXuatKho
             QLPhieuXuatKho phieuXuatForm = new QLPhieuXuatKho();
            OpenChildForm(phieuXuatForm, sender as Button);

        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormQLVoucher(), sender as Button);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLHoaDon(), sender as Button);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLBaoCao(), sender as Button);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            ActivateButton(sender as Button); 
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                this.Hide(); 
                DangNhap loginForm = new DangNhap(); 
                loginForm.ShowDialog();
                this.Close(); 
            }
            else
            {
                // Nếu người dùng chọn No, khôi phục lại màu của nút đã active trước đó (nếu có)
                if (currentActiveButton != null && currentActiveButton != (sender as Button))
                {
                    ActivateButton(currentActiveButton);
                }
                else if (currentActiveButton == (sender as Button)) // Nếu nút Đăng xuất đang active mà lại chọn No
                {
                    
                    (sender as Button).BackColor = Color.FromArgb(70, 70, 70);
                    (sender as Button).ForeColor = Color.WhiteSmoke;
                    currentActiveButton = null; // Không còn nút nào active
                }
            }
        }

       
        private void Panel_Body_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Panel3_Paint(object sender, PaintEventArgs e) // Panel3 giờ là pnlButtons
        {
            
        }

        private void FormQL_Load(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {

        }
    }
}
