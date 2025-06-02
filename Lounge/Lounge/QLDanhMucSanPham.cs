using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lounge.DAL; // Đảm bảo bạn đã có namespace này
using Lounge.Model; // Đảm bảo bạn đã có namespace này

namespace Lounge
{
    public partial class QLDanhMucSanPham : Form
    {
        private DanhMucSPDAL danhMucSPDAL = new DanhMucSPDAL();
        private List<DanhMucSanPham> dsDanhMuc = new List<DanhMucSanPham>();
        private int currentIndex = -1;

        public QLDanhMucSanPham()
        {
            InitializeComponent();
        }

        private void QLDanhMucSanPham_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
            ConfigureDataGridView();
            LoadData();
            // Gán sự kiện cho các nút sau khi chúng đã được khởi tạo
            WireUpButtonEvents();
        }

        private void WireUpButtonEvents()
        {
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            btnLoc.Click += btnLoc_Click;
            btnKoLoc.Click += btnKoLoc_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            btnDau.Click += btnDau_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnKe.Click += btnKe_Click;
            btnCuoi.Click += btnCuoi_Click;
        }

        private void InitializeComboBox()
        {
            cboLoaiDanhMuc.Items.Clear();
            cboLoaiDanhMuc.Items.Add("Đồ uống"); // Phải khớp với giá trị trong CSDL
            cboLoaiDanhMuc.Items.Add("Món ăn");  // Phải khớp với giá trị trong CSDL
            cboLoaiDanhMuc.SelectedIndex = -1; // Không chọn gì ban đầu hoặc chọn giá trị mặc định
        }

        private void ConfigureDataGridView()
        {
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.Columns.Clear();
            dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaDanhMuc", HeaderText = "Mã DM", Width = 80 });
            dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDanhMuc", HeaderText = "Tên Danh Mục", Width = 200 });
            dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Loai", HeaderText = "Loại", Width = 100 });
            dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ThueVAT", HeaderText = "Thuế VAT (%)", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });
            dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MoTa", HeaderText = "Mô Tả", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill }); // Cho cột mô tả fill

            dgvDanhMuc.SelectionChanged += DgvDanhMuc_SelectionChanged;
        }

        private void LoadData()
        {
            try
            {
                dsDanhMuc = danhMucSPDAL.GetAllDanhMucSP();
                dgvDanhMuc.DataSource = null; // Xóa binding cũ
                if (dsDanhMuc != null)
                {
                    dgvDanhMuc.DataSource = dsDanhMuc;
                    lblTongSo.Text = dsDanhMuc.Count.ToString();
                    currentIndex = dsDanhMuc.Count > 0 ? 0 : -1;
                    txtHienHanh.Text = dsDanhMuc.Count > 0 ? "1" : "0";
                }
                else
                {
                    dsDanhMuc = new List<DanhMucSanPham>(); // Khởi tạo danh sách rỗng nếu DAL trả về null
                    lblTongSo.Text = "0";
                    currentIndex = -1;
                    txtHienHanh.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dsDanhMuc = new List<DanhMucSanPham>(); // Đảm bảo dsDanhMuc không null
                lblTongSo.Text = "0";
                currentIndex = -1;
                txtHienHanh.Text = "0";
            }
            DisplayCurrentDanhMuc();
            UpdateNavigationButtons();
        }


        private void DgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhMuc.SelectedRows.Count > 0)
            {
                currentIndex = dgvDanhMuc.SelectedRows[0].Index;
                DisplayCurrentDanhMuc();
                UpdateNavigationButtons();
            }
        }

        private void DisplayCurrentDanhMuc()
        {
            if (currentIndex >= 0 && currentIndex < dsDanhMuc.Count)
            {
                var dm = dsDanhMuc[currentIndex];
                txtMaDanhMuc.Text = dm.MaDanhMuc.ToString();
                txtTenDanhMuc.Text = dm.TenDanhMuc;
                cboLoaiDanhMuc.SelectedItem = dm.Loai;
                txtThueVAT.Text = dm.ThueVAT.ToString("N2"); // Định dạng số có 2 chữ số thập phân
                txtMoTaDanhMuc.Text = dm.MoTa;
                txtHienHanh.Text = (currentIndex + 1).ToString();
            }
            else
            {
                ClearInputFields();
                txtHienHanh.Text = "0";
            }
        }

        private void ClearInputFields()
        {
            txtMaDanhMuc.Text = ""; // Mã thường không cho sửa khi thêm mới, sẽ tự tăng hoặc được tạo
            txtTenDanhMuc.Text = "";
            cboLoaiDanhMuc.SelectedIndex = -1; // Hoặc giá trị mặc định
            txtThueVAT.Text = "0.00";
            txtMoTaDanhMuc.Text = "";
        }

        private void UpdateNavigationButtons()
        {
            bool hasData = dsDanhMuc.Count > 0;
            btnDau.Enabled = hasData && currentIndex > 0;
            btnTruoc.Enabled = hasData && currentIndex > 0;
            btnKe.Enabled = hasData && currentIndex < dsDanhMuc.Count - 1;
            btnCuoi.Enabled = hasData && currentIndex < dsDanhMuc.Count - 1;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanhMuc.Focus();
                return false;
            }
            if (cboLoaiDanhMuc.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiDanhMuc.Focus();
                return false;
            }
            if (!decimal.TryParse(txtThueVAT.Text, out decimal thueVAT) || thueVAT < 0 || thueVAT > 100)
            {
                MessageBox.Show("Thuế VAT phải là một số hợp lệ từ 0 đến 100!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThueVAT.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                DanhMucSanPham dm = new DanhMucSanPham
                {
                    TenDanhMuc = txtTenDanhMuc.Text.Trim(),
                    Loai = cboLoaiDanhMuc.SelectedItem.ToString(),
                    ThueVAT = decimal.Parse(txtThueVAT.Text),
                    MoTa = txtMoTaDanhMuc.Text.Trim()
                };

                try
                {
                    if (danhMucSPDAL.AddDanhMuc(dm))
                    {
                        MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Tải lại dữ liệu để hiển thị danh mục mới
                        // Tùy chọn: Di chuyển đến danh mục vừa thêm
                        var newDm = dsDanhMuc.FirstOrDefault(d => d.TenDanhMuc == dm.TenDanhMuc && d.Loai == dm.Loai);
                        if (newDm != null)
                        {
                            currentIndex = dsDanhMuc.IndexOf(newDm);
                            DisplayCurrentDanhMuc();
                            if (currentIndex >= 0) dgvDanhMuc.Rows[currentIndex].Selected = true;
                        }
                        ClearInputFields(); // Xóa trắng các ô nhập liệu sau khi thêm
                    }
                    else
                    {
                        MessageBox.Show("Thêm danh mục thất bại! Tên danh mục có thể đã tồn tại hoặc có lỗi khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn một danh mục để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInput())
            {
                DanhMucSanPham dm = new DanhMucSanPham
                {
                    MaDanhMuc = int.Parse(txtMaDanhMuc.Text),
                    TenDanhMuc = txtTenDanhMuc.Text.Trim(),
                    Loai = cboLoaiDanhMuc.SelectedItem.ToString(),
                    ThueVAT = decimal.Parse(txtThueVAT.Text),
                    MoTa = txtMoTaDanhMuc.Text.Trim()
                };

                try
                {
                    if (danhMucSPDAL.UpdateDanhMuc(dm))
                    {
                        MessageBox.Show("Cập nhật danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        int previousIndex = currentIndex; // Lưu lại vị trí cũ
                        LoadData();
                        // Cố gắng chọn lại dòng vừa sửa
                        if (previousIndex >= 0 && previousIndex < dsDanhMuc.Count)
                        {
                            var updatedDm = dsDanhMuc.FirstOrDefault(d => d.MaDanhMuc == dm.MaDanhMuc);
                            if (updatedDm != null)
                            {
                                currentIndex = dsDanhMuc.IndexOf(updatedDm);
                            }
                            else
                            {
                                currentIndex = previousIndex; // Nếu không tìm thấy, giữ lại index cũ (có thể đã bị xóa bởi người khác)
                                if (currentIndex >= dsDanhMuc.Count) currentIndex = dsDanhMuc.Count > 0 ? dsDanhMuc.Count - 1 : -1;
                            }
                        }
                        else if (dsDanhMuc.Count > 0)
                        {
                            currentIndex = 0;
                        }
                        else
                        {
                            currentIndex = -1;
                        }
                        DisplayCurrentDanhMuc();
                        if (currentIndex >= 0 && currentIndex < dgvDanhMuc.Rows.Count) dgvDanhMuc.Rows[currentIndex].Selected = true;

                    }
                    else
                    {
                        MessageBox.Show("Cập nhật danh mục thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn một danh mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục '{txtTenDanhMuc.Text}' không?\nLưu ý: Nếu danh mục này đang được sử dụng bởi các sản phẩm, việc xóa có thể không thành công.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maDanhMuc = int.Parse(txtMaDanhMuc.Text);
                    if (danhMucSPDAL.DeleteDanhMuc(maDanhMuc))
                    {
                        MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Tải lại dữ liệu
                        // currentIndex sẽ tự động cập nhật trong LoadData
                    }
                    else
                    {
                        MessageBox.Show("Xóa danh mục thất bại! Danh mục có thể đang được sử dụng hoặc có lỗi khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            txtTimMaDanhMuc.Text = "";
            txtTimTenDanhMuc.Text = "";
            radMaDanhMuc.Checked = false;
            radTenDanhMuc.Checked = false;
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            List<DanhMucSanPham> allData;
            try
            {
                allData = danhMucSPDAL.GetAllDanhMucSP();
                if (allData == null) allData = new List<DanhMucSanPham>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu để lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<DanhMucSanPham> filteredData = allData;

            if (radMaDanhMuc.Checked && !string.IsNullOrWhiteSpace(txtTimMaDanhMuc.Text))
            {
                if (int.TryParse(txtTimMaDanhMuc.Text, out int maDM))
                {
                    filteredData = filteredData.Where(dm => dm.MaDanhMuc == maDM);
                }
                else
                {
                    MessageBox.Show("Mã danh mục tìm kiếm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (radTenDanhMuc.Checked && !string.IsNullOrWhiteSpace(txtTimTenDanhMuc.Text))
            {
                string searchTerm = txtTimTenDanhMuc.Text.Trim().ToLower();
                filteredData = filteredData.Where(dm => dm.TenDanhMuc.ToLower().Contains(searchTerm));
            }
            // Nếu không chọn tiêu chí nào hoặc không nhập gì, sẽ hiển thị tất cả (filteredData = allData)

            dsDanhMuc = filteredData.ToList();
            dgvDanhMuc.DataSource = null;
            dgvDanhMuc.DataSource = dsDanhMuc;

            lblTongSo.Text = dsDanhMuc.Count.ToString();
            currentIndex = dsDanhMuc.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsDanhMuc.Count > 0 ? "1" : "0";
            DisplayCurrentDanhMuc();
            UpdateNavigationButtons();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            txtTimMaDanhMuc.Text = "";
            txtTimTenDanhMuc.Text = "";
            radMaDanhMuc.Checked = false;
            radTenDanhMuc.Checked = false;
            LoadData(); // Tải lại toàn bộ dữ liệu
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsDanhMuc.Count > 0)
            {
                currentIndex = 0;
                DisplayCurrentDanhMuc();
                if (dgvDanhMuc.Rows.Count > currentIndex) dgvDanhMuc.Rows[currentIndex].Selected = true;
                UpdateNavigationButtons();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentDanhMuc();
                if (dgvDanhMuc.Rows.Count > currentIndex) dgvDanhMuc.Rows[currentIndex].Selected = true;
                UpdateNavigationButtons();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsDanhMuc.Count - 1)
            {
                currentIndex++;
                DisplayCurrentDanhMuc();
                if (dgvDanhMuc.Rows.Count > currentIndex) dgvDanhMuc.Rows[currentIndex].Selected = true;
                UpdateNavigationButtons();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsDanhMuc.Count > 0)
            {
                currentIndex = dsDanhMuc.Count - 1;
                DisplayCurrentDanhMuc();
                if (dgvDanhMuc.Rows.Count > currentIndex) dgvDanhMuc.Rows[currentIndex].Selected = true;
                UpdateNavigationButtons();
            }
        }
    }
}
