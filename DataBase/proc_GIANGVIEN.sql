create procedure sp_GIANGVIEN_insert(
	@MAGV nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@HOCHAM nvarchar(20),
	@CHUYENMON nvarchar(50),
	@MAKHOA nvarchar(10)
)
as
begin
	insert into GIANGVIEN values (@MAGV, @HO, @TEN, @HOCHAM, @CHUYENMON, @MAKHOA)
end
GO

create procedure sp_GIANGVIEN_update(
	@MAGV nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@HOCHAM nvarchar(20),
	@CHUYENMON nvarchar(50),
	@MAKHOA nvarchar(10)
)
as
begin
	update GIANGVIEN set HO = @HO, TEN = @TEN, HOCHAM = @HOCHAM, CHUYENMON = @CHUYENMON, MAKHOA = @MAKHOA WHERE MAGV = @MAGV
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
	select * from GIANGVIEN where MAGV =@MAGV
end
GO
