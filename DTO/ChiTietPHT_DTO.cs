using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPHT_DTO
    {
        private string _maPHT;
        private string _maSP;
        private string _lyDoHT;
        private int _soLuong;
        private float _thanhTien;

        public ChiTietPHT_DTO() { }

        public string MaPHT { get => _maPHT; set => _maPHT = value; }
        public string MaSP { get => _maSP; set => _maSP = value; }
        public string LyDoHT { get => _lyDoHT; set => _lyDoHT = value; }
        public int SoLuong { get => _soLuong; set => _soLuong = value; }
        public float ThanhTien { get => _thanhTien; set => _thanhTien = value; }

        public ChiTietPHT_DTO(string maPHT, string maSP, string lyDoHT, int soLuong, float thanhTien)
        {
            _maPHT = maPHT;
            _maSP = maSP;
            _lyDoHT = lyDoHT;
            _soLuong = soLuong;
            _thanhTien = thanhTien;
        }
    }
}
