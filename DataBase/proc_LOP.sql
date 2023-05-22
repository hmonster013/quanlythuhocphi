USE QLSV_TC
GO

create procedure sp_LOP_insert(
	@MALOP nvarchar(10),
	@MACN nvarchar(10)
)
as
begin
	insert into LOP(MALOP, MACN) values (@MALOP, @MACN)
end
GO

create procedure sp_LOP_update(
	@MALOP nvarchar(10),
	@MACN nvarchar(10)
)
as
begin
	update LOP set MACN = @MACN WHERE MALOP = @MALOP
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
	select * from LOP where MALOP = @MALOP
end
GO

CREATE PROCEDURE sp_LOP_select_by_makhoa(
	@MAKHOA nvarchar(10)
)
as
begin
	select * from LOP inner join CHUYENNGANH ON CHUYENNGANH.MACN = LOP.MACN 
	WHERE CHUYENNGANH.MAKHOA = @MAKHOA
end
go

CREATE PROCEDURE sp_LOP_select_by_macn(
	@MACN nvarchar(10)
)
as
begin
	select * from LOP where LOP.MACN = @MACN
end
go

