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
    public partial class frmCTPN : Form
    {
        BUS_ChiTietPhieuNhap ctpn = new BUS_ChiTietPhieuNhap();
        public frmCTPN()
        {
            InitializeComponent();
        }
        private void frmCTPN_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsView.ColumnAutoWidth = true;
            int tong = 0;
            DataTable dt = new DataTable();
            dt = ctpn.ChiTietPhieuNhapGetByID(Uc.ucPhieuNhap.mapn);
            this.Text = "Chi tiết phiếu nhập: " + Uc.ucPhieuNhap.mapn;
            gridControl1.DataSource = dt;

            foreach (DataRow row in dt.Rows)
            {
               tong += int.Parse(row["GiaNhap"].ToString()) * int.Parse(row["SoLuong"].ToString());
           }
            textBox1.Text = tong.ToString();

            //gridColumn1.OptionsColumn.FixedWidth=true;
        }
    }
}
