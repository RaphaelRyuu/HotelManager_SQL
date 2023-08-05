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
    public partial class FormThanhToan : Form
    {
        public FormThanhToan()
        {
            InitializeComponent();
        }
        void loadData()
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select pdp.MaPDP as N'Mã PDP',ctdv.MaDV as N'Mã dịch vụ',dv.TenDV as N'Tên dịch vụ',ctdv.SoLuong as N'Số lượng', dv.DonGia as N'Đơn giá',(SoLuong*DonGia) as N'Thành tiền'  from PhieuDatPhong pdp inner join ChiTietDichVu ctdv on pdp.MaPDP=ctdv.MaPDP inner join DichVu dv on ctdv.MaDV = dv.MaDV where pdp.MaPDP = '{0}'";
                sql = String.Format(sql, cbMaDP.Text);
                DataTable dt = db.runQuery(sql);
                dgvCTDV.DataSource = dt;

                sql = "select sum(ctdv.SoLuong * dv.DonGia) as TongTien from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where ctdv.MaPDP = '{0}' group by ctdv.MaPDP";
                dt = db.runQuery(String.Format(sql, cbMaDP.Text));
                txtHDDV.Text = dt.Rows[0]["TongTien"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormThanhToan_Load(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select MaPDP from PhieuDatPhong where TrangThai=N'chờ thanh toán'";
                DataTable dt = db.runQuery(sql);
                cbMaDP.DisplayMember = "MaPDP";
                cbMaDP.DataSource = dt;

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cbMaDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaDP.Text.Length > 0)
            {
                dbConnectors db = new dbConnectors();
                string sql = "select sum(ctdv.SoLuong * dv.DonGia) as TongTien from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where ctdv.MaPDP = '{0}' group by ctdv.MaPDP";
                DataTable dt = db.runQuery(String.Format(sql, cbMaDP.Text));
                txtTongTien.Text = dt.Rows[0]["TongTien"].ToString();

                sql = "select * from PhieuDatPhong where MaPDP = '{0}'";
                dt = db.runQuery(String.Format(sql, cbMaDP.Text));
                txtMaKH.Text = dt.Rows[0]["MaKH"].ToString();
                txtMaNV.Text = dt.Rows[0]["MaNV"].ToString();
                txtTrangThai.Text = dt.Rows[0]["TrangThai"].ToString();
                txtNguoiSD.Text = dt.Rows[0]["NguoiSD"].ToString();

                sql = "select datediff(day, PhieuDatPhong.NgayNhan, getdate()) as SoNgay from PhieuDatPhong where MaPDP='{0}'";
                dt = db.runQuery(String.Format(sql, cbMaDP.Text));
                txtSoNgay.Text = dt.Rows[0]["SoNgay"].ToString();

                sql = "select p.DonGia as GiaPhong from Phong p inner join PhieuDatPhong pdp on p.MaPhong = pdp.MaPhong where pdp.MaPDP = '{0}'";
                dt = db.runQuery(String.Format(sql, cbMaDP.Text));
                txtGiaPhong.Text = dt.Rows[0]["GiaPhong"].ToString();

                int soNgay = Convert.ToInt32(txtSoNgay.Text);
                int giaPhong = Convert.ToInt32(txtGiaPhong.Text);
                int tienPhong = soNgay * giaPhong;

                txtTienPhong.Text = tienPhong.ToString();

                int tienDV = Convert.ToInt32(txtTongTien.Text);
                int tienTT = tienDV + tienPhong;
                txtTongTienTT.Text = tienTT.ToString();

                loadData();

                return;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string message = "Xác nhận thanh toán?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
            try
            {
                if (txtTrangThai.Text == "đã thanh toán" || txtTrangThai.Text == "hủy")
                {
                    MessageBox.Show("Không thể thanh toán");
                    return;
                }
                dbConnectors db = new dbConnectors();
                string sql = "exec spTaoHoaDon '{0}', '{1}'";
                sql = String.Format(sql, cbMaDP.Text, txtMaNV.Text);
                db.executeQuery(sql);
                MessageBox.Show("Thành Công");
                return;
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
