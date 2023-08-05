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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        void TraCuu(DataGridView dgv, String table, String cbText, String content, string sql)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                sql = String.Format(sql, table, cbText, content);
                DataTable dt = db.runQuery(sql);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        void TraCuuPhong(DataGridView dgv, String cbText, String content)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                if (cbText == "")
                {
                    string sql = "select * xem_danh_sach_phong";
                    DataTable dt = db.runQuery(sql);
                    dgv.DataSource = dt;
                }
                else
                {
                    string sql = "select p.MaPhong as 'Mã Phòng', p.DonGia as 'Đơn Giá', p.TrangThai as 'Trạng Thái',lp.TenLoai as 'Loại Phòng' from Phong p inner join LoaiPhong lp on lp.MaLP = p.MaLP where {0} like N'%{1}%'";
                    //string sql = "select * from {0} where {1} like N'%{2}%'";
                    sql = String.Format(sql, cbText, content);
                    DataTable dt = db.runQuery(sql);
                    dgv.DataSource = dt;
                }


            }
            catch (Exception ex)
            {
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select MaLP from LoaiPhong";
                DataTable dt = db.runQuery(sql);
                cbLoaiMPMoi.DisplayMember = "MaLP";
                cbLoaiMPMoi.DataSource = dt;

                dt = db.runQuery("select count(*) + 1 as SL from NhanVien");
                string MaNV = "NV00" + dt.Rows[0]["SL"].ToString();
                txtMaNVMoi.Text = MaNV;
                txtMaNVMoi.Enabled = false;

                dt = db.runQuery("select count(*) + 1 as SL from KhachHang");
                string MaKH = "KH00" + dt.Rows[0]["SL"].ToString();
                txtMaKHMoi.Text = MaKH;
                txtMaKHMoi.Enabled = false;

                dt = db.runQuery("select count(*) + 1 as SL from Phong");
                string MaPhong = "P00" + dt.Rows[0]["SL"].ToString();
                txtMaPhongMoi.Text = MaPhong;
                txtMaPhongMoi.Enabled = false;

                return;
            }
            catch (Exception ex)
            {
            }
        }

        void loadData(DataGridView dgv, String table)
        {
            try
            {
                string sql = "select * from " + table + "";
                //sql = String.Format(sql, tb.ToString());
                dbConnectors db = new dbConnectors();
                DataTable dt = db.runQuery(sql);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        //tab quan ly PDP
        private void btnTimPDP_Click(object sender, EventArgs e)
        {
            String sqlPDP = "select   pdp.MaPDP as N'Mã PDP' ,pdp.MaKH as N'Mã khách hàng', kh.TenKH as N'Tên khách hàng', p.MaPhong as N'Mã Phòng', pdp.NgayDat as N'Ngày đặt', pdp.NgayNhan as N'Ngày nhận', pdp.TrangThai as N'Trạng thái'" +
                "from Phong p left join {0} pdp on p.MaPhong = pdp.MaPhong left join KhachHang kh on kh.MaKH = pdp.MaKH " +
                "where {1} like N'%{2}%'";
            String content = txtTraCuuPDP.Text;
            switch (cbSearchPDP.Text)
            {

                case "Mã PDP":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPDP", content, sqlPDP);
                    break;
                case "Tên Khách Hàng":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "TenKH", content, sqlPDP);
                    break;
                case "Mã Phòng":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPhong", content, sqlPDP);
                    break;
                case "":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPDP", content, sqlPDP);
                    break;
                default:
                    break;
            }
        }

        private void txtTraCuuPDP_TextChanged(object sender, EventArgs e)
        {
            String sqlPDP = "select   pdp.MaPDP as N'Mã PDP' ,pdp.MaKH as N'Mã khách hàng', kh.TenKH as N'Tên khách hàng', p.MaPhong as N'Mã Phòng', pdp.NgayDat as N'Ngày đặt', pdp.NgayNhan as N'Ngày nhận', pdp.TrangThai as N'Trạng thái'" +
                "from Phong p left join {0} pdp on p.MaPhong = pdp.MaPhong left join KhachHang kh on kh.MaKH = pdp.MaKH " +
                "where {1} like N'%{2}%'";
            String content = txtTraCuuPDP.Text;
            switch (cbSearchPDP.Text)
            {

                case "Mã PDP":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPDP", content, sqlPDP);
                    break;
                case "Tên Khách Hàng":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "TenKH", content, sqlPDP);
                    break;
                case "Mã Phòng":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPhong", content, sqlPDP);
                    break;
                case "":
                    TraCuu(dgvListPDP, "PhieuDatPhong", "pdp.MaPDP", content, sqlPDP);
                    break;
                default:

                    break;
            }
        }

        private void btnTaoPhieuDatPhong_Click(object sender, EventArgs e)
        {
            PhieuDatPhong phieuDatPhong = new PhieuDatPhong();
            phieuDatPhong.Show();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            FormThanhToan formThanhToan = new FormThanhToan();
            formThanhToan.Show();
        }

        //tab quan ly Phong
        private void btnTraCuuPhong_Click(object sender, EventArgs e)
        {
            try
            {

                String content = txtMaPhong.Text;
                switch (cbSearchPhong.Text)
                {

                    case "Mã Phòng":
                        TraCuuPhong(dgvListPhong, "MaPhong", content);
                        break;
                    case "Loại Phòng":
                        TraCuuPhong(dgvListPhong, "Tenloai", content);
                        break;
                    case "Trạng Thái":
                        TraCuuPhong(dgvListPhong, "TrangThai", content);
                        break;
                    case "":
                        TraCuuPhong(dgvListPhong, "MaPhong", content);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {
            String content = txtMaPhong.Text;
            switch (cbSearchPhong.Text)
            {

                case "Mã Phòng":
                    TraCuuPhong(dgvListPhong, "MaPhong", content);
                    break;
                case "Loại Phòng":
                    TraCuuPhong(dgvListPhong, "Tenloai", content);
                    break;
                case "Trạng Thái":
                    TraCuuPhong(dgvListPhong, "TrangThai", content);
                    break;
                case "":
                    TraCuuPhong(dgvListPhong, "MaPhong", content);
                    break;
                default:
                    break;
            }
        }

        private void btnThemPhongMoi_Click(object sender, EventArgs e)
        {
            string message = "Xác nhận thêm phòng mới?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
            try
            {
                dbConnectors db = new dbConnectors();
                //string sql = "insert into Phong(MaPhong, DonGia, TrangThai, MaLP) values('{0}',{1},N'trống', '{2}')";
                //db.executeQuery(String.Format(sql, txtMaPhongMoi.Text, txtDonGiaMoi.Text, cbLoaiMPMoi.Text));

                string sql = "exec spThemPhong '{0}','{1}', '{2}'";
                db.executeQuery(String.Format(sql, txtMaPhongMoi.Text, txtDonGiaMoi.Text, cbLoaiMPMoi.Text));
                MessageBox.Show("Thành Công");

                DataTable dt = db.runQuery("select count(*) + 1 as SL from Phong");
                string MaPhong = "P00" + dt.Rows[0]["SL"].ToString();
                txtMaPhongMoi.Text = MaPhong;
                txtDonGiaMoi.Clear();
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

        private void btnThemLoaiPhongMoi_Click(object sender, EventArgs e)
        {
        //    this.Visible = false;
            FormLoaiPhong formLoaiPhong = new FormLoaiPhong();
            formLoaiPhong.Show();

        }

        //tab quan ly HD
        private void btnTraCuuHD_Click(object sender, EventArgs e)
        {
            String sqlHD = "select hd.MaHD as N'Mã hóa đơn', hd.MaPDP as N'Mã PDP', pdp.MaPhong as N'Mã phòng'" +
                ",pdp.NgayNhan as N'Ngày nhận', hd.NgayLap as N'NgayTra', kh.TenKH as N'Tên KH', nv.TenNV as N'Nhân viên lập', hd.TongTien as N'Tổng tiền' " +
                "from {0} hd inner join PhieuDatPhong pdp on pdp.MaPDP = hd.MaPDP inner join KhachHang kh on kh.MaKH = pdp.MaKH inner join NhanVien nv on nv.MaNV = hd.MaNV " +
                "where {1} like N'%{2}%'";
            String content = txtMaHD.Text;
            switch (cbSearchHD.Text)
            {

                case "Mã hóa đơn":
                    TraCuu(dgvListHD, "HoaDon", "MaHD", content, sqlHD);
                    break;
                case "Mã PDP":
                    TraCuu(dgvListHD, "HoaDon", "hd.MaPDP", content, sqlHD);
                    break;
                case "Mã Phòng":
                    TraCuu(dgvListHD, "HoaDon", "MaPhong", content, sqlHD);
                    break;
                case "Tên Khách Hàng":
                    TraCuu(dgvListHD, "HoaDon", "TenKH", content, sqlHD);
                    break;
                case "Tên Nhân Viên":
                    TraCuu(dgvListHD, "HoaDon", "TenNV", content, sqlHD);
                    break;

                case "":
                    TraCuu(dgvListHD, "HoaDon", "MaHD", content, sqlHD);
                    break;
                default:
                    break;
            }
        }

        private void dgvListHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListHD.Rows.Count <= 0) return;
            try
            {
                string MaPDP = dgvListHD.CurrentRow.Cells["Mã PDP"].Value.ToString();
                dbConnectors db = new dbConnectors();
                string sql = "select MaPDP as N'Mã PDP', dv.MaDV as N'Mã dịch vụ', dv.TenDV as N'Tên dịch vụ', ctdv.SoLuong as N'Số lượng', dv.DonGia as N'Đơn giá', DonGia * SoLuong as N'Thành tiền'  from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where MaPDP = '{0}'";
                sql = String.Format(sql, MaPDP);
                DataTable dt = db.runQuery(sql);
                dgvListCTDV.DataSource = dt;


                sql = "select datediff(day, pdp.NgayNhan, hd.NgayLap) as SoNgay " +
                    "from PhieuDatPhong pdp inner join HoaDon hd on pdp.MaPDP = hd.MaPDP  where hd.MaPDP='{0}'";
                dt = db.runQuery(String.Format(sql, MaPDP));
                String strSoNgay = dt.Rows[0]["SoNgay"].ToString();
                int soNgay = Convert.ToInt32(strSoNgay);

                sql = "select p.DonGia as GiaPhong from Phong p inner join PhieuDatPhong pdp on p.MaPhong = pdp.MaPhong where pdp.MaPDP = '{0}'";
                dt = db.runQuery(String.Format(sql, MaPDP));
                String strGiaPhong = dt.Rows[0]["GiaPhong"].ToString();
                int giaPhong = Convert.ToInt32(strGiaPhong);

                int tienPhong = soNgay * giaPhong;
                txtTienPhong.Text = tienPhong.ToString();

                sql = "select sum(ctdv.SoLuong * dv.DonGia) as DichVu from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where ctdv.MaPDP = '{0}' group by ctdv.MaPDP";
                dt = db.runQuery(String.Format(sql, MaPDP));
                txtDichVu.Text = dt.Rows[0]["DichVu"].ToString();

                int dichVu = Convert.ToInt32(txtDichVu.Text);
                int tienTT = dichVu + tienPhong;

                txtTongTien.Text = tienTT.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            String sqlHD = "select hd.MaHD as N'Mã hóa đơn', hd.MaPDP as N'Mã PDP', pdp.MaPhong as N'Mã phòng'" +
                ",pdp.NgayNhan as N'Ngày nhận', hd.NgayLap as N'NgayTra', kh.TenKH as N'Tên KH', nv.TenNV as N'Nhân viên lập', hd.TongTien as N'Tổng tiền' " +
                "from {0} hd inner join PhieuDatPhong pdp on pdp.MaPDP = hd.MaPDP inner join KhachHang kh on kh.MaKH = pdp.MaKH inner join NhanVien nv on nv.MaNV = hd.MaNV " +
                "where {1} like N'%{2}%'";
            String content = txtMaHD.Text;
            switch (cbSearchHD.Text)
            {

                case "Mã hóa đơn":
                    TraCuu(dgvListHD, "HoaDon", "MaHD", content, sqlHD);
                    break;
                case "Mã PDP":
                    TraCuu(dgvListHD, "HoaDon", "hd.MaPDP", content, sqlHD);
                    break;
                case "Mã Phòng":
                    TraCuu(dgvListHD, "HoaDon", "MaPhong", content, sqlHD);
                    break;
                case "Tên Khách Hàng":
                    TraCuu(dgvListHD, "HoaDon", "TenKH", content, sqlHD);
                    break;
                case "Tên Nhân Viên":
                    TraCuu(dgvListHD, "HoaDon", "TenNV", content, sqlHD);
                    break;

                case "":
                    TraCuu(dgvListHD, "HoaDon", "MaHD", content, sqlHD);
                    break;
                default:
                    break;
            }
        }

        //tab quan ly NV
        private void btnTraCuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlNV = "select MaNV as N'Mã nhân viên', TenNV as N'Tên nhân viên'," +
                                 "Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'" +
                                    " from {0} where {1} like N'%{2}%'";
                String content = txtMaNV.Text;
                switch (cbSearchNV.Text)
                {

                    case "Mã NV":
                        TraCuu(dgvListNV, "NhanVien", "MaNV", content, sqlNV);
                        break;
                    case "Số CMND":
                        TraCuu(dgvListNV, "NhanVien", "CMND", content, sqlNV);
                        break;
                    case "Tên NV":
                        TraCuu(dgvListNV, "NhanVien", "TenNV", content, sqlNV);
                        break;
                    case "Số điện thoại":
                        TraCuu(dgvListNV, "NhanVien", "Sdt", content, sqlNV);
                        break;
                    case "Địa chỉ":
                        TraCuu(dgvListNV, "NhanVien", "DiaChi", content, sqlNV);
                        break;
                    case "":
                        TraCuu(dgvListNV, "NhanVien", "TenNV", content, sqlNV);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            string sqlNV = "select MaNV as N'Mã nhân viên', TenNV as N'Tên nhân viên'," +
                                 "Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'" +
                                    " from {0} where {1} like N'%{2}%'";
            String content = txtMaNV.Text;
            switch (cbSearchNV.Text)
            {

                case "Mã NV":
                    TraCuu(dgvListNV, "NhanVien", "MaNV", content, sqlNV);
                    break;
                case "Số CMND":
                    TraCuu(dgvListNV, "NhanVien", "CMND", content, sqlNV);

                    break;
                case "Tên NV":
                    TraCuu(dgvListNV, "NhanVien", "TenNV", content, sqlNV);
                    break;
                case "Số điện thoại":
                    TraCuu(dgvListNV, "NhanVien", "Sdt", content, sqlNV); ;
                    break;
                case "Địa chỉ":
                    TraCuu(dgvListNV, "NhanVien", "DiaChi", content, sqlNV);
                    break;
                case "":
                    TraCuu(dgvListNV, "NhanVien", "TenNV", content, sqlNV);
                    break;
                default:
                    break;
            }
        }

        private void dgvListNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvListNV.Rows[e.RowIndex];
                txtMaNVMoi.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                txtSDTNV.Text = row.Cells[2].Value.ToString();
                txtCMNDNV.Text = row.Cells[4].Value.ToString();
                txtDCNV.Text = row.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            try
            {
                DataTable dt = db.runQuery("select count(*) + 1 as SL from NhanVien");
                string MaNV = "NV00" + dt.Rows[0]["SL"].ToString();
                txtMaNVMoi.Text = MaNV;
                txtTenNV.Text = "";
                txtSDTNV.Text = "";
                txtCMNDNV.Text = "";
                txtDCNV.Text = "";
                txtMaNV.Clear();
                txtMaNVMoi.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            try
            {
                string sql = "update NhanVien set TenNV=N'{0}',Sdt='{1}',DiaChi=N'{2}',CMND='{3}' where MaNV = '{4}' ";
                db.executeQuery(String.Format(sql, txtTenNV.Text, txtSDTNV.Text, txtDCNV.Text, txtCMNDNV.Text, txtMaNVMoi.Text));
                MessageBox.Show("Cập nhật Thành Công");
                loadData(dgvListNV, "xem_danh_sach_nhan_vien");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            string message = "Thao tác sẽ xoá nhân viên, xác nhận?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
            try
            {
                string sql = "delete from NhanVien where MaNV = '{0}' ";
                db.executeQuery(String.Format(sql, txtMaNVMoi.Text));
                MessageBox.Show("Xóa Thành Công");
                loadData(dgvListNV, "xem_danh_sach_nhan_vien");

                DataTable dt = db.runQuery("select count(*) + 3 as SL from NhanVien");
                string MaNV = "NV00" + dt.Rows[0]["SL"].ToString();
                txtMaNVMoi.Text = MaNV;
                txtTenNV.Text = "";
                txtSDTNV.Text = "";
                txtCMNDNV.Text = "";
                txtDCNV.Text = "";
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

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                DataTable dt = db.runQuery("select count(*) as SL from NhanVien where CMND = '" + txtCMNDNV.Text + "'");
                if (Convert.ToInt32(dt.Rows[0]["SL"].ToString()) > 0)
                {
                    MessageBox.Show("thông tin CMND đã tồn tại");
                    return;
                }
                // dt = db.runQuery("select count(*) + 1 as SL from NhanVien");
                //string MaNV = "NV00" + dt.Rows[0]["SL"].ToString();
                //string sql = "insert into NhanVien(MaNV, TenNV, Sdt, DiaChi, CMND) values('{0}',N'{1}','{2}',N'{3}','{4}')";
                string sql = "exec spThemNhanVien '{0}',N'{1}','{2}',N'{3}','{4}'";
                db.executeQuery(String.Format(sql, txtMaNVMoi.Text, txtTenNV.Text, txtSDTNV.Text, txtDCNV.Text, txtCMNDNV.Text));
                MessageBox.Show("Thành Công");
                loadData(dgvListNV, "xem_danh_sach_nhan_vien");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //tab quan ly KH
        private void btnTraCuuKH_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlKH = "select MaKH as N'Mã khách hàng', TenKH as N'Tên khách hàng'," +
                                 "Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'" +
                                    " from {0} where {1} like N'%{2}%'";
                String content = txtMaKH.Text;
                switch (cbSearchKH.Text)
                {

                    case "Mã KH":
                        TraCuu(dgvListKH, "KhachHang", "MaKH", content, sqlKH);
                        break;
                    case "Số CMND":
                        TraCuu(dgvListKH, "KhachHang", "CMND", content, sqlKH);

                        break;
                    case "Tên":
                        TraCuu(dgvListKH, "KhachHang", "TenKH", content, sqlKH);
                        break;
                    case "Số điện thoại":
                        TraCuu(dgvListKH, "KhachHang", "Sdt", content, sqlKH);
                        break;
                    case "Địa chỉ":
                        TraCuu(dgvListKH, "KhachHang", "DiaChi", content, sqlKH);
                        break;
                    case "":
                        TraCuu(dgvListKH, "KhachHang", "TenKH", content, sqlKH);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            string sqlKH = "select MaKH as N'Mã khách hàng', TenKH as N'Tên khách hàng'," +
                 "Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'" +
                    " from {0} where {1} like N'%{2}%'";
            String content = txtMaKH.Text;
            switch (cbSearchKH.Text)
            {

                case "Mã KH":
                    TraCuu(dgvListKH, "KhachHang", "MaKH", content, sqlKH);
                    break;
                case "Số CMND":
                    TraCuu(dgvListKH, "KhachHang", "CMND", content, sqlKH);

                    break;
                case "Tên":
                    TraCuu(dgvListKH, "KhachHang", "TenKH", content, sqlKH);
                    break;
                case "Số điện thoại":
                    TraCuu(dgvListKH, "KhachHang", "Sdt", content, sqlKH);
                    break;
                case "Địa chỉ":
                    TraCuu(dgvListKH, "KhachHang", "DiaChi", content, sqlKH);
                    break;
                case "":
                    TraCuu(dgvListKH, "KhachHang", "TenKH", content, sqlKH);
                    break;
                default:
                    break;
            }

        }

        private void dgvListKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvListKH.Rows[e.RowIndex];
                txtMaKHMoi.Text = row.Cells[0].Value.ToString();
                txtTenKH.Text = row.Cells[1].Value.ToString();
                txtSDTKH.Text = row.Cells[2].Value.ToString();
                txtCMNDKH.Text = row.Cells[4].Value.ToString();
                txtDCKH.Text = row.Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            try
            {
                DataTable dt = db.runQuery("select count(*) + 1 as SL from KhachHang");
                string MaKH = "KH00" + dt.Rows[0]["SL"].ToString();
                txtMaKHMoi.Text = MaKH;
                txtTenKH.Text = "";
                txtSDTKH.Text = "";
                txtCMNDKH.Text = "";
                txtDCKH.Text = "";
                txtMaKH.Clear();
                txtMaKHMoi.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            try
            {
                string sql = "update KhachHang set TenKH=N'{0}',Sdt='{1}',DiaChi=N'{2}',CMND='{3}' where MaKH = '{4}' ";
                db.executeQuery(String.Format(sql, txtTenKH.Text, txtSDTKH.Text, txtDCKH.Text, txtCMNDKH.Text, txtMaKHMoi.Text));
                MessageBox.Show("Cập nhật Thành Công");
                loadData(dgvListKH, "xem_danh_sach_khach_hang");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            dbConnectors db = new dbConnectors();
            string message = "Thao tác sẽ xoá khách hàng, xác nhận?";
            string title = "Xác nhận";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
            {
                string sql = "delete from KhachHang where MaKH = '{0}' ";
                db.executeQuery(String.Format(sql, txtMaKHMoi.Text));
                MessageBox.Show("Xóa Thành Công");
                loadData(dgvListKH, "xem_danh_sach_khach_hang");


                DataTable dt = db.runQuery("select count(*) + 4 as SL from KhachHang");
                string MaKH = "KH00" + dt.Rows[0]["SL"].ToString();
                txtMaKHMoi.Text = MaKH;
                txtTenKH.Text = "";
                txtSDTKH.Text = "";
                txtCMNDKH.Text = "";
                txtDCKH.Text = "";
                txtMaKHMoi.Enabled = false;
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

        private void btnLuuKH_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                DataTable dt = db.runQuery("select count(*) as SL from KhachHang where CMND = '" + txtCMNDKH.Text + "'");
                if (Convert.ToInt32(dt.Rows[0]["SL"].ToString()) > 0)
                {
                    MessageBox.Show("thông tin CMND đã tồn tại");
                    return;
                }
                // dt = db.runQuery("select count(*) + 1 as SL from NhanVien");
                //string MaNV = "NV00" + dt.Rows[0]["SL"].ToString();
                //string sql = "insert into KhachHang(MaKH, TenKH, Sdt, DiaChi, CMND) values('{0}',N'{1}','{2}',N'{3}','{4}')";
                string sql = "exec spThemKhachHang '{0}',N'{1}','{2}',N'{3}','{4}' ";
                db.executeQuery(String.Format(sql, txtMaKHMoi.Text, txtTenKH.Text, txtSDTKH.Text, txtDCKH.Text, txtCMNDKH.Text));
                MessageBox.Show("Thêm mới thành công");
                loadData(dgvListKH, "xem_danh_sach_khach_hang");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            FormThemDichVu formThemDichVu = new FormThemDichVu();
            formThemDichVu.Show();
        }

        //Bao cao thong ke
        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "select * from thong_ke_doanh_thu";
                DataTable dt = db.runQuery(sql);
                dgvBaoCaoDT.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBaoCaoLoaiPhong_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "exec spThongKeLoaiPhong";
                DataTable dt = db.runQuery(sql);
                dgvTKLP.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBaoCaoDiaDiem_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnectors db = new dbConnectors();
                string sql = "exec spThongKeTheoKhachHang";
                DataTable dt = db.runQuery(sql);
                dgvTKDiaDiem.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }
    }
}
