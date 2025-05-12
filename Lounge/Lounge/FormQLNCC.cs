using Lounge.DAL;
using Lounge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormQLNCC : Form
    {
        private NhaCungCapDAL nhaCungCapDAL = new NhaCungCapDAL();
        private List<NhaCungCap> dsNhaCungCap = new List<NhaCungCap>();
        private int currentIndex = -1;

        public FormQLNCC()
        {
            InitializeComponent();
            LoadData();
            ConfigureDataGridView();
            UpdateNavigation();
            // Wire up button events
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            btnLoc.Click += btnLoc_Click;
            btnKoLoc.Click += btnKoLoc_Click;
            btnDau.Click += btnDau_Click;
            btnTruoc.Click += btnTruoc_Click;
            btnKe.Click += btnKe_Click;
            btnCuoi.Click += btnCuoi_Click;
            btnLamMoi.Click += btnLamMoi_Click;
        }

        private void LoadData()
        {
            dsNhaCungCap = nhaCungCapDAL.GetAllNhaCungCap();
            dgvNhaCungCap.DataSource = null;
            dgvNhaCungCap.DataSource = dsNhaCungCap;
            lblTongTin.Text = dsNhaCungCap.Count.ToString();
            txtHienHanh.Text = dsNhaCungCap.Count > 0 ? "1" : "0";
            currentIndex = dsNhaCungCap.Count > 0 ? 0 : -1;
            DisplayCurrentNCC();
            UpdateNavigation();
        }

        private void ConfigureDataGridView()
        {
            dgvNhaCungCap.AutoGenerateColumns = false;
            dgvNhaCungCap.Columns.Clear();
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNhaCungCap", HeaderText = "Mã NCC" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenNhaCungCap", HeaderText = "Tên NCC" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "Điện Thoại" });
            dgvNhaCungCap.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email" });
            dgvNhaCungCap.SelectionChanged += DgvNhaCungCap_SelectionChanged;
        }

        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhaCungCap.SelectedRows.Count > 0)
            {
                currentIndex = dgvNhaCungCap.SelectedRows[0].Index;
                DisplayCurrentNCC();
                UpdateNavigation();
            }
        }

        private void DisplayCurrentNCC()
        {
            if (currentIndex >= 0 && currentIndex < dsNhaCungCap.Count)
            {
                var ncc = dsNhaCungCap[currentIndex];
                txtMaNCC.Text = ncc.MaNhaCungCap.ToString();
                txtTenNCC.Text = ncc.TenNhaCungCap;
                txtSoDienThoai.Text = ncc.SoDienThoai ?? "";
                txtEmail.Text = ncc.Email ?? "";
                txtHienHanh.Text = (currentIndex + 1).ToString();
            }
            else
            {
                ClearInputFields();
            }
        }

        private void ClearInputFields()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
        }

        private void UpdateNavigation()
        {
            btnDau.Enabled = dsNhaCungCap.Count > 0 && currentIndex > 0;
            btnTruoc.Enabled = dsNhaCungCap.Count > 0 && currentIndex > 0;
            btnKe.Enabled = dsNhaCungCap.Count > 0 && currentIndex < dsNhaCungCap.Count - 1;
            btnCuoi.Enabled = dsNhaCungCap.Count > 0 && currentIndex < dsNhaCungCap.Count - 1;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            LoadData();
            radMaNCC.Checked = false;
            radTenNCC.Checked = false;
            txt_timMaNCC.Text = "";
            txt_timTenNCC.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtSoDienThoai.Text) && !Regex.IsMatch(txtSoDienThoai.Text, @"^\+?\d{10,15}$"))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại từ 10 đến 15 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            dsNhaCungCap = nhaCungCapDAL.GetAllNhaCungCap();
            if (radMaNCC.Checked && !string.IsNullOrWhiteSpace(txt_timMaNCC.Text) && int.TryParse(txt_timMaNCC.Text, out int maNCC))
            {
                dsNhaCungCap = dsNhaCungCap.Where(ncc => ncc.MaNhaCungCap == maNCC).ToList();
            }
            else if (radTenNCC.Checked && !string.IsNullOrWhiteSpace(txt_timTenNCC.Text))
            {
                dsNhaCungCap = dsNhaCungCap.Where(ncc => ncc.TenNhaCungCap.IndexOf(txt_timTenNCC.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            dgvNhaCungCap.DataSource = null;
            dgvNhaCungCap.DataSource = dsNhaCungCap;
            lblTongTin.Text = dsNhaCungCap.Count.ToString();
            currentIndex = dsNhaCungCap.Count > 0 ? 0 : -1;
            txtHienHanh.Text = dsNhaCungCap.Count > 0 ? "1" : "0";
            DisplayCurrentNCC();
            UpdateNavigation();
        }

        private void btnKoLoc_Click(object sender, EventArgs e)
        {
            LoadData();
            radMaNCC.Checked = false;
            radTenNCC.Checked = false;
            txt_timMaNCC.Text = "";
            txt_timTenNCC.Text = "";
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            if (dsNhaCungCap.Count > 0)
            {
                currentIndex = 0;
                DisplayCurrentNCC();
                dgvNhaCungCap.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            if (dsNhaCungCap.Count > 0)
            {
                currentIndex = dsNhaCungCap.Count - 1;
                DisplayCurrentNCC();
                dgvNhaCungCap.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayCurrentNCC();
                dgvNhaCungCap.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            if (currentIndex < dsNhaCungCap.Count - 1)
            {
                currentIndex++;
                DisplayCurrentNCC();
                dgvNhaCungCap.Rows[currentIndex].Selected = true;
                UpdateNavigation();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var ncc = new NhaCungCap
                {
                    TenNhaCungCap = txtTenNCC.Text,
                    SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text
                };

                if (nhaCungCapDAL.AddNCC(ncc))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearInputFields();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateInput() && int.TryParse(txtMaNCC.Text, out int maNhaCungCap))
            {
                var ncc = new NhaCungCap
                {
                    MaNhaCungCap = maNhaCungCap,
                    TenNhaCungCap = txtTenNCC.Text,
                    SoDienThoai = string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ? null : txtSoDienThoai.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text
                };

                if (nhaCungCapDAL.UpdateNCC(ncc))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtMaNCC.Text, out int maNhaCungCap))
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (nhaCungCapDAL.DeleteNCC(maNhaCungCap))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhà cung cấp thất bại! Có thể nhà cung cấp đang được tham chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}