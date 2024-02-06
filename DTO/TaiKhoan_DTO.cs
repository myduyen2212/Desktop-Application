using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private string _maTK;
        private string _tenTK;
        private string _matKhau;
        private string _maNV;

        public TaiKhoan_DTO() { }
        public string MaTK { get => _maTK; set => _maTK = value; }
        public string TenTK { get => _tenTK; set => _tenTK = value; }
        public string MatKhau { get => _matKhau; set => _matKhau = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }

        public TaiKhoan_DTO(string maTK, string tenTK, string matKhau)
        {
            _maTK = maTK;
            _tenTK = tenTK;
            _matKhau = matKhau;
            _maNV = MaNV;
        }
    }
}
