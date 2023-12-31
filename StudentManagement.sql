USE master
CREATE DATABASE [StudentManagement]
USE [StudentManagement]
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 8/25/2022 7:59:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQua](
	[MaSo] [varchar](8) NOT NULL,
	[MaMH] [nchar](6) NOT NULL,
	[Diem] [decimal](18, 0) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 8/25/2022 7:59:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [nchar](6) NOT NULL,
	[TenKhoa] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mon]    Script Date: 8/25/2022 7:59:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mon](
	[MaMH] [nchar](6) NOT NULL,
	[TenMH] [nvarchar](30) NULL,
	[SoTiet] [int] NULL,
	[MaKhoa] [nchar](6) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 8/25/2022 7:59:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSo] [varchar](8) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [varchar](10) NULL,
	[MaKhoa] [nchar](6) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'CNTT  ', N'Công nghệ thông tin')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'LOG   ', N'Logistic')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'NNH   ', N'Ngôn ngữ học')
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa]) VALUES (N'QTKD  ', N'Quản trị kinh doanh')
GO
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'CHN201', N'Ngôn ngữ Trung', 30, N'NNH   ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'COL221', N'Lập trình Console', 30, N'CNTT  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'CSD201', N'Kiến trúc máy tính', 30, N'CNTT  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'DBI202', N'Cơ sở dữ liệu', 30, N'CNTT  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'DEM211', N'Demo mon hoc', 32, N'CNTT  ', NULL)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'ENG201', N'Ngôn ngữ Anh', 30, N'NNH   ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'FIN202', N'Tài chính doanh nghiệp', 30, N'QTKD  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'JPN201', N'Ngôn ngữ Nhật', 30, N'NNH   ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'KOR201', N'Ngôn ngữ Hàn Quốc', 30, N'NNH   ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'KTE201', N'Nguyên lý kế toán', 30, N'QTKD  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'KTI202', N'Kinh tế vĩ mô', 30, N'QTKD  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'MKT201', N'Nguyên lý Marketing', 30, N'QTKD  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'NET202', N'Mạng máy tính', 30, N'CNTT  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'SPE202', N'Kỹ năng giao tiếp ', 30, N'QTKD  ', 1)
INSERT [dbo].[Mon] ([MaMH], [TenMH], [SoTiet], [MaKhoa], [Status]) VALUES (N'WIN221', N'Lập trình Windows', 30, N'CNTT  ', 1)
GO
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE130201', N'Lương Đức Anh', CAST(N'1999-02-02' AS Date), 1, N'Quảng Bình', N'0323231245', N'CNTT  ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140507', N'Đỗ Văn Mạnh', CAST(N'2000-07-30' AS Date), 1, N'Hưng Yên', N'0345345345', N'NNH   ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140661', N'Mai Anh Tuấn', CAST(N'2000-02-12' AS Date), 1, N'Hải Dương', N'0321321321', N'QTKD  ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140702', N'Phạm Xuân Huy', CAST(N'2000-01-13' AS Date), 1, N'Hà Nội', N'0336577960', N'CNTT  ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140704', N'Đinh Minh Chiến', CAST(N'2000-08-11' AS Date), 1, N'Quảng Ninh', N'0123123123', N'QTKD  ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140709', N'Nguyễn Thị Thuỳ Linh', CAST(N'2000-02-12' AS Date), 0, N'Hải Dương', N'0356879425', N'LOG   ', NULL)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE140802', N'Hoàng Bình Minh', CAST(N'2000-12-12' AS Date), 1, N'Hà Nội', N'0123123123', N'CNTT  ', 1)
INSERT [dbo].[SinhVien] ([MaSo], [HoTen], [NgaySinh], [GioiTinh], [DiaChi], [DienThoai], [MaKhoa], [Status]) VALUES (N'HE150803', N'Lê Tân Khánh Linh', CAST(N'2001-01-01' AS Date), 0, N'Hải Phòng', N'0232323231', N'LOG   ', 1)
GO
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE130201', N'COL221', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE130201', N'DBI202', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE130201', N'NET202', CAST(5 AS Decimal(18, 0)), NULL)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140507', N'CHN201', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140507', N'ENG201', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140507', N'JPN201', CAST(6 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140507', N'KOR201', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140661', N'FIN202', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140661', N'KTE201', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140661', N'KTI202', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140661', N'MKT201', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140661', N'SPE202', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140702', N'COL221', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140702', N'CSD201', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140702', N'DBI202', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140702', N'NET202', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140702', N'WIN221', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140704', N'FIN202', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140704', N'KTE201', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140704', N'KTI202', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140704', N'MKT201', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140704', N'SPE202', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140802', N'COL221', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140802', N'CSD201', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140802', N'DBI202', CAST(8 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140802', N'NET202', CAST(9 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE140802', N'WIN221', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE150803', N'CHN201', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE150803', N'ENG201', CAST(7 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE150803', N'JPN201', CAST(6 AS Decimal(18, 0)), 1)
INSERT [dbo].[KetQua] ([MaSo], [MaMH], [Diem], [Status]) VALUES (N'HE150803', N'KOR201', CAST(9 AS Decimal(18, 0)), 1)
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD FOREIGN KEY([MaMH])
REFERENCES [dbo].[Mon] ([MaMH])
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD FOREIGN KEY([MaSo])
REFERENCES [dbo].[SinhVien] ([MaSo])
GO
ALTER TABLE [dbo].[Mon]  WITH CHECK ADD FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
GO
