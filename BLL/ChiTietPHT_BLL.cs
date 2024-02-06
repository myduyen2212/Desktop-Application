using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPHT_BLL
    {
        private static ChiTietPHT_BLL instance;

        public static ChiTietPHT_BLL Instance
        {
            get { if (instance == null) instance = new ChiTietPHT_BLL(); return instance; }
            private set { instance = value; }
        }
        ChiTietPHT_DAL chiTietPHTDAL = new ChiTietPHT_DAL();

        public ChiTietPHT_BLL() { }

        
    }
}
