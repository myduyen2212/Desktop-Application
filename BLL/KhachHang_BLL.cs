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
    public class KhachHang_BLL
    {
        private static KhachHang_BLL instance;

        public static KhachHang_BLL Instance
        {
            get { if (instance == null) instance = new KhachHang_BLL(); return instance; }
            private set { instance = value; }
        }

        public KhachHang_BLL() { }

        KhachHang_DAL khDAL = new KhachHang_DAL();

        public DataTable LayDSKH()
        {
            return khDAL.LayDSKH();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return khDAL.TimKiem(TuKhoa);
        }
        

        public bool CheckThem(KhachHang_DTO KhachHang)
        {
            if (khDAL.CheckThem(KhachHang) == false)
            {
                return false;
            }
            if (khDAL.CheckThem(KhachHang) == true)
            {
                return true;
            }

            return khDAL.CheckThem(KhachHang);
        }

        public int TaoSTTMaKH()
        {
            int STT = khDAL.TaoSTTMaKH() + 1;
            return STT;
        }

        public bool ThemKH(KhachHang_DTO KhachHang)
        {
            return khDAL.ThemKH(KhachHang);
        }

        public bool SuaKH(KhachHang_DTO KhachHang)
        {
            return khDAL.SuaKH(KhachHang);
        }

        public bool CheckXoaHD(KhachHang_DTO KhachHang)
        {
            if (khDAL.CheckXoaHD(KhachHang) == false)
            {
                return false;
            }
            if (khDAL.CheckXoaHD(KhachHang) == true)
            {
                return true;
            }

            return khDAL.CheckXoaHD(KhachHang);
        }

        public bool CheckXoaPHT(KhachHang_DTO KhachHang)
        {
            if (khDAL.CheckXoaPHT(KhachHang) == false)
            {
                return false;
            }
            if (khDAL.CheckXoaPHT(KhachHang) == true)
            {
                return true;
            }

            return khDAL.CheckXoaPHT(KhachHang);
        }

        public bool XoaKH(KhachHang_DTO KhachHang)
        {
            return khDAL.XoaKH(KhachHang);
        }
    }
}
