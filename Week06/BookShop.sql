USE [BookShop]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 12/2/2023 12:01:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Cover_Img_Path] [nchar](50) NULL,
	[Author] [nvarchar](100) NULL,
	[Published_Year] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (1, N'Đắc Nhân Tâm', N'assets/books/01.DacNhanTam.jpg                    ', N'Dale Carnegie', 2020, 99000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (2, N'Đánh Thức Con Người Bên Trong Bạn', N'assets/books/02.DanhThucConNguoiBenTrongBan.jpg   ', N'Tony Robbins', 2019, 179000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (3, N'How Psychology Works', N'assets/books/03.HowPsychologyWorks.jpg            ', N'Jo Hemmings', 2020, 199000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (4, N'Mindset', N'assets/books/04.Mindset.jpg                       ', N'Carol S.Dweck', 2018, 49000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (5, N'Object Oriented Programming', N'assets/books/05.OOP.jpg                           ', N'HCMUS', 2010, 99000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (6, N'Tâm Lý Học Đời Sống', N'assets/books/06.TamLyHocDoiSong.jpg               ', N'Sigmund Freud', 2016, 249000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (7, N'Tâm Lý Học Nỗi Đau', N'assets/books/07.TamLyHocNoiDau.jpg                ', N'Patrick Wall', 2018, 149000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (8, N'Tâm Lý Học Tội Phạm', N'assets/books/08.TamLyHocToiPham.jpg               ', N'Hans Gross', 2017, 199000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (9, N'Luyện Thi Toeic 850', N'assets/books/09.TOEIC.jpg                         ', N'Trung Tam Anh Ngu', 2021, 99000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (10, N'Tư Duy Phản Biện', N'assets/books/10.TuDuyPhanBien.jpg                 ', N'Richard Paul and Linda Elder', 2022, 149000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (11, N'Why We Sleep ?', N'assets/books/11.WhyWeSleep.jpg                    ', N'Matthew Walker', 2019, 99000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (15, N'Bài tập Tiếng Anh 9', N'assets/books/13.jpg                               ', N'Nhà xuất bản Việt Nam', 2018, 49000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (16, N'Mĩ Thuật Lớp 1', N'assets/books/16.jpg                               ', N'Nhà xuất bản Việt Nam', 2003, 11000)
INSERT [dbo].[Books] ([ID], [Name], [Cover_Img_Path], [Author], [Published_Year], [Price]) VALUES (17, N'Bổ trợ và Nâng cao Toán 7', N'assets/books/14.jpg                               ', N'Nhà xuất bản Việt Nam', 2017, 19000)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
