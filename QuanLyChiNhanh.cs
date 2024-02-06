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
    public partial class QuanLyChiNhanh : Form
    {
        ChiNhanh_DTO ChiNhanh = new ChiNhanh_DTO();
        ChiNhanh_BLL CNBLL = new ChiNhanh_BLL();
        bool _them;

        public QuanLyChiNhanh()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSCN()
        {
            try
            {
                dgvCN.DataSource = CNBLL.LayDSCN();
                dgvCN.Columns[0].HeaderText = "Mã chi nhánh";
                dgvCN.Columns[0].Width = 200;
                dgvCN.Columns[1].HeaderText = "Tên chi nhánh";
                dgvCN.Columns[1].Width = 200;
                dgvCN.Columns[2].HeaderText = "Địa chỉ";
                dgvCN.Columns[2].Width = 220;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void QuanLyChiNhanh_Load(object sender, EventArgs e)
        {
            LoadDSCN();
            _them = false;
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSCN();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvCN.DataSource = CNBLL.TimKiem(TuKhoa);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCN.Text = dgvCN.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenCN.Text = dgvCN.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvCN.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvCN.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtDiaChi.Text = "";

            txtTenCN.Enabled = true;
            txtDiaChi.Enabled = true;

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

            txtTenCN.Enabled = true;
            txtDiaChi.Enabled = true;

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

            ChiNhanh.MaCN = txtMaCN.Text;
            ChiNhanh.TenCN = txtTenCN.Text;
            ChiNhanh.DiaChi = txtDiaChi.Text;

            if (CNBLL.CheckXoaNV(ChiNhanh) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa chi nhánh này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (CNBLL.CheckXoaTK(ChiNhanh) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Không được xóa chi nhánh này!", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dgvCN.SelectedRows != null)
                    {
                        DialogResult ThongBaoXNX;
                        ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá chi nhánh có mã là " + ChiNhanh.MaCN + " không?", "Thông báo",
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (ThongBaoXNX == DialogResult.OK)
                        {
                            if (CNBLL.XoaCN(ChiNhanh))
                            {
                                DialogResult ThongBao;
                                ThongBao = MessageBox.Show("Xóa chi nhánh thành công", "Thông báo",
                                              MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Xóa chi nhánh thất bại", "Thông báo lỗi",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadDSCN();
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
                if (CNBLL.CheckThem(ChiNhanh) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Chi nhánh này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaCN = CNBLL.TaoSTTMaCN();
                    ChiNhanh.MaCN = txtMaCN.Text;
                    if (STTMaCN < 10)
                    {
                        ChiNhanh.MaCN = "MIEU0" + STTMaCN.ToString();
                    }
                    else
                    {
                        ChiNhanh.MaCN = "MIEU" + STTMaCN.ToString();
                    }

                    CNBLL.ThemCN(ChiNhanh);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm chi nhánh thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                CNBLL.SuaCN(ChiNhanh);
                DialogResult ThongBao;
                ThongBao = MessageBox.Show("Sửa chi nhánh thành công", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {            
            ChiNhanh.MaCN = txtMaCN.Text;
            ChiNhanh.TenCN = txtTenCN.Text;
            ChiNhanh.DiaChi = txtDiaChi.Text;

            if (ChiNhanh.TenCN == "" || ChiNhanh.DiaChi == "")
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin của chi nhánh không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ChiNhanh.TenCN.Length > 50)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Tên chi nhánh không đúng định dạng", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (ChiNhanh.DiaChi.Length > 100)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Địa chỉ chi nhánh không đúng định dạng", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        txtTenCN.Enabled = false;
                        txtDiaChi.Enabled = false;

                        dgvCN.Enabled = true;

                        SaveData();
                        LoadDSCN();

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenCN.Enabled = false;
            txtDiaChi.Enabled = false;

            dgvCN.Enabled = true;

            txtMaCN.Text = "";
            txtTenCN.Text = "";
            txtDiaChi.Text = "";

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

        private void dgvCN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvCN.Rows.Count == 0) return;
            vitri = 0;

            txtMaCN.Text = dgvCN.Rows[vitri].Cells["MaCN"].Value.ToString();
            txtTenCN.Text = dgvCN.Rows[vitri].Cells["TenCN"].Value.ToString();
            txtDiaChi.Text = dgvCN.Rows[vitri].Cells["DiaChi"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvCN.Rows.Count == 0) return;
            vitri = dgvCN.Rows.Count - 2;

            txtMaCN.Text = dgvCN.Rows[vitri].Cells["MaCN"].Value.ToString();
            txtTenCN.Text = dgvCN.Rows[vitri].Cells["TenCN"].Value.ToString();
            txtDiaChi.Text = dgvCN.Rows[vitri].Cells["DiaChi"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvCN.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvCN.Rows.Count - 2;

            txtMaCN.Text = dgvCN.Rows[vitri].Cells["MaCN"].Value.ToString();
            txtTenCN.Text = dgvCN.Rows[vitri].Cells["TenCN"].Value.ToString();
            txtDiaChi.Text = dgvCN.Rows[vitri].Cells["DiaChi"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvCN.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvCN.Rows.Count - 2) vitri = 0;

            txtMaCN.Text = dgvCN.Rows[vitri].Cells["MaCN"].Value.ToString();
            txtTenCN.Text = dgvCN.Rows[vitri].Cells["TenCN"].Value.ToString();
            txtDiaChi.Text = dgvCN.Rows[vitri].Cells["DiaChi"].Value.ToString();
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
