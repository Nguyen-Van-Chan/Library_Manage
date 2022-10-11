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
   public class DAL_NhaXuatBan
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable NhaXuatBanGet()
        {
            SqlCommand cmd = new SqlCommand("sp_NhaXuatbanSelect", kn.KetNoi());
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
        public DataTable NhaXuatBanModify(DTO_NhaXuatBan nxb)
        {
            SqlCommand cmd = new SqlCommand("sp_NhaXuatBanModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", nxb.Id);
            cmd.Parameters.AddWithValue("@tennhaxuatban", nxb.Tennhaxuatban);
            cmd.Parameters.AddWithValue("@diachi", nxb.Diachi);
            cmd.Parameters.AddWithValue("@dienthoai", nxb.Dienthoai);
            cmd.Parameters.AddWithValue("@fax", nxb.Fax);
            cmd.Parameters.AddWithValue("@email", nxb.Email);
            cmd.Parameters.AddWithValue("@website", nxb.Website);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NhaXuatBanDelete(DTO_NhaXuatBan nxb)
        {
            SqlCommand cmd = new SqlCommand("sp_NhaXuatBanDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", nxb.Id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
