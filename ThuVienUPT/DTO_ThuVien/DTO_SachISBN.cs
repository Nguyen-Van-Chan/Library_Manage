using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_SachISBN
    {
        private string _masach;
        private string _isbn;

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
