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
    public class HoaDon_BLL
    {
        private static HoaDon_BLL instance;

        public static HoaDon_BLL Instance
        {
            get { if (instance == null) instance = new HoaDon_BLL(); return instance; }
            private set { instance = value; }
        }

        public HoaDon_BLL() { }

        
    }
}
