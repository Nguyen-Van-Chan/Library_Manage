using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_ChiTietPhieuNhap
    {
        private string _maphieu;
        private string _masach;
        private int _gianhap;

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

        public string Masach
        {
            get
            {
                return _masach;
            }

            set
            {
                _masach = value;
            }
        }

        public int Gianhap
        {
            get
            {
                return _gianhap;
            }

            set
            {
                _gianhap = value;
            }
        }
    }
}

