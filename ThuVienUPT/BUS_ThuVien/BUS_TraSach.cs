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
   public class BUS_TraSach
    {
        DAL_TraSach dal_ts = new DAL_TraSach();
        public DataTable TraSachGet()
        {
            return dal_ts.TraSachGet();
        }
        public DataTable TraSachModify(DTO_TraSach ts)
        {
            return dal_ts.TraSachModify(ts);
        }
        public DataTable TraSachSelectLastID()
        {
            return dal_ts.TraSachGetLastID();
        }
        public DataTable TraSachDelete(DTO_TraSach ts)
        {
            return dal_ts.TraSachDelete(ts);
        }
        public DataTable ChiTietPhieuTraGetByID(string maphieutra)
        {
            return dal_ts.ChiTietPhieuTraGetByID(maphieutra);
        }
    }
}
