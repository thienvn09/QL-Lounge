Use QLBONGDA
GO
-- A
/* câu 1 Cho biết NGAYTD, TENCLB1, TENCLB2, KETQUA các trận đấu diễn ra vào tháng 3 trên sân 
nhà mà không bị thủng lưới.  */
SELECT TD.NGAYTD ,CLB1.TENCLB , CLB2.TENCLB , TD.KETQUA
FROM TRANDAU as TD 
	join CAULACBO as CLB1 on CLB1.MACLB = TD.MACLB1
	join CAULACBO as CLB2 on CLB2.MACLB = TD.MACLB2
	join SANVD as S on S.MASAN = TD.MASAN
where MONTH(TD.NGAYTD) = 3 and TD.KETQUA like '%-0'
/* 2. Cho biết mã số, họ tên, ngày sinh của những cầu thủ có họ lót là “Công”. */
SELECT C.MACT,C.HOTEN,C.NGAYSINH
FROM CAUTHU as C
Where C.HOTEN Like N'% Công %'
-- 3. Cho biết mã số, họ tên, ngày sinh của những cầu thủ có họ không phải là họ “Nguyễn “. 
SELECT C.MACT,C.HOTEN,C.NGAYSINH
FROM CAUTHU as C
Where C.HOTEN NOT LIKE N'Nguyễn%'
--Câu 4 Cho biết mã huấn luyện viên, họ tên, ngày sinh, địa chỉ của những huấn luyện viên Việt Nam có tuổi nằm trong khoảng 35-40. 
SELECT H.MAHLV,H.TENHLV,H.NGAYSINH,H.DIACHI
From HUANLUYENVIEN as H
WHERE H.MAQG LIKE 'VN' AND (YEAR(GETDATE()) - YEAR(H.NGAYSINH)) BETWEEN 35 AND 40;
/*5. Cho biết tên câu lạc bộ có huấn luyện viên trưởng sinh vào ngày 20 tháng 8 năm 2019. */
SELECT CLB.TENCLB
FROM CAULACBO as CLB
	join HLV_CLB as HCLB on HCLB.MACLB = CLB.MACLB
	join HUANLUYENVIEN as HLV on HLV.MAHLV = HCLB.MAHLC
where HLV.NGAYSINH like '2019-8-20'
/* câu 6 Cho biết tên câu lạc bộ, tên tỉnh mà CLB đang đóng có số bàn thắng nhiều nhất tính đến 
hết vòng 3 năm 2009.*/
SELECT TOP 1 CLB.TENCLB ,T.TENTINH ,BXH.THANG
FROM CAULACBO as CLB
join TINH as T on T.MATINH = CLB.MATINH
join BANGXH as BXH on BXH.MACLB = CLB.MACLB
WHERE BXH.VONG = 3 AND BXH.NAM=2009
ORDER BY BXH.THANG DESC
-- B
/* 1. Cho biết tên huấn luyện viên đang nắm giữ một vị trí trong một câu lạc bộ mà chưa có số 
điện thoại. */
SELECT HLV.TENHLV
FROM HUANLUYENVIEN as HLV
	join HLV_CLB as H on H.MAHLC = HLV.MAHLV
	join CAULACBO as C on C.MACLB = H.MACLB
WHERE H.VAITRO LIKE N'%' AND HLV.DIENTHOAI IS NULL
/* Liệt kê các huấn luyện viên thuộc quốc gia Việt Nam chưa làm công tác huấn 
luyện tại bất kỳ một câu lạc bộ nào. */
SELECT HLV.TENHLV
FROM HUANLUYENVIEN as HLV
	join HLV_CLB as H on H.MAHLC = HLV.MAHLV
	join CAULACBO as C on C.MACLB = H.MACLB
