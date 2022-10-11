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
  public class BUS_NhaCungCap
    {
        DAL_NhaCungCap dal_ncc = new DAL_NhaCungCap();
        public DataTable NhaCungCapGet()
        {
            return dal_ncc.NhaCungCapGet();
        }
        public DataTable NhaCungCapIDMax(string table)
        {
            return dal_ncc.SelectIDMax(table);
        }
        public DataTable NhaCungCapModify(DTO_NhaCungCap ncc)
        {
            return dal_ncc.NhaCungCapModify(ncc);
        }
        public DataTable NhaCungCapDelete(DTO_NhaCungCap ncc)
        {
            return dal_ncc.NhaCungCapDelete(ncc);
        }
    }
}
