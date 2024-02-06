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
    public class ChiNhanh_DAL
    {
        private static ChiNhanh_DAL instance;

        public static ChiNhanh_DAL Instance
        {
            get { if (instance == null) instance = new ChiNhanh_DAL(); return instance; }
            private set { instance = value; }
        }

        public ChiNhanh_DAL() { }

        public DataTable LayDSCN()
        {
            string query = "SELECT * FROM ChiNhanh";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT * FROM ChiNhanh WHERE MaCN LIKE '%{0}%' OR TenCN LIKE N'%{0}%' OR DiaChi LIKE N'%{0}%'", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool CheckThem(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("SELECT * FROM ChiNhanh WHERE TenCN = N'{0}' AND DiaChi = N'{1}'", ChiNhanh.TenCN, ChiNhanh.DiaChi);
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

        public int TaoSTTMaCN()
        {
            string query = string.Format("SELECT COUNT(*) FROM ChiNhanh");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool ThemCN(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("INSERT INTO ChiNhanh(MaCN, TenCN, DiaChi) VALUES ('{0}', N'{1}', N'{2}')", ChiNhanh.MaCN, ChiNhanh.TenCN, ChiNhanh.DiaChi);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool SuaCN(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("UPDATE ChiNhanh SET MaCN = '{0}', TenCN = N'{1}', DiaChi = N'{2}' WHERE MaCN = '{3}'", ChiNhanh.MaCN, ChiNhanh.TenCN, ChiNhanh.DiaChi, ChiNhanh.MaCN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool CheckXoaNV(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE MaCN = '{0}'", ChiNhanh.MaCN);
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

        public bool CheckXoaTK(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("SELECT * FROM TonKho WHERE MaCN = '{0}'", ChiNhanh.MaCN);
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

        public bool XoaCN(ChiNhanh_DTO ChiNhanh)
        {
            string query = string.Format("DELETE ChiNhanh WHERE MaCN = '{0}'", ChiNhanh.MaCN);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
