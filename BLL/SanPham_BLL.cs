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
    public class SanPham_BLL
    {
        private static SanPham_BLL instance;

        public static SanPham_BLL Instance
        {
            get { if (instance == null) instance = new SanPham_BLL(); return instance; }
            private set { instance = value; }
        }

        public SanPham_BLL() { }

        SanPham_DAL spDAL = new SanPham_DAL();              

        public DataTable LayDSSP()
        {
            return spDAL.LayDSSP();
        }

        public DataTable LayDSNCC()
        {
            return spDAL.LayDSNCC();
        }

        public DataTable LayDSLSP()
        {
            return spDAL.LayDSLSP();
        }

        public DataTable LayDSCN()
        {
            return spDAL.LayDSCN();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return spDAL.TimKiem(TuKhoa);
        }

        public DataTable LocNCC(string TuKhoa)
        {
            return spDAL.LocNCC(TuKhoa);
        }

        public DataTable LocLSP(string TuKhoa)
        {
            return spDAL.LocLSP(TuKhoa);
        }

        public bool CheckThem(SanPham_DTO SanPham)
        {
            if (spDAL.CheckThem(SanPham) == false)
            {
                return false;
            }
            if (spDAL.CheckThem(SanPham) == true)
            {
                return true;
            }

            return spDAL.CheckThem(SanPham);
        }

        public int TaoSTTMaSP()
        {
            int STT = spDAL.TaoSTTMaSP() + 1;
            return STT;
        }

        public bool ThemSP(SanPham_DTO SanPham)
        {
            return spDAL.ThemSP(SanPham);
        }

        public bool ThemTKSP(SanPham_DTO SanPham, TonKho_DTO TonKho)
        {
            return spDAL.ThemTKSP(SanPham, TonKho);
        }

        public bool SuaSP(SanPham_DTO SanPham)
        {
            return spDAL.SuaSP(SanPham);
        }

        public bool SuaTKSP(SanPham_DTO SanPham, TonKho_DTO TonKho)
        {
            return spDAL.SuaTKSP(SanPham, TonKho);
        }

        public bool CheckXoaCTHD(SanPham_DTO SanPham)
        {
            if (spDAL.CheckXoaCTHD(SanPham) == false)
            {
                return false;
            }
            if (spDAL.CheckXoaCTHD(SanPham) == true)
            {
                return true;
            }

            return spDAL.CheckXoaCTHD(SanPham);
        }

        public bool CheckXoaCTPHT(SanPham_DTO SanPham)
        {
            if (spDAL.CheckXoaCTPHT(SanPham) == false)
            {
                return false;
            }
            if (spDAL.CheckXoaCTPHT(SanPham) == true)
            {
                return true;
            }

            return spDAL.CheckXoaCTPHT(SanPham);
        }
        
        public bool XoaTKSP(SanPham_DTO SanPham)
        {
            return spDAL.XoaTKSP(SanPham);
        }

        public bool XoaSP(SanPham_DTO SanPham)
        {
            return spDAL.XoaSP(SanPham);
        }
    }
}
