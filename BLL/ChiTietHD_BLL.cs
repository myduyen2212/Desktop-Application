using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietHD_BLL
    {
        private static ChiTietHD_BLL instance;

        public static ChiTietHD_BLL Instance
        {
            get { if (instance == null) instance = new ChiTietHD_BLL(); return instance; }
            private set { instance = value; }
        }
        public ChiTietHD_BLL() { }

        ChiTietHD_DAL chiTietHD_DAL = new ChiTietHD_DAL();

        

    }
}
