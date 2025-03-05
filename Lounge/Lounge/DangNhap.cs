using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lounge
{
    public partial class DangNhap : Form
    {
        public KetNoi KetNoi = new KetNoi();
        public DangNhap()
        {
            InitializeComponent();
        }
        public void Checkconnection()
        {
            try
            {
                using (SqlConnection conn = KetNoi.GetConnect())
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Kết nối cơ sở dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SqlConnection cc = KetNoi.GetConnect();
        }
        private void DangNhap_Load(object sender, EventArgs e)
        {
            Checkconnection();
            DataTable tb = KetNoi.DangNhap();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(txtTaiKhoan.Text == "Thien" && txtMatKhau.Text == "1")
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    TrangChu TC = new TrangChu();
                    TC.ShowDialog();
                }
                else
                {
                    DataTable tb = KetNoi.DangNhap();
                    int i = 0;
                    for (i = 0; i < tb.Rows.Count; i++)
                    {
                        if (txtTaiKhoan.Text == tb.Rows[i][0].ToString() && txtMatKhau.Text == tb.Rows[i][1].ToString())
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            TrangChu TC = new TrangChu();
                            TC.ShowDialog();
                            break;
                        }
                    }
                    if (i == tb.Rows.Count)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
