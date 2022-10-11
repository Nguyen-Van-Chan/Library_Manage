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
using System.Diagnostics;

namespace ThuVienUPT.Uc
{
    public partial class ucNganSach : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NganSach ns = new BUS_NganSach();
        public ucNganSach()
        {
            InitializeComponent();
        }

        private void ucNganSach_Leave(object sender, EventArgs e)
        {

        }

        private void ucNganSach_Load(object sender, EventArgs e)
        {
            gcData.DataSource = ns.NganSachGet();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaNgan.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTenNgan.Text = gvData.GetFocusedRowCellValue("TenNgan").ToString();
            }
            catch
            {

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenNgan.Focus();
            txtMaNgan.Text = ns.NganSachIDMax("NganSach").Rows[0]["ID"].ToString();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenNgan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngăn sách", "Thông báo");
                txtTenNgan.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_NganSach ngansach = new DTO_NganSach();
            ngansach.Id = int.Parse(txtMaNgan.Text);
            ngansach.Tenngan = txtTenNgan.Text;
            dt = ns.NganSachModify(ngansach);
            gcData.DataSource = ns.NganSachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NganSach ngansach = new DTO_NganSach();
            ngansach.Id = int.Parse(txtMaNgan.Text);
            dt = ns.NganSachDelete(ngansach);
            gcData.DataSource = ns.NganSachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void txtTenNgan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }
    }
}
