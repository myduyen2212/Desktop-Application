using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVien_BLL
    {
        private static NhanVien_BLL instance;

        public static NhanVien_BLL Instance
        {
            get { if (instance == null) instance = new NhanVien_BLL(); return instance; }
            private set { instance = value; }
        }

        public NhanVien_BLL() { }

        NhanVien_DAL nvDAL = new NhanVien_DAL();

        public DataTable LayDSNV()
        {
            return nvDAL.LayDSNV();
        }

        public DataTable LayDSCN()
        {
            return nvDAL.LayDSCN();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return nvDAL.TimKiem(TuKhoa);
        }

        public DataTable LocCN(string TuKhoa)
        {
            return nvDAL.LocCN(TuKhoa);
        }

        public bool CheckThem(NhanVien_DTO NhanVien)
        {
            if (nvDAL.CheckThem(NhanVien) == false)
            {
                return false;
            }
            if (nvDAL.CheckThem(NhanVien) == true)
            {
                return true;
            }

            return nvDAL.CheckThem(NhanVien);
        }

        public int TaoSTTMaNV()
        {
            int STT = nvDAL.TaoSTTMaNV() + 1;
            return STT;
        }

        public bool ThemNV(NhanVien_DTO NhanVien)
        {
            return nvDAL.ThemNV(NhanVien);
        }

        public bool SuaNV(NhanVien_DTO NhanVien)
        {
            return nvDAL.SuaNV(NhanVien);
        }

        public bool CheckXoaHD(NhanVien_DTO NhanVien)
        {
            if (nvDAL.CheckXoaHD(NhanVien) == false)
            {
                return false;
            }
            if (nvDAL.CheckXoaHD(NhanVien) == true)
            {
                return true;
            }

            return nvDAL.CheckXoaHD(NhanVien);
        }

        public bool CheckXoaPHT(NhanVien_DTO NhanVien)
        {
            if (nvDAL.CheckXoaPHT(NhanVien) == false)
            {
                return false;
            }
            if (nvDAL.CheckXoaPHT(NhanVien) == true)
            {
                return true;
            }

            return nvDAL.CheckXoaPHT(NhanVien);
        }

        public bool XoaNV(NhanVien_DTO NhanVien)
        {
            return nvDAL.XoaNV(NhanVien);
        }
    }
}
