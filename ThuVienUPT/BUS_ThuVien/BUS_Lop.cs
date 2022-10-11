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
   public class BUS_Lop
    {
        DAL_Lop dal_l = new DAL_Lop();
        public DataTable LopGet()
        {
            return dal_l.LopGet();
        }
        public DataTable LopIDMax(string table)
        {
            return dal_l.SelectIDMax(table);
        }
        public DataTable LopModify(DTO_Lop l)
        {
            return dal_l.LopModify(l);
        }
        public DataTable LopDelete(DTO_Lop l)
        {
            return dal_l.LopDelete(l);
        }
    }
}
