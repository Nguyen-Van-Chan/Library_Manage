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
    public class DAL_PhieuNhap
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable PhieuNhapGet()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable LKSachNhapVe()
        {
            SqlCommand cmd = new SqlCommand("sp_LietKeSachNhapVe", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuNhapSachPhieuNhap(DTO_PhieuNhap pn)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuNhapSachPhieuNhap", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@MaPhieu", pn.Maphieu);
            cmd.Parameters.AddWithValue("@NgayNhap", pn.Ngaynhap);
            cmd.Parameters.AddWithValue("@CongTy", pn.Congty);
            cmd.Parameters.AddWithValue("@ThuThu", pn.Thuthu);
            cmd.Parameters.AddWithValue("@GhiChu", pn.Ghichu);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuNhapGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuNhapModify(DTO_PhieuNhap pn)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pn.Maphieu);
            cmd.Parameters.AddWithValue("@ngaynhap", pn.Ngaynhap);
            cmd.Parameters.AddWithValue("@congty", pn.Congty);
            cmd.Parameters.AddWithValue("@thuthu", pn.Thuthu);
            cmd.Parameters.AddWithValue("@ghichu", pn.Ghichu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuNhapDelete(DTO_PhieuNhap pn)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuNhapDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pn.Maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
