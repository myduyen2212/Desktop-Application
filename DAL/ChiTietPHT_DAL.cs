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
    public class ChiTietPHT_DAL
    {
        private static ChiTietPHT_DAL instance;

        public static ChiTietPHT_DAL Instance
        {
            get { if (instance == null) instance = new ChiTietPHT_DAL(); return instance; }
            private set { instance = value; }
        }

        public ChiTietPHT_DAL() { }

        
    }
}
