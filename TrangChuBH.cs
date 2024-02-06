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
    public partial class TrangChuBH : Form
    {
        public TrangChuBH()
        {
            InitializeComponent();
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
