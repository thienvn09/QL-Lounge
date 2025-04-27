Create DATABASE QL_NHAHANG
USE QL_NHAHANG
GO
CREATE TABLE KhachHang(
	MaKhachHang INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	SDT_KH NVARCHAR(15) UNIQUE NOT NULL,
	LoaiKH NVARCHAR(20) NOT NULL, /* CÓ THỂ LÀ KHÁCH VÃN LAI , KHÁCH VIP */
	NgaySuDung DATETIME NOT NULL,
	TiLeGiamGia DECIMAL(5,2) DEFAULT 0.00,
);
Go
CREATE TABLE NhanVien(
	MaNV INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	HoTen NVARCHAR(100) NOT NULL,
	ChucVu NVARCHAR(20) NOT NULL CHECK (ChucVu IN (N'Nhân viên', N'Quản lý')), /* CÓ THỂ LÀ QUẢN LÝ , nhân viên */
	SDT_NV VARCHAR(15) NOT NULL UNIQUE,
	Email_NV NVARCHAR(100) UNIQUE,
	NgayTao  DATETIME DEFAULT GETDATE(),
);
GO
CREATE TABLE DangNhap(
	MaDangNhap INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
	MatKhau VARCHAR(50) NOT NULL,
	MaNV INT not null,
	NgayTao DATETIME DEFAULT GETDATE(),
	TrangThai NVARCHAR(20) NOT NULL CHECK(TrangThai IN(N'Hoạt động',N'Khóa')),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV) ON DELETE CASCADE
);
Go
CREATE TABLE DanhMucSanPham (
    MaDanhMuc INT PRIMARY KEY IDENTITY(1,1),
    TenDanhMuc NVARCHAR(100) NOT NULL,
    Loai NVARCHAR(20) NOT NULL CHECK (Loai IN (N'Đồ uống', N'Món ăn')), -- Loại sản phẩm
    ThueVAT DECIMAL(5, 2) NOT NULL CHECK (ThueVAT IN (8.00, 10.00)), -- Thuế VAT (8% hoặc 10%)
    MoTa NVARCHAR(MAX)
);
GO
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
GO
CREATE TABLE Ban(
	MaBan INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	SoBan NVARCHAR(40) NOT NULL,
	SoChoNgoi INT NOT NULL,
	KhuVuc NVARCHAR(20) NOT NULL CHECK( KhuVuc In(N'Nhà Hàng',N'Quầy Bar')),
	TrangThai NVARCHAR(20) NOT NULL CHECK( TrangThai IN(N'Trống',N'Đang sử dụng')),
);
GO
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
Go
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
GO
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
GO
CREATE TABLE KhoHang(
	MaKhoHang INT PRIMARY KEY IDENTITY(1,1),
    MaSanPham INT, -- Tham chiếu đến bảng SanPham
    SoLuongTon INT NOT NULL DEFAULT 0, -- Số lượng tồn kho
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO
CREATE TABLE PhieuNhapKho(
	MaPhieuNhap INT PRIMARY KEY IDENTITY(1,1),
	NgayNhap Date Not NULL,
	MaNV INT NOT NULL, --tham chiếu tới bảng nhân viên
	TongTienNhap DECIMAL(15,2) NOT NULL,
	GhiChu NVARCHAR(MAX),
	FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),

);
GO
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
GO
CREATE TABLE ChiTietPhieuXuat (
    MaChiTietXuat INT PRIMARY KEY IDENTITY(1,1),
    MaPhieuXuat INT, -- Tham chiếu đến bảng PhieuXuatKho
    MaSanPham INT, -- Tham chiếu đến bảng SanPham
    SoLuong INT NOT NULL, -- Số lượng xuất
    FOREIGN KEY (MaPhieuXuat) REFERENCES PhieuXuatKho(MaPhieuXuat),
    FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
Go
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
Go

USE QL_NHAHANG
GO

-- 1. Insert into KhachHang (Customers) - 20 rows
INSERT INTO KhachHang (HoTen, SDT_KH, LoaiKH, NgaySuDung, TiLeGiamGia) VALUES
(N'Lê Hoàng Thiện', '0905123456', N'Khách VIP', '2025-04-20', 0.15),
(N'Nguyễn Minh Anh', '0918765432', N'Khách vãng lai', '2025-04-25', 0.00),
(N'Trần Thị Hồng Nhung', '0932145678', N'Khách VIP', '2025-04-22', 0.10),
(N'Phạm Quốc Huy', '0945678901', N'Khách vãng lai', '2025-04-27', 0.00),
(N'Võ Ngọc Lan', '0923456789', N'Khách VIP', '2025-04-26', 0.20),
(N'Hoàng Văn Nam', '0956789012', N'Khách vãng lai', '2025-04-24', 0.00),
(N'Nguyễn Thị Minh Thư', '0967890123', N'Khách VIP', '2025-04-23', 0.12),
(N'Đặng Quang Vinh', '0978901234', N'Khách vãng lai', '2025-04-21', 0.00),
(N'Phan Thị Kim Ngân', '0989012345', N'Khách VIP', '2025-04-20', 0.18),
(N'Lê Văn Hùng', '0990123456', N'Khách vãng lai', '2025-04-25', 0.00),
(N'Trần Quốc Bảo', '0901234567', N'Khách VIP', '2025-04-26', 0.10),
(N'Nguyễn Ngọc Ánh', '0912345678', N'Khách vãng lai', '2025-04-27', 0.00),
(N'Vũ Thị Thu Hà', '0924567890', N'Khách VIP', '2025-04-22', 0.15),
(N'Đỗ Văn Khánh', '0935678901', N'Khách vãng lai', '2025-04-23', 0.00),
(N'Bùi Thị Thanh Tâm', '0946789012', N'Khách VIP', '2025-04-24', 0.20),
(N'Ngô Văn Tùng', '0957890123', N'Khách vãng lai', '2025-04-25', 0.00),
(N'Lý Thị Mai', '0968901234', N'Khách VIP', '2025-04-26', 0.10),
(N'Phạm Văn Long', '0979012345', N'Khách vãng lai', '2025-04-27', 0.00),
(N'Trần Thị Ngọc Diệp', '0980123456', N'Khách VIP', '2025-04-20', 0.15),
(N'Nguyễn Văn Quang', '0991234567', N'Khách vãng lai', '2025-04-21', 0.00);

-- 2. Insert into NhanVien (Employees) - 20 rows
INSERT INTO NhanVien (HoTen, ChucVu, SDT_NV, Email_NV, NgayTao) VALUES
(N'Nguyễn Văn Hùng', N'Quản lý', '0987654321', 'hungnv@nhahang.com', '2025-01-01'),
(N'Phan Thị Mai', N'Nhân viên', '0971234567', 'maipt@nhahang.com', '2025-02-15'),
(N'Đỗ Quốc Bảo', N'Nhân viên', '0967891234', 'baodq@nhahang.com', '2025-03-10'),
(N'Lê Thị Thu Hà', N'Nhân viên', '0956782345', 'haltt@nhahang.com', '2025-04-01'),
(N'Trần Quang Vinh', N'Quản lý', '0943215678', 'vinhtq@nhahang.com', '2025-04-10'),
(N'Nguyễn Thị Lan Anh', N'Nhân viên', '0934567890', 'anhntl@nhahang.com', '2025-01-15'),
(N'Võ Văn Tâm', N'Nhân viên', '0925678901', 'tamvv@nhahang.com', '2025-02-01'),
(N'Phạm Thị Hồng', N'Nhân viên', '0916789012', 'hongpt@nhahang.com', '2025-03-01'),
(N'Hoàng Văn Đức', N'Quản lý', '0907890123', 'duchv@nhahang.com', '2025-04-05'),
(N'Trần Thị Kim Oanh', N'Nhân viên', '0998901234', 'oantht@nhahang.com', '2025-01-20'),
(N'Nguyễn Văn Tuấn', N'Nhân viên', '0989012345', 'tuannv@nhahang.com', '2025-02-10'),
(N'Lê Thị Ngọc Mai', N'Nhân viên', '0970123456', 'mainlt@nhahang.com', '2025-03-15'),
(N'Đặng Văn Hậu', N'Nhân viên', '0961234567', 'haudv@nhahang.com', '2025-04-02'),
(N'Phan Thị Thanh Thủy', N'Nhân viên', '0952345678', 'thuypt@nhahang.com', '2025-01-25'),
(N'Ngô Văn Khang', N'Quản lý', '0943456789', 'khangnv@nhahang.com', '2025-02-20'),
(N'Trần Thị Minh Châu', N'Nhân viên', '0934567891', 'chauttm@nhahang.com', '2025-03-05'),
(N'Vũ Văn Hưng', N'Nhân viên', '0925678902', 'hungvv@nhahang.com', '2025-04-03'),
(N'Nguyễn Thị Hồng Nhung', N'Nhân viên', '0916789013', 'nhungnth@nhahang.com', '2025-01-30'),
(N'Lê Văn Hoàng', N'Nhân viên', '0907890124', 'hoanglv@nhahang.com', '2025-02-25'),
(N'Trần Thị Bích Ngọc', N'Nhân viên', '0998901235', 'ngocttb@nhahang.com', '2025-03-20');

-- 3. Insert into DangNhap (Login Accounts) - 20 rows (1 per NhanVien)
INSERT INTO DangNhap (TenDangNhap, MatKhau, MaNV, NgayTao, TrangThai) VALUES
('hungnv', 'pass123', 1, '2025-01-01', N'Hoạt động'),
('maipt', 'pass456', 2, '2025-02-15', N'Hoạt động'),
('baodq', 'pass789', 3, '2025-03-10', N'Hoạt động'),
('haltt', 'pass101', 4, '2025-04-01', N'Hoạt động'),
('vinhtq', 'pass202', 5, '2025-04-10', N'Khóa'),
('anhntl', 'pass303', 6, '2025-01-15', N'Hoạt động'),
('tamvv', 'pass404', 7, '2025-02-01', N'Hoạt động'),
('hongpt', 'pass505', 8, '2025-03-01', N'Hoạt động'),
('duchv', 'pass606', 9, '2025-04-05', N'Hoạt động'),
('oantht', 'pass707', 10, '2025-01-20', N'Hoạt động'),
('tuannv', 'pass808', 11, '2025-02-10', N'Hoạt động'),
('mainlt', 'pass909', 12, '2025-03-15', N'Hoạt động'),
('haudv', 'pass010', 13, '2025-04-02', N'Hoạt động'),
('thuypt', 'pass111', 14, '2025-01-25', N'Hoạt động'),
('khangnv', 'pass212', 15, '2025-02-20', N'Hoạt động'),
('chauttm', 'pass313', 16, '2025-03-05', N'Hoạt động'),
('hungvv', 'pass414', 17, '2025-04-03', N'Hoạt động'),
('nhungnth', 'pass515', 18, '2025-01-30', N'Hoạt động'),
('hoanglv', 'pass616', 19, '2025-02-25', N'Hoạt động'),
('ngocttb', 'pass717', 20, '2025-03-20', N'Khóa');

-- 4. Insert into DanhMucSanPham (Product Categories) - 20 rows
INSERT INTO DanhMucSanPham (TenDanhMuc, Loai, ThueVAT, MoTa) VALUES
(N'Cocktail', N'Đồ uống', 10.00, N'Các loại cocktail đặc trưng của nhà hàng'),
(N'Bia', N'Đồ uống', 10.00, N'Bia nội địa và nhập khẩu'),
(N'Rượu Vang', N'Đồ uống', 10.00, N'Rượu vang đỏ và trắng'),
(N'Nước Ép Tươi', N'Đồ uống', 8.00, N'Nước ép trái cây tươi 100%'),
(N'Cà Phê', N'Đồ uống', 8.00, N'Cà phê phin truyền thống Việt Nam'),
(N'Trà', N'Đồ uống', 8.00, N'Trà xanh, trà hoa và trà thảo mộc'),
(N'Mocktail', N'Đồ uống', 8.00, N'Đồ uống không cồn sáng tạo'),
(N'Smoothie', N'Đồ uống', 8.00, N'Sinh tố trái cây bổ dưỡng'),
(N'Khai Vị', N'Món ăn', 8.00, N'Món khai vị kiểu Việt Nam và quốc tế'),
(N'Salad', N'Món ăn', 8.00, N'Salad tươi với nguyên liệu cao cấp'),
(N'Phở', N'Món ăn', 8.00, N'Phở truyền thống Việt Nam'),
(N'Món Nướng', N'Món ăn', 8.00, N'Món nướng hải sản và thịt'),
(N'Món Xào', N'Món ăn', 8.00, N'Món xào đậm đà hương vị'),
(N'Món Hầm', N'Món ăn', 8.00, N'Món hầm bổ dưỡng'),
(N'Cơm và Mì', N'Món ăn', 8.00, N'Cơm và mì kiểu Việt Nam'),
(N'Món Chay', N'Món ăn', 8.00, N'Món chay thanh đạm'),
(N'Tráng Miệng', N'Món ăn', 8.00, N'Các món tráng miệng truyền thống và hiện đại'),
(N'Bánh Ngọt', N'Món ăn', 8.00, N'Bánh ngọt và bánh nướng'),
(N'Chè', N'Món ăn', 8.00, N'Chè Việt Nam truyền thống'),
(N'Kem', N'Món ăn', 8.00, N'Kem nhà làm với các hương vị độc đáo');

-- 5. Insert into NhaCungCap (Suppliers) - 20 rows
INSERT INTO NhaCungCap (TenNhaCungCap, SoDienThoai, Email) VALUES
(N'Công ty TNHH Thực Phẩm Sạch', '0912345678', 'thucphamsach@gmail.com'),
(N'Nhà cung cấp Rượu Vang Đà Lạt', '0923456789', 'ruouvangdalat@gmail.com'),
(N'Công ty Bia Sài Gòn', '0934567890', 'biasaigon@gmail.com'),
(N'Nhà cung cấp Trái Cây Tươi', '0945678901', 'traicaytuoi@gmail.com'),
(N'Công ty Hải Sản Biển Xanh', '0956789012', 'haisanbx@gmail.com'),
(N'Nhà cung cấp Gia Vị Nam Phát', '0967890123', 'giavinp@gmail.com'),
(N'Công ty TNHH Cà Phê Nguyên Chất', '0978901234', 'caphe@gmail.com'),
(N'Nhà cung cấp Rau Củ Đà Lạt', '0989012345', 'raucudalat@gmail.com'),
(N'Công ty Thực Phẩm Đông Lạnh', '0990123456', 'donglanh@gmail.com'),
(N'Nhà cung cấp Bia Tiger', '0901234567', 'biatiger@gmail.com'),
(N'Công ty TNHH Thảo Mộc Việt', '0912345679', 'thaomocviet@gmail.com'),
(N'Nhà cung cấp Thịt Bò Úc', '0923456780', 'thitbouc@gmail.com'),
(N'Công ty TNHH Trà Việt', '0934567891', 'traviet@gmail.com'),
(N'Nhà cung cấp Sữa Tươi Đà Lạt', '0945678902', 'suatuoi@gmail.com'),
(N'Công ty TNHH Gạo Hữu Cơ', '0956789013', 'gaohuuco@gmail.com'),
(N'Nhà cung cấp Hải Sản Nha Trang', '0967890124', 'haisannt@gmail.com'),
(N'Công ty TNHH Bánh Ngọt Sài Gòn', '0978901235', 'banhngot@gmail.com'),
(N'Nhà cung cấp Rượu Vang Chile', '0989012346', 'ruouvangchile@gmail.com'),
(N'Công ty TNHH Thực Phẩm Chay', '0990123457', 'thucphamchay@gmail.com'),
(N'Nhà cung cấp Nước Ép Tự Nhiên', '0901234568', 'nuocep@gmail.com');

-- 6. Insert into SanPham (Products) - 30 rows for variety
INSERT INTO SanPham (TenSanPham, MaDanhMuc, MaNhaCungCap, Gia, MoTa, SoLuongTonKho) VALUES
-- Cocktails (1)
(N'Phở Cocktail', 1, 2, 150000, N'Cocktail lấy cảm hứng từ phở với gin', 50),
(N'Lychee Martini', 1, 2, 180000, N'Cocktail vải thiều với vodka', 40),
(N'Mango Mojito', 1, 2, 160000, N'Mojito xoài tươi mát', 45),
-- Beers (2)
(N'Bia Sài Gòn', 2, 3, 35000, N'Bia Sài Gòn Special', 200),
(N'Bia Tiger', 2, 10, 40000, N'Bia Tiger Crystal', 180),
(N'Heineken', 2, 10, 45000, N'Bia Heineken nhập khẩu', 150),
-- Wines (3)
(N'Rượu Vang Đà Lạt Đỏ', 3, 2, 250000, N'Rượu vang đỏ từ nho Đà Lạt', 30),
(N'Rượu Vang Chile Trắng', 3, 18, 300000, N'Rượu vang trắng Chile', 25),
-- Fresh Juices (4)
(N'Nước Ép Dứa', 4, 4, 50000, N'Nước ép dứa tươi 100%', 100),
(N'Nước Ép Cam', 4, 4, 55000, N'Nước ép cam tươi', 90),
-- Coffee (5)
(N'Cà Phê Sữa Đá', 5, 7, 40000, N'Cà phê phin với sữa đặc', 150),
(N'Cà Phê Đen', 5, 7, 35000, N'Cà phê phin đen nguyên chất', 140),
-- Tea (6)
(N'Trà Sen', 6, 13, 45000, N'Trà sen thơm lừng', 80),
(N'Trà Xanh Lài', 6, 13, 40000, N'Trà xanh pha với hoa lài', 85),
-- Mocktails (7)
(N'Mocktail Chanh Dây', 7, 4, 60000, N'Mocktail chanh dây tươi mát', 70),
(N'Mocktail Dưa Hấu', 7, 4, 60000, N'Mocktail dưa hấu giải nhiệt', 65),
-- Appetizers (9)
(N'Gỏi Cuốn Tôm', 9, 5, 80000, N'Gỏi cuốn tôm tươi với rau sống', 60),
(N'Chả Giò Hải Sản', 9, 5, 90000, N'Chả giò chiên giòn nhân hải sản', 50),
-- Salads (10)
(N'Salad Cá Hồi', 10, 5, 120000, N'Salad cá hồi với sốt mè rang', 40),
(N'Salad Gà Nướng', 10, 12, 100000, N'Salad gà nướng với rau xanh', 45),
-- Phở (11)
(N'Phở Bò', 11, 12, 120000, N'Phở bò truyền thống', 70),
(N'Phở Gà', 11, 12, 110000, N'Phở gà thơm ngon', 65),
-- Grilled Dishes (12)
(N'Cá Bớp Nướng Muối Ớt', 12, 5, 250000, N'Cá bớp nướng muối ớt', 20),
(N'Sườn Heo Nướng', 12, 12, 180000, N'Sườn heo nướng mật ong', 25),
-- Stir-fried Dishes (13)
(N'Bò Xào Lăn', 13, 12, 150000, N'Bò xào lăn đậm đà', 30),
(N'Mực Xào Tỏi', 13, 5, 160000, N'Mực tươi xào tỏi', 35),
-- Stews (14)
(N'Bò Hầm Rượu Vang', 14, 12, 200000, N'Bò hầm với rượu vang đỏ', 20),
(N'Gà Hầm Thuốc Bắc', 14, 12, 180000, N'Gà hầm bổ dưỡng', 25),
-- Rice and Noodles (15)
(N'Cơm Chiên Hải Sản', 15, 5, 120000, N'Cơm chiên với tôm mực', 50),
(N'Mì Xào Bò', 15, 12, 130000, N'Mì xào bò mềm thơm', 45),
-- Vegetarian (16)
(N'Đậu Hũ Chiên Giòn', 16, 19, 80000, N'Đậu hũ chiên giòn với sốt chấm', 60),
(N'Nấm Xào Thập Cẩm', 16, 19, 90000, N'Nấm xào rau củ', 55),
-- Desserts (17)
(N'Chè Ba Màu', 17, 19, 45000, N'Chè ba màu với nước cốt dừa', 80),
(N'Bánh Flan', 17, 17, 40000, N'Bánh flan caramel mềm mịn', 90),
-- Cakes (18)
(N'Bánh Tiramisu', 18, 17, 60000, N'Bánh tiramisu cà phê', 40),
(N'Bánh Cheesecake', 18, 17, 65000, N'Bánh cheesecake chanh dây', 35);

-- 7. Insert into Ban (Tables) - 20 rows
INSERT INTO Ban (SoBan, SoChoNgoi, KhuVuc, TrangThai) VALUES
(N'Bàn 01', 4, N'Nhà Hàng', N'Trống'),
(N'Bàn 02', 6, N'Nhà Hàng', N'Đang sử dụng'),
(N'Bàn 03', 2, N'Quầy Bar', N'Trống'),
(N'Bàn 04', 8, N'Nhà Hàng', N'Trống'),
(N'Bàn 05', 4, N'Quầy Bar', N'Đang sử dụng'),
(N'Bàn 06', 6, N'Nhà Hàng', N'Trống'),
(N'Bàn 07', 4, N'Quầy Bar', N'Trống'),
(N'Bàn 08', 10, N'Nhà Hàng', N'Đang sử dụng'),
(N'Bàn 09', 2, N'Quầy Bar', N'Trống'),
(N'Bàn 10', 6, N'Nhà Hàng', N'Trống'),
(N'Bàn 11', 4, N'Nhà Hàng', N'Đang sử dụng'),
(N'Bàn 12', 8, N'Quầy Bar', N'Trống'),
(N'Bàn 13', 6, N'Nhà Hàng', N'Trống'),
(N'Bàn 14', 4, N'Quầy Bar', N'Đang sử dụng'),
(N'Bàn 15', 2, N'Nhà Hàng', N'Trống'),
(N'Bàn 16', 6, N'Quầy Bar', N'Trống'),
(N'Bàn 17', 4, N'Nhà Hàng', N'Trống'),
(N'Bàn 18', 8, N'Quầy Bar', N'Đang sử dụng'),
(N'Bàn 19', 6, N'Nhà Hàng', N'Trống'),
(N'Bàn 20', 4, N'Quầy Bar', N'Trống');

-- 8. Insert into Voucher - 20 rows
INSERT INTO Voucher (MaKhachHang, MaSanPham, GiaTri, NgayHetHan, TrangThai) VALUES
(1, 1, 50000, '2025-05-30', N'Chưa sử dụng'),
(2, 4, 20000, '2025-06-15', N'Chưa sử dụng'),
(3, 6, 30000, '2025-04-30', N'Đã sử dụng'),
(4, 9, 40000, '2025-05-15', N'Chưa sử dụng'),
(5, 11, 25000, '2025-06-01', N'Chưa sử dụng'),
(6, 13, 35000, '2025-05-20', N'Đã sử dụng'),
(7, 15, 45000, '2025-06-10', N'Chưa sử dụng'),
(8, 17, 20000, '2025-05-25', N'Chưa sử dụng'),
(9, 19, 30000, '2025-06-05', N'Chưa sử dụng'),
(10, 21, 40000, '2025-05-30', N'Đã sử dụng'),
(11, 23, 50000, '2025-06-15', N'Chưa sử dụng'),
(12, 25, 25000, '2025-05-10', N'Chưa sử dụng'),
(13, 27, 35000, '2025-06-20', N'Chưa sử dụng'),
(14, 29, 45000, '2025-05-15', N'Đã sử dụng'),
(15, 31, 20000, '2025-06-01', N'Chưa sử dụng'),
(16, 33, 30000, '2025-05-25', N'Chưa sử dụng'),
(17, 35, 40000, '2025-06-10', N'Chưa sử dụng'),
(18, 4, 25000, '2025-05-30', N'Đã sử dụng'),
(19, 6, 35000, '2025-06-05', N'Chưa sử dụng'),
(20, 8, 45000, '2025-05-20', N'Chưa sử dụng');

-- 9. Insert into HoaDon (Invoices) - 20 rows
INSERT INTO HoaDon (MaKhachHang, MaNhanVien, MaBan, NgayDat, TongTien, TienGiamGia, TongThueVAT, TrangThai, NguoiTao) VALUES
(1, 2, 2, '2025-04-25 19:00:00', 350000, 52500, 29750, N'Đã thanh toán', 1),
(2, 3, 5, '2025-04-26 20:30:00', 200000, 0, 16000, N'Chưa thanh toán', 5),
(3, 4, 1, '2025-04-27 18:45:00', 450000, 45000, 36000, N'Đã thanh toán', 9),
(4, 6, 3, '2025-04-25 19:30:00', 300000, 0, 24000, N'Chưa thanh toán', 15),
(5, 7, 4, '2025-04-26 21:00:00', 500000, 100000, 40000, N'Đã thanh toán', 1),
(6, 8, 6, '2025-04-27 17:30:00', 250000, 0, 20000, N'Chưa thanh toán', 5),
(7, 10, 8, '2025-04-25 20:00:00', 400000, 48000, 32000, N'Đã thanh toán', 9),
(8, 11, 10, '2025-04-26 19:15:00', 320000, 0, 25600, N'Chưa thanh toán', 15),
(9, 12, 12, '2025-04-27 18:00:00', 380000, 38000, 30400, N'Đã thanh toán', 1),
(10, 13, 14, '2025-04-25 21:30:00', 280000, 0, 22400, N'Chưa thanh toán', 5),
(11, 14, 16, '2025-04-26 20:45:00', 410000, 49200, 32800, N'Đã thanh toán', 9),
(12, 16, 18, '2025-04-27 19:00:00', 360000, 0, 28800, N'Chưa thanh toán', 15),
(13, 17, 20, '2025-04-25 18:30:00', 290000, 29000, 23200, N'Đã thanh toán', 1),
(14, 18, 1, '2025-04-26 19:45:00', 430000, 0, 34400, N'Chưa thanh toán', 5),
(15, 19, 3, '2025-04-27 20:15:00', 340000, 51000, 27200, N'Đã thanh toán', 9),
(16, 20, 5, '2025-04-25 19:15:00', 310000, 0, 24800, N'Chưa thanh toán', 15),
(17, 2, 7, '2025-04-26 18:45:00', 370000, 37000, 29600, N'Đã thanh toán', 1),
(18, 3, 9, '2025-04-27 21:00:00', 390000, 0, 31200, N'Chưa thanh toán', 5),
(19, 4, 11, '2025-04-25 20:30:00', 420000, 63000, 33600, N'Đã thanh toán', 9),
(20, 6, 13, '2025-04-26 19:30:00', 330000, 0, 26400, N'Chưa thanh toán', 15);

-- 10. Insert into ChiTietHoaDon (Invoice Details) - 20 rows
INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, Gia, ThueVAT) VALUES
(1, 1, 2, 150000, 10.00), -- Phở Cocktail
(1, 17, 1, 80000, 8.00), -- Gỏi Cuốn Tôm
(2, 11, 3, 40000, 8.00), -- Cà Phê Sữa Đá
(2, 21, 1, 120000, 8.00), -- Phở Bò
(3, 4, 5, 35000, 10.00), -- Bia Sài Gòn
(3, 23, 1, 250000, 8.00), -- Cá Bớp Nướng
(4, 13, 2, 45000, 8.00), -- Trà Sen
(4, 19, 2, 120000, 8.00), -- Salad Cá Hồi
(5, 2, 3, 180000, 10.00), -- Lychee Martini
(5, 29, 2, 120000, 8.00), -- Cơm Chiên Hải Sản
(6, 6, 4, 45000, 10.00), -- Heineken
(6, 33, 1, 45000, 8.00), -- Chè Ba Màu
(7, 8, 1, 300000, 10.00), -- Rượu Vang Chile Trắng
(7, 25, 2, 150000, 8.00), -- Bò Xào Lăn
(8, 15, 3, 60000, 8.00), -- Mocktail Chanh Dây
(8, 27, 1, 200000, 8.00), -- Bò Hầm Rượu Vang
(9, 3, 2, 160000, 10.00), -- Mango Mojito
(9, 31, 2, 80000, 8.00), -- Đậu Hũ Chiên Giòn
(10, 9, 4, 50000, 8.00), -- Nước Ép Dứa
(10, 35, 1, 60000, 8.00); -- Bánh Tiramisu

-- 11. Insert into KhoHang (Inventory) - 20 rows
INSERT INTO KhoHang (MaSanPham, SoLuongTon) VALUES
(1, 50),  -- Phở Cocktail
(2, 40),  -- Lychee Martini
(3, 45),  -- Mango Mojito
(4, 200), -- Bia Sài Gòn
(5, 180), -- Bia Tiger
(6, 150), -- Heineken
(7, 30),  -- Rượu Vang Đà Lạt Đỏ
(8, 25),  -- Rượu Vang Chile Trắng
(9, 100), -- Nước Ép Dứa
(10, 90), -- Nước Ép Cam
(11, 150),-- Cà Phê Sữa Đá
(12, 140),-- Cà Phê Đen
(13, 80), -- Trà Sen
(14, 85), -- Trà Xanh Lài
(15, 70), -- Mocktail Chanh Dây
(16, 65), -- Mocktail Dưa Hấu
(17, 60), -- Gỏi Cuốn Tôm
(18, 50), -- Chả Giò Hải Sản
(19, 40), -- Salad Cá Hồi
(20, 45); -- Salad Gà Nướng

-- 12. Insert into PhieuNhapKho (Warehouse Receipts) - 20 rows
INSERT INTO PhieuNhapKho (NgayNhap, MaNV, TongTienNhap, GhiChu) VALUES
('2025-04-20', 1, 5000000, N'Nhập lô bia và cocktail'),
('2025-04-21', 5, 3000000, N'Nhập hải sản và trái cây'),
('2025-04-22', 9, 4000000, N'Nhập thịt bò và rau củ'),
('2025-04-23', 15, 2500000, N'Nhập cà phê và trà'),
('2025-04-24', 1, 3500000, N'Nhập rượu vang và bánh ngọt'),
('2025-04-25', 5, 2000000, N'Nhập nguyên liệu chè'),
('2025-04-26', 9, 4500000, N'Nhập hải sản tươi'),
('2025-04-27', 15, 3000000, N'Nhập bia và nước ép'),
('2025-04-20', 1, 2800000, N'Nhập thực phẩm chay'),
('2025-04-21', 5, 3200000, N'Nhập thịt và gia vị'),
('2025-04-22', 9, 2700000, N'Nhập trái cây tươi'),
('2025-04-23', 15, 4100000, N'Nhập bia và cocktail'),
('2025-04-24', 1, 2600000, N'Nhập rau củ và nấm'),
('2025-04-25', 5, 3300000, N'Nhập hải sản và thịt'),
('2025-04-26', 9, 2900000, N'Nhập cà phê và trà'),
('2025-04-27', 15, 3700000, N'Nhập rượu vang và bánh'),
('2025-04-20', 1, 3100000, N'Nhập thực phẩm chay'),
('2025-04-21', 5, 3400000, N'Nhập trái cây và nước ép'),
('2025-04-22', 9, 3600000, N'Nhập bia và cocktail'),
('2025-04-23', 15, 3200000, N'Nhập hải sản và rau củ');

-- 13. Insert into ChiTietPhieuNhapKho (Warehouse Receipt Details) - 20 rows
INSERT INTO ChiTietPhieuNhapKho (MaPhieuNhap, MaSanPham, SoLuong, DonGia) VALUES
(1, 4, 100, 30000),  -- Bia Sài Gòn
(1, 1, 20, 100000),  -- Phở Cocktail
(2, 23, 10, 200000), -- Cá Bớp Nướng
(2, 9, 50, 40000),   -- Nước Ép Dứa
(3, 21, 30, 90000),  -- Phở Bò
(3, 12, 100, 25000), -- Cà Phê Đen
(4, 13, 50, 35000),  -- Trà Sen
(4, 19, 20, 100000), -- Salad Cá Hồi
(5, 7, 15, 200000),  -- Rượu Vang Đà Lạt Đỏ
(5, 35, 30, 50000),  -- Bánh Tiramisu
(6, 33, 50, 35000),  -- Chè Ba Màu
(6, 15, 40, 50000),  -- Mocktail Chanh Dây
(7, 18, 30, 70000),  -- Chả Giò Hải Sản
(7, 25, 20, 120000), -- Bò Xào Lăn
(8, 5, 80, 35000),   -- Bia Tiger
(8, 10, 60, 45000),  -- Nước Ép Cam
(9, 31, 40, 60000),  -- Đậu Hũ Chiên Giòn
(9, 27, 10, 150000), -- Bò Hầm Rượu Vang
(10, 29, 30, 90000), -- Cơm Chiên Hải Sản
(10, 2, 15, 120000); -- Lychee Martini

-- 14. Insert into PhieuXuatKho (Warehouse Issues) - 20 rows
INSERT INTO PhieuXuatKho (NgayXuat, MaNhanVien, GhiChu) VALUES
('2025-04-20', 2, N'Xuất nguyên liệu cho bếp'),
('2025-04-21', 3, N'Xuất bia cho quầy bar'),
('2025-04-22', 4, N'Xuất trái cây cho nước ép'),
('2025-04-23', 6, N'Xuất hải sản cho món nướng'),
('2025-04-24', 7, N'Xuất cà phê và trà'),
('2025-04-25', 8, N'Xuất bánh ngọt và chè'),
('2025-04-26', 10, N'Xuất thịt bò cho món xào'),
('2025-04-27', 11, N'Xuất cocktail cho quầy bar'),
('2025-04-20', 12, N'Xuất rau củ cho salad'),
('2025-04-21', 13, N'Xuất bia và rượu vang'),
('2025-04-22', 14, N'Xuất nguyên liệu phở'),
('2025-04-23', 16, N'Xuất thực phẩm chay'),
('2025-04-24', 17, N'Xuất hải sản cho cơm chiên'),
('2025-04-25', 18, N'Xuất trái cây cho mocktail'),
('2025-04-26', 19, N'Xuất thịt cho món nướng'),
('2025-04-27', 20, N'Xuất cà phê và nước ép'),
('2025-04-20', 2, N'Xuất bánh ngọt cho tráng miệng'),
('2025-04-21', 3, N'Xuất bia cho quầy bar'),
('2025-04-22', 4, N'Xuất rau củ cho món chay'),
('2025-04-23', 6, N'Xuất cocktail và rượu vang');

-- 15. Insert into ChiTietPhieuXuat (Warehouse Issue Details) - 20 rows
INSERT INTO ChiTietPhieuXuat (MaPhieuXuat, MaSanPham, SoLuong) VALUES
(1, 21, 10), -- Phở Bò
(1, 23, 5),  -- Cá Bớp Nướng
(2, 4, 50),  -- Bia Sài Gòn
(2, 6, 30),  -- Heineken
(3, 9, 20),  -- Nước Ép Dứa
(3, 10, 15), -- Nước Ép Cam
(4, 18, 10), -- Chả Giò Hải Sản
(4, 29, 8),  -- Cơm Chiên Hải Sản
(5, 11, 30), -- Cà Phê Sữa Đá
(5, 13, 20), -- Trà Sen
(6, 33, 15), -- Chè Ba Màu
(6, 35, 10), -- Bánh Tiramisu
(7, 25, 12), -- Bò Xào Lăn
(7, 27, 5),  -- Bò Hầm Rượu Vang
(8, 1, 10),  -- Phở Cocktail
(8, 2, 8),   -- Lychee Martini
(9, 19, 10), -- Salad Cá Hồi
(9, 20, 8),  -- Salad Gà Nướng
(10, 7, 5),  -- Rượu Vang Đà Lạt Đỏ
(10, 8, 4);  -- Rượu Vang Chile Trắng

-- 16. Insert into BaoCao (Reports) - 20 rows
INSERT INTO BaoCao (LoaiBaoCao, NgayBaoCao, TongDoanhThu, TongChiPhi, SoHoaDon, SoKhachHang, SoSanPhamBanRa, NguoiTao, GhiChu) VALUES
(N'Hàng Ngày', '2025-04-20', 2000000, 1200000, 10, 15, 50, 1, N'Báo cáo ngày 20/04'),
(N'Hàng Ngày', '2025-04-21', 2500000, 1500000, 12, 18, 60, 5, N'Báo cáo ngày 21/04'),
(N'Hàng Ngày', '2025-04-22', 1800000, 1000000, 8, 12, 45, 9, N'Báo cáo ngày 22/04'),
(N'Hàng Ngày', '2025-04-23', 2200000, 1300000, 11, 16, 55, 15, N'Báo cáo ngày 23/04'),
(N'Hàng Ngày', '2025-04-24', 2700000, 1600000, 13, 20, 65, 1, N'Báo cáo ngày 24/04'),
(N'Hàng Ngày', '2025-04-25', 3000000, 1800000, 15, 22, 70, 5, N'Báo cáo ngày 25/04'),
(N'Hàng Ngày', '2025-04-26', 2800000, 1700000, 14, 21, 68, 9, N'Báo cáo ngày 26/04'),
(N'Hàng Ngày', '2025-04-27', 2600000, 1500000, 12, 18, 60, 15, N'Báo cáo ngày 27/04'),
(N'Hàng Tháng', '2025-04-30', 50000000, 30000000, 200, 350, 1000, 1, N'Báo cáo tháng 04/2025'),
(N'Hàng Tháng', '2025-03-31', 48000000, 29000000, 190, 340, 980, 5, N'Báo cáo tháng 03/2025'),
(N'Hàng Ngày', '2025-04-19', 2100000, 1250000, 10, 14, 48, 9, N'Báo cáo ngày 19/04'),
(N'Hàng Ngày', '2025-04-18', 2300000, 1350000, 11, 16, 52, 15, N'Báo cáo ngày 18/04'),
(N'Hàng Ngày', '2025-04-17', 2400000, 1400000, 12, 17, 55, 1, N'Báo cáo ngày 17/04'),
(N'Hàng Ngày', '2025-04-16', 1900000, 1100000, 9, 13, 47, 5, N'Báo cáo ngày 16/04'),
(N'Hàng Ngày', '2025-04-15', 2600000, 1500000, 13, 19, 60, 9, N'Báo cáo ngày 15/04'),
(N'Hàng Ngày', '2025-04-14', 2700000, 1600000, 14, 20, 65, 15, N'Báo cáo ngày 14/04'),
(N'Hàng Ngày', '2025-04-13', 2000000, 1200000, 10, 15, 50, 1, N'Báo cáo ngày 13/04'),
(N'Hàng Ngày', '2025-04-12', 2200000, 1300000, 11, 16, 55, 5, N'Báo cáo ngày 12/04'),
(N'Hàng Ngày', '2025-04-11', 2500000, 1500000, 12, 18, 60, 9, N'Báo cáo ngày 11/04'),
(N'Hàng Năm', '2025-12-31', 600000000, 360000000, 2400, 4200, 12000, 15, N'Báo cáo năm 2025');
