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
    public partial class ucSachTLV : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_Sach s = new BUS_Sach();
        BUS_LinhVuc lv = new BUS_LinhVuc();
        BUS_NgonNgu nn = new BUS_NgonNgu();
        BUS_NhaXuatBan nxb = new BUS_NhaXuatBan();
        public ucSachTLV()
        {
            InitializeComponent();
        }

        private void ucSachTLV_Load(object sender, EventArgs e)
        {
            gcData.DataSource = s.SachThongKe();
            this.gvData.BestFitColumns();
        }

        private void btnReportSachTLV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_SachTLV frmtv = new frmReport_SachTLV();
            using (ReportPrintTool printTool = new ReportPrintTool(frmtv))
            {
                printTool.ShowPreviewDialog(UserLookAndFeel.Default);
            }
        }
    }
}
