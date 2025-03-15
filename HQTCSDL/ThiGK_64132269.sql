CREATE DATABASE ThiGK_64132269;
GO
USE ThiGK_64132269
GO
CREATE TABLE LoaiTaiLieu(
	MaLoaiTaiLieu INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	TenLoaiSach NVARCHAR(100),
	GhiChu NVARCHAR(100),
)
GO
CREATE TABLE TaiLieu(
	MaTaiLieu INT NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	TenTaiLieu NVARCHAR(100),
	NgayXuatBan Date,
	AnhBIa NVARCHAR(200),
	MaLoaiTaiLieu INT,

	FOREIGN KEY (MaLoaiTaiLieu) REFERENCES LoaiTaiLieu(MaLoaiTaiLieu)
)

insert into LoaiTaiLieu(MaLoaiTaiLieu,TenLoaiSach,GhiChu)values(01,'Toan','sach1')
insert into LoaiTaiLieu(MaLoaiTaiLieu,TenLoaiSach,GhiChu)values(01,'Toan2','sach2')
insert into LoaiTaiLieu(MaLoaiTaiLieu,TenLoaiSach,GhiChu)values(01,'Toan3','sach3')
insert into LoaiTaiLieu(MaLoaiTaiLieu,TenLoaiSach,GhiChu)values(01,'Toan4','sach4')
insert into LoaiTaiLieu(MaLoaiTaiLieu,TenLoaiSach,GhiChu)values(01,'Toan5','sach5')

  