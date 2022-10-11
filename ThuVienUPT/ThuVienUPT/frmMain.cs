using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThuVienUPT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private static int KiemTraTonTai(DevExpress.XtraTab.XtraTabControl tabControlName, string tabName)
        {
            int re = -1;
            for (int i = 0; i < tabControlName.TabPages.Count; i++)
            {
                if (tabControlName.TabPages[i].Name == tabName)
                {
                    re = i;
                    break;
                }
            }
            return re;
        }
        public void AddNewTab(string Text, string Name, int imageIndex, UserControl userControl)
        {
            int index = KiemTraTonTai(xtraTabControl, Name);
            if (index >= 0)
            {
                xtraTabControl.SelectedTabPage = xtraTabControl.TabPages[index];
                xtraTabControl.SelectedTabPage.Text = Text;
            }
            else
            {
                DevExpress.XtraTab.XtraTabPage tabpage = new DevExpress.XtraTab.XtraTabPage { Text = Text, Name = Name, ImageIndex = imageIndex };
                xtraTabControl.TabPages.Add(tabpage);
                xtraTabControl.SelectedTabPage = tabpage;
                userControl.Parent = tabpage;
                userControl.Show();
                userControl.Dock = DockStyle.Fill;
            }
        }
        private void xtraTabControl_CloseButtonClick(object sender, EventArgs e)
        {
            XtraTabPage page = xtraTabControl.SelectedTabPage;
            xtraTabControl.TabPages.Remove(page);
        }
        private void barDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Close();
        }

        private void barDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucChangePW usercontrol = new Uc.ucChangePW();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navDoiMK_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Đổi Mật Khẩu", "barDoiMatKhau", 0, new Uc.ucChangePW());
        }
        private void navSachTV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách Thư Viện", "barSachTV", 0, new Uc.ucSachThuVienUPT());
        }

        private void barSachTV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSachThuVienUPT usercontrol = new Uc.ucSachThuVienUPT();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSachTLV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách Thuộc Lĩnh Vực", "barSachTLV", 0, new Uc.ucSachThuVienUPT());
        }

        private void barSachTLV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSachTLV usercontrol = new Uc.ucSachTLV();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSachDDM_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách Đang Được Mượn", "barSachDDM", 0, new Uc.ucSachThuVienUPT());
        }

        private void barSachDDM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSachDDM usercontrol = new Uc.ucSachDDM();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSachMNN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách Mượn Nhiều Nhất", "barSachDDM", 0, new Uc.ucSachThuVienUPT());
        }

        private void barSachMNN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSachMNN usercontrol = new Uc.ucSachMNN();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void barMuonSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucMuonSachSV usercontrol = new Uc.ucMuonSachSV();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navMuonSach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Mượn Sách", "barMuonSach", 0, new Uc.ucMuonSachSV());
        }

        private void navQTTraSach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Trả Sách", "barQTTraSach", 0, new Uc.ucTraSachSV());
        }

        private void barQTTraSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucTraSachSV usercontrol = new Uc.ucTraSachSV();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void barSaoLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBackUp backup = new frmBackUp();
            backup.Show();
        }

        private void barSachNhapVe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucLietKeSachNhapVe usercontrol = new Uc.ucLietKeSachNhapVe();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSachNhapVe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách Nhập Về", "barSachNhapVe", 0, new Uc.ucLietKeSachNhapVe());
        }

        private void barNhapSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucNhapSachSV usercontrol = new Uc.ucNhapSachSV();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Nhập Sách", "barNhapSach", 0, new Uc.ucNhapSachSV());
        }

        private void barSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSach usercontrol = new Uc.ucSach();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách", "barSach", 0, new Uc.ucSach());
        }

        private void barTacGia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucTacGia usercontrol = new Uc.ucTacGia();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navTacGia_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Tác Giả", "barTacGia", 0, new Uc.ucTacGia());
        }

        private void barisbn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSachISBN usercontrol = new Uc.ucSachISBN();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSachISBN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sách ISBN", "barisbn", 0, new Uc.ucSachISBN());
        }

        private void barNgonNgu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucNgonNgu usercontrol = new Uc.ucNgonNgu();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navNgonNgu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Ngôn Ngữ", "barNgonNgu", 0, new Uc.ucNgonNgu());
        }

        private void barLinhVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucLinhVuc usercontrol = new Uc.ucLinhVuc();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navLinhVuc_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Lĩnh Vực", "barLinhVuc", 0, new Uc.ucLinhVuc());
        }

        private void barNhaXuatBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucNhaXuatBan usercontrol = new Uc.ucNhaXuatBan();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navNhaXuatBan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Nhà Xuất Bản", "barNhaXuatBan", 0, new Uc.ucNhaXuatBan());
        }

        private void barNganSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucNganSach usercontrol = new Uc.ucNganSach();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navNganSach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Ngăn Sách", "barNganSach", 0, new Uc.ucNganSach());
        }

        private void barKeSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucKeSach usercontrol = new Uc.ucKeSach();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navKeSach_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Kệ Sách", "barKeSach", 0, new Uc.ucKeSach());
        }

        private void barSinhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucSinhVien usercontrol = new Uc.ucSinhVien();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navSinhVien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Sinh Viên", "barSinhVien", 0, new Uc.ucSinhVien());
        }

        private void barKhoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucKhoa usercontrol = new Uc.ucKhoa();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navKhoa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Khoa", "barKhoa", 0, new Uc.ucKhoa());
        }

        private void barLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucLop usercontrol = new Uc.ucLop();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navLop_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Lớp", "barLop", 0, new Uc.ucLop());
        }

        private void barNhaCungCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucNhaCungCap usercontrol = new Uc.ucNhaCungCap();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navNhaCungCap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Nhà Cung Cấp", "barNhaCungCap", 0, new Uc.ucNhaCungCap());
        }

        private void barPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucPhieuNhap usercontrol = new Uc.ucPhieuNhap();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navPN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Phiếu Nhập", "barPhieuNhap", 0, new Uc.ucPhieuNhap());
        }

        private void barPhieuMuon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucPhieuMuon usercontrol = new Uc.ucPhieuMuon();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }

        private void navPM_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Phiếu Mượn", "barPhieuMuon", 0, new Uc.ucPhieuMuon());
        }

        private void navTS_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Trả Sách", "barTraSach", 0, new Uc.ucTraSach());
        }

        private void barPMQH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucTimKiemQuaHan usercontrol = new Uc.ucTimKiemQuaHan();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }
        private void navPMQH_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Phiếu Mượn Quá Hạn", "barPMQH", 0, new Uc.ucTimKiemQuaHan());
        }
        private void barPMTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucTimKiemTheoNgay usercontrol = new Uc.ucTimKiemTheoNgay();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }
        private void navPMTN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Phiếu Mượn Theo Ngày", "barPMTN", 0, new Uc.ucTimKiemTheoNgay());
        }

        private void navNguoiDung_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AddNewTab("Người Dùng", "barNguoiDung", 0, new Uc.ucNguoiDung());
        }

        private void btnAllPM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Uc.ucTatCaPhieuMuon usercontrol = new Uc.ucTatCaPhieuMuon();
            AddNewTab(e.Item.Caption, e.Item.Name, e.Item.ImageIndex, usercontrol);
        }
    }
}
