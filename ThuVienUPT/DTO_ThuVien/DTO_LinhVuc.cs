using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_LinhVuc
    {
        private int _id;
        private string _linhvuc;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Linhvuc
        {
            get
            {
                return _linhvuc;
            }

            set
            {
                _linhvuc = value;
            }
        }
    }
}

