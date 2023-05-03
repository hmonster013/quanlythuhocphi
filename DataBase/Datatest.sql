USE QLSV_TC
GO

INSERT INTO KHOA VALUES (N'CNTT', N'Công nghệ thông tin', 429000)

INSERT INTO LOP VALUES (N'72DCHT21', N'Hệ thống thông tin', N'CNTT')

INSERT INTO SINHVIEN VALUES (N'72DCHT20104', N'Trần Phú', N'Huy', N'72DCHT21', N'CNTT', 0, '2003-5-18', N'Kim Giang, Hà Nội', 0, N'1')

INSERT INTO MONHOC(MAMH,TENMH,SOTINCHI) VALUES
('DC2HT26', N'Cấu trúc dữ liệu và giải thuật', 4),
('DC2HT38', N'Công nghệ phần mềm', 3),
('DC2TT32', N'Điện toán đám mây', 2),
('DC3HT21', N'Hệ quản trị Cơ sở dữ liệu', 3),
('DC2TT35', N'Lập trình hướng đối tượng C++', 3),
('DC2HT36', N'Lập trình trên môi trường Web', 3),
('DC2HT34', N'Lập trình trực quan C#', 3),
('DC2HT12', N'Nguyên lý Hệ điều hành', 3),
('DC2TT22', N'Nhập môn Cơ sở dữ liệu', 3),
('DC2HT13', N'Nhập môn mạng máy tính', 3),
('DC2TT31', N'Phần mềm mã nguồn mở', 2),
('DC2HT42', N'Toán học rời rạc', 4),
('DC3TT34', N'Giao thông thông minh - ITS', 2),
--('DC2TT11', N'Kiến trúc máy tính', 3),
--('DC2HT27', N'Lập trình Java cơ bản', 3),
('DC2TT23', N'Ngôn ngữ lập trình C', 3),
('DC2TT24', N'Thương mại điện tử', 3),
('DC1LL08', N'Chủ nghĩa xã hội khoa học', 2),
('DC1LL07', N'Kinh tế chính trị Mác - Lênin', 2),
('DC1TT31', N'Kỹ thuật xây dựng và trình bày báo cáo', 2),
('DC1CB98', N'Làm việc nhóm và kỹ năng giao tiếp', 2),
('DC1LL09', N'Lịch sử Đảng cộng sản Việt Nam', 2),
('DC1TT44', N'Tin học cơ sở', 3),
('DC1CB41', N'Toán 2', 2),
('DC1LL06', N'Triết học Mác - Lênin', 3),
('DC1LL03', N'Tư tưởng Hồ Chí Minh', 2),
('DC1TT21', N'Vật lý đại cương 1', 2),
('DC1TT22', N'Vật lý đại cương 2', 2),
('DC1TD33', N'Aerobic', 2),
('DC1TD31', N'Bóng chuyền', 2),
('DC1TD32', N'Cầu lông', 2),
('DC1QP06', N'Công tác quốc phòng và an ninh', 2),
('DC1TD21', N'Điền kinh', 2),
('DC1QP05', N'Đường lối quốc phòng và an ninh của Đảng Cộng sản Việt Nam', 3),
('DC1QP08', N'Kỹ thuật chiến đấu bộ binh và chiến thuật', 2),
('DC1LL05', N'Pháp luật Việt Nam đại cương', 2),
('DC1QP07', N'Quân sự chung', 2),
('DC1CB35', N'Tiếng Anh', 3),
('DC1CB11', N'Toán 1', 4),
('DC3HT51', N'An toàn và bảo mật hệ thống thông tin', 2),
('DC3HT52', N'Đồ án Hệ thống thông tin', 3),
('DC3HT23', N'Hệ cơ sở tri thức', 3),
('DC3HT42', N'Hệ thống hoạch định nguồn lực doanh nghiệp (ERP)', 3),
('DC3HT43', N'Hệ thống thông tin địa lý - GIS', 3),
('DC3HT22', N'Hệ trợ giúp quyết định', 3),
('DC3HT41', N'Kiểm thử phần mềm', 3),
('DC3HT31', N'Lập trình di động', 3),
('DC3TH17', N'Nhập môn tương tác người - máy', 2),
('DC3HT16', N'Nhập môn Xử lý ảnh', 3),
('DC3HT60', N'Phân tích và thiết kế hệ thống thông tin', 4),
('DC3HT32', N'Quản lý dự án phần mềm', 3),
('DC3HT12', N'Trí tuệ nhân tạo', 3),
('DC3HT44', N'Kiến trúc của hệ thống QL, giám sát PTGT', 3),
('DC3TT12', N'Kiến trúc và thiết kế phần mềm', 3),
('DC3HT25', N'Lập trình Java nâng cao', 3),
('DC3HT18', N'Tiếng anh chuyên ngành',3),
('DC4HT23', N'Thực tập chuyên ngành',3),
('DC4HT25', N'Thực tập doanh nghiệp',3),
('DC4HT24', N'Thực tập Hệ thống thông tin',3),
('DC4TH80', N'Đồ án tốt nghiệp',8),
('DC4TH70', N'Thực tập tốt nghiệp',4),
('CC_TA', N'Chứng chỉ tiếng anh',1)

INSERT INTO GIANGVIEN VALUES (N'GV001', N'CNTT', N'Phan Như', N'Minh', N'Tiến Sĩ')
INSERT INTO GIANGVIEN VALUES (N'GV002', N'CNTT', N'Nguyễn Thái', N'Sơn', N'Tiến Sĩ')

INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2TT11', N'GV001', N'CNTT', 0)
INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2HT27', N'GV002', N'CNTT', 0)

INSERT INTO DANGKY(MALHP, MASV, HUYDANGKY) VALUES (1000, '72DCHT20104', 0)
INSERT INTO DANGKY(MALHP, MASV, HUYDANGKY) VALUES (1001, '72DCHT20104', 0)

INSERT INTO PHIEUTHU(MASV, NIENKHOA, HOCKY, SOTIENDONG) VALUES ('72DCHT20104', '2022-2023', 2, 2000000)