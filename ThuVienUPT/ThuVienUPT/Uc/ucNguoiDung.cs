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
    public partial class ucNguoiDung : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NguoiDung nd = new BUS_NguoiDung();
        public ucNguoiDung()
        {
            InitializeComponent();
        }

        private void ucNguoiDung_Load(object sender, EventArgs e)
        {
            gcData.DataSource = nd.NguoiDungGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtTK.Text = gvData.GetFocusedRowCellValue("TaiKhoan").ToString();
                txtMK.Text = gvData.GetFocusedRowCellValue("MatKhau").ToString();
                txtHT.Text = gvData.GetFocusedRowCellValue("HoTen").ToString();
                txtISADMIN.Text = gvData.GetFocusedRowCellValue("IsAdmin").ToString();
            }
            catch (Exception)
            {
            }
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NguoiDung nguoidung = new DTO_NguoiDung();
            nguoidung.Taikhoan = txtTK.Text;
            dt = nd.NguoiDungDelete(nguoidung);
            gcData.DataSource = nd.NguoiDungGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }
    }
}
