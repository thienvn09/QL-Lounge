
CREATE DATABASE HT_Shop;
GO
USE HT_Shop;
GO
 --Tạo bảng Cửa Hàng
CREATE TABLE CuaHang (
    MaCH VARCHAR(10) PRIMARY KEY,
    TenCH VARCHAR(100),
    CHTruong VARCHAR(100)
);
GO

-- Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    HoNV VARCHAR(100),
    TenNV VARCHAR(100),
    GioiTinh VARCHAR(20),
    NgaySinh DATE,
    DiaChi VARCHAR(100),
    DienThoai VARCHAR(20),
    NoiSinh VARCHAR(100),
    NgayVaoLam DATE,
    Email VARCHAR(100),
    MaCH VARCHAR(10),
    FOREIGN KEY (MaCH) REFERENCES CuaHang(MaCH)
);
GO

-- Tạo bảng Tài Khoản
CREATE TABLE TaiKhoan (
    TenDN VARCHAR(20) PRIMARY KEY,
    MatKhau VARCHAR(100),
    ChucVu VARCHAR(100),
    MaNV VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

-- Tạo bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(10) PRIMARY KEY,
    TenNCC VARCHAR(100),
    DiaChi VARCHAR(100),
    DienThoai VARCHAR(20),
    Email VARCHAR(100)
);
GO

-- Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH VARCHAR(10) PRIMARY KEY,
    TenKH VARCHAR(100),
    DiaChi VARCHAR(100),
    NgaySinh DATE,
    DienThoai VARCHAR(20),
    ThanhVien VARCHAR(30)
);
GO

-- Tạo bảng Loại Sản Phẩm
CREATE TABLE LoaiSanPham (
    MaloaiSP VARCHAR(10) PRIMARY KEY,
    TenloaiSP VARCHAR(100),
    GhiChu VARCHAR(100)
);
GO

-- Tạo bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY,
    TenSP VARCHAR(100),
    SLTon INT,
    DonViTinh VARCHAR(10),
    MaloaiSP VARCHAR(10),
    MaNCC VARCHAR(10),
    FOREIGN KEY (MaloaiSP) REFERENCES LoaiSanPham(MaloaiSP),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO

-- Tạo bảng Phiếu Nhập
CREATE TABLE PhieuNhap (
    SoPN VARCHAR(10) PRIMARY KEY,
    NgayNhap DATE,
    PTTT VARCHAR(100),
    GhiChu VARCHAR(100),
    MaNV VARCHAR(10),
    MaNCC VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO

-- Tạo bảng Chi Tiết Phiếu Nhập
CREATE TABLE CTPhieuNhap (
    SoPN VARCHAR(10),
    MaSP VARCHAR(10),
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    PRIMARY KEY (SoPN, MaSP),
    FOREIGN KEY (SoPN) REFERENCES PhieuNhap(SoPN),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO

-- Tạo bảng Phiếu Xuất
CREATE TABLE PhieuXuat (
    SoPX VARCHAR(10) PRIMARY KEY,
    NgayXuat DATE,
    GhiChu VARCHAR(100),
    MaNV VARCHAR(10),
    MaCH VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaCH) REFERENCES CuaHang(MaCH)
);
GO

-- Tạo bảng Chi Tiết Phiếu Xuất
CREATE TABLE CTPhieuXuat (
    SoPX VARCHAR(10),
    MaSP VARCHAR(10),
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    PRIMARY KEY (SoPX, MaSP),
    FOREIGN KEY (SoPX) REFERENCES PhieuXuat(SoPX),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO

-- Tạo bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    NgayDH DATE,
    PTTT VARCHAR(100),
    MaNV VARCHAR(10),
    MaKH VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD001', N'SP01', 1, 90000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD001', N'SP02', 5, 100000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD01', N'SP16', 3, 35000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD017', N'SP10', 5, 30000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD02', N'SP05', 3, 21000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD03', N'SP07', 2, 25000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD03', N'SP14', 4, 25000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD04', N'SP02', 5, 75000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD05', N'SP17', 1, 4000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD05', N'SP18', 10, 55000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD06', N'SP05', 2, 21000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD07', N'SP01', 5, 60000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD07', N'SP06', 3, 21000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD07', N'SP21', 3, 55000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD08', N'SP08', 4, 30000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD09', N'SP12', 5, 30000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD10', N'SP09', 3, 32000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD11', N'SP23', 10, 40000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD12', N'SP03', 3, 65000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD13', N'SP04', 2, 22000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD14', N'SP15', 4, 25000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD14', N'SP20', 2, 20000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD15', N'SP13', 2, 65000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD16', N'SP10', 3, 30000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD17', N'SP17', 50, 6000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD18', N'SP19', 20, 80000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD19', N'SP01', 5, 60000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD20', N'SP11', 2, 35000)
INSERT [dbo].[CTHoaDon] ([MaHD], [MaSP], [SoLuongDat], [DGBan]) VALUES (N'HD20', N'SP22', 30, 42000)
GO
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN01', N'SP01', 15, 50000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN01', N'SP02', 20, 65000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN01', N'SP11', 1, 4000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN01', N'SP12', 20, 20000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN0133', N'SP01', 1, 90000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN02', N'SP10', 35, 20000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN03', N'SP09', 15, 22000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN03', N'SP17', 20, 3500)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN03', N'SP20', 25, 10000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN04', N'SP03', 20, 55000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN05', N'SP23', 15, 30000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN06', N'SP10', 35, 20000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN07', N'SP15', 20, 15000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN07', N'SP22', 20, 32000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN08', N'SP04', 20, 12000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN09', N'SP11', 10, 25000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN09', N'SP21', 20, 45000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN10', N'SP08', 25, 20000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN11', N'SP04', 20, 12000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN11', N'SP05', 25, 11000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN12', N'SP15', 20, 15000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN13', N'SP20', 25, 10000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN14', N'SP02', 25, 65000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN14', N'SP13', 20, 55000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN14', N'SP14', 30, 15000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN15', N'SP19', 30, 70000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN16', N'SP07', 12, 15000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN17', N'SP19', 30, 70000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN18', N'SP16', 15, 25000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN18', N'SP18', 20, 45000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN19', N'SP22', 20, 32000)
INSERT [dbo].[CTPhieuNhap] ([SoPN], [MaSP], [SoLuong], [DonGia]) VALUES (N'PN20', N'SP06', 20, 11000)
GO
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX01', N'SP18', 50, 45000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX01', N'SP19', 60, 70000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX0111', N'SP01', 1, 1111)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX02', N'SP02', 15, 65000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX02', N'SP05', 20, 11000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX03', N'SP12', 30, 20000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX04', N'SP02', 15, 65000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX04', N'SP07', 10, 15000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX05', N'SP04', 10, 12000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX06', N'SP08', 10, 20000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX07', N'SP09', 10, 22000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX08', N'SP18', 30, 45000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX09', N'SP10', 25, 20000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX09', N'SP15', 30, 15000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX10', N'SP09', 20, 22000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX10', N'SP17', 300, 3500)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX11', N'SP20', 10, 10000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX12', N'SP08', 10, 20000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX13', N'SP14', 20, 15000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX14', N'SP01', 15, 50000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX15', N'SP18', 40, 45000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX16', N'SP10', 10, 20000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX17', N'SP01', 15, 50000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX18', N'SP07', 20, 15000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX19', N'SP01', 15, 50000)
INSERT [dbo].[CTPhieuXuat] ([SoPX], [MaSP], [SoLuong], [DonGia]) VALUES (N'PX20', N'SP04', 10, 12000)
GO
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH01', N'Cửa hàng chi nhánh Quận 1', N'Phan Văn Tài')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH02', N'Cửa hàng chi nhánh Quận 7', N'Lâm Văn Bền')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH03', N'Cửa hàng chi nhánh Biên Hòa', N'Trần Thị Mơ')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH04', N'Cửa hàng chi nhánh Vũng Tàu', N'Trần Ngọc Mai')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH05', N'Cửa hàng chi nhánh Cần Thơ', N'Phan Duy Tâm')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH06', N'Cửa hàng chi nhánh Đà Nẵng', N'Nguyễn Ngọc Bích')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH07', N'Cửa hàng chi nhánh Bình Dương', N'Trần Tấn Duy')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH08', N'Cửa hàng chi nhánh Hải Phòng', N'Nguyễn Thành Phát')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH09', N'Cửa hàng chi nhánh Quận 8', N'Trần Gia Huy')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH099', N'Cửa hàng chi nhánh Quận 3', N'Phan Văn Tài')
INSERT [dbo].[CuaHang] ([MaCH], [TenCH], [CHTruong]) VALUES (N'CH10', N'Cửa hàng chi nhánh Quận Bình Thạnh', N'Lê Duy Khánh')
GO
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD001', CAST(N'2024-09-21T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV08', N'KH12')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD01', CAST(N'2022-05-04T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV04', N'KH06')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD017', CAST(N'2022-05-04T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV07', N'KH10')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD02', CAST(N'2022-05-09T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV09', N'KH01')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD03', CAST(N'2022-05-15T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV08', N'KH03')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD04', CAST(N'2022-06-25T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV01', N'KH09')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD05', CAST(N'2022-07-04T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV09', N'KH10')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD06', CAST(N'2022-07-20T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV03', N'KH02')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD07', CAST(N'2022-08-04T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV02', N'KH08')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD08', CAST(N'2022-08-20T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV01', N'KH11')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD09', CAST(N'2022-09-08T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV10', N'KH04')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD10', CAST(N'2022-10-10T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV19', N'KH07')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD11', CAST(N'2022-10-22T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV20', N'KH05')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD12', CAST(N'2022-11-06T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV05', N'KH12')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD13', CAST(N'2022-12-03T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV15', N'KH18')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD14', CAST(N'2022-12-18T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV17', N'KH13')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD15', CAST(N'2023-01-03T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV18', N'KH15')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD16', CAST(N'2023-01-26T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV14', N'KH14')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD17', CAST(N'2023-02-04T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV10', N'KH16')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD18', CAST(N'2023-02-15T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV01', N'KH11')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD19', CAST(N'2023-03-10T00:00:00.000' AS DateTime), N'Chuyển khoản', N'NV07', N'KH17')
INSERT [dbo].[HoaDon] ([MaHD], [NgayDH], [PTTT], [MaNV], [MaKH]) VALUES (N'HD20', CAST(N'2023-03-25T00:00:00.000' AS DateTime), N'Tiền mặt', N'NV12', N'KH08')
GO
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH01', N'Ngọc', N'123/6 bis Lê Thánh Tôn', CAST(N'2000-04-26T00:00:00.000' AS DateTime), N'098123123', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH014', N'Ngọc', N'123/6 bis Lê Thánh Tôn', CAST(N'2000-04-26T00:00:00.000' AS DateTime), N'098123123', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH02', N'Tuấn', N'49/12B Nguyễn Thị Minh Khai', CAST(N'2001-05-07T00:00:00.000' AS DateTime), N'091321321', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH03', N'Anh', N'Ngõ 6, phố Thanh Xuân', CAST(N'2000-03-26T00:00:00.000' AS DateTime), N'090312312', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH04', N'Khánh', N'67 bis Nguyễn Thượng Hiền', CAST(N'1999-09-29T00:00:00.000' AS DateTime), N'090812812', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH05', N'Thịnh', N'41 Xóm Củi', CAST(N'2000-10-02T00:00:00.000' AS DateTime), N'02116584446', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH06', N'Minh', N'31 Nguyễn Xí', CAST(N'2001-01-20T00:00:00.000' AS DateTime), N'02116584447', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH07', N'Khương', N'1110 Phan Văn Trị', CAST(N'1998-07-15T00:00:00.000' AS DateTime), N'02116584448', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH08', N'Đức', N'91 Thống Nhất', CAST(N'2003-07-26T00:00:00.000' AS DateTime), N'02116584449', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH09', N'Nhung', N'71 Quang Trung', CAST(N'2002-08-20T00:00:00.000' AS DateTime), N'02116584441', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH10', N'Hưng', N'21 Chu Văn An', CAST(N'2005-09-21T00:00:00.000' AS DateTime), N'02116584442', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH11', N'Linh', N'71 Huỳnh Thúc Kháng', CAST(N'2005-04-25T00:00:00.000' AS DateTime), N'0985278934', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH12', N'Khánh', N'93 Quốc lộ 13', CAST(N'2000-04-17T00:00:00.000' AS DateTime), N'0987855432', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH13', N'Duy', N'455 Xô Viết Nghệ Tĩnh', CAST(N'2000-09-29T00:00:00.000' AS DateTime), N'0347098766', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH14', N'Vy', N'12 Nguyễn Oanh', CAST(N'1996-06-26T00:00:00.000' AS DateTime), N'098987123', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH15', N'Nguyên', N'34 Lê Quang Định', CAST(N'2005-04-30T00:00:00.000' AS DateTime), N'098123787', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH16', N'Hồng', N'16 Trương Định', CAST(N'2003-10-22T00:00:00.000' AS DateTime), N'038145123', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH17', N'Vân', N'12 Nguyễn Gia Trí', CAST(N'2000-11-30T00:00:00.000' AS DateTime), N'098123345', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH18', N'Phương', N'54 Lê Văn Việt', CAST(N'2005-04-10T00:00:00.000' AS DateTime), N'098678129', N'Có')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH19', N'Châu', N'89 Lã Xuân Oai', CAST(N'2002-05-19T00:00:00.000' AS DateTime), N'098567345', N'Không')
INSERT [dbo].[KhachHang] ([MaKH], [TenKH], [DiaChi], [NgaySinh], [DienThoai], [ThanhVien]) VALUES (N'KH20', N'Liên', N'46 Võ Văn Hát', CAST(N'1999-05-12T00:00:00.000' AS DateTime), N'038678456', N'Không')
GO
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP01', N'Thực phẩm tươi', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP02', N'Rau củ', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP03', N'Gia vị', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP04', N'Trái cây', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP05', N'Thực phẩm đông lạnh', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP06', N'Thực phẩm ăn liền', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP07', N'Thực phẩm khô', NULL)
INSERT [dbo].[LoaiSanPham] ([MaloaiSP], [TenloaiSP], [GhiChu]) VALUES (N'LSP08', N'Sữa tươi', NULL)
GO
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC01', N'Trang trại xanh', N'76 Lê Văn Chí', N'0966843748', N'TTX@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC02', N'Rau-củ Farm', N'Thủ Dầu Một', N'0966885248', N'RXF@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC03', N'Công ty cổ phần ACECOOK', N'778 Nguyễn Kiệm', N'0966885038', N'ACECOOK@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC04', N'Công ty TH', N'b2/1a Tăng Nhơn Phú A', N'0966672048', N'THMILK@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC05', N'Công ty VINAMILK', N'Đường số 8, Hoàng Diệu Hai', N'0743843748', N'VINAMILK@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC06', N'Công ty AJINOMOTO', N'103 Nguyễn Thị Minh Khai', N'0966885678', N'AJINOMOTO@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC07', N'Tập đoàn HẠT NGỌC TRỜI', N'200 Võ Thị Sáu', N'0966809877', N'hnt@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC08', N'Công ty TNHH MTV Thành Thành Công Gia Lai', N'561 Trần Hưng Đạo', N'02693657345', N'ttcs@gmail.com')
INSERT [dbo].[NhaCungCap] ([MaNCC], [TenNCC], [DiaChi], [DienThoai], [Email]) VALUES (N'NCC088', N'Công ty AJINOMOTO', N'103 Nguyễn Thị Minh Khai', N'0966885678', N'AJINOMOTO@gmail.com')
GO
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV01', N'Phan', N'Thành Duy', N'Nam', CAST(N'1998-02-25T00:00:00.000' AS DateTime), N'5 Dương Quảng hàm', N'08858454182', N'Vũng Tàu', CAST(N'2017-05-01T00:00:00.000' AS DateTime), NULL, N'CH01')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV02', N'Lâm', N'Đại Ngọc', N'Nữ', CAST(N'1999-03-06T00:00:00.000' AS DateTime), N'2/1A Quang Trung', N'08354362205', N'Cà Mau', CAST(N'2017-05-01T00:00:00.000' AS DateTime), NULL, N'CH02')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV03', N'Trần', N'Châu Khoa', N'Nam', CAST(N'1999-05-05T00:00:00.000' AS DateTime), N'10 QL 1A', N'09181833333', N'Vĩnh Long', CAST(N'2017-05-01T00:00:00.000' AS DateTime), NULL, N'CH03')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV04', N'Lê', N'Chí Kiên', N'Nam', CAST(N'1995-03-10T00:00:00.000' AS DateTime), N'564/1/3F Nguyễn Xí', N'09131620000', N'Nghệ An', CAST(N'2017-05-01T00:00:00.000' AS DateTime), NULL, N'CH04')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV05', N'Phan', N'Thanh Tâm', N'Nữ', CAST(N'1996-03-03T00:00:00.000' AS DateTime), N'306 Nguyễn Trọng Tuyển', N'09186223333', N'Đồng Nai', CAST(N'2017-08-01T00:00:00.000' AS DateTime), NULL, N'CH05')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV06', N'Mai', N'Thị Lựu', N'Nữ', CAST(N'1992-06-25T00:00:00.000' AS DateTime), N'256/96/4 Phan Đăng Lưu', N'09181831444', N'TP.HCM', CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'CH06')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV07', N'Đào', N'Thị Hồng', N'Nữ', CAST(N'1999-03-18T00:00:00.000' AS DateTime), N'764/94 Phạm Văn Chiêu', N'09754322222', N'TP.HCM', CAST(N'2017-03-01T00:00:00.000' AS DateTime), NULL, N'CH07')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV08', N'Phan', N'Thành Nhân', N'Nam', CAST(N'1998-10-07T00:00:00.000' AS DateTime), N'152 Nguyễn Trọng Tuyển', N'09135332332', N'TP.HCM', CAST(N'2018-09-01T00:00:00.000' AS DateTime), NULL, N'CH08')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV09', N'Nguyễn', N'Ánh Dương', N'Nữ', CAST(N'2000-12-01T00:00:00.000' AS DateTime), N'65 Nam Kỳ Khởi Nghĩa', N'09812127678', N'Tiền Giang', CAST(N'2018-05-01T00:00:00.000' AS DateTime), NULL, N'CH09')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV10', N'Phan', N'Ánh Nguyệt', N'Nữ', CAST(N'1997-12-28T00:00:00.000' AS DateTime), N'32/65/9 Trần Cao Vân', N'09812342356', N'Đà Nẵng', CAST(N'2018-05-01T00:00:00.000' AS DateTime), NULL, N'CH10')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV11', N'Lê', N'Thị Cúc', N'Nữ', CAST(N'2000-04-05T00:00:00.000' AS DateTime), N'334 Phan Văn Trị', N'0389297475', N'Vũng Tàu', CAST(N'2018-05-01T00:00:00.000' AS DateTime), NULL, N'CH01')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV12', N'Mai', N'Minh Mẫn', N'Nam', CAST(N'1995-12-25T00:00:00.000' AS DateTime), N'58 Trần Bình Trọng', N'0883215763', N'Nha Trang', CAST(N'2019-06-01T00:00:00.000' AS DateTime), NULL, N'CH02')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV13', N'Võ', N'Minh Hoàng', N'Nam', CAST(N'2000-01-20T00:00:00.000' AS DateTime), N'310 Lê Quang Định', N'0982742175', N'Long An', CAST(N'2019-06-01T00:00:00.000' AS DateTime), NULL, N'CH03')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV14', N'Lê', N'Trung Kiệt', N'Nam', CAST(N'1999-10-10T00:00:00.000' AS DateTime), N'28 Nguyễn An Ninh', N'0398458351', N'Đà Nẵng', CAST(N'2019-06-01T00:00:00.000' AS DateTime), NULL, N'CH04')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV15', N'Trần', N'Trọng Duy', N'Nam', CAST(N'2000-02-25T00:00:00.000' AS DateTime), N'258 Dương Quảng hàm', N'0918670347', N'Tiền Giang', CAST(N'2019-06-01T00:00:00.000' AS DateTime), NULL, N'CH05')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV16', N'Phan', N'Nhật Hạ', N'Nữ', CAST(N'2000-06-29T00:00:00.000' AS DateTime), N'470 Nguyễn Thái Sơn', N'08858454874', N'Vũng Tàu', CAST(N'2019-09-07T00:00:00.000' AS DateTime), NULL, N'CH06')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV17', N'Trần', N'Minh Thư', N'Nữ', CAST(N'1999-02-15T00:00:00.000' AS DateTime), N'174 Bùi Đình Túy', N'08898454182', N'Nha Trang', CAST(N'2019-09-07T00:00:00.000' AS DateTime), NULL, N'CH07')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV18', N'Nguyễn', N'Bảo Duy', N'Nam', CAST(N'1998-09-28T00:00:00.000' AS DateTime), N'240 Nguyễn Xí', N'09638454084', N'Đồng Nai', CAST(N'2019-09-07T00:00:00.000' AS DateTime), NULL, N'CH08')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV19', N'Trịnh', N'Kim Chi', N'Nữ', CAST(N'1995-02-02T00:00:00.000' AS DateTime), N'791 Nguyễn Kiệm', N'08532454895', N'TP.HCM', CAST(N'2019-09-07T00:00:00.000' AS DateTime), NULL, N'CH09')
INSERT [dbo].[NhanVien] ([MaNV], [HoNV], [TenNV], [GioiTinh], [NgaySinh], [DiaChi], [DienThoai], [NoiSinh], [NgayVaoLam], [Email], [MaCH]) VALUES (N'NV20', N'Lê', N'Ngọc Thanh', N'Nữ', CAST(N'2000-05-07T00:00:00.000' AS DateTime), N'267 Chu Văn An', N'08979254186', N'Đà Nẵng', CAST(N'2019-09-07T00:00:00.000' AS DateTime), NULL, N'CH10')
GO
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN01', CAST(N'2022-04-05T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV05', N'NCC01')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN0133', CAST(N'2022-04-05T00:00:00.000' AS DateTime), N'ok', N'Chuyển khoản', N'NV10', N'NCC06')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN015', CAST(N'2022-04-05T00:00:00.000' AS DateTime), N'oke', N'Chuyển khoản', N'NV09', N'NCC07')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN02', CAST(N'2022-05-05T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV09', N'NCC06')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN03', CAST(N'2022-06-15T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV10', N'NCC08')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN04', CAST(N'2022-07-15T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV01', N'NCC01')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN05', CAST(N'2022-08-09T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV03', N'NCC04')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN06', CAST(N'2022-09-09T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV08', N'NCC06')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN07', CAST(N'2022-10-03T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV10', N'NCC05')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN08', CAST(N'2022-10-03T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV02', N'NCC02')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN09', CAST(N'2022-11-25T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV04', N'NCC08')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN10', CAST(N'2022-11-25T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV09', N'NCC03')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN11', CAST(N'2022-11-25T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV17', N'NCC02')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN12', CAST(N'2022-12-30T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV20', N'NCC05')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN13', CAST(N'2022-12-30T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV18', N'NCC08')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN14', CAST(N'2022-12-30T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV15', N'NCC01')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN15', CAST(N'2023-01-20T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV07', N'NCC07')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN16', CAST(N'2023-01-20T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV04', N'NCC02')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN17', CAST(N'2023-01-20T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV13', N'NCC07')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN18', CAST(N'2023-02-18T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV02', N'NCC08')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN19', CAST(N'2023-02-18T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV01', N'NCC05')
INSERT [dbo].[PhieuNhap] ([SoPN], [NgayNhap], [GhiChu], [PTTT], [MaNV], [MaNCC]) VALUES (N'PN20', CAST(N'2023-02-18T00:00:00.000' AS DateTime), NULL, N'Chuyển khoản', N'NV08', N'NCC02')
GO
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX01', CAST(N'2022-05-13T00:00:00.000' AS DateTime), NULL, N'NV01', N'CH05')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX011', CAST(N'2022-05-13T00:00:00.000' AS DateTime), N'iii', N'NV06', N'CH07')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX0111', CAST(N'2022-05-13T00:00:00.000' AS DateTime), N'oke', N'NV01', N'CH05')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX02', CAST(N'2022-05-20T00:00:00.000' AS DateTime), NULL, N'NV07', N'CH09')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX03', CAST(N'2022-06-10T00:00:00.000' AS DateTime), NULL, N'NV16', N'CH10')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX04', CAST(N'2022-06-28T00:00:00.000' AS DateTime), NULL, N'NV09', N'CH04')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX05', CAST(N'2022-07-15T00:00:00.000' AS DateTime), NULL, N'NV04', N'CH03')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX06', CAST(N'2022-07-31T00:00:00.000' AS DateTime), NULL, N'NV01', N'CH10')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX07', CAST(N'2022-08-15T00:00:00.000' AS DateTime), NULL, N'NV02', N'CH02')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX08', CAST(N'2022-08-31T00:00:00.000' AS DateTime), NULL, N'NV05', N'CH10')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX09', CAST(N'2022-09-15T00:00:00.000' AS DateTime), NULL, N'NV05', N'CH01')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX10', CAST(N'2022-09-30T00:00:00.000' AS DateTime), NULL, N'NV03', N'CH04')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX11', CAST(N'2022-10-16T00:00:00.000' AS DateTime), NULL, N'NV14', N'CH03')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX12', CAST(N'2022-10-31T00:00:00.000' AS DateTime), NULL, N'NV18', N'CH02')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX13', CAST(N'2022-11-14T00:00:00.000' AS DateTime), NULL, N'NV10', N'CH07')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX14', CAST(N'2022-11-28T00:00:00.000' AS DateTime), NULL, N'NV19', N'CH09')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX15', CAST(N'2022-12-18T00:00:00.000' AS DateTime), NULL, N'NV20', N'CH03')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX16', CAST(N'2022-12-31T00:00:00.000' AS DateTime), NULL, N'NV14', N'CH05')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX17', CAST(N'2023-01-19T00:00:00.000' AS DateTime), NULL, N'NV10', N'CH08')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX18', CAST(N'2023-01-31T00:00:00.000' AS DateTime), NULL, N'NV01', N'CH03')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX19', CAST(N'2022-02-14T00:00:00.000' AS DateTime), NULL, N'NV02', N'CH01')
INSERT [dbo].[PhieuXuat] ([SoPX], [NgayXuat], [GhiChu], [MaNV], [MaCH]) VALUES (N'PX20', CAST(N'2022-02-25T00:00:00.000' AS DateTime), NULL, N'NV03', N'CH03')
GO
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP01', N'Thịt heo xay', 150, N'Kg', N'LSP01', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP013', N'Thịt bo', 150, N'Kg', N'LSP01', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP02', N'Thịt bò xay', 150, N'Kg', N'LSP01', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP03', N'Thịt ức gà', 200, N'Kg', N'LSP01', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP031', N'Thịt canh ga', 200, N'Kg', N'LSP01', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP04', N'Rau mồng tơi', 100, N'Kg', N'LSP02', N'NCC02')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP05', N'Cải cay', 25, N'Kg', N'LSP02', N'NCC02')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP06', N'Cà rốt', 20, N'Kg', N'LSP02', N'NCC02')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP07', N'Khoai tây', 30, N'Kg', N'LSP02', N'NCC02')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP08', N'Muối', 100, N'Túi', N'LSP03', N'NCC03')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP09', N'Đường', 100, N'Túi', N'LSP03', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP10', N'Bột ngọt AJINOMOTO', 100, N'Túi', N'LSP03', N'NCC06')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP11', N'Hạt nêm KNOR', 100, N'Túi', N'LSP03', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP12', N'Dưa hấu', 50, N'Kg', N'LSP04', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP13', N'Táo', 50, N'Kg', N'LSP04', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP14', N'Chuối', 450, N'Kg', N'LSP04', N'NCC01')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP15', N'Kem chuối VINAMILK', 200, N'Hộp', N'LSP05', N'NCC05')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP16', N'Cá viên chiên', 100, N'Túi', N'LSP05', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP17', N'Mì hảo hảo', 500, N'Gói', N'LSP06', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP18', N'Xúc xích', 500, N'Cây', N'LSP06', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP19', N'Gạo', 200, N'Túi', N'LSP07', N'NCC07')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP20', N'Bột mì AJI-QUICK', 100, N'Túi', N'LSP07', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP21', N'Khô bò', 50, N'Hộp', N'LSP07', N'NCC08')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP22', N'Sữa VINAMILK', 450, N'Lốc', N'LSP08', N'NCC05')
INSERT [dbo].[SanPham] ([MaSP], [TenSP], [SLTon], [DonViTinh], [MaloaiSP], [MaNCC]) VALUES (N'SP23', N'Sữa TH TRUE MILK', 350, N'Lốc', N'LSP08', N'NCC04')
GO
INSERT [dbo].[TaiKhoan] ([TenDN], [MatKhau], [ChucVu], [MaNV]) VALUES (N'admin', N'123456789', N'Admin', N'NV02')
INSERT [dbo].[TaiKhoan] ([TenDN], [MatKhau], [ChucVu], [MaNV]) VALUES (N'nhanvien', N'123456789', N'Nhân Viên', N'NV01')
GO