USE [master]
GO
/****** Object:  Database [SocialDashboard]    Script Date: 28/05/2024 2:16:39 AM ******/
CREATE DATABASE [SocialDashboard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SocialDashboard', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SocialDashboard.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SocialDashboard_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SocialDashboard_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SocialDashboard] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialDashboard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialDashboard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialDashboard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialDashboard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialDashboard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialDashboard] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialDashboard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialDashboard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialDashboard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialDashboard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialDashboard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialDashboard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialDashboard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialDashboard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialDashboard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialDashboard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialDashboard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialDashboard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialDashboard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialDashboard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialDashboard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialDashboard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialDashboard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialDashboard] SET RECOVERY FULL 
GO
ALTER DATABASE [SocialDashboard] SET  MULTI_USER 
GO
ALTER DATABASE [SocialDashboard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialDashboard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialDashboard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialDashboard] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SocialDashboard] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SocialDashboard] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SocialDashboard', N'ON'
GO
ALTER DATABASE [SocialDashboard] SET QUERY_STORE = OFF
GO
USE [SocialDashboard]
GO
/****** Object:  User [sa2]    Script Date: 28/05/2024 2:16:40 AM ******/
CREATE USER [sa2] FOR LOGIN [sa2] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [sa2]
GO
/****** Object:  Table [dbo].[TblUsers]    Script Date: 28/05/2024 2:16:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](50) NULL,
	[Password] [nvarchar](250) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_TblUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblUserSocialMediaDetails]    Script Date: 28/05/2024 2:16:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblUserSocialMediaDetails](
	[UserSocialMediaID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[FacebookLink] [nvarchar](500) NULL,
	[InstagramLink] [nvarchar](500) NULL,
	[TwitterLink] [nvarchar](500) NULL,
	[OtherLink] [nvarchar](500) NULL,
	[CurrentLocation] [nvarchar](500) NULL,
	[Longitude] [nvarchar](50) NULL,
	[Latitude] [nvarchar](50) NULL,
 CONSTRAINT [PK_TblUserSocialMediaDetails] PRIMARY KEY CLUSTERED 
(
	[UserSocialMediaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TblUsers] ON 
GO
INSERT [dbo].[TblUsers] ([UserID], [FirstName], [LastName], [MobileNo], [Password], [RoleID]) VALUES (1, N'testte', N'test', N'9898012345', N'123456', 2)
GO
SET IDENTITY_INSERT [dbo].[TblUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[TblUserSocialMediaDetails] ON 
GO
INSERT [dbo].[TblUserSocialMediaDetails] ([UserSocialMediaID], [UserID], [FacebookLink], [InstagramLink], [TwitterLink], [OtherLink], [CurrentLocation], [Longitude], [Latitude]) VALUES (1, 1, N'test', N'test', N'test', N'test', N'', N'23.0225', N'72.5714')
GO
SET IDENTITY_INSERT [dbo].[TblUserSocialMediaDetails] OFF
GO
USE [master]
GO
ALTER DATABASE [SocialDashboard] SET  READ_WRITE 
GO
