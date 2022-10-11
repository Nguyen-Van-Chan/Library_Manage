using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_ThuVien;
using DTO_ThuVien;
using DevExpress.XtraGrid.Views.Grid;

namespace ThuVienUPT.FRM
{
    public partial class frmCTPM : Form
    {
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        public frmCTPM()
        {
            InitializeComponent();
        }

        private void frmCTPM_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ctpm.ChiTietPhieuMuonGetByID(Uc.ucPhieuMuon.mapm);
            this.Text = "Chi tiết phiếu mượn: " + Uc.ucPhieuMuon.mapm;
            gridControl1.DataSource = dt;
        }
    }
}
