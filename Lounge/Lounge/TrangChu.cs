using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;
using Microsoft.VisualBasic; // For InputBox

namespace Lounge
{
    public partial class TrangChu : Form
    {
        // DAL Objects
        private BanDAL banDAL = new BanDAL();
        private DanhMucSPDAL danhMucDAL = new DanhMucSPDAL();
        private SanPhamDAL sanPhamDAL = new SanPhamDAL();
        private HoaDonDAL hoaDonDAL = new HoaDonDAL();
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private VoucherDAL voucherDAL = new VoucherDAL();
        private KhachHangDAL khachHangDAL = new KhachHangDAL(); // Mới: DAL cho khách hàng

        // Current State Objects
        private Ban currentBan = null;
        private HoaDon currentHoaDon = null;
        private DanhMucSanPham currentDanhMuc = null;
        private KhachHan currentKhachHang = null; // Mới: Lưu khách hàng đang được chọn
        private Voucher appliedVoucher = null;
        private List<ChiTietHoaDon> tempOrderItems = new List<ChiTietHoaDon>();

        // State Flags
        private bool daGuiBep = false;

        // Other utilities
        private Timer timer = new Timer();
        private int maNhanVien = 1; // ID nhân viên đăng nhập (ví dụ)

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
            btnPaid.Text = "THANH TOÁN";
        }

        #region Screen Switching and Loading
        /// <summary>
        /// Tải lại màn hình chọn bàn và reset toàn bộ trạng thái.
        /// </summary>
        private void LoadBan()
        {
            plnBan.Controls.Clear();
            plnBan.Visible = true;
            plnMain.Visible = false;
            plnBottom.Visible = false;

            // Reset labels
            lblTable.Text = "Bàn: N/A";
            lblCover.Text = "Khách: 0";
            lblWholeCheck.Text = "Tổng cộng: 0.00";

            // Reset state
            tempOrderItems.Clear();
            daGuiBep = false;
            currentHoaDon = null;
            currentBan = null;
            currentDanhMuc = null;
            appliedVoucher = null;
            currentKhachHang = null; // Mới: Reset khách hàng

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

        /// <summary>
        /// Hiển thị các nút chọn bàn trên giao diện.
        /// </summary>
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

        /// <summary>
        /// Xử lý khi nhân viên chọn một bàn.
        /// </summary>
        private void BtnBan_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentBan = btn.Tag as Ban;
            if (currentBan == null) return;

            // Chuyển giao diện sang màn hình order
            plnBan.Visible = false;
            plnMain.Visible = true;
            plnBottom.Visible = true;

            // Cập nhật thông tin bàn
            lblTable.Text = $"Bàn: {currentBan.SoBan}";
            lblCover.Text = $"Khách: {currentBan.SoChoNgoi}";

            // Reset trạng thái order của phiên trước
            tempOrderItems.Clear();
            daGuiBep = false;
            appliedVoucher = null;
            currentKhachHang = null;

            // Tải dữ liệu cho màn hình order
            LoadExistingUnpaidOrderForTable();
            LoadMainCategories();
            DisplayHoaDon();
        }

        /// <summary>
        /// Tải hóa đơn chưa thanh toán (nếu có) của bàn vừa chọn.
        /// </summary>
        private void LoadExistingUnpaidOrderForTable()
        {
            if (currentBan == null) return;
            try
            {
                currentHoaDon = hoaDonDAL.LayHoaDonChuaThanhToanTheoMaBan(currentBan.MaBan);
                if (currentHoaDon != null)
                {
                    // Mới: Tải thông tin khách hàng của hóa đơn cũ
                    if (currentHoaDon.MaKhachHang > 1) // Giả sử 1 là khách lẻ
                    {
                        currentKhachHang = khachHangDAL.GetKHById(currentHoaDon.MaKhachHang);
                    }

                    List<ChiTietHoaDon> existingDetails = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(currentHoaDon.MaHoaDon);
                    if (existingDetails != null)
                    {
                        tempOrderItems.AddRange(existingDetails);
                    }
                    daGuiBep = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải hóa đơn cũ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentHoaDon = null;
            }
        }
        #endregion

        #region Order Screen (Categories and Products)
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
                btn.Click += BtnSanPham_Click;
                flowPanelProducts.Controls.Add(btn);
            }
        }

        /// <summary>
        /// Xử lý khi thêm một sản phẩm vào hóa đơn.
        /// </summary>
        private void BtnSanPham_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SANPHAM sp = btn.Tag as SANPHAM;
            if (sp == null) return;

            // Nếu hóa đơn đã được tạo, tạo một đối tượng hóa đơn tạm
            if (currentHoaDon == null)
            {
                currentHoaDon = new HoaDon
                {
                    // Mới: Sử dụng khách hàng đã chọn, mặc định là khách lẻ (ID=1)
                    MaKhachHang = (currentKhachHang != null) ? currentKhachHang.MaKhachHang : 1,
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

            // Lấy thuế VAT từ danh mục
            decimal thueVATValue = 10; // Thuế mặc định
            DanhMucSanPham dmCuaSP = danhMucDAL.GetDanhMucById(sp.MaDanhMuc);
            if (dmCuaSP != null) thueVATValue = dmCuaSP.ThueVAT;

            // Thêm hoặc cập nhật số lượng món trong danh sách tạm
            var existingItem = tempOrderItems.FirstOrDefault(item => item.MaSanPham == sp.MaSanPham);
            if (existingItem != null)
            {
                existingItem.SoLuong++;
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
                tempOrderItems.Add(newItem);
            }
            DisplayHoaDon();
        }
        #endregion

        #region Bill Display and Management

        /// <summary>
        /// Hiển thị lại toàn bộ thông tin hóa đơn từ tempOrderItems.
        /// </summary>
        private void DisplayHoaDon()
        {
            plnHoaDon.Controls.Clear();

            // Panel chứa danh sách các món
            FlowLayoutPanel flowPanelBillItems = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(5)
            };

            // Panel chứa các thông tin tổng kết
            Panel panelTotals = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 175, // Tăng chiều cao để có chỗ cho tên KH
                BackColor = Color.FromArgb(230, 230, 230),
                Padding = new Padding(10)
            };
            plnHoaDon.Controls.Add(flowPanelBillItems);
            plnHoaDon.Controls.Add(panelTotals);

            // === PHẦN THÔNG TIN KHÁCH HÀNG ===
            Label lblCustomerInfo = new Label
            {
                Text = "KH: Khách lẻ",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(10, 5),
                AutoSize = true
            };
            if (currentKhachHang != null)
            {
                lblCustomerInfo.Text = $"KH: {currentKhachHang.HoTen}";
            }
            panelTotals.Controls.Add(lblCustomerInfo);


            // === PHẦN DANH SÁCH MÓN ĂN ===
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
                foreach (var chiTiet in tempOrderItems)
                {
                    chiTiet.ThanhTien = chiTiet.SoLuong * chiTiet.Gia;
                    chiTiet.TienThue = chiTiet.ThanhTien * (chiTiet.ThueVAT / 100);
                    subTotalDisplay += chiTiet.ThanhTien;
                    totalVATDisplay += chiTiet.TienThue;

                    // Panel cho mỗi dòng sản phẩm
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
                        Dock = DockStyle.Fill,
                    };
                    itemPanel.Controls.Add(lblItem);

                    // Nút xóa chỉ hiển thị khi chưa gửi bếp hoặc hóa đơn chưa thanh toán
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

                    flowPanelBillItems.Controls.Add(itemPanel);
                }
            }
            else
            {
                Label lblNoBill = new Label { Text = "Vui lòng chọn món...", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 12), ForeColor = Color.Gray };
                flowPanelBillItems.Controls.Add(lblNoBill);
            }

            // === PHẦN TỔNG KẾT HÓA ĐƠN ===
            float discountDisplay = appliedVoucher?.GiaTri ?? currentHoaDon?.TienGiamGia ?? 0;
            float grandTotalDisplay = subTotalDisplay + totalVATDisplay - discountDisplay;

            // Tạm tính và VAT
            panelTotals.Controls.Add(new Label { Text = "Tạm tính:", Font = new Font("Segoe UI", 10), Location = new Point(10, 30), AutoSize = true });
            panelTotals.Controls.Add(new Label { Text = $"{subTotalDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 30), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 });
            panelTotals.Controls.Add(new Label { Text = "Thuế VAT:", Font = new Font("Segoe UI", 10), Location = new Point(10, 55), AutoSize = true });
            panelTotals.Controls.Add(new Label { Text = $"{totalVATDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.DarkSlateGray, Location = new Point(200, 55), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 });

            // Voucher và Giảm giá
            Label lblVoucherInfo = new Label { Font = new Font("Segoe UI", 9, FontStyle.Italic), ForeColor = Color.ForestGreen, Location = new Point(10, 80), AutoSize = true };
            if (appliedVoucher != null)
            {
                lblVoucherInfo.Text = $"Voucher: -{appliedVoucher.GiaTri:N0}đ (Mã: {appliedVoucher.MaVoucher})";
            }
            panelTotals.Controls.Add(lblVoucherInfo);

            panelTotals.Controls.Add(new Label { Text = "Giảm giá:", Font = new Font("Segoe UI", 10), Location = new Point(10, 105), AutoSize = true });
            panelTotals.Controls.Add(new Label { Text = $"{discountDisplay:N0}đ", Font = new Font("Segoe UI", 10, FontStyle.Bold), ForeColor = Color.IndianRed, Location = new Point(200, 105), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 180 });

            // Tổng cộng
            panelTotals.Controls.Add(new Label { Text = "TỔNG CỘNG:", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(10, 135), AutoSize = true });
            panelTotals.Controls.Add(new Label { Text = $"{grandTotalDisplay:N0}đ", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.FromArgb(0, 122, 204), Location = new Point(180, 135), AutoSize = true, RightToLeft = RightToLeft.Yes, Width = 200 });

            // Cập nhật tổng tiền hiển thị trên thanh header
            lblWholeCheck.Text = $"Tổng cộng: {grandTotalDisplay:N0}đ";
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ChiTietHoaDon itemToRemove = btn.Tag as ChiTietHoaDon;
            if (itemToRemove != null)
            {
                tempOrderItems.Remove(itemToRemove);
                DisplayHoaDon();
            }
        }

        #endregion

        #region Bottom Panel Button Events

        /// <summary>
        /// Mới: Mở form tìm kiếm và chọn khách hàng.
        /// </summary>
        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {
            if (currentBan == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (frmTimKiemKhachHang frmSearch = new frmTimKiemKhachHang())
            {
                if (frmSearch.ShowDialog() == DialogResult.OK)
                {
                    currentKhachHang = frmSearch.SelectedKhachHang;
                    if (currentHoaDon != null)
                    {
                        currentHoaDon.MaKhachHang = currentKhachHang.MaKhachHang;
                    }
                    DisplayHoaDon();
                    MessageBox.Show($"Đã chọn khách hàng: {currentKhachHang}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnApplyVoucher_Click(object sender, EventArgs e)
        {
            if (!tempOrderItems.Any() && currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào hóa đơn trước khi áp dụng voucher.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string voucherCodeInput = Interaction.InputBox("Nhập mã voucher:", "Áp dụng Voucher", "").Trim();
            if (string.IsNullOrWhiteSpace(voucherCodeInput)) return;

            try
            {
                // Logic tìm voucher theo mã (cần có trong VoucherDAL)
                // Voucher foundVoucher = voucherDAL.GetVoucherByCode(voucherCodeInput);
                // ... Xử lý kiểm tra voucher
                // appliedVoucher = foundVoucher;
                DisplayHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng voucher: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gửi thông tin order xuống bếp, lưu hóa đơn và chi tiết vào DB.
        /// </summary>
        private void btnSendCheck_Click(object sender, EventArgs e)
        {
            if (!tempOrderItems.Any())
            {
                MessageBox.Show("Không có món nào để gửi bếp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool isNewHoaDon = (currentHoaDon == null || currentHoaDon.MaHoaDon == 0);

                if (isNewHoaDon)
                {
                    currentHoaDon = new HoaDon
                    {
                        MaKhachHang = (currentKhachHang != null) ? currentKhachHang.MaKhachHang : 1,
                        MaNhanVien = maNhanVien,
                        MaBan = currentBan.MaBan,
                        NgayDat = DateTime.Now,
                        TrangThai = "Chưa thanh toán",
                        NguoiTao = maNhanVien,
                        TienGiamGia = (float)(appliedVoucher?.GiaTri ?? 0),
                    };
                    int newHoaDonId = hoaDonDAL.ThemHoaDon(currentHoaDon);
                    if (newHoaDonId <= 0) throw new Exception("Không thể tạo hóa đơn mới trong CSDL.");
                    currentHoaDon.MaHoaDon = newHoaDonId;
                }
                else
                {
                    if (currentKhachHang != null)
                    {
                        currentHoaDon.MaKhachHang = currentKhachHang.MaKhachHang;
                    }
                }

                // Xóa các chi tiết cũ và thêm lại danh sách mới để đồng bộ
                chiTietHoaDonDAL.XoaTatCaChiTietTheoMaHoaDon(currentHoaDon.MaHoaDon);
                foreach (var tempItem in tempOrderItems)
                {
                    tempItem.MaHoaDon = currentHoaDon.MaHoaDon;
                    chiTietHoaDonDAL.ThemChiTietHoaDon(tempItem);
                }

                // Cập nhật lại tổng tiền từ CSDL
                hoaDonDAL.CapNhatTongTienHoaDon(currentHoaDon.MaHoaDon);
                currentHoaDon = hoaDonDAL.LayHoaDonTheoMa(currentHoaDon.MaHoaDon);

                // Cập nhật trạng thái bàn và voucher
                banDAL.CapNhatTrangThaiBan(currentBan.MaBan, "Đang sử dụng");
                if (appliedVoucher != null)
                {
                    // voucherDAL.CapNhatTrangThaiVoucher(appliedVoucher.MaVoucher, "Đã sử dụng");
                }

                daGuiBep = true;
                MessageBox.Show($"Hóa đơn #{currentHoaDon?.MaHoaDon} đã được gửi bếp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi bếp: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Nút thanh toán cuối cùng, có kiểm tra các thay đổi chưa lưu.
        /// </summary>
        private void btnPaid_Click(object sender, EventArgs e)
        {
            if (currentHoaDon == null || currentHoaDon.MaHoaDon <= 0)
            {
                if (tempOrderItems.Any())
                {
                    DialogResult res = MessageBox.Show("Có các món mới chưa được gửi bếp. Bạn có muốn gửi bếp và thanh toán ngay?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        btnSendCheck_Click(sender, e);
                        if (currentHoaDon == null) return; // Dừng nếu gửi bếp thất bại
                    }
                    else return;
                }
                else
                {
                    MessageBox.Show("Không có hóa đơn hợp lệ để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (currentHoaDon.TrangThai == "Đã thanh toán")
            {
                MessageBox.Show("Hóa đơn này đã được thanh toán trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy lại thông tin hóa đơn mới nhất từ CSDL để đảm bảo tổng tiền chính xác
            try
            {
                hoaDonDAL.CapNhatTongTienHoaDon(currentHoaDon.MaHoaDon);
                currentHoaDon = hoaDonDAL.LayHoaDonTheoMa(currentHoaDon.MaHoaDon);
                if (currentHoaDon == null) throw new Exception("Không thể lấy thông tin hóa đơn mới nhất.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật tổng tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận và thanh toán
            DialogResult confirmPayment = MessageBox.Show($"Xác nhận thanh toán cho hóa đơn #{currentHoaDon.MaHoaDon}\nTổng cộng: {currentHoaDon.ThanhToan:N0}đ", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    LoadBan(); // Quay lại màn hình chọn bàn
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xử lý thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Hủy thao tác và quay về màn hình chọn bàn.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy các thao tác hiện tại và quay lại màn hình chọn bàn không?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadBan();
            }
        }

        /// <summary>
        /// Quay lại màn hình chọn bàn từ màn hình order.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tempOrderItems.Any() && !daGuiBep)
            {
                DialogResult result = MessageBox.Show("Bạn có các món chưa gửi bếp. Thoát sẽ làm mất các món này. Bạn có chắc chắn muốn thoát?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }
            LoadBan();
        }

        #endregion

        #region Utility Methods
        private string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength - 3) + "...";
        }
        #endregion

        // Các sự kiện chưa dùng đến có thể để trống
        private void btnPrintCheck_Click(object sender, EventArgs e) { }
        private void btnGuestCheck_Click(object sender, EventArgs e) { }
        private void lblWholeCheck_Click(object sender, EventArgs e) { }
        private void btnInfo_Click(object sender, EventArgs e) { }
        private void btnExit_Click(object sender, EventArgs e) { this.Close(); }

    }
}
