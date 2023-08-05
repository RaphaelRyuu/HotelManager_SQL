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
    public partial class PhieuDatPhong : Form
    {
        public PhieuDatPhong()
        {
            InitializeComponent();
        }

        private void PhieuDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                txtNgayNhanPhong.Format = DateTimePickerFormat.Custom;
                txtNgayNhanPhong.CustomFormat = "yyyy-MM-dd";
                dbConnectors db = new dbConnectors();
                string sql = "select MaPhong from Phong where TrangThai=N'trống'";
                DataTable dt = db.runQuery(sql);
                cbMaPhong.DisplayMember = "MaPhong";
                cbMaPhong.DataSource = dt;
                sql = "select MaNV from NhanVien";
                dt = db.runQuery(sql);
                cbMaNV.DisplayMember = "MaNV";
                cbMaNV.DataSource = dt;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnTaoPhieuDatPhong_Click(object sender, EventArgs e)
        {
            string message = "Xác nhận đặt phòng?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "exec taoPhieuDatPhong N'{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}'";
                sql = String.Format(sql, txtTenKH.Text, txtSDT.Text, txtDiaChi.Text, txtCMND.Text, txtNgayNhanPhong.Text, cbMaNV.Text, cbMaPhong.Text, txtNguoiSD);
                db.executeQuery(sql);
                MessageBox.Show("Thành Công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
            else
            {
                // Do something  
            }
        }
    }
}
