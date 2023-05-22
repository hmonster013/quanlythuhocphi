USE QLSV_TC
GO

--Lấy tất cả học phí của 1 sinh viên theo mã sinh viên của từng học kỳ
CREATE PROCEDURE sp_XULYHOCPHI_select_allhocphi(
	@MASV nvarchar(15)
)
as
begin
	DECLARE @temp_dongia float
	--Lấy ra đơn giá 1 tín chỉ của khoa sinh viên đang ở
	SELECT @temp_dongia = KHOA.DONGIA
	FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP = LOP.MALOP
				INNER JOIN CHUYENNGANH ON LOP.MACN = CHUYENNGANH.MACN
				INNER JOIN KHOA ON CHUYENNGANH.MAKHOA = KHOA.MAKHOA
	WHERE SINHVIEN.MASV = @MASV
	--Tính học phí của từng học kỳ sinh viên đang học
	SELECT SINHVIEN.MASV, DANGKY.MADK, DANGKY.HOCKY, SUM(MONHOC.SOTINCHI) as TONGSOTC, @temp_dongia * SUM(MONHOC.SOTINCHI) as HOCPHI
	FROM SINHVIEN INNER JOIN DANGKY ON SINHVIEN.MASV = DANGKY.MASV
				INNER JOIN CTDANGKY ON DANGKY.MADK = CTDANGKY.MADK
				INNER JOIN LOPHOCPHAN ON CTDANGKY.MALHP = LOPHOCPHAN.MALHP
				INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
	WHERE SINHVIEN.MASV = @MASV
	GROUP BY SINHVIEN.MASV, DANGKY.MADK, DANGKY.HOCKY
end
go

exec sp_XULYHOCPHI_select_allhocphi '72DCHT20104'
go

--Lấy ra tất cả số tiền đã đóng của 1 sinh viên theo mã sinh viên theo từng học kỳ 
CREATE PROCEDURE sp_XULYHOCPHI_select_alldadong(
	@MASV nvarchar(15)
)
as
begin
	SELECT PHIEUTHU.*, SUM(CTPHIEUTHU.SOTIENDONG) AS DADONG
	FROM PHIEUTHU LEFT JOIN CTPHIEUTHU ON PHIEUTHU.MAPT = CTPHIEUTHU.MAPT
	WHERE PHIEUTHU.MASV = @MASV
	GROUP BY PHIEUTHU.MAPT, PHIEUTHU.MASV, PHIEUTHU.NIENKHOA, PHIEUTHU.HOCKY
end
go

exec sp_XULYHOCPHI_select_alldadong '72DCHT20104'
GO

--Lấy ra tất cả các thông tin về học phí, số tiền đã đóng, số tiền chưa đóng theo từng học kỳ
CREATE PROCEDURE sp_XULYHOCPHI_all(
	@MASV nvarchar(15)
)
as
begin
	CREATE TABLE #temp_hocphi(
		MASV nvarchar(15),
		MADK int,
		HOCKY int,
		TONGSOTC int,
		HOCPHI float
	)

	INSERT INTO #temp_hocphi
	EXEC sp_XULYHOCPHI_select_allhocphi @MASV

	CREATE TABLE #temp_dadong(
		MAPT int,
		MASV nvarchar(15),
		NIENKHOA nvarchar(9),
		HOCKY int,
		DADONG float
	)

	INSERT INTO #temp_dadong
	EXEC sp_XULYHOCPHI_select_alldadong @MASV

	SELECT   #temp_hocphi.MADK, #temp_hocphi.MASV, #temp_dadong.NIENKHOA, #temp_hocphi.HOCKY, #temp_hocphi.TONGSOTC, #temp_dadong.MAPT, #temp_hocphi.HOCPHI,
			CASE 
			WHEN #temp_dadong.DADONG is null THEN 0
			ELSE #temp_dadong.DADONG
			END AS DADONG,
			CASE 
			WHEN #temp_hocphi.HOCPHI - #temp_dadong.DADONG is null THEN #temp_hocphi.HOCPHI
			ELSE #temp_hocphi.HOCPHI - #temp_dadong.DADONG
			END AS CHUADONG
	FROM #temp_hocphi LEFT JOIN #temp_dadong ON #temp_hocphi.MASV = #temp_dadong.MASV AND #temp_hocphi.HOCKY = #temp_dadong.HOCKY
end
go

exec sp_XULYHOCPHI_all '72DCHT20104'
go

--Lấy thông tin về thông tin học phí , đã đóng, chưa đóng của một sinh viên trong học kỳ nào đó
CREATE PROCEDURE sp_XULYHOCPHI_select_byhocky(
	@MASV nvarchar(15),
	@HOCKY int
)
as
begin
	CREATE TABLE #temp_hocphi(
		MASV nvarchar(15),
		MADK int,
		HOCKY int,
		TONGSOTC int,
		HOCPHI float
	)

	INSERT INTO #temp_hocphi
	EXEC sp_XULYHOCPHI_select_allhocphi @MASV

	CREATE TABLE #temp_dadong(
		MAPT int,
		MASV nvarchar(15),
		NIENKHOA nvarchar(9),
		HOCKY int,
		DADONG float
	)

	INSERT INTO #temp_dadong
	EXEC sp_XULYHOCPHI_select_alldadong @MASV

	SELECT  #temp_dadong.MAPT, #temp_hocphi.MASV, #temp_hocphi.MADK, #temp_dadong.NIENKHOA, #temp_hocphi.HOCKY, #temp_hocphi.HOCPHI,
			CASE 
			WHEN #temp_dadong.DADONG is null THEN 0
			ELSE #temp_dadong.DADONG
			END AS DADONG,
			CASE 
			WHEN #temp_hocphi.HOCPHI - #temp_dadong.DADONG is null THEN #temp_hocphi.HOCPHI
			ELSE #temp_hocphi.HOCPHI - #temp_dadong.DADONG
			END AS CHUADONG
	FROM #temp_hocphi LEFT JOIN #temp_dadong ON #temp_hocphi.MASV = #temp_dadong.MASV AND #temp_hocphi.HOCKY = #temp_dadong.HOCKY
	WHERE #temp_hocphi.HOCKY = @HOCKY
end
go

exec sp_XULYHOCPHI_select_byhocky '72DCHT20104', 2
go

--Lấy ra tất cả các thông tin về tổng học phí, tổng số tiền đã đóng, tổng số tiền chưa đóng
CREATE PROCEDURE sp_XULYHOCPHI_sum_all(
	@MASV nvarchar(15)
)
as
begin
	CREATE TABLE #temp_hocphi(
		MASV nvarchar(15),
		MADK int,
		HOCKY int,
		TONGSOTC int,
		HOCPHI float
	)

	INSERT INTO #temp_hocphi
	EXEC sp_XULYHOCPHI_select_allhocphi @MASV

	CREATE TABLE #temp_dadong(
		MAPT int,
		MASV nvarchar(15),
		NIENKHOA nvarchar(9),
		HOCKY int,
		DADONG float
	)

	INSERT INTO #temp_dadong
	EXEC sp_XULYHOCPHI_select_alldadong @MASV

	SELECT  #temp_hocphi.MASV, SUM(#temp_hocphi.HOCPHI) AS TONGHOCPHI,
			CASE 
			WHEN SUM(#temp_dadong.DADONG) is null THEN 0
			ELSE SUM(#temp_dadong.DADONG)
			END AS TONGDADONG,
			CASE 
			WHEN SUM(#temp_dadong.DADONG) is null THEN SUM(#temp_hocphi.HOCPHI)
			ELSE SUM(#temp_hocphi.HOCPHI) - SUM(#temp_dadong.DADONG)
			END AS TONGCHUADONG
	FROM #temp_hocphi LEFT JOIN #temp_dadong ON #temp_hocphi.MASV = #temp_dadong.MASV AND #temp_hocphi.HOCKY = #temp_dadong.HOCKY
	GROUP BY #temp_hocphi.MASV
end
go

exec sp_XULYHOCPHI_sum_all '72DCHT20104'
go


--Lấy danh sách học phí của tất cả sinh viên
CREATE PROCEDURE sp_XULYHOCPHI_dshocphi(
	@MAKHOA nvarchar(10),
	@MACN nvarchar(10),
	@MALOP nvarchar(10)
)
AS
BEGIN
	SELECT SINHVIEN.MASV, SUM(MONHOC.SOTINCHI) as TONGSOTC, KHOA.DONGIA * SUM(MONHOC.SOTINCHI) as HOCPHI
	FROM KHOA INNER JOIN CHUYENNGANH ON KHOA.MAKHOA = CHUYENNGANH.MAKHOA
			INNER JOIN LOP ON CHUYENNGANH.MACN = LOP.MACN
			INNER JOIN SINHVIEN ON LOP.MALOP = SINHVIEN.MALOP
			INNER JOIN DANGKY ON SINHVIEN.MASV = DANGKY.MASV
			INNER JOIN CTDANGKY ON DANGKY.MADK = CTDANGKY.MADK
			INNER JOIN LOPHOCPHAN ON CTDANGKY.MALHP = LOPHOCPHAN.MALHP
			INNER JOIN MONHOC ON LOPHOCPHAN.MAMH = MONHOC.MAMH
	WHERE KHOA.MAKHOA LIKE '%' + @MAKHOA + '%' AND CHUYENNGANH.MACN LIKE '%' + @MACN+ '%' AND LOP.MALOP LIKE '%' + @MALOP + '%'
	GROUP BY SINHVIEN.MASV, KHOA.DONGIA
END
GO

EXEC sp_XULYHOCPHI_dshocphi '', '', ''
GO
--Lấy danh sách học phí, số tiền đã đóng, số tiền chưa đóng
CREATE PROCEDURE sp_XULYHOCPHI_ds_all(
	@MAKHOA nvarchar(10),
	@MACN nvarchar(10),
	@MALOP nvarchar(10)
)
AS
BEGIN
	CREATE TABLE #temp(
		MASV nvarchar(15),
		TONGSOTC int,
		HOCPHI float
	)

	INSERT INTO #temp
	EXEC sp_XULYHOCPHI_dshocphi @MAKHOA, @MACN, @MALOP

	SELECT  #temp.MASV, #temp.TONGSOTC, #temp.HOCPHI,
		CASE 
		WHEN temp1.TONGDADONG is null THEN 0
		ELSE temp1.TONGDADONG
		END AS TONGDADONG,
		CASE 
		WHEN temp1.TONGDADONG is null THEN #temp.HOCPHI
		ELSE #temp.HOCPHI - temp1.TONGDADONG
		END AS TONGCHUADONG
	FROM #temp LEFT JOIN 
	(
	SELECT SINHVIEN.MASV, SUM(SOTIENDONG) AS TONGDADONG
	FROM SINHVIEN INNER JOIN PHIEUTHU ON SINHVIEN.MASV = PHIEUTHU.MASV
				INNER JOIN CTPHIEUTHU ON PHIEUTHU.MAPT = CTPHIEUTHU.MAPT
	GROUP BY SINHVIEN.MASV
	) as temp1 
	on #temp.MASV = temp1.MASV

END
GO

EXEC sp_XULYHOCPHI_ds_all '', '', ''
GO

--Lấy ra tổng học phí, tổng số tiền đã đóng, tổng số tiền chưa đóng của tất cả học sinh
CREATE PROCEDURE sp_XULYHOCPHI_ds_sum_all(
	@MAKHOA nvarchar(10),
	@MACN nvarchar(10),
	@MALOP nvarchar(10)
)
AS
BEGIN
	CREATE TABLE #temp(
		MASV nvarchar(15),
		TONGSOTC int,
		HOCPHI float
	)

	INSERT INTO #temp
	EXEC sp_XULYHOCPHI_dshocphi @MAKHOA, @MACN, @MALOP

	SELECT SUM(#temp.HOCPHI) AS TONGHOCPHI,
			CASE 
			WHEN SUM(temp1.TONGDADONG) is null THEN 0
			ELSE SUM(temp1.TONGDADONG)
			END AS TONGDADONG,
			CASE 
			WHEN SUM(temp1.TONGDADONG) is null THEN SUM(#temp.HOCPHI)
			ELSE SUM(#temp.HOCPHI) - SUM(temp1.TONGDADONG)
			END AS TONGCHUADONG
	FROM #temp LEFT JOIN 
	(
	SELECT SINHVIEN.MASV, SUM(SOTIENDONG) AS TONGDADONG
	FROM SINHVIEN INNER JOIN PHIEUTHU ON SINHVIEN.MASV = PHIEUTHU.MASV
				INNER JOIN CTPHIEUTHU ON PHIEUTHU.MAPT = CTPHIEUTHU.MAPT
	GROUP BY SINHVIEN.MASV
	) as temp1 
	on #temp.MASV = temp1.MASV
END
GO

EXEC sp_XULYHOCPHI_ds_sum_all 'CNTT', '', ''