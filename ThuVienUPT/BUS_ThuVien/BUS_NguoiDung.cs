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
    public class BUS_NguoiDung
    {
        DAL_NguoiDung dal_nd = new DAL_NguoiDung();
        public DataTable NguoiDungDangNhap(string _username,string _password)
        {
            return dal_nd.NguoiDungDangNhap(_username, _password);
        }
        public DataTable NguoiDungGet()
        {
            return dal_nd.NguoiDungGet();
        }
        public DataTable Change_PW(string _username, string _password)
        {
            return dal_nd.Change_PW(_username, _password);
        }
        public DataTable NguoiDungDangKy(DTO_NguoiDung nd)
        {
            return dal_nd.NguoiDungDangKy(nd);
        }
        public DataTable NguoiDungDelete(DTO_NguoiDung nd)
        {
            return dal_nd.NguoiDungDelete(nd);
        }
    }
}
