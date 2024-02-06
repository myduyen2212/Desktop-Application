using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuHoanTra_DTO
    {
        private string _maPHT;
        private DateTime _ngayPHT;
        private float _tongTienHT;
        private string _maKH;
        private string _maHD;
        private string _maNV;

        public PhieuHoanTra_DTO() { }

        public string MaPHT { get => _maPHT; set => _maPHT = value; }
        public DateTime NgayPHT { get => _ngayPHT; set => _ngayPHT = value; }
        public float TongTienHT { get => _tongTienHT; set => _tongTienHT = value; }
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string MaHD { get => _maHD; set => _maHD = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }

        public PhieuHoanTra_DTO(string maPHT, DateTime ngayPHT, float tongTienHT, string maKH, string maHD, string maNV)
        {
            _maPHT = maPHT;
            _ngayPHT = ngayPHT;
            _tongTienHT = tongTienHT;
            _maKH = maKH;
            _maHD = maHD;
            _maNV = maNV;
        }
    }
}
