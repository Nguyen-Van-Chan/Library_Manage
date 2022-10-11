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
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace ThuVienUPT.Uc
{
    public partial class ucTimKiemTheoNgay : XtraUserControl
    {
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public ucTimKiemTheoNgay()
        {
            InitializeComponent();
        }

        private void uc_TimKiemTheoNgay_Load(object sender, EventArgs e)
        {
            
        }
        public DataTable TimNgayMuon()
        {
            DataTable dt = new DataTable();
            DTO_PhieuNhap phieunhap = new DTO_PhieuNhap();
            DateTime start = DateTime.Parse(dateTuNgay.Text);
            DateTime end = DateTime.Parse(dateDenNgay.Text);
            dt = pm.PhieuNhapByDate(start,end);
            return dt;
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(dateTuNgay.Text == "" && dateDenNgay.Text== "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                
            } else
            gcData.DataSource= TimNgayMuon();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_PMTheoNgay frmtv = new frmReport_PMTheoNgay();
            using (ReportPrintTool printTool = new ReportPrintTool(frmtv))
            {
                frmtv.Parameters[0].Value = DateTime.Parse(dateTuNgay.Text); 
                frmtv.Parameters[0].Value = DateTime.Parse(dateDenNgay.Text); 
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}
