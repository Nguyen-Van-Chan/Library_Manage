using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_Khoa
    {
        private int _id;
        private string _tenkhoa;

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

        public string Tenkhoa
        {
            get
            {
                return _tenkhoa;
            }

            set
            {
                _tenkhoa = value;
            }
        }
    }
}
