USE [master]
GO
/****** Object:  Database [JuegoTrucoBD]    Script Date: 16/11/2022 02:40:45 ******/
CREATE DATABASE [JuegoTrucoBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JuegoTrucoBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JuegoTrucoBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JuegoTrucoBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JuegoTrucoBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JuegoTrucoBD] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JuegoTrucoBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JuegoTrucoBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JuegoTrucoBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JuegoTrucoBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JuegoTrucoBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JuegoTrucoBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET RECOVERY FULL 
GO
ALTER DATABASE [JuegoTrucoBD] SET  MULTI_USER 
GO
ALTER DATABASE [JuegoTrucoBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JuegoTrucoBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JuegoTrucoBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JuegoTrucoBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JuegoTrucoBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JuegoTrucoBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JuegoTrucoBD', N'ON'
GO
ALTER DATABASE [JuegoTrucoBD] SET QUERY_STORE = OFF
GO
USE [JuegoTrucoBD]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 16/11/2022 02:40:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[partidasJugadas] [int] NOT NULL,
	[partidasGanadas] [int] NOT NULL,
	[partidasPerdidas] [int] NOT NULL,
	[esUsuario] [bit] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (1, N'BOT-Juan', 22, 7, 15, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (2, N'BOT-Mica', 14, 6, 8, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (3, N'BOT-Nahuel', 19, 10, 9, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (4, N'BOT-Luca', 24, 17, 7, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (5, N'Nathan', 29, 18, 11, 1)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (6, N'BOT-Pedro', 6, 2, 4, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (7, N'BOT-Juan', 8, 4, 4, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (8, N'BOT-Sergio', 6, 1, 5, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (9, N'BOT-Santi', 5, 2, 3, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (10, N'Bot-Pepe', 6, 2, 4, 0)
INSERT [dbo].[Jugadores] ([id], [nombre], [partidasJugadas], [partidasGanadas], [partidasPerdidas], [esUsuario]) VALUES (11, N'Bot-Tito', 4, 3, 1, 0)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
USE [master]
GO
ALTER DATABASE [JuegoTrucoBD] SET  READ_WRITE 
GO
