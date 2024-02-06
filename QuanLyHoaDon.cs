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
    public partial class QuanLyHoaDon : Form
    {
        public QuanLyHoaDon()
        {
            InitializeComponent();
            LayDSSP();
            LoadDSKH();
            LoadCTKM();
            LoadDSNV();
            LoadCTKMToComboBox();
            dgvCTHD.UserDeletedRow += dgvCTHD_UserDeletedRow;
        }

        private void pbLOGO_Click(object sender, EventArgs e)
        {
            TrangChuBH trangchu = new TrangChuBH();
            trangchu.Show();
            this.Hide();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            TrangChuBH trangchu = new TrangChuBH();
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

        HoaDon_DTO HoaDon = new HoaDon_DTO();
        HoaDon_BLL HoaDonBLL = new HoaDon_BLL();
        ChiTietHD_DTO chiTietHD = new ChiTietHD_DTO();
        ChiTietHD_BLL chiTietHD_BLL = new ChiTietHD_BLL();
        SanPham_BLL sanPham_BLL = new SanPham_BLL();
        SanPham_DTO sanPham = new SanPham_DTO();
        NhanVien_BLL nhanVienBLL = new NhanVien_BLL();

        KhachHang_DTO KhachHang = new KhachHang_DTO();
        KhachHang_BLL KHBLL = new KhachHang_BLL();
        ChuongTrinhKhuyenMai_DTO CTKM = new ChuongTrinhKhuyenMai_DTO();
        ChuongTrinhKhuyenMai_BLL CTKM_BLL = new ChuongTrinhKhuyenMai_BLL();
        bool _them;
        
        private void dgvCTHD_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            CapnNhatTienTraLai();
        }

        public void LayDSSP()
        {
            try
            {
                // Thêm một cột checkbox vào DataGridView
                dgvSP.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Enable multi-select
                dgvSP.MultiSelect = true;
                // Lấy dữ liệu sản phẩm và hiển thị trong DataGridView
                dgvSP.DataSource = sanPham_BLL.LayDSSP();

                // Thiết lập các cột trong DataGridView


                dgvSP.CellClick += dgvSP_CellClick;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            dgvCTHD.CellValueChanged += dgvCTHD_CellValueChanged;

        }

        private void dgvCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCTHD.Columns["SoLuong"].Index && e.RowIndex >= 0)
            {
                // Fix: Corrected the conversion syntax
                int quantity = Convert.ToInt32(dgvCTHD.Rows[e.RowIndex].Cells["SoLuong"].Value);
                float unitPrice = Convert.ToSingle(dgvCTHD.Rows[e.RowIndex].Cells["GiaBan"].Value);

                // Tính thành tiền
                float totalAmount = quantity * unitPrice;

                // Cập nhật cột "ThanhTien"
                dgvCTHD.Rows[e.RowIndex].Cells["ThanhTien"].Value = totalAmount;

                // Cập nhật tổng thành tiền
                CapnNhatTienTraLai();
            }
        }

        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCTHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void txtTuKhoaTKKH_TextChanged(object sender, EventArgs e)
        {
            if (txtTuKhoaTKKH.Text == "")
            {
                LoadDSKH();
            }
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            try
            {
                string TuKhoaTKH = txtTuKhoaTKKH.Text;
                dgvKH.DataSource = KHBLL.TimKiem(TuKhoaTKH);
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            // Check if any row is selected in dgvCTHD
            if (dgvCTHD.SelectedRows.Count > 0)
            {
                // There is a selected row, proceed with deletion
                DataGridViewRow selectedRow = dgvCTHD.SelectedRows[0];
                dgvCTHD.Rows.Remove(selectedRow);
                CapnNhatTienTraLai();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trong Hóa đơn để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnChonSP_Click(object sender, EventArgs e)
        {
            // Handle the logic when the "Chọn SP" button is clicked

            // Assuming you want to add a row to dgvCTHD based on the selected row in dgvSP
            if (dgvSP.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSP.SelectedRows[0];

                // Get the values from the selected row in dgvSP
                string selectedProductCode = Convert.ToString(selectedRow.Cells["MaSP"].Value);
                string selectedProductName = Convert.ToString(selectedRow.Cells["TenSP"].Value);
                float selectedSellingPrice = Convert.ToSingle(selectedRow.Cells["GiaBan"].Value);

                // Check if dgvCTHD has columns
                if (dgvCTHD.Columns.Count == 0)
                {
                    dgvCTHD.Columns.Add("MaSP", "Mã Sản Phẩm");
                    dgvCTHD.Columns.Add("TenSP", "Tên Sản Phẩm");
                    dgvCTHD.Columns.Add("SoLuong", "Số Lượng");
                    dgvCTHD.Columns.Add("GiaBan", "Giá Bán");
                    dgvCTHD.Columns.Add("ThanhTien", "Thành Tiền");
                }

                // Check if the product code already exists in dgvCTHD
                DataGridViewRow existingRow = dgvCTHD.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["MaSP"].Value != null && r.Cells["MaSP"].Value.ToString() == selectedProductCode);

                if (existingRow == null)
                {
                    // Product code doesn't exist, add a new row to dgvCTHD
                    DataGridViewRow newRow = new DataGridViewRow();

                    // Add columns: MaSanPham, TenSanPham, SoLuong, GiaBan, ThanhTien
                    DataGridViewCell cell1 = new DataGridViewTextBoxCell();
                    cell1.Value = selectedProductCode;
                    newRow.Cells.Add(cell1);

                    // Assuming the product name is in the second column (adjust the index based on your actual column)
                    DataGridViewCell cell2 = new DataGridViewTextBoxCell();
                    cell2.Value = selectedProductName;
                    newRow.Cells.Add(cell2);

                    // Add a column for quantity
                    DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                    newRow.Cells.Add(cell3);

                    // Add a column for selling price
                    DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                    cell4.Value = selectedSellingPrice;
                    newRow.Cells.Add(cell4);

                    // Add a column for total amount
                    DataGridViewTextBoxCell cell5 = new DataGridViewTextBoxCell();
                    newRow.Cells.Add(cell5);

                    // Add the new row to dgvCTHD
                    dgvCTHD.Rows.Add(newRow);
                }
                else
                {
                    // Product code already exists, you can handle it as needed (e.g., show a message)
                    MessageBox.Show("Sản phẩm đã tồn tại trong hóa đơn", "Trùng lặp sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
            dgvKH.RowEnter += dgvKH_RowEnter;
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

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            LoadDSKH();
            _them = false;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            btnThemKH.Enabled = false;

            dgvKH.Enabled = false;

            btnThemKH.BackColor = Color.LightGray;
            pbSuaB.BringToFront();


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

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            btnThemKH.Enabled = false;

            btnThemKH.BackColor = Color.LightGray;
            pbThemB.BringToFront();

            txtTenKH.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            dtpNgaySinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;

            _them = false;
        }

        private void btnLuuKH_Click(object sender, EventArgs e)
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

                                                btnThemKH.BackColor = Color.Gold;
                                                pbThem.BringToFront();
                                                btnThemKH.BackColor = Color.LightSkyBlue;
                                                pbSua.BringToFront();
                                                btnThemKH.BackColor = Color.FromArgb(255, 192, 192);
                                                btnThemKH.BringToFront();

                                                btnThemKH.Enabled = true;
                                                btnThemKH.Enabled = true;
                                                btnThemKH.Enabled = true;
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

        private void btnHuyKH_Click(object sender, EventArgs e)
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

            btnThemKH.BackColor = Color.Gold;
            pbThem.BringToFront();
            btnSuaKH.BackColor = Color.LightSkyBlue;
            pbSua.BringToFront();

            _them = false;

            btnThemKH.Enabled = true;
            btnSuaKH.Enabled = true;
        }

        public void LoadCTKM()
        {
            try
            {
                dgvCTKM.DataSource = CTKM_BLL.LayDSCTKM();
                dgvCTKM.Columns[0].HeaderText = "Mã CTKM";
                dgvCTKM.Columns[0].Width = 105;
                dgvCTKM.Columns[1].HeaderText = "Tên chương trình";
                dgvCTKM.Columns[1].Width = 200;
                dgvCTKM.Columns[2].HeaderText = "Ngày bắt đầu";
                dgvCTKM.Columns[2].Width = 150;
                dgvCTKM.Columns[3].HeaderText = "Ngày kết thúc ";
                dgvCTKM.Columns[3].Width = 150;
                dgvCTKM.Columns[4].HeaderText = "Giảm giá (%)";
                dgvCTKM.Columns[4].Width = 105;
            }
            catch (SqlException)
            {
                DialogResult ThongBaoLoi;
                ThongBaoLoi = MessageBox.Show("Không lấy được dữ liệu, có lỗi rồi!", "Thông báo lỗi",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void LoadCTKMToComboBox()
        {
            try
            {
                // Lấy DataTable từ BLL
                DataTable dtCTKM = CTKM_BLL.LayDSCTKM();

                // Check if the DataTable is not null and contains data
                if (dtCTKM != null && dtCTKM.Rows.Count > 0)
                {
                    // Thêm cột ChietKhau vào DataTable (if not already added)

                    // Thiết lập ComboBox
                    cmbCTKM.DataSource = dtCTKM;
                    cmbCTKM.DisplayMember = "MaCTKM"; // Tên hiển thị trong ComboBox
                    cmbCTKM.ValueMember = "MaCTKM";    // Giá trị tương ứng với mỗi mục

                    // Optional: Chọn một giá trị mặc định (nếu cần)
                }
                else
                {
                    MessageBox.Show("Dữ liệu chương trình khuyến mãi không khả dụng hoặc trống rỗng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu chương trình khuyến mãi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCTKM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string maCTKM = cmbCTKM.SelectedValue.ToString();

                // Tìm thông tin chương trình khuyến mãi trong danh sách
                DataRow[] rows = CTKM_BLL.LayDSCTKM().Select($"MaCTKM = '{maCTKM}'");

                if (rows.Length > 0)
                {
                    // Lấy chiết khấu từ DataRow tìm thấy
                    int chietKhau = Convert.ToInt32(rows[0]["ChietKhau"]);

                    // Tính tổng thành tiền từ DataGridView
                    float tongThanhTienDGV = TinhTongThanhTienDGV();

                    // Tính giảm giá dựa trên tổng thành tiền
                    float giamGia = (chietKhau / 100f) * tongThanhTienDGV; // Lưu ý: Chia cho 100f để có kết quả dạng float

                    // Cập nhật giá trị giảm giá vào TextBox
                    txtTienGiamGia.Text = giamGia.ToString();

                    // Trừ số tiền giảm giá khỏi tổng thành tiền và cập nhật TextBox
                    tongThanhTienDGV -= giamGia;
                    txtTongThanhTien.Text = tongThanhTienDGV.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xử lý sự kiện cmbCTKM_SelectedIndexChanged: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public float TinhTongThanhTienDGV()
        {
            float tongThanhTien = 0;

            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                int soLuong = Convert.ToInt32(dgvCTHD.Rows[i].Cells["SoLuong"].Value);
                float donGia = Convert.ToSingle(dgvCTHD.Rows[i].Cells["GiaBan"].Value);
                float thanhTien = soLuong * donGia;
                dgvCTHD.Rows[i].Cells["ThanhTien"].Value = thanhTien.ToString(); // Format as currency
                tongThanhTien += thanhTien;
            }

            // Hiển thị tổng thành tiền
            txtTongThanhTien.Text = tongThanhTien.ToString(); // Format as currency
            return tongThanhTien;
        }

        private void CapnNhatTienTraLai() //tính tiền trả 
        {
            float tongthanhTien = TinhTongThanhTienDGV();
            txtTongThanhTien.Text = tongthanhTien.ToString();
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtTongThanhTien.Text, out decimal tongThanhTienDGV) && decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhachDua))
            {
                decimal tienTraLai = tienKhachDua - tongThanhTienDGV;
                txtTienTraLai.Text = tienTraLai.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTienTraLai_TextChanged(object sender, EventArgs e)
        {
            // Tính tiền trả lại
            if (decimal.TryParse(txtTongThanhTien.Text, out decimal tongThanhTien) &&
         decimal.TryParse(txtTienKhachDua.Text, out decimal tienKhachDua))
            {
                decimal tienTraLai = tienKhachDua - tongThanhTien;
                txtTienTraLai.Text = tienTraLai.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDSNV()
        {
            DataTable dt = nhanVienBLL.LayDSNV();
            cmbTenNV.DisplayMember = "MaNV"; // Display member (employee name)
            cmbTenNV.ValueMember = "MaNV";    // Value member (employee ID)
            cmbTenNV.DataSource = dt;         // Set the data source
        }

        private void dtpNgayTaoHD_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayTaoHD.Enabled = true;
        }

        private void btnThemHD_Click(object sender, EventArgs e)
        {
            
        }
    }
}
