CREATE DATABASE QLSV_TC
GO

USE QLSV_TC
GO

CREATE TABLE KHOA(
	MAKHOA nvarchar(10) primary key,
	TENKHOA nvarchar(50)
)
GO

CREATE TABLE LOP(
	MALOP nvarchar(10) primary key,
	TENLOP nvarchar(50),
	CHUYENNGANH nvarchar(50),
	MAKHOA nvarchar(10)
)
GO

CREATE TABLE SINHVIEN(
	MASV nvarchar(10) primary key,
	HO nvarchar(50),
	TEN nvarchar(10),
	MALOP nvarchar(10),
	PHAI bit, --FALSE: NAM, TRUE: NỮ
	NGAYSINH datetime,
	DIACHI nvarchar(100),
	DANGNGHIHOC bit,
	PASSWORD nvarchar(40)
)
GO

CREATE TABLE MONHOC(
	MAMH nvarchar(10) primary key,
	TENMH nvarchar(50),
	SOTIETLT int,
	SOTIETTH int,
)
GO

CREATE TABLE GIANGVIEN(
	MAGV nvarchar(10) primary key,
	HO nvarchar(50),
	TEN nvarchar(10),
	HOCHAM nvarchar(20),
	CHUYENMON nvarchar(50),
	MAKHOA nvarchar(10)
)
GO

CREATE TABLE TINCHI(
	MATC nvarchar(10),
	MAKHOA nvarchar(10),
	DONGIA float
)
GO

CREATE TABLE LOPHOCPHAN(
	MALHP int,
	NIENKHOA nvarchar(9),
	HOCKY int,
	MAMH nvarchar(10),
	NHOM int,
	MAGV nvarchar(10),
	MAKHOA nvarchar(10),
	SOSVTOITHIEU smallint,
	HUYLOP bit,
)
GO

CREATE TABLE DANGKY(
	MADK int primary key,
	MALTC int,
	MASV nvarchar(10),
	DIEM_CC int,
	DIEM_GK float,
	DIEM_CK float,
	HUYDANGKY bit
)
GO

CREATE TABLE HOCPHI(
	MAHP nvarchar(10),
	MASV nvarchar(10),
	NIENKHOA nvarchar(9),
	HOCKY int,
	HOCPHI int
)
GO

CREATE TABLE DONGHOCPHI(
	MADHP nvarchar(10),
	MASV nvarchar(10),
	NIENKHOA nvarchar(9),
	HOCKY int,
	NGAYDONG date,
	SOTIENDONG int
)
GO