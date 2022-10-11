using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
   public  class DTO_Lop
    {
        private int _malop;
        private string _tenlop;

        public int Malop
        {
            get
            {
                return _malop;
            }

            set
            {
                _malop = value;
            }
        }

        public string Tenlop
        {
            get
            {
                return _tenlop;
            }

            set
            {
                _tenlop = value;
            }
        }
    }
}
