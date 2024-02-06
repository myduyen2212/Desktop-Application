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
    public partial class QuanLySanPham : Form
    {
        SanPham_DTO SanPham = new SanPham_DTO();
        SanPham_BLL SPBLL = new SanPham_BLL();
        TonKho_DTO TonKho = new TonKho_DTO();
        bool _them;

        public QuanLySanPham()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }

        public void LoadDSSP()
        {
            try
            {
                dgvSP.DataSource = SPBLL.LayDSSP();
                dgvSP.Columns[0].HeaderText = "Chi nhánh";
                dgvSP.Columns[0].Width = 200;
                dgvSP.Columns[1].HeaderText = "Mã sản phẩm";
                dgvSP.Columns[1].Width = 50;
                dgvSP.Columns[2].HeaderText = "Tên sản phẩm";
                dgvSP.Columns[2].Width = 200;
                dgvSP.Columns[3].HeaderText = "Giá vốn";
                dgvSP.Columns[3].Width = 100;
                dgvSP.Columns[4].HeaderText = "Giá bán";
                dgvSP.Columns[4].Width = 100;
                dgvSP.Columns[5].HeaderText = "Đơn vị tính";
                dgvSP.Columns[5].Width = 100;
                dgvSP.Columns[6].HeaderText = "Kích thước sản phẩm";
                dgvSP.Columns[6].Width = 100;
                dgvSP.Columns[7].HeaderText = "Màu sản phẩm";
                dgvSP.Columns[7].Width = 100;
                dgvSP.Columns[8].HeaderText = "Số lượng tồn kho";
                dgvSP.Columns[8].Width = 50;
                dgvSP.Columns[9].HeaderText = "Loại sản phẩm";
                dgvSP.Columns[9].Width = 50;
                dgvSP.Columns[10].HeaderText = "Nhà cung cấp";
                dgvSP.Columns[10].Width = 100;

            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLSP()
        {
            DataTable dtlsp = new DataTable();
            dtlsp = SPBLL.LayDSLSP();
            cmbLSP.DataSource = dtlsp;
            cmbLSP.DisplayMember = "TenLSP";
            cmbLSP.ValueMember = "MaLSP";

            cmbLocLSP.DataSource = dtlsp;
            cmbLocLSP.DisplayMember = "TenLSP";
            cmbLocLSP.ValueMember = "MaLSP";
        }

        public void LoadNCC()
        {
            DataTable dtncc = new DataTable();
            dtncc = SPBLL.LayDSNCC();
            cmbNCC.DataSource = dtncc;
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";

            cmbLocNCC.DataSource = dtncc;
            cmbLocNCC.DisplayMember = "TenNCC";
            cmbLocNCC.ValueMember = "MaNCC";
        }

        public void LoadCN()
        {
            DataTable dtcn = new DataTable();
            dtcn = SPBLL.LayDSCN();
            cmbCN.DataSource = dtcn;
            cmbCN.DisplayMember = "TenCN";
            cmbCN.ValueMember = "MaCN";            
        }

        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            LoadDSSP();
            LoadLSP();
            LoadNCC();
            LoadCN();
            _them = false;
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSSP();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoa = txtTuKhoaTK.Text;
                dgvSP.DataSource = SPBLL.TimKiem(TuKhoa);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLocNCC_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoaLoc = cmbLocNCC.SelectedValue.ToString();
                dgvSP.DataSource = SPBLL.LocNCC(TuKhoaLoc);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnLocLSP_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoaLoc = cmbLSP.SelectedValue.ToString();
                dgvSP.DataSource = SPBLL.LocLSP(TuKhoaLoc);
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
            LoadDSSP();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnThem.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSua.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();
            btnXoa.BackColor = Color.FromArgb(255, 192, 192);

            txtTenSP.Enabled = false;
            txtGV.Enabled = false;
            txtGB.Enabled = false;
            txtDVT.Enabled = false;
            txtKTSP.Enabled = false;
            txtMauSP.Enabled = false;
            txtSLTK.Enabled = false;
            cmbLSP.Enabled = false;
            cmbNCC.Enabled = false;
            cmbCN.Enabled = false;

            dgvSP.Enabled = true;
        }

        private void dgvSP_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            cmbCN.Text = dgvSP.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSP.Text = dgvSP.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[e.RowIndex].Cells[2].Value.ToString();

            txtGV.Text = dgvSP.Rows[e.RowIndex].Cells[3].Value.ToString();
            CultureInfo cultureGV = new CultureInfo("vi-VN");
            txtGV.Text = float.Parse(txtGV.Text).ToString("c", cultureGV);

            txtGB.Text = dgvSP.Rows[e.RowIndex].Cells[4].Value.ToString();
            CultureInfo cultureGB = new CultureInfo("vi-VN");
            txtGB.Text = float.Parse(txtGB.Text).ToString("c", cultureGB);

            txtDVT.Text = dgvSP.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtKTSP.Text = dgvSP.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtMauSP.Text = dgvSP.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtSLTK.Text = dgvSP.Rows[e.RowIndex].Cells[8].Value.ToString();
            cmbLSP.Text = dgvSP.Rows[e.RowIndex].Cells[9].Value.ToString();
            cmbNCC.Text = dgvSP.Rows[e.RowIndex].Cells[10].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvSP.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGV.Text = "";
            txtGB.Text = "";
            txtDVT.Text = "";
            txtKTSP.Text = "";
            txtMauSP.Text = "";
            txtSLTK.Text = "";
            cmbLSP.SelectedValue = "LSP01";
            cmbNCC.SelectedValue = "PS01";
            cmbCN.SelectedValue = "MIEU01";

            txtTenSP.Enabled = true;
            txtGV.Enabled = true;
            txtGB.Enabled = true;
            txtDVT.Enabled = true;
            txtKTSP.Enabled = true;
            txtMauSP.Enabled = true;
            txtSLTK.Enabled = true;
            cmbLSP.Enabled = true;
            cmbNCC.Enabled = true;
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

            txtTenSP.Enabled = true;
            txtGV.Enabled = true;
            txtGB.Enabled = true;
            txtDVT.Enabled = true;
            txtKTSP.Enabled = true;
            txtMauSP.Enabled = true;
            txtSLTK.Enabled = true;
            cmbLSP.Enabled = true;
            cmbNCC.Enabled = true;
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

            SanPham.MaSP = txtMaSP.Text;
            TonKho.MaSP = txtMaSP.Text;
            SanPham.TenSP = txtTenSP.Text;

            float giaVon = float.Parse(txtGV.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            SanPham.GiaVon = giaVon;

            float giaBan = float.Parse(txtGB.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
            SanPham.GiaBan = giaBan;

            SanPham.DonViTinh = txtDVT.Text;
            SanPham.KichThuocSP = txtKTSP.Text;
            SanPham.MauSP = txtMauSP.Text;
            TonKho.SoLuongTonKho = int.Parse(txtSLTK.Text);
            SanPham.MaLSP = cmbLSP.SelectedValue.ToString();
            SanPham.MaNCC = cmbNCC.SelectedValue.ToString();
            TonKho.MaCN = cmbCN.SelectedValue.ToString();

            if (SPBLL.CheckXoaCTHD(SanPham) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa sản phẩm này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (SPBLL.CheckXoaCTPHT(SanPham) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Không được xóa sản phẩm này!", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (dgvSP.SelectedRows != null)
                    {
                        DialogResult ThongBaoXNX;
                        ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá sản phẩm có mã là " + SanPham.MaSP + " không?", "Thông báo",
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (ThongBaoXNX == DialogResult.OK)
                        {
                            if (SPBLL.XoaTKSP(SanPham))
                            {
                                if(SPBLL.XoaSP(SanPham))
                                {
                                    DialogResult ThongBao;
                                    ThongBao = MessageBox.Show("Xóa sản phẩm thành công", "Thông báo",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                else
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Xóa sản phẩm thất bại", "Thông báo lỗi",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                
                            }
                            else
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Xóa sản phẩm thất bại", "Thông báo lỗi",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            LoadDSSP();
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
                if (SPBLL.CheckThem(SanPham) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Sản phẩm này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaSP = SPBLL.TaoSTTMaSP();
                    if (STTMaSP < 10)
                    {
                        SanPham.MaSP = "SP0" + STTMaSP.ToString();
                    }
                    else
                    {
                        SanPham.MaSP = "SP" + STTMaSP.ToString();
                    }
                    txtMaSP.Text = SanPham.MaSP;
                    TonKho.MaSP = SanPham.MaSP;

                    if (SPBLL.ThemSP(SanPham))
                    {
                        if (SPBLL.ThemTKSP(SanPham, TonKho))
                        {
                            DialogResult ThongBao;
                            ThongBao = MessageBox.Show("Thêm sản phẩm thành công", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (SPBLL.SuaSP(SanPham))
                {
                    if (SPBLL.SuaTKSP(SanPham, TonKho))
                    {
                        DialogResult ThongBao;
                        ThongBao = MessageBox.Show("Sửa sản phẩm thành công", "Thông báo",
                                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Sửa sản phẩm thất bại", "Thông báo lỗi",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Sửa sản phẩm thất bại", "Thông báo lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                SanPham.TenSP = txtTenSP.Text;
                SanPham.DonViTinh = txtDVT.Text;
                SanPham.KichThuocSP = txtKTSP.Text;
                SanPham.MauSP = txtMauSP.Text;
                SanPham.MaLSP = cmbLSP.SelectedValue.ToString();
                SanPham.MaNCC = cmbNCC.SelectedValue.ToString();
                TonKho.MaCN = cmbCN.SelectedValue.ToString();
            }
            else
            {
                SanPham.MaSP = txtMaSP.Text;
                TonKho.MaSP = txtMaSP.Text;
                SanPham.TenSP = txtTenSP.Text;
                SanPham.DonViTinh = txtDVT.Text;
                SanPham.KichThuocSP = txtKTSP.Text;
                SanPham.MauSP = txtMauSP.Text;
                SanPham.MaLSP = cmbLSP.SelectedValue.ToString();
                SanPham.MaNCC = cmbNCC.SelectedValue.ToString();
                TonKho.MaCN = cmbCN.SelectedValue.ToString();
            }
            
            if (txtGV.Text == "")
            {
                SanPham.GiaVon = 0;
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin sản phẩm không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtGB.Text == "")
                {
                    SanPham.GiaBan = 0;
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Thông tin sản phẩm không được bỏ trống", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (SanPham.TenSP == "" || SanPham.DonViTinh == "" || SanPham.KichThuocSP == "" || SanPham.MauSP == "" || SanPham.MaLSP == "" || SanPham.MaNCC == "")
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Thông tin sản phẩm không được bỏ trống", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (SanPham.TenSP.Length > 250)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Tên sản phẩm không đúng định dạng", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (SanPham.DonViTinh.Length > 10)
                            {
                                DialogResult ThongBaoLoi;
                                ThongBaoLoi = MessageBox.Show("Đơn vị tính của sản phẩm không đúng định dạng", "Thông báo lỗi",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (SanPham.KichThuocSP.Length > 30)
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Kích thước của sản phẩm không đúng định dạng", "Thông báo lỗi",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    if (SanPham.MauSP.Length > 30)
                                    {
                                        DialogResult ThongBaoLoi;
                                        ThongBaoLoi = MessageBox.Show("Màu của sản phẩm không đúng định dạng", "Thông báo lỗi",
                                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        int intValue = 0;
                                        if (int.TryParse(txtSLTK.Text, out intValue) == false)
                                        {
                                            DialogResult ThongBaoLoi;
                                            ThongBaoLoi = MessageBox.Show("Số lượng tồn kho không đúng định dạng", "Thông báo lỗi",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if (_them == false)
                                            {
                                                float giaVon = float.Parse(txtGV.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                txtGV.Text = giaVon.ToString();

                                                float giaBan = float.Parse(txtGB.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                txtGB.Text = giaBan.ToString();
                                            }

                                            float floatValueGV = 0;
                                            if (float.TryParse(txtGV.Text, out floatValueGV) == false)
                                            {
                                                DialogResult ThongBaoLoi;
                                                ThongBaoLoi = MessageBox.Show("Giá vốn của sản phẩm không đúng định dạng", "Thông báo lỗi",
                                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                            else
                                            {
                                                float floatValueGB = 0;
                                                if (float.TryParse(txtGB.Text, out floatValueGB) == false)
                                                {
                                                    DialogResult ThongBaoLoi;
                                                    ThongBaoLoi = MessageBox.Show("Giá bán của sản phẩm không đúng định dạng", "Thông báo lỗi",
                                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {                                                    
                                                    if (_them == true)
                                                    {
                                                        float giaVon = float.Parse(txtGV.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                        SanPham.GiaVon = giaVon;

                                                        float giaBan = float.Parse(txtGB.Text, NumberStyles.Currency, new CultureInfo("vi-VN"));
                                                        SanPham.GiaBan = giaBan;

                                                        TonKho.SoLuongTonKho = int.Parse(txtSLTK.Text);

                                                        txtTenSP.Enabled = false;
                                                        txtGV.Enabled = false;
                                                        txtGB.Enabled = false;
                                                        txtDVT.Enabled = false;
                                                        txtKTSP.Enabled = false;
                                                        txtMauSP.Enabled = false;
                                                        txtSLTK.Enabled = false;
                                                        cmbLSP.Enabled = false;
                                                        cmbNCC.Enabled = false;
                                                        cmbCN.Enabled = false;
                                                        
                                                        dgvSP.Enabled = true;

                                                        SaveData();
                                                        LoadDSSP();

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
                                                    else
                                                    {
                                                        SanPham.GiaVon = float.Parse(txtGV.Text);
                                                        SanPham.GiaBan = float.Parse(txtGB.Text);

                                                        TonKho.SoLuongTonKho = int.Parse(txtSLTK.Text);

                                                        txtTenSP.Enabled = false;
                                                        txtGV.Enabled = false;
                                                        txtGB.Enabled = false;
                                                        txtDVT.Enabled = false;
                                                        txtKTSP.Enabled = false;
                                                        txtMauSP.Enabled = false;
                                                        txtSLTK.Enabled = false;
                                                        cmbLSP.Enabled = false;
                                                        cmbNCC.Enabled = false;
                                                        cmbCN.Enabled = false;
                                                        
                                                        dgvSP.Enabled = true;

                                                        SaveData();
                                                        LoadDSSP();

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
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenSP.Enabled = false;
            txtGV.Enabled = false;
            txtGB.Enabled = false;
            txtDVT.Enabled = false;
            txtKTSP.Enabled = false;
            txtMauSP.Enabled = false;
            txtSLTK.Enabled = false;
            cmbLSP.Enabled = false;
            cmbNCC.Enabled = false;
            cmbCN.Enabled = false;

            dgvSP.Enabled = true;

            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGV.Text = "";
            txtGB.Text = "";
            txtDVT.Text = "";
            txtKTSP.Text = "";
            txtMauSP.Text = "";
            txtSLTK.Text = "";
            cmbLSP.SelectedValue = "LSP01";
            cmbNCC.SelectedValue = "PS01";
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
        
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvSP.Rows.Count == 0) return;
            vitri = 0;

            txtMaSP.Text = dgvSP.Rows[vitri].Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[vitri].Cells["TenSP"].Value.ToString();
            txtGV.Text = dgvSP.Rows[vitri].Cells["GiaVon"].Value.ToString();
            txtGB.Text = dgvSP.Rows[vitri].Cells["GiaBan"].Value.ToString();
            txtDVT.Text = dgvSP.Rows[vitri].Cells["DonVTinh"].Value.ToString();
            txtKTSP.Text = dgvSP.Rows[vitri].Cells["KichThuocSP"].Value.ToString();
            txtMauSP.Text = dgvSP.Rows[vitri].Cells["MauSP"].Value.ToString();
            txtSLTK.Text = dgvSP.Rows[vitri].Cells["SoLuongTonKho"].Value.ToString();
            cmbLSP.SelectedValue = dgvSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            cmbNCC.SelectedValue = dgvSP.Rows[vitri].Cells["MaNCC"].Value.ToString();
            cmbCN.SelectedValue = dgvSP.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvSP.Rows.Count == 0) return;
            vitri = dgvSP.Rows.Count - 2;

            txtMaSP.Text = dgvSP.Rows[vitri].Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[vitri].Cells["TenSP"].Value.ToString();
            txtGV.Text = dgvSP.Rows[vitri].Cells["GiaVon"].Value.ToString();
            txtGB.Text = dgvSP.Rows[vitri].Cells["GiaBan"].Value.ToString();
            txtDVT.Text = dgvSP.Rows[vitri].Cells["DonVTinh"].Value.ToString();
            txtKTSP.Text = dgvSP.Rows[vitri].Cells["KichThuocSP"].Value.ToString();
            txtMauSP.Text = dgvSP.Rows[vitri].Cells["MauSP"].Value.ToString();
            txtSLTK.Text = dgvSP.Rows[vitri].Cells["SoLuongTonKho"].Value.ToString();
            cmbLSP.SelectedValue = dgvSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            cmbNCC.SelectedValue = dgvSP.Rows[vitri].Cells["MaNCC"].Value.ToString();
            cmbCN.SelectedValue = dgvSP.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvSP.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvSP.Rows.Count - 2;

            txtMaSP.Text = dgvSP.Rows[vitri].Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[vitri].Cells["TenSP"].Value.ToString();
            txtGV.Text = dgvSP.Rows[vitri].Cells["GiaVon"].Value.ToString();
            txtGB.Text = dgvSP.Rows[vitri].Cells["GiaBan"].Value.ToString();
            txtDVT.Text = dgvSP.Rows[vitri].Cells["DonVTinh"].Value.ToString();
            txtKTSP.Text = dgvSP.Rows[vitri].Cells["KichThuocSP"].Value.ToString();
            txtMauSP.Text = dgvSP.Rows[vitri].Cells["MauSP"].Value.ToString();
            txtSLTK.Text = dgvSP.Rows[vitri].Cells["SoLuongTonKho"].Value.ToString();
            cmbLSP.SelectedValue = dgvSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            cmbNCC.SelectedValue = dgvSP.Rows[vitri].Cells["MaNCC"].Value.ToString();
            cmbCN.SelectedValue = dgvSP.Rows[vitri].Cells["MaCN"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvSP.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvSP.Rows.Count - 2) vitri = 0;

            txtMaSP.Text = dgvSP.Rows[vitri].Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvSP.Rows[vitri].Cells["TenSP"].Value.ToString();
            txtGV.Text = dgvSP.Rows[vitri].Cells["GiaVon"].Value.ToString();
            txtGB.Text = dgvSP.Rows[vitri].Cells["GiaBan"].Value.ToString();
            txtDVT.Text = dgvSP.Rows[vitri].Cells["DonVTinh"].Value.ToString();
            txtKTSP.Text = dgvSP.Rows[vitri].Cells["KichThuocSP"].Value.ToString();
            txtMauSP.Text = dgvSP.Rows[vitri].Cells["MauSP"].Value.ToString();
            txtSLTK.Text = dgvSP.Rows[vitri].Cells["SoLuongTonKho"].Value.ToString();
            cmbLSP.SelectedValue = dgvSP.Rows[vitri].Cells["MaLSP"].Value.ToString();
            cmbNCC.SelectedValue = dgvSP.Rows[vitri].Cells["MaNCC"].Value.ToString();
            cmbCN.SelectedValue = dgvSP.Rows[vitri].Cells["MaCN"].Value.ToString();
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
