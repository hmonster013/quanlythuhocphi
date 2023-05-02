USE QLSV_TC
GO

CREATE PROCEDURE sp_PHIEUTHU_insert(
@MASV nvarchar(15),
@NIENKHOA nvarchar(9),
@HOCKY int,
@NGAYDONG date,
@SOTIENDONG int
)
AS
BEGIN
INSERT INTO PHIEUTHU(MASV, NIENKHOA, HOCKY, NGAYDONG, SOTIENDONG) VALUES (@MASV, @NIENKHOA, @HOCKY, @NGAYDONG, @SOTIENDONG)
END
GO

CREATE PROCEDURE sp_PHIEUTHU_update(
@MAPT int,
@MASV nvarchar(15),
@NIENKHOA nvarchar(9),
@HOCKY int,
@NGAYDONG date,
@SOTIENDONG int
)
AS
BEGIN
UPDATE PHIEUTHU SET MASV = @MASV, NIENKHOA = @NIENKHOA, HOCKY = @HOCKY, NGAYDONG = @NGAYDONG, SOTIENDONG = @SOTIENDONG WHERE MAPT = @MAPT
END
GO

CREATE PROCEDURE sp_PHIEUTHU_delete(
@MAPT int
)
AS
BEGIN
DELETE FROM PHIEUTHU WHERE MAPT = @MAPT
END
GO

CREATE PROCEDURE sp_PHIEUTHU_select_all
AS
BEGIN
SELECT * FROM PHIEUTHU
END
GO

CREATE PROCEDURE sp_PHIEUTHU_select_mapt(
@MAPT int
)
AS
BEGIN
SELECT * FROM PHIEUTHU WHERE MAPT = @MAPT
END
GO