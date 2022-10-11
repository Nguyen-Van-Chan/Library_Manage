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
    public partial class ucTimKiemQuaHan : XtraUserControl
    {
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public ucTimKiemQuaHan()
        {
            InitializeComponent();
        }

        private void ucTimKiemQuaHan_Load(object sender, EventArgs e)
        {

        }
        public DataTable TimPhieuMuonQuaHan()
        {
            DataTable dt = new DataTable();
            dt = pm.PhieuMuonQuaHan();
            return dt;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = TimPhieuMuonQuaHan();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_PMQuaHan frmtv = new frmReport_PMQuaHan();
            using (ReportPrintTool printTool = new ReportPrintTool(frmtv))
            {
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}
