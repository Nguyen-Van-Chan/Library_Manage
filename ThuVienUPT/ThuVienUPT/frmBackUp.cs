using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;


namespace ThuVienUPT
{
    public partial class frmBackUp : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=TDK\TDK;Initial Catalog=ThuVienUPT;Integrated Security=True"); 
        public frmBackUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            string folderPath = "";
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;

            folderBrowser.FileName = "Mời Bạn Chọn Thư Mục";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                 folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
            }
            textBox1.Text = folderPath;
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_BackUP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@duongdan", textBox1.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Sao Lưu Thành Công");
            } catch (Exception e1)
            {
                label2.Text = e1.ToString();
            }
        }
       
    }
}
