using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiNhanh_DTO
    {
        private string _maCN;
        private string _tenCN;
        private string _diaChi;

        public ChiNhanh_DTO() { }

        public string MaCN { get => _maCN; set => _maCN = value; }
        public string TenCN { get => _tenCN; set => _tenCN = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }

        public ChiNhanh_DTO(string maCN, string tenCN, string diaChi)
        {
            _maCN = maCN;
            _tenCN = tenCN;
            _diaChi = diaChi;
        }
    }
}
