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
    public partial class FormThemDichVu : Form
    {
        public FormThemDichVu()
        {
            InitializeComponent();
        }
        void loadData()
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select pdp.MaPDP as N'Mã PDP',ctdv.MaDV as N'Mã dịch vụ',dv.TenDV as N'Tên dịch vụ',ctdv.SoLuong as N'Số lượng', dv.DonGia as N'Đơn giá',(SoLuong*DonGia) as N'Thành tiền'  from PhieuDatPhong pdp inner join ChiTietDichVu ctdv on pdp.MaPDP=ctdv.MaPDP inner join DichVu dv on ctdv.MaDV = dv.MaDV where pdp.MaPDP = '{0}'";
                sql = String.Format(sql, cbMaPDP.Text);
                DataTable dt = db.runQuery(sql);
                dgvCTDV.DataSource = dt;

                sql = "select sum(ctdv.SoLuong * dv.DonGia) as TongTien from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where ctdv.MaPDP = '{0}' group by ctdv.MaPDP";
                dt = db.runQuery(String.Format(sql, cbMaPDP.Text));
                txtHDDV.Text = dt.Rows[0]["TongTien"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FormThemDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select MaPDP from PhieuDatPhong where TrangThai =N'chờ thanh toán'";

                DataTable dt = db.runQuery(sql);
                cbMaPDP.DisplayMember = "MaPDP";
                cbMaPDP.DataSource = dt;

                sql = "select * from xem_danh_sach_dich_vu";
                dt = db.runQuery(sql);
                dgvListDV.DataSource = dt;

                txtThanhTien.ReadOnly = true;
                txtMaDV.ReadOnly = true;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "insert into ChiTietDichVu(MaPDP, MaDV, SoLuong) values('{0}','{1}', {2})";
                db.executeQuery(String.Format(sql, cbMaPDP.Text, txtMaDV.Text, txtSoLuong.Text));
                MessageBox.Show("Thành Công");

                sql = "select * from xem_danh_sach_dich_vu";
                DataTable dt = db.runQuery(sql);
                dgvListDV.DataSource = dt;

                loadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvListDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvListDV.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells[0].Value.ToString();
                txtDonGia.Text = row.Cells[2].Value.ToString();
                txtSoLuong.Clear();
                txtThanhTien.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            int soLuong, donGia;
            donGia = Convert.ToInt32(txtDonGia.Text);
            if (txtSoLuong.Text == "")
            {
                txtThanhTien.Text = "";
            }
            else
            {
                soLuong = Convert.ToInt32(txtSoLuong.Text);
                int thanhTien = donGia * soLuong;
                txtThanhTien.Text = thanhTien.ToString();

            }
        }

        private void cbMaPDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaDV.Clear();
                txtDonGia.Clear();
                txtSoLuong.Clear();
                txtThanhTien.Clear();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCTDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvCTDV.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells[1].Value.ToString();
                txtDonGia.Text = row.Cells[4].Value.ToString();
                txtSoLuong.Text = row.Cells[3].Value.ToString();
                txtThanhTien.Text = row.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatDV_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            try
            {
                string sql = "update ChiTietDichVu set SoLuong=N'{0}' where MaPDP = '{1}' and MaDV ='{2}' ";
                db.executeQuery(String.Format(sql, txtSoLuong.Text, cbMaPDP.Text, txtMaDV.Text));
                MessageBox.Show("Cập nhật Thành Công");

                sql = "select * from xem_danh_sach_dich_vu";
                DataTable dt = db.runQuery(sql);
                dgvListDV.DataSource = dt;


                loadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            string message = "Thao tác sẽ xoá dịch vụ, xác nhận?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
            try
            {
                string sql = "delete from ChiTietDichVu where MaPDP = '{1}' and MaDV ='{2}' ";
                db.executeQuery(String.Format(sql, txtSoLuong.Text, cbMaPDP.Text, txtMaDV.Text));
                MessageBox.Show("Xóa Thành Công");

                sql = "select * from xem_danh_sach_dich_vu";
                DataTable dt = db.runQuery(sql);
                dgvListDV.DataSource = dt;

                loadData();



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
