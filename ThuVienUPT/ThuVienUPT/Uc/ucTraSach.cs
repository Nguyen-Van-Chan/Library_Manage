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
using System.Diagnostics;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ThuVienUPT.Uc
{
    public partial class ucTraSach : XtraUserControl
    {
        BUS_TraSach ts = new BUS_TraSach();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        public static string mapt;
        BUS_NguoiDung nd = new BUS_NguoiDung();
        BUS_SinhVien sv = new BUS_SinhVien();
        public ucTraSach()
        {
            InitializeComponent();
        }

        private void ucTraSach_Load(object sender, EventArgs e)
        {
            //gridMaPhieu.Properties.DisplayMember = "MaPhieu";
            //gridMaPhieu.Properties.ValueMember = "MaPhieu";
            //gridMaPhieu.Properties.DataSource = pm.PhieuMuonGet();

            //gridThuThu.Properties.DisplayMember = "HoTen";
            //gridThuThu.Properties.ValueMember = "TaiKhoan";
            //gridThuThu.Properties.DataSource = nd.NguoiDungGet();

            //gridMaSV.Properties.DisplayMember = "TenSinhVien";
            //gridMaSV.Properties.ValueMember = "MaSinhVien";
            //gridMaSV.Properties.DataSource = sv.SinhVienGet();

              gcData.DataSource = ts.TraSachGet();
           //   this.gvData.BestFitColumns();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //try
            //{
            //    gridMaPhieu.Text = gvData.GetFocusedRowCellValue("MaPhieu").ToString();
            //    dateNgayTra.EditValue = Convert.ToDateTime(gvData.GetFocusedRowCellValue("NgayTra").ToString());
            //    gridThuThu.Text = gvData.GetFocusedRowCellValue("ThuThu").ToString();
            //    txtGhiChu.Text = gvData.GetFocusedRowCellValue("GhiChu").ToString();
            //    gridMaSV.Text = gvData.GetFocusedRowCellValue("MaSinhVien").ToString();
            //    txtMaPT.Text = gvData.GetFocusedRowCellValue("MaPhieuTra").ToString();
            //}
            //catch (Exception)
            //{
            //}
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridThuThu.Focus();
            //gridThuThu.Text = txtGhiChu.Text=txtMaPT.Text=gridMaSV.Text = "";
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DataTable dt = new DataTable();
            //DTO_TraSach trasach = new DTO_TraSach();
            //trasach.Maphieu = gridMaPhieu.Text;
            //dt = ts.TraSachDelete(trasach);
            //MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            //gcData.DataSource = ts.TraSachGet();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (txtMaPT.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập  mã phiếu trả", "Thông báo");
            //    txtGhiChu.Focus();
            //    return;
            //}
            //if (gridThuThu.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập  thủ thư", "Thông báo");
            //    gridThuThu.Focus();
            //    return;
            //}
            //if (txtGhiChu.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập  ghi chú", "Thông báo");
            //    txtGhiChu.Focus();
            //    return;
            //}
            //if (dateNgayTra.EditValue == null)
            //{
            //    MessageBox.Show("Bạn chưa chọn ngày trả", "Thông báo");
            //    dateNgayTra.Focus();
            //    return;
            //}
            //if (gridMaSV.Text == "")
            //{
            //    MessageBox.Show("Bạn chưa nhập  mã sinh viên", "Thông báo");
            //    gridMaSV.Focus();
            //    return;
            //}
            //DataTable dt = new DataTable();
            //DTO_TraSach trasach = new DTO_TraSach();
            //trasach.Maphieu = gridMaPhieu.Text;
            //trasach.Ngaytra = Convert.ToDateTime(dateNgayTra.EditValue);
            //trasach.Thuthu = gridThuThu.Text;
            //trasach.Ghichu = txtGhiChu.Text;
            //trasach.Masinhvien = gridMaSV.Text;
            //trasach.Maphieutra = int.Parse(txtMaPT.Text);
            //dt = ts.TraSachModify(trasach);
            //MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            //gcData.DataSource = ts.TraSachGet();
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtGhiChu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void gvData_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                mapt = gvData.GetFocusedRowCellValue("MaPhieuTra").ToString();
                FRM.frmCTPT frm = new FRM.frmCTPT();
                frm.ShowDialog();
            }
        }
    }
}
