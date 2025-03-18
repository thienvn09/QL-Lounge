Use QLBONGDA
Go
/* câu 1 */
Select MACT,HOTEN,So,VITRI,NGAYSINH,DIACHI 
From CAUTHU
/* CÂU 2 */
SELECT * 
FROM CAUTHU 
WHERE So='7'AND VITRI=N'Tiền vệ'
/* câu 3 */
SELECT TENHLV ,NGAYSINH,DIACHI,DIENTHOAI
FROM HUANLUYENVIEN
/* CÂU 4 */
Select MACT,HOTEN,So,VITRI,NGAYSINH,DIACHI 
From CAUTHU,CAULACBO as b 
WHERE b.TENCLB = N'SHB Đà Nẵng'  
/* câu 5 */
Select * 
From CAUTHU as a , QUOCGIA as q , CAULACBO as c
where q.TENQG = N'Việt Nam' AND c.TENCLB = N'Becamex Bình Dương'
/* câu 6 Hiển thị thông tin tất cả các cầu thủ đang thi đấu trong câu lạc bộ có sân nhà là 
“Hoàng Anh Gia Lai”.  */

SELECT C.MACT, C.HOTEN,C.VITRI, C.NGAYSINH, C.DIACHI,  C.MACLB, C.MAQG, C.SO
FROM CAUTHU C
JOIN CAULACBO CLB ON C.MACLB = CLB.MACLB
JOIN SANVD S ON CLB.MASAN = S.MASAN
WHERE S.TENSAN = N'Hoàng Anh Gia Lai';


/* CÂU 7 Cho biết kết quả (MATRAN, NGAYTD, TENSAN, TENCLB1, TENCLB2, KETQUA) các 
trận đấu vòng 2 của mùa bóng năm 2009.  */

SELECT T.MATRAN, T.NGAYTD, S.TENSAN, CLB1.TENCLB AS TENCLB1, CLB2.TENCLB AS TENCLB2, T.KETQUA
FROM TRANDAU T
JOIN SANVD S ON T.MASAN = S.MASAN
JOIN CAULACBO CLB1 ON T.MACLB1 = CLB1.MACLB
JOIN CAULACBO CLB2 ON T.MACLB2 = CLB2.MACLB
WHERE T.NAM = 2009 AND T.VONG = 2;
  
/* CÂU 8 Cho biết mã huấn luyện viên, tên, ngày sinh, địa chỉ, vai trò và tên CLB 
đang làm việc của các huấn luyện viên có quốc tịch “ViệtNam”. */
SELECT HLV.MAHLV, HLV.TENHLV, HLV.NGAYSINH, HLV.DIACHI, HLVCLB.VAITRO, CLB.TENCLB
FROM HUANLUYENVIEN HLV
JOIN QUOCGIA QG ON HLV.MAQG = QG.MAQG
JOIN HLV_CLB HLVCLB ON HLV.MAHLV = HLVCLB.MAHLC
JOIN CAULACBO CLB ON HLVCLB.MACLB = CLB.MACLB
WHERE QG.TENQG = N'Việt Nam';

/* CÂU 9 Lấy tên 3 câu lạc bộ có điểm cao nhất sau vòng 3 năm 2009. */
WITH BXH_RANKED AS (
    SELECT CLB.TENCLB, BXH.DIEM,
           RANK() OVER (ORDER BY BXH.DIEM DESC) AS RANK_NUM
    FROM BANGXH AS BXH
    JOIN CAULACBO AS CLB ON BXH.MACLB = CLB.MACLB
    WHERE BXH.VONG = 3 AND BXH.NAM = 2009
)
SELECT TENCLB, DIEM
FROM BXH_RANKED
WHERE RANK_NUM <= 3;

/* Cau 10  Cho biết mã huấn luyện viên, họ tên, ngày sinh, địa chỉ, vai trò và tên CLB đang làm việc 
mà câu lạc bộ đó đóng ở tỉnh Binh Dương. */
SELECT HLV.MAHLV , HLV.TENHLV ,HLV.NGAYSINH ,HLV.DIACHI,HLVCLB.VAITRO,CLB.TENCLB
FROM HUANLUYENVIEN AS HLV
	JOIN HLV_CLB AS HLVCLB ON HLV.MAHLV = HLVCLB.MAHLC
	JOIN CAULACBO AS CLB ON CLB.MACLB = HLVCLB.MACLB
	JOIN TINH AS T ON T.MATINH = CLB.MATINH
WHERE T.TENTINH LIKE N'Bình Dương'

-- CAU 1
SELECT clb.TENCLB, COUNT(c.MACT) as soluong 
FROM CAUTHU as c
	join CAULACBO as clb on clb.MACLB = c.MACLB
group by clb.TENCLB
-- cau 2
--  Thống kê số lượng cầu thủ nước ngoài (có quốc tịch khác Việt Nam) của mỗi câu lạc bộ
Select clb.MACLB,clb.TENCLB, COUNT( c.MACT) as SoLuongNuocNgoai
FROM CAUTHU as c
	join QuocGia as qg on qg.MAQG = c.MAQG
	join CAULACBO as clb on clb.MACLB = c.MACLB
where qg.TENQG != N'Việt Nam'
GROUP BY clb.MACLB, clb.TENCLB
-- cau 3
--Cho biết mã câu lạc bộ, tên câu lạc bộ, tên sân vận động, địa chỉ và số lượng cầu 
--thủ nước ngoài (có quốc tịch khác Việt Nam) tương ứng của các câu lạc bộ có nhiều 
--hơn 2 cầu thủ nước ngoài. 
SELECT CLB.MACLB,CLB.TENCLB, S.TENSAN, S.Diachi ,COUNT(*) as SoLuongCauthu
FROM CAULACBO as CLB 
	join SANVD as S on S.MASAN = CLB.MASAN
	join CAUTHU as C on C.MACLB = CLB.MACLB
	join Quocgia as qg on qg.MAQG = C.MAQG
where  qg.TENQG != N'Việt Nam' 
GROUP BY CLB.MACLB , CLB.TENCLB , s.TENSAN, s.DiaChi 
Having COUNT(*) > 2
-- câu 4
/*Cho biết tên tỉnh, số lượng cầu thủ đang thi đấu ở vị trí tiền đạo trong các câu lạc 
bộ thuộc địa bàn tỉnh đó quản lý.  */
SELECT T.TENTINH , COUNT(*) as SoLuongTienDao
FROM TINH as T
	join CAULACBO as clb on clb.MATINH = T.MATINH
	join CAUTHU	  as C   on  C.MACLB = clb.MACLB
where C.VITRI like N'Tiền đạo' 
GROUP by t.TENTINH ,C.MACT
/*.Câu 5 Cho biết tên câu lạc bộ, tên tỉnh mà CLB đang đóng nằm ở vị trí cao nhất của bảng 
xếp hạng vòng 3, năm 2009.  */
Select clb.TENCLB,T.TENTINH
FROM CAULACBO as clb
	join TINH as T on T.MATINH = clb.MATINH
	join BANGXH as B on B.MACLB =clb.MACLB
where B.HANG = '1' and B.VONG = '3' and B.NAM ='2009'
GROUP by clb.TENCLB , T.TENTINH
