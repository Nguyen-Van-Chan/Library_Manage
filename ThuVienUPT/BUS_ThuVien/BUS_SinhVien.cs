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
   public class BUS_SinhVien
    {
        DAL_SinhVien dal_sv = new DAL_SinhVien();
        public DataTable SinhVienGet()
        {
            return dal_sv.SinhVienGet();
        }
        public DataTable SinhVienSelectLastID()
        {
            return dal_sv.SinhVienGetLastID();
        }
        public DataTable SinhVienModify(DTO_SinhVien sv)
        {
            return dal_sv.SinhVienModify(sv);
        }
        public DataTable SinhVienDelete(DTO_SinhVien sv)
        {
            return dal_sv.SinhVienDelete(sv);
        }
    }
}
