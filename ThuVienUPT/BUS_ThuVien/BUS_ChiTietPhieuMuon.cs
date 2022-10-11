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
   public class BUS_ChiTietPhieuMuon
    {
        DAL_ChiTietPhieuMuon dal_ctpm = new DAL_ChiTietPhieuMuon();
        public DataTable ChiTietPhieuMuonGet()
        {
            return dal_ctpm.ChiTietPhieuMuonGet();
        }
        public DataTable ChiTietPhieuMuonModify(DTO_ChiTietPhieuMuon ctpm)
        {
            return dal_ctpm.ChiTietPhieuMuonModify(ctpm);
        }
        public DataTable ChiTietPhieuMuonGetByID(string maphieu)
        {
            return dal_ctpm.ChiTietPhieuMuonGetByID(maphieu);
        }
        public DataTable ChiTietPhieuMuonSelectLastID()
        {
            return dal_ctpm.ChiTietPhieuMuonGetLastID();
        }
        public DataTable ChiTietPhieuMuonDelete(DTO_ChiTietPhieuMuon ctpm)
        {
            return dal_ctpm.ChiTietPhieuMuonDelete(ctpm);
        }
        public DataTable NghiepVuMuonSachChiTiet(string maphieu, string masach)
        {
            return dal_ctpm.NghiepVuMuonSachChiTiet(maphieu, masach);
        }
    }
}
