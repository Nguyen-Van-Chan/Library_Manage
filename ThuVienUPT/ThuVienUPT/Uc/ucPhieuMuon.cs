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
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ThuVienUPT.Report;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace ThuVienUPT.Uc
{
    public partial class ucPhieuMuon : UserControl
    {
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public static string mapm;
        BUS_NguoiDung nd = new BUS_NguoiDung();
        public ucPhieuMuon()
        {
            InitializeComponent();
        }

        private void ucPhieuMuon_Load(object sender, EventArgs e)
        {
            //gridThuThu.Properties.DisplayMember = "HoTen"; 
            //gridThuThu.Properties.ValueMember = "TaiKhoan";
            //gridThuThu.Properties.DataSource = nd.NguoiDungGet();

            gcData.DataSource = pm.PhieuMuonGet();
            this.gvData.BestFitColumns();

        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                //txtMaP.Text = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                //dateNgayMuon.EditValue = Convert.ToDateTime(gvData.GetFocusedRowCellValue("NgayMuon").ToString());
                //dateNgayTra.EditValue = Convert.ToDateTime(gvData.GetFocusedRowCellValue("NgayTra").ToString());
                //txtMaSV.Text = gvData.GetFocusedRowCellValue("MaSinhVien").ToString();
                //gridThuThu.Text = gvData.GetFocusedRowCellValue("ThuThu").ToString();
                //txtGhiChu.Text = gvData.GetFocusedRowCellValue("GhiChu").ToString();
                //txtTinhTrang.Text = gvData.GetFocusedRowCellValue("TinhTrang").ToString();
            }
            catch (Exception)
            {
            }
        }
        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
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
                mapm = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                FRM.frmCTPM frm = new FRM.frmCTPM();
                frm.ShowDialog();
            }
        }

        private void btnInPhieu_Click(object sender, EventArgs e)
        {
           frmReport_PrintPM frmtv = new frmReport_PrintPM();
           using (ReportPrintTool printTool = new ReportPrintTool(frmtv))
            {
                frmtv.Parameters[0].Value = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        //    DataTable dt = new DataTable();
        //    DTO_PhieuMuon phieumuon = new DTO_PhieuMuon();
        //    phieumuon.Maphieu = txtMaP.Text;
        //    dt = pm.PhieuMuonDelete(phieumuon);
        //    MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        //    gcData.DataSource = pm.PhieuMuonGet();
        }
    }
}
