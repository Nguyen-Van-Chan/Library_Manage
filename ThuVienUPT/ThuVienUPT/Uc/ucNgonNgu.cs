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
    public partial class ucNgonNgu : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NgonNgu nn = new BUS_NgonNgu();
        public ucNgonNgu()
        {
            InitializeComponent();
        }

        private void ucNgonNgu_Load(object sender, EventArgs e)
        {
            gcData.DataSource = nn.NgonNguGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtID.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTNN.Text = gvData.GetFocusedRowCellValue("TenNgonNgu").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTNN.Focus();
            txtID.Text = nn.NgonNguIDMax("NgonNgu").Rows[0]["ID"].ToString();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NgonNgu ngonngu = new DTO_NgonNgu();
            ngonngu.Id = int.Parse(txtID.Text);
            dt = nn.NgonNguDelete(ngonngu);
            gcData.DataSource = nn.NgonNguGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTNN.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngôn ngữ", "Thông báo");
                txtTNN.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_NgonNgu ngonngu = new DTO_NgonNgu();
            ngonngu.Id = int.Parse(txtID.Text);
            ngonngu.Tenngonngu = txtTNN.Text;
            dt = nn.NgonNguModify(ngonngu);
            gcData.DataSource = nn.NgonNguGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtTNN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
