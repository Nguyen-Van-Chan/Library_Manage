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
   public class DAL_SachISBN
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable SachISBNGet()
        {
            SqlCommand cmd = new SqlCommand("sp_Sach_ISBNSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachISBNGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_Sach_ISBNSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachISBNModify(DTO_SachISBN sachisbn)
        {
            SqlCommand cmd = new SqlCommand("sp_Sach_ISBNModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masach", sachisbn.Masach);
            cmd.Parameters.AddWithValue("@isbn", sachisbn.Isbn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachISBNDelete(DTO_SachISBN sachisbn)
        {
            SqlCommand cmd = new SqlCommand("sp_Sach_ISBNDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masach", sachisbn.Masach);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
