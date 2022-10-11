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
using System.Globalization;

namespace ThuVienUPT.Uc
{
    public partial class ucNhapSachSV : UserControl
    {
        BUS_ChiTietPhieuNhap ctpn = new BUS_ChiTietPhieuNhap();
        BUS_PhieuNhap pn = new BUS_PhieuNhap();
        BUS_NguoiDung nd = new BUS_NguoiDung();
        BUS_NhaCungCap ncc = new BUS_NhaCungCap();
        BUS_Sach s = new BUS_Sach();
        public ucNhapSachSV()
        {
            InitializeComponent();
        }

        private void ucNhapSachSV_Load(object sender, EventArgs e)
        {
            gridMaSach.Properties.DisplayMember = "TieuDe";
            gridMaSach.Properties.ValueMember = "MaSach";
            gridMaSach.Properties.DataSource = s.SachGet();

            gridThuThu.Properties.DisplayMember = "HoTen";
            gridThuThu.Properties.ValueMember = "TaiKhoan";
            gridThuThu.Properties.DataSource = nd.NguoiDungGet();

            gridCongTy.Properties.DisplayMember = "TenNhaCungCap";
            gridCongTy.Properties.ValueMember = "ID";
            gridCongTy.Properties.DataSource = ncc.NhaCungCapGet();

            gridThuThu.EditValue = gridThuThu.Properties.GetDisplayTextByKeyValue(frmLogin.username);
            txtSoLuong.Text = "1";

            DateTime today = DateTime.Now;
            dateNgayNhap.EditValue = today.Date;
            //DataTable dtSach = s.SachGet();
            //AutoCompleteStringCollection autoText = new AutoCompleteStringCollection();
            //foreach(DataRow dt in dtSach.Rows)
            //{
            //    autoText.Add(dt["TieuDe"].ToString());
            //}
            //txtMaSach.AutoCompleteMode = AutoCompleteMode.Suggest;
            //txtMaSach.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtMaSach.AutoCompleteCustomSource = autoText;

        }
        Boolean Kiemtra = false;
        private void btnThemVao_Click(object sender, EventArgs e)
        {
           // string masach= "";
            string masach = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
            if (masach == "")
            {

            }
            string tensach = gridMaSach.Text;
            int gianhap = int.Parse(txtGiaNhap.Text);
            int soluong = int.Parse(txtSoLuong.Text);
            if (dataGV.Rows.Count == 0 && masach != "[Chọn Mã Sách]")
            {
                dataGV.Rows.Add(masach, tensach, soluong, gianhap);
            }
            else
            {
                foreach (DataGridViewRow dr in dataGV.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == masach)
                    {
                        Kiemtra = true;
                        MessageBox.Show("Sách này đã tồn tại");
                    }
                    else
                    {
                        Kiemtra = false;

                    }
                }
                if (Kiemtra == false && dataGV.Rows.Count != 0)
                {
                    dataGV.Rows.Add(masach, tensach, soluong, gianhap);
                }
            }
         }
        public string AutiIDPhieuNhap()
        {
            string _x = "";
            DataTable dt = new DataTable();
            dt = pn.PhieuNhapSelectLastID();
            if (dt.Rows.Count == 0)
                _x = "PN0000";
            else
                _x = dt.Rows[0]["MaPhieu"].ToString();
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
            txtMaPhieu.Text = AutiIDPhieuNhap();
        }
        public void ThemPN()
        {
            DataTable dt = new DataTable();
            DTO_PhieuNhap phieunhap = new DTO_PhieuNhap();
            phieunhap.Maphieu = txtMaPhieu.Text;
            phieunhap.Ngaynhap = Convert.ToDateTime(dateNgayNhap.EditValue);
            phieunhap.Congty = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
            phieunhap.Thuthu = gridLookUpEdit2View.GetRowCellValue(gridLookUpEdit2View.FocusedRowHandle, gridLookUpEdit2View.Columns[0]).ToString();
            phieunhap.Ghichu = txtGhiChu.Text;
            dt = pn.NghiepVuNhapSachPhieuNhap(phieunhap);
        }
        public void ThemCTPN()
        {
            DataTable dt = new DataTable();
            string maphieu = txtMaPhieu.Text;
            int gianhap = int.Parse(txtGiaNhap.Text);
            int soluong = int.Parse(txtSoLuong.Text);
            string masach = "";

            for (int i = 0; i < dataGV.RowCount; i++)
            {
                masach = dataGV.Rows[i].Cells[0].Value.ToString();
                dt = ctpn.NghiepVuNhapSachChiTiet(maphieu, masach,gianhap,soluong);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ThemPN();
                ThemCTPN();
                MessageBox.Show("Nhập sách thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi trong quá trình nhập sách");
            }
        }
    }
}
