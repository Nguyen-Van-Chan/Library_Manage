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
    public partial class ucChiTietPhieuNhap : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_ChiTietPhieuNhap ctpn = new BUS_ChiTietPhieuNhap();
        BUS_PhieuNhap pn = new BUS_PhieuNhap();
        BUS_Sach s = new BUS_Sach();
        public ucChiTietPhieuNhap()
        {
            InitializeComponent();
        }

        private void ucChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            gridMaP.Properties.DisplayMember = "MaPhieu";
            gridMaP.Properties.ValueMember = "MaPhieu";
            gridMaP.Properties.NullText = "Chọn Mã Phiếu";
            gridMaP.Properties.DataSource = pn.PhieuNhapGet();

            gcData.DataSource = ctpn.ChiTietPhieuNhapGet();
            this.gvData.BestFitColumns();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                gridMaP.Text = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
                txtMaS.Text = gvData.GetFocusedRowCellValue("MaSach").ToString();
                txtGN.Text = gvData.GetFocusedRowCellValue("GiaNhap").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaS.Focus();
            txtMaS.Text = txtGN.Text = "";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_ChiTietPhieuNhap chitietphieunhap = new DTO_ChiTietPhieuNhap();
            chitietphieunhap.Maphieu = gridMaP.Text;
            dt = ctpn.ChiTietPhieuNhapDelete(chitietphieunhap);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            gcData.DataSource = ctpn.ChiTietPhieuNhapGet();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaS.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sách", "Thông báo");
                txtMaS.Focus();
                return;
            }
            if (txtGN.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá nhập", "Thông báo");
                txtGN.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_ChiTietPhieuNhap chitietphieunhap = new DTO_ChiTietPhieuNhap();
            chitietphieunhap.Maphieu = gridMaP.Text;
            chitietphieunhap.Masach = txtMaS.Text;
            chitietphieunhap.Gianhap = int.Parse(txtGN.Text);
            dt = ctpn.ChiTietPhieuNhapModify(chitietphieunhap);
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            gcData.DataSource = ctpn.ChiTietPhieuNhapGet();
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtGN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void gridMaPhieu_EditValueChanged(object sender, EventArgs e)
        {
            gridMaP.Properties.NullText = "Chọn Mã Phiếu";
        }
        }
}
