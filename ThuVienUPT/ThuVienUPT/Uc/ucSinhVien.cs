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
    public partial class ucSinhVien : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_SinhVien s = new BUS_SinhVien();
        BUS_Lop lop = new BUS_Lop();
        public ucSinhVien()
        {
            InitializeComponent();
        }

        private void ucSinhVien_Load(object sender, EventArgs e)
        {
            gridLop.Properties.DisplayMember = "TenLop";
            gridLop.Properties.ValueMember = "MaLop";
            gridLop.Properties.DataSource = lop.LopGet();

           
            gcdata.DataSource = s.SinhVienGet();
            this.gvdata.BestFitColumns();
        }
        public string AutiIDSinhVien()
        {
            string _x = "";
            DataTable dt = new DataTable();
            dt = s.SinhVienSelectLastID();
            if (dt.Rows.Count == 0)
                _x = "000000000";
            else
                _x = dt.Rows[0]["MaSinhVien"].ToString();
            string kq = "";
            string left = _x.Substring(0, 2).ToString();
            string snew = _x.Substring(2, 4).ToString();
            int i = int.Parse(snew);
            i++;
            if (i < 10)
                kq = "000000" + i.ToString();
            if (i >= 10 && i < 100)
                kq = "0000" + i.ToString();
            if (i >= 100 && i < 1000)
                kq = "00" + i.ToString();
            if (i >= 1000)
                kq = i.ToString();
            return left + kq;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaSV.Text = AutiIDSinhVien();
            txtTenSV.Focus();
            txtTenSV.Text = txtGT.Text = dateNS.Text = txtDT.Text = txtEmail.Text = "";
            gridLop.EditValue = null;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_SinhVien sv = new DTO_SinhVien();
            sv.Masinhvien = txtMaSV.Text;
            dt = s.SinhVienDelete(sv);
            gcdata.DataSource = s.SinhVienGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenSV.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sinh viên", "Thông báo");
                txtTenSV.Focus();
                return;
            }
            if (txtGT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giới tính", "Thông báo");
                txtGT.Focus();
                return;
            }
            if (dateNS.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh", "Thông báo");
                dateNS.Focus();
                return;
            }
            if (gridLop.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn lớp", "Thông báo");
                gridLop.Focus();
                return;
            }
            if (txtDT.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập điện thoại", "Thông báo");
                txtDT.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên email", "Thông báo");
                txtEmail.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_SinhVien sinhvien = new DTO_SinhVien();
            sinhvien.Masinhvien = txtMaSV.Text;
            sinhvien.Tensinhvien = txtTenSV.Text;
            sinhvien.Gioitinh = txtGT.Text;
            sinhvien.Ngaysinh = Convert.ToDateTime(dateNS.EditValue);
            sinhvien.Lop = int.Parse(gridLop.EditValue.ToString());
            sinhvien.Dienthoai = txtDT.Text;
            sinhvien.Email = txtEmail.Text;
            dt = s.SinhVienModify(sinhvien);
            gcdata.DataSource = s.SinhVienGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcdata.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void gvdata_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaSV.Text = gvdata.GetFocusedRowCellValue("MaSinhVien").ToString();
                txtTenSV.Text = gvdata.GetFocusedRowCellValue("TenSinhVien").ToString();
                txtGT.Text = gvdata.GetFocusedRowCellValue("GioiTinh").ToString();
                dateNS.EditValue = Convert.ToDateTime(gvdata.GetFocusedRowCellValue("NgaySinh").ToString());
                // gridLop.EditValue = gvdata.GetRowCellValue(gvdata.FocusedRowHandle, gvdata.Columns[4]).ToString();
                gridLop.EditValue = gridLop.Properties.GetKeyValue(int.Parse(gvdata.GetFocusedRowCellValue("Lop").ToString()) - 1);
                txtDT.Text = gvdata.GetFocusedRowCellValue("DienThoai").ToString();
                txtEmail.Text = gvdata.GetFocusedRowCellValue("Email").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void txtTenSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtGT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gcdata_Click(object sender, EventArgs e)
        {

        }
    }
}
