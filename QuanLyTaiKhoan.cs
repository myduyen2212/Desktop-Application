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
using BLL;
using DTO;

namespace QLBH_MIEU
{
    public partial class QuanLyTaiKhoan : Form
    {
        TaiKhoan_DTO TaiKhoan = new TaiKhoan_DTO();
        TaiKhoan_BLL TKBLL = new TaiKhoan_BLL();

        public QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSTK()
        {
            try
            {
                dgvTK.DataSource = TKBLL.LayDSTK();
                dgvTK.Columns[0].HeaderText = "Mã tài khoản";
                dgvTK.Columns[0].Width = 183;
                dgvTK.Columns[1].HeaderText = "Mã nhân viên";
                dgvTK.Columns[1].Width = 183;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadDSTK();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvTK.DataSource = TKBLL.TimKiem(TuKhoa);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSTK();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TaiKhoan.MaTK = dgvTK.CurrentRow.Cells["MaTK"].Value.ToString();
            TaiKhoan.TenTK = dgvTK.CurrentRow.Cells["TenTK"].Value.ToString();
            TaiKhoan.MaNV = dgvTK.CurrentRow.Cells["MaNV"].Value.ToString();

            if (dgvTK.SelectedRows != null)
            {
                DialogResult ThongBaoXNX;
                ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá tài khoản có mã là " + TaiKhoan.MaTK + " không?", "Thông báo",
                              MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (ThongBaoXNX == DialogResult.OK)
                {
                    if (TKBLL.XoaTaiKhoan(TaiKhoan))
                    {
                        DialogResult ThongBao;
                        ThongBao = MessageBox.Show("Xóa tài khoản thành công", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Xóa tài khoản thất bại", "Thông báo lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadDSTK();
                }
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
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
