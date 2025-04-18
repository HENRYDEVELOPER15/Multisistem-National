USE [master]
GO
/****** Object:  Database [Reporte]    Script Date: 22/02/2025 16:44:01 ******/
CREATE DATABASE [Reporte]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Reporte', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JJ\MSSQL\DATA\Reporte.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Reporte_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.JJ\MSSQL\DATA\Reporte_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Reporte] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Reporte].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Reporte] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Reporte] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Reporte] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Reporte] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Reporte] SET ARITHABORT OFF 
GO
ALTER DATABASE [Reporte] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Reporte] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Reporte] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Reporte] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Reporte] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Reporte] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Reporte] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Reporte] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Reporte] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Reporte] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Reporte] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Reporte] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Reporte] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Reporte] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Reporte] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Reporte] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Reporte] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Reporte] SET RECOVERY FULL 
GO
ALTER DATABASE [Reporte] SET  MULTI_USER 
GO
ALTER DATABASE [Reporte] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Reporte] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Reporte] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Reporte] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Reporte] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Reporte] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Reporte', N'ON'
GO
ALTER DATABASE [Reporte] SET QUERY_STORE = OFF
GO
USE [Reporte]
GO
/****** Object:  Table [dbo].[Cambios]    Script Date: 22/02/2025 16:44:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cambios](
	[Id_Cambio] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Repuesto] [nvarchar](100) NULL,
	[Serial_Defectuoso] [nvarchar](100) NULL,
	[Serial_Nuevo] [nvarchar](100) NULL,
	[id_Equipo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cambio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Dirección] [nvarchar](255) NULL,
	[Contrato] [nvarchar](100) NULL,
	[id_Equipo] [int] NULL,
	[id_Responsable] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipo]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipo](
	[id_Equipo] [int] IDENTITY(1,1) NOT NULL,
	[Equipo] [nvarchar](100) NULL,
	[Marca] [nvarchar](100) NULL,
	[Modelo] [nvarchar](100) NULL,
	[Serial] [nvarchar](100) NULL,
	[Fallas_Observación] [nvarchar](max) NULL,
	[Acciones] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_Equipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Escaner]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Escaner](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [nvarchar](max) NULL,
	[Fecha] [date] NULL,
	[id_impresora] [int] NULL,
	[id_Empresa] [int] NULL,
 CONSTRAINT [PK_Escaner] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Impresoras]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Impresoras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](max) NULL,
	[Modelo] [nvarchar](max) NULL,
	[Serial] [nvarchar](max) NULL,
	[Nombre] [nvarchar](max) NULL,
	[id_Empresa] [int] NULL,
 CONSTRAINT [PK_Impresoras] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Informe]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Informe](
	[Id_Informe] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[IngMantenimiento] [nvarchar](100) NULL,
	[Id_Empresa] [int] NULL,
	[Servicio] [nchar](200) NULL,
	[Facturar] [nchar](10) NULL,
	[Pendiente] [nchar](10) NULL,
	[fa] [datetime] NULL,
	[fs] [datetime] NULL,
	[actualizar] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Informe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Responsable]    Script Date: 22/02/2025 16:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Responsable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Oficina] [varchar](50) NULL,
	[Telefono] [numeric](20, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cambios]  WITH NOCHECK ADD FOREIGN KEY([id_Equipo])
REFERENCES [dbo].[Equipo] ([id_Equipo])
GO
ALTER TABLE [dbo].[Empresa]  WITH NOCHECK ADD FOREIGN KEY([id_Equipo])
REFERENCES [dbo].[Equipo] ([id_Equipo])
GO
ALTER TABLE [dbo].[Empresa]  WITH NOCHECK ADD  CONSTRAINT [FK_Empresa_Responsable] FOREIGN KEY([id_Responsable])
REFERENCES [dbo].[Responsable] ([id])
GO
ALTER TABLE [dbo].[Empresa] NOCHECK CONSTRAINT [FK_Empresa_Responsable]
GO
ALTER TABLE [dbo].[Escaner]  WITH CHECK ADD  CONSTRAINT [FK_Escaner_Impresoras] FOREIGN KEY([id_impresora])
REFERENCES [dbo].[Impresoras] ([id])
GO
ALTER TABLE [dbo].[Escaner] CHECK CONSTRAINT [FK_Escaner_Impresoras]
GO
ALTER TABLE [dbo].[Impresoras]  WITH CHECK ADD  CONSTRAINT [FK_Impresoras_Empresa] FOREIGN KEY([id_Empresa])
REFERENCES [dbo].[Empresa] ([id_Empresa])
GO
ALTER TABLE [dbo].[Impresoras] CHECK CONSTRAINT [FK_Impresoras_Empresa]
GO
ALTER TABLE [dbo].[Informe]  WITH NOCHECK ADD FOREIGN KEY([Id_Empresa])
REFERENCES [dbo].[Empresa] ([id_Empresa])
GO
USE [master]
GO
ALTER DATABASE [Reporte] SET  READ_WRITE 
GO
