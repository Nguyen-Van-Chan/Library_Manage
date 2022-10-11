using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO_ThuVien;

namespace DAL_ThuVien
{
  public  class DAL_Lop
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable LopGet()
        {
            SqlCommand cmd = new SqlCommand("sp_LopSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SelectIDMax(string table)
        {
            SqlCommand cmd = new SqlCommand("sp_SelectIDMax", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@table", table);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LopModify(DTO_Lop lop)
        {
            SqlCommand cmd = new SqlCommand("sp_LopModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@malop", lop.Malop);
            cmd.Parameters.AddWithValue("@tenlop", lop.Tenlop);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LopDelete(DTO_Lop lop)
        {
            SqlCommand cmd = new SqlCommand("sp_LopDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@malop", lop.Malop);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
