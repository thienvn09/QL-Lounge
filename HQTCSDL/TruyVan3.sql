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
SELECT HL.MAHLV, HL.TENHLV
FROM HUANLUYENVIEN HL
JOIN QUOCGIA Q ON HL.MAQG = Q.MAQG
WHERE Q.TENQG = N'VN'
AND HL.MAHLV NOT IN (SELECT DISTINCT MAHLV FROM HLV_CLB);
/* 3. Liệt kê các cầu thủ đang thi đấu trong các câu lạc bộ có thứ hạng ở vòng 3 năm 2009 
lớn hơn 6 hoặc nhỏ hơn 3. */
SELECT C.MACT, C.HOTEN, C.MACLB
FROM CAUTHU C
JOIN BANGXH BX ON C.MACLB = BX.MACLB
WHERE BX.NAM = 2009 AND BX.VONG = 3
AND (BX.HANG > 6 OR BX.HANG < 3);
/* 4. Cho biết danh sách các trận đấu (NGAYTD, TENSAN, TENCLB1, TENCLB2, KETQUA) của 
câu lạc bộ (CLB) đang xếp hạng cao nhất tính đến hết vòng 3 năm 2009. */
SELECT TD.NGAYTD, S.TENSAN, CLB1.TENCLB AS CLB1, CLB2.TENCLB AS CLB2, TD.KETQUA
FROM TRANDAU TD
JOIN CAULACBO CLB1 ON TD.MACLB1 = CLB1.MACLB
JOIN CAULACBO CLB2 ON TD.MACLB2 = CLB2.MACLB
JOIN SANVD S ON TD.MASAN = S.MASAN
WHERE TD.MACLB1 = (
        SELECT TOP 1 MACLB 
        FROM BANGXH 
        WHERE NAM = 2009 AND VONG = 3 
        ORDER BY HANG ASC
    )
   OR TD.MACLB2 = (
        SELECT TOP 1 MACLB 
        FROM BANGXH 
        WHERE NAM = 2009 AND VONG = 3 
        ORDER BY HANG ASC
    );

-- C Truy vấn con 
/* 1. Cho biết mã câu lạc bộ, tên câu lạc bộ, tên sân vận động, địa chỉ và số lượng cầu thủ nước 
ngoài (Có quốc tịch khác “Việt Nam”) tương ứng của các câu lạc bộ có nhiều hơn 2 cầu 
thủ nước ngoài.*/
SELECT C.MACLB, C.TENCLB, S.TENSAN, S.DIACHI, COUNT(CT.MACT) AS SoCauThuNuocNgoai
FROM CAULACBO C
JOIN SANVD S ON C.MASAN = S.MASAN
JOIN CAUTHU CT ON C.MACLB = CT.MACLB
JOIN QUOCGIA Q ON CT.MAQG = Q.MAQG
WHERE Q.TENQG <> N'VN'  -- Chỉ lấy cầu thủ nước ngoài
GROUP BY C.MACLB, C.TENCLB, S.TENSAN, S.DIACHI  -- Thay C.DIACHI thành S.DIACHI
HAVING COUNT(CT.MACT) > 2;  -- Chỉ lấy CLB có hơn 2 cầu thủ nước ngoài


/* 2. Cho biết tên câu lạc bộ, tên tỉnh mà CLB đang đóng có hiệu số bàn thắng bại cao 
nhất năm 2009.*/
SELECT C.TENCLB, T.TENTINH
FROM CAULACBO C
JOIN TINH T ON C.MATINH = T.MATINH
WHERE C.MACLB = (
    SELECT TOP 1 MACLB 
    FROM BANGXH 
    WHERE NAM = 2009 
    ORDER BY (THANG - THUA) DESC
);


/*3. Cho biết danh sách các trận đấu ( NGAYTD, TENSAN, TENCLB1, TENCLB2, KETQUA) của 
câu lạc bộ CLB có thứ hạng thấp nhất trong bảng xếp hạng vòng 3 năm 2009.*/
SELECT TD.NGAYTD, S.TENSAN, CLB1.TENCLB AS CLB1, CLB2.TENCLB AS CLB2, TD.KETQUA
FROM TRANDAU TD
JOIN CAULACBO CLB1 ON TD.MACLB1 = CLB1.MACLB
JOIN CAULACBO CLB2 ON TD.MACLB2 = CLB2.MACLB
JOIN SANVD S ON TD.MASAN = S.MASAN
WHERE TD.MACLB1 = (
        SELECT TOP 1 MACLB 
        FROM BANGXH 
        WHERE NAM = 2009 AND VONG = 3 
        ORDER BY HANG DESC  -- Lấy CLB có thứ hạng thấp nhất
    )
   OR TD.MACLB2 = (
        SELECT TOP 1 MACLB 
        FROM BANGXH 
        WHERE NAM = 2009 AND VONG = 3 
        ORDER BY HANG DESC
    );


/* 4. Cho biết mã câu lạc bộ, tên câu lạc bộ đã tham gia thi đấu với tất cả các câu lạc bộ còn lại 
(kể cả sân nhà và sân khách) trong mùa giải năm 2009. */
SELECT C1.MACLB, C1.TENCLB
FROM CAULACBO C1
WHERE NOT EXISTS (
    SELECT 1
    FROM CAULACBO C2
    WHERE C1.MACLB <> C2.MACLB
    AND NOT EXISTS (
        SELECT 1 
        FROM TRANDAU TD 
        WHERE ((TD.MACLB1 = C1.MACLB AND TD.MACLB2 = C2.MACLB) 
           OR  (TD.MACLB1 = C2.MACLB AND TD.MACLB2 = C1.MACLB))
           AND YEAR(TD.NGAYTD) = 2009
    )
);

/* 5. Cho biết mã câu lạc bộ, tên câu lạc bộ đã tham gia thi đấu với tất cả các câu lạc bộ còn lại 
(chỉ tính sân nhà) tro ng mùa giải năm 2009.*/
SELECT C1.MACLB, C1.TENCLB
FROM CAULACBO C1
WHERE NOT EXISTS (
    SELECT 1
    FROM CAULACBO C2
    WHERE C1.MACLB <> C2.MACLB
    AND NOT EXISTS (
        SELECT 1 
        FROM TRANDAU TD 
        WHERE TD.MACLB1 = C1.MACLB 
        AND TD.MACLB2 = C2.MACLB 
        AND YEAR(TD.NGAYTD) = 2009
    )
);