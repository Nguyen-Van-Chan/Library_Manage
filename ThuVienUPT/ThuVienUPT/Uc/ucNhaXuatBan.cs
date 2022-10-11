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
    public partial class ucNhaXuatBan : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_NhaXuatBan nxb = new BUS_NhaXuatBan();
        public ucNhaXuatBan()
        {
            InitializeComponent();
        }

        private void ucNhaXuatBan_Load(object sender, EventArgs e)
        {
            gcData.DataSource = nxb.NhaXuatBanGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtID.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTenNXB.Text = gvData.GetFocusedRowCellValue("TenNhaXuatBan").ToString();
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
            txtTenNXB.Focus();
            txtDiaChi.Focus();
            txtDienThoai.Focus();
            txtFax.Focus();
            txtEmail.Focus();
            txtWebsite.Focus();
            txtID.Text = nxb.NhaXuatBanIDMax("NhaXuatBan").Rows[0]["ID"].ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_NhaXuatBan nhaxuatban = new DTO_NhaXuatBan();
            nhaxuatban.Id = int.Parse(txtID.Text);
            dt = nxb.NhaXuatBanDelete(nhaxuatban);
            gcData.DataSource = nxb.NhaXuatBanGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenNXB.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhà xuất bản", "Thông báo");
                txtTenNXB.Focus();
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
            DTO_NhaXuatBan nhaxuatban = new DTO_NhaXuatBan();
            nhaxuatban.Id = int.Parse(txtID.Text);
            nhaxuatban.Tennhaxuatban = txtTenNXB.Text;
            nhaxuatban.Diachi = txtDiaChi.Text;
            nhaxuatban.Dienthoai = txtDienThoai.Text;
            nhaxuatban.Fax = txtFax.Text;
            nhaxuatban.Email = txtEmail.Text;
            nhaxuatban.Website = txtWebsite.Text;
            dt = nxb.NhaXuatBanModify(nhaxuatban);
            gcData.DataSource = nxb.NhaXuatBanGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtTenNXB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
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
    }
}
