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
    public class NhaCungCap_DAL
    {
        private static NhaCungCap_DAL instance;

        public static NhaCungCap_DAL Instance
        {
            get { if (instance == null) instance = new NhaCungCap_DAL(); return instance; }
            private set { instance = value; }
        }

        public NhaCungCap_DAL() { }

        public DataTable LayDSNCC()
        {
            string query = "SELECT * FROM NhaCungCap";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT * FROM NhaCungCap WHERE MaNCC LIKE '%{0}%' OR TenNCC LIKE N'%{0}%' OR DiaChi LIKE N'%{0}%' OR SDT LIKE N'%{0}%'", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool CheckThem(NhaCungCap_DTO NhaCungCap)
        {
            string query = string.Format("SELECT * FROM NhaCungCap WHERE TenNCC = N'{0}' AND SDT = N'{1}' AND DiaChi = N'{2}' AND Email = N'{3}'", NhaCungCap.TenNCC, NhaCungCap.SDT, NhaCungCap.DiaChi, NhaCungCap.Email);
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

        public int TaoSTTMaNCC()
        {
            string query = string.Format("SELECT COUNT(*) FROM NhaCungCap");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemNCC(NhaCungCap_DTO NhaCungCap)
        {
            string query = string.Format("INSERT INTO NhaCungCap(MaNCC, TenNCC, SDT, DiaChi, Email) VALUES ('{0}', N'{1}', N'{2}', N'{3}', N'{4}')", NhaCungCap.MaNCC, NhaCungCap.TenNCC, NhaCungCap.SDT, NhaCungCap.DiaChi, NhaCungCap.Email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaNCC(NhaCungCap_DTO NhaCungCap)
        {
            string query = string.Format("UPDATE NhaCungCap SET MaNCC = '{0}', TenNCC = N'{1}', SDT = N'{2}', DiaChi = N'{3}', Email = N'{4}' WHERE MaNCC = '{5}'", NhaCungCap.MaNCC, NhaCungCap.TenNCC, NhaCungCap.SDT, NhaCungCap.DiaChi, NhaCungCap.Email, NhaCungCap.MaNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoa(NhaCungCap_DTO NhaCungCap)
        {
            string query = string.Format("SELECT * FROM SanPham WHERE MaNCC = '{0}'", NhaCungCap.MaNCC);
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

        public bool XoaNCC(NhaCungCap_DTO NhaCungCap)
        {
            string query = string.Format("DELETE NhaCungCap WHERE MaNCC = '{0}'", NhaCungCap.MaNCC);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
