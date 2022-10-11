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
    public partial class ucTatCaPhieuMuon : UserControl
    {
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public ucTatCaPhieuMuon()
        {
            InitializeComponent();
        }

        private void ucTatCaPhieuMuon_Load(object sender, EventArgs e)
        {
            //gridControl1.DataSource = pm.PhieuMuonGet();
            //this.gridView1.BestFitColumns();
        }
        public DataTable TimTatCaPM()
        {
            DataTable dt = new DataTable();
            dt = pm.PhieuMuonGet();
            return dt;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           gridControl1.DataSource= TimTatCaPM();
        }
    }
}
