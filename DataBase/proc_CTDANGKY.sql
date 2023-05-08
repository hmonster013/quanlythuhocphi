use QLSV_TC
go

create procedure sp_CTDANGKY_insert(
	@MALHP int,
	@MADK int
)
as
begin
	INSERT INTO CTDANGKY(MALHP, MADK) VALUES (@MALHP, @MADK)
end
go

create procedure sp_CTDANGKY_update(
	@MACTDK int	,
	@MALHP int,
	@MADK int
)
as
begin
	UPDATE CTDANGKY SET MALHP = @MALHP, MADK = @MADK WHERE MACTDK = @MACTDK
end
go

create procedure sp_CTDANGKY_delete(
	@MACTDK int
)
as
begin
	DELETE FROM CTDANGKY WHERE MACTDK = @MACTDK
end
go

create procedure sp_CTDANGKY_select_all
as
begin
	select * from CTDANGKY
end
go

create procedure sp_CTDANGKY_select_mactdk(
	@MACTDK int
)
as
begin
	select * from CTDANGKY where MACTDK = @MACTDK
end
go
