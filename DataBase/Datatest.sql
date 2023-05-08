USE QLSV_TC
GO

INSERT INTO KHOA VALUES (N'CNTT', N'Công nghệ thông tin', 429000)

INSERT INTO CHUYENNGANH VALUES (N'HTTT', N'Hệ thống thông tin', N'CNTT')

INSERT INTO LOP VALUES (N'72DCHT21', N'HTTT')

INSERT INTO NGUOIDUNG VALUES (N'72DCHT20104', N'1', N'User')
INSERT INTO NGUOIDUNG VALUES (N'Admin', N'1', N'Admin')
INSERT INTO NGUOIDUNG VALUES (N'QuanLy', N'1', N'QuanLy')

INSERT INTO SINHVIEN VALUES (N'72DCHT20104', N'Trần Phú', N'Huy', N'72DCHT21', 0, '2003-5-18', N'Kim Giang, Hà Nội', 0, N'72DCHT20104')

INSERT INTO MONHOC(MAMH, MACN, TENMH, HOCKY, SOTINCHI) VALUES
('DC2HT26', N'HTTT', N'Cấu trúc dữ liệu và giải thuật', 3, 4),
('DC2HT38', N'HTTT', N'Công nghệ phần mềm', 3, 3),
('DC2TT32', N'HTTT', N'Điện toán đám mây', 2, 3),
('DC3HT21', N'HTTT', N'Hệ quản trị Cơ sở dữ liệu', 3, 3),
('DC2TT35', N'HTTT', N'Lập trình hướng đối tượng C++', 3, 3),
('DC2HT36', N'HTTT', N'Lập trình trên môi trường Web', 3, 3),
('DC2HT34', N'HTTT', N'Lập trình trực quan C#', 3, 3),
('DC2HT12', N'HTTT', N'Nguyên lý Hệ điều hành', 2, 3),
('DC2TT22', N'HTTT', N'Nhập môn Cơ sở dữ liệu', 3, 3),
('DC2HT13', N'HTTT', N'Nhập môn mạng máy tính', 3, 3),
('DC2TT31', N'HTTT', N'Phần mềm mã nguồn mở', 2, 3),
('DC2HT42', N'HTTT', N'Toán học rời rạc', 3, 4),
('DC3TT34', N'HTTT', N'Giao thông thông minh - ITS', 2, 3),
('DC2TT11', N'HTTT', N'Kiến trúc máy tính', 2, 3),
('DC2HT27', N'HTTT', N'Lập trình Java cơ bản', 3, 3),
('DC2TT23', N'HTTT', N'Ngôn ngữ lập trình C', 3, 3),
('DC2TT24', N'HTTT', N'Thương mại điện tử', 3, 3),
('DC1LL08', N'HTTT', N'Chủ nghĩa xã hội khoa học', 3, 2),
('DC1LL07', N'HTTT', N'Kinh tế chính trị Mác - Lênin', 2, 2),
('DC1TT31', N'HTTT', N'Kỹ thuật xây dựng và trình bày báo cáo', 1, 2),
('DC1CB98', N'HTTT', N'Làm việc nhóm và kỹ năng giao tiếp', 1, 2),
('DC1LL09', N'HTTT', N'Lịch sử Đảng cộng sản Việt Nam', 4, 2)

INSERT INTO GIANGVIEN VALUES (N'GV001', N'CNTT', N'Phan Như', N'Minh', N'Tiến Sĩ')
INSERT INTO GIANGVIEN VALUES (N'GV002', N'CNTT', N'Nguyễn Thái', N'Sơn', N'Tiến Sĩ')
INSERT INTO GIANGVIEN VALUES (N'GV003', N'CNTT', N'Nguyễn Thái', N'Thịnh', N'Tiến Sĩ')
INSERT INTO GIANGVIEN VALUES (N'GV004', N'CNTT', N'Lê Tùng', N'Anh', N'Tiến Sĩ')

INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2TT11', N'GV001', N'HTTT', 0)
INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2HT27', N'GV002', N'HTTT', 0)
INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC1CB98', N'GV003', N'HTTT', 0)
INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC1LL09', N'GV004', N'HTTT', 0)

INSERT INTO DANGKY(MASV, HOCKY) VALUES ('72DCHT20104', 2)	

INSERT INTO CTDANGKY(MALHP, MADK) VALUES (1000, 2000)
INSERT INTO CTDANGKY(MALHP, MADK) VALUES (1001, 2000)

INSERT INTO PHIEUTHU(MASV, NIENKHOA, HOCKY, SOTIENDONG) VALUES ('72DCHT20104', '2022-2023', 2, 2000000)