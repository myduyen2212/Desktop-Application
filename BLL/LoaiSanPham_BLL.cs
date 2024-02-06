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
    public class LoaiSanPham_BLL
    {
        private static LoaiSanPham_BLL instance;

        public static LoaiSanPham_BLL Instance
        {
            get { if (instance == null) instance = new LoaiSanPham_BLL(); return instance; }
            private set { instance = value; }
        }

        public LoaiSanPham_BLL() { }

        LoaiSanPham_DAL lspDAL = new LoaiSanPham_DAL();

        public DataTable LayDSLSP()
        {
            return lspDAL.LayDSLSP();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return lspDAL.TimKiem(TuKhoa);
        }
        
        public bool CheckThem(LoaiSanPham_DTO LoaiSanPham)
        {
            return lspDAL.CheckThem(LoaiSanPham);
        }

        public int TaoSTTMaLSP()
        {
            int STT = lspDAL.TaoSTTMaLSP() + 1;
            return STT;
        }

        public bool ThemLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            return lspDAL.ThemLSP(LoaiSanPham);
        }

        public bool SuaLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            return lspDAL.SuaLSP(LoaiSanPham);
        }

        public bool CheckXoa(LoaiSanPham_DTO LoaiSanPham)
        {
            return lspDAL.CheckXoa(LoaiSanPham);
        }               

        public bool XoaLSP(LoaiSanPham_DTO LoaiSanPham)
        {
            return lspDAL.XoaLSP(LoaiSanPham);
        }
    }
}
