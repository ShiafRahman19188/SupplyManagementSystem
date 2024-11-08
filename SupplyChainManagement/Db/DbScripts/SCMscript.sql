USE [master]
GO
/****** Object:  Database [SCMDb]    Script Date: 11/3/2024 9:38:37 AM ******/
CREATE DATABASE [SCMDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SCMDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SCMDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SCMDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SCMDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SCMDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SCMDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SCMDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SCMDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SCMDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SCMDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SCMDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [SCMDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SCMDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SCMDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SCMDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SCMDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SCMDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SCMDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SCMDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SCMDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SCMDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SCMDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SCMDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SCMDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SCMDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SCMDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SCMDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SCMDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SCMDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SCMDb] SET  MULTI_USER 
GO
ALTER DATABASE [SCMDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SCMDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SCMDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SCMDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SCMDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SCMDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SCMDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [SCMDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SCMDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[deliveryUnits]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[deliveryUnits](
	[deliveryUnitId] [bigint] IDENTITY(1,1) NOT NULL,
	[deliveryUnitName] [nvarchar](max) NULL,
 CONSTRAINT [PK_deliveryUnits] PRIMARY KEY CLUSTERED 
(
	[deliveryUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[itemDetails]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[itemDetails](
	[itemDetailsId] [bigint] IDENTITY(1,1) NOT NULL,
	[itemName] [nvarchar](max) NULL,
	[purchaseRequisitionpr_id] [bigint] NOT NULL,
 CONSTRAINT [PK_itemDetails] PRIMARY KEY CLUSTERED 
(
	[itemDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[merchandisers]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[merchandisers](
	[merchandiserId] [bigint] IDENTITY(1,1) NOT NULL,
	[merchandiserName] [nvarchar](max) NULL,
 CONSTRAINT [PK_merchandisers] PRIMARY KEY CLUSTERED 
(
	[merchandiserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[purchaseRequisitions]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[purchaseRequisitions](
	[pr_id] [bigint] IDENTITY(1,1) NOT NULL,
	[pr_no] [nvarchar](max) NULL,
	[pr_date] [datetime2](7) NULL,
	[delivery_date] [datetime2](7) NULL,
	[merchandiserId] [bigint] NOT NULL,
	[supplierId] [bigint] NOT NULL,
	[deliveryUnitId] [bigint] NOT NULL,
 CONSTRAINT [PK_purchaseRequisitions] PRIMARY KEY CLUSTERED 
(
	[pr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[suppliers]    Script Date: 11/3/2024 9:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[suppliers](
	[supplierId] [bigint] IDENTITY(1,1) NOT NULL,
	[supplierName] [nvarchar](max) NULL,
 CONSTRAINT [PK_suppliers] PRIMARY KEY CLUSTERED 
(
	[supplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_itemDetails_purchaseRequisitionpr_id]    Script Date: 11/3/2024 9:38:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_itemDetails_purchaseRequisitionpr_id] ON [dbo].[itemDetails]
(
	[purchaseRequisitionpr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_purchaseRequisitions_deliveryUnitId]    Script Date: 11/3/2024 9:38:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_purchaseRequisitions_deliveryUnitId] ON [dbo].[purchaseRequisitions]
(
	[deliveryUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_purchaseRequisitions_merchandiserId]    Script Date: 11/3/2024 9:38:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_purchaseRequisitions_merchandiserId] ON [dbo].[purchaseRequisitions]
(
	[merchandiserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_purchaseRequisitions_supplierId]    Script Date: 11/3/2024 9:38:37 AM ******/
CREATE NONCLUSTERED INDEX [IX_purchaseRequisitions_supplierId] ON [dbo].[purchaseRequisitions]
(
	[supplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[itemDetails]  WITH CHECK ADD  CONSTRAINT [FK_itemDetails_purchaseRequisitions_purchaseRequisitionpr_id] FOREIGN KEY([purchaseRequisitionpr_id])
REFERENCES [dbo].[purchaseRequisitions] ([pr_id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[itemDetails] CHECK CONSTRAINT [FK_itemDetails_purchaseRequisitions_purchaseRequisitionpr_id]
GO
ALTER TABLE [dbo].[purchaseRequisitions]  WITH CHECK ADD  CONSTRAINT [FK_purchaseRequisitions_deliveryUnits_deliveryUnitId] FOREIGN KEY([deliveryUnitId])
REFERENCES [dbo].[deliveryUnits] ([deliveryUnitId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[purchaseRequisitions] CHECK CONSTRAINT [FK_purchaseRequisitions_deliveryUnits_deliveryUnitId]
GO
ALTER TABLE [dbo].[purchaseRequisitions]  WITH CHECK ADD  CONSTRAINT [FK_purchaseRequisitions_merchandisers_merchandiserId] FOREIGN KEY([merchandiserId])
REFERENCES [dbo].[merchandisers] ([merchandiserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[purchaseRequisitions] CHECK CONSTRAINT [FK_purchaseRequisitions_merchandisers_merchandiserId]
GO
ALTER TABLE [dbo].[purchaseRequisitions]  WITH CHECK ADD  CONSTRAINT [FK_purchaseRequisitions_suppliers_supplierId] FOREIGN KEY([supplierId])
REFERENCES [dbo].[suppliers] ([supplierId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[purchaseRequisitions] CHECK CONSTRAINT [FK_purchaseRequisitions_suppliers_supplierId]
GO
USE [master]
GO
ALTER DATABASE [SCMDb] SET  READ_WRITE 
GO
