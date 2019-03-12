IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'testDB')
BEGIN
CREATE DATABASE [testDB] ON  PRIMARY 
( NAME = N'testDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\testDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'testDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\testDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
END
GO
ALTER DATABASE [testDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [testDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [testDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [testDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [testDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [testDB] SET ARITHABORT OFF
GO
ALTER DATABASE [testDB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [testDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [testDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [testDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [testDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [testDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [testDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [testDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [testDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [testDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [testDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [testDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [testDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [testDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [testDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [testDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [testDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [testDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [testDB] SET  READ_WRITE
GO
ALTER DATABASE [testDB] SET RECOVERY FULL
GO
ALTER DATABASE [testDB] SET  MULTI_USER
GO
ALTER DATABASE [testDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [testDB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'testDB', N'ON'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_online_log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_online_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [nchar](10) NULL,
	[user_name] [nvarchar](50) NULL,
	[ip] [varchar](50) NULL,
	[timestamp] [nchar](13) NULL,
 CONSTRAINT [PK_user_online_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
