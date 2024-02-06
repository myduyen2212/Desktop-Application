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
    public partial class QuanLyKhachHang : Form
    {
        KhachHang_DTO KhachHang = new KhachHang_DTO();
        KhachHang_BLL KHBLL = new KhachHang_BLL();
        bool _them;

        public QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSKH()
        {
            try
            {
                dgvKH.DataSource = KHBLL.LayDSKH();
                dgvKH.Columns[0].HeaderText = "Mã khách hàng";
                dgvKH.Columns[0].Width = 50;
                dgvKH.Columns[1].HeaderText = "Tên khách hàng";
                dgvKH.Columns[1].Width = 80;
                dgvKH.Columns[2].HeaderText = "Giới tính";
                dgvKH.Columns[2].Width = 50;
                dgvKH.Columns[3].HeaderText = "Số điện thoại";
                dgvKH.Columns[3].Width = 60;
                dgvKH.Columns[4].HeaderText = "Ngày sinh";
                dgvKH.Columns[4].Width = 75;
                dgvKH.Columns[5].HeaderText = "Địa chỉ";
                dgvKH.Columns[5].Width = 240;
                dgvKH.Columns[6].HeaderText = "Email";
                dgvKH.Columns[6].Width = 100;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadDSKH();
            _them = false;
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSKH();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvKH.DataSource = KHBLL.TimKiem(TuKhoa);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dgvKH.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvKH.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSDT.Text = dgvKH.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvKH.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvKH.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtEmail.Text = dgvKH.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvKH.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtGioiTinh.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Text = "2023-12-22";
            txtDiaChi.Text = "";
            txtEmail.Text = "";

            txtTenKH.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;

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

            txtTenKH.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;

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

            KhachHang.MaKH = txtMaKH.Text;
            KhachHang.TenKH = txtTenKH.Text;
            KhachHang.GioiTinh = txtGioiTinh.Text;
            KhachHang.SDT = txtSDT.Text;
            KhachHang.NgaySinh = dtpNgaySinh.Value;
            KhachHang.DiaChi = txtDiaChi.Text;
            KhachHang.Email = txtEmail.Text;

            if (KHBLL.CheckXoaHD(KhachHang) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa khách hàng này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (KHBLL.CheckXoaPHT(KhachHang) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Không được xóa khách hàng này!", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dgvKH.SelectedRows != null)
                    {
                        DialogResult ThongBaoXNX;
                        ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá khách hàng có mã là " + KhachHang.MaKH + " không?", "Thông báo",
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (ThongBaoXNX == DialogResult.OK)
                        {
                            if (KHBLL.XoaKH(KhachHang))
                            {
                                DialogResult ThongBao;
                                ThongBao = MessageBox.Show("Xóa khách hàng thành công", "Thông báo",
                                              MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Xóa khách hàng thất bại", "Thông báo lỗi",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadDSKH();
                        }
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
                if (KHBLL.CheckThem(KhachHang) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Khách hàng này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaKH = KHBLL.TaoSTTMaKH();
                    KhachHang.MaKH = txtMaKH.Text;
                    if (STTMaKH < 10)
                    {
                        KhachHang.MaKH = "KH00" + STTMaKH.ToString();
                    }
                    else
                    {
                        if (STTMaKH < 100)
                        {
                            KhachHang.MaKH = "KH0" + STTMaKH.ToString();
                        }
                        else
                        {
                            KhachHang.MaKH = "KH" + STTMaKH.ToString();

                        }
                    }

                    KHBLL.ThemKH(KhachHang);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm khách hàng thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                KHBLL.SuaKH(KhachHang);
                DialogResult ThongBao;
                ThongBao = MessageBox.Show("Sửa khách hàng thành công", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {            
            KhachHang.MaKH = txtMaKH.Text;
            KhachHang.TenKH = txtTenKH.Text;
            KhachHang.GioiTinh = txtGioiTinh.Text;
            KhachHang.SDT = txtSDT.Text;
            if (dtpNgaySinh.Text == "3000-12-22")
            {
                KhachHang.NgaySinh = Convert.ToDateTime("");
            }
            else
            {
                KhachHang.NgaySinh = dtpNgaySinh.Value;
            }
            KhachHang.DiaChi = txtDiaChi.Text;
            KhachHang.Email = txtEmail.Text;

            if (KhachHang.TenKH == "")
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Tên khách hàng không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (KhachHang.TenKH.Length > 50)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Tên khách hàng không đúng định dạng", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (KhachHang.GioiTinh.Length > 3)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Giới tính khách hàng không đúng định dạng", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (KhachHang.DiaChi.Length > 100)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Địa chỉ khách hàng không đúng định dạng", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (KhachHang.Email.Length > 100)
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Email khách hàng không đúng định dạng", "Thông báo lỗi",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (KhachHang.Email != "")
                                {
                                    if (KhachHang.Email.EndsWith("@gmail.com") == false)
                                    {
                                        DialogResult ThongBaoLoi;
                                        ThongBaoLoi = MessageBox.Show("Email khách hàng không đúng định dạng", "Thông báo lỗi",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (KhachHang.SDT.Length != 10)
                                        {
                                            DialogResult ThongBaoLoi;
                                            ThongBaoLoi = MessageBox.Show("Số điện thoại của khách hàng không đúng định dạng", "Thông báo lỗi",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            int intValue = 0;
                                            if (int.TryParse(KhachHang.SDT, out intValue) == false)
                                            {
                                                DialogResult ThongBaoLoi;
                                                ThongBaoLoi = MessageBox.Show("Số điện thoại của khách hàng không đúng định dạng", "Thông báo lỗi",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                txtTenKH.Enabled = false;
                                                txtGioiTinh.Enabled = false;
                                                txtSDT.Enabled = false;
                                                dtpNgaySinh.Enabled = false;
                                                txtDiaChi.Enabled = false;
                                                txtEmail.Enabled = false;

                                                dgvKH.Enabled = true;

                                                SaveData();
                                                LoadDSKH();

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
                                }
                            }
                        }
                    }
                }
            }            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenKH.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;

            dgvKH.Enabled = true;

            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtGioiTinh.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Text = "2023-12-22";
            txtDiaChi.Text = "";
            txtEmail.Text = "";

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

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvKH.Rows.Count == 0) return;
            vitri = 0;

            txtMaKH.Text = dgvKH.Rows[vitri].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[vitri].Cells["TenKH"].Value.ToString();
            txtGioiTinh.Text = dgvKH.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvKH.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dgvKH.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvKH.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvKH.Rows.Count == 0) return;
            vitri = dgvKH.Rows.Count - 2;

            txtMaKH.Text = dgvKH.Rows[vitri].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[vitri].Cells["TenKH"].Value.ToString();
            txtGioiTinh.Text = dgvKH.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvKH.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dgvKH.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvKH.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvKH.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvKH.Rows.Count - 2;

            txtMaKH.Text = dgvKH.Rows[vitri].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[vitri].Cells["TenKH"].Value.ToString();
            txtGioiTinh.Text = dgvKH.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvKH.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dgvKH.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvKH.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvKH.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvKH.Rows.Count - 2) vitri = 0;

            txtMaKH.Text = dgvKH.Rows[vitri].Cells["MaKH"].Value.ToString();
            txtTenKH.Text = dgvKH.Rows[vitri].Cells["TenKH"].Value.ToString();
            txtGioiTinh.Text = dgvKH.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvKH.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvKH.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dgvKH.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvKH.Rows[vitri].Cells["Email"].Value.ToString();
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
