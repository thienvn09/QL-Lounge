CREATE DATABASE ShopManagement;
GO
-- Sử dụng database ShopManagement
USE ShopManagement;
GO

-- Tạo bảng Cửa Hàng
CREATE TABLE CuaHang (
    MaCH NVARCHAR(10) PRIMARY KEY,      -- Mã cửa hàng
    TenCH NVARCHAR(100),                -- Tên cửa hàng
    CHTruong NVARCHAR(100)             -- Cửa hàng trưởng
);
GO
-- Tạo bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV NVARCHAR(10) PRIMARY KEY,      -- Mã nhân viên
    HoNV NVARCHAR(100),                 -- Họ nhân viên
    TenNV NVARCHAR(100),                -- Tên nhân viên
    GioiTinh NVARCHAR(20),              -- Giới tính
    NgaySinh DATE,                      -- Ngày sinh
    DiaChi NVARCHAR(100),               -- Địa chỉ
    DienThoai NVARCHAR(20),             -- Điện thoại
    NoiSinh NVARCHAR(100),              -- Nơi sinh
    NgayVaoLam DATE,                    -- Ngày vào làm
    Email NVARCHAR(100),                -- Email
    MaCH NVARCHAR(10),                  -- Mã cửa hàng (khóa ngoại)
    FOREIGN KEY (MaCH) REFERENCES CuaHang(MaCH)
);
GO
-- Tạo bảng Tài Khoản
CREATE TABLE TaiKhoan (
    TenDN NVARCHAR(20) PRIMARY KEY,     -- Tên đăng nhập
    MatKhau NVARCHAR(100),              -- Mật khẩu
    ChucVu NVARCHAR(100),               -- Chức vụ
    MaNV NVARCHAR(10),                  -- Mã nhân viên (khóa ngoại)
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO
-- Tạo bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    MaNCC NVARCHAR(10) PRIMARY KEY,     -- Mã nhà cung cấp
    TenNCC NVARCHAR(100),               -- Tên nhà cung cấp
    DiaChi NVARCHAR(100),               -- Địa chỉ
    DienThoai NVARCHAR(20),             -- Điện thoại
    Email NVARCHAR(100)                 -- Email
);
GO
-- Tạo bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH NVARCHAR(10) PRIMARY KEY,      -- Mã khách hàng
    TenKH NVARCHAR(100),                -- Tên khách hàng
    DiaChi NVARCHAR(100),               -- Địa chỉ
    NgaySinh DATE,                      -- Ngày sinh
    DienThoai NVARCHAR(20),             -- Điện thoại
    ThanhVien NVARCHAR(30)              -- Thành viên
);
GO
-- Tạo bảng Loại Sản Phẩm
CREATE TABLE LoaiSanPham (
    MaloaiSP NVARCHAR(10) PRIMARY KEY,  -- Mã loại sản phẩm
    TenloaiSP NVARCHAR(100),            -- Tên loại sản phẩm
    GhiChu NVARCHAR(100)                -- Ghi chú
);
GO
-- Tạo bảng Sản Phẩm
CREATE TABLE SanPham (
    MaSP NVARCHAR(10) PRIMARY KEY,      -- Mã sản phẩm
    TenSP NVARCHAR(100),                -- Tên sản phẩm
    SLTon INT,                          -- Số lượng tồn
    DonViTinh NVARCHAR(10),             -- Đơn vị tính
    MaloaiSP NVARCHAR(10),              -- Mã loại sản phẩm (khóa ngoại)
    MaNCC NVARCHAR(10),                 -- Mã nhà cung cấp (khóa ngoại)
    FOREIGN KEY (MaloaiSP) REFERENCES LoaiSanPham(MaloaiSP),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO
-- Tạo bảng Phiếu Nhập
CREATE TABLE PhieuNhap (
    SoPN NVARCHAR(10) PRIMARY KEY,      -- Số phiếu nhập
    NgayNhap DATE,                      -- Ngày nhập
    PTTT NVARCHAR(100),                 -- Phương thức thanh toán
    GhiChu NVARCHAR(100),               -- Ghi chú
    MaNV NVARCHAR(10),                  -- Mã nhân viên (khóa ngoại)
    MaNCC NVARCHAR(10),                 -- Mã nhà cung cấp (khóa ngoại)
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
);
GO
-- Tạo bảng Phiếu Xuất
CREATE TABLE PhieuXuat (
    SoPX NVARCHAR(10) PRIMARY KEY,      -- Số phiếu xuất
    NgayXuat DATE,                      -- Ngày xuất
    GhiChu NVARCHAR(100),               -- Ghi chú
    MaNV NVARCHAR(10),                  -- Mã nhân viên (khóa ngoại)
    MaCH NVARCHAR(10),                  -- Mã cửa hàng (khóa ngoại)
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaCH) REFERENCES CuaHang(MaCH)
);
GO
-- Tạo bảng Hóa Đơn
CREATE TABLE HoaDon (
    MaHD NVARCHAR(10) PRIMARY KEY,      -- Mã hóa đơn
    NgayDH DATE,                       
    PTTT NVARCHAR(100),                 
    MaNV NVARCHAR(10),                  -- Mã nhân viên (khóa ngoại)
    MaKH NVARCHAR(10),                  -- Mã khách hàng (khóa ngoại)
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO
-- Tạo bảng Chi Tiết Hóa Đơn
CREATE TABLE CTHoaDon (
    MaHD NVARCHAR(10),                  -- Mã hóa đơn (khóa ngoại)
    MaSP NVARCHAR(10),                  -- Mã sản phẩm (khóa ngoại)
    SoLuongDat INT,                     
    DGBan INT,                          
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO
INSERT INTO CuaHang (MaCH, TenCH, CHTruong) VALUES
('CH001', 'Cửa Hàng A', 'Nguyễn Văn A'),
('CH002', 'Cửa Hàng B', 'Trần Thị B'),
('CH003', 'Cửa Hàng C', 'Lê Văn C'),
('CH004', 'Cửa Hàng D', 'Phạm Thị D'),
('CH005', 'Cửa Hàng E', 'Bùi Văn E'),
('CH006', 'Cửa Hàng F', 'Vũ Thị F'),
('CH007', 'Cửa Hàng G', 'Ngô Văn G'),
('CH008', 'Cửa Hàng H', 'Dương Thị H'),
('CH009', 'Cửa Hàng I', 'Hoàng Văn I'),
('CH010', 'Cửa Hàng J', 'Lê Thị J');
GO
-- Thêm dữ liệu vào bảng Nhân Viên
INSERT INTO NhanVien (MaNV, HoNV, TenNV, GioiTinh, NgaySinh, DiaChi, DienThoai, NoiSinh, NgayVaoLam, Email, MaCH) VALUES
('NV001', 'Nguyễn', 'Văn A', 'Nam', '1990-01-01', 'Hà Nội', '0912345678', 'Hà Nội', '2020-01-01', 'nva@example.com', 'CH001'),
('NV002', 'Trần', 'Thị B', 'Nữ', '1992-02-02', 'TP Hồ Chí Minh', '0923456789', 'TP Hồ Chí Minh', '2021-02-02', 'tvb@example.com', 'CH002'),
('NV003', 'Lê', 'Văn C', 'Nam', '1988-03-03', 'Đà Nẵng', '0934567890', 'Đà Nẵng', '2022-03-03', 'lvc@example.com', 'CH003'),
('NV004', 'Phạm', 'Thị D', 'Nữ', '1993-04-04', 'Cần Thơ', '0945678901', 'Cần Thơ', '2023-04-04', 'ptd@example.com', 'CH004'),
('NV005', 'Bùi', 'Văn E', 'Nam', '1995-05-05', 'Hải Phòng', '0956789012', 'Hải Phòng', '2020-05-05', 'bve@example.com', 'CH005'),
('NV006', 'Vũ', 'Thị F', 'Nữ', '1996-06-06', 'Vũng Tàu', '0967890123', 'Vũng Tàu', '2021-06-06', 'vtf@example.com', 'CH006'),
('NV007', 'Ngô', 'Văn G', 'Nam', '1997-07-07', 'Hà Nội', '0978901234', 'Hà Nội', '2022-07-07', 'ngv@example.com', 'CH007'),
('NV008', 'Dương', 'Thị H', 'Nữ', '1998-08-08', 'Bình Dương', '0989012345', 'Bình Dương', '2023-08-08', 'dth@example.com', 'CH008'),
('NV009', 'Hoàng', 'Văn I', 'Nam', '1999-09-09', 'Vĩnh Long', '0990123456', 'Vĩnh Long', '2020-09-09', 'hvi@example.com', 'CH009'),
('NV010', 'Lê', 'Thị J', 'Nữ', '2000-10-10', 'Quảng Ninh', '0901234567', 'Quảng Ninh', '2021-10-10', 'ltj@example.com', 'CH010');
GO
-- Thêm dữ liệu vào bảng Tài Khoản
INSERT INTO TaiKhoan (TenDN, MatKhau, ChucVu, MaNV) VALUES
('Thien', '1', 'Quản lý', 'NV001'),
('Luong', '2', 'Nhân viên', 'NV002');
GO
-- Thêm dữ liệu vào bảng Nhà Cung Cấp
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, DienThoai, Email) VALUES
('NCC001', 'Công Ty A', 'Hà Nội', '0102345678', 'contact@companya.com'),
('NCC002', 'Công Ty B', 'TP Hồ Chí Minh', '0103456789', 'contact@companyb.com'),
('NCC003', 'Công Ty C', 'Đà Nẵng', '0104567890', 'contact@companyc.com'),
('NCC004', 'Công Ty D', 'Cần Thơ', '0105678901', 'contact@companyd.com'),
('NCC005', 'Công Ty E', 'Hải Phòng', '0106789012', 'contact@companye.com'),
('NCC006', 'Công Ty F', 'Vũng Tàu', '0107890123', 'contact@companyf.com'),
('NCC007', 'Công Ty G', 'Hà Nội', '0108901234', 'contact@companyg.com'),
('NCC008', 'Công Ty H', 'Bình Dương', '0109012345', 'contact@companyh.com'),
('NCC009', 'Công Ty I', 'Vĩnh Long', '0109123456', 'contact@companyi.com'),
('NCC010', 'Công Ty J', 'Quảng Ninh', '0109234567', 'contact@companyj.com');
GO
-- Thêm dữ liệu vào bảng Khách Hàng
INSERT INTO KhachHang (MaKH, TenKH, DiaChi, NgaySinh, DienThoai, ThanhVien) VALUES
('KH001', 'Nguyễn Văn A', 'Hà Nội', '1980-01-01', '0901234567', 'VIP'),
('KH002', 'Trần Thị B', 'TP Hồ Chí Minh', '1990-02-02', '0902345678', 'Thường'),
('KH003', 'Lê Văn C', 'Đà Nẵng', '1985-03-03', '0903456789', 'VIP'),
('KH004', 'Phạm Thị D', 'Cần Thơ', '1995-04-04', '0904567890', 'Thường'),
('KH005', 'Bùi Văn E', 'Hải Phòng', '2000-05-05', '0905678901', 'VIP'),
('KH006', 'Vũ Thị F', 'Vũng Tàu', '1996-06-06', '0906789012', 'Thường'),
('KH007', 'Ngô Văn G', 'Hà Nội', '1998-07-07', '0907890123', 'VIP'),
('KH008', 'Dương Thị H', 'Bình Dương', '2002-08-08', '0908901234', 'Thường'),
('KH009', 'Hoàng Văn I', 'Vĩnh Long', '1997-09-09', '0909012345', 'VIP'),
('KH010', 'Lê Thị J', 'Quảng Ninh', '2003-10-10', '0909123456', 'Thường');
GO
-- Thêm dữ liệu vào bảng Loại Sản Phẩm
INSERT INTO LoaiSanPham (MaloaiSP, TenloaiSP, GhiChu) VALUES
('LSP001', 'Điện Thoại', 'Sản phẩm di động'),
('LSP002', 'Laptop', 'Máy tính xách tay'),
('LSP003', 'Máy Tính Bảng', 'Thiết bị di động cỡ nhỏ'),
('LSP004', 'Máy Ảnh', 'Máy ảnh kỹ thuật số'),
('LSP005', 'Máy Tính Để Bàn', 'Máy tính bàn truyền thống'),
('LSP006', 'Phụ Kiện', 'Phụ kiện điện tử'),
('LSP007', 'Tiện Ích Gia Đình', 'Thiết bị gia dụng'),
('LSP008', 'Thực Phẩm', 'Sản phẩm ăn uống'),
('LSP009', 'Thời Trang', 'Trang phục thời trang'),
('LSP010', 'Giày Dép', 'Sản phẩm giày dép');
GO
-- Thêm dữ liệu vào bảng Sản Phẩm
INSERT INTO SanPham (MaSP, TenSP, SLTon, DonViTinh, MaloaiSP, MaNCC) VALUES
('SP001', 'Điện Thoại A', 100, 'Cái', 'LSP001', 'NCC001'),
('SP002', 'Laptop B', 50, 'Cái', 'LSP002', 'NCC002'),
('SP003', 'Máy Tính Bảng C', 200, 'Cái', 'LSP003', 'NCC003'),
('SP004', 'Máy Ảnh D', 70, 'Cái', 'LSP004', 'NCC004'),
('SP005', 'Máy Tính Để Bàn E', 30, 'Cái', 'LSP005', 'NCC005'),
('SP006', 'Phụ Kiện F', 150, 'Cái', 'LSP006', 'NCC006'),
('SP007', 'Tiện Ích Gia Đình G', 120, 'Cái', 'LSP007', 'NCC007'),
('SP008', 'Thực Phẩm H', 300, 'Kg', 'LSP008', 'NCC008'),
('SP009', 'Thời Trang I', 50, 'Cái', 'LSP009', 'NCC009'),
('SP010', 'Giày Dép J', 80, 'Cái', 'LSP010', 'NCC010');
GO
-- Thêm dữ liệu vào bảng Phiếu Nhập
INSERT INTO PhieuNhap (SoPN, NgayNhap, PTTT, GhiChu, MaNV, MaNCC) VALUES
('PN001', '2024-11-01', 'Chuyển khoản', 'Nhập khẩu điện thoại', 'NV001', 'NCC001'),
('PN002', '2024-11-02', 'Tiền mặt', 'Nhập khẩu laptop', 'NV002', 'NCC002'),
('PN003', '2024-11-03', 'Chuyển khoản', 'Nhập khẩu máy tính bảng', 'NV003', 'NCC003'),
('PN004', '2024-11-04', 'Tiền mặt', 'Nhập khẩu máy ảnh', 'NV004', 'NCC004'),
('PN005', '2024-11-05', 'Chuyển khoản', 'Nhập khẩu máy tính bàn', 'NV005', 'NCC005'),
('PN006', '2024-11-06', 'Tiền mặt', 'Nhập khẩu phụ kiện', 'NV006', 'NCC006'),
('PN007', '2024-11-07', 'Chuyển khoản', 'Nhập khẩu gia dụng', 'NV007', 'NCC007'),
('PN008', '2024-11-08', 'Tiền mặt', 'Nhập khẩu thực phẩm', 'NV008', 'NCC008'),
('PN009', '2024-11-09', 'Chuyển khoản', 'Nhập khẩu thời trang', 'NV009', 'NCC009'),
('PN010', '2024-11-10', 'Tiền mặt', 'Nhập khẩu giày dép', 'NV010', 'NCC010');
GO
-- Thêm dữ liệu vào bảng Phiếu Xuất
INSERT INTO PhieuXuat (SoPX, NgayXuat, GhiChu, MaNV, MaCH) VALUES
('PX001', '2024-11-01', 'Xuất hàng cho cửa hàng A', 'NV001', 'CH001'),
('PX002', '2024-11-02', 'Xuất hàng cho cửa hàng B', 'NV002', 'CH002'),
('PX003', '2024-11-03', 'Xuất hàng cho cửa hàng C', 'NV003', 'CH003'),
('PX004', '2024-11-04', 'Xuất hàng cho cửa hàng D', 'NV004', 'CH004'),
('PX005', '2024-11-05', 'Xuất hàng cho cửa hàng E', 'NV005', 'CH005'),
('PX006', '2024-11-06', 'Xuất hàng cho cửa hàng F', 'NV006', 'CH006'),
('PX007', '2024-11-07', 'Xuất hàng cho cửa hàng G', 'NV007', 'CH007'),
('PX008', '2024-11-08', 'Xuất hàng cho cửa hàng H', 'NV008', 'CH008'),
('PX009', '2024-11-09', 'Xuất hàng cho cửa hàng I', 'NV009', 'CH009'),
('PX010', '2024-11-10', 'Xuất hàng cho cửa hàng J', 'NV010', 'CH010');
GO
-- Thêm dữ liệu vào bảng Hóa Đơn
INSERT INTO HoaDon (MaHD, NgayDH, PTTT, MaNV, MaKH) VALUES
('HD001', '2024-11-01', 'Chuyển khoản', 'NV001', 'KH001'),
('HD002', '2024-11-02', 'Tiền mặt', 'NV002', 'KH002'),
('HD003', '2024-11-03', 'Chuyển khoản', 'NV003', 'KH003'),
('HD004', '2024-11-04', 'Tiền mặt', 'NV004', 'KH004'),
('HD005', '2024-11-05', 'Chuyển khoản', 'NV005', 'KH005'),
('HD006', '2024-11-06', 'Tiền mặt', 'NV006', 'KH006'),
('HD007', '2024-11-07', 'Chuyển khoản', 'NV007', 'KH007'),
('HD008', '2024-11-08', 'Tiền mặt', 'NV008', 'KH008'),
('HD009', '2024-11-09', 'Chuyển khoản', 'NV009', 'KH009'),
('HD010', '2024-11-10', 'Tiền mặt', 'NV010', 'KH010');
GO
-- Thêm dữ liệu vào bảng Chi Tiết Hóa Đơn
INSERT INTO CTHoaDon (MaHD, MaSP, SoLuongDat, DGBan) VALUES
('HD001', 'SP001', 10, 5000000),
('HD002', 'SP002', 5, 15000000),
('HD003', 'SP003', 20, 4000000),
('HD004', 'SP004', 3, 8000000),
('HD005', 'SP005', 2, 12000000),
('HD006', 'SP006', 15, 200000),
('HD007', 'SP007', 10, 300000),
('HD008', 'SP008', 50, 100000),
('HD009', 'SP009', 30, 200000),
('HD010', 'SP010', 25, 700000);
GO





