using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL_ThuVien;
using DTO_ThuVien;

namespace BUS_ThuVien
{
   public class BUS_PhieuMuon
    {
        DAL_PhieuMuon dal_pm = new DAL_PhieuMuon();
        public DataTable PhieuMuonGet()
        {
            return dal_pm.PhieuMuonGet();
        }
        public DataTable PhieuMuonModify(DTO_PhieuMuon pm)
        {
            return dal_pm.PhieuMuonModify(pm);
        }
        public DataTable PhieuMuonSelectLastID()
        {
            return dal_pm.PhieuMuonGetLastID();
        }
        public DataTable PhieuMuonDelete(DTO_PhieuMuon pm)
        {
            return dal_pm.PhieuMuonDelete(pm);
        }
        public DataTable NghiepVuMuonSachPhieuMuon(DTO_PhieuMuon pm)
        {
            return dal_pm.NghiepVuMuonSachPhieuMuon(pm);
        }
        public DataTable NghiepVuTraSachSV(string maphieu, string thuthu, DateTime ngaytra, string ghichu, string masinhvien)
        {
            return dal_pm.NghiepVuTraSachSV(maphieu, thuthu, ngaytra, ghichu, masinhvien);
        }
        public DataTable NghiepVuTraSachChiTiet(string maphieu,string masach)
        {
            return dal_pm.NghiepVuTraSachChiTiet(maphieu, masach);
        }
        public DataTable PhieuMuonDelete(string pm)
        {
            return dal_pm.PhieuMuonDelete(pm);
        }
        public DataTable PhieuNhapByDate(DateTime start, DateTime end)
        {
            return dal_pm.PhieuNhapByDate(start, end);
        }
        public DataTable PhieuMuonQuaHan()
        {
            return dal_pm.PhieuMuonQuaHan();
        }
        public DataTable PhieuMuonGetID(string maphieu)
        {
            return dal_pm.PhieuMuonGetID(maphieu);
        }
    }
}
