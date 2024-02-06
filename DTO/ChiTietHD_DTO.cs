using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHD_DTO
    {
        private string _maHD;
        private string _maSP;
        private int _soLuong;
        private float _thanhTien;

        public ChiTietHD_DTO() { }

        public string MaHD { get => _maHD; set => _maHD = value; }
        public string MaSP { get => _maSP; set => _maSP = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public float ThanhTien { get => _thanhTien; set => _thanhTien = value; }

        public ChiTietHD_DTO(string maHD, string maSP, int soLuong, float thanhTien)
        {
            _maHD = maHD;
            _maSP = maSP;
            _soLuong = soLuong;
            _thanhTien = thanhTien;
        }
            }
}
