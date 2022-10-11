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
   public class DAL_ChiTietPhieuNhap
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable ChiTietPhieuNhapGet()
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuNhapGetByID(string maphieu)
        {
            SqlCommand cmd = new SqlCommand("sp_CTPNDetailByID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapn", maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuNhapGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuNhapModify(DTO_ChiTietPhieuNhap ctpn)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ctpn.Maphieu);
            cmd.Parameters.AddWithValue("@masach", ctpn.Masach);
            cmd.Parameters.AddWithValue("@gianhap", ctpn.Gianhap);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuNhapDelete(DTO_ChiTietPhieuNhap ctpn)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuNhapDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ctpn.Maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuNhapSachChiTiet(string maphieu, string masach,int gianhap,int soluong)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuNhapSachChiTiet", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieu", maphieu);
            cmd.Parameters.AddWithValue("@MaSach", masach);
            cmd.Parameters.AddWithValue("@GiaNhap", gianhap);
            cmd.Parameters.AddWithValue("@SoLuong", soluong);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
