using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS_ThuVien;
using DTO_ThuVien;
using System.IO;
using System.Diagnostics;

namespace ThuVienUPT.Uc
{
    public partial class ucLop : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_Lop l = new BUS_Lop();
        public ucLop()
        {
            InitializeComponent();
        }

        private void ucLop_Load(object sender, EventArgs e)
        {
            gridData.DataSource = l.LopGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            txtMaLop.Text = gvData.GetFocusedRowCellValue("MaLop").ToString();
            txtTenLop.Text = gvData.GetFocusedRowCellValue("TenLop").ToString();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenLop.Focus();
            txtMaLop.Text = l.LopIDMax("Lop").Rows[0]["ID"].ToString();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_Lop lop = new DTO_Lop();
            lop.Malop = int.Parse(txtMaLop.Text);
            dt = l.LopDelete(lop);
            gridData.DataSource = l.LopGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenLop.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên lớp", "Thông báo");
                txtTenLop.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_Lop lop = new DTO_Lop();
            lop.Malop = int.Parse(txtMaLop.Text);
            lop.Tenlop = txtTenLop.Text;
            dt = l.LopModify(lop);
            gridData.DataSource = l.LopGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gridData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }
    }
}
