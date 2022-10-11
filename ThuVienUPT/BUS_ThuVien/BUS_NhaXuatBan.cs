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
   public class BUS_NhaXuatBan
    {
        DAL_NhaXuatBan dal_nxb = new DAL_NhaXuatBan();
        public DataTable NhaXuatBanGet()
        {
            return dal_nxb.NhaXuatBanGet();
        }
        public DataTable NhaXuatBanIDMax(string table)
        {
            return dal_nxb.SelectIDMax(table);
        }
        public DataTable NhaXuatBanModify(DTO_NhaXuatBan nxb)
        {
            return dal_nxb.NhaXuatBanModify(nxb);
        }
        public DataTable NhaXuatBanDelete(DTO_NhaXuatBan nxb)
        {
            return dal_nxb.NhaXuatBanDelete(nxb);
        }
    }
}
