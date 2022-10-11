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
    public partial class ucSach : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_Sach s = new BUS_Sach();
        BUS_LinhVuc lv = new BUS_LinhVuc();
        BUS_KeSach ks = new BUS_KeSach();
        BUS_NganSach ns = new BUS_NganSach();
        BUS_NgonNgu nn = new BUS_NgonNgu();
        BUS_Khoa k = new BUS_Khoa();
        BUS_NhaXuatBan nxb = new BUS_NhaXuatBan();
        public ucSach()
        {

            InitializeComponent();

        }

        private void ucSach_Load(object sender, EventArgs e)
        {

            gridLinhVuc.Properties.DisplayMember = "LinhVuc";
            gridLinhVuc.Properties.ValueMember = "ID";
            gridLinhVuc.Properties.DataSource = lv.LinhVucGet();

            gridKe.Properties.DisplayMember = "TenKe";
            gridKe.Properties.ValueMember = "ID";
            gridKe.Properties.DataSource = ks.KeSachGet();

            gridNgan.Properties.DisplayMember = "TenNgan";
            gridNgan.Properties.ValueMember = "ID";
            gridNgan.Properties.DataSource = ns.NganSachGet();

            gridNgonNgu.Properties.DisplayMember = "TenNgonNgu";
            gridNgonNgu.Properties.ValueMember = "ID";
            gridNgonNgu.Properties.DataSource = nn.NgonNguGet();

            gridKhoa.Properties.DisplayMember = "TenKhoa";
            gridKhoa.Properties.ValueMember = "ID";
            gridKhoa.Properties.DataSource = k.KhoaGet();

            gridNhaXuatBan.Properties.DisplayMember = "TenNhaXuatBan";
            gridNhaXuatBan.Properties.ValueMember = "ID";
            gridNhaXuatBan.Properties.DataSource = nxb.NhaXuatBanGet();

            
            gcData.DataSource = s.SachGet();
            //this.gvData.BestFitColumns();

        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTieuDeSach.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tiêu đề sách", "Thông báo");
                txtTieuDeSach.Focus();
                return;
            }
            if (txtSoTrang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số trang", "Thông báo");
                txtSoTrang.Focus();
                return;
            }
            if (txtNamXuatBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm xuất bản", "Thông báo");
                txtNamXuatBan.Focus();
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo");
                txtSoLuong.Focus();
                return;
            }
            if (txtGiaNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá nhập", "Thông báo");
                txtGiaNhap.Focus();
                return;
            }
            if (gridNhaXuatBan.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn nhà xuất bản", "Thông báo");
                gridNhaXuatBan.Focus();
                return;
            }
            if (gridLinhVuc.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn lĩnh vực", "Thông báo");
                gridLinhVuc.Focus();
                return;
            }
            if (gridNgonNgu.EditValue == null)
            {
                MessageBox.Show("Bạn chưa ngôn ngữ sách", "Thông báo");
                gridNgonNgu.Focus();
                return;
            }
            if (gridKe.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn kệ sách", "Thông báo");
                gridKe.Focus();
                return;
            }
            if (gridNgan.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn sách", "Thông báo");
                gridNgan.Focus();
                return;
            }
            if (gridKhoa.EditValue == null)
            {
                MessageBox.Show("Bạn chưa khoa", "Thông báo");
                gridKhoa.Focus();
                return;
            }
            if (dateNgayTao.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày tạo", "Thông báo");
                txtTieuDeSach.Focus();
                return;
            }
            if (dateNgayCapNhat.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn ngày cập nhật", "Thông báo");
                txtTieuDeSach.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_Sach sach = new DTO_Sach();
            sach.Masach = txtMaSach.Text;
            sach.Tieude = txtTieuDeSach.Text;
            sach.Sotrang = int.Parse(txtSoTrang.Text);
            sach.Namxuatban = int.Parse(txtNamXuatBan.Text);
            sach.Nhaxuatban = int.Parse(gridNhaXuatBan.EditValue.ToString());
            sach.Linhvuc = int.Parse(gridLinhVuc.EditValue.ToString());
            sach.Ke = int.Parse(gridKe.EditValue.ToString());
            sach.Ngan = int.Parse(gridNgan.EditValue.ToString());
            sach.Ngonngu = int.Parse(gridNgonNgu.EditValue.ToString());
            sach.Khoa = int.Parse(gridKhoa.EditValue.ToString());
            sach.Soluong = int.Parse(txtSoLuong.Text);
            sach.Gianhap = int.Parse(txtGiaNhap.Text);
            sach.Ngaytao = Convert.ToDateTime(dateNgayTao.EditValue);
            sach.Ngaycapnhat = Convert.ToDateTime(dateNgayCapNhat.EditValue);
            sach.Hinhanh = txtHinhAnh.Text;
            dt = s.SachModify(sach);
            gcData.DataSource = s.SachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
          
        }
        public string AutiIDSach()
        {

            string _x = "";
            DataTable dt = new DataTable();
            dt = s.SachSelectLastID();
            if (dt.Rows.Count == 0)
                _x = "SA0000";
            else
                _x = dt.Rows[0]["MaSach"].ToString();
            string kq = "";
            string left = _x.Substring(0, 2).ToString();
            string snew = _x.Substring(2, 4).ToString();
            int i = int.Parse(snew);
            i++;
            if (i < 10)
                kq = "000" + i.ToString();
            if (i >= 10 && i < 100)
                kq = "00" + i.ToString();
            if (i >= 100 && i < 1000)
                kq = "0" + i.ToString();
            if (i >= 1000)
                kq = i.ToString();
            return left + kq;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaSach.Text = AutiIDSach();
            txtTieuDeSach.Focus();
            txtTieuDeSach.Text = txtSoTrang.Text = txtSoLuong.Text = txtNamXuatBan.Text = txtHinhAnh.Text = txtGiaNhap.Text = "";
            gridNhaXuatBan.EditValue = gridNgonNgu.EditValue = gridNgan.EditValue = gridKe.EditValue = gridKhoa.EditValue = gridLinhVuc.EditValue = null;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            string path = @"D:\Image";
            if (Directory.Exists(path))
                openFileDialog1.InitialDirectory = path;
            else
                openFileDialog1.InitialDirectory = @"D:\";
            openFileDialog1.Title = "Chọn ảnh sách";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.png) | *.jpg; *.jpeg; *.jpe; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHinhAnh.Text = openFileDialog1.FileName;
                picHinhAnh.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             string FileName = "D:\\output.xlsx";
             gcData.ExportToXlsx(FileName);
             Process.Start(FileName);
           
        }

        private void txtTieuDeSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtSoTrang_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtNamXuatBan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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
        private void gridNhaXuatBan_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
                txtMaSach.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[0]).ToString();
                txtTieuDeSach.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[1]).ToString();
                txtSoTrang.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[2]).ToString();
                txtNamXuatBan.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[3]).ToString();
           // gridNhaXuatBan.EditValue= gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[4]).ToString();
                gridNhaXuatBan.EditValue = gridNhaXuatBan.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("NhaXuatBan").ToString()) - 1);
                gridLinhVuc.EditValue = gridLinhVuc.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("LinhVuc").ToString()) - 1);
                gridKe.EditValue = gridKe.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("Ke").ToString()) - 1);
                gridNgan.EditValue = gridNgan.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("Ngan").ToString()) - 1);
                gridNgonNgu.EditValue = gridNgonNgu.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("NgonNgu").ToString()) - 1);
                gridKhoa.EditValue = gridKhoa.Properties.GetKeyValue(int.Parse(gvData.GetFocusedRowCellValue("k").ToString()) - 1);
            //gridLinhVuc.EditValue = gvData.GetFocusedRowCellValue("TenLV").ToString();
            //gridKe.EditValue = gvData.GetFocusedRowCellValue("TenKe").ToString();
            //gridNgan.EditValue = gvData.GetFocusedRowCellValue("TenNgan").ToString();
            //gridNgonNgu.EditValue = gvData.GetFocusedRowCellValue("NN").ToString();
            //gridKhoa.EditValue = gvData.GetFocusedRowCellValue("Khoa").ToString();
                txtSoLuong.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[10]).ToString();
                txtGiaNhap.Text = gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[11]).ToString();
                dateNgayTao.EditValue = Convert.ToDateTime(gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[12]).ToString());
                dateNgayCapNhat.EditValue = Convert.ToDateTime(gvData.GetRowCellValue(gvData.FocusedRowHandle, gvData.Columns[13]).ToString());
            try
            {
                if (gvData.GetFocusedRowCellValue("HinhAnh").ToString() == "")
                {
                    //txtHinhAnh.Text = "Chưa có ảnh";
                    picHinhAnh.Image = Image.FromFile(@"D:\Image\noimage.jpg");
                }
                else
                {
                    txtHinhAnh.Text = gvData.GetFocusedRowCellValue("HinhAnh").ToString();
                    picHinhAnh.Image = Image.FromFile(gvData.GetFocusedRowCellValue("HinhAnh").ToString());
                }
            } catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
            }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_Sach s1 = new DTO_Sach();
             s1.Masach= txtMaSach.Text;
            dt = s.SachDelete(s1);
            gcData.DataSource = s.SachGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
         
        }
    }
}
