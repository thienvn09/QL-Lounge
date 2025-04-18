using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lounge.DAL;

using System.Windows.Forms;
using Lounge.Model;

namespace Lounge
{
    public partial class TrangChu : Form
    {
        private Ban ban = new Ban();
        private DanhMucSanPham danhMucSanPham = new DanhMucSanPham();
        public DanhMucSPDAL DanhMucSPDAL = new DanhMucSPDAL();
        BanDAL banDAL = new BanDAL();
        public SanPhamDAL sanPhamDAL = new SanPhamDAL();
        public SANPHAM SP = new SANPHAM();
        
        public TrangChu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
         /*   plnDanhMuc.Visible = false;*/ // Ẩn panel danh mục lúc đầu
            plnBan.Visible = true;      // Hiện panel bàn lúc đầu
            LoadBan();
         
        }
       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            this.Close();
        }
       

        private void TrangChu_Load(object sender, EventArgs e)
        {
          
        }
        private void LoadSPTheoDanhMuc(int maDanhMuc)
        {
            List<SANPHAM> dsSanPham = sanPhamDAL.GetSanPhamTheoDanhMuc(maDanhMuc);
            plnBan.Controls.Clear();

            int x = 10, y = 10;
            int count = 0;

            foreach (var sp in dsSanPham)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 80;
                btn.Text = $"{sp.TenSanPham}\n{sp.Gia} VND";
                btn.BackColor = Color.RoyalBlue;
                btn.ForeColor = Color.Orange;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Tag = sp.MaSanPham;

                btn.Location = new Point(x, y);
                plnBan.Controls.Add(btn);

                x += 130;
                count++;
                if (count % 4 == 0)
                {
                    x = 10;
                    y += 90;
                }
            }
        }

        private void LoadDanhMuc()
        {
            plnBan.Visible = true;
            plnBan.Controls.Clear();
            List<DanhMucSanPham> dmsp = DanhMucSPDAL.GetAllDanhMucSP();
            int x = 10, y = 10;
            int count = 0;
            foreach (var danhMucSanPham in dmsp)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 80;
                btn.Text = danhMucSanPham.TenDanhMuc;
                btn.BackColor = Color.RoyalBlue;
                btn.ForeColor = Color.Orange;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Tag = danhMucSanPham.MaDanhMuc;
                btn.Location = new Point(x, y);
                // Gắn đúng sự kiện click
                btn.Click += DanhMuc_Click;
                plnBan.Controls.Add(btn);
                x += 130;
                count++;
                if (count % 4 == 0)
                {
                    x = 10;
                    y += 90;
                }
            }
        }
        private void LoadBan()
        {
            plnBan.Controls.Clear();
            List<Ban> dsban = banDAL.GetAllBan();
            int x = 10, y = 10;
            int count = 0;

            foreach (var ban in dsban)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 80;
                btn.Text = $"{ban.SoBan}\n👤 {ban.SoChoNgoi}\n{ban.TrangThai}";
                btn.BackColor = ban.TrangThai == "Đang sử dụng" ? Color.RoyalBlue : Color.LightGray;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Tag = ban.MaBan;

                btn.Location = new Point(x, y);

                // Gắn đúng sự kiện click
                btn.Click += Ban_Click;

                plnBan.Controls.Add(btn);

                x += 130;
                count++;
                if (count % 4 == 0)
                {
                    x = 10;
                    y += 90;
                }
                
            }
            
        }
        private void Ban_Click(object sender, EventArgs e)
        {
            plnBan.Visible = false;
            plnBan.Controls.Clear();
           
            LoadDanhMuc();

            int maBan = (int)(sender as Button).Tag;
            ban = banDAL.getbanByid(maBan);

            MessageBox.Show($"Bạn đã chọn bàn số: {ban.SoBan}");
        }

        private void DanhMuc_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag != null)
            {
                int maDanhMuc = Convert.ToInt32(button.Tag);
                MessageBox.Show($"Bạn đã chọn danh mục có mã: {maDanhMuc}");

      
                plnBan.Visible = true;

                LoadSPTheoDanhMuc(maDanhMuc);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra: Button hoặc Tag không hợp lệ.");
            }
        }
        private void btnTim1_Click(object sender, EventArgs e)
        {
            frmThemBan frm = new frmThemBan();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Ban newBan = frm.banmoi;

                var daTonTai = banDAL.GetBanBySoBan(newBan.SoBan);
               if(daTonTai != null)
                {
                    MessageBox.Show("Bàn đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (banDAL.AddNewBan(newBan))
                {
                    MessageBox.Show("Thêm bàn thành công!");
                    LoadBan();
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại!");
                }
            }
         }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            LoadBan();
        }
    }
}
