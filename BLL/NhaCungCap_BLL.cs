using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        private static NhaCungCap_BLL instance;

        public static NhaCungCap_BLL Instance
        {
            get { if (instance == null) instance = new NhaCungCap_BLL(); return instance; }
            private set { instance = value; }
        }

        public NhaCungCap_BLL() { }

        NhaCungCap_DAL nccDAL = new NhaCungCap_DAL();

        public DataTable LayDSNCC()
        {
            return nccDAL.LayDSNCC();
        }

        public DataTable TimKiem(string TuKhoa)
        {
            return nccDAL.TimKiem(TuKhoa);
        }
        
        public bool CheckThem(NhaCungCap_DTO NhaCungCap)
        {
            if (nccDAL.CheckThem(NhaCungCap) == false)
            {
                return false;
            }
            if (nccDAL.CheckThem(NhaCungCap) == true)
            {
                return true;
            }

            return nccDAL.CheckThem(NhaCungCap);
        }

        public int TaoSTTMaNCC()
        {
            int STT = nccDAL.TaoSTTMaNCC() + 1;
            return STT;
        }

        public bool ThemNCC(NhaCungCap_DTO NhaCungCap)
        {
            return nccDAL.ThemNCC(NhaCungCap);
        }

        public bool SuaNCC(NhaCungCap_DTO NhaCungCap)
        {
            return nccDAL.SuaNCC(NhaCungCap);
        }

        public bool CheckXoa(NhaCungCap_DTO NhaCungCap)
        {
            if (nccDAL.CheckXoa(NhaCungCap) == false)
            {
                return false;
            }
            if (nccDAL.CheckXoa(NhaCungCap) == true)
            {
                return true;
            }

            return nccDAL.CheckXoa(NhaCungCap);
        }

        public bool XoaNCC(NhaCungCap_DTO NhaCungCap)
        {
            return nccDAL.XoaNCC(NhaCungCap);
        }
    }
}
