using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
namespace shop
{
    public  class db
    {
        public static DataTable bind(string s)
        {
            string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
            SqlConnection conn = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter(s,conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        
        }
    }
}
