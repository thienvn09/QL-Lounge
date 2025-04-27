using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class TrangChu : Form
    {
        private BanDAL banDAL = new BanDAL();
        private DanhMucSPDAL danhMucDAL = new DanhMucSPDAL();
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private Timer timer = new Timer();
        private Ban currentBan = null;
        private DanhMucSanPham currentDanhMuc = null;
        private List<SANPHAM> selectedSanPhams = new List<SANPHAM>();

        public TrangChu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ConfigurePanels();
            LoadBan();
            SetupTimer();
        }

        private void ConfigurePanels()
        {
            plnBan.AutoScroll = true;
            plnBan.Dock = DockStyle.Fill;
            plnBan.BackColor = Color.FromArgb(200, 220, 240);

            plnDanhMuc.AutoScroll = true;
            plnDanhMuc.BackColor = Color.FromArgb(200, 220, 240);
            plnDanhMuc.Padding = new Padding(10); // Thêm padding cho panel danh mục

            plnSanPham.AutoScroll = true;
            plnSanPham.BackColor = Color.FromArgb(200, 220, 240);
            plnSanPham.Padding = new Padding(10); // Thêm padding cho panel sản phẩm

            plnHoaDon.BackColor = Color.FromArgb(200, 220, 240);
            plnHoaDon.Padding = new Padding(10); // Thêm padding cho panel hóa đơn

            plnBan.Visible = true;
            plnDanhMuc.Visible = false;
            plnSanPham.Visible = false;
            plnHoaDon.Visible = false;
        }

        private void SetupTimer()
        {
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            timer.Start();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Admin | Operator | Tư Anh";
            lblTable.Text = "Table: N/A";
            lblCover.Text = "Cover: 0";
            lblWholeCheck.Text = "Whole Check: 0.00";
        }

        private void LoadBan()
        {
            plnBan.Controls.Clear();
            plnDanhMuc.Controls.Clear();
            plnSanPham.Controls.Clear();
            plnHoaDon.Controls.Clear();

            plnBan.Visible = true;
            plnMain.Visible = false;
            plnBottom.Visible = false;

            try
            {
                List<Ban> dsBan = banDAL.GetAllBan();
                if (dsBan == null || dsBan.Count == 0)
                {
                    MessageBox.Show("Không có bàn nào trong cơ sở dữ liệu! Vui lòng kiểm tra bảng Ban.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DisplayButtonsBan(dsBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayButtonsBan(List<Ban> dsBan)
        {
            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(10)
            };
            plnBan.Controls.Add(flowPanel);

            int buttonWidth = 200, buttonHeight = 120, margin = 10;
            int buttonsPerRow = 5;
            int count = 0;

            foreach (var ban in dsBan)
            {
                Button btn = new Button
                {
                    Text = $"{ban.SoBan}\n👤 {ban.SoChoNgoi}\n{ban.TrangThai}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(margin / 2),
                    BackColor = ban.TrangThai == "Trống" ? Color.FromArgb(102, 204, 102) : Color.FromArgb(255, 77, 77),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = ban
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += BtnBan_Click;
                flowPanel.Controls.Add(btn);

                count++;
                if (count % buttonsPerRow == 0)
                {
                    flowPanel.SetFlowBreak(btn, true);
                }
            }

            if (flowPanel.Controls.Count == 0)
            {
                MessageBox.Show("Không có nút bàn nào được hiển thị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDanhMuc()
        {
            plnDanhMuc.Controls.Clear();
            plnSanPham.Controls.Clear();
            plnHoaDon.Controls.Clear();

            plnBan.Visible = false;
            plnMain.Visible = true;
            plnDanhMuc.Visible = true;
            plnSanPham.Visible = true;
            plnHoaDon.Visible = true;
            plnBottom.Visible = true;

            lblTable.Text = $"Table: {currentBan?.SoBan ?? "N/A"}";
            lblCover.Text = $"Cover: {currentBan?.SoChoNgoi ?? 0}";
            lblWholeCheck.Text = "Whole Check: 0.00";

            try
            {
                List<DanhMucSanPham> dsDanhMuc = danhMucDAL.GetAllDanhMucSP();
                if (dsDanhMuc == null || dsDanhMuc.Count == 0)
                {
                    MessageBox.Show("Không có danh mục sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DisplayButtonsDanhMuc(dsDanhMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSanPhamTheoDanhMuc(int idDanhMuc)
        {
            plnSanPham.Controls.Clear();

            try
            {
                List<SANPHAM> dsSanPham = sanPhamDAL.GetSanPhamById(idDanhMuc);
                if (dsSanPham == null || dsSanPham.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào trong danh mục này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DisplayButtonsSanPham(dsSanPham);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayButtonsDanhMuc(List<DanhMucSanPham> dsDanhMuc)
        {
            var groupedDanhMuc = new Dictionary<string, List<DanhMucSanPham>>
            {
                { "FOOD", new List<DanhMucSanPham>() },
                { "ALCOHOLIC", new List<DanhMucSanPham>() },
                { "FUNCTION", new List<DanhMucSanPham>() }
            };

            foreach (var dm in dsDanhMuc)
            {
                if (dm.TenDanhMuc.Contains("Phở") || dm.TenDanhMuc.Contains("Soup"))
                    groupedDanhMuc["FOOD"].Add(dm);
                else if (dm.TenDanhMuc.Contains("Cocktail"))
                    groupedDanhMuc["ALCOHOLIC"].Add(dm);
                else
                    groupedDanhMuc["FUNCTION"].Add(dm);
            }

            int x = 0, y = 0;
            foreach (var group in groupedDanhMuc)
            {
                if (group.Value.Count == 0) continue;

                Label lblGroup = new Label
                {
                    Text = group.Key,
                    Font = new Font("Segoe UI", 14, FontStyle.Bold), // Tăng kích thước font tiêu đề
                    ForeColor = Color.Black,
                    BackColor = Color.FromArgb(180, 200, 220), // Thêm màu nền nhẹ
                    Padding = new Padding(5),
                    Location = new Point(x, y),
                    AutoSize = true
                };
                plnDanhMuc.Controls.Add(lblGroup);
                y += 40; // Tăng khoảng cách giữa tiêu đề và nút

                int buttonWidth = 100, buttonHeight = 60, margin = 10; // Tăng khoảng cách giữa các nút
                int buttonsPerRow = 3;
                int count = 0;

                foreach (var dm in group.Value)
                {
                    Button btn = new Button
                    {
                        Text = dm.TenDanhMuc,
                        Size = new Size(buttonWidth, buttonHeight),
                        Font = new Font("Segoe UI", 10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(x, y),
                        BackColor = dm.TenDanhMuc == "Corkage" ? Color.FromArgb(255, 204, 0) : Color.FromArgb(0, 153, 204),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat,
                        Tag = dm
                    };
                    btn.FlatAppearance.BorderSize = 1; // Thêm viền nhẹ
                    btn.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);
                    btn.Click += BtnDanhMuc_Click;
                    plnDanhMuc.Controls.Add(btn);

                    count++;
                    x += buttonWidth + margin;
                    if (count % buttonsPerRow == 0)
                    {
                        x = 0;
                        y += buttonHeight + margin;
                    }
                }
                x = 0;
                y += buttonHeight + 10; // Tăng khoảng cách giữa các nhóm
            }
        }

        private void DisplayButtonsSanPham(List<SANPHAM> dsSanPham)
        {
            int x = 0, y = 0;
            int buttonWidth = 150, buttonHeight = 70, margin = 10; // Giảm kích thước nút và khoảng cách
            int buttonsPerRow = 5; // Hiển thị 4 nút mỗi hàng

            foreach (var sp in dsSanPham)
            {
                Button btn = new Button
                {
                    Text = $"{sp.TenSanPham}\n{sp.Gia:N0}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Font = new Font("Segoe UI", 9), // Giảm kích thước font cho vừa nút
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(x, y),
                    BackColor = Color.FromArgb(0, 153, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = sp
                };
                btn.FlatAppearance.BorderSize = 1; // Thêm viền nhẹ
                btn.FlatAppearance.BorderColor = Color.FromArgb(150, 150, 150);
                btn.Click += BtnSanPham_Click;
                plnSanPham.Controls.Add(btn);

                x += buttonWidth + margin;
                if (x + buttonWidth > plnSanPham.Width)
                {
                    x = 0;
                    y += buttonHeight + margin;
                }
            }
        }

        private void DisplayHoaDon()
        {
            plnHoaDon.Controls.Clear();

            int y = 0;
            decimal total = 0;

            Label lblHeader = new Label
            {
                Text = "CHECK TYPE        IN HOUSE   SHARE",
                Font = new Font("Courier New", 10, FontStyle.Bold), // Sử dụng font monospace để căn chỉnh thẳng hàng
                Location = new Point(0, y),
                AutoSize = true
            };
            plnHoaDon.Controls.Add(lblHeader);
            y += 30;

            foreach (var sp in selectedSanPhams)
            {
                Label lblItem = new Label
                {
                    Text = $"{sp.TenSanPham,-20} {1,10} {sp.Gia,10:N0}", // Căn chỉnh thẳng hàng
                    Font = new Font("Courier New", 10), // Sử dụng font monospace
                    Location = new Point(0, y),
                    AutoSize = true
                };
                plnHoaDon.Controls.Add(lblItem);
                total += sp.Gia;
                y += 25;
            }

            y += 20;
            Label lblTotal = new Label
            {
                Text = $"WHOLE CHECK: {total:N0}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold), // Tăng kích thước font
                ForeColor = Color.FromArgb(0, 153, 204), // Thêm màu sắc nổi bật
                Location = new Point(0, y),
                AutoSize = true
            };
            plnHoaDon.Controls.Add(lblTotal);

            lblWholeCheck.Text = $"Whole Check: {total:N0}";
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentBan = btn.Tag as Ban;
            if (currentBan == null)
            {
                MessageBox.Show("Không tìm thấy bàn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedSanPhams.Clear();
            LoadDanhMuc();
        }

        private void BtnDanhMuc_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentDanhMuc = btn.Tag as DanhMucSanPham;
            if (currentDanhMuc == null)
            {
                MessageBox.Show("Không tìm thấy danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadSanPhamTheoDanhMuc(currentDanhMuc.MaDanhMuc);
        }

        private void BtnSanPham_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SANPHAM sp = btn.Tag as SANPHAM;
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            selectedSanPhams.Add(sp);
            DisplayHoaDon();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (plnMain.Visible)
            {
                LoadBan();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống quản lý nhà hàng\nPhiên bản 1.0\nPhát triển bởi Tư Anh", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            this.Close();
        }

        private void btnSendCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã được gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPrintCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hóa đơn đã được in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuestCheck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xem trước hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanh toán hoàn tất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            selectedSanPhams.Clear();
            DisplayHoaDon();
            LoadBan();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedSanPhams.Clear();
            DisplayHoaDon();
            LoadBan();
        }
    }
}