
  CREATE DATABASE CuoiKy_LanCuoi;
  Go
USE  CuoiKy_LanCuoi
GO
CREATE TABLE category(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	title NVARCHAR(100),
	content NVARCHAR(500),
	createAt DATETIME,
	updateAt DATETIME
)
GO

CREATE TABLE product(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	title NVARCHAR(100),
	content NVARCHAR(500),
	img NVARCHAR(200),
	price INT,
	rate FLOAT,
	createAt DATETIME,
	updateAt DATETIME,
	categoryId int,
	FOREIGN KEY (categoryId) REFERENCES category(id)
)
GO

CREATE TABLE customer(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	firstName NVARCHAR(100),
	lastName NVARCHAR(100),
	address NVARCHAR(500),
	phone NVARCHAR(15),
	email NVARCHAR(50),
	img NVARCHAR(200),
	registeredAt DATETIME,
	updateAt DATETIME,
	dateOfBirth DATE null,	
	password NVARCHAR(200),
	randomKey varchar (50) null,
	isActive BIT,
	role INT  --  0: user, 1: admin,
)
GO

CREATE TABLE  cart (
	id INT  NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	customerId INT,
	createAt DATETIME,
	productId INT,
	quantity INT,
	FOREIGN KEY (customerId) REFERENCES customer(id),
	FOREIGN KEY (productId) REFERENCES product(id)
)
GO

CREATE TABLE  payment (
	id INT  NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	customerId INT,
	firstName NVARCHAR(100),
	lastName NVARCHAR(100),
	phone NVARCHAR(15),
	email NVARCHAR(50),
	createAt DATETIME,
	total FLOAT,
	FOREIGN KEY (customerId) REFERENCES customer(id),
)
GO

CREATE TABLE paymentDetail (
	productId INT,
	paymentId INT,
	price INT,
	quantity INT,
	total FLOAT,
	createAt DATETIME,
	FOREIGN KEY (productId) REFERENCES product(id),
	FOREIGN KEY (paymentId) REFERENCES payment(id)
)
GO

CREATE TABLE menu(
	id INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	parentId INT NULL,
	title NVARCHAR(100),
	menuUrl NVARCHAR(100),
	menuIndex int,
	isVisible BIT DEFAULT 1, --1: DISPLAY || 0: HIDDEN
)
GO
CREATE TABLE paymentMethod (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- ID phương thức thanh toán
    methodName NVARCHAR(50) NOT NULL,          -- Tên phương thức (Credit Card, PayPal...)
    description NVARCHAR(255) NULL            -- Mô tả chi tiết nếu cần
)
GO
ALTER TABLE payment
ADD paymentMethodId INT NULL, -- ID của phương thức thanh toán
FOREIGN KEY (paymentMethodId) REFERENCES paymentMethod(id)
GO
SET IDENTITY_INSERT [dbo].[category] ON

-- Chỉ giữ lại ba danh mục
INSERT [dbo].[category] ([id], [title], [content], [createAt], [updateat]) VALUES (1, N'Trái cây nhập khẩu', N'Cung cấp các loại trái cây nhập khẩu tươi ngon, chất lượng cao.', CAST(N'2024-07-24T14:33:29.983' AS DateTime), CAST(N'2024-07-24T14:33:29.983' AS DateTime));
INSERT [dbo].[category] ([id], [title], [content], [createAt], [updateat]) VALUES (2, N'Trái cây nội địa', N'Chuyên cung cấp trái cây nội địa tươi ngon, đảm bảo vệ sinh an toàn thực phẩm.', CAST(N'2024-07-24T14:33:29.983' AS DateTime), CAST(N'2024-07-24T14:33:29.983' AS DateTime));
INSERT [dbo].[category] ([id], [title], [content], [createAt], [updateat]) VALUES (3, N'Hoa', N'Cung cấp các loại hoa tươi, phù hợp cho mọi dịp lễ.', CAST(N'2024-07-24T14:33:29.983' AS DateTime), CAST(N'2024-07-24T14:33:29.983' AS DateTime));

SET IDENTITY_INSERT [dbo].[category] OFF
GO

SET IDENTITY_INSERT [dbo].[product] ON

-- Chỉ giữ lại ba sản phẩm mỗi danh mục
-- Trái cây nhập khẩu
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (1, N'Táo Fuji', N'Táo Fuji nhập khẩu, giòn ngọt, chất lượng cao.', N'tao-fuji.png', 50000, 4.5, CAST(N'2024-07-24T14:46:55.457' AS DateTime), CAST(N'2024-07-24T15:54:27.633' AS DateTime), 1);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (2, N'Nho Mỹ', N'Nho Mỹ tươi ngon, giàu dinh dưỡng.', N'tao-fuji.png', 70000, 4.9, CAST(N'2024-07-24T15:11:53.750' AS DateTime), CAST(N'2024-07-24T15:11:53.750' AS DateTime), 1);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (3, N'Cam Nhập Khẩu', N'Cam nhập khẩu giàu vitamin C, tốt cho sức khỏe.', N'tao-fuji.png', 60000, 4.8, CAST(N'2024-07-24T15:10:13.337' AS DateTime), CAST(N'2024-07-24T15:10:13.337' AS DateTime), 1);

-- Trái cây nội địa
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (4, N'Chuối Laba', N'Chuối Laba tươi ngon, giàu dinh dưỡng.', N'tao-fuji.png', 30000, 4.7, CAST(N'2024-07-24T15:05:25.137' AS DateTime), CAST(N'2024-07-24T15:40:06.767' AS DateTime), 2);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (5, N'Dứa Queen', N'Dứa Queen nội địa tươi ngon, giàu dinh dưỡng.', N'tao-fuji.png', 35000, 4.4, CAST(N'2024-07-24T15:11:08.860' AS DateTime), CAST(N'2024-07-24T15:11:08.860' AS DateTime), 2);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (6, N'Xoài Cát Hòa Lộc', N'Xoài nội địa tươi ngon, hương vị đậm đà.', N'tao-fuji.png', 40000, 4.6, CAST(N'2024-07-24T15:11:53.750' AS DateTime), CAST(N'2024-07-24T15:11:53.750' AS DateTime), 2);

-- Hoa
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (7, N'Hoa Hồng Đỏ', N'Hoa hồng đỏ tươi, phù hợp làm quà tặng.', N'tao-fuji.png', 150000, 4.9, CAST(N'2024-07-24T15:13:08.833' AS DateTime), CAST(N'2024-07-24T15:13:08.833' AS DateTime), 3);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (8, N'Hoa Lan Hồ Điệp', N'Hoa lan hồ điệp trang nhã, phù hợp trang trí.', N'tao-fuji.png', 300000, 5.0, CAST(N'2024-07-24T15:14:08.833' AS DateTime), CAST(N'2024-07-24T15:14:08.833' AS DateTime), 3);
INSERT [dbo].[product] ([id], [title], [content], [img], [price], [rate], [createAt], [updateAt], [categoryId]) VALUES (9, N'Hoa Cẩm Chướng', N'Hoa cẩm chướng đa sắc màu, tươi lâu.', N'tao-fuji.png', 100000, 4.8, CAST(N'2024-07-24T15:15:08.833' AS DateTime), CAST(N'2024-07-24T15:15:08.833' AS DateTime), 3);

SET IDENTITY_INSERT [dbo].[product] OFF
GO

SET IDENTITY_INSERT [dbo].[customer] ON 

INSERT [dbo].[customer] ([id], [firstName], [lastName], [address], [phone], [email], [img], [registeredAt], [updateAt], [dateOfBirth], [password], [randomKey], [isActive], [role]) 
VALUES (1, N'Admin', N'Nguyen', N'Viet Nam', N'0385247684', N'admin@gmail.com', N'20240803173344avatar1.png', CAST(N'2024-08-03T17:33:44.340' AS DateTime), CAST(N'2024-08-03T17:33:44.340' AS DateTime), CAST(N'2001-01-16' AS Date), N'd8ef478326e2e94f8302726fe597d65e', N'LCiU^', 1, 1)
SET IDENTITY_INSERT [dbo].[customer] OFF
GO
---------------------- INSERT cart -----------------

---------------------- INSERT payment -----------------

---------------------- INSERT paymentDetail -----------------

---------------------- INSERT menu -----------------
SET IDENTITY_INSERT [dbo].[menu] ON

-- Các mục menu cấp cao
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (1, NULL, N'Trang chủ', N'/', 1, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (2, NULL, N'Cửa hàng', N'/Product', 2, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (3, NULL, N'Danh mục', NULL, 3, 1);

-- Các mục menu cấp con
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (4, 3, N'Trái cây nhập khẩu', N'/Product?idcategory=1', 4, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (5, 3, N'Trái cây nội địa', N'/Product?idcategory=2', 5, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (6, 3, N'Hoa', N'/Product?idcategory=3', 6, 1);

-- Các mục menu khác
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (9, 3, N'Phụ kiện', N'/Product?idcategory=6', 9, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (10, NULL, N'Liên hệ', N'/contact', 10, 1);
INSERT [dbo].[menu] ([id], [parentId], [title], [menuUrl], [menuIndex], [isVisible]) VALUES (11, NULL, N'Trang quản trị', N'/Admin/ProductAdmin', 11, 1);

SET IDENTITY_INSERT [dbo].[menu] OFF
GO
SET IDENTITY_INSERT [dbo].[category] ON 
DECLARE @PageIndex INT, @PageSize INT;
SET @PageIndex = 1;
SET @PageSize = 5;

SELECT * FROM (
    SELECT ROW_NUMBER() OVER(ORDER BY a.id DESC) AS RowNumber,
        a.id AS ProductId, a.title AS ProductTitle,  
        a.content AS ProductContent, a.img AS ProductImg, a.price AS ProductPrice,
        a.rate AS ProductRate, a.createAt AS ProductCreateAt, a.updateAt AS ProductUpdateAt, 
        b.id AS CategoryId, b.title AS CategoryTitle
    FROM product a 
    JOIN category b ON a.categoryId = b.Id
) TableResult
WHERE TableResult.RowNumber BETWEEN ( @PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize;

-- Nếu cần thêm mục menu khác