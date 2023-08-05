using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyks
{
    public partial class FormLoaiPhong : Form
    {
        public FormLoaiPhong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                //string sql = "insert into LoaiPhong(MaLP, TenLoai) values(N'{0}',N'{1}')";
                string sql = "exec spThemLoaiPhong N'{0}',N'{1}'";
                db.executeQuery(String.Format(sql, txtMaLoaiPhong.Text, txtTenLoai.Text));
                MessageBox.Show("Thành Công");
                this.Visible = false;
                Form1 form1 = new Form1();
                form1.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLoaiPhong_Load(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                DataTable dt = db.runQuery("select count(*) + 1 as SL from LoaiPhong");
                string MaLoaiPhong = "LP00" + dt.Rows[0]["SL"].ToString();
                txtMaLoaiPhong.Text = MaLoaiPhong;
                txtMaLoaiPhong.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
