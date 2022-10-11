using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ThuVien;
using System.Data.SqlClient;
using System.Data;
using DTO_ThuVien;
namespace DAL_ThuVien
{
   
   public  class DAL_KeSach
    {
        DAL_KetNoi kn = new DAL_KetNoi();

        public DataTable KeSachGet()
        {
            SqlCommand cmd = new SqlCommand("sp_KeSelect", kn.KetNoi());
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
        public DataTable KeSachModify(DTO_KeSach ke)
        {
            SqlCommand cmd = new SqlCommand("sp_KeModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ke.Id);
            cmd.Parameters.AddWithValue("@tenke", ke.Tenke);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable KeDelete(DTO_KeSach ke)
        {
            SqlCommand cmd = new SqlCommand("sp_KeDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ke.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
