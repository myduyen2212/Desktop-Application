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
    public partial class QuanLyNhaCungCap : Form
    {
        NhaCungCap_DTO NhaCungCap = new NhaCungCap_DTO();
        NhaCungCap_BLL NCCBLL = new NhaCungCap_BLL();
        bool _them;

        public QuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSNCC()
        {
            try
            {
                dgvNCC.DataSource = NCCBLL.LayDSNCC();
                dgvNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
                dgvNCC.Columns[0].Width = 77;
                dgvNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
                dgvNCC.Columns[1].Width = 80;
                dgvNCC.Columns[2].HeaderText = "Số điện thoại";
                dgvNCC.Columns[2].Width = 100;
                dgvNCC.Columns[3].HeaderText = "Địa chỉ";
                dgvNCC.Columns[3].Width = 270;
                dgvNCC.Columns[4].HeaderText = "Email";
                dgvNCC.Columns[4].Width = 131;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void QuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDSNCC();
            _them = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvNCC.DataSource = NCCBLL.TimKiem(TuKhoa);
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
                LoadDSNCC();
            }
        }

        private void dgvNCC_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvNCC.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();    
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";

            txtTenNCC.Enabled = true;
            txtSDT.Enabled = true;
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

            txtTenNCC.Enabled = true;
            txtSDT.Enabled = true;
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

            NhaCungCap.MaNCC = txtMaNCC.Text;
            NhaCungCap.TenNCC = txtTenNCC.Text;
            NhaCungCap.SDT = txtSDT.Text;
            NhaCungCap.DiaChi = txtDiaChi.Text;
            NhaCungCap.Email = txtEmail.Text;

            if (NCCBLL.CheckXoa(NhaCungCap) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa nhà cung cấp này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvNCC.SelectedRows != null)
                {
                    DialogResult ThongBaoXNX;
                    ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá nhà cung cấp có mã là " + NhaCungCap.MaNCC + " không?", "Thông báo",
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ThongBaoXNX == DialogResult.OK)
                    {
                        if (NCCBLL.XoaNCC(NhaCungCap))
                        {
                            DialogResult ThongBao;
                            ThongBao = MessageBox.Show("Xóa nhà cung cấp thành công", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Xóa nhà cung cấp thất bại", "Thông báo lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadDSNCC();
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
                if (NCCBLL.CheckThem(NhaCungCap) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Nhà cung cấp này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaNCC = NCCBLL.TaoSTTMaNCC();
                    NhaCungCap.MaNCC = txtMaNCC.Text;
                    if (STTMaNCC < 10)
                    {
                        NhaCungCap.MaNCC = "PS0" + STTMaNCC.ToString();
                    }
                    else
                    {
                        NhaCungCap.MaNCC = "PS" + STTMaNCC.ToString();
                    }

                    NCCBLL.ThemNCC(NhaCungCap);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {                
                if (NCCBLL.SuaNCC(NhaCungCap))
                {
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Sửa nhà cung cấp thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Sửa nhà cung cấp thất bại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaCungCap.MaNCC = txtMaNCC.Text;
            NhaCungCap.TenNCC = txtTenNCC.Text;
            NhaCungCap.SDT = txtSDT.Text;
            NhaCungCap.DiaChi = txtDiaChi.Text;
            NhaCungCap.Email = txtEmail.Text;

            if (NhaCungCap.TenNCC == "" || NhaCungCap.DiaChi == "" || NhaCungCap.Email == "" || NhaCungCap.SDT == "")
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin nhà cung cấp không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (NhaCungCap.TenNCC.Length > 50)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Tên nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NhaCungCap.DiaChi.Length > 100)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Địa chỉ nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (NhaCungCap.Email.Length > 100)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Email nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (NhaCungCap.Email.EndsWith("@gmail.com") == false)
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Email nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (NhaCungCap.SDT.Length != 10)
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Số điện thoại của nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    int intValue;
                                    if (int.TryParse(NhaCungCap.SDT, out intValue) == false)
                                    {
                                        DialogResult ThongBaoLoi;
                                        ThongBaoLoi = MessageBox.Show("Số điện thoại của nhà cung cấp không đúng định dạng", "Thông báo lỗi",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        txtTenNCC.Enabled = false;
                                        txtSDT.Enabled = false;
                                        txtDiaChi.Enabled = false;
                                        txtEmail.Enabled = false;

                                        dgvNCC.Enabled = true;

                                        SaveData();
                                        LoadDSNCC();

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenNCC.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;

            dgvNCC.Enabled = true;

            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtSDT.Text = "";
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

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvNCC.Rows.Count == 0) return;
            vitri = 0;

            txtMaNCC.Text = dgvNCC.Rows[vitri].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[vitri].Cells["TenNCC"].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[vitri].Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvNCC.Rows.Count == 0) return;
            vitri = dgvNCC.Rows.Count - 2;

            txtMaNCC.Text = dgvNCC.Rows[vitri].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[vitri].Cells["TenNCC"].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[vitri].Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvNCC.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvNCC.Rows.Count - 2;

            txtMaNCC.Text = dgvNCC.Rows[vitri].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[vitri].Cells["TenNCC"].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[vitri].Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[vitri].Cells["Email"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvNCC.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvNCC.Rows.Count - 2) vitri = 0;

            txtMaNCC.Text = dgvNCC.Rows[vitri].Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgvNCC.Rows[vitri].Cells["TenNCC"].Value.ToString();
            txtSDT.Text = dgvNCC.Rows[vitri].Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvNCC.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dgvNCC.Rows[vitri].Cells["Email"].Value.ToString();
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
