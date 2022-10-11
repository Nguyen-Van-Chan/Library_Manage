using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_NguoiDung
    {
        private string _taikhoan;
        private string _matkhau;
        private string _hoten;
        private bool _isadmin;

        public string Taikhoan
        {
            get
            {
                return _taikhoan;
            }

            set
            {
                _taikhoan = value;
            }
        }

        public string Matkhau
        {
            get
            {
                return _matkhau;
            }

            set
            {
                _matkhau = value;
            }
        }

        public string Hoten
        {
            get
            {
                return _hoten;
            }

            set
            {
                _hoten = value;
            }
        }

        public bool Isadmin
        {
            get
            {
                return _isadmin;
            }

            set
            {
                _isadmin = value;
            }
        }
    }
}
