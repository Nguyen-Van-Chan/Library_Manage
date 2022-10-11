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
    public partial class ucKhoa : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKhoa()
        {
            InitializeComponent();
        }
        BUS_Khoa k = new BUS_Khoa();
        private void ucKhoa_Load(object sender, EventArgs e)
        {
            gridData.DataSource = k.KhoaGet();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

            try
            {
                txtMaKhoa.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtTenKhoa.Text = gridView1.GetFocusedRowCellValue("TenKhoa").ToString();
            }
            catch
            {

            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenKhoa.Focus();
            txtMaKhoa.Text = k.KhoaIDMax("Khoa").Rows[0]["ID"].ToString();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên kệ sách", "Thông báo");
                txtTenKhoa.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_Khoa khoa = new DTO_Khoa();
            khoa.Id = int.Parse(txtMaKhoa.Text);
            khoa.Tenkhoa = txtTenKhoa.Text;
            dt = k.KhoaModify(khoa);
            gridData.DataSource = k.KhoaGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void txtTenKhoa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gridData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_Khoa k1 = new DTO_Khoa();
            k1.Id = int.Parse(txtMaKhoa.Text);
            dt = k.KhoaDelete(k1);
            gridData.DataSource = k.KhoaGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }
    }
}
