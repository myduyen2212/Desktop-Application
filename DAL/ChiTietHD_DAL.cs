using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace DAL
{
    public class ChiTietHD_DAL
    {
        private static ChiTietHD_DAL instance;

        public static ChiTietHD_DAL Instance
        {
            get { if (instance == null) instance = new ChiTietHD_DAL(); return instance; }
            private set { instance = value; }
        }

        public ChiTietHD_DAL() { }

        
    }
}
