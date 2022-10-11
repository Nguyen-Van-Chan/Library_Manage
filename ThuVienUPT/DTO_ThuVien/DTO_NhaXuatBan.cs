using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_NhaXuatBan
    {
        private int _id;
        private string _tennhaxuatban;
        private string _diachi;
        private string _dienthoai;
        private string _fax;
        private string _email;
        private string _website;

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

        public string Tennhaxuatban
        {
            get
            {
                return _tennhaxuatban;
            }

            set
            {
                _tennhaxuatban = value;
            }
        }

        public string Diachi
        {
            get
            {
                return _diachi;
            }

            set
            {
                _diachi = value;
            }
        }

        public string Dienthoai
        {
            get
            {
                return _dienthoai;
            }

            set
            {
                _dienthoai = value;
            }
        }

        public string Fax
        {
            get
            {
                return _fax;
            }

            set
            {
                _fax = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public string Website
        {
            get
            {
                return _website;
            }

            set
            {
                _website = value;
            }
        }
    }
}
