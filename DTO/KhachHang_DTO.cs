using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        private string _maKH;
        private string _tenKH;
        private string _gioiTinh;
        private string _sDT;
        private DateTime _ngaySinh;
        private string _diaChi;
        private string _email;

        public KhachHang_DTO() { }

        public string MaKH { get => _maKH; set => _maKH = value; }
        public string TenKH { get => _tenKH; set => _tenKH = value; }
        public string GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public string SDT { get => _sDT; set => _sDT = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Email { get => _email; set => _email = value; }

        public KhachHang_DTO(string maKH, string tenKH, string gioiTinh, string sDT, DateTime ngaySinh, string diaChi, string email)
        {
            _maKH = maKH;
            _tenKH = tenKH;
            _gioiTinh = gioiTinh;
            _sDT = sDT;
            _ngaySinh = ngaySinh;
            _diaChi = diaChi;
            _email = email;
        }
    }
}
