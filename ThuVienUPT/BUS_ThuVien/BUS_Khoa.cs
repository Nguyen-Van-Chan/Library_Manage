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
    public class BUS_Khoa
    {
        DAL_Khoa dal_k = new DAL_Khoa();
        public DataTable KhoaGet()
        {
            return dal_k.KhoaGet();
        }
        public DataTable KhoaIDMax(string table)
        {
            return dal_k.SelectIDMax(table);
        }
        public DataTable KhoaModify(DTO_Khoa khoa)
        {
            return dal_k.KhoaModify(khoa);
        }
        public DataTable KhoaDelete(DTO_Khoa khoa)
        {
            return dal_k.KhoaDelete(khoa);
        }
    }
}
