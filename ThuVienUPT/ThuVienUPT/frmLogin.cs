using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using BUS_ThuVien;

namespace ThuVienUPT
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        Point mousedownpoint = Point.Empty;
        BUS_NguoiDung bus_nd = new BUS_NguoiDung();
        public static string username;
        public frmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
        private void lblThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
                return;
            }
            if (int.Parse(bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["errcode"].ToString()) == 1)
            {
                username = bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["UserName"].ToString();
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
                lblThongBao.Text = bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["errmsg"].ToString();
        }
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            mousedownpoint = new Point(e.X, e.Y);
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedownpoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mousedownpoint.X), f.Location.Y + (e.Y - mousedownpoint.Y));
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            mousedownpoint = Point.Empty;
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
                {
                    lblThongBao.Text = "Vui lòng nhập đầy đủ thông tin";
                    return;
                }
                if (int.Parse(bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["errcode"].ToString()) == 1)
                {
                    // mk = txtMatKhau.Text;
                    username = bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["UserName"].ToString();
                    frmMain frm = new frmMain();
                    frm.Show();
                    this.Hide();
                }
                else
                    lblThongBao.Text = bus_nd.NguoiDungDangNhap(txtTenDangNhap.Text, txtMatKhau.Text).Rows[0]["errmsg"].ToString();
            }
        }
    }
}