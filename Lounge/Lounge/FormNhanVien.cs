using Lounge.DAL;
using Lounge.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormNhanVien : Form
    {
        private KetNoi kn = new KetNoi();
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private BindingSource bdsource = new BindingSource();

        public FormNhanVien()
        {
            InitializeComponent();
        }
        private void FormNhanVien_Resize(object sender, EventArgs e)
        {
            this.label17.Location = new System.Drawing.Point((this.ClientSize.Width - this.label17.Width) / 2, 8);
            this.groupBox4.Location = new System.Drawing.Point(this.ClientSize.Width - 550, 60);
            this.btnLamMoi.Location = new System.Drawing.Point(this.ClientSize.Width - 200, 20);
        }
        private void LoadData()
        {
            try
            {
                bdsource.DataSource = nhanVienDAL.GetAllNhanVien();
                dgvNhanVien.DataSource = bdsource;

                txtHienHanh.Text = (bdsource.Position + 1).ToString();
                lblTongTin.Text = bdsource.Count.ToString();

                // Thay đổi độ rộng các cột
                dgvNhanVien.Columns["MaNhanvien"].Width = 100;
                dgvNhanVien.Columns["HoTen"].Width = 120;
                //dgvNhanVien.Columns["ChucVu"].Width = 80; // Uncomment if ChucVu is in model
                dgvNhanVien.Columns["SDT_NV"].Width = 100;
                dgvNhanVien.Columns["Email_NV"].Width = 150;
                dgvNhanVien.Columns["NgayTao"].Width = 80;

                // Đặt tiêu đề cột
                dgvNhanVien.Columns["MaNhanvien"].HeaderText = "Mã NV";
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                //dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ"; // Uncomment if ChucVu is in model
                dgvNhanVien.Columns["SDT_NV"].HeaderText = "SĐT";
                dgvNhanVien.Columns["Email_NV"].HeaderText = "Email";
                dgvNhanVien.Columns["NgayTao"].HeaderText = "Ngày Tạo";

                // Cài đặt style cho DataGridView
                dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
                dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                UpdateNavigationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNavigationButtons()
        {
            btnDau.Enabled = bdsource.Count > 1 && bdsource.Position > 0;
            btnTruoc.Enabled = bdsource.Count > 1 && bdsource.Position > 0;
            btnKe.Enabled = bdsource.Count > 1 && bdsource.Position < bdsource.Count - 1;
            btnCuoi.Enabled = bdsource.Count > 1 && bdsource.Position < bdsource.Count - 1;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            txtMaNV.Enabled = false; // Vô hiệu hóa txtMaNV vì MaNV tự sinh
            radTenNV.Checked = true; // Default to search by name
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();
            UpdateNavigationButtons();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();
            UpdateNavigationButtons();
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();
            UpdateNavigationButtons();
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();
            UpdateNavigationButtons();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
            txtMaNV.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txt_timMaNV.Clear();
            txt_timTenNV.Clear();
            radTenNV.Checked = true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string filter = "";
                if (radMaNV.Checked && !string.IsNullOrWhiteSpace(txt_timMaNV.Text))
                {
                    filter = $"MaNhanvien = '{txt_timMaNV.Text.Trim()}'";
                }
                else if (radTenNV.Checked && !string.IsNullOrWhiteSpace(txt_timTenNV.Text))
                {
                    filter = $"HoTen LIKE '%{txt_timTenNV.Text.Trim()}%'";
                }

                var list = nhanVienDAL.GetAllNhanVien();
                if (!string.IsNullOrEmpty(filter))
                {
                    bdsource.DataSource = list.Where(nv => filter == "" || (radMaNV.Checked && nv.MaNhanvien.ToString() == txt_timMaNV.Text.Trim()) || (radTenNV.Checked && nv.HoTen.Contains(txt_timTenNV.Text.Trim()))).ToList();

                }
                else
                {
                    bdsource.DataSource = list;
                }

                dgvNhanVien.DataSource = bdsource;
                txtHienHanh.Text = (bdsource.Position + 1).ToString();
                lblTongTin.Text = bdsource.Count.ToString();
                UpdateNavigationButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            txt_timMaNV.Clear();
            txt_timTenNV.Clear();
            radTenNV.Checked = true;
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                NhanVien nhanVien = new NhanVien
                {
                    HoTen = txtTenNV.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim(), 
                    SDT_NV = txtDienThoai.Text.Trim(),
                    Email_NV = txtEmail.Text.Trim(),
                    NgayTao = dtpNgayVaoLam.Value
                };

                nhanVienDAL.ThemNhanVien(nhanVien);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;
                if (!int.TryParse(txtMaNV.Text, out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVien nhanVien = new NhanVien
                {
                    MaNhanvien = maNV,
                    HoTen = txtTenNV.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim(), // Uncomment if ChucVu is in model
                    SDT_NV = txtDienThoai.Text.Trim(),
                    Email_NV = txtEmail.Text.Trim(),
                    NgayTao = dtpNgayVaoLam.Value
                };

                nhanVienDAL.SuaNhanVien(nhanVien);
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtMaNV.Text, out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    nhanVienDAL.XoaNhanVien(maNV);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                var row = dgvNhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNhanvien"].Value.ToString();
                txtTenNV.Text = row.Cells["HoTen"].Value.ToString();
                txtChucVu.Text = row.Cells["ChucVu"].Value.ToString(); // Uncomment if ChucVu is in model
                txtDienThoai.Text = row.Cells["SDT_NV"].Value.ToString();
                txtEmail.Text = row.Cells["Email_NV"].Value?.ToString() ?? "";
                dtpNgayVaoLam.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);

                txtMaNV.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtChucVu.Text)) // Uncomment if ChucVu is in model
            {
               MessageBox.Show("Vui lòng nhập chức vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               txtChucVu.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txtDienThoai.Text, @"^\+?\d[\d\s-]{8,12}\d$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Phải có 10-13 chữ số, có thể chứa dấu cách hoặc gạch ngang.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        private void ClearInputs()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtChucVu.Text = ""; 
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            dtpNgayVaoLam.Value = DateTime.Now;
            txtMaNV.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}