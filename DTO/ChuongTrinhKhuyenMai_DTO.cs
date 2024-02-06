using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuongTrinhKhuyenMai_DTO
    {
        private string _maCTKM;
        private string _tenCTKM;
        private DateTime _ngayBDCTKM;
        private DateTime _ngayKTCTKM;
        private int _chietKhau;

        public ChuongTrinhKhuyenMai_DTO() { }

        public string MaCTKM { get => _maCTKM; set => _maCTKM = value; }
        public string TenCTKM { get => _tenCTKM; set => _tenCTKM = value; }
        public DateTime NgayBDCTKM { get => _ngayBDCTKM; set => _ngayBDCTKM = value; }
        public DateTime NgayKTCTKM { get => _ngayKTCTKM; set => _ngayKTCTKM = value; }
        public int ChietKhau { get => _chietKhau; set => _chietKhau = value; }

        public ChuongTrinhKhuyenMai_DTO(string maCTKM, string tenCTKM, DateTime ngayBDCTKM, DateTime ngayKTCTKM, int chietKhau)
        {
            _maCTKM = maCTKM;
            _tenCTKM = tenCTKM;
            _ngayBDCTKM = ngayBDCTKM;
            _ngayKTCTKM = ngayKTCTKM;
            _chietKhau = chietKhau;
        }
    }
}
