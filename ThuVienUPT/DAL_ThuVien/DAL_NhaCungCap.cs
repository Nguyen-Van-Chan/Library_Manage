using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_ThuVien;

namespace DAL_ThuVien
{
  public class DAL_NhaCungCap
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable NhaCungCapGet()
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapSelect", kn.KetNoi());
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
        public DataTable NhaCungCapModify(DTO_NhaCungCap ncc)
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ncc.Id);
            cmd.Parameters.AddWithValue("@tennhacungcap", ncc.Tenhacungcap);
            cmd.Parameters.AddWithValue("@diachi", ncc.Diachi);
            cmd.Parameters.AddWithValue("@dienthoai", ncc.Dienthoai);
            cmd.Parameters.AddWithValue("@fax", ncc.Fax);
            cmd.Parameters.AddWithValue("@email", ncc.Email);
            cmd.Parameters.AddWithValue("@website", ncc.Website);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NhaCungCapDelete(DTO_NhaCungCap ncc)
        {
            SqlCommand cmd = new SqlCommand("sp_NhaCungCapDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ncc.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
