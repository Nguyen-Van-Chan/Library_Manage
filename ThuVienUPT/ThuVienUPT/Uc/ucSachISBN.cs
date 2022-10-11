using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS_ThuVien;
using DTO_ThuVien;
using System.IO;

namespace ThuVienUPT.Uc
{
    public partial class ucSachISBN : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_SachISBN s = new BUS_SachISBN();
        BUS_Sach s1 = new BUS_Sach();
        public ucSachISBN()
        {
            InitializeComponent();
        }

        private void ucSachISBN_Load(object sender, EventArgs e)
        {
            gcData.DataSource = s.SachISBNGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaS.Text = gvData.GetFocusedRowCellValue("MaSach").ToString();
                txtISBN.Text = gvData.GetFocusedRowCellValue("ISBN").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaS.Text = AutiIDSachISBN();
            txtISBN.Focus();
            txtISBN.Text = "";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_SachISBN sachisbn = new DTO_SachISBN();
            sachisbn.Masach = txtMaS.Text;
            dt = s.SachISBNDelete(sachisbn);
            gcData.DataSource = s.SachISBNGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtISBN.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập  sách ISBN", "Thông báo");
                txtISBN.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_SachISBN sachisbn = new DTO_SachISBN();
            sachisbn.Masach = txtMaS.Text;
            sachisbn.Isbn = txtISBN.Text;
            dt = s.SachISBNModify(sachisbn);
            gcData.DataSource = s.SachISBNGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        public string AutiIDSachISBN()
        {

            string _x = "";
            DataTable dt = new DataTable();
            dt = s.SachISBNSelectLastID();
            if (dt.Rows.Count == 0)
                _x = "SA0000";
            else
                _x = dt.Rows[0]["MaSach"].ToString();
            string kq = "";
            string left = _x.Substring(0, 2).ToString();
            string snew = _x.Substring(2, 4).ToString();
            int i = int.Parse(snew);
            i++;
            if (i < 10)
                kq = "000" + i.ToString();
            if (i >= 10 && i < 100)
                kq = "00" + i.ToString();
            if (i >= 100 && i < 1000)
                kq = "0" + i.ToString();
            if (i >= 1000)
                kq = i.ToString();
            return left + kq;
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
