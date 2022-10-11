using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_ThuVien
{
    public class DTO_PhieuMuon
    {
        private string _maphieu;
        private DateTime _ngaymuon;
        private DateTime _ngaytra;
        private string _masinhvien;
        private string _thuthu;
        private string _ghichu;
        private string _tinhtrang;

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

        public DateTime Ngaymuon
        {
            get
            {
                return _ngaymuon;
            }

            set
            {
                _ngaymuon = value;
            }
        }

        public DateTime Ngaytra
        {
            get
            {
                return _ngaytra;
            }

            set
            {
                _ngaytra = value;
            }
        }

        public string Masinhvien
        {
            get
            {
                return _masinhvien;
            }

            set
            {
                _masinhvien = value;
            }
        }

        public string Thuthu
        {
            get
            {
                return _thuthu;
            }

            set
            {
                _thuthu = value;
            }
        }

        public string Ghichu
        {
            get
            {
                return _ghichu;
            }

            set
            {
                _ghichu = value;
            }
        }

        public string Tinhtrang
        {
            get
            {
                return _tinhtrang;
            }

            set
            {
                _tinhtrang = value;
            }
        }
    }
}
