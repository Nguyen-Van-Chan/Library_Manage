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
    public class BUS_KeSach
    {
        DAL_KeSach dal_ks = new DAL_KeSach();
        public DataTable KeSachGet()
        {
            return dal_ks.KeSachGet();
        } 
        public DataTable KeSachModify(DTO_KeSach ke)
        {
            return dal_ks.KeSachModify(ke);
        }
        public DataTable KeSachIDMax(string table)
        {
            return dal_ks.SelectIDMax(table);
        }
        public DataTable KeSachDelete(DTO_KeSach ke)
        {
            return dal_ks.KeDelete(ke);
        }
    }
}
