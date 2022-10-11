using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_NgonNgu
    {
        private int _id;
        private string _tenngonngu;

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

        public string Tenngonngu
        {
            get
            {
                return _tenngonngu;
            }

            set
            {
                _tenngonngu = value;
            }
        }
    }
}
