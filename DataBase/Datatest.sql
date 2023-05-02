USE QLSV_TC
GO

INSERT INTO KHOA VALUES (N'CNTT', N'Công nghệ thông tin', 429000)

INSERT INTO LOP VALUES (N'72DCHT21', N'Hệ thống thông tin', N'CNTT')

INSERT INTO SINHVIEN VALUES (N'72DCHT20104', N'Trần Phú', N'Huy', N'72DCHT21', N'CNTT', 0, '2003-5-18', N'Kim Giang, Hà Nội', 0, N'1')

INSERT INTO MONHOC(MAMH,TENMH,SOTINCHI) VALUES
('DC2HT26','Cấu trúc dữ liệu và giải thuật',4),
('DC2HT38','Công nghệ phần mềm',3),
('DC2TT32','Điện toán đám mây',2),
('DC3HT21','Hệ quản trị Cơ sở dữ liệu',3),
('DC2TT35','Lập trình hướng đối tượng C++',3),
('DC2HT36','Lập trình trên môi trường Web',3),
('DC2HT34','Lập trình trực quan C#',3),
('DC2HT12','Nguyên lý Hệ điều hành',3),
('DC2TT22','Nhập môn Cơ sở dữ liệu',3),
('DC2HT13','Nhập môn mạng máy tính',3),
('DC2TT31','Phần mềm mã nguồn mở',2),
('DC2HT42','Toán học rời rạc',4),
('DC3TT34','Giao thông thông minh - ITS',2),
('DC2TT11','Kiến trúc máy tính',3),
('DC2HT27','Lập trình Java cơ bản',3),
('DC2TT23','Ngôn ngữ lập trình C',3),
('DC2TT24','Thương mại điện tử',3),
('DC1LL08','Chủ nghĩa xã hội khoa học',2),
('DC1LL07','Kinh tế chính trị Mác - Lênin',2),
('DC1TT31','Kỹ thuật xây dựng và trình bày báo cáo',2),
('DC1CB98','Làm việc nhóm và kỹ năng giao tiếp',2),
('DC1LL09','Lịch sử Đảng cộng sản Việt Nam',2),
('DC1TT44','Tin học cơ sở',3),
('DC1CB41','Toán 2',2),
('DC1LL06','Triết học Mác - Lênin',3),
('DC1LL03','Tư tưởng Hồ Chí Minh',2),
('DC1TT21','Vật lý đại cương 1',2),
('DC1TT22','Vật lý đại cương 2',2),
('DC1TD33','Aerobic',2),
('DC1TD31','Bóng chuyền',2),
('DC1TD32','Cầu lông',2),
('DC1QP06','Công tác quốc phòng và an ninh',2),
('DC1TD21','Điền kinh',2),
('DC1QP05','Đường lối quốc phòng và an ninh của Đảng Cộng sản Việt Nam',3),
('DC1QP08','Kỹ thuật chiến đấu bộ binh và chiến thuật',2),
('DC1LL05','Pháp luật Việt Nam đại cương',2),
('DC1QP07','Quân sự chung',2),
('DC1CB35','Tiếng Anh',3),
('DC1CB11','Toán 1',4),
('DC3HT51','An toàn và bảo mật hệ thống thông tin',2),
('DC3HT52','Đồ án Hệ thống thông tin',3),
('DC3HT23','Hệ cơ sở tri thức',3),
('DC3HT42','Hệ thống hoạch định nguồn lực doanh nghiệp (ERP)',3),
('DC3HT43','Hệ thống thông tin địa lý - GIS',3),
('DC3HT22','Hệ trợ giúp quyết định',3),
('DC3HT41','Kiểm thử phần mềm',3),
('DC3HT31','Lập trình di động',3),
('DC3TH17','Nhập môn tương tác người - máy',2),
('DC3HT16','Nhập môn Xử lý ảnh',3),
('DC3HT60','Phân tích và thiết kế hệ thống thông tin',4),
('DC3HT32','Quản lý dự án phần mềm',3),
('DC3HT12','Trí tuệ nhân tạo',3),
('DC3HT44','Kiến trúc của hệ thống QL, giám sát PTGT',3),
('DC3TT12','Kiến trúc và thiết kế phần mềm',3),
('DC3HT25','Lập trình Java nâng cao',3),
('DC3HT18','Tiếng anh chuyên ngành',3),
('DC4HT23','Thực tập chuyên ngành',3),
('DC4HT25','Thực tập doanh nghiệp',3),
('DC4HT24','Thực tập Hệ thống thông tin',3),
('DC4TH80','Đồ án tốt nghiệp',8),
('DC4TH70','Thực tập tốt nghiệp',4),
('CC_TA','Chứng chỉ tiếng anh',1)

INSERT INTO GIANGVIEN VALUES (N'GV001', N'CNTT', N'Phan Như', N'Minh', N'Tiến Sĩ')
INSERT INTO GIANGVIEN VALUES (N'GV002', N'CNTT', N'Nguyễn Thái', N'Sơn', N'Tiến Sĩ')

INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2TT11', N'GV001', N'CNTT', 0)
INSERT INTO LOPHOCPHAN VALUES (N'2022-2023', 2, N'DC2HT27', N'GV002', N'CNTT', 0)

INSERT INTO DANGKY(MALHP, MASV, HUYDANGKY) VALUES (1000, '72DCHT20104', 0)
INSERT INTO DANGKY(MALHP, MASV, HUYDANGKY) VALUES (1001, '72DCHT20104', 0)

INSERT INTO PHIEUTHU(MASV, NIENKHOA, HOCKY, SOTIENDONG) VALUES ('72DCHT20104', '2022-2023', 2, 2000000)