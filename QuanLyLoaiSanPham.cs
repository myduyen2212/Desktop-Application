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
    public partial class QuanLyLoaiSanPham : Form
    {
        LoaiSanPham_DTO LoaiSanPham = new LoaiSanPham_DTO();
        LoaiSanPham_BLL LSPBLL = new LoaiSanPham_BLL();
        bool _them;

        public QuanLyLoaiSanPham()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSLSP()
        {
            try
            {
                dgvLSP.DataSource = LSPBLL.LayDSLSP();
                dgvLSP.Columns[0].HeaderText = "Mã loại sản phẩm";
                dgvLSP.Columns[0].Width = 200;
                dgvLSP.Columns[1].HeaderText = "Tên loại sản phẩm";
                dgvLSP.Columns[1].Width = 200;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void QuanLyLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadDSLSP();
            _them = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvLSP.DataSource = LSPBLL.TimKiem(TuKhoa);
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
                LoadDSLSP();
            }
        }

        private void dgvLSP_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLSP.Text = dgvLSP.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvLSP.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaLSP.Text = "";
            txtTenLSP.Text = "";

            txtTenLSP.Enabled = true;

            _them = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnXoa.Enabled = false;

            btnThem.BackColor = Color.LightGray;
            pbThemB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtTenLSP.Enabled = true;

            _them = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;

            btnThem.BackColor = Color.LightGray;
            pbThemB.BringToFront();
            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();

            LoaiSanPham.MaLSP = txtMaLSP.Text;
            LoaiSanPham.TenLSP = txtTenLSP.Text;

            if (LSPBLL.CheckXoa(LoaiSanPham) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa loại sản phẩm này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvLSP.SelectedRows != null)
                {
                    DialogResult ThongBaoXNX;
                    ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá loại sản phẩm có mã là " + LoaiSanPham.MaLSP + " không?", "Thông báo",
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ThongBaoXNX == DialogResult.OK)
                    {
                        if (LSPBLL.XoaLSP(LoaiSanPham))
                        {
                            DialogResult ThongBao;
                            ThongBao = MessageBox.Show("Xóa loại sản phẩm thành công", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Xóa loại sản phẩm thất bại", "Thông báo lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadDSLSP();
                    }
                }
            }

            btnThem.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSua.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();
            btnXoa.BackColor = Color.FromArgb(255, 192, 192);
            pbXoa.BringToFront();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        public void SaveData()
        {
            if (_them)
            {
                if (LSPBLL.CheckThem(LoaiSanPham) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Loại sản phẩm này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaLSP = LSPBLL.TaoSTTMaLSP();
                    LoaiSanPham.MaLSP = txtMaLSP.Text;
                    if (STTMaLSP < 10)
                    {
                        LoaiSanPham.MaLSP = "LSP0" + STTMaLSP.ToString();
                    }
                    else
                    {
                        LoaiSanPham.MaLSP = "LSP" + STTMaLSP.ToString();
                    }

                    LSPBLL.ThemLSP(LoaiSanPham);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm loại sản phẩm thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {                
                LSPBLL.SuaLSP(LoaiSanPham);
                DialogResult ThongBao;
                ThongBao = MessageBox.Show("Sửa loại sản phẩm thành công", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LoaiSanPham.MaLSP = txtMaLSP.Text;
            LoaiSanPham.TenLSP = txtTenLSP.Text;

            if (LoaiSanPham.TenLSP == "")
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (LoaiSanPham.TenLSP.Length > 50)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Tên loại sản phẩm không đúng định dạng", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    txtMaLSP.Enabled = false;
                    txtTenLSP.Enabled = false;

                    dgvLSP.Enabled = true;

                    SaveData();
                    LoadDSLSP();

                    _them = false;

                    btnThem.BackColor = Color.Gold;
                    pbThem.BringToFront();
                    btnSua.BackColor = Color.LightSkyBlue;
                    pbSua.BringToFront();
                    btnXoa.BackColor = Color.FromArgb(255, 192, 192);
                    pbXoa.BringToFront();

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenLSP.Enabled = false;

            dgvLSP.Enabled = true;

            txtMaLSP.Text = "";
            txtTenLSP.Text = "";

            btnThem.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSua.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();
            btnXoa.BackColor = Color.FromArgb(255, 192, 192);
            pbXoa.BringToFront();

            _them = false;

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        int vitri = -1;

        private void dgvLSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvLSP.Rows.Count == 0) return;
            vitri = 0;

            txtMaLSP.Text = dgvLSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[vitri].Cells["TenLSP"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvLSP.Rows.Count == 0) return;
            vitri = dgvLSP.Rows.Count - 2;

            txtMaLSP.Text = dgvLSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[vitri].Cells["TenLSP"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvLSP.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvLSP.Rows.Count - 2;

            txtMaLSP.Text = dgvLSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[vitri].Cells["TenLSP"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvLSP.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvLSP.Rows.Count - 2) vitri = 0;

            txtMaLSP.Text = dgvLSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            txtTenLSP.Text = dgvLSP.Rows[vitri].Cells["TenLSP"].Value.ToString();
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
