using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
   public class DTO_SinhVien
    {
        private string _masinhvien;
        private string _tensinhvien;
        private string _gioitinh;
        private DateTime _ngaysinh;
        private int _lop;
        private string _dienthoai;
        private string _email;

        public string Masinhvien
        {
            get
            {
                return _masinhvien;
            }

            set
            {
                _masinhvien = value;
            }
        }

        public string Tensinhvien
        {
            get
            {
                return _tensinhvien;
            }

            set
            {
                _tensinhvien = value;
            }
        }

        public string Gioitinh
        {
            get
            {
                return _gioitinh;
            }

            set
            {
                _gioitinh = value;
            }
        }

        public DateTime Ngaysinh
        {
            get
            {
                return _ngaysinh;
            }

            set
            {
                _ngaysinh = value;
            }
        }

        public int Lop
        {
            get
            {
                return _lop;
            }

            set
            {
                _lop = value;
            }
        }

        public string Dienthoai
        {
            get
            {
                return _dienthoai;
            }

            set
            {
                _dienthoai = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }
    }
}
