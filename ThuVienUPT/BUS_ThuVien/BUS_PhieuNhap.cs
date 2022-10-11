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
    public class BUS_PhieuNhap
    {
        DAL_PhieuNhap dal_pn = new DAL_PhieuNhap();
        public DataTable PhieuNhapGet()
        {
            return dal_pn.PhieuNhapGet();
        }
        public DataTable LKSachNhapVe()
        {
            return dal_pn.LKSachNhapVe();
        }
        public DataTable PhieuNhapModify(DTO_PhieuNhap pn)
        {
            return dal_pn.PhieuNhapModify(pn);
        }
        public DataTable PhieuNhapSelectLastID()
        {
            return dal_pn.PhieuNhapGetLastID();
        }
        public DataTable PhieuNhapDelete(DTO_PhieuNhap pn)
        {
            return dal_pn.PhieuNhapDelete(pn);
        }
        public DataTable NghiepVuNhapSachPhieuNhap(DTO_PhieuNhap pn)
        {
            return dal_pn.NghiepVuNhapSachPhieuNhap(pn);
        }
    }
}
