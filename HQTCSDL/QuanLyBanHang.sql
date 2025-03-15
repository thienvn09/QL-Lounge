Use QuanLyBanHang;
Go
SELECT * 
FROM NhanVien WHERE(Usename and Matkhau)

DECLARE @Username VARCHAR(50), @Password VARCHAR(50);
SET @Username = 'NguyenThiKhanhLinh@gmail.com';  -- Thay bằng email hoặc số điện thoại thực tế
SET @Password = 'NhanVienBaoCaoTaiChinh';             -- Thay bằng mật khẩu thực tế


-- Kiểm tra quyền Admin (IDPer = 1)
IF EXISTS (SELECT * FROM NhanVien WHERE (Username = @Username OR Sdt = @Username OR Email = @Username) AND MatKhau = @Password AND IDPer = 1)
    SELECT 1 AS code  -- Admin

-- Kiểm tra quyền Nhân viên bán hàng (IDPer = 2)
ELSE IF EXISTS (SELECT * FROM NhanVien WHERE (Username = @Username OR Sdt = @Username OR Email = @Username) AND MatKhau = @Password AND IDPer = 2)
    SELECT 2 AS code  -- Nhân viên bán hàng

-- Kiểm tra quyền Nhân viên trực kho (IDPer = 3)
ELSE IF EXISTS (SELECT * FROM NhanVien WHERE (Username = @Username OR Sdt = @Username OR Email = @Username) AND MatKhau = @Password AND IDPer = 3)
    SELECT 3 AS code  -- Nhân viên trực kho

-- Kiểm tra quyền Khách hàng (IDPer = 4)
ELSE IF EXISTS (SELECT * FROM NhanVien WHERE (Username = @Username OR Sdt = @Username OR Email = @Username) AND MatKhau = @Password AND IDPer = 4)
    SELECT 4 AS code  -- Khách hàng

-- Kiểm tra nếu mật khẩu sai
ELSE IF EXISTS (SELECT * FROM NhanVien WHERE (Username = @Username OR Sdt = @Username OR Email = @Username) AND MatKhau != @Password)
    SELECT 5 AS code  -- Sai mật khẩu

-- Tài khoản không tồn tại
ELSE 
    SELECT 6 AS code  -- Tài khoản không tồn tại
