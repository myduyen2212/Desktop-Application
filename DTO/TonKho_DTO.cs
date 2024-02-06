using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TonKho_DTO
    {
        private string _maCN;
        private string _maSP;
        private int _soLuongTonKho;

        public TonKho_DTO() { }

        public string MaCN { get => _maCN; set => _maCN = value; }
        public string MaSP { get => _maSP; set => _maSP = value; }
        public int SoLuongTonKho { get => _soLuongTonKho; set => _soLuongTonKho = value; }

        public TonKho_DTO(string maCN, string maSP, int soLuongTonKho)
        {
            _maCN = maCN;
            _maSP = maSP;
            _soLuongTonKho = soLuongTonKho;
        }
    }
}
