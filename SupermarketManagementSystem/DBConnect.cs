using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem
{
    class DBConnect
    {
        SqlConnection sc;
        public SqlConnection Connect()                                  //建立数据库连接
        {
            string str = "Server=localhost;Database=SupermarketSystem;Trusted_Connection=true;";
            sc = new SqlConnection(str);                                //sc.ConnectionString = "Data Source=XXX;Initial Catalog=SurpermartkerSystem;Integrated Security=True";
            sc.Open();

            return sc;
        }
        public SqlCommand Command(string sql)                           //数据库操作
        {
            SqlCommand cmd = new SqlCommand(sql, Connect());
            return cmd;
        }
        public int Execute(string sql)                                  //更新
        {
            return Command(sql).ExecuteNonQuery();                      //受影响行数
        }
        public SqlDataReader Read(string sql)                           //读取
        {
            return Command(sql).ExecuteReader();
        }
        public void Close()                                             //关闭数据库连接
        {
            sc.Close(); 
        }
    }

}
