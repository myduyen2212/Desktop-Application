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
    public partial class DangNhap : Form
    {
        TaiKhoan_DTO TaiKhoan = new TaiKhoan_DTO();
        TaiKhoan_BLL TKBLL = new TaiKhoan_BLL();
        NhanVien_DTO NhanVien = new NhanVien_DTO();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TaiKhoan.TenTK = txtTenDN.Text;
            TaiKhoan.MatKhau = txtMK.Text;

            if (TaiKhoan.TenTK == "" || TaiKhoan.MatKhau == "" || TaiKhoan.TenTK.Length > 30 || TaiKhoan.MatKhau.Length > 10)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng định dạng", "Thông báo lỗi",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (TKBLL.CheckTTTK(TaiKhoan) == false)
                {
                    if (TKBLL.CheckTenTK(TaiKhoan) == false)
                    {
                        DialogResult ThongBaoLoi1;
                        ThongBaoLoi1 = MessageBox.Show("Tên tài khoản không chính xác", "Thông báo lỗi",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (TKBLL.CheckMK(TaiKhoan) == false)
                        {
                            DialogResult ThongBaoLoi2;
                            ThongBaoLoi2 = MessageBox.Show("Mật khẩu không chính xác", "Thông báo lỗi",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (TKBLL.CheckTenTK(TaiKhoan) == false && TKBLL.CheckMK(TaiKhoan) == false)
                            {
                                DialogResult ThongBaoLoi3;
                                ThongBaoLoi3 = MessageBox.Show("Tài khoản này không tồn tại", "Thông báo lỗi",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }                    
                }
                else
                {
                    DataTable dtCQ = new DataTable();
                    dtCQ = TKBLL.CheckQuyen(TaiKhoan);
                    NhanVien.ChucVu = dtCQ.Rows[0][0].ToString();

                    if (NhanVien.ChucVu == "Quản lý")
                    {
                        TrangChuQL trangchuQL = new TrangChuQL();
                        trangchuQL.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (NhanVien.ChucVu == "Nhân viên bán hàng")
                        {
                            TrangChuBH trangchuBH = new TrangChuBH();
                            trangchuBH.Show();
                            this.Hide();
                        }
                    }                    
                }
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            DangKy dangky = new DangKy();
            dangky.Show();
            this.Hide();
        }

        private void pbeyeClose_Click(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '\0';
            pbeyeOpen.BringToFront();
        }

        private void pbeyeOpen_Click(object sender, EventArgs e)
        {
            txtMK.PasswordChar = '*';
            pbeyeClose.BringToFront();
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
