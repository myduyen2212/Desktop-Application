using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien_DTO
    {
        private string _maNV;
        private string _tenNV;
        private string _gioiTinh;
        private string _sDT;
        private DateTime _ngaySinh;
        private string _email;
        private string _diaChi;
        private string _chucVu;
        private DateTime _ngayBDLamViec;
        private float _mucLuong;
        private string _bHYT;
        private string _trinhDoHocVan;
        private string _maCN;

        public NhanVien_DTO() { }

        public string MaNV { get => _maNV; set => _maNV = value; }
        public string TenNV { get => _tenNV; set => _tenNV = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string SDT { get => _sDT; set => _sDT = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string Email { get => _email; set => _email = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string ChucVu { get => _chucVu; set => _chucVu = value; }
        public DateTime NgayBDLamViec { get => _ngayBDLamViec; set => _ngayBDLamViec = value; }
        public float MucLuong { get => _mucLuong; set => _mucLuong = value; }
        public string BHYT { get => _bHYT; set => _bHYT = value; }
        public string TrinhDoHocVan { get => _trinhDoHocVan; set => _trinhDoHocVan = value; }
        public string MaCN { get => _maCN; set => _maCN = value; }

        public NhanVien_DTO(string maNV, string tenNV, string gioiTinh, string sDT, DateTime ngaySinh, string email, string diaChi, string chucVu, DateTime ngayBDLamViec, float mucLuong, string bHYT, string trinhDoHocVan, string maTK, string maCN)
        {
            _maNV = maNV;
            _tenNV = tenNV;
            _gioiTinh = gioiTinh;
            _sDT = sDT;
            _ngaySinh = ngaySinh;
            _email = email;
            _diaChi = diaChi;
            _chucVu = chucVu;
            _ngayBDLamViec = ngayBDLamViec;
            _mucLuong = mucLuong;
            _bHYT = bHYT;
            _trinhDoHocVan = trinhDoHocVan;
            _maCN = maCN;
        }
    }
}
