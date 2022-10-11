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
    public partial class ucSachThuVienUPT : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_Sach s = new BUS_Sach();
        BUS_LinhVuc lv = new BUS_LinhVuc();
        BUS_NgonNgu nn = new BUS_NgonNgu();
        BUS_NhaXuatBan nxb = new BUS_NhaXuatBan();
        public ucSachThuVienUPT()
        {
            InitializeComponent();
        }

        private void ucSachThuVienUPT_Load(object sender, EventArgs e)
        {
            gcData.DataSource = s.SachThongKe();
            this.gvData.BestFitColumns();
        }

        private void btnReportSachTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_TKTBSachTV frmtv = new frmReport_TKTBSachTV();
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
