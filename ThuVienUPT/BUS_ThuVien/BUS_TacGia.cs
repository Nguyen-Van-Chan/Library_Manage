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
  public class BUS_TacGia
    {
        DAL_TacGia dal_tg = new DAL_TacGia();
        public DataTable TacGiaGet()
        {
            return dal_tg.TacGiaGet();
        }
        public DataTable TacGiaIDMax(string table)
        {
            return dal_tg.SelectIDMax(table);
        }
        public DataTable TacGiaModify(DTO_TacGia tacgia)
        {
            return dal_tg.TacGiaModify(tacgia);
        }
        public DataTable TacGiaDelete(DTO_TacGia tacgia)
        {
            return dal_tg.TacGiaDelete(tacgia);
        }
    }
}
