using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_ThuVien;
using System.Data;
using DTO_ThuVien;

namespace BUS_ThuVien
{
   public  class BUS_LinhVuc
    {
        DAL_LinhVuc dal_lv = new DAL_LinhVuc();
        public DataTable LinhVucGet()
        {
            return dal_lv.LinhVucGet();
        }
        public DataTable LinhVucIDMax(string table)
        {
            return dal_lv.SelectIDMax(table);
        }
        public DataTable LinhVucModify(DTO_LinhVuc lv)
        {
            return dal_lv.LinhVucModify(lv);
        }
        public DataTable LinhVucDelete(DTO_LinhVuc lv)
        {
            return dal_lv.LinhVucDelete(lv);
        }
    }
}
