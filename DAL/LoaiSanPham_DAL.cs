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
    public class LoaiSanPham_DAL
    {
        private static LoaiSanPham_DAL instance;

        public static LoaiSanPham_DAL Instance
        {
            get { if (instance == null) instance = new LoaiSanPham_DAL(); return instance; }
            private set { instance = value; }
        }

        public LoaiSanPham_DAL() { }

        public DataTable LayDSLSP()
        {
            string query = "SELECT * FROM LoaiSanPham";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT * FROM LoaiSanPham WHERE MaLSP LIKE '%{0}%' OR TenLSP LIKE N'%{0}%'", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }       

        public bool CheckThem(LoaiSanPham_DTO LoaiSanPham)
        {
            string query = string.Format("SELECT * FROM LoaiSanPham WHERE TenLSP = N'{0}'", LoaiSanPham.TenLSP);
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

        public int TaoSTTMaLSP()
        {
            string query = string.Format("SELECT COUNT(*) FROM LoaiSanPham");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            string query = string.Format("INSERT INTO LoaiSanPham(MaLSP, TenLSP) VALUES ('{0}', N'{1}')", LoaiSanPham.MaLSP, LoaiSanPham.TenLSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            string query = string.Format("UPDATE LoaiSanPham SET MaLSP = '{0}', TenLSP = N'{1}' WHERE MaLSP = '{2}'", LoaiSanPham.MaLSP, LoaiSanPham.TenLSP, LoaiSanPham.MaLSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoa(LoaiSanPham_DTO LoaiSanPham)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE MaLSP = '{0}'", LoaiSanPham.MaLSP);
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

        public bool XoaLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            string query = string.Format("DELETE LoaiSanPham WHERE MaLSP = '{0}'", LoaiSanPham.MaLSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
