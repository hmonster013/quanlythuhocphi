create procedure sp_MONHOC_insert(
	@MAMH nvarchar(10),
	@TENMH nvarchar(50)
)
as
begin
	insert into MONHOC values (@MAMH, @TENMH)
end
GO

create procedure sp_MONHOC_update(
	@MAMH nvarchar(10),
	@TENMH nvarchar(50)
)
as
begin
	update MONHOC set TENMH = @TENMH WHERE MAMH = @MAMH
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
