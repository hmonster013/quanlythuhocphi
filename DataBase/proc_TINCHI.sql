create procedure sp_TINCHI_insert(
	@MATC nvarchar(10),
	@MAKHOA nvarchar(10),
	@DONGIA float
)
as
begin
	insert into TINCHI values (@MATC, @MAKHOA, @DONGIA)
end
GO

create procedure sp_TINCHI_update(
	@MATC nvarchar(10),
	@MAKHOA nvarchar(10),
	@DONGIA float
)
as
begin
	update TINCHI set MAKHOA = @MAKHOA, DONGIA = @DONGIA WHERE MATC = @MATC
end
GO

create procedure sp_TINCHI_delete(
	@MATC nvarchar(10)
)
as
begin
	delete TINCHI where MATC = @MATC
end
GO

create procedure sp_TINCHI_select_all
as
begin
	select * from TINCHI
end
GO

create procedure sp_TINCHI_select_matc(
	@MATC nvarchar(10)
)
as
begin
	select * from TINCHI where MATC = @MATC
end
GO
