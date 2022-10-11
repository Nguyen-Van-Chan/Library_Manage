using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_ThuVien;
using DTO_ThuVien;
using System.IO;

namespace ThuVienUPT.Uc
{
    public partial class ucChangePW : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NguoiDung nda = new BUS_NguoiDung();
        public ucChangePW()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NguoiDung nd = new DTO_NguoiDung();
            if (txtMatKhauCu.Text == "" || txtMatKhauMoi.Text == "" || txtNhapLaiMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            dt = nda.Change_PW(frmLogin.username, txtMatKhauMoi.Text);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }
    }
}

