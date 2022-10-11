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
   public class DAL_SinhVien
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable SinhVienGet()
        {
            SqlCommand cmd = new SqlCommand("sp_SinhVienSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SinhVienGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_SinhVienSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SinhVienModify(DTO_SinhVien sv)
        {
            SqlCommand cmd = new SqlCommand("sp_SinhVienModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masinhvien", sv.Masinhvien);
            cmd.Parameters.AddWithValue("@tensinhvien", sv.Tensinhvien);
            cmd.Parameters.AddWithValue("@gioitinh", sv.Gioitinh);
            cmd.Parameters.AddWithValue("@ngaysinh", sv.Ngaysinh);
            cmd.Parameters.AddWithValue("@lop", sv.Lop);
            cmd.Parameters.AddWithValue("@dienthoai", sv.Dienthoai);
            cmd.Parameters.AddWithValue("@email", sv.Email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable SinhVienDelete(DTO_SinhVien sinhvien)
        {
            SqlCommand cmd = new SqlCommand("sp_SinhVienDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@masinhvien", sinhvien.Masinhvien);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
