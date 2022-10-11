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
   public class DAL_TraSach
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable TraSachGet()
        {
            SqlCommand cmd = new SqlCommand("sp_TraSachSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable TraSachGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_TraSachSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable TraSachModify(DTO_TraSach ts)
        {
            SqlCommand cmd = new SqlCommand("sp_TraSachModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ts.Maphieu);
            cmd.Parameters.AddWithValue("@ngaytra", ts.Ngaytra);
            cmd.Parameters.AddWithValue("@thuthu", ts.Thuthu);
            cmd.Parameters.AddWithValue("@ghichu", ts.Ghichu);
            cmd.Parameters.AddWithValue("@masinhvien", ts.Masinhvien);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable TraSachDelete(DTO_TraSach ts)
        {
            SqlCommand cmd = new SqlCommand("sp_TraSachDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ts.Maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuTraGetByID(string maphieutra)
        {
            SqlCommand cmd = new SqlCommand("sp_CTPTDetailByID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapt", maphieutra);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
