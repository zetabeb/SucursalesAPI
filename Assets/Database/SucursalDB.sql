USE [master]
GO
/****** Object:  Database [SucursalDB]    Script Date: 1/04/2024 12:43:21 a. m. ******/
CREATE DATABASE [SucursalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SucursalDB', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SucursalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SucursalDB_log', FILENAME = N'E:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SucursalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SucursalDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SucursalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SucursalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SucursalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SucursalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SucursalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SucursalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SucursalDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SucursalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SucursalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SucursalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SucursalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SucursalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SucursalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SucursalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SucursalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SucursalDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SucursalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SucursalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SucursalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SucursalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SucursalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SucursalDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SucursalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SucursalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SucursalDB] SET  MULTI_USER 
GO
ALTER DATABASE [SucursalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SucursalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SucursalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SucursalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SucursalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SucursalDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SucursalDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SucursalDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SucursalDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/04/2024 12:43:21 a. m. ******/
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
/****** Object:  Table [dbo].[Sucursales]    Script Date: 1/04/2024 12:43:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[direccion] [nvarchar](max) NOT NULL,
	[telefono] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[horarioAtencion] [nvarchar](max) NOT NULL,
	[gerenteSucursal] [nvarchar](max) NOT NULL,
	[tipoMoneda] [nvarchar](max) NOT NULL,
	[fechaCreacion] [date] NOT NULL,
	[fechaUltimaActualizacion] [date] NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 1/04/2024 12:43:21 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[email] [nvarchar](max) NOT NULL,
	[clave] [nvarchar](max) NOT NULL,
	[fechaCreacion] [date] NOT NULL,
	[fechaUltimaActualizacion] [date] NOT NULL,
	[rol] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240331053821_Initial', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240331204720_ChangeColumnTypeSucursal', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401003440_AddUsuarioTable', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401041209_AddRolColumn', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240401050005_UpdateTypeColumns', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([id], [nombre], [direccion], [telefono], [email], [horarioAtencion], [gerenteSucursal], [tipoMoneda], [fechaCreacion], [fechaUltimaActualizacion]) VALUES (1, N'Alamos', N'Calle 5', N'3123456788', N'alamos@correo.com', N'08:00AM-05:00PM', N'Lucas Regente', N'COP', CAST(N'2022-01-01' AS Date), CAST(N'2023-12-31' AS Date))
INSERT [dbo].[Sucursales] ([id], [nombre], [direccion], [telefono], [email], [horarioAtencion], [gerenteSucursal], [tipoMoneda], [fechaCreacion], [fechaUltimaActualizacion]) VALUES (2, N'Madelena', N'Calle 3', N'3012345678', N'madelena@corre.com', N'08:00AM-06:00PM', N'Andrés Espinosa', N'COP', CAST(N'2022-01-02' AS Date), CAST(N'2024-01-01' AS Date))
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([id], [nombre], [email], [clave], [fechaCreacion], [fechaUltimaActualizacion], [rol]) VALUES (1, N'Juan Martinez', N'juan@correo.com', N'clavecifradaSHA6', CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), N'admin')
INSERT [dbo].[Usuarios] ([id], [nombre], [email], [clave], [fechaCreacion], [fechaUltimaActualizacion], [rol]) VALUES (2, N'Manuel Arvelaez', N'manuel@correo.com', N'clavecifradaSHA6', CAST(N'2021-01-01' AS Date), CAST(N'2021-01-01' AS Date), N'user')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (N'') FOR [rol]
GO
USE [master]
GO
ALTER DATABASE [SucursalDB] SET  READ_WRITE 
GO
