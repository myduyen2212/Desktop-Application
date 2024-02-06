using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLBH_MIEU
{
    public partial class QuanLyNhanVien : Form
    {
        NhanVien_DTO NhanVien = new NhanVien_DTO();
        NhanVien_BLL NVBLL = new NhanVien_BLL();
        bool _them;

        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSNV()
        {
            try
            {
                dgvNV.DataSource = NVBLL.LayDSNV();
                dgvNV.Columns[0].HeaderText = "Mã nhân viên";
                dgvNV.Columns[0].Width = 80;
                dgvNV.Columns[1].HeaderText = "Tên nhân viên";
                dgvNV.Columns[1].Width = 80;
                dgvNV.Columns[2].HeaderText = "Giới tính";
                dgvNV.Columns[2].Width = 80;
                dgvNV.Columns[3].HeaderText = "Số điện thoại";
                dgvNV.Columns[3].Width = 80;
                dgvNV.Columns[4].HeaderText = "Ngày sinh";
                dgvNV.Columns[4].Width = 80;
                dgvNV.Columns[5].HeaderText = "Email";
                dgvNV.Columns[5].Width = 120;
                dgvNV.Columns[6].HeaderText = "Địa chỉ";
                dgvNV.Columns[6].Width = 120;
                dgvNV.Columns[7].HeaderText = "Chức vụ";
                dgvNV.Columns[7].Width = 80;
                dgvNV.Columns[8].HeaderText = "Ngày bắt đầu làm việc";
                dgvNV.Columns[8].Width = 80;
                dgvNV.Columns[9].HeaderText = "Mức lương";
                dgvNV.Columns[9].Width = 80;
                dgvNV.Columns[10].HeaderText = "Bảo hiểm y tế";
                dgvNV.Columns[10].Width = 80;
                dgvNV.Columns[11].HeaderText = "Trình độ học vấn";
                dgvNV.Columns[11].Width = 80;
                dgvNV.Columns[12].HeaderText = "Mã chi nhánh";
                dgvNV.Columns[12].Width = 80;

            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadCN()
        {
            DataTable dtcn = new DataTable();
            dtcn = NVBLL.LayDSCN();
            cmbCN.DataSource = dtcn;
            cmbCN.DisplayMember = "MaCN";
            cmbCN.ValueMember = "MaCN";

            cmbLocCN.DataSource = dtcn;
            cmbLocCN.DisplayMember = "TenCN";
            cmbLocCN.ValueMember = "MaCN";
        }
                
        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadDSNV();
            LoadCN();
            _them = false;
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSNV();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvNV.DataSource = NVBLL.TimKiem(TuKhoa);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoaLoc = cmbLocCN.SelectedValue.ToString();
                dgvNV.DataSource = NVBLL.LocCN(TuKhoaLoc);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbReset_Click(object sender, EventArgs e)
        {
            LoadDSNV();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnThem.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSua.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();
            btnXoa.BackColor = Color.FromArgb(255, 192, 192);

            txtTenNV.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtChucVu.Enabled = false;
            dtpNgayBDLV.Enabled = false;
            txtMucLuong.Enabled = false;
            txtBHYT.Enabled = false;
            txtTDHV.Enabled = false;
            cmbCN.Enabled = false;

            dgvNV.Enabled = true;
        }

        private void dgvNV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNV.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGioiTinh.Text = dgvNV.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSDT.Text = dgvNV.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpNgaySinh.Text = dgvNV.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtEmail.Text = dgvNV.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[e.RowIndex].Cells[7].Value.ToString();
            dtpNgayBDLV.Text = dgvNV.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtMucLuong.Text = dgvNV.Rows[e.RowIndex].Cells[9].Value.ToString();

            CultureInfo culture = new CultureInfo("vi-VN");
            txtMucLuong.Text = float.Parse(txtMucLuong.Text).ToString("c", culture);
            
            txtBHYT.Text = dgvNV.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtTDHV.Text = dgvNV.Rows[e.RowIndex].Cells[11].Value.ToString();
            cmbCN.SelectedValue = dgvNV.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvNV.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtGioiTinh.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Text = "3000-12-22";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtChucVu.Text = "";
            dtpNgayBDLV.Text = "2000-12-22";
            txtMucLuong.Text = "";
            txtBHYT.Text = "";
            txtTDHV.Text = "";
            cmbCN.SelectedValue = "MIEU01";

            txtTenNV.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            txtChucVu.Enabled = true;
            dtpNgayBDLV.Enabled = true;
            txtMucLuong.Enabled = true;
            txtBHYT.Enabled = true;
            txtTDHV.Enabled = true;
            cmbCN.Enabled = true;

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

            txtTenNV.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtEmail.Enabled = true;
            txtDiaChi.Enabled = true;
            txtChucVu.Enabled = true;
            dtpNgayBDLV.Enabled = true;
            txtMucLuong.Enabled = true;
            txtBHYT.Enabled = true;
            txtTDHV.Enabled = true;
            cmbCN.Enabled = true;

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

            NhanVien.MaNV = txtMaNV.Text;
            NhanVien.TenNV = txtTenNV.Text;
            NhanVien.GioiTinh = txtGioiTinh.Text;
            NhanVien.SDT = txtSDT.Text;
            NhanVien.NgaySinh = dtpNgaySinh.Value;
            NhanVien.Email = txtEmail.Text;
            NhanVien.DiaChi = txtDiaChi.Text;
            NhanVien.ChucVu = txtChucVu.Text;
            NhanVien.NgayBDLamViec = dtpNgayBDLV.Value;

            float mucLuong = float.Parse(txtMucLuong.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            NhanVien.MucLuong = mucLuong;

            NhanVien.BHYT = txtBHYT.Text;
            NhanVien.TrinhDoHocVan = txtTDHV.Text;
            NhanVien.MaCN = cmbCN.SelectedValue.ToString();

            if (NVBLL.CheckXoaHD(NhanVien) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa nhân viên này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (NVBLL.CheckXoaPHT(NhanVien) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Không được xóa nhân viên này!", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dgvNV.SelectedRows != null)
                    {
                        DialogResult ThongBaoXNX;
                        ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá nhân viên có mã là " + NhanVien.MaNV + " không?", "Thông báo",
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (ThongBaoXNX == DialogResult.OK)
                        {
                            if (NVBLL.XoaNV(NhanVien))
                            {
                                DialogResult ThongBao;
                                ThongBao = MessageBox.Show("Xóa nhân viên thành công", "Thông báo",
                                              MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Xóa nhân viên thất bại", "Thông báo lỗi",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadDSNV();
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
                if (NVBLL.CheckThem(NhanVien) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Nhân viên này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaNV = NVBLL.TaoSTTMaNV();
                    NhanVien.MaNV = txtMaNV.Text;
                    if (STTMaNV < 10)
                    {
                        NhanVien.MaNV = "NV0" + STTMaNV.ToString();
                    }
                    else
                    {
                        NhanVien.MaNV = "NV" + STTMaNV.ToString();
                    }

                    NVBLL.ThemNV(NhanVien);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm nhân viên thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {                
                NVBLL.SuaNV(NhanVien);
                DialogResult ThongBao;
                ThongBao = MessageBox.Show("Sửa nhân viên thành công", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanVien.MaNV = txtMaNV.Text;
            NhanVien.TenNV = txtTenNV.Text;
            NhanVien.GioiTinh = txtGioiTinh.Text;
            NhanVien.SDT = txtSDT.Text;
            NhanVien.NgaySinh = dtpNgaySinh.Value;
            NhanVien.Email = txtEmail.Text;
            NhanVien.DiaChi = txtDiaChi.Text;
            NhanVien.ChucVu = txtChucVu.Text;
            NhanVien.NgayBDLamViec = dtpNgayBDLV.Value;
            NhanVien.BHYT = txtBHYT.Text;
            NhanVien.TrinhDoHocVan = txtTDHV.Text;
            NhanVien.MaCN = cmbCN.SelectedValue.ToString();

            if (txtMucLuong.Text == "")
            {
                NhanVien.MucLuong = 0;
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin nhân viên không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (NhanVien.TenNV == "" || NhanVien.GioiTinh == "" || NhanVien.SDT == "" || NhanVien.NgaySinh == Convert.ToDateTime("3000-12-22") || NhanVien.Email == "" || NhanVien.DiaChi == "" || NhanVien.ChucVu == "" || NhanVien.NgayBDLamViec == Convert.ToDateTime("2000-12-22") || NhanVien.BHYT == "" || NhanVien.TrinhDoHocVan == "" || NhanVien.MaCN == "")
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Thông tin nhân viên không được bỏ trống", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NhanVien.TenNV.Length > 50)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Tên nhân viên không đúng định dạng", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (NhanVien.GioiTinh.Length > 3)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Giới tính nhân viên không đúng định dạng", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (NhanVien.DiaChi.Length > 100)
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Địa chỉ của nhân viên không đúng định dạng", "Thông báo lỗi",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (NhanVien.Email.Length > 100)
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Email nhân viên không đúng định dạng", "Thông báo lỗi",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (NhanVien.Email != "")
                                    {
                                        if (NhanVien.Email.EndsWith("@gmail.com") == false)
                                        {
                                            DialogResult ThongBaoLoi;
                                            ThongBaoLoi = MessageBox.Show("Email nhân viên không đúng định dạng", "Thông báo lỗi",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if (NhanVien.SDT.Length != 10)
                                            {
                                                DialogResult ThongBaoLoi;
                                                ThongBaoLoi = MessageBox.Show("Số điện thoại của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                int intValue = 0;
                                                if (int.TryParse(NhanVien.SDT, out intValue) == false)
                                                {
                                                    DialogResult ThongBaoLoi;
                                                    ThongBaoLoi = MessageBox.Show("Số điện thoại của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    if (NhanVien.ChucVu.Length > 30)
                                                    {
                                                        DialogResult ThongBaoLoi;
                                                        ThongBaoLoi = MessageBox.Show("Chức vụ của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                    else
                                                    {
                                                        if (NhanVien.BHYT.Length != 15)
                                                        {
                                                            DialogResult ThongBaoLoi;
                                                            ThongBaoLoi = MessageBox.Show("Bảo hiểm y tế của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                        else
                                                        {
                                                            float floatValueBHYT = 0;
                                                            if (float.TryParse(NhanVien.BHYT, out floatValueBHYT) == false)
                                                            {
                                                                DialogResult ThongBaoLoi;
                                                                ThongBaoLoi = MessageBox.Show("Bảo hiểm y tế của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            }
                                                            else
                                                            {
                                                                if (NhanVien.TrinhDoHocVan.Length > 20)
                                                                {
                                                                    DialogResult ThongBaoLoi;
                                                                    ThongBaoLoi = MessageBox.Show("Trình độ học vấn của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                }
                                                                else
                                                                {
                                                                    if (_them == false)
                                                                    {
                                                                        float mucLuong = float.Parse(txtMucLuong.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                                        txtMucLuong.Text = mucLuong.ToString();
                                                                    }

                                                                    float floatValueML = 0;
                                                                    if (float.TryParse(txtMucLuong.Text, out floatValueML) == false)
                                                                    {
                                                                        DialogResult ThongBaoLoi;
                                                                        ThongBaoLoi = MessageBox.Show("Mức lương của nhân viên không đúng định dạng", "Thông báo lỗi",
                                                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (_them == true)
                                                                        {
                                                                            if (DateTime.Now.Year - NhanVien.NgaySinh.Year < 18)
                                                                            {
                                                                                DialogResult ThongBaoLoi;
                                                                                ThongBaoLoi = MessageBox.Show("Ngày sinh của nhân viên không hợp lệ", "Thông báo lỗi",
                                                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (NhanVien.NgayBDLamViec < NhanVien.NgaySinh || NhanVien.NgayBDLamViec < DateTime.Now)
                                                                                {
                                                                                    DialogResult ThongBaoLoi;
                                                                                    ThongBaoLoi = MessageBox.Show("Ngày bắt đầu làm việc của nhân viên không hợp lệ", "Thông báo lỗi",
                                                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                }
                                                                                else
                                                                                {
                                                                                    float mucLuong = float.Parse(txtMucLuong.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                                                    NhanVien.MucLuong = mucLuong;

                                                                                    txtTenNV.Enabled = false;
                                                                                    txtGioiTinh.Enabled = false;
                                                                                    txtSDT.Enabled = false;
                                                                                    dtpNgaySinh.Enabled = false;
                                                                                    txtEmail.Enabled = false;
                                                                                    txtDiaChi.Enabled = false;
                                                                                    txtChucVu.Enabled = false;
                                                                                    dtpNgayBDLV.Enabled = false;
                                                                                    txtMucLuong.Enabled = false;
                                                                                    txtBHYT.Enabled = false;
                                                                                    txtTDHV.Enabled = false;

                                                                                    dgvNV.Enabled = true;

                                                                                    SaveData();
                                                                                    LoadDSNV();

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
                                                                        else
                                                                        {
                                                                            if (DateTime.Now.Year - NhanVien.NgaySinh.Year < 18)
                                                                            {
                                                                                DialogResult ThongBaoLoi;
                                                                                ThongBaoLoi = MessageBox.Show("Ngày sinh của nhân viên không hợp lệ", "Thông báo lỗi",
                                                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (NhanVien.NgayBDLamViec < NhanVien.NgaySinh)
                                                                                {
                                                                                    DialogResult ThongBaoLoi;
                                                                                    ThongBaoLoi = MessageBox.Show("Ngày bắt đầu làm việc của nhân viên không hợp lệ", "Thông báo lỗi",
                                                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                                }
                                                                                else
                                                                                {
                                                                                    NhanVien.MucLuong = float.Parse(txtMucLuong.Text);

                                                                                    txtTenNV.Enabled = false;
                                                                                    txtGioiTinh.Enabled = false;
                                                                                    txtSDT.Enabled = false;
                                                                                    dtpNgaySinh.Enabled = false;
                                                                                    txtEmail.Enabled = false;
                                                                                    txtDiaChi.Enabled = false;
                                                                                    txtChucVu.Enabled = false;
                                                                                    dtpNgayBDLV.Enabled = false;
                                                                                    txtMucLuong.Enabled = false;
                                                                                    txtBHYT.Enabled = false;
                                                                                    txtTDHV.Enabled = false;

                                                                                    dgvNV.Enabled = true;

                                                                                    SaveData();
                                                                                    LoadDSNV();

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
            txtTenNV.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtSDT.Enabled = false;
            dtpNgaySinh.Enabled = false;
            txtEmail.Enabled = false;
            txtDiaChi.Enabled = false;
            txtChucVu.Enabled = false;
            dtpNgayBDLV.Enabled = false;
            txtMucLuong.Enabled = false;
            txtBHYT.Enabled = false;
            txtTDHV.Enabled = false;
            cmbCN.Enabled = false;
            
            dgvNV.Enabled = true;

            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtGioiTinh.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Text = "3000-12-22";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtChucVu.Text = "";
            dtpNgayBDLV.Text = "2000-12-22";
            txtMucLuong.Text = "";
            txtBHYT.Text = "";
            txtTDHV.Text = "";
            cmbCN.SelectedValue = "MIEU01";

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

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count == 0) return;
            vitri = 0;

            txtMaNV.Text = dgvNV.Rows[vitri].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[vitri].Cells["TenNV"].Value.ToString();
            txtGioiTinh.Text = dgvNV.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvNV.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvNV.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtEmail.Text = dgvNV.Rows[vitri].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[vitri].Cells["ChucVu"].Value.ToString();
            dtpNgayBDLV.Text = dgvNV.Rows[vitri].Cells["NgayBDLamViec"].Value.ToString();
            txtMucLuong.Text = dgvNV.Rows[vitri].Cells["MucLuong"].Value.ToString();
            txtBHYT.Text = dgvNV.Rows[vitri].Cells["BHYT"].Value.ToString();
            txtTDHV.Text = dgvNV.Rows[vitri].Cells["TrinhDoHocVan"].Value.ToString();
            cmbCN.SelectedValue = dgvNV.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count == 0) return;
            vitri = dgvNV.Rows.Count - 2;

            txtMaNV.Text = dgvNV.Rows[vitri].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[vitri].Cells["TenNV"].Value.ToString();
            txtGioiTinh.Text = dgvNV.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvNV.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvNV.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtEmail.Text = dgvNV.Rows[vitri].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[vitri].Cells["ChucVu"].Value.ToString();
            dtpNgayBDLV.Text = dgvNV.Rows[vitri].Cells["NgayBDLamViec"].Value.ToString();
            txtMucLuong.Text = dgvNV.Rows[vitri].Cells["MucLuong"].Value.ToString();
            txtBHYT.Text = dgvNV.Rows[vitri].Cells["BHYT"].Value.ToString();
            txtTDHV.Text = dgvNV.Rows[vitri].Cells["TrinhDoHocVan"].Value.ToString();
            cmbCN.SelectedValue = dgvNV.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvNV.Rows.Count - 2;

            txtMaNV.Text = dgvNV.Rows[vitri].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[vitri].Cells["TenNV"].Value.ToString();
            txtGioiTinh.Text = dgvNV.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvNV.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvNV.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtEmail.Text = dgvNV.Rows[vitri].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[vitri].Cells["ChucVu"].Value.ToString();
            dtpNgayBDLV.Text = dgvNV.Rows[vitri].Cells["NgayBDLamViec"].Value.ToString();
            txtMucLuong.Text = dgvNV.Rows[vitri].Cells["MucLuong"].Value.ToString();
            txtBHYT.Text = dgvNV.Rows[vitri].Cells["BHYT"].Value.ToString();
            txtTDHV.Text = dgvNV.Rows[vitri].Cells["TrinhDoHocVan"].Value.ToString();
            cmbCN.SelectedValue = dgvNV.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvNV.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvNV.Rows.Count - 2) vitri = 0;

            txtMaNV.Text = dgvNV.Rows[vitri].Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNV.Rows[vitri].Cells["TenNV"].Value.ToString();
            txtGioiTinh.Text = dgvNV.Rows[vitri].Cells["GioiTinh"].Value.ToString();
            txtSDT.Text = dgvNV.Rows[vitri].Cells["SDT"].Value.ToString();
            dtpNgaySinh.Text = dgvNV.Rows[vitri].Cells["NgaySinh"].Value.ToString();
            txtEmail.Text = dgvNV.Rows[vitri].Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNV.Rows[vitri].Cells["DiaChi"].Value.ToString();
            txtChucVu.Text = dgvNV.Rows[vitri].Cells["ChucVu"].Value.ToString();
            dtpNgayBDLV.Text = dgvNV.Rows[vitri].Cells["NgayBDLamViec"].Value.ToString();
            txtMucLuong.Text = dgvNV.Rows[vitri].Cells["MucLuong"].Value.ToString();
            txtBHYT.Text = dgvNV.Rows[vitri].Cells["BHYT"].Value.ToString();
            txtTDHV.Text = dgvNV.Rows[vitri].Cells["TrinhDoHocVan"].Value.ToString();
            cmbCN.SelectedValue = dgvNV.Rows[vitri].Cells["MaCN"].Value.ToString();
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
