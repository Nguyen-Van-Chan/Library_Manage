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
using System.Diagnostics;

namespace ThuVienUPT.Uc
{
    public partial class ucNhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NhaCungCap ncc = new BUS_NhaCungCap();
        public ucNhaCungCap()
        {
            InitializeComponent();
        }

        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            gcData.DataSource = ncc.NhaCungCapGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtID.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTenNhaCungCap.Text = gvData.GetFocusedRowCellValue("TenNhaCungCap").ToString();
                txtDiaChi.Text = gvData.GetFocusedRowCellValue("DiaChi").ToString();
                txtDienThoai.Text = gvData.GetFocusedRowCellValue("DienThoai").ToString();
                txtFax.Text = gvData.GetFocusedRowCellValue("Fax").ToString();
                txtEmail.Text = gvData.GetFocusedRowCellValue("Email").ToString();
                txtWebsite.Text = gvData.GetFocusedRowCellValue("Website").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenNhaCungCap.Focus();
            txtDiaChi.Focus();
            txtDienThoai.Focus();
            txtFax.Focus();
            txtEmail.Focus();
            txtWebsite.Focus();
            txtID.Text = ncc.NhaCungCapIDMax("NhaCungCap").Rows[0]["ID"].ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NhaCungCap nhacungcap = new DTO_NhaCungCap();
            nhacungcap.Id = int.Parse(txtID.Text);
            dt = ncc.NhaCungCapDelete(nhacungcap);
            gcData.DataSource = ncc.NhaCungCapGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenNhaCungCap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà cung cấp", "Thông báo");
                txtTenNhaCungCap.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo");
                txtDiaChi.Focus();
                return;
            }
            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập điện thoại", "Thông báo");
                txtDienThoai.Focus();
                return;
            }
            if (txtFax.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số fax", "Thông báo");
                txtFax.Focus();
                return;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập email", "Thông báo");
                txtEmail.Focus();
                return;
            }
            if (txtWebsite.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập website", "Thông báo");
                txtWebsite.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_NhaCungCap nhacungcap = new DTO_NhaCungCap();
            nhacungcap.Id = int.Parse(txtID.Text);
            nhacungcap.Tenhacungcap = txtTenNhaCungCap.Text;
            nhacungcap.Diachi = txtDiaChi.Text;
            nhacungcap.Dienthoai = txtDienThoai.Text;
            nhacungcap.Fax = txtFax.Text;
            nhacungcap.Email = txtEmail.Text;
            nhacungcap.Website = txtWebsite.Text;
            dt = ncc.NhaCungCapModify(nhacungcap);
            gcData.DataSource = ncc.NhaCungCapGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtTenNhaCungCap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtWebsite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
