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
    public class ChuongTrinhKhuyenMai_DAL
    {
        private static ChuongTrinhKhuyenMai_DAL instance;

        public static ChuongTrinhKhuyenMai_DAL Instance
        {
            get { if (instance == null) instance = new ChuongTrinhKhuyenMai_DAL(); return instance; }
            private set { instance = value; }
        }

        public ChuongTrinhKhuyenMai_DAL() { }

        public DataTable LayDSCTKM()
        {
            string query = "SELECT * FROM ChuongTrinhKhuyenMai";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiemCTKMMaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("SELECT * FROM ChuongTrinhKhuyenMai WHERE MaCTKM LIKE '%{0}%'", ChuongTrinhKhuyenMai.MaCTKM);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiemCTKMTenCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("SELECT * FROM ChuongTrinhKhuyenMai WHERE TenCTKM LIKE N'%{0}%'", ChuongTrinhKhuyenMai.TenCTKM);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiemCTKMNgayBD(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("SELECT * FROM ChuongTrinhKhuyenMai WHERE NgayBDCTKM LIKE N'%{0:yyyy-MM-dd}%'", Convert.ToDateTime(ChuongTrinhKhuyenMai.NgayBDCTKM));
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool CheckThem(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("SELECT * FROM ChuongTrinhKhuyenMai WHERE TenCTKM = N'{0}' AND NgayBDCTKM = '{1:yyyy-MM-dd}'AND NgayKTCTKM = '{2:yyyy-MM-dd}' AND ChietKhau = {3}", ChuongTrinhKhuyenMai.TenCTKM, ChuongTrinhKhuyenMai.NgayBDCTKM, ChuongTrinhKhuyenMai.NgayKTCTKM, ChuongTrinhKhuyenMai.ChietKhau);
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

        public int TaoSTTMaCTKM()
        {
            string query = string.Format("SELECT COUNT(*) FROM ChuongTrinhKhuyenMai");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("INSERT INTO ChuongTrinhKhuyenMai(MaCTKM, TenCTKM, NgayBDCTKM, NgayKTCTKM, ChietKhau) VALUES ('{0}', N'{1}', '{2:yyyy-MM-dd}', '{3:yyyy-MM-dd}', {4})", ChuongTrinhKhuyenMai.MaCTKM, ChuongTrinhKhuyenMai.TenCTKM, Convert.ToDateTime(ChuongTrinhKhuyenMai.NgayBDCTKM), Convert.ToDateTime(ChuongTrinhKhuyenMai.NgayKTCTKM), ChuongTrinhKhuyenMai.ChietKhau);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("UPDATE ChuongTrinhKhuyenMai SET MaCTKM = '{0}', TenCTKM = N'{1}', NgayBDCTKM = N'{2:yyyy-MM-dd}', NgayKTCTKM = N'{3:yyyy-MM-dd}', ChietKhau = {4} WHERE MaCTKM = '{5}'", ChuongTrinhKhuyenMai.MaCTKM, ChuongTrinhKhuyenMai.TenCTKM, Convert.ToDateTime(ChuongTrinhKhuyenMai.NgayBDCTKM), Convert.ToDateTime(ChuongTrinhKhuyenMai.NgayKTCTKM), ChuongTrinhKhuyenMai.ChietKhau, ChuongTrinhKhuyenMai.MaCTKM);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoa(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("SELECT * FROM HoaDon WHERE MaCTKM = '{0}'", ChuongTrinhKhuyenMai.MaCTKM);
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

        public bool XoaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            string query = string.Format("DELETE ChuongTrinhKhuyenMai WHERE MaCTKM = '{0}'", ChuongTrinhKhuyenMai.MaCTKM);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
