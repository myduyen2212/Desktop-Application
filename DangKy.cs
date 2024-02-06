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
    public partial class DangKy : Form
    {
        TaiKhoan_DTO TaiKhoan = new TaiKhoan_DTO();
        TaiKhoan_BLL TKBLL = new TaiKhoan_BLL();

        public DangKy()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            int STTMaTK = TKBLL.TaoSTTMaTK();
            TaiKhoan.MaNV = txtMaNV.Text;
            if (STTMaTK < 10)
            {
                TaiKhoan.MaTK = "AC0" + STTMaTK.ToString();
            }
            else
            {
                TaiKhoan.MaTK = "AC" + STTMaTK.ToString();
            }
            TaiKhoan.TenTK = txtTenDK.Text;
            TaiKhoan.MatKhau = txtMK.Text;

            if (TKBLL.CheckMaNV(TaiKhoan) == false) 
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Mã nhân viên không tồn tại", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (TKBLL.CheckTaiKhoan(TaiKhoan) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Mã nhân viên này đã có tài khoản", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {                  

                    if (TaiKhoan.MaNV == "" || TaiKhoan.TenTK == "" || TaiKhoan.MatKhau == "" || TaiKhoan.TenTK.Length > 30 || TaiKhoan.MatKhau.Length > 10)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Mã nhân viên, tên tài khoản hoặc mật khẩu không phù hợp", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (TKBLL.CheckDangKy(TaiKhoan) == false)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Tên tài khoản đã tồn tại, vui lòng nhập tên tài khoản khác", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (txtMK.Text != txtMKNL.Text)
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Mật khẩu nhập lại không chính xác", "Thông báo lỗi",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (TKBLL.CheckDangKy(TaiKhoan) == true)
                                {
                                    TKBLL.DangKy(TaiKhoan);
                                    DialogResult ThongBao;
                                    ThongBao = MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo",
                                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                        }
                    }
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
            txtMK.PasswordChar = '\0';
            pbeyeOpenMK.BringToFront();
        }

        private void pbeyeOpenMK_Click(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '*';
            pbeyeCloseMK.BringToFront();
        }

        private void pbeyeCloseMKNL_Click(object sender, EventArgs e)
        {
            txtMKNL.PasswordChar = '\0';
            pbeyeOpenMKNL.BringToFront();
        }

        private void pbeyeOpenMKNL_Click(object sender, EventArgs e)
        {
            txtMKNL.PasswordChar = '*';
            pbeyeCloseMKNL.BringToFront();
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
