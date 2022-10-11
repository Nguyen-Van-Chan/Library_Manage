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
   public class DAL_ChiTietPhieuMuon
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable ChiTietPhieuMuonGet()
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuMuonSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuMuonGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuMuonSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuMuonGetByID(string maphieu)
        {
            SqlCommand cmd = new SqlCommand("sp_CTPMDetailByID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mapm", maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuMuonModify(DTO_ChiTietPhieuMuon ctpm)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuMuonModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ctpm.Maphieu);
            cmd.Parameters.AddWithValue("@masach", ctpm.Masach);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable ChiTietPhieuMuonDelete(DTO_ChiTietPhieuMuon ctpm)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietPhieuMuonDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", ctpm.Maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuMuonSachChiTiet(string maphieu, string masach)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuMuonSachChiTiet", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaPhieu", maphieu);
            cmd.Parameters.AddWithValue("@MaSach", masach);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
