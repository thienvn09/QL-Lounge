CREATE DATABASE QL_NHAHANG1
GO
USE QL_NHAHANG1
GO
CREATE TABLE KhachHang(
	MaKhachHang INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	SDT_KH NVARCHAR(15) UNIQUE NOT NULL,
	LoaiKH NVARCHAR(20) NOT NULL, /* CÓ THỂ LÀ KHÁCH VÃN LAI , KHÁCH VIP */
	NgaySuDung DATETIME NOT NULL,
	TiLeGiamGia DECIMAL(5,2) DEFAULT 0.00,
);
CREATE TABLE NhanVien(
	MaNV INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	ChucVu NVARCHAR(20) NOT NULL CHECK (ChucVu IN (N'Nhân viên', N'Quản lý')), /* CÓ THỂ LÀ QUẢN LÝ , nhân viên */
	SDT_NV VARCHAR(15) NOT NULL UNIQUE,
	Email_NV NVARCHAR(100) UNIQUE,
	NgayTao  DATETIME DEFAULT GETDATE(),
);

CREATE TABLE DangNhap(
	MaDangNhap INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
	MatKhau VARCHAR(50) NOT NULL,
	MaNV INT not null,
	NgayTao DATETIME DEFAULT GETDATE(),
	TrangThai NVARCHAR(20) NOT NULL CHECK(TrangThai IN(N'Hoạt động',N'Khóa')),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE CASCADE
);
CREATE TABLE DanhMucSanPham (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(20) NOT NULL CHECK (Loai IN (N'Đồ uống', N'Món ăn')), -- Loại sản phẩm
    ThueVAT DECIMAL(5, 2) NOT NULL CHECK (ThueVAT IN (8.00, 10.00)), -- Thuế VAT (8% hoặc 10%)
    MoTa NVARCHAR(MAX)
);
CREATE TABLE NhaCungCap(
	MaNhaCungCap INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	TenNhaCungCap NVARCHAR(200) NOT NULL,
	SoDienThoai VARCHAR(20) NOT NULL UNIQUE,
	Email NvarChar(100) Null,
);
CREATE TABLE SANPHAM(
	MaSanPham INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TenSanPham NVARCHAR(50) NOT NULL,
	MaDanhMuc INT, -- mối quan hệ n-1 mới bảng danh mục sp
	MaNhaCungCap INT, -- Mối quan hệ n-1 với bảng nhà cung cấp
	Gia DECIMAL(10,2) NOT NULL,
	MoTa NVARCHAR(200) NULL,
	SoLuongTonKho INT NOT NULL DEFAULT 0,
	FOREIGN KEY (MaDanhMuc) REFERENCES DanhMucSanPham(MaDanhMuc),
	FOREIGN KEY (MaNhaCungCap) REFERENCES NhaCungCap(MaNhaCungCap),
);
CREATE TABLE Ban(
	MaBan INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SoBan NVARCHAR(40) NOT NULL,
	SoChoNgoi INT NOT NULL,
	KhuVuc NVARCHAR(20) NOT NULL CHECK( KhuVuc In(N'Nhà Hàng',N'Quầy Bar')),
	TrangThai NVARCHAR(20) NOT NULL CHECK( TrangThai IN(N'Trống',N'Đang sử dụng')),
);
CREATE TABLE Voucher(
	MaVoucher INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MaKhachHang INT, -- tham chiếu tới bảng khách hàng
	MaSanPham INT, -- tham chiếu tới bảng sản phẩm
	GiaTri DECIMAL(10,2) NOT NULL,
	NgayHetHan DATE,
	TrangThai NVARCHAR(20) NOT NULL CHECK(TrangThai IN('Đã sử dụng' , 'Chưa sử dụng')),
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang (MaKhachHang),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
CREATE TABLE HoaDon(
	MaHoaDon INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MaKhachHang INT  NOT NULL, -- tham chiếu tới bảng khách hàng
	MaNhanVien INT, -- tham chiếu tới bảng nhân viên
	MaBan INT, -- tham chiếu tới bảng bàn
	NgayDat DATETIME NOT NULL DEFAULT GETDATE(),
	TongTien DECIMAL(10, 2), -- Tổng tiền trước thuế và giảm giá
	TienGiamGia DECIMAL(10,2) DEFAULT 0.00,
	TongThueVAT DECIMAL (10,2), -- Tổng tiền thuế
	ThanhToan AS (TongTien + TongThueVAT - TienGiamGia),
	TrangThai NVARCHAR(20) DEFAULT 'Chưa thanh toán' CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán')),
	NguoiTao INT,
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan),
    FOREIGN KEY (NguoiTao) REFERENCES NhanVien(MaNV),
);
CREATE TABLE ChiTietHoaDon(
	MaChiTietHoaDon INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MaHoaDon INT, -- tham chiếu tới bảng hóa đơn
	MaSanPham INT, -- tham chiếu tới bảng sản phẩm
	SoLuong INT NOT NULL,
	Gia DECIMAL(10,2) NOT NULL, -- giá của sản phẩm 
	ThueVAT DECIMAL(5,2) NOT NULL , -- lấy từ danh mục sản phẩm 
	ThanhTien AS(Gia *SoLuong),
	TienThue AS (Gia * SoLuong * ThueVAT /100), --tiền thuế (thành tiền * thuế vat /100)
	FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
	FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham),
);
CREATE TABLE KhoHang(
	MaKhoHang INT PRIMARY KEY IDENTITY(1,1),
    MaSanPham INT, -- Tham chiếu đến bảng SanPham
    SoLuongTon INT NOT NULL DEFAULT 0, -- Số lượng tồn kho
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
CREATE TABLE PhieuNhapKho(
	MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
	NgayNhap Date Not NULL,
	MaNV INT NOT NULL, --tham chiếu tới bảng nhân viên
	TongTienNhap DECIMAL(15,2) NOT NULL,
	GhiChu NVARCHAR(MAX),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

);
CREATE TABLE ChiTietPhieuNhapKho(
	MaChiTietPhieuNhap INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	MaPhieuNhap INT not null, -- tham chiếu tới bang phiếu nhập
	MaSanPham INT not null,
	SoLuong INT Not Null, -- số lượng nhập
	DonGia DECIMAL(10, 2) NOT NULL, -- Đơn giá nhập
	ThanhTien AS (SoLuong * DonGia), -- Thành tiền tự động tính
    FOREIGN KEY (MaPhieuNhap) REFERENCES PhieuNhapKho(MaPhieuNhap),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
CREATE TABLE PhieuXuatKho (
    MaPhieuXuat INT PRIMARY KEY IDENTITY(1,1),
    NgayXuat DATE NOT NULL DEFAULT GETDATE(), -- Ngày xuất kho
    MaNhanVien INT, -- Người thực hiện xuất kho (tham chiếu đến bảng NhanVien)
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNV)
);
CREATE TABLE ChiTietPhieuXuat (
    MaChiTietXuat INT PRIMARY KEY IDENTITY(1,1),
    MaPhieuXuat INT, -- Tham chiếu đến bảng PhieuXuatKho
    MaSanPham INT, -- Tham chiếu đến bảng SanPham
    SoLuong INT NOT NULL, -- Số lượng xuất
    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuatKho(MaPhieuXuat),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
CREATE TABLE BaoCao(
	MaBaoCao INT PRIMARY KEY IDENTITY(1,1),
	LoaiBaoCao NVARCHAR(20) NOT NULL Check( LoaiBaoCao In(N'Hàng Ngày',N'Hàng Tháng',N'Hàng năm')),
	NgayBaoCao DATE NOT NULL,
	TongDoanhThu DECIMAL(15,2) NOT NULL,-- Tổng doanh thu
	TongChiPhi DECIMAL(15,2) NOT Null,
	LoiNhuan AS(TongDoanhThu - TongChiPhi),
	SoHoaDon INT NOT NULL,
	SoKhachHang INT NOT NULL,
	SoSanPhamBanRa INT NOT NULL,
	NguoiTao INT, 
	GhiChu Nvarchar(MAX) Not NULL,
	FOREIGN KEY (NguoiTao) REFERENCES NhanVien(MaNV),
);
CREATE VIEW vw_ChiTietBan AS
SELECT 
    b.MaBan,
    b.SoBan,
    b.KhuVuc,
    b.TrangThai,
    hd.MaHoaDon,
    sp.TenSanPham,
    cthd.SoLuong,
    cthd.Gia,
    cthd.ThueVAT,
    (cthd.Gia * cthd.SoLuong) AS ThanhTien,
    (cthd.Gia * cthd.SoLuong * cthd.ThueVAT / 100) AS TienThue,
    (cthd.Gia * cthd.SoLuong * (1 + cthd.ThueVAT / 100)) AS TongTienMon
FROM Ban b
LEFT JOIN HoaDon hd ON b.MaBan = hd.MaBan AND hd.TrangThai = N'Chưa thanh toán'
LEFT JOIN ChiTietHoaDon cthd ON hd.MaHoaDon = cthd.MaHoaDon
LEFT JOIN SanPham sp ON sp.MaSanPham = cthd.MaSanPham

