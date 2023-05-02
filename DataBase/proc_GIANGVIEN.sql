USE QLSV_TC
GO

create procedure sp_GIANGVIEN_insert(
	@MAGV nvarchar(10),
	@MAKHOA nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@HOCHAM nvarchar(20)
)
as
begin
	insert into GIANGVIEN values (@MAGV, @MAKHOA, @HO, @TEN, @HOCHAM)
end
GO

create procedure sp_GIANGVIEN_update(
	@MAGV nvarchar(10),
	@MAKHOA nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@HOCHAM nvarchar(20)
)
as
begin
	update GIANGVIEN set MAKHOA = @MAKHOA, HO = @HO, TEN = @TEN, HOCHAM = @HOCHAM WHERE MAGV = @MAGV
end
GO

create procedure sp_GIANGVIEN_delete(
	@MAGV nvarchar(10)
)
as
begin
	delete GIANGVIEN where MAGV = @MAGV
end
GO

create procedure sp_GIANGVIEN_select_all
as
begin
	select * from GIANGVIEN
end
GO

create procedure sp_GIANGVIEN_select_magv(
	@MAGV nvarchar(10)
)
as
begin
	select * from GIANGVIEN where MAGV = @MAGV
end
GO
