using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_ChiTietPhieuMuon
    {
        private string _maphieu;
        private string _masach;
        private string _isbn;

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

        public string Isbn
        {
            get
            {
                return _isbn;
            }

            set
            {
                _isbn = value;
            }
        }
    }
}

