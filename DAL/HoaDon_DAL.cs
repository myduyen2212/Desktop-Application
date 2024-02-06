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
    public class HoaDon_DAL
    {
        private static HoaDon_DAL instance;

        public static HoaDon_DAL Instance
        {
            get { if (instance == null) instance = new HoaDon_DAL(); return instance; }
            private set { instance = value; }
        }

        public HoaDon_DAL() { }

        
    }
}
