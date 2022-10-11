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
    public class DAL_PhieuMuon
    {
        DAL_KetNoi kn = new DAL_KetNoi();
        public DataTable PhieuMuonGet()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonSelect", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonGetLastID()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonSelectLastID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonModify(DTO_PhieuMuon pm)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonModify", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pm.Maphieu);
            cmd.Parameters.AddWithValue("@ngaymuon", pm.Ngaymuon);
            cmd.Parameters.AddWithValue("@ngaytra", pm.Ngaytra);
            cmd.Parameters.AddWithValue("@masinhvien", pm.Masinhvien);
            cmd.Parameters.AddWithValue("@thuthu", pm.Thuthu);
            cmd.Parameters.AddWithValue("@ghichu", pm.Ghichu);
            cmd.Parameters.AddWithValue("@tinhtrang", pm.Tinhtrang);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonDelete(DTO_PhieuMuon pm)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pm.Maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuMuonSachPhieuMuon(DTO_PhieuMuon pm)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuMuonSachPhieuMuon", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pm.Maphieu);
            cmd.Parameters.AddWithValue("@ngaymuon", pm.Ngaymuon);
            cmd.Parameters.AddWithValue("@ngaytra", pm.Ngaytra);
            cmd.Parameters.AddWithValue("@masinhvien", pm.Masinhvien);
            cmd.Parameters.AddWithValue("@thuthu", pm.Thuthu);
            cmd.Parameters.AddWithValue("@ghichu", pm.Ghichu);
            cmd.Parameters.AddWithValue("@tinhtrang", "Chưa Được Trả");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuTraSachSV(string maphieu, string thuthu, DateTime ngaytra, string ghichu, string masinhvien)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuTraSach", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", maphieu);
            cmd.Parameters.AddWithValue("@thuthu", thuthu);
            cmd.Parameters.AddWithValue("@ngaytra", ngaytra);
            cmd.Parameters.AddWithValue("@ghichu", ghichu);
            cmd.Parameters.AddWithValue("@masinhvien", masinhvien);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable NghiepVuTraSachChiTiet(string maphieu, string masach)
        {
            SqlCommand cmd = new SqlCommand("sp_ChiTietTraSach", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", maphieu);
            cmd.Parameters.AddWithValue("@masach", masach);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonDelete(string pm)
        {
            SqlCommand cmd = new SqlCommand("sp_NghiepVuTraSachDelete", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", pm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuNhapByDate(DateTime start, DateTime end)
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonByDate", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@start", start);
            cmd.Parameters.AddWithValue("@end", end);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonQuaHan()
        {
            SqlCommand cmd = new SqlCommand("sp_PhieuMuonQuaHan", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable PhieuMuonGetID(string maphieu)
        {
            SqlCommand cmd = new SqlCommand("sp_getPMByID", kn.KetNoi());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@maphieu", maphieu);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
