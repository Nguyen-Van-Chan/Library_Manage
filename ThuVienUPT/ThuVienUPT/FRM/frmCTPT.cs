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
    public partial class frmCTPT : Form
    {
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        BUS_TraSach ts = new BUS_TraSach();
        public frmCTPT()
        {
            InitializeComponent();
        }

        private void frmTraSachPhieuTra_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ts.ChiTietPhieuTraGetByID(Uc.ucTraSach.mapt);
            this.Text = "Chi Tiết Trả Sách: " + Uc.ucTraSach.mapt;
            gridControl1.DataSource = dt;
        }
    }
}
