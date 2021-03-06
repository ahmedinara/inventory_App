USE [master]
GO
/****** Object:  Database [ims]    Script Date: 12/12/2021 3:57:39 PM ******/
CREATE DATABASE [ims]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventory MS- Project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventory MS- Project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventory MS- Project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Inventory MS- Project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ims] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ims].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ims] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ims] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ims] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ims] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ims] SET ARITHABORT OFF 
GO
ALTER DATABASE [ims] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ims] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ims] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ims] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ims] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ims] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ims] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ims] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ims] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ims] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ims] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ims] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ims] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ims] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ims] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ims] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ims] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ims] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ims] SET  MULTI_USER 
GO
ALTER DATABASE [ims] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ims] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ims] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ims] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ims] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ims] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ims] SET QUERY_STORE = OFF
GO
USE [ims]
GO
/****** Object:  User [msUser]    Script Date: 12/12/2021 3:57:39 PM ******/
CREATE USER [msUser] FOR LOGIN [msUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](150) NOT NULL,
	[Name_En] [nvarchar](150) NOT NULL,
	[ParentId] [int] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](250) NOT NULL,
	[Name_En] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](250) NULL,
	[Website] [nvarchar](250) NULL,
	[LogoUrl] [nvarchar](250) NULL,
	[Address] [nvarchar](400) NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Custmer]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Custmer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](250) NOT NULL,
	[Name_En] [nvarchar](250) NOT NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[MobileNo] [nvarchar](100) NULL,
	[Address] [nvarchar](400) NULL,
 CONSTRAINT [PK_Custmer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemScanned]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemScanned](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductVarientCode] [int] NULL,
	[LocationId] [int] NULL,
	[ScannedStock] [float] NOT NULL,
	[PhysicalStock] [float] NOT NULL,
	[LocationCode] [nvarchar](max) NULL,
	[VariantCode] [nvarchar](max) NULL,
	[StatesId] [int] NOT NULL,
	[ScannedId] [int] NOT NULL,
	[ProductCode] [nvarchar](max) NULL,
	[TagValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RfIdScannedProductDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](200) NOT NULL,
	[Name_En] [nvarchar](200) NOT NULL,
	[LocationCode] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeasuringUnit]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeasuringUnit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](200) NOT NULL,
	[Name_En] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_MeasuringUnit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Master]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Title_Ar] [nvarchar](250) NOT NULL,
	[Title_En] [nvarchar](250) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[LastUpdateOn] [datetime2](7) NULL,
	[LastUpdateBy] [int] NULL,
	[IsDeleted] [bit] NULL,
	[MeasuringUnitId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Varient]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Varient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[VarientCode] [nvarchar](max) NOT NULL,
	[CombinedAttributeId] [int] NOT NULL,
	[RfidCode] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_Product_Varient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RfIdScannedProduct]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RfIdScannedProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[ItemsCount] [int] NOT NULL,
 CONSTRAINT [PK_RfIdScannedProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScannedStates]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScannedStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](150) NOT NULL,
	[Name_En] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ScannedStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductVarientId] [int] NOT NULL,
	[VarientCode] [nvarchar](max) NULL,
	[PhysicalStock] [int] NOT NULL,
	[ReservedStock] [int] NOT NULL,
	[OrderedStock] [int] NOT NULL,
	[AvaliableStock] [int] NOT NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name_Ar] [nvarchar](250) NOT NULL,
	[Name_En] [nvarchar](250) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[MobileNo] [nvarchar](100) NULL,
	[Address] [nvarchar](400) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferIn]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferIn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime2](7) NULL,
	[ItemsCount] [int] NOT NULL,
	[SupplierId] [int] NOT NULL,
	[TransferDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TransferIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferInDetail]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferInDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Qty] [int] NOT NULL,
	[TransferInId] [int] NOT NULL,
	[ProductVarientId] [int] NOT NULL,
	[TagValue] [nvarchar](max) NULL,
	[VarientCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransferInDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferOut]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferOut](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNo] [nvarchar](100) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[DeletedBy] [int] NULL,
	[DeletedOn] [datetime2](7) NULL,
	[ItemsCount] [int] NOT NULL,
	[CustmerId] [int] NOT NULL,
	[TransferDate] [datetime2](7) NULL,
 CONSTRAINT [PK_TransferOut] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransferOutDetail]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransferOutDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Qty] [int] NOT NULL,
	[TransferOutId] [int] NOT NULL,
	[ProductVarientId] [int] NOT NULL,
	[TagValue] [nvarchar](max) NULL,
	[VarientCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransferOutDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FristName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[MobileNo] [nchar](100) NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NULL,
	[CreatedBy] [int] NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[UpdateBy] [int] NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[PasswordSalt] [varbinary](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WebHooks]    Script Date: 12/12/2021 3:57:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WebHooks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[obj] [nvarchar](max) NULL,
	[DateIn] [datetime2](7) NULL,
 CONSTRAINT [PK_WebHook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name_Ar], [Name_En], [ParentId]) VALUES (1, N'Defult Category', N'Defult Category', NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Company] ON 

INSERT [dbo].[Company] ([Id], [Name_Ar], [Name_En], [Email], [Website], [LogoUrl], [Address], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (1, N'ahmed', N'ahmed', N'ahmedinara00@gmail.com', NULL, NULL, NULL, CAST(N'2021-09-15T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Company] OFF
GO
SET IDENTITY_INSERT [dbo].[Custmer] ON 

INSERT [dbo].[Custmer] ([Id], [Name_Ar], [Name_En], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [MobileNo], [Address]) VALUES (2, N'Custmer-1', N'Custmer-1', 5, CAST(N'2021-09-25T00:00:00.0000000' AS DateTime2), NULL, NULL, N'01092008982', N'Custmer-1')
SET IDENTITY_INSERT [dbo].[Custmer] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemScanned] ON 

INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (119, 46, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'300833B2DDD9014000000000')
INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (120, 52, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'E2009A8020002AF000005988')
INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (121, 53, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'E200001B931501170360588A')
INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (122, 42, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'E280689100005002C05064CF')
INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (123, 50, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'E2009A8020002AF000005994')
INSERT [dbo].[ItemScanned] ([Id], [ProductVarientCode], [LocationId], [ScannedStock], [PhysicalStock], [LocationCode], [VariantCode], [StatesId], [ScannedId], [ProductCode], [TagValue]) VALUES (124, 43, 0, 1, 2, NULL, NULL, 2, 85, NULL, N'E280689100004002C054B4C1')
SET IDENTITY_INSERT [dbo].[ItemScanned] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([Id], [Name_Ar], [Name_En], [LocationCode]) VALUES (3, N'up', N'up', N'Loc-L1-R31L1-R31')
INSERT [dbo].[Location] ([Id], [Name_Ar], [Name_En], [LocationCode]) VALUES (5, N'down', N'down', N'Loc-L2-R41L1-R61')
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[MeasuringUnit] ON 

INSERT [dbo].[MeasuringUnit] ([Id], [Name_Ar], [Name_En]) VALUES (1, N'قطعه', N'Piece')
SET IDENTITY_INSERT [dbo].[MeasuringUnit] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Master] ON 

INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (17, N'17', N'F18/ID', N'F18/ID', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (18, N'18', N'FHT2422', N'FHT2422', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (19, N'19', N'hand wrist', N'hand wrist', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (20, N'20', N'LPR1000S', N'LPR1000S', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (21, N'21', N'LPR4000', N'LPR4000', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (22, N'22', N'T_T-Shirt', N'T_T-Shirt', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (23, N'23', N'TS1022', N'TS1022', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (24, N'24', N'UA400', N'UA400', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (25, N'25', N'Uface_Charger', N'Uface_Charger', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (26, N'26', N'Uface800', N'Uface800', 4, CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2), 4, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (31, N'wwww', N'a', N'a', 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1, 1)
INSERT [dbo].[Product_Master] ([Id], [Code], [Title_Ar], [Title_En], [CreatedBy], [CreatedOn], [LastUpdateOn], [LastUpdateBy], [IsDeleted], [MeasuringUnitId], [CategoryId]) VALUES (32, N'1234568', N'', N'', 4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 1, 1)
SET IDENTITY_INSERT [dbo].[Product_Master] OFF
GO
SET IDENTITY_INSERT [dbo].[Product_Varient] ON 

INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (34, 17, N'504660085398784', 1, N'E200001D32140180192099BB', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (35, 17, N'504660085398793', 1, N'E28011700000020CECD36AD5', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (36, 18, N'6100870672433', 1, N'E200001D321402711970EF0C', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (37, 19, N'248660085339501', 1, N'E280689400004005F0E2211C', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (38, 20, N'4600118009547', 1, N'E200001D32140180192099BB', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (39, 20, N'4600118009548', 1, N'E2801170000002136A93A3BE', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (40, 21, N'4600118000540', 1, N'E200001D321401841920A25D', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (41, 21, N'4600118000547', 1, N'E200001D321402771970F3AF', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (42, 22, N'570987110008', 1, N'E280689100005002C05064CF', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (43, 22, N'570987110009', 1, N'E280689100004002C054B4C1', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (44, 23, N'6100870542411', 1, N'E200001B490B02150520BFDF', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (45, 23, N'6100870542482', 1, N'E200001D3214016419508823', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (46, 24, N'304660085198790', 1, N'300833B2DDD9014000000000', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (47, 24, N'304660085198791', 1, N'E200001D3214018119209E13', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (48, 25, N'100180085449501', 1, N'300833B2DDD9014000000000', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (49, 25, N'100180085449502', 1, N'E200001B581202691910F032', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (50, 26, N'100180056556900', 1, N'E2009A8020002AF000005994', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (51, 26, N'100180056556901', 1, N'E28011057000020CBA9B239C', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (52, 26, N'100180056556902', 1, N'E2009A8020002AF000005988', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (53, 26, N'100180056556903', 1, N'E200001B931501170360588A', CAST(N'2021-12-09T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (55, 32, N'5A8B19C7555555555A8B19C7', 1, N'5A8B19C7555555555A8B19C7', CAST(N'2021-12-12T15:10:28.3715953' AS DateTime2))
INSERT [dbo].[Product_Varient] ([Id], [ProductId], [VarientCode], [CombinedAttributeId], [RfidCode], [CreatedOn]) VALUES (56, 32, N'E2801170000002136A93A2BB', 1, N'E2801170000002136A93A2BB', CAST(N'2021-12-12T15:10:28.3722723' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Product_Varient] OFF
GO
SET IDENTITY_INSERT [dbo].[RfIdScannedProduct] ON 

INSERT [dbo].[RfIdScannedProduct] ([Id], [CreatedBy], [CreatedOn], [ItemsCount]) VALUES (85, 4, CAST(N'2021-12-09T13:05:49.2223501' AS DateTime2), 6)
SET IDENTITY_INSERT [dbo].[RfIdScannedProduct] OFF
GO
SET IDENTITY_INSERT [dbo].[ScannedStates] ON 

INSERT [dbo].[ScannedStates] ([Id], [Name_Ar], [Name_En]) VALUES (1, N'مطابق', N'Identical')
INSERT [dbo].[ScannedStates] ([Id], [Name_Ar], [Name_En]) VALUES (2, N'غير مطابق', N'Not Identical')
INSERT [dbo].[ScannedStates] ([Id], [Name_Ar], [Name_En]) VALUES (3, N'لا يوجد', N'not exist')
INSERT [dbo].[ScannedStates] ([Id], [Name_Ar], [Name_En]) VALUES (4, N'لم يجرد', N'not stripped')
SET IDENTITY_INSERT [dbo].[ScannedStates] OFF
GO
SET IDENTITY_INSERT [dbo].[Stock] ON 

INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (20, 46, N'304660085198790', 4, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (21, 53, N'100180056556903', 4, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (22, 50, N'100180056556900', 4, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (23, 52, N'100180056556902', 3, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (24, 49, N'100180085449502', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (25, 51, N'100180056556901', 4, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (26, 43, N'570987110009', 4, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (27, 42, N'570987110008', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (28, 39, N'4600118009548', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (29, 44, N'6100870542411', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (30, 41, N'4600118000547', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (31, 37, N'248660085339501', 2, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (32, 55, N'5A8B19C7555555555A8B19C7', 1, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (33, 56, N'E2801170000002136A93A2BB', 1, 0, 0, 1, 3)
INSERT [dbo].[Stock] ([Id], [ProductVarientId], [VarientCode], [PhysicalStock], [ReservedStock], [OrderedStock], [AvaliableStock], [LocationId]) VALUES (34, 35, N'504660085398793', 1, 0, 0, 1, 3)
SET IDENTITY_INSERT [dbo].[Stock] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name_Ar], [Name_En], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [MobileNo], [Address]) VALUES (2, N'Supplier-1', N'Supplier-1', 4, CAST(N'2021-09-22T00:00:00.0000000' AS DateTime2), NULL, NULL, N'a', N'a')
INSERT [dbo].[Supplier] ([Id], [Name_Ar], [Name_En], [CreatedBy], [CreatedOn], [UpdatedBy], [UpdatedOn], [MobileNo], [Address]) VALUES (3, N'Supplier-2', N'Supplier-2', 4, CAST(N'2021-09-22T00:00:00.0000000' AS DateTime2), NULL, NULL, N'a', N'a')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferIn] ON 

INSERT [dbo].[TransferIn] ([Id], [InvoiceNo], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [DeletedBy], [DeletedOn], [ItemsCount], [SupplierId], [TransferDate]) VALUES (66, N'inv-1', 4, CAST(N'2021-12-09T12:50:04.3415858' AS DateTime2), NULL, NULL, NULL, NULL, 8, 2, CAST(N'2021-12-09T11:26:28.2143327' AS DateTime2))
INSERT [dbo].[TransferIn] ([Id], [InvoiceNo], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [DeletedBy], [DeletedOn], [ItemsCount], [SupplierId], [TransferDate]) VALUES (67, N'invo-12345', 4, CAST(N'2021-12-12T14:40:25.3312620' AS DateTime2), NULL, NULL, NULL, NULL, 9, 2, CAST(N'2021-12-12T14:39:59.5077987' AS DateTime2))
INSERT [dbo].[TransferIn] ([Id], [InvoiceNo], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [DeletedBy], [DeletedOn], [ItemsCount], [SupplierId], [TransferDate]) VALUES (68, N'invo-12345', 4, CAST(N'2021-12-12T15:10:28.4362014' AS DateTime2), NULL, NULL, NULL, NULL, 13, 2, CAST(N'2021-12-12T15:09:13.5330419' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TransferIn] OFF
GO
SET IDENTITY_INSERT [dbo].[TransferInDetail] ON 

INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (70, 1, 66, 46, N'300833B2DDD9014000000000', N'304660085198790')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (71, 1, 66, 49, N'E200001B581202691910F032', N'100180085449502')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (72, 1, 66, 53, N'E200001B931501170360588A', N'100180056556903')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (73, 1, 66, 50, N'E2009A8020002AF000005994', N'100180056556900')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (74, 1, 66, 52, N'E2009A8020002AF000005988', N'100180056556902')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (75, 1, 66, 51, N'E28011057000020CBA9B239C', N'100180056556901')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (76, 1, 66, 43, N'E280689100004002C054B4C1', N'570987110009')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (77, 1, 66, 42, N'E280689100005002C05064CF', N'570987110008')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (78, 1, 67, 50, N'E2009A8020002AF000005994', N'100180056556900')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (79, 1, 67, 39, N'E2801170000002136A93A3BE', N'4600118009548')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (80, 1, 67, 44, N'E200001B490B02150520BFDF', N'6100870542411')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (81, 1, 67, 46, N'300833B2DDD9014000000000', N'304660085198790')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (82, 1, 67, 43, N'E280689100004002C054B4C1', N'570987110009')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (83, 1, 67, 41, N'E200001D321402771970F3AF', N'4600118000547')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (84, 1, 67, 37, N'E280689400004005F0E2211C', N'248660085339501')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (85, 1, 67, 53, N'E200001B931501170360588A', N'100180056556903')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (86, 1, 67, 51, N'E28011057000020CBA9B239C', N'100180056556901')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (87, 1, 68, 37, N'E280689400004005F0E2211C', N'248660085339501')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (88, 1, 68, 50, N'E2009A8020002AF000005994', N'100180056556900')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (89, 1, 68, 46, N'300833B2DDD9014000000000', N'304660085198790')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (90, 1, 68, 51, N'E28011057000020CBA9B239C', N'100180056556901')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (91, 1, 68, 41, N'E200001D321402771970F3AF', N'4600118000547')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (92, 1, 68, 44, N'E200001B490B02150520BFDF', N'6100870542411')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (93, 1, 68, 39, N'E2801170000002136A93A3BE', N'4600118009548')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (94, 1, 68, 53, N'E200001B931501170360588A', N'100180056556903')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (95, 1, 68, 43, N'E280689100004002C054B4C1', N'570987110009')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (96, 1, 68, 55, N'5A8B19C7555555555A8B19C7', N'5A8B19C7555555555A8B19C7')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (97, 1, 68, 56, N'E2801170000002136A93A2BB', N'E2801170000002136A93A2BB')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (98, 1, 68, 52, N'E2009A8020002AF000005988', N'100180056556902')
INSERT [dbo].[TransferInDetail] ([Id], [Qty], [TransferInId], [ProductVarientId], [TagValue], [VarientCode]) VALUES (99, 1, 68, 35, N'E28011700000020CECD36AD5', N'504660085398793')
SET IDENTITY_INSERT [dbo].[TransferInDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [FristName], [LastName], [MobileNo], [Email], [Password], [RoleId], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [IsActive], [CompanyId], [PasswordSalt]) VALUES (4, N'ahmed', N'inara', N'01092008982                                                                                         ', N'ahmedinara@aictec.com', N'YQv3nyQ+eFU2koP7MvzsEGERdQ5uy+2qPfDCVaXM3gk=', NULL, NULL, CAST(N'2021-09-16T06:20:41.8784955' AS DateTime2), NULL, NULL, 1, 1, 0x2D67D76ABFA195869885DFFC6DCE1019)
INSERT [dbo].[User] ([Id], [FristName], [LastName], [MobileNo], [Email], [Password], [RoleId], [CreatedBy], [CreatedOn], [UpdateBy], [UpdatedOn], [IsActive], [CompanyId], [PasswordSalt]) VALUES (5, N'Hanan', N'Abdelwahab', N'2365489898                                                                                          ', N'hanan.abdelwahab@aictec.com', N'P5bsqwojHLuv7nlDBjQyQSvIb6Pu6VpeZv8oLoSlq8M=', NULL, NULL, CAST(N'2021-09-16T07:23:50.1292702' AS DateTime2), NULL, NULL, 1, 1, 0xF729D83937E1173AA265426C415CA6C6)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
/****** Object:  Index [IX_Category_ParentId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Category_ParentId] ON [dbo].[Category]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Custmer_CreatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Custmer_CreatedBy] ON [dbo].[Custmer]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Custmer_UpdatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Custmer_UpdatedBy] ON [dbo].[Custmer]
(
	[UpdatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RfIdScannedProductDetail_ProductId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_RfIdScannedProductDetail_ProductId] ON [dbo].[ItemScanned]
(
	[ProductVarientCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RfIdScannedProductDetail_StatesId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_RfIdScannedProductDetail_StatesId] ON [dbo].[ItemScanned]
(
	[StatesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Master_CategoryId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Master_CategoryId] ON [dbo].[Product_Master]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Master_CreatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Master_CreatedBy] ON [dbo].[Product_Master]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Master_LastUpdateBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Master_LastUpdateBy] ON [dbo].[Product_Master]
(
	[LastUpdateBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Master_MeasuringUnitId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Master_MeasuringUnitId] ON [dbo].[Product_Master]
(
	[MeasuringUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Varient_ProductId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Product_Varient_ProductId] ON [dbo].[Product_Varient]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Stock_ProductId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Stock_ProductId] ON [dbo].[Stock]
(
	[ProductVarientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Supplier_CreatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Supplier_CreatedBy] ON [dbo].[Supplier]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Supplier_UpdatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_Supplier_UpdatedBy] ON [dbo].[Supplier]
(
	[UpdatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferIn_CreatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferIn_CreatedBy] ON [dbo].[TransferIn]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferIn_DeletedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferIn_DeletedBy] ON [dbo].[TransferIn]
(
	[DeletedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferIn_SupplierId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferIn_SupplierId] ON [dbo].[TransferIn]
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferIn_UpdateBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferIn_UpdateBy] ON [dbo].[TransferIn]
(
	[UpdateBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferInDetail_TransferInId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferInDetail_TransferInId] ON [dbo].[TransferInDetail]
(
	[TransferInId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferOut_CreatedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferOut_CreatedBy] ON [dbo].[TransferOut]
(
	[CreatedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferOut_CustmerId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferOut_CustmerId] ON [dbo].[TransferOut]
(
	[CustmerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferOut_DeletedBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferOut_DeletedBy] ON [dbo].[TransferOut]
(
	[DeletedBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferOut_UpdateBy]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferOut_UpdateBy] ON [dbo].[TransferOut]
(
	[UpdateBy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TransferOutDetail_TransferOutId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_TransferOutDetail_TransferOutId] ON [dbo].[TransferOutDetail]
(
	[TransferOutId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_User_CompanyId]    Script Date: 12/12/2021 3:57:40 PM ******/
CREATE NONCLUSTERED INDEX [IX_User_CompanyId] ON [dbo].[User]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Category]  WITH CHECK ADD  CONSTRAINT [FK_Category_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Category] CHECK CONSTRAINT [FK_Category_Category]
GO
ALTER TABLE [dbo].[Custmer]  WITH CHECK ADD  CONSTRAINT [FK_Custmer_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Custmer] CHECK CONSTRAINT [FK_Custmer_User]
GO
ALTER TABLE [dbo].[Custmer]  WITH CHECK ADD  CONSTRAINT [FK_Custmer_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Custmer] CHECK CONSTRAINT [FK_Custmer_User1]
GO
ALTER TABLE [dbo].[ItemScanned]  WITH CHECK ADD  CONSTRAINT [FK_ItemsScanned_RfIdScannedProduct] FOREIGN KEY([ScannedId])
REFERENCES [dbo].[RfIdScannedProduct] ([Id])
GO
ALTER TABLE [dbo].[ItemScanned] CHECK CONSTRAINT [FK_ItemsScanned_RfIdScannedProduct]
GO
ALTER TABLE [dbo].[ItemScanned]  WITH CHECK ADD  CONSTRAINT [FK_RfIdScannedProductDetail_ScannedStates_StatesId] FOREIGN KEY([StatesId])
REFERENCES [dbo].[ScannedStates] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemScanned] CHECK CONSTRAINT [FK_RfIdScannedProductDetail_ScannedStates_StatesId]
GO
ALTER TABLE [dbo].[Product_Master]  WITH CHECK ADD  CONSTRAINT [FK_Product_Master_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product_Master] CHECK CONSTRAINT [FK_Product_Master_Category]
GO
ALTER TABLE [dbo].[Product_Master]  WITH CHECK ADD  CONSTRAINT [FK_Product_Master_MeasuringUnit] FOREIGN KEY([MeasuringUnitId])
REFERENCES [dbo].[MeasuringUnit] ([Id])
GO
ALTER TABLE [dbo].[Product_Master] CHECK CONSTRAINT [FK_Product_Master_MeasuringUnit]
GO
ALTER TABLE [dbo].[Product_Master]  WITH CHECK ADD  CONSTRAINT [FK_Product_Master_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Product_Master] CHECK CONSTRAINT [FK_Product_Master_User]
GO
ALTER TABLE [dbo].[Product_Master]  WITH CHECK ADD  CONSTRAINT [FK_Product_Master_User1] FOREIGN KEY([LastUpdateBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Product_Master] CHECK CONSTRAINT [FK_Product_Master_User1]
GO
ALTER TABLE [dbo].[Product_Varient]  WITH CHECK ADD  CONSTRAINT [FK_Product_Varient_Product_Master] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product_Master] ([Id])
GO
ALTER TABLE [dbo].[Product_Varient] CHECK CONSTRAINT [FK_Product_Varient_Product_Master]
GO
ALTER TABLE [dbo].[RfIdScannedProduct]  WITH CHECK ADD  CONSTRAINT [FK_RfIdScannedProduct_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[RfIdScannedProduct] CHECK CONSTRAINT [FK_RfIdScannedProduct_User]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_Varient1] FOREIGN KEY([ProductVarientId])
REFERENCES [dbo].[Product_Varient] ([Id])
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Product_Varient1]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_User]
GO
ALTER TABLE [dbo].[Supplier]  WITH CHECK ADD  CONSTRAINT [FK_Supplier_User1] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Supplier] CHECK CONSTRAINT [FK_Supplier_User1]
GO
ALTER TABLE [dbo].[TransferIn]  WITH CHECK ADD  CONSTRAINT [FK_TransferIn_Supplier] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[Supplier] ([Id])
GO
ALTER TABLE [dbo].[TransferIn] CHECK CONSTRAINT [FK_TransferIn_Supplier]
GO
ALTER TABLE [dbo].[TransferIn]  WITH CHECK ADD  CONSTRAINT [FK_TransferIn_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferIn] CHECK CONSTRAINT [FK_TransferIn_User]
GO
ALTER TABLE [dbo].[TransferIn]  WITH CHECK ADD  CONSTRAINT [FK_TransferIn_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferIn] CHECK CONSTRAINT [FK_TransferIn_User1]
GO
ALTER TABLE [dbo].[TransferIn]  WITH CHECK ADD  CONSTRAINT [FK_TransferIn_User2] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferIn] CHECK CONSTRAINT [FK_TransferIn_User2]
GO
ALTER TABLE [dbo].[TransferInDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferInDetail_Product_Varient] FOREIGN KEY([ProductVarientId])
REFERENCES [dbo].[Product_Varient] ([Id])
GO
ALTER TABLE [dbo].[TransferInDetail] CHECK CONSTRAINT [FK_TransferInDetail_Product_Varient]
GO
ALTER TABLE [dbo].[TransferInDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferInDetail_TransferIn] FOREIGN KEY([TransferInId])
REFERENCES [dbo].[TransferIn] ([Id])
GO
ALTER TABLE [dbo].[TransferInDetail] CHECK CONSTRAINT [FK_TransferInDetail_TransferIn]
GO
ALTER TABLE [dbo].[TransferOut]  WITH CHECK ADD  CONSTRAINT [FK_TransferOut_Custmer] FOREIGN KEY([CustmerId])
REFERENCES [dbo].[Custmer] ([Id])
GO
ALTER TABLE [dbo].[TransferOut] CHECK CONSTRAINT [FK_TransferOut_Custmer]
GO
ALTER TABLE [dbo].[TransferOut]  WITH CHECK ADD  CONSTRAINT [FK_TransferOut_User] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferOut] CHECK CONSTRAINT [FK_TransferOut_User]
GO
ALTER TABLE [dbo].[TransferOut]  WITH CHECK ADD  CONSTRAINT [FK_TransferOut_User1] FOREIGN KEY([UpdateBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferOut] CHECK CONSTRAINT [FK_TransferOut_User1]
GO
ALTER TABLE [dbo].[TransferOut]  WITH CHECK ADD  CONSTRAINT [FK_TransferOut_User2] FOREIGN KEY([DeletedBy])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[TransferOut] CHECK CONSTRAINT [FK_TransferOut_User2]
GO
ALTER TABLE [dbo].[TransferOutDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferOutDetail_Product_Varient] FOREIGN KEY([ProductVarientId])
REFERENCES [dbo].[Product_Varient] ([Id])
GO
ALTER TABLE [dbo].[TransferOutDetail] CHECK CONSTRAINT [FK_TransferOutDetail_Product_Varient]
GO
ALTER TABLE [dbo].[TransferOutDetail]  WITH CHECK ADD  CONSTRAINT [FK_TransferOutDetail_TransferOut] FOREIGN KEY([TransferOutId])
REFERENCES [dbo].[TransferOut] ([Id])
GO
ALTER TABLE [dbo].[TransferOutDetail] CHECK CONSTRAINT [FK_TransferOutDetail_TransferOut]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Company]
GO
USE [master]
GO
ALTER DATABASE [ims] SET  READ_WRITE 
GO
