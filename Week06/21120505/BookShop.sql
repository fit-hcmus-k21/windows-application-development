USE [BookShop]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2023 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 12/12/2023 5:08:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Cover_Img_Path] [nchar](50) NULL,
	[Author] [nvarchar](100) NULL,
	[Published_Year] [int] NULL,
	[Price] [int] NULL,
	[Category_ID] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Tâm Lý Học')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Sách Giáo Khoa')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Khởi Nghiệp - Kinh Doanh')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Kỹ Năng Mềm')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (5, N'Khoa Học - Công Nghệ')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (0, N'Khác')
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (1, N'Đắc Nhân Tâm', N'assets/books/01.DacNhanTam.jpg                    ', N'Dale Carnegie', 2020, 99000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (2, N'Đánh Thức Con Người Bên Trong Bạn', N'assets/books/02.DanhThucConNguoiBenTrongBan.jpg   ', N'Tony Robbins', 2019, 179000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (3, N'How Psychology Works', N'assets/books/03.HowPsychologyWorks.jpg            ', N'Jo Hemmings', 2020, 199000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (4, N'Mindset', N'assets/books/04.Mindset.jpg                       ', N'Carol S.Dweck', 2018, 49000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (5, N'Object Oriented Programming', N'assets/books/05.OOP.jpg                           ', N'HCMUS', 2010, 99000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (6, N'Tâm Lý Học Đời Sống', N'assets/books/06.TamLyHocDoiSong.jpg               ', N'Sigmund Freud', 2016, 249000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (7, N'Tâm Lý Học Nỗi Đau', N'assets/books/07.TamLyHocNoiDau.jpg                ', N'Patrick Wall', 2018, 149000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (8, N'Tâm Lý Học Tội Phạm', N'assets/books/08.TamLyHocToiPham.jpg               ', N'Hans Gross', 2017, 199000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (9, N'Luyện Thi Toeic 850', N'assets/books/09.TOEIC.jpg                         ', N'Trung Tam Anh Ngu', 2021, 99000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (10, N'Tư Duy Phản Biện', N'assets/books/10.TuDuyPhanBien.jpg                 ', N'Richard Paul and Linda Elder', 2022, 149000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (11, N'Why We Sleep ?', N'assets/books/11.WhyWeSleep.jpg                    ', N'Matthew Walker', 2019, 99000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (15, N'Bài tập Tiếng Anh 9', N'assets/books/13.jpg                               ', N'Nhà xuất bản Việt Nam', 2018, 49000, 2)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (16, N'Mĩ Thuật Lớp 1', N'assets/books/16.jpg                               ', N'Nhà xuất bản Việt Nam', 2003, 11000, 2)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (17, N'Bổ trợ và Nâng cao Toán 7', N'assets/books/14.jpg                               ', N'Nhà xuất bản Việt Nam', 2017, 19000, 2)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (18, N'Python for Data Analysis ', N'assets/books/15.jpg                               ', N'Bephein John', 2020, 199000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (19, N'Tôi Tài Giỏi Bạn Cũng Thế', N'assets/books/19..jpg                              ', N'Anonymous', 2019, 49000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (20, N'Cà phê cùng Tony', N'assets/books/20..jpg                              ', N'Tony Đặng', 2017, 75000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (21, N'Học Khôn Ngoan Mà Không Gian Nan', N'assets/books/21..jpg                              ', N'Kevin Pauth', 2020, 89000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (22, N'Tư Duy Sâu', N'assets/books/22.TuDuySau.jpg                      ', N'Diệp Tu', 2019, 37000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (23, N'Rèn luyện Tư duy phản biện', N'assets/books/23..jpg                              ', N'Albert RutherFold', 2023, 139000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (24, N'Đi Tìm Lẽ Sống', N'assets/books/24.DiTimLeSong.jpg                   ', N'Victor E.Frankl', 2023, 139000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (25, N'Hiểu Về Trái Tim', N'assets/books/25.HieuVeTraiTim.jpg                 ', N'Minh Niệm', 2017, 49000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (26, N'What I wish I knew when I was 20', N'assets/books/26.WhatIwishIknewwhenIwas20.jpg      ', N'Tina Seelig ', 2018, 117000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (27, N'Đảo Giấu Vàng', N'assets/books/27.DaoGiauVang.jpg                   ', N'Robert Louis Stevenson', 2018, 137000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (28, N'Trí Tuệ Do Thái', N'assets/books/28..jpg                              ', N'ERan Katz', 2016, 155000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (29, N'Hoàng Tử Bé', N'assets/books/29.HoangTuBe.jpg                     ', N'Antoine de Sain-Exupery', 2015, 89000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (30, N'Nhà Giả Kim', N'assets/books/30..jpg                              ', N'Paul Coelho', 2020, 89000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (31, N'Chiến Binh Cầu Vồng', N'assets/books/31..jpg                              ', N'Andrea Hiirata ', 2017, 89000, 3)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (32, N'How to improve your memory for study', N'assets/books/32..jpg                              ', N'Jonathan HanCock', 2020, 137000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (33, N'Ngày xưa có một con bò', N'assets/books/33..jpg                              ', N'Camilo Cruz PhD', 2021, 79000, 3)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (34, N'Làm chủ tuổi 20', N'assets/books/34..jpg                              ', N'Dương Duy Bách', 2021, 39000, 3)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (35, N'Chuyện con mèo dạy hải âu bay', N'assets/books/35..jpg                              ', N'Luis Sepul Veda', 2022, 135000, 4)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (36, N'Tâm lý học ứng dụng', N'assets/books/36.Tamlyhocungdung.jpg               ', N'Patrick King', 2018, 155000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (37, N'Tâm Lý Học Đại Cương', N'assets/books/37..jpg                              ', N'Nguyễn Quang Uân', 2017, 39000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (38, N'Cân bằng cảm xúc cả lúc bão giông', N'assets/books/38..jpg                              ', N'Anonymous', 2021, 95000, 1)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (39, N'Business Analysis ', N'assets/books/39.BusinessAnalysis.jpg              ', N'Dummies', 2021, 89000, 5)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (40, N'Luật An Toàn Thông Tin Mạng', N'assets/books/40..jpg                              ', N'Luật Pháp Việt Nam', 2021, 95000, 0)
INSERT [dbo].[Product] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price], [Category_ID]) VALUES (41, N'Người nhạy cảm món quà hay lời nguyền?', N'assets/books/41..jpg                              ', N'Anonymous', 2019, 89000, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
