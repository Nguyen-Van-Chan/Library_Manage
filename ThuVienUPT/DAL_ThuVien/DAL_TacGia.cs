using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_ThuVien;
using System.Data.SqlClient;
using System.Data;

namespace DAL_ThuVien
{
  public class DAL_TacGia
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable TacGiaGet()
        {
            SqlCommand cmd = new SqlCommand("sp_TacGiaSelect", kn.KetNoi());
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
        public DataTable TacGiaModify(DTO_TacGia tacgia)
        {
            SqlCommand cmd = new SqlCommand("sp_TacGiaModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", tacgia.Id);
            cmd.Parameters.AddWithValue("@tentacgia", tacgia.Tentacgia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable TacGiaDelete(DTO_TacGia tacgia)
        {
            SqlCommand cmd = new SqlCommand("sp_TacGiaDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", tacgia.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
