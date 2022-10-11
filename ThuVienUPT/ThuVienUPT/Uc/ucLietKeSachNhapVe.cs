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
using ThuVienUPT.Report;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace ThuVienUPT.Uc
{
    public partial class ucLietKeSachNhapVe : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_PhieuNhap pn = new BUS_PhieuNhap();
        BUS_NguoiDung nd = new BUS_NguoiDung();
        public ucLietKeSachNhapVe()
        {
            InitializeComponent();
        }

        private void ucLietKeSachNhapVe_Load(object sender, EventArgs e)
        {
            gcData.DataSource = pn.LKSachNhapVe();
            this.gvData.BestFitColumns();
        }

        private void btnSachNhapVe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReport_SachNhapVe frmtv = new frmReport_SachNhapVe();
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
