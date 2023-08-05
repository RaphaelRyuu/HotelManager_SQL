use master
go
if DB_ID('quanlyks') is not null
	drop database quanlyks
go


create database quanlyks
go
use quanlyks
go

create table KhachHang (
	MaKH varchar(10) primary key,
	TenKH nvarchar(255) not null,
	Sdt varchar(11) not null,
	DiaChi nvarchar(255),
	CMND varchar(255) not null unique
)

create table NhanVien(
	MaNV varchar(10) primary key,
	TenNV nvarchar(255) not null,
	Sdt varchar(11),
	DiaChi nvarchar(255),
	CMND varchar(255) not null
)

create table DichVu(
	MaDV varchar(10) primary key,
	TenDV nvarchar(100) not null,
	DonGia float not null,
	SoLuongTon int not null,
	TrangThai nvarchar(100) CHECK( TrangThai in (N'hết hàng',N'còn hàng') )
)

create table LoaiPhong(
	MaLP varchar(10) primary key,
	TenLoai nvarchar(255) not null
)

create table Phong(
	MaPhong varchar(10) primary key,
	DonGia float not null,
	TrangThai nvarchar(100) CHECK( TrangThai in (N'đang hoạt động',N'trống') ),
	MaLP varchar(10),

	CONSTRAINT FK_P_LP FOREIGN KEY (MaLP) REFERENCES LoaiPhong(MaLP)
)

create table PhieuDatPhong(
	MaPDP varchar(10) primary key,
	NgayDat datetime not null,
	NgayNhan datetime not null,
	TrangThai nvarchar(100) not null check(TrangThai in (N'chờ thanh toán', N'đã thanh toán', N'hủy')),
	MaKH varchar(10) not null,
	MaNV varchar(10) not null,
	MaPhong varchar(10) not null,
	NguoiSD nvarchar(50) not null,

	CONSTRAINT FK_PDP_KH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
	CONSTRAINT FK_PDP_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_PDP_P FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong)
)

create table ChiTietDichVu(
	MaPDP varchar(10) not null,
	MaDV varchar(10) not null,
	SoLuong integer not null,
	
	CONSTRAINT PK_CTDV PRIMARY KEY (MaPDP, MaDV),
	CONSTRAINT FK_CTDV_PDP FOREIGN KEY (MaPDP) REFERENCES PhieuDatPhong(MaPDP),
	CONSTRAINT FK_CTDV_DV FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
)

create table HoaDon(
	MaHD varchar(10) primary key,
	NgayLap datetime not null,
	TongTien float not null,
	MaNV varchar(10) not null,
	MaPDP varchar(10) not null,

	CONSTRAINT FK_HD_NV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
	CONSTRAINT FK_HD_PDP FOREIGN KEY (MaPDP) REFERENCES PhieuDatPhong(MaPDP)
)
go
-- ===================== VIEWS =======================
-- Xem danh sách đặt phòng
create view xem_danh_sach_dat_phong as
select  p.MaPhong as N'Mã Phòng', pdp.MaPDP as N'Mã PDP' ,pdp.MaKH as N'Mã khách hàng', kh.TenKH as N'Tên khách hàng', pdp.NgayDat as N'Ngày đặt', pdp.NgayNhan as N'Ngày Nhận', pdp.TrangThai as N'Trạng thái'
from Phong p 
left join PhieuDatPhong pdp on p.MaPhong = pdp.MaPhong
left join KhachHang kh on kh.MaKH = pdp.MaKH
go
-- Xem danh sách hóa đơn
create view xem_danh_sach_hoa_don as
select hd.MaHD as N'Mã hóa đơn', hd.MaPDP as N'Mã PDP', pdp.MaPhong as N'Mã phòng', kh.TenKH as N'Tên khách hàng', nv.TenNV as N'Nhân viên lập', hd.TongTien as N'Tổng tiền'
from HoaDon hd
inner join PhieuDatPhong pdp on pdp.MaPDP = hd.MaPDP
inner join KhachHang kh on kh.MaKH = pdp.MaKH
inner join NhanVien nv on nv.MaNV = hd.MaNV
go

-- Xem danh sách các dịch vụ
create view xem_danh_sach_dich_vu as
select MaDV as 'Mã dịch vụ', TenDV as 'Tên dịch vụ', DonGia as 'Đơn Giá', SoLuongTon as 'Số lượng còn' from DichVu

go

-- Xem danh sách phòng
create view xem_danh_sach_phong as 
select p.MaPhong as 'Mã Phòng', p.DonGia as 'Đơn Giá', p.TrangThai as 'Trạng Thái',lp.TenLoai as 'Loại Phòng' 
		from Phong p inner join LoaiPhong lp on lp.MaLP = p.MaLP
go
-- Xem danh sách nhân viên
create view xem_danh_sach_nhan_vien as
select MaNV as N'Mã nhân viên', TenNV as N'Tên nhân viên',
                                 Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'
from NhanVien
go

--Xem danh sách khách hàng
create view xem_danh_sach_khach_hang as
select MaKH as N'Mã khách hàng', TenKH as N'Tên khách hàng',
                                 Sdt as N'Số điện thoại', DiaChi as N'Địa chỉ', CMND as N'Số CMND'
from KhachHang
go
-- xem chi tiet dich vu cua Phieu Dat Phong
create view xem_chi_tiet_dich_vu_cua_phieu_dat_phong as
select pdp.MaPDP, dv.TenDV, ctdv.SoLuong, dv.DonGia, ctdv.SoLuong * dv.DonGia as ThanhTien
from ChiTietDichVu ctdv
inner join DichVu dv on dv.MaDV = ctdv.MaDV
inner join PhieuDatPhong pdp on pdp.MaPDP = ctdv.MaPDP
go
-- xem thong ke doanh thu
create view thong_ke_doanh_thu as
select baocao.thang as N'Tháng', baocao.nam as N'Năm', sum(baocao.TongTien) as N'Tổng doanh thu'
from (select MONTH(hd.NgayLap) thang, YEAR(hd.NgayLap) nam, hd.TongTien from HoaDon hd) as baocao
group by baocao.thang, baocao.nam
go



-- ===================== THÊM DỮ LIỆU =======================

insert into KhachHang (MaKH, TenKH, Sdt, DiaChi, CMND)
values ('KH001', N'Nguyễn Văn A', '01234646781', N'Hà Nội', '1597238641'),
		('KH002', N'Nguyễn Văn B', '0126456782', N'Cà Mau', '1557523642'),
		('KH003', N'Ngô Bá Vương', '0123456783', N'Hà Nội', '1597268643'),
		('KH004', N'Trần Văn An', '0123456764', N'Hà Nam', '1596528643'),
		('KH005', N'Nguyễn Thị Lan', '01236546783', N'Hà Nội', '1512228643'),
		('KH006', N'Nguyễn Thị Mai', '01236542783', N'Bắc Ninh', '1512458643')

go
insert into NhanVien(MaNV, TenNV, Sdt, DiaChi, CMND)
values	('NV001', N'Nguyễn Trọng Năng', '0967100356', N'Hà Nội', '159758642'),
		('NV002', N'Lê Văn Sơn', '0123456786', N'Bắc Ninh', '169755643'),
		('NV003', N'Dương Mạnh Hiếu', '0978256125', N'Hà Nội', '159758644'),
		('NV004', N'Nguyễn Phúc Mỹ', '0967105787', N'Nam Định', '125922368'),
		('NV005', N'Hoàng Văn Nhẫn', '0386256351', N'Hà Nội', '136646528'),
		('NV006', N'Lê Ngọc Long', '0863456787', N'Hà Nội', '199758624')


go
insert into LoaiPhong(MaLP, TenLoai) values ('LP001', N'Luxury'),('LP002', N'VIP'),('LP003', N'thường')
go
insert into DichVu(MaDV, TenDV, DonGia, TrangThai, SoLuongTon) 
values	('DV001', N'Cơm tấm', 30000, N'còn hàng',1000),
		('DV002', N'Snack',10000, N'còn hàng', 1000), 
		('DV003', N'Nước chanh', 15000, N'còn hàng', 5000),
		('DV004', N'Nước khoáng', 10000, N'còn hàng',1000),
		('DV005', N'Giặt ủi', 30000, N'còn hàng',1000)
go
insert into Phong(MaPhong, DonGia, TrangThai, MaLP) 
values	('P001', 500000, N'đang hoạt động', 'LP003'),
		('P002', 200000, N'trống', 'LP001'),
		('P003', 10000, N'đang hoạt động', 'LP002'),
		('P004', 100000, N'đang hoạt động', 'LP002'),
		('P005', 250000, N'đang hoạt động', 'LP003'),
		('P006', 60000, N'trống', 'LP001'),
		('P007', 80000, N'trống', 'LP002'),
		('P008', 200000, N'trống', 'LP003')

go
insert into PhieuDatPhong(MaPDP, NgayDat, NgayNhan, MaNV, MaKH, MaPhong, TrangThai, NguoiSD )
				values	('PDP001', '2022-06-10', '2022-06-11', 'NV001', 'KH001', 'P001', N'đã thanh toán', N'Trần Anh Quân, Nguyễn Xuân Sơn'),
						('PDP002', '2022-06-19', '2022-06-21', 'NV001', 'KH002', 'P002', N'đã thanh toán', N'Hoàng Quốc Nguyên, Hồ Tuấn Anh'),
						('PDP003', '2022-06-03', '2022-06-05', 'NV002', 'KH003', 'P003', N'chờ thanh toán', N'Nguyễn Trọng Năng, Dương Mạnh Hiếu'),
						('PDP004', '2022-06-04', '2022-06-06', 'NV002', 'KH003', 'P004', N'chờ thanh toán', N'Hoàng Hà Nam, Nguyễn Phúc Mỹ'),
						('PDP005', '2022-06-01', '2022-05-28', 'NV002', 'KH003', 'P005', N'chờ thanh toán', N'Vũ Thanh Phương, Nguyễn Thanh Quỳnh')


go
insert into ChiTietDichVu(MaPDP, MaDV, SoLuong) values ('PDP001', 'DV002', 10),
														('PDP002', 'DV001', 5),
														('PDP003', 'DV003', 2),
														('PDP004', 'DV003', 1),
														('PDP005', 'DV001', 1)

go
insert into HoaDon (MaHD, NgayLap, TongTien, MaNV, MaPDP) 
				values	('HD001', '2022-06-23', 550000, 'NV002', 'PDP002'),
						('HD002', '2022-06-22', 5600000, 'NV001', 'PDP001')
go



-- ===================== TRIGGERS =======================

-- trigger kiểm tra trạng thái của phòng phải "trống" khi có khách đặt thuê
create trigger trgKiemTraPhong on PhieuDatPhong
after insert as
begin
	declare @MaPhong varchar(10);
	set @MaPhong = (select MaPhong from inserted)
	if not exists (select * from Phong p where p.TrangThai = N'trống' and p.MaPhong = @MaPhong)
		begin
			raiserror('Phong dang hoat dong',15,1)
			rollback tran
			return
		end

	update Phong
	set TrangThai = N'đang hoạt động'
	where MaPhong = @MaPhong
end
go
-- trigger kiểm tra ngày nhận phòng phải lớn hơn ngày đặt
create trigger trgKiemTraNgayNhanVaDatPhong on PhieuDatPhong
after insert as
begin
	if((select NgayNhan from inserted) < (convert(varchar, getdate(), 23)))
		begin
			raiserror('NgayNhan khong dung',15,1)
			rollback tran
			return;
		end
	if (select NgayNhan from inserted) < (select (convert(varchar, NgayDat, 23)) from inserted)
		begin
			raiserror('NgayNhan < NgayDat',15,1)
			rollback tran
			return;
		end
end
go
-- trigger cập nhật lại số lượng dịch vụ khi thêm 1 dòng vào CTDV
create trigger trgCapNhatSoLuongDV on ChiTietDichVu
after insert as
begin
	declare @MaDV varchar(10)
	set @MaDV = (select MaDV from inserted);
	if not exists (select * from DichVu where MaDV = @MaDV)
		begin
			raiserror('Khong tim thay dich vu',15,1);
			rollback tran
			return
		end
	declare @SoLuongDVHienTai int;
	set @SoLuongDVHienTai = (select dv.SoLuongTon from DichVu dv where MaDV = @MaDV)
	if @SoLuongDVHienTai < (select SoLuong from inserted)
		begin
			raiserror('Khong du dich vu',15,1);
			rollback tran
			return
		end
	declare @TrangThai nvarchar(100), @SoLuongSauCapNhat int;
	set @SoLuongSauCapNhat = @SoLuongDVHienTai - (select SoLuong from inserted);
	set @TrangThai = N'còn hàng'
	if @SoLuongSauCapNhat <= 0
		begin
			set @TrangThai = N'hết hàng'
		end
	update DichVu
	set TrangThai = @TrangThai, SoLuongTon = @SoLuongSauCapNhat
	where MaDV = @MaDV
	print 'Cap nhat thanh cong'
end
go
-- trigger cập nhật lại số lượng dịch vụ khi sua 1 dòng vào CTDV
create trigger trgCapNhatSoLuongDVUpdate on ChiTietDichVu
after update as
begin
	declare @MaDV varchar(10)
	set @MaDV = (select MaDV from inserted);
	if not exists (select * from DichVu where MaDV = @MaDV)
		begin
			raiserror('Khong tim thay dich vu',15,1);
			rollback tran
			return
		end
	declare @SoLuongDVHienTai int;
	set @SoLuongDVHienTai = (select dv.SoLuongTon from DichVu dv where MaDV = @MaDV)
	if @SoLuongDVHienTai < (select SoLuong from inserted)
		begin
			raiserror('Khong du dich vu',15,1);
			rollback tran
			return
		end
	declare @TrangThai nvarchar(100), @SoLuongSauCapNhat int;
	set @SoLuongSauCapNhat = @SoLuongDVHienTai - (select SoLuong from inserted) + (select SoLuong from deleted);
	set @TrangThai = N'còn hàng'
	if @SoLuongSauCapNhat <= 0
		begin
			set @TrangThai = N'hết hàng'
		end
	update DichVu
	set TrangThai = @TrangThai, SoLuongTon = @SoLuongSauCapNhat
	where MaDV = @MaDV
	print 'Cap nhat thanh cong'
end
go

use quanlyks
go
-- trigger cập nhật lại số lượng dịch vụ khi xóa 1 dòng vào CTDV
create trigger trgCapNhatSoLuongDVDelete on ChiTietDichVu
after delete as
begin
	declare @MaDV varchar(10)
	set @MaDV = (select MaDV from deleted);
	if not exists (select * from DichVu where MaDV = @MaDV)
		begin
			raiserror('Khong tim thay dich vu',15,1);
			rollback tran
			return
		end
	declare @SoLuongDVHienTai int;
	set @SoLuongDVHienTai = (select dv.SoLuongTon from DichVu dv where MaDV = @MaDV)

	declare @TrangThai nvarchar(100), @SoLuongSauCapNhat int;
	set @SoLuongSauCapNhat = @SoLuongDVHienTai + (select SoLuong from deleted);
	set @TrangThai = N'còn hàng'
	if @SoLuongSauCapNhat <= 0
		begin
			set @TrangThai = N'hết hàng'
		end
	update DichVu
	set TrangThai = @TrangThai, SoLuongTon = @SoLuongSauCapNhat
	where MaDV = @MaDV
	print 'Cap nhat thanh cong'
end
go

-- ===================== STORED PROCEDURES =======================

-- stored procedure Tao Hoa Don 
use quanlyks
go
create proc spTaoHoaDon @MaPDP varchar(10), @MaNV varchar(10) as
	if not exists (select * from PhieuDatPhong where MaPDP = @MaPDP)
		begin
			raiserror('khong tim thay phieu dat phong',15,1)
			return
		end
	if exists (select * from HoaDon hd where hd.MaPDP = @MaPDP)
		begin
			raiserror('khach hang da thanh toan', 15,1);
			return
		end

	declare @TongTien float;

	declare @TongTienDV float;
	set @TongTienDV = (select sum(ctdv.SoLuong * dv.DonGia) 
			from ChiTietDichVu ctdv inner join DichVu dv on dv.MaDV = ctdv.MaDV where MaPDP = @MaPDP)
	
	declare @TienPhong float;
	declare @songay float;
	declare @dongia float;
	set @songay = (SELECT DATEDIFF(day, NgayNhan, GETDATE())
				FROM dbo.PhieuDatPhong where MaPDP=@MaPDP)
	set @dongia = (select DonGia from PhieuDatPhong pdp inner join Phong p on pdp.MaPhong=p.MaPhong
				where MaPDP=@MaPDP) 
	set @TienPhong = @dongia * @songay;

	set @TongTien = @TongTienDV + @TienPhong

	declare @MaHD varchar(10);

	set @MaHD = CONCAT('HD', left(NEWID(),5));

	--set @MaHD = left(NEWID(),5);
	insert into HoaDon(MaHD, NgayLap, TongTien, MaNV, MaPDP) values (@MaHD, GETDATE(), @TongTien, @MaNV, @MaPDP);
	update PhieuDatPhong
	set TrangThai = N'đã thanh toán'
	where MaPDP = @MaPDP;
	declare @MaPhong varchar(10);
	set @MaPhong = (select MaPhong from PhieuDatPhong where MaPDP = @MaPDP)
	update Phong
	set TrangThai = N'trống'
	where MaPhong = @MaPhong
go

-- thống kê số lượt đặt thuê theo từng loại phòng
create proc spThongKeLoaiPhong as
	select lp.MaLP as N'Mã loại phòng', lp.TenLoai as N'Tên loại' , count(pdp.MaPDP) as N'Số lượt đặt'
	from PhieuDatPhong pdp
	inner join Phong p on p.MaPhong = pdp.MaPhong
	inner join LoaiPhong lp on lp.MaLP = p.MaLP
	group by lp.MaLP, lp.TenLoai
	order by count(pdp.MaPDP) desc
go

-- thống kê khách đặt thuê phòng theo địa điểm
create proc spThongKeTheoKhachHang as
	select kh.DiaChi as N'Địa chỉ', count(pdp.MaPDP) as N'Số lượt đặt'
	from PhieuDatPhong pdp
	inner join KhachHang kh on kh.MaKH = pdp.MaKH
	group by kh.DiaChi
	order by count(pdp.MaPDP) desc
go
-- stored procedure tao phieu dat phong
create proc taoPhieuDatPhong @TenKH nvarchar(255), @sdt varchar(11), @DiaChi nvarchar(255), @cmnd varchar(255),
@NgayNhan datetime, @MaNV varchar(10), @MaPhong varchar(10), @NguoiSD nvarchar(50)
as
	declare @MaPDP varchar(10), @MaKH varchar(10);
	set @MaKH = CONCAT('KH', left(NEWID(),5));
	set @MaPDP = CONCAT('PDP', left(NEWID(),5));

	insert into KhachHang(MaKH, TenKH, Sdt, DiaChi, CMND) values (@MaKH, @TenKH, @sdt, @DiaChi, @cmnd);
	insert into PhieuDatPhong(MaPDP, NgayDat, NgayNhan, MaKH, MaNV, MaPhong, TrangThai, NguoiSD) 
	values                   (@MaPDP, GETDATE(), @NgayNhan, @MaKH, @MaNV, @MaPhong, N'chờ thanh toán', @NguoiSD)

	print 'tao thanh cong'
go


--stored procedure them phong moi
create proc spThemPhong @MaPhong varchar(10),@DonGia float,@MaLP varchar(10)
as
	insert into Phong(MaPhong, DonGia, TrangThai, MaLP) values(@MaPhong, @DonGia, N'trống', @MaLP)
go

--stored procedure them nhan vien moi
create proc spThemNhanVien @MaNV varchar(10),@TenNV nvarchar(255),@Sdt varchar(11),@DiaChi nvarchar(255), @cmnd varchar(255)
as
	insert into NhanVien(MaNV, TenNV, Sdt, DiaChi, CMND) values (@MaNV, @TenNV, @Sdt, @DiaChi, @cmnd)
go


--stored procedure them khach hang moi
create proc spThemKhachHang @MaKH varchar(10),@TenKH nvarchar(255),@Sdt varchar(11),@DiaChi nvarchar(255), @cmnd varchar(255)
as
	insert into KhachHang(MaKH, TenKH, Sdt, DiaChi, CMND) values (@MaKH, @TenKH, @Sdt, @DiaChi, @cmnd)
go

--stored procedure them loai phong moi
create proc spThemLoaiPhong @MaLP varchar(10), @TenLoai nvarchar(255)
as
	insert into LoaiPhong(MaLP, TenLoai) values (@MaLP, @TenLoai)
go