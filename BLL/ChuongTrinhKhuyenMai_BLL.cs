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
    public class ChuongTrinhKhuyenMai_BLL
    {
        private static ChuongTrinhKhuyenMai_BLL instance;

        public static ChuongTrinhKhuyenMai_BLL Instance
        {
            get { if (instance == null) instance = new ChuongTrinhKhuyenMai_BLL(); return instance; }
            private set { instance = value; }
        }

        public ChuongTrinhKhuyenMai_BLL() { }

        ChuongTrinhKhuyenMai_DAL ctkmDAL = new ChuongTrinhKhuyenMai_DAL();

        public DataTable LayDSCTKM()
        {
            return ctkmDAL.LayDSCTKM();
        }

        public DataTable TimKiemCTKMMaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.TimKiemCTKMMaCTKM(ChuongTrinhKhuyenMai);
        }

        public DataTable TimKiemCTKMTenCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.TimKiemCTKMTenCTKM(ChuongTrinhKhuyenMai);
        }

        public DataTable TimKiemCTKMNgayBD(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.TimKiemCTKMNgayBD(ChuongTrinhKhuyenMai);
        }

        public bool CheckThem(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            if (ctkmDAL.CheckThem(ChuongTrinhKhuyenMai) == false)
            {
                return false;
            }
            if (ctkmDAL.CheckThem(ChuongTrinhKhuyenMai) == true)
            {
                return true;
            }

            return ctkmDAL.CheckThem(ChuongTrinhKhuyenMai);
        }

        public int TaoSTTMaCTKM()
        {
            int STT = ctkmDAL.TaoSTTMaCTKM() + 1;
            return STT;
        }

        public bool ThemCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.ThemCTKM(ChuongTrinhKhuyenMai);
        }

        public bool SuaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.SuaCTKM(ChuongTrinhKhuyenMai);
        }

        public bool CheckXoa(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            if (ctkmDAL.CheckXoa(ChuongTrinhKhuyenMai) == false)
            {
                return false;
            }
            if (ctkmDAL.CheckXoa(ChuongTrinhKhuyenMai) == true)
            {
                return true;
            }

            return ctkmDAL.CheckXoa(ChuongTrinhKhuyenMai);
        }

        public bool XoaCTKM(ChuongTrinhKhuyenMai_DTO ChuongTrinhKhuyenMai)
        {
            return ctkmDAL.XoaCTKM(ChuongTrinhKhuyenMai);
        }
    }
}
