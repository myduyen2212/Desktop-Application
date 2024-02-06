using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL;

namespace BLL
{
    public class TaiKhoan_BLL
    {
        private static TaiKhoan_BLL instance;

        public static TaiKhoan_BLL Instance
        {
            get { if (instance == null) instance = new TaiKhoan_BLL(); return instance; }
            private set { instance = value; }
        }

        public TaiKhoan_BLL() { }

        TaiKhoan_DAL tkDAL = new TaiKhoan_DAL();

        public DataTable CheckQuyen(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckQuyen(TaiKhoan);
        }

        public bool CheckTTTK(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckTTTK(TaiKhoan);
        }

        public bool CheckTenTK(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckTenTK(TaiKhoan);
        }

        public bool CheckMK(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckMK(TaiKhoan);
        }

        public bool CheckMaNV(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckMaNV(TaiKhoan);
        }

        public bool CheckTaiKhoan(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.CheckTaiKhoan(TaiKhoan);
        }

        public bool CheckDangKy(TaiKhoan_DTO TaiKhoan)
        {
            if (tkDAL.CheckDangKy(TaiKhoan) == false)
            {
                return false;
            }
            if (tkDAL.CheckDangKy(TaiKhoan) == true)
            {
                return true;
            }

            return tkDAL.CheckDangKy(TaiKhoan);
        }

        public int TaoSTTMaTK()
        {
            int STT = tkDAL.TaoSTTMaTK() + 1;
            return STT;
        }

        public bool DangKy(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.DangKy(TaiKhoan);
        }

        public bool DoiMatKhau(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.DoiMatKhau(TaiKhoan);
        }

        public DataTable LayDSTK()
        {
            return tkDAL.LayDSTK();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return tkDAL.TimKiem(TuKhoa);
        }
        
        public bool XoaTaiKhoan(TaiKhoan_DTO TaiKhoan)
        {
            return tkDAL.XoaTaiKhoan(TaiKhoan);
        }
    }
}