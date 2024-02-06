using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace DAL
{
    public class NhanVien_DAL
    {
        private static NhanVien_DAL instance;

        public static NhanVien_DAL Instance
        {
            get { if (instance == null) instance = new NhanVien_DAL(); return instance; }
            private set { instance = value; }
        }

        public NhanVien_DAL() { }

        public DataTable LayDSNV()
        {
            string query = "SELECT * FROM NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LayDSCN()
        {
            string query = "SELECT * FROM ChiNhanh";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoaLoc)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE MaNV LIKE '%{0}%' OR TenNV LIKE N'%{0}%' OR SDT LIKE N'%{0}%'", TuKhoaLoc);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable LocCN(string MaCN)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE MaCN LIKE '%{0}%'", MaCN);
            return DataProvider.Instance.ExecuteQuery(query);
        }


        public bool CheckThem(NhanVien_DTO NhanVien)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE TenNV = N'{0}' AND SDT = N'{1}'", NhanVien.TenNV, NhanVien.SDT);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int TaoSTTMaNV()
        {
            string query = string.Format("SELECT COUNT(*) FROM NhanVien");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemNV(NhanVien_DTO NhanVien)
        {
            string query = string.Format("INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, SDT, Email, NgaySinh, DiaChi, ChucVu, NgayBDLamViec, MucLuong, BHYT, TrinhDoHocVan, MaCN) VALUES ('{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5:yyyy-MM-dd}', N'{6}', N'{7}', '{8:yyyy-MM-dd}', {9}, '{10}', N'{11}', '{12}')", NhanVien.MaNV, NhanVien.TenNV, NhanVien.GioiTinh, NhanVien.SDT, NhanVien.Email, Convert.ToDateTime(NhanVien.NgaySinh), NhanVien.DiaChi, NhanVien.ChucVu, Convert.ToDateTime(NhanVien.NgayBDLamViec), NhanVien.MucLuong, NhanVien.BHYT, NhanVien.TrinhDoHocVan, NhanVien.MaCN.ToString());
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaNV(NhanVien_DTO NhanVien)
        {
            string query = string.Format("UPDATE NhanVien SET MaNV = '{0}', TenNV = N'{1}', GioiTinh = N'{2}', SDT = N'{3}', Email = N'{4}', NgaySinh = '{5:yyyy-MM-dd}', DiaChi = N'{6}', ChucVu = N'{7}', NgayBDLamViec = '{8:yyyy-MM-dd}', MucLuong = {9}, BHYT = '{10}', TrinhDoHocVan = N'{11}', MaCN = '{12}' WHERE MaNV = '{13}'", NhanVien.MaNV, NhanVien.TenNV, NhanVien.GioiTinh, NhanVien.SDT, NhanVien.Email, Convert.ToDateTime(NhanVien.NgaySinh), NhanVien.DiaChi, NhanVien.ChucVu, Convert.ToDateTime(NhanVien.NgayBDLamViec), NhanVien.MucLuong, NhanVien.BHYT, NhanVien.TrinhDoHocVan, NhanVien.MaCN.ToString(), NhanVien.MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoaHD(NhanVien_DTO NhanVien)
        {
            string query = string.Format("SELECT * FROM HoaDon WHERE MaNV = '{0}'", NhanVien.MaNV);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckXoaPHT(NhanVien_DTO NhanVien)
        {
            string query = string.Format("SELECT * FROM PhieuHoanTra WHERE MaNV = '{0}'", NhanVien.MaNV);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool XoaNV(NhanVien_DTO NhanVien)
        {
            string query = string.Format("DELETE NhanVien WHERE MaNV = '{0}'", NhanVien.MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
