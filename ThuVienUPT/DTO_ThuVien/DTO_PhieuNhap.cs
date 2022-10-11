using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_PhieuNhap
    {
        private string _maphieu;
        private DateTime _ngaynhap;
        private string _congty;
        private string _thuthu;
        private string _ghichu;

        public string Maphieu
        {
            get
            {
                return _maphieu;
            }

            set
            {
                _maphieu = value;
            }
        }

        public DateTime Ngaynhap
        {
            get
            {
                return _ngaynhap;
            }

            set
            {
                _ngaynhap = value;
            }
        }

        public string Congty
        {
            get
            {
                return _congty;
            }

            set
            {
                _congty = value;
            }
        }

        public string Thuthu
        {
            get
            {
                return _thuthu;
            }

            set
            {
                _thuthu = value;
            }
        }

        public string Ghichu
        {
            get
            {
                return _ghichu;
            }

            set
            {
                _ghichu = value;
            }
        }
    }
}
