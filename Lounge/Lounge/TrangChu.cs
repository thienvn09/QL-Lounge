using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lounge.DAL;

using System.Windows.Forms;
using Lounge.Model;

namespace Lounge
{
    public partial class TrangChu : Form
    {
        private Ban ban = new Ban();
        BanDAL banDAL = new BanDAL();
        public TrangChu()
        {
            InitializeComponent();

            LoadBan();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
            this.Close();
        }
       

        private void TrangChu_Load(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadBan()
        {
            plnBan.Controls.Clear();
            List<Ban> dsban = banDAL.GetAllBan();

            int x = 10, y = 10;
            int count = 0;

            foreach (var ban in dsban)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 80;
                btn.Text = $"{ban.SoBan}\n👤 {ban.SoChoNgoi}\n{ban.TrangThai}";
                btn.BackColor = ban.TrangThai == "Đang sử dụng" ? Color.RoyalBlue : Color.LightGray;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Tag = ban.MaBan;

                btn.Location = new Point(x, y);

                // Gắn đúng sự kiện click
                btn.Click += Ban_Click;

                plnBan.Controls.Add(btn);

                x += 130;
                count++;
                if (count % 4 == 0)
                {
                    x = 10;
                    y += 90;
                }
            }
        }

        private void Ban_Click(object sender, EventArgs e)
        {
           /* Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                int maBan = (int)btn.Tag;

                ChiTietBanDAL chiTietBanDAL = new ChiTietBanDAL();
                var chiTiet = chiTietBanDAL.GetChiTietBans(maBan);

                pnlChiTietBan.Controls.Clear(); // Xóa nội dung cũ
                pnlChiTietBan.Visible = true;

                Label lblTitle = new Label();
                lblTitle.Text = "Chi tiết bàn số " + btn.Text.Split('\n')[0];
                lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblTitle.Dock = DockStyle.Top;
                lblTitle.Height = 30;
                pnlChiTietBan.Controls.Add(lblTitle);

                // DataGridView
                DataGridView dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = chiTiet;
                pnlChiTietBan.Controls.Add(dgv);
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnTim1_Click(object sender, EventArgs e)
        {
            frmThemBan frm = new frmThemBan();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Ban newBan = frm.banmoi;

                var daTonTai = banDAL.GetBanBySoBan(newBan.SoBan);
               if(daTonTai != null)
                {
                    MessageBox.Show("Bàn đã tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (banDAL.AddNewBan(newBan))
                {
                    MessageBox.Show("Thêm bàn thành công!");
                    LoadBan();
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại!");
                }
            }
         }
        private void MoFormChiTietBan(int maBan)
        {
            FormChiTietBan form = new FormChiTietBan(maBan);
            form.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plnBan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
