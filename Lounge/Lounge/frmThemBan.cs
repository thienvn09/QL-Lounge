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

namespace Lounge
{
    public partial class frmThemBan : Form
    {
        public Ban banmoi { get; private set; }
        public frmThemBan()
        {
            InitializeComponent();
            cbbViTri.Items.AddRange(new string[] { "Nhà Hàng", "Quầy Bar" });
            txtTrangThai.Items.AddRange(new string[] { "Trống", "Đang sử dụng" });
        }

        private void frmThemBan_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSoBan.Text) || string.IsNullOrEmpty(txtSoCho.Text) || string.IsNullOrEmpty(cbbViTri.Text) || string.IsNullOrEmpty(txtTrangThai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            banmoi = new Ban
            {
                SoBan = txtSoBan.Text.Trim(),
                SoChoNgoi = int.Parse(txtSoCho.Text.Trim()),
                KhuVuc = cbbViTri.SelectedItem.ToString(),
                TrangThai = txtTrangThai.SelectedItem.ToString()
            };
            this.DialogResult = DialogResult.OK; // Đặt kết quả của form là OK
            this.Close(); // Đóng form
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đặt kết quả của form là Cancel
            this.Close(); // Đóng form
        }
    }
}
