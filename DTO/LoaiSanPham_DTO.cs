using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiSanPham_DTO
    {
        private string _maLSP;
        private string _tenLSP;

        public LoaiSanPham_DTO() { }

        public string MaLSP { get => _maLSP; set => _maLSP = value; }
        public string TenLSP { get => _tenLSP; set => _tenLSP = value; }

        public LoaiSanPham_DTO(string maLSP, string tenLSP)
        {
            MaLSP = maLSP;
            TenLSP = tenLSP;
        }
    }
}
