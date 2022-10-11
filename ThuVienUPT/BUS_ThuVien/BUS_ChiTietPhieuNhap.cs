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
   public class BUS_ChiTietPhieuNhap
    {
        DAL_ChiTietPhieuNhap dal_ctpn = new DAL_ChiTietPhieuNhap();
        public DataTable ChiTietPhieuNhapGet()
        {
            return dal_ctpn.ChiTietPhieuNhapGet();
        }
        public DataTable ChiTietPhieuNhapModify(DTO_ChiTietPhieuNhap ctpn)
        {
            return dal_ctpn.ChiTietPhieuNhapModify(ctpn);
        }
        public DataTable ChiTietPhieuNhapGetByID(string maphieu)
        {
            return dal_ctpn.ChiTietPhieuNhapGetByID(maphieu);
        }
        public DataTable ChiTietPhieuNhapSelectLastID()
        {
            return dal_ctpn.ChiTietPhieuNhapGetLastID();
        }
        public DataTable ChiTietPhieuNhapDelete(DTO_ChiTietPhieuNhap ctpn)
        {
            return dal_ctpn.ChiTietPhieuNhapDelete(ctpn);
        }
        public DataTable NghiepVuNhapSachChiTiet(string maphieu, string masach,int gianhap,int soluong)
        {
            return dal_ctpn.NghiepVuNhapSachChiTiet(maphieu, masach,gianhap,soluong);
        }
    }
}
