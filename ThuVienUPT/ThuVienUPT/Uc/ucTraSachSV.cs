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
using System.Data.SqlClient;

namespace ThuVienUPT.Uc
{
    public partial class ucTraSachSV : DevExpress.XtraEditors.XtraUserControl
    {
        DateTime ngaytra = DateTime.Now;
        BUS_TraSach ts = new BUS_TraSach();
        BUS_PhieuMuon pm = new BUS_PhieuMuon();
        BUS_NguoiDung nd = new BUS_NguoiDung();
        BUS_SinhVien sv = new BUS_SinhVien();
        BUS_ChiTietPhieuMuon ctpm = new BUS_ChiTietPhieuMuon();
        public ucTraSachSV()
        {
            InitializeComponent();
        }
        private void ucTraSachSV_Load(object sender, EventArgs e)
        {
            gridMaPhieu.Properties.DisplayMember = "MaPhieu";
            gridMaPhieu.Properties.ValueMember = "MaPhieu";
            gridMaPhieu.Properties.DataSource = pm.PhieuMuonGet();

            dateNgayTra.EditValue = ngaytra;
        }    
        private void gridMaPhieu_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = pm.PhieuMuonGetID(gridMaPhieu.Text);
            dateNgayTra.EditValue = dt.Rows[0]["NgayTra"].ToString();
            txtThuThu.Text = dt.Rows[0]["ThuThu"].ToString();
            txtGhiChu.Text = dt.Rows[0]["GhiChu"].ToString();
            txtMaSV.Text = dt.Rows[0]["MaSinhVien"].ToString();
        }

        private void btnThemvao_Click(object sender, EventArgs e)
        {
          //  string masach = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
          //  string tensach = gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns[0]).ToString();
            DataTable dt = new DataTable();
            dt = ctpm.ChiTietPhieuMuonGetByID(gridMaPhieu.Text);
            dataGridView1.DataSource = dt;
          //dataGridView1.Rows.Add(masach, tensach);
            MessageBox.Show("Thêm vào thành công");
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string maphieu = gridMaPhieu.Text;
            string thuthu = txtThuThu.Text;
            string ghichu = txtGhiChu.Text;
            string masinhvien = txtMaSV.Text;
            dt = pm.NghiepVuTraSachSV(maphieu, thuthu, ngaytra, ghichu, masinhvien);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataTable dt1 = pm.NghiepVuTraSachChiTiet(maphieu, row.Cells[0].Value.ToString());
            }
            MessageBox.Show("Trả Sách Thành Công");
            DataTable dt2 = new DataTable();
            dt2 = pm.PhieuMuonDelete(maphieu);
        }
    }
}
