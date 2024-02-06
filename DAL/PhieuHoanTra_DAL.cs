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
    public class PhieuHoanTra_DAL
    {
        private static PhieuHoanTra_DAL instance;

        public static PhieuHoanTra_DAL Instance
        {
            get { if (instance == null) instance = new PhieuHoanTra_DAL(); return instance; }
            private set { instance = value; }
        }

        public PhieuHoanTra_DAL() { }

        
    }
}
