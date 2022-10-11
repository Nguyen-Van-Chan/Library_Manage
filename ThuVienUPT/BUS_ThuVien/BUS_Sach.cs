using DAL_ThuVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_ThuVien;
namespace BUS_ThuVien
{
    public class BUS_Sach
    {
        DAL_Sach dal_s = new DAL_Sach();
        public DataTable SachGet()
        {
            return dal_s.SachGet();
        }
        public DataTable SachModify(DTO_Sach sach)
        {
            return dal_s.SachModify(sach);
        }
        public DataTable SachSelectLastID()
        {
            return dal_s.SachGetLastID();
        }
        public DataTable SachThongKe()
        {
            return dal_s.SachThongKe();
        }
        public DataTable SachMNN()
        {
            return dal_s.SachMNN();
        }
        public DataTable SachDDM()
        {
            return dal_s.SachDDM();
        }
        public DataTable SachDelete(DTO_Sach sach)
        {
            return dal_s.SachDelete(sach);
        }
    }
}
