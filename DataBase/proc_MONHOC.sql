USE QLSV_TC
GO

create procedure sp_MONHOC_insert(
	@MAMH nvarchar(10),
	@MACN nvarchar(10),
	@TENMH nvarchar(50),
	@HOCKY int,
	@SOTINCHI int
)
as
begin
	insert into MONHOC(MAMH, MACN, TENMH, HOCKY, SOTINCHI) values (@MAMH, @MACN, @TENMH, @HOCKY, @SOTINCHI)
end
GO

create procedure sp_MONHOC_update(
	@MAMH nvarchar(10),
	@MACN nvarchar(10),
	@TENMH nvarchar(50),
	@HOCKY int,
	@SOTINCHI int
)
as
begin
	update MONHOC set TENMH = @TENMH, MACN = @MACN, HOCKY = @HOCKY, SOTINCHI = @SOTINCHI WHERE MAMH = @MAMH
end
GO

create procedure sp_MONHOC_delete(
	@MAMH nvarchar(10)
)
as
begin
	delete MONHOC where MAMH = @MAMH
end
GO

create procedure sp_MONHOC_select_all
as
begin
	select * from MONHOC
end
GO

create procedure sp_MONHOC_select_mamh(
	@MAMH nvarchar(10)
)
as
begin
	select * from MONHOC where MAMH =@MAMH
end
GO
