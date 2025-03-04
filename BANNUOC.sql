CREATE DATABASE QL_NHAHANG
GO
USE QL_NHAHANG
GO
CREATE TABLE KhachHang(
	MaKhachHang INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	SDT_KH NVARCHAR(15) UNIQUE NOT NULL,
	LoaiKH NVARCHAR(20) NOT NULL, /* CÓ THỂ LÀ KHÁCH VÃN LAI , KHÁCH KHÁCH SẠN, KHÁCH VIP */
	NgaySuDung DATETIME NOT NULL,
	TiLeGiamGia DECIMAL(5,2) DEFAULT 0.00,
);
CREATE TABLE NhanVien(
	MaNV INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	ChucVu NVARCHAR(20) NOT NULL CHECK (ChucVu IN ('Nhân viên', 'Quản lý')), /* CÓ THỂ LÀ QUẢN LÝ , nhân viên */
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
	TrangThai NVARCHAR(20) NOT NULL CHECK(TrangThai IN('Hoạt động','Khóa')),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE CASCADE
);
CREATE TABLE DanhMucSanPham (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(20) NOT NULL CHECK (Loai IN ('Đồ uống', 'Món ăn')), -- Loại sản phẩm
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
	KhuVuc NVARCHAR(20) NOT NULL CHECK( KhuVuc In('Nhà Hàng','Quầy Bar')),
	TrangThai NVARCHAR(20) NOT NULL CHECK( TrangThai IN('Trống','Đang sử dụng')),
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
	TrangThai NVARCHAR(20) DEFAULT 'Chưa thanh toán' CHECK (TrangThai IN ('Chưa thanh toán', 'Đã thanh toán')),
	NguoiTao INT,
	FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan),
    FOREIGN KEY (NguoiTao) REFERENCES NhanVien(MaNV),
);
