using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLBH_MIEU
{
    public partial class DoiMatKhau : Form
    {
        TaiKhoan_DTO TaiKhoan = new TaiKhoan_DTO();
        TaiKhoan_BLL TKBLL = new TaiKhoan_BLL();

        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            TaiKhoan.TenTK = txtTenTK.Text;
            TaiKhoan.MatKhau = txtMKHT.Text;

            DialogResult ThongBaoXNDMK;
            ThongBaoXNDMK = MessageBox.Show("Bạn chắc chắn muốn đổi mật khẩu tài khoản này không?", "Thông báo",
                          MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBaoXNDMK == DialogResult.OK)
            {
                if (TKBLL.DoiMatKhau(TaiKhoan))
                {
                    if (txtMKM.Text != txtMKMNL.Text)
                    {
                        DialogResult ThongBao;
                        ThongBao = MessageBox.Show("Mật khẩu mới nhập lại không chính xác", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        TaiKhoan.MatKhau = txtMKM.Text;
                        TKBLL.DoiMatKhau(TaiKhoan);
                        DialogResult ThongBao;
                        ThongBao = MessageBox.Show("Đổi mật khẩu thành công", "Thông báo",
                                   MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác", "Thông báo",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            dangnhap.Show();
            this.Hide();
        }

        private void pbeyeCloseMK_Click(object sender, EventArgs e)
        {
            txtMKHT.PasswordChar = '\0';
            pbeyeOpenMK.BringToFront();
        }

        private void pbeyeOpenMK_Click(object sender, EventArgs e)
        {
            txtMKHT.PasswordChar = '*';
            pbeyeCloseMK.BringToFront();
        }

        private void pbeyeCloseMKM_Click(object sender, EventArgs e)
        {
            txtMKM.PasswordChar = '\0';
            pbeyeOpenMKM.BringToFront();
        }

        private void pbeyeOpenMKM_Click(object sender, EventArgs e)
        {
            txtMKM.PasswordChar = '*';
            pbeyeCloseMKM.BringToFront();
        }

        private void pbeyeCloseMKMNL_Click(object sender, EventArgs e)
        {
            txtMKMNL.PasswordChar = '\0';
            pbeyeOpenMKMNL.BringToFront();
        }

        private void pbeyeOpenMKMNL_Click(object sender, EventArgs e)
        {
            txtMKMNL.PasswordChar = '*';
            pbeyeCloseMKMNL.BringToFront();
        }
    
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult ThongBao;
            ThongBao = MessageBox.Show("Bạn có chắc chắn muốn thoát ứng dụng không?", "Thông báo",
                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (ThongBao == DialogResult.OK)
                Application.Exit();
        }
    }
}
