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
    public partial class ucTacGia : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_TacGia tg = new BUS_TacGia();
        public ucTacGia()
        {
            InitializeComponent();
        }

        private void ucTacGia_Load(object sender, EventArgs e)
        {
            gcData.DataSource = tg.TacGiaGet();
        }

        private void gvData_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                txtMaTG.Text = gvData.GetFocusedRowCellValue("ID").ToString();
                txtTenTG.Text = gvData.GetFocusedRowCellValue("TenTacGia").ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtTenTG.Focus();
            txtMaTG.Text = tg.TacGiaIDMax("TacGia").Rows[0]["ID"].ToString();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            DTO_TacGia tacgia = new DTO_TacGia();
            tacgia.Id = int.Parse(txtMaTG.Text);
            dt = tg.TacGiaDelete(tacgia);
            gcData.DataSource = tg.TacGiaGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtTenTG.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tác giả", "Thông báo");
                txtTenTG.Focus();
                return;
            }
            DataTable dt = new DataTable();
            DTO_TacGia tacgia = new DTO_TacGia();
            tacgia.Id = int.Parse(txtMaTG.Text);
            tacgia.Tentacgia = txtTenTG.Text;
            dt = tg.TacGiaModify(tacgia);
            gcData.DataSource = tg.TacGiaGet();
            MessageBox.Show(dt.Rows[0]["errmsg"].ToString());
            
        }

        private void btnXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FileName = "D:\\output.xlsx";
            gcData.ExportToXlsx(FileName);
            Process.Start(FileName);
        }

        private void txtTenTG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) != true && Char.IsNumber(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
