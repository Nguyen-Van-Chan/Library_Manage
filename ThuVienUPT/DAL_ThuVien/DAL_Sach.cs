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
    public class DAL_Sach
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable SachGet()
        {
            SqlCommand cmd = new SqlCommand("sp_SachSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_SachSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachModify(DTO_Sach sach)
        {
            SqlCommand cmd = new SqlCommand("sp_SachModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masach",sach.Masach);
            cmd.Parameters.AddWithValue("@tieude", sach.Tieude);
            cmd.Parameters.AddWithValue("@sotrang", sach.Sotrang);
            cmd.Parameters.AddWithValue("@namxuatban", sach.Namxuatban);
            cmd.Parameters.AddWithValue("@nhaxuatban", sach.Nhaxuatban);
            cmd.Parameters.AddWithValue("@linhvuc", sach.Linhvuc);
            cmd.Parameters.AddWithValue("@ke", sach.Ke);
            cmd.Parameters.AddWithValue("@ngan", sach.Ngan);
            cmd.Parameters.AddWithValue("@ngonngu", sach.Ngonngu);
            cmd.Parameters.AddWithValue("@khoa", sach.Khoa);
            cmd.Parameters.AddWithValue("@soluong", sach.Soluong);
            cmd.Parameters.AddWithValue("@gianhap", sach.Gianhap);
            cmd.Parameters.AddWithValue("@ngaytao", sach.Ngaytao);
            cmd.Parameters.AddWithValue("@ngaycapnhat", sach.Ngaycapnhat);
            cmd.Parameters.AddWithValue("@hinhanh", sach.Hinhanh);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachThongKe()
        {
            SqlCommand cmd = new SqlCommand("sp_ThongKeSachThuVien", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachMNN()
        {
            SqlCommand cmd = new SqlCommand("sp_SelectTop10", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachDDM()
        {
            SqlCommand cmd = new SqlCommand("sp_LietKeSachDDM", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SachDelete(DTO_Sach sach)
        {
            SqlCommand cmd = new SqlCommand("sp_SachDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masach", sach.Masach);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
