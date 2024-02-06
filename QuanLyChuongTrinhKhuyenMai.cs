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
    public partial class QuanLyChuongTrinhKhuyenMai : Form
    {
        ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai = new ChuongTrinhKhuyenMai_DTO();
        ChuongTrinhKhuyenMai_BLL CTKMBLL = new ChuongTrinhKhuyenMai_BLL();
        bool _them;

        public QuanLyChuongTrinhKhuyenMai()
        {
            InitializeComponent();
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuQL trangchu = new TrangChuQL();
            trangchu.Show();
            this.Hide();
        }
        public void LoadDSCTKM()
        {
            try
            {
                dgvCTKM.DataSource = CTKMBLL.LayDSCTKM();
                dgvCTKM.Columns[0].HeaderText = "Mã chương trình khuyến mãi";
                dgvCTKM.Columns[0].Width = 155;
                dgvCTKM.Columns[1].HeaderText = "Tên chương trình khuyến mãi";
                dgvCTKM.Columns[1].Width = 200;
                dgvCTKM.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvCTKM.Columns[2].Width = 100;
                dgvCTKM.Columns[3].HeaderText = "Ngày kết thúc";
                dgvCTKM.Columns[3].Width = 100;
                dgvCTKM.Columns[4].HeaderText = "Chiếu khấu";
                dgvCTKM.Columns[4].Width = 100;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadLoaiTimKiem()
        {
            DataTable dtcb = new DataTable();
            dtcb.Columns.Add("LoaiTimKiem", typeof(string));
            dtcb.Rows.Add("Tìm theo mã");
            dtcb.Rows.Add("Tìm theo tên");
            dtcb.Rows.Add("Tìm theo ngày BĐ");

            try
            {
                cmbTimKiem.DataSource = dtcb;
                cmbTimKiem.DisplayMember = "LoaiTimKiem";
                cmbTimKiem.ValueMember = "LoaiTimKiem";
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuanLyChuongTrinhKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadDSCTKM();
            LoadLoaiTimKiem();
            _them = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cmbTimKiem.SelectedValue.ToString() == "Tìm theo mã")
            {
                try
                {
                    ChuongTrinhKhuyenMai.MaCTKM = txtTuKhoaTK.Text;
                    dgvCTKM.DataSource = CTKMBLL.TimKiemCTKMMaCTKM(ChuongTrinhKhuyenMai);
                }
                catch (SqlException)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (cmbTimKiem.SelectedValue.ToString() == "Tìm theo tên")
                {
                    try
                    {
                        ChuongTrinhKhuyenMai.TenCTKM = txtTuKhoaTK.Text;
                        dgvCTKM.DataSource = CTKMBLL.TimKiemCTKMTenCTKM(ChuongTrinhKhuyenMai);
                    }
                    catch (SqlException)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        ChuongTrinhKhuyenMai.NgayBDCTKM = dtpTKNgayBD.Value;
                        dgvCTKM.DataSource = CTKMBLL.TimKiemCTKMNgayBD(ChuongTrinhKhuyenMai);
                    }
                    catch (SqlException)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtTuKhoaTK_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTK.Text == "")
            {
                LoadDSCTKM();
            }
        }
        
        private void pbReset_Click(object sender, EventArgs e)
        {
            dtpTKNgayBD.Text = "2000-12-22";
            LoadDSCTKM();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            btnThem.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSua.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();
            btnXoa.BackColor = Color.FromArgb(255, 192, 192);

            txtTenCTKM.Enabled = false;
            dtpNgayBD.Enabled = false;
            dtpNgayKT.Enabled = false;
            txtChietKhau.Enabled = false;

            dgvCTKM.Enabled = true;
        }

        private void dgvCTKM_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCTKM.Text = dgvCTKM.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenCTKM.Text = dgvCTKM.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgayBD.Text = dgvCTKM.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpNgayKT.Text = dgvCTKM.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtChietKhau.Text = dgvCTKM.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            dgvCTKM.Enabled = false;

            btnSua.BackColor = Color.LightGray;
            pbSuaB.BringToFront();
            btnXoa.BackColor = Color.LightGray;
            pbXoaB.BringToFront();

            txtMaCTKM.Text = "";
            txtTenCTKM.Text = "";
            dtpNgayBD.Text = "2000-12-22";
            dtpNgayKT.Text = "2000-12-22";
            txtChietKhau.Text = "";

            txtTenCTKM.Enabled = true;
            dtpNgayBD.Enabled = true;
            dtpNgayKT.Enabled = true;
            txtChietKhau.Enabled = true;

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

            txtTenCTKM.Enabled = true;
            dtpNgayBD.Enabled = true;
            dtpNgayKT.Enabled = true;
            txtChietKhau.Enabled = true;

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

            ChuongTrinhKhuyenMai.MaCTKM = txtMaCTKM.Text;
            ChuongTrinhKhuyenMai.TenCTKM = txtTenCTKM.Text;
            ChuongTrinhKhuyenMai.NgayBDCTKM = dtpNgayBD.Value;
            ChuongTrinhKhuyenMai.NgayKTCTKM = dtpNgayKT.Value;
            ChuongTrinhKhuyenMai.ChietKhau = int.Parse(txtChietKhau.Text);

            if (CTKMBLL.CheckXoa(ChuongTrinhKhuyenMai) == false)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không được xóa chương trình khuyến mãi này!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (dgvCTKM.SelectedRows != null)
                {
                    DialogResult ThongBaoXNX;
                    ThongBaoXNX = MessageBox.Show("Bạn chắc chắn muốn xoá chương trình khuyến mãi có mã là " + ChuongTrinhKhuyenMai.MaCTKM + " không?", "Thông báo",
                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (ThongBaoXNX == DialogResult.OK)
                    {
                        if (CTKMBLL.XoaCTKM(ChuongTrinhKhuyenMai))
                        {
                            DialogResult ThongBao;
                            ThongBao = MessageBox.Show("Xóa chương trình khuyến mãi thành công", "Thông báo",
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Xóa chương trình khuyến mãi thất bại", "Thông báo lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        LoadDSCTKM();
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
                if (CTKMBLL.CheckThem(ChuongTrinhKhuyenMai) == false)
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Chương trình khuyến mãi này đã tồn tại", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int STTMaNCC = CTKMBLL.TaoSTTMaCTKM();
                    ChuongTrinhKhuyenMai.MaCTKM = txtMaCTKM.Text;
                    if (STTMaNCC < 10)
                    {
                        ChuongTrinhKhuyenMai.MaCTKM = "CTKM0" + STTMaNCC.ToString();
                    }
                    else
                    {
                        ChuongTrinhKhuyenMai.MaCTKM = "CTKM" + STTMaNCC.ToString();
                    }

                    CTKMBLL.ThemCTKM(ChuongTrinhKhuyenMai);
                    DialogResult ThongBao;
                    ThongBao = MessageBox.Show("Thêm chương trình khuyến mãi thành công", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {               
                CTKMBLL.SuaCTKM(ChuongTrinhKhuyenMai);
                DialogResult ThongBao;
                ThongBao = MessageBox.Show("Sửa chương trình khuyến mãi thành công", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ChuongTrinhKhuyenMai.MaCTKM = txtMaCTKM.Text;
            ChuongTrinhKhuyenMai.TenCTKM = txtTenCTKM.Text;
            ChuongTrinhKhuyenMai.NgayBDCTKM = dtpNgayBD.Value;
            ChuongTrinhKhuyenMai.NgayKTCTKM = dtpNgayKT.Value;

            if (txtChietKhau.Text == "")
            {
                ChuongTrinhKhuyenMai.ChietKhau = 0;
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Thông tin của chương trình khuyến mãi không được bỏ trống", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (ChuongTrinhKhuyenMai.TenCTKM == "" || ChuongTrinhKhuyenMai.NgayBDCTKM == Convert.ToDateTime("2000-12-22") || ChuongTrinhKhuyenMai.NgayKTCTKM == Convert.ToDateTime("2000-12-22"))
                {
                    DialogResult ThongBaoLoi;
                    ThongBaoLoi = MessageBox.Show("Thông tin của chương trình khuyến mãi không được bỏ trống", "Thông báo lỗi",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (ChuongTrinhKhuyenMai.TenCTKM.Length > 50)
                    {
                        DialogResult ThongBaoLoi;
                        ThongBaoLoi = MessageBox.Show("Tên chương trình khuyến mãi không đúng định dạng", "Thông báo lỗi",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int intValue = 0;
                        if (int.TryParse(txtChietKhau.Text, out intValue) == false)
                        {
                            DialogResult ThongBaoLoi;
                            ThongBaoLoi = MessageBox.Show("Chiết khấu của chương trình khuyến mãi không đúng định dạng", "Thông báo lỗi",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (_them == true)
                            {
                                if (ChuongTrinhKhuyenMai.NgayBDCTKM > ChuongTrinhKhuyenMai.NgayKTCTKM || ChuongTrinhKhuyenMai.NgayBDCTKM < DateTime.Now)
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Ngày bắt đầu và Ngày kết thúc không hợp lệ", "Thông báo lỗi",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ChuongTrinhKhuyenMai.ChietKhau = int.Parse(txtChietKhau.Text);

                                    txtTenCTKM.Enabled = false;
                                    dtpNgayBD.Enabled = false;
                                    dtpNgayKT.Enabled = false;
                                    txtChietKhau.Enabled = false;

                                    dgvCTKM.Enabled = true;

                                    SaveData();
                                    LoadDSCTKM();

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
                            else
                            {
                                if (ChuongTrinhKhuyenMai.NgayBDCTKM > ChuongTrinhKhuyenMai.NgayKTCTKM)
                                {
                                    DialogResult ThongBaoLoi;
                                    ThongBaoLoi = MessageBox.Show("Ngày bắt đầu và Ngày kết thúc không hợp lệ", "Thông báo lỗi",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    ChuongTrinhKhuyenMai.ChietKhau = int.Parse(txtChietKhau.Text);

                                    txtTenCTKM.Enabled = false;
                                    dtpNgayBD.Enabled = false;
                                    dtpNgayKT.Enabled = false;
                                    txtChietKhau.Enabled = false;

                                    dgvCTKM.Enabled = true;

                                    SaveData();
                                    LoadDSCTKM();

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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTenCTKM.Enabled = false;
            dtpNgayBD.Enabled = false;
            dtpNgayKT.Enabled = false;
            txtChietKhau.Enabled = false;

            dgvCTKM.Enabled = true;

            txtMaCTKM.Text = "";
            txtTenCTKM.Text = "";
            dtpNgayBD.Text = "";
            dtpNgayKT.Text = "";
            txtChietKhau.Text = "";

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

        private void dgvCTKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvCTKM.Rows.Count == 0) return;
            vitri = 0;

            txtMaCTKM.Text = dgvCTKM.Rows[vitri].Cells["MaCTKM"].Value.ToString();
            txtTenCTKM.Text = dgvCTKM.Rows[vitri].Cells["TenCTKM"].Value.ToString();
            dtpNgayBD.Text = dgvCTKM.Rows[vitri].Cells["NgayBDCTKM"].Value.ToString();
            dtpNgayKT.Text = dgvCTKM.Rows[vitri].Cells["NgayKTCTKM"].Value.ToString();
            txtChietKhau.Text = dgvCTKM.Rows[vitri].Cells["ChietKhau"].Value.ToString();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvCTKM.Rows.Count == 0) return;
            vitri = dgvCTKM.Rows.Count - 2;

            txtMaCTKM.Text = dgvCTKM.Rows[vitri].Cells["MaCTKM"].Value.ToString();
            txtTenCTKM.Text = dgvCTKM.Rows[vitri].Cells["TenCTKM"].Value.ToString();
            dtpNgayBD.Text = dgvCTKM.Rows[vitri].Cells["NgayBDCTKM"].Value.ToString();
            dtpNgayKT.Text = dgvCTKM.Rows[vitri].Cells["NgayKTCTKM"].Value.ToString();
            txtChietKhau.Text = dgvCTKM.Rows[vitri].Cells["ChietKhau"].Value.ToString();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dgvCTKM.Rows.Count == 0) return;
            vitri--;
            if (vitri < 0) vitri = dgvCTKM.Rows.Count - 2;

            txtMaCTKM.Text = dgvCTKM.Rows[vitri].Cells["MaCTKM"].Value.ToString();
            txtTenCTKM.Text = dgvCTKM.Rows[vitri].Cells["TenCTKM"].Value.ToString();
            dtpNgayBD.Text = dgvCTKM.Rows[vitri].Cells["NgayBDCTKM"].Value.ToString();
            dtpNgayKT.Text = dgvCTKM.Rows[vitri].Cells["NgayKTCTKM"].Value.ToString();
            txtChietKhau.Text = dgvCTKM.Rows[vitri].Cells["ChietKhau"].Value.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvCTKM.Rows.Count == 0) return;
            vitri++;
            if (vitri > dgvCTKM.Rows.Count - 2) vitri = 0;

            txtMaCTKM.Text = dgvCTKM.Rows[vitri].Cells["MaCTKM"].Value.ToString();
            txtTenCTKM.Text = dgvCTKM.Rows[vitri].Cells["TenCTKM"].Value.ToString();
            dtpNgayBD.Text = dgvCTKM.Rows[vitri].Cells["NgayBDCTKM"].Value.ToString();
            dtpNgayKT.Text = dgvCTKM.Rows[vitri].Cells["NgayKTCTKM"].Value.ToString();
            txtChietKhau.Text = dgvCTKM.Rows[vitri].Cells["ChietKhau"].Value.ToString();
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
