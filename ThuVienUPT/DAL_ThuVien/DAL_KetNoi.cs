using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_ThuVien
{
    class DAL_KetNoi
    {
        public SqlConnection KetNoi()
        {
            SqlConnection _con = new SqlConnection(@"Data Source=TDK\TDK;Initial Catalog=ThuVienUPT;Integrated Security=True");
            return _con;
        }
  
    }
}
