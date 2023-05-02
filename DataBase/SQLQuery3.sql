(SELECT KHOA.DONGIA
FROM SINHVIEN INNER JOIN KHOA ON SINHVIEN.MAKHOA = KHOA.MAKHOA
WHERE SINHVIEN.MASV = '72DCHT20104')

(SELECT SUM(SOTINCHI)
FROM DANGKY INNER JOIN LOPHOCPHAN ON DANGKY.MALHP = LOPHOCPHAN.MALHP
			INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
WHERE MASV = '72DCHT20104')

SELECT KHOA.DONGIA * TotalSoTinChi as 'KetQua'
FROM SINHVIEN INNER JOIN KHOA ON SINHVIEN.MAKHOA = KHOA.MAKHOA
CROSS JOIN
(SELECT SUM(SOTINCHI) AS TotalSoTinChi
FROM DANGKY INNER JOIN LOPHOCPHAN ON DANGKY.MALHP = LOPHOCPHAN.MALHP
INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
WHERE MASV = '72DCHT20104') AS T
WHERE SINHVIEN.MASV = '72DCHT20104'

