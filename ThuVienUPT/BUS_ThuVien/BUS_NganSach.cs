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
    public class BUS_NganSach
    {
        DAL_NganSach dal_ns = new DAL_NganSach();
        public DataTable NganSachGet()
        {
            return dal_ns.NganSachGet();
        }
        public DataTable NganSachIDMax(string table)
        {
            return dal_ns.SelectIDMax(table);
        }
        public DataTable NganSachModify(DTO_NganSach ngan)
        {
            return dal_ns.NganSacghModify(ngan);
        }
        public DataTable NganSachDelete(DTO_NganSach ngan)
        {
            return dal_ns.NganSachDelete(ngan);
        }
    }
}
