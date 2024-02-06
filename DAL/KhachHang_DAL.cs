using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace DAL
{
    public class KhachHang_DAL
    {
        private static KhachHang_DAL instance;

        public static KhachHang_DAL Instance
        {
            get { if (instance == null) instance = new KhachHang_DAL(); return instance; }
            private set { instance = value; }
        }

        public KhachHang_DAL() { }

        public DataTable LayDSKH()
        {
            string query = "SELECT * FROM KhachHang";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT * FROM KhachHang WHERE MaKH LIKE '%{0}%' OR TenKH LIKE N'%{0}%' OR SDT LIKE N'%{0}%'", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool CheckThem(KhachHang_DTO KhachHang)
        {
            string query = string.Format("SELECT * FROM KhachHang WHERE TenKH = N'{0}' AND SDT = N'{1}'", KhachHang.TenKH, KhachHang.SDT);
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

        public int TaoSTTMaKH()
        {
            string query = string.Format("SELECT COUNT(*) FROM KhachHang");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemKH(KhachHang_DTO KhachHang)
        {
            string query = string.Format("INSERT INTO KhachHang(MaKH, TenKH, GioiTinh, SDT, NgaySinh, DiaChi, Email) VALUES ('{0}', N'{1}', N'{2}', N'{3}', '{4:yyyy-MM-dd}', N'{5}', N'{6}')", KhachHang.MaKH, KhachHang.TenKH, KhachHang.GioiTinh, KhachHang.SDT, Convert.ToDateTime(KhachHang.NgaySinh), KhachHang.DiaChi, KhachHang.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaKH(KhachHang_DTO KhachHang)
        {
            string query = string.Format("UPDATE KhachHang SET MaKH = '{0}', TenKH = N'{1}', GioiTinh = N'{2}', SDT = N'{3}', NgaySinh = '{4:yyyy-MM-dd}', DiaChi = N'{5}', Email = N'{6}' WHERE MaKH = '{7}'", KhachHang.MaKH, KhachHang.TenKH, KhachHang.GioiTinh, KhachHang.SDT, Convert.ToDateTime(KhachHang.NgaySinh), KhachHang.DiaChi, KhachHang.Email, KhachHang.MaKH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoaHD(KhachHang_DTO KhachHang)
        {
            string query = string.Format("SELECT * FROM HoaDon WHERE MaKH = '{0}'", KhachHang.MaKH);
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

        public bool CheckXoaPHT(KhachHang_DTO KhachHang)
        {
            string query = string.Format("SELECT * FROM PhieuHoanTra WHERE MaKH = '{0}'", KhachHang.MaKH);
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

        public bool XoaKH(KhachHang_DTO KhachHang)
        {
            string query = string.Format("DELETE KhachHang WHERE MaKH = '{0}'", KhachHang.MaKH);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
