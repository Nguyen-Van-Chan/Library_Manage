using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_KeSach
    {
        private int _id;
        private string _tenke;

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

        public string Tenke
        {
            get
            {
                return _tenke;
            }

            set
            {
                _tenke = value;
            }
        }
    }
}

