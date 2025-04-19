using Lounge.DAL;
using Lounge.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace Lounge
{
    public partial class FormNhanVien : Form
    {
        KetNoi kn = new KetNoi();
        public NhanVienDAL nhanVienDAL = new NhanVienDAL();
        private BindingSource bdsource = new BindingSource();
        public FormNhanVien()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            bdsource.DataSource = nhanVienDAL.GetAllNhanVien(); // Gọi dữ liệu nhân viên
            dgvNhanVien.DataSource = bdsource;
            // SELECT MaNV, HoTen, ChucVu, SDT_NV, Email_NV, DiaChi, GioiTinh, NgayTao
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();

            // Thay đổi độ rộng các cột
            dgvNhanVien.Columns[0].Width = 100;//MaNhanVien
            dgvNhanVien.Columns[1].Width = 120;  // HoTen
            dgvNhanVien.Columns[2].Width = 80;   // ChucVu
            dgvNhanVien.Columns[3].Width = 100;  // SDT_NV
            dgvNhanVien.Columns[4].Width = 150;  // Email_NV
            dgvNhanVien.Columns[5].Width = 150;  // DiaChi
            dgvNhanVien.Columns[6].Width = 80;   // NgayTao
            dgvNhanVien.Columns[7].Width = 80;   // GioiTinh (vị trí 6 nếu thêm sau NgayTao)

            // Cài đặt style cho DataGridView
            dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Nạp dữ liệu cho ComboBox giới tính
            cboxGioiTinh.Items.Clear();
            cboxGioiTinh.Items.Add("Nam");
            cboxGioiTinh.Items.Add("Nữ");
            cboxGioiTinh.Items.Add("Khác");
            cboxGioiTinh.SelectedIndex = -1; // Đặt giá trị mặc định là không chọn gì

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnDau_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();

            btnTruoc.Enabled = false;
            btnDau.Enabled = false;
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();

            if (bdsource.Position == 0)
            {
                btnTruoc.Enabled = false;
                btnDau.Enabled = false;
            }
            btnKe.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnKe_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();

            if (bdsource.Position == bdsource.Count - 1)
            {
                btnKe.Enabled = false;
                btnCuoi.Enabled = false;
            }
            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
            txtHienHanh.Text = (bdsource.Position + 1).ToString();
            lblTongTin.Text = bdsource.Count.ToString();

            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
            btnKe.Enabled = false;
            btnCuoi.Enabled = false;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            cboxGioiTinh.Text = "";
            txtMaNV.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien()
            {
                HoTen = txtTenNV.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim(),
                SDT_NV = txtDienThoai.Text.Trim(),
                Email_NV = txtEmail.Text.Trim(),
                NgayTao = dtpNgayVaoLam.Value,
                DiaChi = txtDiaChi.Text.Trim(),
                GioiTinh = cboxGioiTinh.SelectedItem?.ToString()
            };
            try
            {
                nhanVienDAL.ThemNhanVien(nhanVien);
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtMaNV.Text, out int manv)) // Convert string to int safely  
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        nhanVienDAL.XoaNhanVien(manv); // Pass the integer value  
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại DataGridView  
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void dgvNhanVien_SelectionChanged(object sender, DataGridViewCellEventArgs e)
        {
            
                txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value.ToString();
                txtChucVu.Text = dgvNhanVien.CurrentRow.Cells["ChucVu"].Value.ToString();
                if(dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value != null)
                {
                cboxGioiTinh.SelectedItem = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
                }
                else
                {
                cboxGioiTinh.SelectedIndex = -1; // Đặt giá trị mặc định là không chọn gì
                }
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
                txtDienThoai.Text = dgvNhanVien.CurrentRow.Cells["SDT_NV"].Value.ToString();
                dtpNgayVaoLam.Value = Convert.ToDateTime(dgvNhanVien.CurrentRow.Cells["NgayTao"].Value);
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email_NV"].Value.ToString();
            
        }

      
    }
}
