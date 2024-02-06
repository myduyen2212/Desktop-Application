using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DBConnect
    {
        // Tạo biến strConnection kiểu string
        string strConnection;

        // Khai báo chuỗi kết nối DBConnect đến cơ sở dữ liệu QLBH_MIEU trong SQL Server
        public DBConnect()
        {
            strConnection = "Data Source=WIN10PRO\\SQLSVR;Initial Catalog=QLBH_MIEU;Integrated Security=True";
        }

        // Khởi tạo chuỗi kết nối KetNoi đến cơ sở dữ liệu 
        public SqlConnection Connect()
        {
            return new SqlConnection(strConnection);
        }
    }
}
