USE [master]
GO
/****** Object:  Database [CreamMUTestDB]    Script Date: 2023/6/17 上午 12:00:09 ******/
CREATE DATABASE [CreamMUTestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CreamMUTestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CreamMUTestDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CreamMUTestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CreamMUTestDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CreamMUTestDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CreamMUTestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CreamMUTestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CreamMUTestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CreamMUTestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CreamMUTestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CreamMUTestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CreamMUTestDB] SET  MULTI_USER 
GO
ALTER DATABASE [CreamMUTestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CreamMUTestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CreamMUTestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CreamMUTestDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CreamMUTestDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CreamMUTestDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CreamMUTestDB', N'ON'
GO
ALTER DATABASE [CreamMUTestDB] SET QUERY_STORE = OFF
GO
USE [CreamMUTestDB]
GO
/****** Object:  Table [dbo].[ProductComment]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductComment](
	[CommentID] [int] NOT NULL,
	[MemberID] [int] NULL,
	[Comment] [nvarchar](200) NULL,
	[Date] [nvarchar](30) NULL,
	[ProductID] [int] NULL,
	[Stars] [int] NULL,
	[Image] [nvarchar](100) NULL,
 CONSTRAINT [PK_ProductComment] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tEmployee]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tEmployee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](20) NULL,
 CONSTRAINT [PK_tEmployee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tMember]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tMember](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](20) NULL,
 CONSTRAINT [PK_tMember] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tP_Type]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tP_Type](
	[P_TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Type_Descript] [nvarchar](50) NULL,
 CONSTRAINT [PK_tP_Type] PRIMARY KEY CLUSTERED 
(
	[P_TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tProduct]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tProduct](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[P_Name] [nvarchar](50) NULL,
	[P_TypeID] [int] NULL,
	[P_Price] [money] NULL,
	[P_Instock] [int] NULL,
	[P_Status] [nvarchar](20) NULL,
	[P_Descript] [nvarchar](500) NULL,
	[P_ReleaseDate] [nvarchar](50) NULL,
	[EmployeeID] [int] NULL,
	[P_Images] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tProduct] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTrackingList]    Script Date: 2023/6/17 上午 12:00:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTrackingList](
	[MemberID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[TrackingDate] [datetime] NULL,
 CONSTRAINT [PK_tTrackingList] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tEmployee] ON 
GO
INSERT [dbo].[tEmployee] ([EmployeeID], [EmployeeName]) VALUES (1, N'John')
GO
INSERT [dbo].[tEmployee] ([EmployeeID], [EmployeeName]) VALUES (2, N'Alice')
GO
INSERT [dbo].[tEmployee] ([EmployeeID], [EmployeeName]) VALUES (3, N'Bob')
GO
SET IDENTITY_INSERT [dbo].[tEmployee] OFF
GO
SET IDENTITY_INSERT [dbo].[tMember] ON 
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (1, N'Member1', N'member1@example.com', N'password1')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (2, N'Member2', N'member2@example.com', N'password2')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (3, N'Member3', N'member3@example.com', N'password3')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (4, N'Member4', N'member4@example.com', N'password4')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (5, N'Member5', N'member5@example.com', N'password5')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (6, N'Member6', N'member6@example.com', N'password6')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (7, N'Member7', N'member7@example.com', N'password7')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (8, N'Member8', N'member8@example.com', N'password8')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (9, N'Member9', N'member9@example.com', N'password9')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (10, N'Member10', N'member10@example.com', N'password10')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (11, N'Member11', N'member11@example.com', N'password11')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (12, N'Member12', N'member12@example.com', N'password12')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (13, N'Member13', N'member13@example.com', N'password13')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (14, N'Member14', N'member14@example.com', N'password14')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (15, N'Member15', N'member15@example.com', N'password15')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (16, N'Member16', N'member16@example.com', N'password16')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (17, N'Member17', N'member17@example.com', N'password17')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (18, N'Member18', N'member18@example.com', N'password18')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (19, N'Member19', N'member19@example.com', N'password19')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (20, N'Member20', N'member20@example.com', N'password20')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (21, N'Member21', N'member21@example.com', N'password21')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (22, N'Member22', N'member22@example.com', N'password22')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (23, N'Member23', N'member23@example.com', N'password23')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (24, N'Member24', N'member24@example.com', N'password24')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (25, N'Member25', N'member25@example.com', N'password25')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (26, N'Member26', N'member26@example.com', N'password26')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (27, N'Member27', N'member27@example.com', N'password27')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (28, N'Member28', N'member28@example.com', N'password28')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (29, N'Member29', N'member29@example.com', N'password29')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (30, N'Member30', N'member30@example.com', N'password30')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (31, N'Member31', N'member31@example.com', N'password31')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (32, N'Member32', N'member32@example.com', N'password32')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (33, N'Member33', N'member33@example.com', N'password33')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (34, N'Member34', N'member34@example.com', N'password34')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (35, N'Member35', N'member35@example.com', N'password35')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (36, N'Member36', N'member36@example.com', N'password36')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (37, N'Member37', N'member37@example.com', N'password37')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (38, N'Member38', N'member38@example.com', N'password38')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (39, N'Member39', N'member39@example.com', N'password39')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (40, N'Member40', N'member40@example.com', N'password40')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (41, N'Member41', N'member41@example.com', N'password41')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (42, N'Member42', N'member42@example.com', N'password42')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (43, N'Member43', N'member43@example.com', N'password43')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (44, N'Member44', N'member44@example.com', N'password44')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (45, N'Member45', N'member45@example.com', N'password45')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (46, N'Member46', N'member46@example.com', N'password46')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (47, N'Member47', N'member47@example.com', N'password47')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (48, N'Member48', N'member48@example.com', N'password48')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (49, N'Member49', N'member49@example.com', N'password49')
GO
INSERT [dbo].[tMember] ([MemberID], [Name], [Email], [Password]) VALUES (50, N'Member50', N'member50@example.com', N'password50')
GO
SET IDENTITY_INSERT [dbo].[tMember] OFF
GO
SET IDENTITY_INSERT [dbo].[tP_Type] ON 
GO
INSERT [dbo].[tP_Type] ([P_TypeID], [Type_Descript]) VALUES (1, N'老虎')
GO
INSERT [dbo].[tP_Type] ([P_TypeID], [Type_Descript]) VALUES (2, N'小狗')
GO
INSERT [dbo].[tP_Type] ([P_TypeID], [Type_Descript]) VALUES (3, N'小貓')
GO
INSERT [dbo].[tP_Type] ([P_TypeID], [Type_Descript]) VALUES (4, N'鱷魚')
GO
SET IDENTITY_INSERT [dbo].[tP_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[tProduct] ON 
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (2, N'Product2', 1, 10.0000, 50, N'Active', N'Description 1', N'20230202', 1, N'02.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (3, N'Product3', 2, 15.9900, 25, N'Active', N'Description 2', N'20230203', 2, N'03.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (4, N'Product4', 1, 12.9900, 30, N'Active', N'Description 3', N'20230204', 3, N'04.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (5, N'Product5', 2, 8.9900, 40, N'Active', N'Description 4', N'20230205', 1, N'05.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (6, N'Product6', 2, 14.9900, 20, N'Active', N'Description 5', N'20230206', 2, N'06.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (7, N'Product7', 2, 11.9900, 35, N'Active', N'Description 6', N'20230207', 3, N'07.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (8, N'Product8', 1, 9.9900, 45, N'Active', N'Description 7', N'20230208', 3, N'08.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (9, N'Product9', 2, 13.9900, 15, N'Active', N'Description 8', N'20230209', 2, N'09.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (10, N'Product10', 1, 12.4900, 55, N'Active', N'Description 9', N'202302010', 1, N'10.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (11, N'Product11', 1, 10.7900, 30, N'Active', N'Description 10', N'20230211', 1, N'11.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (12, N'Product12', 1, 16.9900, 25, N'Active', N'Description 11', N'20230212', 1, N'12.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (13, N'Product13', 1, 11.9900, 40, N'Active', N'Description 12', N'20230213', 2, N'13.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (14, N'Product14', 2, 13.9900, 35, N'Active', N'Description 13', N'20230214', 3, N'14.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (15, N'Product15', 2, 9.9900, 50, N'Active', N'Description 14', N'20230215', 1, N'15.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (16, N'Product16', 2, 11.4900, 20, N'Active', N'Description 15', N'20230216', 2, N'16.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (17, N'Product17', 2, 15.7900, 30, N'Active', N'Description 16', N'20230217', 3, N'17.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (18, N'Product18', 2, 14.9900, 40, N'Active', N'Description 17', N'20230218', 2, N'18.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (19, N'Product19', 2, 10.9900, 15, N'Active', N'Description 18', N'20230219', 1, N'19.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (20, N'Product20', 1, 12.4900, 30, N'Active', N'Description 19', N'20230220', 2, N'20.jpg')
GO
INSERT [dbo].[tProduct] ([ProductID], [P_Name], [P_TypeID], [P_Price], [P_Instock], [P_Status], [P_Descript], [P_ReleaseDate], [EmployeeID], [P_Images]) VALUES (21, N'Product21', 2, 13.9900, 25, N'Active', N'Description 20', N'20230221', 3, N'21.jpg')
GO
SET IDENTITY_INSERT [dbo].[tProduct] OFF
GO
ALTER TABLE [dbo].[tProduct]  WITH CHECK ADD  CONSTRAINT [FK_tProduct_P_TypeID] FOREIGN KEY([P_TypeID])
REFERENCES [dbo].[tP_Type] ([P_TypeID])
GO
ALTER TABLE [dbo].[tProduct] CHECK CONSTRAINT [FK_tProduct_P_TypeID]
GO
ALTER TABLE [dbo].[tProduct]  WITH CHECK ADD  CONSTRAINT [FK_tProduct_tEmployee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[tEmployee] ([EmployeeID])
GO
ALTER TABLE [dbo].[tProduct] CHECK CONSTRAINT [FK_tProduct_tEmployee]
GO
ALTER TABLE [dbo].[tTrackingList]  WITH CHECK ADD  CONSTRAINT [FK_tTrackingList_tMember] FOREIGN KEY([MemberID])
REFERENCES [dbo].[tMember] ([MemberID])
GO
ALTER TABLE [dbo].[tTrackingList] CHECK CONSTRAINT [FK_tTrackingList_tMember]
GO
USE [master]
GO
ALTER DATABASE [CreamMUTestDB] SET  READ_WRITE 
GO
