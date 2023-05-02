USE QLSV_TC
GO

CREATE PROCEDURE sp_SINHVIEN_insert(
    @MASV nvarchar(15),
    @HO nvarchar(50),
    @TEN nvarchar(10),
    @MALOP nvarchar(10),
    @MAKHOA nvarchar(10),
    @PHAI bit,
    @NGAYSINH date,
    @DIACHI nvarchar(100),
    @DANGNGHIHOC bit,
    @PASSWORD nvarchar(40)
)
AS
BEGIN
    INSERT INTO SINHVIEN (MASV, HO, TEN, MALOP, MAKHOA, PHAI, NGAYSINH, DIACHI, DANGNGHIHOC, PASSWORD)
    VALUES (@MASV, @HO, @TEN, @MALOP, @MAKHOA, @PHAI, @NGAYSINH, @DIACHI, @DANGNGHIHOC, @PASSWORD)
END
GO

CREATE PROCEDURE sp_SINHVIEN_update(
    @MASV nvarchar(15),
    @HO nvarchar(50),
    @TEN nvarchar(10),
    @MALOP nvarchar(10),
    @MAKHOA nvarchar(10),
    @PHAI bit,
    @NGAYSINH date,
    @DIACHI nvarchar(100),
    @DANGNGHIHOC bit,
    @PASSWORD nvarchar(40)
)
AS
BEGIN
    UPDATE SINHVIEN
    SET HO = @HO,
        TEN = @TEN,
        MALOP = @MALOP,
        MAKHOA = @MAKHOA,
        PHAI = @PHAI,
        NGAYSINH = @NGAYSINH,
        DIACHI = @DIACHI,
        DANGNGHIHOC = @DANGNGHIHOC,
        PASSWORD = @PASSWORD
    WHERE MASV = @MASV
END
GO

CREATE PROCEDURE sp_SINHVIEN_delete(
    @MASV nvarchar(15)
)
AS
BEGIN
    DELETE FROM SINHVIEN
    WHERE MASV = @MASV
END
GO

CREATE PROCEDURE sp_SINHVIEN_select_all
AS
BEGIN
    SELECT * FROM SINHVIEN
END
GO

CREATE PROCEDURE sp_SINHVIEN_select_masv(
    @MASV nvarchar(15)
)
AS
BEGIN
    SELECT * FROM SINHVIEN WHERE MASV = @MASV
END
GO
