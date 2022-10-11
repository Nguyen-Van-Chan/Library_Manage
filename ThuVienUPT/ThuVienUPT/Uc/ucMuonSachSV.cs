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
    public partial class ucMuonSachSV : DevExpress.XtraEditors.XtraUserControl
    {
        BUS_Sach s = new BUS_Sach();
        BUS_SinhVien sv = new BUS_SinhVien();
        BUS_PhieuNhap pn = new BUS_PhieuNhap();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        BUS_NguoiDung nd = new BUS_NguoiDung();
        BUS_SachISBN s1 = new BUS_SachISBN();
        public ucMuonSachSV()
        {
            InitializeComponent();
        }

        private void ucMuonSachSV_Load(object sender, EventArgs e)
        {
            gridMaSach.Properties.DisplayMember = "TieuDe";
            gridMaSach.Properties.ValueMember = "MaSach";
            gridMaSach.Properties.DataSource = s.SachGet();

            gridThuThu.Properties.DisplayMember = "HoTen";
            gridThuThu.Properties.ValueMember = "TaiKhoan";
            gridThuThu.Properties.DataSource = nd.NguoiDungGet();

            gridMaSV.Properties.DisplayMember = "MaSinhVien";
            gridMaSV.Properties.ValueMember = "MaSinhVien";
            gridMaSV.Properties.DataSource = sv.SinhVienGet();

            gridThuThu.EditValue = gridThuThu.Properties.GetDisplayTextByKeyValue(frmLogin.username);

            DateTime today = DateTime.Now;
            dateNgayMuon.EditValue = today.Date;

            dateNgayTra.EditValue = dateNgayMuon.DateTime.AddDays(7);
        }
        Boolean Kiemtra = false;
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            string masach = gridLookUpEdit3View.GetRowCellValue(gridLookUpEdit3View.FocusedRowHandle, gridLookUpEdit3View.Columns[0]).ToString();
            string tensach = gridMaSach.Text;
            if (dataGV.Rows.Count == 0 && masach != "[Chọn Mã Sách]" )
            {
                dataGV.Rows.Add(masach, tensach);
            }
            else if(dataGV.Rows.Count > 2){
                MessageBox.Show("Không Thể Mượn Được Nữa");
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
                    dataGV.Rows.Add(masach, tensach);
                }
            }
        }
        public string AutiIDPhieuMuon()
        {
            string _x = "";
            DataTable dt = new DataTable();
            dt = pm.PhieuMuonSelectLastID();
            if (dt.Rows.Count == 0)
                _x = "PM0000";
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
        public void ThemPM()
        {
            DataTable dt = new DataTable();
            DTO_PhieuMuon phieumuon = new DTO_PhieuMuon();
            phieumuon.Maphieu = txtMaPhieu.Text;
            phieumuon.Ngaymuon = Convert.ToDateTime(dateNgayMuon.EditValue);
            phieumuon.Ngaytra = Convert.ToDateTime(dateNgayTra.EditValue);
            phieumuon.Masinhvien = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
            phieumuon.Thuthu = gridLookUpEdit2View.GetRowCellValue(gridLookUpEdit2View.FocusedRowHandle, gridLookUpEdit2View.Columns[0]).ToString();
            phieumuon.Ghichu = txtGhiChu.Text;
            phieumuon.Tinhtrang = txtTinhTrang.Text;
            dt = pm.NghiepVuMuonSachPhieuMuon(phieumuon);
        }
        public void ThemCTPM()
        {
            DataTable dt = new DataTable();
            string maphieu = txtMaPhieu.Text;
            string masach = "";

            for(int i = 0; i < dataGV.RowCount; i++)
            {
                masach = dataGV.Rows[i].Cells[0].Value.ToString();
                dt = ctpm.NghiepVuMuonSachChiTiet(maphieu, masach);
            }
        }
        private void btnThemPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaPhieu.Text = AutiIDPhieuMuon();
        }

        private void btnLuuPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ThemPM();
                ThemCTPM();
                MessageBox.Show("Mượn Sách Thư Viện Thành Công");
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        private void dateNgayMuon_EditValueChanged(object sender, EventArgs e)
        {
            dateNgayTra.Text = Convert.ToDateTime(dateNgayMuon.EditValue).AddDays(7).ToString();
        }
    }
}
