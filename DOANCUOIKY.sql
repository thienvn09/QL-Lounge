-- Tạo cơ sở dữ liệu
CREATE DATABASE [DOANCUOIKY]
GO

ALTER DATABASE [DOANCUOIKY] SET COMPATIBILITY_LEVEL = 160
GO

USE [DOANCUOIKY]
GO

-- Tạo bảng danh mục (danh_muc)
CREATE TABLE danh_muc (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    ten NVARCHAR(100),  -- Tên danh mục
    mo_ta NVARCHAR(500),  -- Mô tả chi tiết về danh mục
    ngay_tao DATETIME,  -- Ngày tạo danh mục
    ngay_cap_nhat DATETIME  -- Ngày cập nhật danh mục
)
GO

-- Tạo bảng sản phẩm (san_pham)
CREATE TABLE san_pham (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    ten NVARCHAR(100),  -- Tên sản phẩm
    mo_ta NVARCHAR(500),  -- Mô tả chi tiết về sản phẩm
    hinh_anh NVARCHAR(200),  -- Hình ảnh sản phẩm
    gia INT,  -- Giá sản phẩm
    danh_gia FLOAT,  -- Đánh giá sản phẩm
    ngay_tao DATETIME,  -- Ngày tạo sản phẩm
    ngay_cap_nhat DATETIME,  -- Ngày cập nhật sản phẩm
    id_danh_muc INT,  -- Khóa ngoại liên kết với bảng danh mục
    FOREIGN KEY (id_danh_muc) REFERENCES danh_muc(id)  -- Ràng buộc khóa ngoại
)
GO

-- Tạo bảng khách hàng (khach_hang)
CREATE TABLE khach_hang (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    ho_ten NVARCHAR(100),  -- Họ và tên khách hàng
    dia_chi NVARCHAR(500),  -- Địa chỉ khách hàng
    so_dien_thoai NVARCHAR(15),  -- Số điện thoại khách hàng
    email NVARCHAR(50),  -- Email khách hàng
    hinh_anh NVARCHAR(200),  -- Hình ảnh khách hàng
    ngay_dang_ky DATETIME,  -- Ngày đăng ký khách hàng
    ngay_cap_nhat DATETIME,  -- Ngày cập nhật thông tin khách hàng
    ngay_sinh DATE NULL,  -- Ngày sinh khách hàng
    mat_khau NVARCHAR(200),  -- Mật khẩu khách hàng
    khoa_ngoai VARCHAR(50) NULL,  -- Khóa ngẫu nhiên (nếu có)
    trang_thai BIT,  -- Trạng thái kích hoạt tài khoản (1: kích hoạt, 0: khóa)
    vai_tro INT  -- Vai trò (0: người dùng, 1: quản trị viên)
)
GO

-- Tạo bảng giỏ hàng (gio_hang)
CREATE TABLE gio_hang (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    id_khach_hang INT,  -- Khóa ngoại liên kết với khách hàng
    ngay_tao DATETIME,  -- Ngày tạo giỏ hàng
    id_san_pham INT,  -- Khóa ngoại liên kết với sản phẩm
    so_luong INT,  -- Số lượng sản phẩm trong giỏ
    FOREIGN KEY (id_khach_hang) REFERENCES khach_hang(id),  -- Ràng buộc khóa ngoại với khách hàng
    FOREIGN KEY (id_san_pham) REFERENCES san_pham(id)  -- Ràng buộc khóa ngoại với sản phẩm
)
GO

-- Tạo bảng thanh toán (thanh_toan)
CREATE TABLE thanh_toan (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    id_khach_hang INT,  -- Khóa ngoại liên kết với khách hàng
    ho_ten NVARCHAR(100),  -- Họ và tên khách hàng
    so_dien_thoai NVARCHAR(15),  -- Số điện thoại khách hàng
    email NVARCHAR(50),  -- Email khách hàng
    ngay_tao DATETIME,  -- Ngày thanh toán
    tong_tien FLOAT,  -- Tổng tiền thanh toán
    FOREIGN KEY (id_khach_hang) REFERENCES khach_hang(id)  -- Ràng buộc khóa ngoại với khách hàng
)
GO

-- Tạo bảng chi tiết thanh toán (chi_tiet_thanh_toan)
CREATE TABLE chi_tiet_thanh_toan (
    id_san_pham INT,  -- Khóa ngoại liên kết với sản phẩm
    id_thanh_toan INT,  -- Khóa ngoại liên kết với thanh toán
    gia INT,  -- Giá sản phẩm tại thời điểm thanh toán
    so_luong INT,  -- Số lượng sản phẩm trong thanh toán
    tong_tien FLOAT,  -- Tổng tiền cho sản phẩm này
    ngay_tao DATETIME,  -- Ngày tạo chi tiết thanh toán
    FOREIGN KEY (id_san_pham) REFERENCES san_pham(id),  -- Ràng buộc khóa ngoại với sản phẩm
    FOREIGN KEY (id_thanh_toan) REFERENCES thanh_toan(id)  -- Ràng buộc khóa ngoại với thanh toán
)
GO

-- Tạo bảng menu (menu)
CREATE TABLE menu (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,  -- Khóa chính, tự động tăng
    id_menu_cha INT NULL,  -- Khóa ngoại liên kết với menu cha (nếu có)
    ten NVARCHAR(100),  -- Tên menu
    url_menu NVARCHAR(100),  -- Đường dẫn URL của menu
    vi_tri_menu INT,  -- Vị trí của menu (để sắp xếp)
    hien_thi BIT DEFAULT 1  -- Hiển thị (1: có, 0: không)
)
GO

-- Tạo bảng nhân viên (NhanVien)
CREATE TABLE NhanVien (
    MaNV INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TenNV NVARCHAR(100),
    NgaySinh DATETIME NULL,
    ChucVu NVARCHAR(50),
    NgayVaoLam DATETIME NULL
)
GO

-- Tạo bảng hóa đơn (HoaDon)
CREATE TABLE HoaDon (
    MaHD INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    MaKH INT,
    NgayDH DATETIME,
    TongTien FLOAT,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
)
GO

-- Tạo bảng chi tiết hóa đơn (CTHoaDon)
CREATE TABLE CTHoaDon (
    MaHD INT,
    MaSP INT,
    SoLuong INT,
    DGBan FLOAT,
    PRIMARY KEY (MaHD, MaSP),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaSP) REFERENCES gio_hang(id)
)
GO

-- Tạo bảng nhà cung cấp (NhaCungCap)
CREATE TABLE NhaCungCap (
    MaNCC INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TenNCC NVARCHAR(100),
    DiaChi NVARCHAR(500),
    SoDienThoai NVARCHAR(15)
)
GO

-- Tạo bảng phiếu nhập (PhieuNhap)
CREATE TABLE PhieuNhap (
    SoPN INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    MaNCC INT,
    NgayNhap DATETIME,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
)
GO

-- Tạo bảng chi tiết phiếu nhập (CTPhieuNhap)
CREATE TABLE CTPHieuNhap (
    SoPN INT,
    MaSP INT,
    SoLuong INT,
    DonGia FLOAT,
    PRIMARY KEY (SoPN, MaSP),
    FOREIGN KEY (SoPN) REFERENCES PhieuNhap(SoPN),
    FOREIGN KEY (MaSP) REFERENCES gio_hang(id)
)
GO

-- Tạo bảng phiếu xuất (PhieuXuat) -- Không cần bảng CuaHang
CREATE TABLE PhieuXuat (
    SoPX INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NgayXuat DATETIME
)
GO

-- Tạo bảng chi tiết phiếu xuất (CTPhieuXuat) -- Cập nhật không cần tham chiếu CuaHang
CREATE TABLE CTPHieuXuat (
    SoPX INT,
    MaSP INT,
    SoLuong INT,
    DonGia FLOAT,
    PRIMARY KEY (SoPX, MaSP),
    FOREIGN KEY (SoPX) REFERENCES PhieuXuat(SoPX),
    FOREIGN KEY (MaSP) REFERENCES gio_hang(id)
)
GO

-- Tạo bảng loại sản phẩm (LoaiSanPham)
CREATE TABLE LoaiSanPham (
    MaloaiSP INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TenLoaiSP NVARCHAR(100)
)
GO

-- Tạo bảng sản phẩm (SanPham) -- Thêm loại sản phẩm
ALTER TABLE san_pham ADD MaloaiSP INT;
ALTER TABLE san_pham ADD FOREIGN KEY (MaloaiSP) REFERENCES LoaiSanPham(MaloaiSP);
GO
