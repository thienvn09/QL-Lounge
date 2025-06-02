using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lounge.DAL; // Cần using DAL
using Lounge.Model; // Cần using Model

namespace Lounge
{
    public partial class FormChiTietHoaDon : Form
    {
        private int _maHoaDonDuocTruyen;
        private HoaDon _hoaDonHienThi; // Để lưu thông tin hóa đơn chính
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private HoaDonDAL hoaDonDAL = new HoaDonDAL(); // Cần để lấy thông tin HoaDon nếu chỉ truyền mã

        // Constructor nhận MaHoaDon
        public FormChiTietHoaDon(int maHoaDon)
        {
            InitializeComponent();
            _maHoaDonDuocTruyen = maHoaDon;
            // Lấy thông tin hóa đơn đầy đủ từ DAL nếu chỉ có mã
            // Điều này tốt hơn là truyền nhiều tham số lẻ tẻ
            _hoaDonHienThi = hoaDonDAL.LayHoaDonTheoMa(_maHoaDonDuocTruyen);
        }

        // Constructor có thể nhận cả đối tượng HoaDon (nếu bạn muốn truyền từ FormQLHoaDon)
        public FormChiTietHoaDon(HoaDon hoaDon)
        {
            InitializeComponent();
            _hoaDonHienThi = hoaDon;
            _maHoaDonDuocTruyen = hoaDon.MaHoaDon; // Lấy mã từ đối tượng
        }


        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            WireUpButtonEvents();
            DisplayThongTinChung();
            ConfigureDataGridView();
            LoadChiTietData();
        }

        private void WireUpButtonEvents()
        {
            btnDong.Click += BtnDong_Click;
        }

        private void DisplayThongTinChung()
        {
            if (_hoaDonHienThi != null)
            {
                txtMaHoaDonDisplay.Text = _hoaDonHienThi.MaHoaDon.ToString();
                txtTenKhachHang.Text = _hoaDonHienThi.TenKhachHang; // Giả định Model HoaDon có TenKhachHang
                txtNgayDat.Text = _hoaDonHienThi.NgayDat.ToString("dd/MM/yyyy HH:mm:ss");
                txtTongThanhToan.Text = _hoaDonHienThi.ThanhToan.ToString("N0") + "đ"; // Giả định Model HoaDon có ThanhToan
            }
            else
            {
                // Xử lý trường hợp không tìm thấy hóa đơn (ví dụ, nếu chỉ truyền mã và mã đó không hợp lệ)
                txtMaHoaDonDisplay.Text = _maHoaDonDuocTruyen.ToString();
                txtTenKhachHang.Text = "Không tìm thấy";
                txtNgayDat.Text = "";
                txtTongThanhToan.Text = "0đ";
                MessageBox.Show($"Không tìm thấy thông tin cho hóa đơn mã: {_maHoaDonDuocTruyen}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            dgvChiTiet.AutoGenerateColumns = false;
            dgvChiTiet.Columns.Clear();

            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaSanPham",
                HeaderText = "Mã SP",
                Width = 80
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenSanPham", // Cần thuộc tính này trong Model ChiTietHoaDon
                HeaderText = "Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoLuong",
                HeaderText = "SL",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gia",
                HeaderText = "Đơn Giá",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThueVAT",
                HeaderText = "VAT(%)",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleCenter }  // Hiển thị 2 số lẻ cho %
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TienThue", // Cột tính toán trong DB
                HeaderText = "Tiền Thuế",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvChiTiet.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ThanhTien", // Cột tính toán trong DB
                HeaderText = "Thành Tiền",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void LoadChiTietData()
        {
            if (_maHoaDonDuocTruyen <= 0 && _hoaDonHienThi == null)
            {
                MessageBox.Show("Không có thông tin hóa đơn để hiển thị chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sử dụng _maHoaDonDuocTruyen đã được gán trong constructor
                List<ChiTietHoaDon> dsChiTiet = chiTietHoaDonDAL.LayChiTietHoaDonTheoMaHoaDon(_maHoaDonDuocTruyen);
                dgvChiTiet.DataSource = null;

                if (dsChiTiet != null && dsChiTiet.Any())
                {
                    dgvChiTiet.DataSource = dsChiTiet;
                }
                else
                {
                    // Có thể hiển thị thông báo nếu hóa đơn không có chi tiết nào
                    // MessageBox.Show("Hóa đơn này không có sản phẩm nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
