using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon_DTO
    {
        private string _maHD;
        private DateTime _ngayHD;
        private float _tienGiamGia;
        private float _tienKhachDua;
        private float _tienTraLai;
        private float _tongThanhTien;
        private string _maKH;
        private string _maCTKM;
        private string _maNV;
        private DataRow item;

        public HoaDon_DTO() { }

        public string MaHD { get => _maHD; set => _maHD = value; }
        public DateTime NgayHD { get => _ngayHD; set => _ngayHD = value; }
        public float TienGiamGia { get => _tongThanhTien; set => _tienGiamGia = value; }
        public float TienKhachDua { get => _tongThanhTien; set => _tienKhachDua = value; }
        public float TienTraLai { get => _tongThanhTien; set => _tienTraLai = value; }
        public float TongThanhTien { get => _tongThanhTien; set => _tongThanhTien = value; }
        public string MaKH { get => _maKH; set => _maKH = value; }
        public string MaCTKM { get => _maCTKM; set => _maCTKM = value; }
        public string MaNV { get => _maNV; set => _maNV = value; }

        public HoaDon_DTO(string maHD, DateTime ngayHD, float tienGiamGia, float tienKhachDua, float tienTraLai, float tongThanhTien, string maKH, string maCTKM, string maNV)
        {
            _maHD = maHD;
            _ngayHD = ngayHD;
            _tienGiamGia = tienGiamGia;
            _tienKhachDua = tienKhachDua;
            _tienTraLai = tienTraLai;
            _tongThanhTien = tongThanhTien;
            _maKH = maKH;
            _maCTKM = maCTKM;
            _maNV = maNV;
        }

        public HoaDon_DTO(DataRow item)
        {
            this.item = item;
        }
    }
}
