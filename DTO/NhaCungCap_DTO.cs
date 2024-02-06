using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap_DTO
    {
        private string _maNCC;
        private string _tenNCC;
        private string _sDT;
        private string _diaChi;
        private string _email;

        public NhaCungCap_DTO() { }

        public string MaNCC { get => _maNCC; set => _maNCC = value; }
        public string TenNCC { get => _tenNCC; set => _tenNCC = value; }
        public string SDT { get => _sDT; set => _sDT = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string Email { get => _email; set => _email = value; }

        public NhaCungCap_DTO(string maNCC, string tenNCC, string sDT, string diaChi, string eMail)
        {
            _maNCC = maNCC;
            _tenNCC = tenNCC;
            _sDT = sDT;
            _diaChi = diaChi;
            _email = eMail;
        }
    }
}
