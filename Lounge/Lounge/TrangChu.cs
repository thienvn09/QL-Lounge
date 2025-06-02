using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Cần cho Linq
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
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private DanhMucSanPham currentDanhMuc = null;
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private HoaDon currentHoaDon = null; // Hóa đơn đang được xử lý (có thể chưa lưu vào DB)
        private int maNhanVien = 1; // TODO: Lấy từ thông tin đăng nhập

        // Danh sách tạm thời để lưu các mục order trước khi gửi bếp
        private List<ChiTietHoaDon> tempOrderItems = new List<ChiTietHoaDon>();
        private bool daGuiBep = false; // Cờ để biết đã gửi bếp hay chưa

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
            plnBan.Dock = DockStyle.Fill;
            plnBan.BackColor = Color.FromArgb(200, 220, 240);

            plnMain.Dock = DockStyle.Fill;
            plnMain.Visible = false;

            plnDanhMuc.Dock = DockStyle.Left;
            plnDanhMuc.Width = 280;
            plnDanhMuc.BackColor = Color.FromArgb(210, 230, 250);
            plnDanhMuc.Padding = new Padding(10);
            plnDanhMuc.AutoScroll = true;

            plnSanPham.Dock = DockStyle.Fill;
            plnSanPham.BackColor = Color.FromArgb(220, 240, 255);
            plnSanPham.Padding = new Padding(10);
            plnSanPham.AutoScroll = true;

            plnHoaDon.Dock = DockStyle.Right;
            plnHoaDon.Width = 420;
            plnHoaDon.BackColor = Color.FromArgb(200, 220, 240);
            plnHoaDon.Padding = new Padding(10);
            plnHoaDon.AutoScroll = true;

            plnBottom.BackColor = Color.FromArgb(50, 50, 50);
            plnBottom.Visible = false;
            plnBottom.Height = 70;

            // Đổi tên nút btnPaid thành btnPrintTempBill (ví dụ) trong Designer
            // Và cập nhật sự kiện click của nó
            // btnPaid.Text = "IN TẠM"; // Làm trong Designer hoặc ở đây
            // btnPaid.Click -= new System.EventHandler(this.btnPaid_Click); // Xóa sự kiện cũ
            // btnPaid.Click += new System.EventHandler(this.btnPrintTempBill_Click); // Thêm sự kiện mới
        }

        private void SetupTimer()
        {
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            timer.Start();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lblTable.Text = "Bàn: N/A";
            lblCover.Text = "Khách: 0";
            lblWholeCheck.Text = "Tổng cộng: 0.00";
            // Đổi tên nút btnPaid thành btnPrintTemp (ví dụ)
            btnPaid.Text = "IN TẠM"; // Hoặc tên gì đó phù hợp với "In Tạm Tính"
        }

        private void LoadBan()
        {
            plnBan.Controls.Clear();
            plnBan.Visible = true;
            plnMain.Visible = false;
            plnBottom.Visible = false;
            lblTable.Text = "Bàn: N/A";
            lblCover.Text = "Khách: 0";
            lblWholeCheck.Text = "Tổng cộng: 0.00";
            tempOrderItems.Clear(); // Xóa các mục tạm thời khi quay lại chọn bàn
            daGuiBep = false; // Reset cờ gửi bếp
            currentHoaDon = null; // Reset hóa đơn hiện tại

            try
            {
                List<Ban> dsBan = banDAL.GetAllBan();
                if (dsBan == null || dsBan.Count == 0)
                {
                    MessageBox.Show("Không có bàn nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DisplayButtonsBan(dsBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải bàn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayButtonsBan(List<Ban> dsBan)
        {
            FlowLayoutPanel flowPanelBan = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                Padding = new Padding(20)
            };
            plnBan.Controls.Add(flowPanelBan);
            int buttonWidth = 180, buttonHeight = 110, margin = 15;
            foreach (var ban in dsBan)
            {
                Button btn = new Button
                {
                    Text = $"{ban.SoBan}\n👤 {ban.SoChoNgoi}\n{ban.TrangThai}",
                    Size = new Size(buttonWidth, buttonHeight),
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(margin),
                    BackColor = ban.TrangThai == "Trống" ? Color.FromArgb(76, 175, 80) : Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = ban
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += BtnBan_Click;
                flowPanelBan.Controls.Add(btn);
            }
        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentBan = btn.Tag as Ban;
            if (currentBan == null) return;

            plnBan.Visible = false;
            plnMain.Visible = true;
            plnBottom.Visible = true;
            lblTable.Text = $"Bàn: {currentBan.SoBan}";
            lblCover.Text = $"Khách: {currentBan.SoChoNgoi}";
            tempOrderItems.Clear(); // Bắt đầu danh sách tạm mới cho bàn mới
            daGuiBep = false;

            // Kiểm tra xem bàn này có hóa đơn CHƯA THANH TOÁN đang tồn tại không
            // Nếu có, tải các chi tiết của nó vào tempOrderItems và currentHoaDon
            // Nếu không, currentHoaDon sẽ là null ban đầu
            LoadExistingUnpaidOrderForTable();

            LoadMainCategories();
            DisplayHoaDon(); // Hiển thị hóa đơn (có thể trống hoặc từ hóa đơn cũ)
        }

        private void LoadExistingUnpaidOrderForTable()
        {
            if (currentBan == null) return;
            try
            {
                currentHoaDon = hoaDonDAL.l(currentBan.MaBan);
                if (currentHoaDon != null)
                {
                    // Đã có hóa đơn chưa thanh toán, tải chi tiết vào tempOrderItems
                    List<ChiTietHoaDon> existingDetails = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);
                    if (existingDetails != null)
                    {
                        tempOrderItems.AddRange(existingDetails);
                    }
                    daGuiBep = true; // Coi như đã gửi bếp nếu tải hóa đơn cũ
                    MessageBox.Show($"Đã tải hóa đơn #{currentHoaDon.MaHoaDon} chưa thanh toán cho bàn {currentBan.SoBan}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    currentHoaDon = null; // Chưa có hóa đơn nào cho bàn này hoặc tất cả đã thanh toán
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hóa đơn cũ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentHoaDon = null;
            }
        }


        private void LoadMainCategories()
        {
            plnDanhMuc.Controls.Clear();
            plnSanPham.Controls.Clear();
            try
            {
                List<DanhMucSanPham> dsDanhMucChinh = danhMucDAL.GetAllDanhMucSP();
                if (dsDanhMucChinh == null || dsDanhMucChinh.Count == 0)
                {
                    Label lblNoCategories = new Label { Text = "Không có danh mục.", Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, AutoSize = true, Location = new Point(10, 10) };
                    plnDanhMuc.Controls.Add(lblNoCategories); return;
                }
                DisplayButtonsMainCategories(dsDanhMucChinh);
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DisplayButtonsMainCategories(List<DanhMucSanPham> dsDanhMucChinh)
        {
            FlowLayoutPanel flowPanelMainCat = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown, WrapContents = false, AutoScroll = true, Padding = new Padding(5) };
            plnDanhMuc.Controls.Add(flowPanelMainCat);
            int buttonHeight = 55;
            foreach (var dm in dsDanhMucChinh)
            {
                Button btn = new Button
                {
                    Text = dm.TenDanhMuc,
                    Height = buttonHeight,
                    Width = flowPanelMainCat.ClientSize.Width - 15,
                    Font = new Font("Segoe UI", 10),
                    BackColor = Color.FromArgb(63, 81, 181),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = dm,
                    Margin = new Padding(0, 0, 0, 8)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += BtnMainCategory_Click;
                flowPanelMainCat.Controls.Add(btn);
            }
        }

        private void BtnMainCategory_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentDanhMuc = btn.Tag as DanhMucSanPham;
            if (currentDanhMuc == null) return;
            LoadProductsOrSubCategories(currentDanhMuc.MaDanhMuc);
        }

        private void LoadProductsOrSubCategories(int maDanhMucChinh)
        {
            plnSanPham.Controls.Clear();
            try
            {
                List<SANPHAM> dsSanPham = sanPhamDAL.GetSanPhamById(maDanhMucChinh);
                if (dsSanPham == null || dsSanPham.Count == 0)
                {
                    Label lblNoProducts = new Label { Text = "Không có sản phẩm.", Font = new Font("Segoe UI", 10), ForeColor = Color.DimGray, TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
                    plnSanPham.Controls.Add(lblNoProducts); return;
                }
                DisplayProductButtons(dsSanPham);
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DisplayProductButtons(List<SANPHAM> dsSanPham)
        {
            FlowLayoutPanel flowPanelProducts = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true, FlowDirection = FlowDirection.LeftToRight, WrapContents = true, Padding = new Padding(10) };
            plnSanPham.Controls.Add(flowPanelProducts);
            int buttonWidth = 140, buttonHeight = 90, margin = 10;
            foreach (var sp in dsSanPham)
            {
                Button btn = new Button
                {
                    Text = $"{sp.TenSanPham}\n{sp.Gia:N0}đ",
                    Size = new Size(buttonWidth, buttonHeight),
                    Font = new Font("Segoe UI", 9),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Margin = new Padding(margin),
                    BackColor = Color.FromArgb(0, 122, 204),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Tag = sp
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += BtnSanPham_Click_Temp; // Sử dụng hàm tạm thời
                flowPanelProducts.Controls.Add(btn);
            }
        }

        // Xử lý thêm sản phẩm vào danh sách tạm thời
        private void BtnSanPham_Click_Temp(object sender, EventArgs e)
        {
            if (daGuiBep && currentHoaDon != null && currentHoaDon.TrangThai == "Chưa thanh toán")
            {
                DialogResult dialogResult = MessageBox.Show("Hóa đơn đã được gửi bếp. Bạn có muốn cập nhật (gửi lại toàn bộ hóa đơn) không?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return; // Không làm gì nếu không muốn cập nhật
                }
                // Nếu Yes, thì sẽ cho thêm/sửa và khi nhấn "Gửi bếp" lại, nó sẽ xử lý cập nhật.
                // Cần cơ chế để DAL biết đây là cập nhật (ví dụ: xóa chi tiết cũ, thêm mới)
            }


            Button btn = sender as Button;
            SANPHAM sp = btn.Tag as SANPHAM;
            if (sp == null) return;

            // Lấy VAT
            decimal thueVATValue = 0;
            DanhMucSanPham dmCuaSP = currentDanhMuc; // Ưu tiên danh mục đang chọn
            if (dmCuaSP == null || dmCuaSP.MaDanhMuc != sp.MaDanhMuc) // Nếu không có hoặc không khớp
            {
                dmCuaSP = danhMucDAL.GetDanhMucById(sp.MaDanhMuc);
            }
            if (dmCuaSP != null) thueVATValue = dmCuaSP.ThueVAT;
            else thueVATValue = 10; // Mặc định

            var existingItem = tempOrderItems.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
            if (existingItem != null)
            {
                existingItem.SoLuong++;
                existingItem.ThanhTien = existingItem.SoLuong * existingItem.Gia; // Tính lại thành tiền
                existingItem.TienThue = existingItem.ThanhTien * (existingItem.ThueVAT / 100); // Tính lại tiền thuế
            }
            else
            {
                ChiTietHoaDon newItem = new ChiTietHoaDon
                {
                    // MaHoaDon sẽ được gán khi gửi bếp
                    MaSanPham = sp.MaSanPham,
                    TenSanPham = sp.TenSanPham,
                    SoLuong = 1,
                    Gia = (float)sp.Gia,
                    ThueVAT = (float)thueVATValue
                };
                newItem.ThanhTien = newItem.SoLuong * newItem.Gia;
                newItem.TienThue = newItem.ThanhTien * (newItem.ThueVAT / 100);
                tempOrderItems.Add(newItem);
            }
            DisplayHoaDon(); // Cập nhật hiển thị hóa đơn từ danh sách tạm
        }


        private void DisplayHoaDon()
        {
            plnHoaDon.Controls.Clear();
            // Panel chứa các mục hóa đơn, cho phép cuộn
            FlowLayoutPanel flowPanelBillItems = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(5)
            };
            // Panel cố định ở dưới cho tổng tiền
            Panel panelTotals = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 120,
                BackColor = Color.FromArgb(230, 230, 230),
                Padding = new Padding(10)
            };
            plnHoaDon.Controls.Add(flowPanelBillItems);
            plnHoaDon.Controls.Add(panelTotals);

            Label lblHeader = new Label
            {
                Text = string.Format("{0,-23} {1,3} {2,8} {3,10} {4,2}", "Tên món", "SL", "Đ.Giá", "T.Tiền", ""), // Thêm cột cho nút X
                Font = new Font("Courier New", 9, FontStyle.Bold),
                AutoSize = false,
                Width = flowPanelBillItems.ClientSize.Width - 5,
                Height = 20,
                Margin = new Padding(0, 0, 0, 5),
            };
            flowPanelBillItems.Controls.Add(lblHeader);

            decimal subTotalDisplay = 0;
            decimal totalVATDisplay = 0;

            if (tempOrderItems.Any())
            {
                for (int i = 0; i < tempOrderItems.Count; i++)
                {
                    var chiTiet = tempOrderItems[i];
                    subTotalDisplay += (decimal)chiTiet.ThanhTien;
                    totalVATDisplay += (decimal)chiTiet.TienThue;

                    Panel itemPanel = new Panel
                    {
                        Width = flowPanelBillItems.ClientSize.Width - 10, // Trừ padding
                        Height = 25, // Chiều cao mỗi dòng
                        Margin = new Padding(0, 0, 0, 2)
                    };

                    Label lblItem = new Label
                    {
                        Text = string.Format("{0,-23} {1,3} {2,8:N0} {3,10:N0}",
                                             TruncateString(chiTiet.TenSanPham ?? "N/A", 21),
                                             chiTiet.SoLuong, chiTiet.Gia, chiTiet.ThanhTien),
                        Font = new Font("Courier New", 9),
                        AutoSize = false,
                        Dock = DockStyle.Fill, // Label chiếm hết panel trừ nút X
                        // Location = new Point(0,0) // Không cần nếu dùng Dock
                    };
                    itemPanel.Controls.Add(lblItem);

                    if (!daGuiBep || (currentHoaDon != null && currentHoaDon.TrangThai == "Chưa thanh toán")) // Chỉ cho xóa nếu chưa gửi bếp HOẶC hóa đơn đang chờ cập nhật
                    {
                        Button btnDeleteItem = new Button
                        {
                            Text = "X",
                            ForeColor = Color.Red,
                            Font = new Font("Arial", 8, FontStyle.Bold),
                            FlatStyle = FlatStyle.System, // Hoặc FlatStyle.Flat và tùy chỉnh thêm
                            Size = new Size(20, 20),
                            Dock = DockStyle.Right, // Nút X ở bên phải
                            Tag = chiTiet // Gán đối tượng ChiTietHoaDon vào Tag
                        };
                        btnDeleteItem.Click += BtnDeleteItem_Click;
                        itemPanel.Controls.Add(btnDeleteItem);
                        lblItem.Width = itemPanel.Width - btnDeleteItem.Width - 5; // Điều chỉnh width của label
                    }
                    flowPanelBillItems.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label lblNoBill = new Label { Text = "Vui lòng chọn món...", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12), ForeColor = Color.Gray };
                flowPanelBillItems.Controls.Add(lblNoBill);
            }

            decimal discountDisplay = (decimal)(currentHoaDon?.TienGiamGia ?? 0); // Nếu currentHoaDon null, giảm giá là 0
            decimal grandTotalDisplay = subTotalDisplay + totalVATDisplay - discountDisplay;


            Label lblSubTotalText = new Label { Text = "Tạm tính:", Font = new Font("Segoe UI", 10), Location = new Point(10, 10), AutoSize = true };
            Label lblSubTotalValue = new Label { Text = $"{subTotalDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 10), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };
            Label lblVATText = new Label { Text = "Thuế VAT:", Font = new Font("Segoe UI", 10), Location = new Point(10, 35), AutoSize = true };
            Label lblVATValue = new Label { Text = $"{totalVATDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 35), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };
            Label lblDiscountText = new Label { Text = "Giảm giá:", Font = new Font("Segoe UI", 10), Location = new Point(10, 60), AutoSize = true };
            Label lblDiscountValue = new Label { Text = $"{discountDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.IndianRed, Location = new Point(200, 60), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };
            Label lblGrandTotalText = new Label { Text = "TỔNG CỘNG:", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(10, 85), AutoSize = true };
            Label lblGrandTotalValue = new Label { Text = $"{grandTotalDisplay:N0}đ", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(0, 122, 204), Location = new Point(180, 85), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 200 };

            panelTotals.Controls.Add(lblSubTotalText); panelTotals.Controls.Add(lblSubTotalValue);
            panelTotals.Controls.Add(lblVATText); panelTotals.Controls.Add(lblVATValue);
            panelTotals.Controls.Add(lblDiscountText); panelTotals.Controls.Add(lblDiscountValue);
            panelTotals.Controls.Add(lblGrandTotalText); panelTotals.Controls.Add(lblGrandTotalValue);

            lblWholeCheck.Text = $"Tổng cộng: {grandTotalDisplay:N0}đ";
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            if (daGuiBep && currentHoaDon != null && currentHoaDon.TrangThai == "Chưa thanh toán")
            {
                DialogResult dialogResult = MessageBox.Show("Hóa đơn đã được gửi bếp. Bạn có muốn cập nhật (gửi lại toàn bộ hóa đơn) không? Việc xóa món này sẽ yêu cầu gửi lại bếp.", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            Button btn = sender as Button;
            ChiTietHoaDon itemToRemove = btn.Tag as ChiTietHoaDon;
            if (itemToRemove != null)
            {
                tempOrderItems.Remove(itemToRemove);
                DisplayHoaDon(); // Cập nhật lại hiển thị
            }
        }


        private string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (plnMain.Visible)
            {
                if (tempOrderItems.Any() && !daGuiBep) // Nếu có món tạm mà chưa gửi bếp
                {
                    DialogResult result = MessageBox.Show("Bạn có các món chưa gửi bếp. Thoát sẽ làm mất các món này. Bạn có chắc chắn muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                currentBan = null; currentHoaDon = null; currentDanhMuc = null;
                tempOrderItems.Clear(); daGuiBep = false;
                plnDanhMuc.Controls.Clear(); plnSanPham.Controls.Clear(); plnHoaDon.Controls.Clear();
                LoadBan();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e) { /* ... giữ nguyên ... */ }
        private void btnExit_Click(object sender, EventArgs e) { /* ... giữ nguyên ... */ }


        // Đổi tên sự kiện này cho phù hợp với chức năng mới "IN TẠM"
        private void btnPrintTempBill_Click(object sender, EventArgs e) // Trước đây là btnPaid_Click
        {
            if (!tempOrderItems.Any() && (currentHoaDon == null || !chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon).Any()))
            {
                MessageBox.Show("Hóa đơn trống, không có gì để in tạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // TODO: Implement print temporary bill logic
            // Logic này sẽ lấy thông tin từ tempOrderItems nếu chưa gửi bếp,
            // hoặc từ currentHoaDon và chi tiết đã lưu nếu đã gửi bếp.
            MessageBox.Show("Chức năng 'In Tạm Tính' chưa được cài đặt chi tiết.\nSẽ in dựa trên các món hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnSendCheck_Click(object sender, EventArgs e)
        {
            if (!tempOrderItems.Any())
            {
                MessageBox.Show("Không có món nào để gửi bếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Kiểm tra hoặc tạo HoaDon chính
                if (currentHoaDon == null) // Chưa có hóa đơn nào cho bàn này, hoặc hóa đơn cũ đã thanh toán
                {
                    currentHoaDon = new HoaDon
                    {
                        MaKhachHang = 1,
                        MaNhanVien = maNhanVien,
                        MaBan = currentBan.MaBan,
                        NgayDat = DateTime.Now,
                        TongTien = 0,
                        TienGiamGia = 0,
                        TongThueVAT = 0,
                        TrangThai = "Chưa thanh toán",
                        NguoiTao = maNhanVien
                    };
                    int newHoaDonId = hoaDonDAL.ThemHoaDon(currentHoaDon);
                    if (newHoaDonId <= 0) throw new Exception("Không thể tạo hóa đơn mới.");
                    currentHoaDon.MaHoaDon = newHoaDonId;

                    // Cập nhật trạng thái bàn
                    if (currentBan.TrangThai == "Trống")
                    {
                        banDAL.CapNhatTrangThaiBan(currentBan.MaBan, "Đang sử dụng");
                    }
                }
                else if (currentHoaDon.MaHoaDon > 0 && daGuiBep) // Hóa đơn đã tồn tại và đã gửi bếp -> cập nhật
                {
                    // Xóa các chi tiết hóa đơn cũ trong DB để thêm lại từ tempOrderItems
                    // Đây là cách đơn giản, cách tốt hơn là so sánh và chỉ cập nhật/thêm/xóa những gì thay đổi
                    chiTietHoaDonDAL.XoaTatCaChiTietTheoMaHoaDon(currentHoaDon.MaHoaDon); // Cần hàm này trong DAL
                }


                // 2. Lưu các ChiTietHoaDon từ tempOrderItems
                foreach (var tempItem in tempOrderItems)
                {
                    tempItem.MaHoaDon = currentHoaDon.MaHoaDon; // Gán MaHoaDon
                    // Không cần gọi ThemChiTietHoaDon nếu đã có MaChiTietHoaDon (trường hợp tải từ DB lên temp)
                    // Tuy nhiên, với logic xóa hết rồi thêm lại ở trên thì luôn thêm mới
                    chiTietHoaDonDAL.ThemChiTietHoaDon(tempItem);
                }

                // 3. Cập nhật tổng tiền, thuế cho HoaDon
                hoaDonDAL.CapNhatTongTienHoaDon(currentHoaDon.MaHoaDon);

                // 4. Lấy lại thông tin hóa đơn đã cập nhật từ DB
                currentHoaDon = hoaDonDAL.LayHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);

                daGuiBep = true; // Đánh dấu đã gửi bếp
                MessageBox.Show($"Hóa đơn #{currentHoaDon.MaHoaDon} đã được gửi bếp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Không xóa tempOrderItems nếu muốn cho phép sửa sau khi gửi bếp
                // tempOrderItems.Clear(); // Nếu muốn bắt đầu lại sau khi gửi bếp

                DisplayHoaDon(); // Hiển thị lại hóa đơn từ DB (hoặc temp nếu vẫn giữ)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi bếp: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintCheck_Click(object sender, EventArgs e) { /* ... giữ nguyên, sẽ in hóa đơn đã gửi bếp ... */ }
        private void btnGuestCheck_Click(object sender, EventArgs e) { /* ... giữ nguyên, sẽ in hóa đơn đã gửi bếp ... */ }

        // Sự kiện này bây giờ là cho nút "THANH TOÁN" thực sự (nếu bạn muốn giữ lại)
        // Hoặc bạn có thể loại bỏ nút này và chỉ có "In Tạm" rồi xử lý thanh toán ở một quy trình khác (vd: tại quầy thu ngân)
        private void btnPaid_Click(object sender, EventArgs e)
        {
            // Nếu bạn muốn nút này là "THANH TOÁN THỰC SỰ"
            if (currentHoaDon != null && currentHoaDon.MaHoaDon > 0 && currentHoaDon.TrangThai == "Chưa thanh toán")
            {
                if (!daGuiBep)
                {
                    MessageBox.Show("Vui lòng 'Gửi Bếp' trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị form/dialog thanh toán chi tiết ở đây
                // Ví dụ: ThanhToanForm frmThanhToan = new ThanhToanForm(currentHoaDon);
                // if (frmThanhToan.ShowDialog() == DialogResult.OK) { ... }

                // Giả sử thanh toán thành công
                try
                {
                    hoaDonDAL.CapNhatTrangThaiHoaDon(currentHoaDon.MaHoaDon, "Đã thanh toán");
                    if (currentBan != null)
                    {
                        banDAL.CapNhatTrangThaiBan(currentBan.MaBan, "Trống");
                    }
                    MessageBox.Show("Hóa đơn đã được thanh toán thành công!", "Thanh toán hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBan(); // Quay lại màn hình chọn bàn
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (currentHoaDon != null && currentHoaDon.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có hóa đơn hợp lệ để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy các thay đổi hiện tại và quay lại màn hình chọn bàn không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Nếu hóa đơn chưa được gửi bếp và có item tạm, chúng sẽ mất
                // Nếu đã gửi bếp, các thay đổi tạm thời (nếu có) sẽ mất, hóa đơn đã lưu vẫn còn
                currentHoaDon = null; currentBan = null; currentDanhMuc = null;
                tempOrderItems.Clear(); daGuiBep = false;
                LoadBan();
            }
        }
        private void lblWholeCheck_Click(object sender, EventArgs e) { /* ... giữ nguyên ... */ }
    }
}
