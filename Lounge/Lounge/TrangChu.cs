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
                plnBan.Controls.Add(btn);

                x += 130; // khoảng cách giữa các button ngang
                count++;
                if (count % 4 == 0) // mỗi dòng 4 bàn
                {
                    x = 10;
                    y += 90;
                }
                btn.Click += (s, e) =>
                {
                    int maBan = (int)((Button)s).Tag;
                    MessageBox.Show($"Bấm vào bàn có mã: {maBan}");
                };

            }
        }


        private void plnBan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
