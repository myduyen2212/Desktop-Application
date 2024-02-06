using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL
{
    public class DataProvider
    {
        // Tạo một đối tượng instance kiểu static 
        private static DataProvider instance;

        // Triển khai đóng gói mẫu Singleton Pattern, đảm bảo chỉ có một thể hiện của lớp DataProvider được tạo ra
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        // Constructor của lớp DataProvider, được đặt là private để không thể tạo đối tượng DataProvider từ bên ngoài lớp
        private DataProvider() { }

        // Định nghĩa phương thức ExecuteQuery để thực hiện truy vấn SELECT và trả về một DataTable
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            // Tạo một đối tượng DataTable để lưu trữ dữ liệu kết quả
            DataTable data = new DataTable();
            // Tạo một đối tượng Chuoiketnoi trong lớp DBConnect để có chuỗi kết nối đến cơ sở dữ liệu
            DBConnect ChuoiKetNoi = new DBConnect();

            // Sử dụng câu lệnh using để đảm bảo rằng đối tượng SqlConnection sẽ được giải phóng sau khi sử dụng
            using (SqlConnection conn = ChuoiKetNoi.Connect())
            {
                // Mở kết nối
                conn.Open();

                // Mở kết nối đến cơ sở dữ liệu và tạo một đối tượng SqlCommand với câu truy vấn query và kết nối conn
                SqlCommand command = new SqlCommand(query, conn);

                // Nếu có tham số, thêm các tham số vào câu truy vấn bằng cách sử dụng Parameters.AddWithValue
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                /* Tạo một đối tượng SqlDataAdapter tên là adapter và sử dụng nó để vận chuyển dữ liệu được lấy thông qua 
                   câu truy vấn query trong command đổ vào DataTable */
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                // Đóng kết nối
                conn.Close();
            }

            // Trả về DataTable
            return data;
        }

        // Định nghĩa phương thức ExecuteNonQuery để thực hiện các truy vấn không trả về dữ liệu(INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            // Tạo biến data kiểu int
            int data = 0;

            DBConnect ChuoiKetNoi = new DBConnect();

            using (SqlConnection conn = ChuoiKetNoi.Connect())
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                conn.Close();
            }

            // Trả về số lượng dòng ảnh hưởng vào biến data
            return data;
        }

        // Định nghĩa phương thức ExecuteScalar để thực hiện một truy vấn và trả về giá trị của ô đầu tiên trong kết quả
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            // Tạo biến data kiểu object
            object data = 0;

            DBConnect ChuoiKetNoi = new DBConnect();

            using (SqlConnection conn = ChuoiKetNoi.Connect())
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                conn.Close();
            }

            // Trả về giá trị ô đầu tiên của kết quả truy vấn vào biến data
            return data;
        }
        
    }
}
