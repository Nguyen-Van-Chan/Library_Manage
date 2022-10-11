using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_NganSach
    {
        private int _id;
        private string _tenngan;

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

        public string Tenngan
        {
            get
            {
                return _tenngan;
            }

            set
            {
                _tenngan = value;
            }
        }
    }
}
