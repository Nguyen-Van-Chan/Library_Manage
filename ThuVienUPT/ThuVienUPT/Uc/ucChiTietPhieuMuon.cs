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

namespace ThuVienUPT.Uc
{
    public partial class ucChiTietPhieuMuon : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        BUS_SachISBN isbn = new BUS_SachISBN();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public ucChiTietPhieuMuon()
        {
            InitializeComponent();
        }

        private void ucChiTietPhieuMuon_Load(object sender, EventArgs e)
        {
            gridMaPhieu.Properties.DisplayMember = "MaPhieu";
            gridMaPhieu.Properties.ValueMember = "MaPhieu";
            gridMaPhieu.Properties.DataSource = pm.PhieuMuonGet();
            gcData.DataSource = ctpm.ChiTietPhieuMuonGet();
            this.gvData.BestFitColumns();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                gridMaPhieu.Text = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                txtMaS.Text = gvData.GetFocusedRowCellValue("MaSach").ToString();
             
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaS.Focus();
            txtMaS.Text = "";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_ChiTietPhieuMuon chitietphieumuon = new DTO_ChiTietPhieuMuon();
            chitietphieumuon.Maphieu = gridMaPhieu.Text;
            dt = ctpm.ChiTietPhieuMuonDelete(chitietphieumuon);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            gcData.DataSource = ctpm.ChiTietPhieuMuonGet();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sách", "Thông báo");
                txtMaS.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_ChiTietPhieuMuon chitietphieumuon = new DTO_ChiTietPhieuMuon();
            chitietphieumuon.Maphieu = gridMaPhieu.Text;
            chitietphieumuon.Masach = txtMaS.Text;
            dt = ctpm.ChiTietPhieuMuonModify(chitietphieumuon);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            gcData.DataSource = ctpm.ChiTietPhieuMuonGet();
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtISBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
