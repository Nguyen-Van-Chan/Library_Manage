using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
   public class DTO_TacGia
    {
        private int _id;
        private string _tentacgia;

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

        public string Tentacgia
        {
            get
            {
                return _tentacgia;
            }

            set
            {
                _tentacgia = value;
            }
        }
    }
}
