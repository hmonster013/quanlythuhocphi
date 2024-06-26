﻿use QLSV_TC
go

--Tìm những môn học đã đăng ký với mã đăng ký A của sinh viên B trong học kỳ C
CREATE PROCEDURE sp_XULYDANGKY_select_masv(
	@MADK int,
	@MASV nvarchar(15),
	@HOCKY int
)
AS
BEGIN
	SELECT LOPHOCPHAN.MALHP, MONHOC.MAMH, MONHOC.TENMH, GIANGVIEN.HO + ' ' + GIANGVIEN.TEN as FULLNAME, MONHOC.SOTINCHI, LOPHOCPHAN.NIENKHOA, LOPHOCPHAN.HOCKY, LOPHOCPHAN.HUYLOP
	FROM DANGKY INNER JOIN CTDANGKY ON DANGKY.MADK = CTDANGKY.MADK
				INNER JOIN LOPHOCPHAN ON CTDANGKY.MALHP = LOPHOCPHAN.MALHP
				INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
				INNER JOIN GIANGVIEN ON LOPHOCPHAN.MAGV = GIANGVIEN.MAGV
	WHERE DANGKY.MASV = @MASV AND DANGKY.MADK = CTDANGKY.MADK AND DANGKY.HOCKY = @HOCKY
END
GO

--Tìm những lớp học phần mà sinh viên chưa đăng ký trong học kỳ A
CREATE PROCEDURE sp_XULYDANGKY_select_chuadk(
	@MADK int,
	@MASV nvarchar(15),
	@HOCKY int
)
as
begin
	SELECT MALHP, MAMH, TENMH, HO + ' ' + TEN as FULLNAME, SOTINCHI, NIENKHOA, HOCKY, HUYLOP
	FROM 
		(
		SELECT LOPHOCPHAN.MALHP, LOPHOCPHAN.NIENKHOA, MONHOC.MAMH, MONHOC.TENMH, GIANGVIEN.HO, GIANGVIEN.TEN, MONHOC.SOTINCHI, LOPHOCPHAN.HOCKY, LOPHOCPHAN.HUYLOP
		FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP = LOP.MALOP
					INNER JOIN CHUYENNGANH ON LOP.MACN = CHUYENNGANH.MACN
					INNER JOIN LOPHOCPHAN ON CHUYENNGANH.MACN = LOPHOCPHAN.MACN
					INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
					INNER JOIN GIANGVIEN ON LOPHOCPHAN.MAGV = GIANGVIEN.MAGV
		WHERE SINHVIEN.MASV = @MASV and LOPHOCPHAN.HOCKY = @HOCKY
		) as allplh
	WHERE MAMH NOT IN 
		(	
		SELECT MONHOC.MAMH
		FROM DANGKY INNER JOIN CTDANGKY ON DANGKY.MADK = CTDANGKY.MADK
					INNER JOIN LOPHOCPHAN ON CTDANGKY.MALHP = LOPHOCPHAN.MALHP
					INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
					INNER JOIN GIANGVIEN ON LOPHOCPHAN.MAGV = GIANGVIEN.MAGV
		WHERE DANGKY.MASV = @MASV AND DANGKY.MADK = CTDANGKY.MADK AND DANGKY.HOCKY = @HOCKY
		)
end
GO

exec sp_XULYDANGKY_select_masv '2000', '72DCHT20104', 2
exec sp_XULYDANGKY_select_chuadk '2000', '72DCHT20104', 2