using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using BUS_ThuVien;
using DTO_ThuVien;
using System.IO;
using ThuVienUPT.Report;

namespace ThuVienUPT.Uc
{
    public partial class ucSachMNN : UserControl
    {
        BUS_Sach s = new BUS_Sach();
        BUS_LinhVuc lv = new BUS_LinhVuc();
        BUS_NgonNgu nn = new BUS_NgonNgu();
        BUS_NhaXuatBan nxb = new BUS_NhaXuatBan();
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        public ucSachMNN()
        {
            InitializeComponent();
        }

        private void ucSachMNN_Load(object sender, EventArgs e)
        {
            gcData.DataSource = s.SachMNN();
            this.gvData.BestFitColumns();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_SachMNN frmtv = new frmReport_SachMNN();
            using (ReportPrintTool printTool = new ReportPrintTool(frmtv))
            {
                // Invoke the Print Preview form modally,  
                // and load the report document into it. 
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);

                // Invoke the Print Preview form 
                // with the specified look and feel setting. 
                // printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}
