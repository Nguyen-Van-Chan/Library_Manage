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
    public class BUS_NgonNgu
    {
        DAL_NgonNgu dal_nn = new DAL_NgonNgu();
        public DataTable NgonNguGet()
        {
            return dal_nn.NgonNguGet();
        }
        public DataTable NgonNguModify(DTO_NgonNgu nn)
        {
            return dal_nn.NgonNguModify(nn);
        }
        public DataTable NgonNguIDMax(string table)
        {
            return dal_nn.SelectIDMax(table);
        }
        public DataTable NgonNguDelete(DTO_NgonNgu nn)
        {
            return dal_nn.NgonNguDelete(nn);
        }
    }
}
