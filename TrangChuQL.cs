using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_MIEU
{
    public partial class TrangChuQL : Form
    {
        public TrangChuQL()
        {
            InitializeComponent();
        }
        
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan QLTK = new QuanLyTaiKhoan();
            QLTK.Show();
            this.Hide();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            QuanLyNhaCungCap QLNCC = new QuanLyNhaCungCap();
            QLNCC.Show();
            this.Hide();
        }

        private void btnLSP_Click(object sender, EventArgs e)
        {
            QuanLyLoaiSanPham QLLSP = new QuanLyLoaiSanPham();
            QLLSP.Show();
            this.Hide();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            QuanLySanPham QLSP = new QuanLySanPham();
            QLSP.Show();
            this.Hide();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien QLNV = new QuanLyNhanVien();
            QLNV.Show();
            this.Hide();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang QLKH = new QuanLyKhachHang();
            QLKH.Show();
            this.Hide();
        }

        private void btnCN_Click(object sender, EventArgs e)
        {
            QuanLyChiNhanh QLCN = new QuanLyChiNhanh();
            QLCN.Show();
            this.Hide();
        }

        private void btnCTKM_Click(object sender, EventArgs e)
        {
            QuanLyChuongTrinhKhuyenMai QLCTKM = new QuanLyChuongTrinhKhuyenMai();
            QLCTKM.Show();
            this.Hide();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon QLHD = new QuanLyHoaDon();
            QLHD.Show();
            this.Hide();
        }

        private void btnHT_Click(object sender, EventArgs e)
        {
            QuanLyHoanTra QLHT = new QuanLyHoanTra();
            QLHT.Show();
            this.Hide();
        }
        
        private void btnDX_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.Show();
            this.Hide();

        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            DoiMatKhau DMK = new DoiMatKhau();
            DMK.Show();
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
