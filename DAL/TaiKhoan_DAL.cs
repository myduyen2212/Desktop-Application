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
    public class TaiKhoan_DAL
    {
        private static TaiKhoan_DAL instance;

        public static TaiKhoan_DAL Instance
        {
            get { if (instance == null) instance = new TaiKhoan_DAL(); return instance; }
            private set { instance = value; }
        }

        public TaiKhoan_DAL() { }

        public DataTable CheckQuyen(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("SELECT NV.ChucVU FROM TaiKhoan TK, NhanVien NV WHERE TK.TenTK = '{0}' AND TK.MaNV = NV.MaNV", TaiKhoan.TenTK);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool CheckTTTK(TaiKhoan_DTO TaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = N'" + TaiKhoan.TenTK + "' AND MatKhau = N'" + TaiKhoan.MatKhau + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool CheckTenTK(TaiKhoan_DTO TaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE TenTK = N'" + TaiKhoan.TenTK + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckMK(TaiKhoan_DTO TaiKhoan)
        {
            string query = "SELECT * FROM TaiKhoan WHERE MatKhau = N'" + TaiKhoan.MatKhau + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckMaNV(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("SELECT * FROM NhanVien WHERE MaNV = '{0}'", TaiKhoan.MaNV);
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckTaiKhoan(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("SELECT * FROM TaiKhoan WHERE MaNV = '{0}'", TaiKhoan.MaNV);
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

        public bool CheckDangKy(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("SELECT * FROM TaiKhoan WHERE TenTK = N'{0}'", TaiKhoan.TenTK);
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

        public int TaoSTTMaTK()
        {
            string query = string.Format("SELECT COUNT(*) FROM TaiKhoan");
            object result = DataProvider.Instance.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        public bool DangKy(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("INSERT INTO TaiKhoan(MaTK, TenTK, MatKhau, MaNV) VALUES ('{0}', N'{1}', N'{2}', N'{3}')", TaiKhoan.MaTK, TaiKhoan.TenTK, TaiKhoan.MatKhau, TaiKhoan.MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DoiMatKhau(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("UPDATE Taikhoan SET MatKhau = N'{0}' WHERE TenTK = N'{1}'", TaiKhoan.MatKhau, TaiKhoan.TenTK);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public DataTable LayDSTK()
        {
            string query = "SELECT MaTK, MaNV FROM TaiKhoan";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable TimKiem(string TuKhoa)
        {
            string query = string.Format("SELECT MaTK, TenTK, MaNV FROM TaiKhoan WHERE MaTK LIKE '%{0}%' OR MaNV LIKE '%{0}%'", TuKhoa);
            return DataProvider.Instance.ExecuteQuery(query);
        }
        
        public bool XoaTaiKhoan(TaiKhoan_DTO TaiKhoan)
        {
            string query = string.Format("DELETE Taikhoan WHERE MaTK = N'{0}'", TaiKhoan.MaTK);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

