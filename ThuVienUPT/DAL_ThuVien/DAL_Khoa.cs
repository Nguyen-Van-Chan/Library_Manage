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
    public class DAL_Khoa
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable KhoaGet()
        {
            SqlCommand cmd = new SqlCommand("sp_KhoaSelect", kn.KetNoi());
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
        public DataTable KhoaModify(DTO_Khoa khoa)
        {
            SqlCommand cmd = new SqlCommand("sp_khoaModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", khoa.Id);
            cmd.Parameters.AddWithValue("@tenkhoa", khoa.Tenkhoa);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable KhoaDelete(DTO_Khoa khoa)
        {
            SqlCommand cmd = new SqlCommand("sp_KhoaDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", khoa.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
