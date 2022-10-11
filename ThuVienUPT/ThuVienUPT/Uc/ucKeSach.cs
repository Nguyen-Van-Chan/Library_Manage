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
    public partial class ucKeSach : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_KeSach ks = new BUS_KeSach();
        public ucKeSach()
        {
            InitializeComponent();
        }

        private void ucKeSach_Load(object sender, EventArgs e)
        {
            gridData.DataSource = ks.KeSachGet();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaKe.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtTenKe.Text = gridView1.GetFocusedRowCellValue("TenKe").ToString();
            }
            catch
            {

            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (txtTenKe.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên kệ sách", "Thông báo");
                txtTenKe.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_KeSach kesach = new DTO_KeSach();
            kesach.Id =int.Parse( txtMaKe.Text);
            kesach.Tenke = txtTenKe.Text;
            dt = ks.KeSachModify(kesach);
            gridData.DataSource = ks.KeSachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenKe.Focus();
            txtMaKe.Text = ks.KeSachIDMax("KeSach").Rows[0]["ID"].ToString();
        }

        private void txtTenKe_KeyPress(object sender, KeyPressEventArgs e)
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
            DTO_KeSach ks1 = new DTO_KeSach();
            ks1.Id = int.Parse(txtMaKe.Text);
            dt = ks.KeSachDelete(ks1);
            gridData.DataSource = ks.KeSachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }
    }
}
