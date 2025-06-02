using Lounge.Model;
using NhaHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class FormQL : Form
    {
        private Form currentFrch;
        public FormQL()
        {
            InitializeComponent();
        }
        public void OpenChildForm(Form currentFrch, Panel Panel_Body, Form frch)
        {
            if (currentFrch != null)
            {
                currentFrch.Close();
            }
            currentFrch = frch;
            frch.TopLevel = false;
            frch.FormBorderStyle = FormBorderStyle.None;
            frch.Dock = DockStyle.Fill;
            Panel_Body.Controls.Add(frch);
            Panel_Body.Tag = frch;
            frch.BringToFront();
            frch.Show();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FormNhanVien nhanVien = new FormNhanVien();
            OpenChildForm(currentFrch,Panel_Body,nhanVien);

        }

        private void Panel_Body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            FormQLKH khachHang = new FormQLKH();
            OpenChildForm(currentFrch, Panel_Body, khachHang);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            FormQLNCC nhaCungCap = new FormQLNCC();
            OpenChildForm(currentFrch, Panel_Body, nhaCungCap);
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            QLPhieuNhapKho phieuNhapKho = new QLPhieuNhapKho();
            OpenChildForm(currentFrch, Panel_Body, phieuNhapKho);
        }

        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            QLPhieuXuatKho qLPhieuXuatKho = new QLPhieuXuatKho();
            OpenChildForm(currentFrch, Panel_Body, qLPhieuXuatKho);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            QLBaoCao qLBaoCao = new QLBaoCao();
            OpenChildForm(currentFrch, Panel_Body, qLBaoCao);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            FormQLSP sanPham = new FormQLSP();
            OpenChildForm(currentFrch, Panel_Body, sanPham);
        }
    }
}
