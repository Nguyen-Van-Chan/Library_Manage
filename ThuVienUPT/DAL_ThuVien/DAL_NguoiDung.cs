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
    public class DAL_NguoiDung
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable NguoiDungDangNhap(string _username,string _password)
        {
            SqlCommand cmd = new SqlCommand("sp_NguoiDungLogin", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", _username);
            cmd.Parameters.AddWithValue("@password", _password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NguoiDungGet()
        {
            SqlCommand cmd = new SqlCommand("sp_NguoiDungSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable Change_PW(string _username, string _password)
        {
            SqlCommand cmd = new SqlCommand("sp_Change_PW", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", _username);
            cmd.Parameters.AddWithValue("@matkhau", _password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NguoiDungDangKy(DTO_NguoiDung nd)
        {
            SqlCommand cmd = new SqlCommand("sp_NguoiDungDangKy", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", nd.Taikhoan);
            cmd.Parameters.AddWithValue("@matkhau", nd.Matkhau);
            cmd.Parameters.AddWithValue("@hoten", nd.Hoten);
            cmd.Parameters.AddWithValue("@isAdmin", nd.Isadmin);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NguoiDungDelete(DTO_NguoiDung nd)
        {
            SqlCommand cmd = new SqlCommand("sp_NguoiDungDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@taikhoan", nd.Taikhoan);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
