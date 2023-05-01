create procedure sp_SINHVIEN_insert(
	@MASV nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@MALOP nvarchar(10),
	@PHAI bit,
	@NGAYSINH datetime,
	@DIACHI nvarchar(100),
	@DANGNGHIHOC bit,
	@PASSWORD nvarchar(40)
)
as
begin
	insert into SINHVIEN values (@MASV, @HO, @TEN, @MALOP, @PHAI, @NGAYSINH, @DIACHI, @DANGNGHIHOC, @PASSWORD)
end
GO

create procedure sp_SINHVIEN_update(
	@MASV nvarchar(10),
	@HO nvarchar(50),
	@TEN nvarchar(10),
	@MALOP nvarchar(10),
	@PHAI bit,
	@NGAYSINH datetime,
	@DIACHI nvarchar(100),
	@DANGNGHIHOC bit,
	@PASSWORD nvarchar(40)
)
as
begin
	update SINHVIEN set HO = @HO, TEN = @TEN, MALOP = @MALOP, PHAI = @PHAI, NGAYSINH = @NGAYSINH, DIACHI = @DIACHI, DANGNGHIHOC = @DANGNGHIHOC, PASSWORD = @PASSWORD WHERE MASV = @MASV
end
GO

create procedure sp_SINHVIEN_delete(
	@MASV nvarchar(10)
)
as
begin
	delete SINHVIEN where MASV = @MASV
end
GO

create procedure sp_SINHVIEN_select_all
as
begin
	select * from SINHVIEN
end
GO

create procedure sp_SINHVIEN_select_masv(
	@MASV nvarchar(10)
)
as
begin
	select * from SINHVIEN where MASV =@MASV
end
GO
