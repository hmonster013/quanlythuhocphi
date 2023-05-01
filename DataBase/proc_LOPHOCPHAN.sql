create procedure sp_LOPHOCPHAN_insert(
	@MALHP int,
	@NIENKHOA nvarchar(9),
	@HOCKY int,
	@MAMH nvarchar(10),
	@NHOM int,
	@MAGV nvarchar(10),
	@MAKHOA nvarchar(10),
	@SOSVTOITHIEU smallint,
	@HUYLOP bit
)
as
begin
	insert into LOPHOCPHAN values (@MALHP, @NIENKHOA, @HOCKY, @MAMH, @NHOM, @MAGV, @MAKHOA, @SOSVTOITHIEU, @HUYLOP)
end
GO

create procedure sp_LOPHOCPHAN_update(
	@MALHP int,
	@NIENKHOA nvarchar(9),
	@HOCKY int,
	@MAMH nvarchar(10),
	@NHOM int,
	@MAGV nvarchar(10),
	@MAKHOA nvarchar(10),
	@SOSVTOITHIEU smallint,
	@HUYLOP bit
)
as
begin
	update LOPHOCPHAN set NIENKHOA = @NIENKHOA, HOCKY = @HOCKY, MAMH = @MAMH, NHOM = @NHOM, MAGV = @MAGV, MAKHOA = @MAKHOA, SOSVTOITHIEU = @SOSVTOITHIEU, HUYLOP = @HUYLOP WHERE MALHP = @MALHP
end
GO

create procedure sp_LOPHOCPHAN_delete(
	@MALHP int
)
as
begin
	delete LOPHOCPHAN where MALHP = @MALHP
end
GO

create procedure sp_LOPHOCPHAN_select_all
as
begin
	select * from LOPHOCPHAN
end
GO

create procedure sp_LOPHOCPHAN_select_malhp(
	@MALHP int
)
as
begin
	select * from LOPHOCPHAN where MALHP = @MALHP
end
GO
