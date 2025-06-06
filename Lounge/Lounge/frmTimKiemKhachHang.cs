using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lounge.DAL;
using Lounge.Model;

namespace Lounge
{
    public partial class frmTimKiemKhachHang : Form
    {
        // DAL để tương tác với bảng KhachHang
        private KhachHangDAL khachHangDAL = new KhachHangDAL();

        /// <summary>
        /// Thuộc tính này sẽ giữ khách hàng được chọn để form TrangChu có thể lấy về.
        /// </summary>
        public KhachHan SelectedKhachHang { get; private set; }

        public frmTimKiemKhachHang()
        {
            InitializeComponent();
        }

        private void frmTimKiemKhachHang_Load(object sender, EventArgs e)
        {
            // Tùy chỉnh giao diện DataGridView
            dgvResults.AutoGenerateColumns = false;
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "MaKhachHang", HeaderText = "Mã KH", DataPropertyName = "MaKhachHang", Width = 80 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "TenKhachHang", HeaderText = "Tên Khách Hàng", DataPropertyName = "TenKhachHang", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn { Name = "SoDienThoai", HeaderText = "Số Điện Thoại", DataPropertyName = "SoDienThoai", Width = 150 });

            // Tải toàn bộ danh sách khách hàng khi mở form (tùy chọn)
            SearchCustomers("");
        }


        /// <summary>
        /// Xử lý sự kiện click nút tìm kiếm.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchCustomers(txtSearchKeyword.Text.Trim());
        }

        /// <summary>
        /// Xử lý sự kiện nhấn Enter trong ô tìm kiếm.
        /// </summary>
        private void txtSearchKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCustomers(txtSearchKeyword.Text.Trim());
                e.SuppressKeyPress = true; // Ngăn tiếng 'beep' của Windows
            }
        }

        /// <summary>
        /// Hàm chung để tìm kiếm và hiển thị kết quả.
        /// </summary>
        private void SearchCustomers(string keyword)
        {
            try
            {
                // Gọi hàm từ DAL để tìm kiếm  
                List<KhachHan> results = new List<KhachHan>();
                var khachHang = khachHangDAL.GetKHById(int.Parse(keyword));
                if (khachHang != null)
                {
                    results.Add(khachHang);
                }
                dgvResults.DataSource = results;

                if (results.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Xử lý sự kiện click nút "Chọn".
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvResults.CurrentRow != null && dgvResults.CurrentRow.DataBoundItem is KhachHan selected)
            {
                this.SelectedKhachHang = selected;
                this.DialogResult = DialogResult.OK; // Báo cho form cha biết đã chọn thành công
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý sự kiện double-click trên một dòng trong DataGridView.
        /// </summary>
        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo double-click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e); // Gọi lại hàm của nút "Chọn"
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút "Hủy".
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
