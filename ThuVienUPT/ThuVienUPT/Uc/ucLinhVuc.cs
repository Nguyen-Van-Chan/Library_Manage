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
    public partial class ucLinhVuc : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_LinhVuc lv = new BUS_LinhVuc();
        public ucLinhVuc()
        {
            InitializeComponent();
        }

        private void ucLinhVuc_Load(object sender, EventArgs e)
        {
            gcData.DataSource = lv.LinhVucGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaLinhVuc.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTenLinhVuc.Text = gvData.GetFocusedRowCellValue("LinhVuc").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenLinhVuc.Focus();
            txtMaLinhVuc.Text = lv.LinhVucIDMax("LinhVuc").Rows[0]["ID"].ToString();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_LinhVuc linhvuc = new DTO_LinhVuc();
            linhvuc.Id = int.Parse(txtMaLinhVuc.Text);
            dt = lv.LinhVucDelete(linhvuc);
            gcData.DataSource = lv.LinhVucGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenLinhVuc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên lĩnh vực", "Thông báo");
                txtTenLinhVuc.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_LinhVuc linhvuc = new DTO_LinhVuc();
            linhvuc.Id = int.Parse(txtMaLinhVuc.Text);
            linhvuc.Linhvuc = txtTenLinhVuc.Text;
            dt = lv.LinhVucModify(linhvuc);
            gcData.DataSource = lv.LinhVucGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtTenLinhVuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
