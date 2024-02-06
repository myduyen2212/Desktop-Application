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
    public class ChiNhanh_BLL
    {
        private static ChiNhanh_BLL instance;

        public static ChiNhanh_BLL Instance
        {
            get { if (instance == null) instance = new ChiNhanh_BLL(); return instance; }
            private set { instance = value; }
        }

        public ChiNhanh_BLL() { }

        ChiNhanh_DAL cnDAL = new ChiNhanh_DAL();

        public DataTable LayDSCN()
        {
            return cnDAL.LayDSCN();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return cnDAL.TimKiem(TuKhoa);
        }

        public bool CheckThem(ChiNhanh_DTO ChiNhanh)
        {
            if (cnDAL.CheckThem(ChiNhanh) == false)
            {
                return false;
            }
            if (cnDAL.CheckThem(ChiNhanh) == true)
            {
                return true;
            }

            return cnDAL.CheckThem(ChiNhanh);
        }

        public int TaoSTTMaCN()
        {
            int STT = cnDAL.TaoSTTMaCN() + 1;
            return STT;
        }

        public bool ThemCN(ChiNhanh_DTO ChiNhanh)
        {
            return cnDAL.ThemCN(ChiNhanh);
        }

        public bool SuaCN(ChiNhanh_DTO ChiNhanh)
        {
            return cnDAL.SuaCN(ChiNhanh);
        }

        public bool CheckXoaNV(ChiNhanh_DTO ChiNhanh)
        {
            if (cnDAL.CheckXoaNV(ChiNhanh) == false)
            {
                return false;
            }
            if (cnDAL.CheckXoaNV(ChiNhanh) == true)
            {
                return true;
            }

            return cnDAL.CheckXoaNV(ChiNhanh);
        }

        public bool CheckXoaTK(ChiNhanh_DTO ChiNhanh)
        {
            if (cnDAL.CheckXoaTK(ChiNhanh) == false)
            {
                return false;
            }
            if (cnDAL.CheckXoaTK(ChiNhanh) == true)
            {
                return true;
            }

            return cnDAL.CheckXoaTK(ChiNhanh);
        }

        public bool XoaCN(ChiNhanh_DTO ChiNhanh)
        {
            return cnDAL.XoaCN(ChiNhanh);
        }
    }
}
