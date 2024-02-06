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
    public class PhieuHoanTra_BLL
    {

        private static PhieuHoanTra_BLL instance;

        public static PhieuHoanTra_BLL Instance
        {
            get { if (instance == null) instance = new PhieuHoanTra_BLL(); return instance; }
            private set { instance = value; }
        }
        public PhieuHoanTra_BLL() { }

        
    }
}
