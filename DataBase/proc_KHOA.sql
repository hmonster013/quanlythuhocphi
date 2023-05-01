--INSERT
create procedure sp_KHOA_insert(
	@MAKHOA nvarchar(10),
	@TENKHOA nvarchar(50)
)
as
begin
	insert into KHOA values (@MAKHOA, @TENKHOA)
end
GO
--UPDATE
create procedure sp_KHOA_update(
	@MAKHOA nvarchar(10),
	@TENKHOA nvarchar(50)
)
as
begin
	update KHOA set TENKHOA = @TENKHOA WHERE MAKHOA = @MAKHOA
end
GO
--DELETE
create procedure sp_KHOA_delete(
	@MAKHOA nvarchar(10)
)
as
begin
	delete KHOA where MAKHOA = @MAKHOA
end
GO
--SELECT *
create procedure sp_KHOA_select_all
as
begin
	select * from KHOA
end
GO
--SELECT ID
create procedure sp_KHOA_select_makhoa(
	@MAKHOA nvarchar(10)
)
as
begin
	select * from KHOA where MAKHOA =@MAKHOA
end
GO
