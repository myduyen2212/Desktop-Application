using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPham_DTO
    {
        private string _maSP;
        private string _tenSP;
        private float _giaVon;
        private float _giaBan;
        private string _donViTinh;
        private string _kichThuocSP;
        private string _mauSP;
        private string _maLSP;
        private string _maNCC;

        public SanPham_DTO() { }

        public string MaSP { get => _maSP; set => _maSP = value; }
        public string TenSP { get => _tenSP; set => _tenSP = value; }
        public float GiaVon { get => _giaVon; set => _giaVon = value; }
        public float GiaBan { get => _giaBan; set => _giaBan = value; }
        public string DonViTinh { get => _donViTinh; set => _donViTinh = value; }
        public string KichThuocSP { get => _kichThuocSP; set => _kichThuocSP = value; }
        public string MauSP { get => _mauSP; set => _mauSP = value; }
        public string MaLSP { get => _maLSP; set => _maLSP = value; }
        public string MaNCC { get => _maNCC; set => _maNCC = value; }

        public SanPham_DTO(string maSP, string tenSP, float giaVon, float giaBan, string donViTinh, string kichThuocSP, string mauSP, string maLSP, string maNCC)
        {
            _maSP = maSP;
            _tenSP = tenSP;
            _giaVon = giaVon;
            _giaBan = giaBan;
            _donViTinh = donViTinh;
            _kichThuocSP = kichThuocSP;
            _mauSP = mauSP;
            _maLSP = maLSP;
            _maNCC = maNCC;
        }
    }
}
