using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS_ThuVien;
using DTO_ThuVien;
using System.IO;
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ThuVienUPT.Uc
{
    public partial class ucPhieuNhap : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_PhieuNhap pn = new BUS_PhieuNhap();
        BUS_NguoiDung nd = new BUS_NguoiDung();
        BUS_NhaCungCap ncc = new BUS_NhaCungCap();
        public static string mapn;
        public ucPhieuNhap()
        {
            InitializeComponent();
        }
        private void ucPhieuNhap_Load(object sender, EventArgs e)
        {
            //gridThuThu.Properties.DisplayMember = "HoTen";
            //gridThuThu.Properties.ValueMember = "TaiKhoan";
            //gridThuThu.Properties.DataSource = nd.NguoiDungGet();

            //gridCongTy.Properties.DisplayMember = "TenNhaCungCap";
            //gridCongTy.Properties.ValueMember = "ID";
            //gridCongTy.Properties.DataSource = ncc.NhaCungCapGet();

            gcData.DataSource = pn.PhieuNhapGet();
            this.gvData.BestFitColumns();
        }
        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {

                //txtMaP.Text = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                //dateNgayNhap.EditValue = Convert.ToDateTime(gvData.GetFocusedRowCellValue("NgayNhap").ToString());
                //gridCongTy.Text = gvData.GetFocusedRowCellValue("CongTy").ToString();
                //gridThuThu.Text = gvData.GetFocusedRowCellValue("ThuThu").ToString();
                //txtGhiChu.Text = gvData.GetFocusedRowCellValue("GhiChu").ToString();
            }
            catch (Exception)
            {
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        //    DataTable dt = new DataTable();
        //    DTO_PhieuNhap phieunhap = new DTO_PhieuNhap();
        //    phieunhap.Maphieu = txtMaP.Text;
        //    dt = pn.PhieuNhapDelete(phieunhap);
        //    MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        //    gcData.DataSource = pn.PhieuNhapGet();
        }
        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }
        private void txtCongTy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                mapn = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                FRM.frmCTPN frm = new FRM.frmCTPN();
                frm.ShowDialog();
            }
        }
    }
}
