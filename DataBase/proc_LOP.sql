create procedure sp_LOP_insert(
	@MALOP nvarchar(10),
	@CHUYENNGANH nvarchar(50),
	@MAKHOA nvarchar(10)
)
as
begin
	insert into LOP values (@MALOP, @CHUYENNGANH, @MAKHOA)
end
GO

create procedure sp_LOP_update(
	@MALOP nvarchar(10),
	@CHUYENNGANH nvarchar(50),
	@MAKHOA nvarchar(10)
)
as
begin
	update LOP set CHUYENNGANH = @CHUYENNGANH, MAKHOA = @MAKHOA WHERE MALOP = @MALOP
end
GO

create procedure sp_LOP_delete(
	@MALOP nvarchar(10)
)
as
begin
	delete LOP where MALOP = @MALOP
end
GO

create procedure sp_LOP_select_all
as
begin
	select * from LOP
end
GO

create procedure sp_LOP_select_malop(
	@MALOP nvarchar(10)
)
as
begin
	select * from LOP where MALOP =@MALOP
end
GO


