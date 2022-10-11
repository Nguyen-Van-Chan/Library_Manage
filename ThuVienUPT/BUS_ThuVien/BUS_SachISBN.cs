using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_ThuVien;
using System.Data;
using DAL_ThuVien;

namespace BUS_ThuVien
{
   public class BUS_SachISBN
    {
        DAL_SachISBN dal_sisbn = new DAL_SachISBN();
        public DataTable SachISBNGet()
        {
            return dal_sisbn.SachISBNGet();
        }
        public DataTable SachISBNModify(DTO_SachISBN sachisbn)
        {
            return dal_sisbn.SachISBNModify(sachisbn);
        }
        public DataTable SachISBNSelectLastID()
        {
            return dal_sisbn.SachISBNGetLastID();
        }
        public DataTable SachISBNDelete(DTO_SachISBN sachisbn)
        {
            return dal_sisbn.SachISBNDelete(sachisbn);
        }
    }
}
