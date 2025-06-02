using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Cần cho Linq
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;
using Microsoft.VisualBasic;
using OpenQA.Selenium.Interactions; // NEW: For InputBox

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
        private HoaDon currentHoaDon = null;
        private int maNhanVien = 1;

        private List<ChiTietHoaDon> tempOrderItems = new List<ChiTietHoaDon>();
        private bool daGuiBep = false;

        private VoucherDAL voucherDAL = new VoucherDAL();
        private Voucher appliedVoucher = null;

        public TrangChu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ConfigurePanels();
            LoadBan();
            SetupTimer();
            WireUpVoucherButton();
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
        }

        private void SetupTimer()
        {
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            timer.Start();
        }


        private void WireUpVoucherButton()
        {
            // Giả sử bạn có nút tên là btnApplyVoucher trong TrangChu.Designer.cs
            // và nó đã được thêm vào plnBottom.
            // Nếu bạn chưa tạo nút này trong Designer, bạn cần làm điều đó trước.
            Control[] foundControls = this.Controls.Find("btnApplyVoucher", true);
            if (foundControls.Length > 0 && foundControls[0] is Button voucherButton)
            {
                voucherButton.Click += new System.EventHandler(this.btnApplyVoucher_Click);
            }
            // Hoặc nếu bạn chắc chắn tên nút là btnApplyVoucher và đã khai báo ở class level:
            // if (this.btnApplyVoucher != null)
            // {
            //    this.btnApplyVoucher.Click += new System.EventHandler(this.btnApplyVoucher_Click);
            // }
        }


        private void TrangChu_Load(object sender, EventArgs e)
        {
            lblTable.Text = "Bàn: N/A";
            lblCover.Text = "Khách: 0";
            lblWholeCheck.Text = "Tổng cộng: 0.00";
            btnPaid.Text = "THANH TOÁN";
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
            tempOrderItems.Clear();
            daGuiBep = false;
            currentHoaDon = null;
            appliedVoucher = null;

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
            tempOrderItems.Clear();
            daGuiBep = false;
            appliedVoucher = null;

            LoadExistingUnpaidOrderForTable();
            LoadMainCategories();
            DisplayHoaDon();
        }

        private void LoadExistingUnpaidOrderForTable()
        {
            if (currentBan == null) return;
            try
            {
                currentHoaDon = hoaDonDAL.LayHoaDonChuaThanhToanTheoMaBan(currentBan.MaBan);
                if (currentHoaDon != null)
                {
                    List<ChiTietHoaDon> existingDetails = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);
                    if (existingDetails != null)
                    {
                        tempOrderItems.AddRange(existingDetails);
                    }
                    daGuiBep = true;
                    // Giả sử Model HoaDon có thuộc tính MaVoucherDaApDung (int?)
                    // và VoucherDAL có GetVoucherById(int maVoucher)
                    // if (currentHoaDon.MaVoucherDaApDung.HasValue)
                    // {
                    //    appliedVoucher = voucherDAL.GetVoucherById(currentHoaDon.MaVoucherDaApDung.Value);
                    //    if (appliedVoucher == null || appliedVoucher.TrangThai != "Chưa sử dụng") 
                    //    {
                    //        appliedVoucher = null; 
                    //        currentHoaDon.TienGiamGia = 0; 
                    //        currentHoaDon.MaVoucherDaApDung = null; 
                    //    }
                    // }
                }
                else
                {
                    currentHoaDon = null;
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
                btn.Click += BtnSanPham_Click_Temp;
                flowPanelProducts.Controls.Add(btn);
            }
        }

        private void BtnSanPham_Click_Temp(object sender, EventArgs e)
        {
            if (daGuiBep && currentHoaDon != null && currentHoaDon.TrangThai == "Chưa thanh toán")
            {
                DialogResult dialogResult = MessageBox.Show("Hóa đơn đã được gửi bếp. Mọi thay đổi sẽ yêu cầu 'Gửi Bếp' lại để cập nhật. Bạn có muốn tiếp tục thêm/sửa món không?", "Xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            Button btn = sender as Button;
            SANPHAM sp = btn.Tag as SANPHAM;
            if (sp == null) return;

            if (currentHoaDon == null)
            {
                currentHoaDon = new HoaDon
                {
                    MaKhachHang = 1,
                    MaNhanVien = maNhanVien,
                    MaBan = currentBan.MaBan,
                    NgayDat = DateTime.Now,
                    TrangThai = "Chưa thanh toán",
                    NguoiTao = maNhanVien,
                    TongTien = 0,
                    TienGiamGia = 0,
                    TongThueVAT = 0
                };
            }

            decimal thueVATValue = 0;
            DanhMucSanPham dmCuaSP = currentDanhMuc;
            if (dmCuaSP == null || dmCuaSP.MaDanhMuc != sp.MaDanhMuc)
            {
                dmCuaSP = danhMucDAL.GetDanhMucById(sp.MaDanhMuc);
            }
            if (dmCuaSP != null) thueVATValue = dmCuaSP.ThueVAT;
            else thueVATValue = 10;

            var existingItem = tempOrderItems.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
            if (existingItem != null)
            {
                existingItem.SoLuong++;
                existingItem.ThanhTien = existingItem.SoLuong * existingItem.Gia;
                existingItem.TienThue = existingItem.ThanhTien * ((float)thueVATValue / 100);
            }
            else
            {
                ChiTietHoaDon newItem = new ChiTietHoaDon
                {
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
            DisplayHoaDon();
        }

        private void DisplayHoaDon()
        {
            plnHoaDon.Controls.Clear();
            FlowLayoutPanel flowPanelBillItems = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(5)
            };
            Panel panelTotals = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 145,
                BackColor = Color.FromArgb(230, 230, 230),
                Padding = new Padding(10)
            };
            plnHoaDon.Controls.Add(flowPanelBillItems);
            plnHoaDon.Controls.Add(panelTotals);

            Label lblHeader = new Label
            {
                Text = string.Format("{0,-23} {1,3} {2,8} {3,10} {4,2}", "Tên món", "SL", "Đ.Giá", "T.Tiền", ""),
                Font = new Font("Courier New", 9, FontStyle.Bold),
                AutoSize = false,
                Width = flowPanelBillItems.ClientSize.Width - 5,
                Height = 20,
                Margin = new Padding(0, 0, 0, 5),
            };
            flowPanelBillItems.Controls.Add(lblHeader);

            float subTotalDisplay = 0;
            float totalVATDisplay = 0;

            if (tempOrderItems.Any())
            {
                for (int i = 0; i < tempOrderItems.Count; i++)
                {
                    var chiTiet = tempOrderItems[i];
                    chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.Gia;
                    chiTiet.TienThue = chiTiet.ThanhTien * (chiTiet.ThueVAT / 100);
                    subTotalDisplay += chiTiet.ThanhTien;
                    totalVATDisplay += chiTiet.TienThue;

                    Panel itemPanel = new Panel
                    {
                        Width = flowPanelBillItems.ClientSize.Width - 10,
                        Height = 25,
                        Margin = new Padding(0, 0, 0, 2)
                    };
                    Label lblItem = new Label
                    {
                        Text = string.Format("{0,-23} {1,3} {2,8:N0} {3,10:N0}",
                                             TruncateString(chiTiet.TenSanPham ?? "N/A", 21),
                                             chiTiet.SoLuong, chiTiet.Gia, chiTiet.ThanhTien),
                        Font = new Font("Courier New", 9),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                    };
                    itemPanel.Controls.Add(lblItem);
                    if (!daGuiBep || (currentHoaDon != null && currentHoaDon.TrangThai == "Chưa thanh toán"))
                    {
                        Button btnDeleteItem = new Button
                        {
                            Text = "X",
                            ForeColor = Color.Red,
                            Font = new Font("Arial", 8, FontStyle.Bold),
                            FlatStyle = FlatStyle.System,
                            Size = new Size(20, 20),
                            Dock = DockStyle.Right,
                            Tag = chiTiet
                        };
                        btnDeleteItem.Click += BtnDeleteItem_Click;
                        itemPanel.Controls.Add(btnDeleteItem);
                        lblItem.Width = itemPanel.Width - btnDeleteItem.Width - 5;
                    }
                    flowPanelBillItems.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label lblNoBill = new Label { Text = "Vui lòng chọn món...", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12), ForeColor = Color.Gray };
                flowPanelBillItems.Controls.Add(lblNoBill);
            }

            float discountDisplay = 0;
            if (appliedVoucher != null && appliedVoucher.TrangThai == "Chưa sử dụng")
            {
                discountDisplay = (float)appliedVoucher.GiaTri;
            }
            else if (currentHoaDon != null)
            {
                discountDisplay = currentHoaDon.TienGiamGia;
            }

            float grandTotalDisplay = subTotalDisplay + totalVATDisplay - discountDisplay;

            Label lblSubTotalText = new Label { Text = "Tạm tính:", Font = new Font("Segoe UI", 10), Location = new Point(10, 10), AutoSize = true };
            Label lblSubTotalValue = new Label { Text = $"{subTotalDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 10), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };
            Label lblVATText = new Label { Text = "Thuế VAT:", Font = new Font("Segoe UI", 10), Location = new Point(10, 35), AutoSize = true };
            Label lblVATValue = new Label { Text = $"{totalVATDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 35), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };

            Label lblVoucherInfo = new Label { Font = new Font("Segoe UI", 9, FontStyle.Italic), ForeColor = Color.ForestGreen, Location = new Point(10, 60), AutoSize = true };
            if (appliedVoucher != null && appliedVoucher.TrangThai == "Chưa sử dụng")
            {
                lblVoucherInfo.Text = $"Voucher: -{appliedVoucher.GiaTri:N0}đ (Mã: {appliedVoucher.MaVoucher})";
            }
            else if (currentHoaDon != null && currentHoaDon.TienGiamGia > 0)
            {
                lblVoucherInfo.Text = $"Giảm giá: -{currentHoaDon.TienGiamGia:N0}đ";
            }
            panelTotals.Controls.Add(lblVoucherInfo);

            Label lblDiscountText = new Label { Text = "Giảm giá:", Font = new Font("Segoe UI", 10), Location = new Point(10, 85), AutoSize = true };
            Label lblDiscountValue = new Label { Text = $"{discountDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.IndianRed, Location = new Point(200, 85), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 };
            Label lblGrandTotalText = new Label { Text = "TỔNG CỘNG:", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(10, 110), AutoSize = true };
            Label lblGrandTotalValue = new Label { Text = $"{grandTotalDisplay:N0}đ", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(0, 122, 204), Location = new Point(180, 110), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 200 };

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
                DialogResult dialogResult = MessageBox.Show("Hóa đơn đã được gửi bếp. Việc xóa món này sẽ yêu cầu 'Gửi Bếp' lại để cập nhật. Bạn có muốn tiếp tục xóa?", "Xác nhận xóa món", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                // NEW: Nếu đã áp voucher, và voucher đó áp dụng cho sản phẩm vừa xóa, cần xem xét lại voucher
                if (appliedVoucher != null && appliedVoucher.MaSanPham.HasValue && appliedVoucher.MaSanPham.Value == itemToRemove.MaSanPham)
                {
                    // Kiểm tra xem còn sản phẩm nào khác trong tempOrderItems khớp với MaSanPham của voucher không
                    bool stillApplicable = tempOrderItems.Any(item => item.MaSanPham == appliedVoucher.MaSanPham.Value);
                    if (!stillApplicable)
                    {
                        MessageBox.Show($"Sản phẩm áp dụng cho voucher (Mã: {appliedVoucher.MaVoucher}) đã bị xóa. Voucher sẽ được gỡ bỏ.", "Thông báo Voucher", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        appliedVoucher = null; // Gỡ voucher
                        if (currentHoaDon != null) currentHoaDon.TienGiamGia = 0; // Reset giảm giá trên hóa đơn tạm
                    }
                }
                DisplayHoaDon();
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
                if (tempOrderItems.Any() && !daGuiBep)
                {
                    DialogResult result = MessageBox.Show("Bạn có các món chưa gửi bếp. Thoát sẽ làm mất các món này. Bạn có chắc chắn muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return;
                }
                currentBan = null; currentHoaDon = null; currentDanhMuc = null;
                tempOrderItems.Clear(); daGuiBep = false; appliedVoucher = null;
                plnDanhMuc.Controls.Clear(); plnSanPham.Controls.Clear(); plnHoaDon.Controls.Clear();
                LoadBan();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e) { /* ... */ }
        private void btnExit_Click(object sender, EventArgs e) { /* ... */ }

        private void btnApplyVoucher_Click(object sender, EventArgs e)
        {
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Cho phép áp voucher ngay cả khi chưa có món, voucher có thể giảm trực tiếp vào hóa đơn
            // if (!tempOrderItems.Any() && currentHoaDon == null)
            // {
            //      MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn trước khi áp dụng voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //     return;
            // }
            if (appliedVoucher != null && appliedVoucher.TrangThai == "Chưa sử dụng")
            {
                MessageBox.Show($"Đã có voucher (Mã: {appliedVoucher.MaVoucher}) được áp dụng. Nếu muốn đổi, vui lòng hủy và tạo lại hóa đơn, hoặc xóa voucher hiện tại (chức năng chưa có).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (daGuiBep && currentHoaDon != null && currentHoaDon.TienGiamGia > 0 && appliedVoucher == null) // Đã gửi bếp, đã có giảm giá (có thể từ voucher trước đó đã lưu) và chưa có voucher nào đang áp dụng trong session này
            {
                MessageBox.Show("Hóa đơn đã được gửi bếp và đã có giảm giá. Không thể áp dụng thêm voucher mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string voucherCodeInput = Microsoft.VisualBasic.Interaction.InputBox("Nhập mã voucher:", "Áp dụng Voucher", "").Trim();
            if (string.IsNullOrWhiteSpace(voucherCodeInput))
            {
                return;
            }

            try
            {
                Voucher foundVoucher = null;
                // Ưu tiên tìm theo mã text nếu VoucherDAL có hàm đó và bảng Voucher có cột mã text
                // if (voucherDAL.HasGetVoucherByCodeTextMethod()) // Giả định có cách kiểm tra
                // {
                //    foundVoucher = voucherDAL.GetVoucherByCodeText(voucherCodeInput);
                // }
                // Nếu không, hoặc tìm theo mã text không thấy, thử tìm theo mã số (MaVoucher)
                if (foundVoucher == null && int.TryParse(voucherCodeInput, out int maVoucherNum))
                {
                    foundVoucher = voucherDAL.GetVoucherById(maVoucherNum);
                }


                if (foundVoucher == null)
                {
                    MessageBox.Show("Mã voucher không hợp lệ hoặc không tồn tại.", "Lỗi Voucher", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (foundVoucher.TrangThai == "Đã sử dụng")
                {
                    MessageBox.Show("Voucher này đã được sử dụng.", "Lỗi Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (foundVoucher.NgayHetHan.HasValue && foundVoucher.NgayHetHan.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Voucher đã hết hạn sử dụng.", "Lỗi Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra điều kiện áp dụng voucher (ví dụ)
                if (foundVoucher.MaKhachHang.HasValue)
                {
                    if (currentHoaDon == null || currentHoaDon.MaKhachHang != foundVoucher.MaKhachHang.Value)
                    {
                        // Cần cơ chế chọn khách hàng cho hóa đơn trước
                        MessageBox.Show($"Voucher này chỉ dành cho khách hàng cụ thể (Mã KH: {foundVoucher.MaKhachHang.Value}). Vui lòng chọn đúng khách hàng cho hóa đơn.", "Lỗi Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (foundVoucher.MaSanPham.HasValue)
                {
                    if (!tempOrderItems.Any(item => item.MaSanPham == foundVoucher.MaSanPham.Value))
                    {
                        MessageBox.Show($"Voucher này chỉ áp dụng cho sản phẩm có mã {foundVoucher.MaSanPham.Value} và sản phẩm này không có trong hóa đơn.", "Lỗi Voucher", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                appliedVoucher = foundVoucher;

                if (currentHoaDon == null)
                {
                    currentHoaDon = new HoaDon
                    {
                        MaKhachHang = (appliedVoucher.MaKhachHang.HasValue ? appliedVoucher.MaKhachHang.Value : 1), // Gán KH của voucher nếu có, hoặc KH mặc định
                        MaNhanVien = maNhanVien,
                        MaBan = currentBan.MaBan,
                        NgayDat = DateTime.Now,
                        TrangThai = "Chưa thanh toán",
                        NguoiTao = maNhanVien,
                        TongTien = 0,
                        TongThueVAT = 0
                    };
                }
                currentHoaDon.TienGiamGia = (float)appliedVoucher.GiaTri;
                // currentHoaDon.MaVoucherDaApDung = appliedVoucher.MaVoucher; // Cập nhật vào HĐ nếu có trường này

                MessageBox.Show($"Đã áp dụng voucher giảm {appliedVoucher.GiaTri:N0}đ.", "Áp dụng thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSendCheck_Click(object sender, EventArgs e)
        {
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gửi bếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!tempOrderItems.Any() && currentHoaDon == null)
            {
                MessageBox.Show("Không có món nào để gửi bếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!tempOrderItems.Any() && currentHoaDon != null && currentHoaDon.TienGiamGia > 0 && appliedVoucher != null)
            {
                MessageBox.Show("Không thể gửi bếp chỉ với voucher mà không có sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isNewHoaDon = false;
                if (currentHoaDon == null)
                {
                    currentHoaDon = new HoaDon
                    {
                        MaKhachHang = 1,
                        MaNhanVien = maNhanVien,
                        MaBan = currentBan.MaBan,
                        NgayDat = DateTime.Now,
                        TongTien = 0,
                        TienGiamGia = (float)(appliedVoucher?.GiaTri ?? 0),
                        TongThueVAT = 0,
                        TrangThai = "Chưa thanh toán",
                        NguoiTao = maNhanVien,
                        // MaVoucherDaApDung = appliedVoucher?.MaVoucher 
                    };
                    int newHoaDonId = hoaDonDAL.ThemHoaDon(currentHoaDon);
                    if (newHoaDonId <= 0) throw new Exception("Không thể tạo hóa đơn mới trong CSDL.");
                    currentHoaDon.MaHoaDon = newHoaDonId;
                    isNewHoaDon = true;
                }
                else
                {
                    if (appliedVoucher != null && appliedVoucher.TrangThai == "Chưa sử dụng")
                    {
                        currentHoaDon.TienGiamGia = (float)appliedVoucher.GiaTri;
                        // currentHoaDon.MaVoucherDaApDung = appliedVoucher.MaVoucher;
                    }
                    else if (appliedVoucher == null && currentHoaDon.TienGiamGia > 0) // Nếu voucher đã bị gỡ bỏ
                    {
                        currentHoaDon.TienGiamGia = 0;
                        // currentHoaDon.MaVoucherDaApDung = null;
                    }


                    if (daGuiBep && currentHoaDon.MaHoaDon > 0)
                    {
                        chiTietHoaDonDAL.XoaTatCaChiTietTheoMaHoaDon(currentHoaDon.MaHoaDon);
                        // Cần cập nhật lại thông tin hóa đơn chính nếu có thay đổi (ví dụ TienGiamGia)
                        // hoaDonDAL.UpdateThongTinCoBanHoaDon(currentHoaDon); // Cần hàm này
                    }
                }

                if (tempOrderItems.Any())
                {
                    foreach (var tempItem in tempOrderItems)
                    {
                        tempItem.MaHoaDon = currentHoaDon.MaHoaDon;
                        chiTietHoaDonDAL.ThemChiTietHoaDon(tempItem);
                    }
                }

                // Cập nhật lại TienGiamGia vào DB trước khi tính tổng
                // (Vì trigger có thể không biết về TienGiamGia nếu nó không được lưu trước)
                // Điều này quan trọng nếu CapNhatTongTienHoaDon không cập nhật TienGiamGia
                if (currentHoaDon.MaHoaDon > 0)
                { // Đảm bảo HĐ đã có ID
                    // Tạo một đối tượng HoaDon chỉ chứa MaHoaDon và TienGiamGia để cập nhật
                    // Hoặc một hàm UpdateSpecificFields trong DAL
                    // hoaDonDAL.CapNhatTienGiamGia(currentHoaDon.MaHoaDon, currentHoaDon.TienGiamGia);
                }


                hoaDonDAL.CapNhatTongTienHoaDon(currentHoaDon.MaHoaDon);
                currentHoaDon = hoaDonDAL.LayHoaDonTheoMa(currentHoaDon.MaHoaDon);

                if (appliedVoucher != null && appliedVoucher.TrangThai == "Chưa sử dụng" && currentHoaDon != null && currentHoaDon.MaHoaDon > 0)
                {
                    voucherDAL.CapNhatTrangThaiVoucher(appliedVoucher.MaVoucher, "Đã sử dụng");
                    appliedVoucher.TrangThai = "Đã sử dụng"; // Cập nhật trạng thái trong bộ nhớ
                }

                daGuiBep = true;
                MessageBox.Show($"Hóa đơn #{currentHoaDon?.MaHoaDon} đã được gửi bếp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isNewHoaDon || currentBan.TrangThai == "Trống")
                {
                    banDAL.CapNhatTrangThaiBan(currentBan.MaBan, "Đang sử dụng");
                }

                tempOrderItems.Clear();
                List<ChiTietHoaDon> savedDetails = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);
                if (savedDetails != null) tempOrderItems.AddRange(savedDetails);

                DisplayHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi bếp: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintCheck_Click(object sender, EventArgs e)
        {
            if (!daGuiBep || currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng 'Gửi Bếp' trước khi in hóa đơn chính thức.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show($"Sẵn sàng in hóa đơn #{currentHoaDon.MaHoaDon}", "In Hóa Đơn", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuestCheck_Click(object sender, EventArgs e)
        {
            string message = "Chức năng 'In Tạm Tính' chưa được cài đặt chi tiết.\nSẽ in dựa trên các món hiện tại:\n";
            if (tempOrderItems.Any())
            {
                foreach (var item in tempOrderItems)
                {
                    message += $"- {item.TenSanPham} (SL: {item.SoLuong})\n";
                }
            }
            else if (currentHoaDon != null)
            {
                List<ChiTietHoaDon> details = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);
                if (details != null && details.Any())
                {
                    foreach (var item in details) { message += $"- {item.TenSanPham} (SL: {item.SoLuong})\n"; }
                }
                else { message += "(Hóa đơn trống)"; }
            }
            else
            {
                message += "(Hóa đơn trống)";
            }
            MessageBox.Show(message, "In Tạm Tính", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (currentHoaDon != null && currentHoaDon.MaHoaDon > 0 && currentHoaDon.TrangThai == "Chưa thanh toán")
            {
                if (!daGuiBep)
                {
                    MessageBox.Show("Vui lòng 'Gửi Bếp' trước khi thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirmPayment = MessageBox.Show($"Xác nhận thanh toán cho hóa đơn #{currentHoaDon.MaHoaDon} với tổng tiền {currentHoaDon.ThanhToan:N0}đ?",
                                                              "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmPayment == DialogResult.Yes)
                {
                    try
                    {
                        hoaDonDAL.CapNhatTrangThaiHoaDon(currentHoaDon.MaHoaDon, "Đã thanh toán");
                        if (currentBan != null)
                        {
                            banDAL.CapNhatTrangThaiBan(currentBan.MaBan, "Trống");
                        }
                        MessageBox.Show("Hóa đơn đã được thanh toán thành công!", "Thanh toán hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (currentHoaDon != null && currentHoaDon.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có hóa đơn hợp lệ để thanh toán hoặc hóa đơn chưa được gửi bếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy các thao tác hiện tại và quay lại màn hình chọn bàn không?\nCác món chưa gửi bếp sẽ bị mất.", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                currentHoaDon = null; currentBan = null; currentDanhMuc = null;
                tempOrderItems.Clear(); daGuiBep = false; appliedVoucher = null;
                LoadBan();
            }
        }
        private void lblWholeCheck_Click(object sender, EventArgs e) { /* ... */ }
    }
}
