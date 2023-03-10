USE [master]
GO
/****** Object:  Database [Igraonica_radnik]    Script Date: 12/1/2020 6:58:07 PM ******/
CREATE DATABASE [Igraonica_radnik] ON  PRIMARY 
( NAME = N'Igraonica_radnik', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Igraonica_radnik.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Igraonica_radnik_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Igraonica_radnik_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Igraonica_radnik] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Igraonica_radnik].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Igraonica_radnik] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET ARITHABORT OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Igraonica_radnik] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Igraonica_radnik] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Igraonica_radnik] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Igraonica_radnik] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Igraonica_radnik] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Igraonica_radnik] SET  MULTI_USER 
GO
ALTER DATABASE [Igraonica_radnik] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Igraonica_radnik] SET DB_CHAINING OFF 
GO
USE [Igraonica_radnik]
GO
/****** Object:  Table [dbo].[igraonica]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[igraonica](
	[id_igraonica] [int] IDENTITY(1,1) NOT NULL,
	[reg_broj] [nvarchar](20) NOT NULL,
	[vlasnik] [varchar](50) NOT NULL,
	[naziv] [varchar](50) NOT NULL,
	[adresa] [varchar](50) NOT NULL,
	[br_telefona] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_igraonica] PRIMARY KEY CLUSTERED 
(
	[id_igraonica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[igraonica_mjesto]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[igraonica_mjesto](
	[id_igraonica_mjesto] [int] IDENTITY(1,1) NOT NULL,
	[id_igraonica] [int] NOT NULL,
	[id_mjesto] [int] NOT NULL,
 CONSTRAINT [PK_igraonica_mjesto] PRIMARY KEY CLUSTERED 
(
	[id_igraonica_mjesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[komponente]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[komponente](
	[id_komponenta] [int] IDENTITY(1,1) NOT NULL,
	[ime_proizvoda] [varchar](50) NOT NULL,
	[id_racunar] [int] NOT NULL,
	[ime] [varchar](50) NULL,
	[kolicina_memorije] [varchar](50) NULL,
	[dimenzija] [float] NULL,
	[tip_ram] [varchar](50) NULL,
	[kapacitet] [varchar](50) NULL,
	[brzina_obrtaja] [varchar](50) NULL,
	[cipset] [varchar](50) NULL,
	[frekvencija_rada] [varchar](50) NULL,
	[broj_jezgara] [int] NULL,
	[id_tip_komponente] [int] NOT NULL,
 CONSTRAINT [PK_komponente] PRIMARY KEY CLUSTERED 
(
	[id_komponenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mjesto]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mjesto](
	[id_mjesto] [int] IDENTITY(1,1) NOT NULL,
	[ptt] [varchar](35) NOT NULL,
	[naziv] [varchar](30) NOT NULL,
 CONSTRAINT [PK_mjesto] PRIMARY KEY CLUSTERED 
(
	[id_mjesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[racunar]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[racunar](
	[id_racunar] [int] IDENTITY(1,1) NOT NULL,
	[br_racunara] [int] NOT NULL,
	[mrezno_ime] [varchar](50) NOT NULL,
	[id_igraonica] [int] NOT NULL,
	[id_tip_racunara] [int] NULL,
 CONSTRAINT [PK_racunar] PRIMARY KEY CLUSTERED 
(
	[id_racunar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[radnik]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[radnik](
	[id_radnik] [int] IDENTITY(1,1) NOT NULL,
	[jmbg] [varchar](50) NOT NULL,
	[ime] [varchar](50) NOT NULL,
	[prezime] [varchar](50) NOT NULL,
	[datum_zaposlenja] [date] NOT NULL,
	[plata] [varchar](50) NOT NULL,
	[id_igraonica] [int] NOT NULL,
	[id_mjesto] [int] NOT NULL,
 CONSTRAINT [PK_radnik] PRIMARY KEY CLUSTERED 
(
	[id_radnik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tip_komponente]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tip_komponente](
	[id_tip_komponente] [int] IDENTITY(1,1) NOT NULL,
	[vrsta_komponenta] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tip_komponente] PRIMARY KEY CLUSTERED 
(
	[id_tip_komponente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tip_racunara]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tip_racunara](
	[id_tip_racunara] [int] IDENTITY(1,1) NOT NULL,
	[tip_racunara] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tip_racunara] PRIMARY KEY CLUSTERED 
(
	[id_tip_racunara] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[igraonica_mjesto]  WITH CHECK ADD  CONSTRAINT [FK_igraonica_mjesto_igraonica] FOREIGN KEY([id_igraonica])
REFERENCES [dbo].[igraonica] ([id_igraonica])
GO
ALTER TABLE [dbo].[igraonica_mjesto] CHECK CONSTRAINT [FK_igraonica_mjesto_igraonica]
GO
ALTER TABLE [dbo].[igraonica_mjesto]  WITH CHECK ADD  CONSTRAINT [FK_igraonica_mjesto_mjesto] FOREIGN KEY([id_mjesto])
REFERENCES [dbo].[mjesto] ([id_mjesto])
GO
ALTER TABLE [dbo].[igraonica_mjesto] CHECK CONSTRAINT [FK_igraonica_mjesto_mjesto]
GO
ALTER TABLE [dbo].[komponente]  WITH CHECK ADD  CONSTRAINT [FK_komponente_racunar] FOREIGN KEY([id_racunar])
REFERENCES [dbo].[racunar] ([id_racunar])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[komponente] CHECK CONSTRAINT [FK_komponente_racunar]
GO
ALTER TABLE [dbo].[komponente]  WITH CHECK ADD  CONSTRAINT [FK_komponente_tip_komponente] FOREIGN KEY([id_tip_komponente])
REFERENCES [dbo].[tip_komponente] ([id_tip_komponente])
GO
ALTER TABLE [dbo].[komponente] CHECK CONSTRAINT [FK_komponente_tip_komponente]
GO
ALTER TABLE [dbo].[racunar]  WITH CHECK ADD  CONSTRAINT [FK_racunar_igraonica] FOREIGN KEY([id_igraonica])
REFERENCES [dbo].[igraonica] ([id_igraonica])
GO
ALTER TABLE [dbo].[racunar] CHECK CONSTRAINT [FK_racunar_igraonica]
GO
ALTER TABLE [dbo].[racunar]  WITH CHECK ADD  CONSTRAINT [FK_racunar_tip_racunara] FOREIGN KEY([id_tip_racunara])
REFERENCES [dbo].[tip_racunara] ([id_tip_racunara])
GO
ALTER TABLE [dbo].[racunar] CHECK CONSTRAINT [FK_racunar_tip_racunara]
GO
ALTER TABLE [dbo].[radnik]  WITH CHECK ADD  CONSTRAINT [FK_radnik_igraonica] FOREIGN KEY([id_igraonica])
REFERENCES [dbo].[igraonica] ([id_igraonica])
GO
ALTER TABLE [dbo].[radnik] CHECK CONSTRAINT [FK_radnik_igraonica]
GO
ALTER TABLE [dbo].[radnik]  WITH CHECK ADD  CONSTRAINT [FK_radnik_mjesto] FOREIGN KEY([id_mjesto])
REFERENCES [dbo].[mjesto] ([id_mjesto])
GO
ALTER TABLE [dbo].[radnik] CHECK CONSTRAINT [FK_radnik_mjesto]
GO
/****** Object:  StoredProcedure [dbo].[DodajGraficku]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajGraficku]
@ime_proizvoda varchar(50),
@id_racunar int,
@ime varchar(50),
@kolicina_memorije varchar(50),
@id_tip_komponente int
AS
BEGIN
INSERT INTO dbo.komponente(ime_proizvoda,id_racunar,ime,kolicina_memorije,id_tip_komponente)
VALUES(@ime_proizvoda,@id_racunar,@ime,@kolicina_memorije,@id_tip_komponente);
END

GO
/****** Object:  StoredProcedure [dbo].[DodajMaticnuPlocu]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajMaticnuPlocu]
@ime_proizvoda varchar(50),
@id_racunar int,
@cipset varchar(50),
@id_tip_komponente int
AS
BEGIN
INSERT INTO dbo.komponente(ime_proizvoda,id_racunar,cipset,id_tip_komponente)
VALUES(@ime_proizvoda,@id_racunar,@cipset,@id_tip_komponente);
END

GO
/****** Object:  StoredProcedure [dbo].[DodajMjesto]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DodajMjesto]
@id_mjesto int out,
@ptt varchar(35),
@naziv varchar(30)
AS
BEGIN
INSERT INTO dbo.mjesto(ptt,naziv)
VALUES (@ptt,@naziv);
select @id_mjesto=SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[DodajNovogRadnika]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajNovogRadnika]
@jmbg varchar(50),
@ime varchar(50),
@prezime varchar(50),
@datum_zaposlenja date,
@plata varchar(50),
@id_igraonica int,
@id_mjesto int
AS
BEGIN

	
		INSERT INTO dbo.radnik(jmbg,ime,prezime,datum_zaposlenja,plata,id_igraonica,id_mjesto)
		VALUES(@jmbg,@ime,@prezime,@datum_zaposlenja,@plata,@id_igraonica,@id_mjesto)
   
END

GO
/****** Object:  StoredProcedure [dbo].[DodajProcesor]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajProcesor]
@ime_proizvoda varchar(50),
@id_racunar int,
@frekvencija_rada varchar(50),
@broj_jezgara int,
@id_tip_komponente int
AS
BEGIN
INSERT INTO dbo.komponente(ime_proizvoda,id_racunar,frekvencija_rada,broj_jezgara,id_tip_komponente)
VALUES(@ime_proizvoda,@id_racunar,@frekvencija_rada,@broj_jezgara,@id_tip_komponente);
END

GO
/****** Object:  StoredProcedure [dbo].[DodajRacunar]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajRacunar]
@id_racunar int out,
@br_racunara int,
@mrezno_ime varchar(50),
@id_igraonica int,
@id_tip_racunara int
AS
BEGIN
INSERT into dbo.racunar(br_racunara,mrezno_ime,id_igraonica,id_tip_racunara)
VALUES(@br_racunara,@mrezno_ime,@id_igraonica,@id_tip_racunara);
SELECT @id_racunar=SCOPE_IDENTITY();
END

GO
/****** Object:  StoredProcedure [dbo].[DodajRAM]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DodajRAM]
@ime_proizvoda varchar(50),
@id_racunar int,
@kolicina_memorije varchar(50),
@tip_ram varchar(50),
@id_tip_komponente int
AS
BEGIN
INSERT INTO dbo.komponente(ime_proizvoda,id_racunar,kolicina_memorije,tip_ram,id_tip_komponente)
VALUES(@ime_proizvoda,@id_racunar,@kolicina_memorije,@tip_ram,@id_tip_komponente);
END

GO
/****** Object:  StoredProcedure [dbo].[IzbrisiRadnika]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IzbrisiRadnika]
@id_radnik int
AS
BEGIN

	SET NOCOUNT ON;
	DELETE FROM dbo.radnik WHERE id_radnik=@id_radnik

END

GO
/****** Object:  StoredProcedure [dbo].[IzlistajMjestaIgraonica]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IzlistajMjestaIgraonica]

AS
BEGIN
SELECT m.id_mjesto,m.ptt,m.naziv
FROM dbo.igraonica i INNER JOIN dbo.igraonica_mjesto im
ON i.id_igraonica=im.id_igraonica
INNER JOIN dbo.mjesto m
ON m.id_mjesto=im.id_mjesto
END

GO
/****** Object:  StoredProcedure [dbo].[MaticnaPloca]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MaticnaPloca]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='maticna_ploca';
END

GO
/****** Object:  StoredProcedure [dbo].[ObrisiRacunar]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObrisiRacunar]
@id_racunar int
AS
BEGIN
DELETE from dbo.racunar where id_racunar=@id_racunar;
END

GO
/****** Object:  StoredProcedure [dbo].[PopuniMjestRadnicima]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PopuniMjestRadnicima]
@id_mjesto int
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * from dbo.mjesto where id_mjesto=@id_mjesto;
END

GO
/****** Object:  StoredProcedure [dbo].[PopuniRadnike]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PopuniRadnike]
@id_igraonica int	
AS
BEGIN

	SET NOCOUNT ON;
	SELECT * FROM dbo.radnik WHERE id_igraonica=@id_igraonica;

END

GO
/****** Object:  StoredProcedure [dbo].[PupuniIgraonica]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PupuniIgraonica]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	Select * from dbo.igraonica

END

GO
/****** Object:  StoredProcedure [dbo].[Ucitaj_Komponente_Osnovno]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ucitaj_Komponente_Osnovno]
@id_racunar int
AS
BEGIN
SELECT * from komponente where id_racunar=@id_racunar;

END

GO
/****** Object:  StoredProcedure [dbo].[Ucitajdvd]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Ucitajdvd]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='dvd'
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajDvD1]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UcitajDvD1]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='dvd';
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajGraficku]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UcitajGraficku]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='graficka_karta';
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajMjesta]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UcitajMjesta]
	
AS
BEGIN
SELECT * FROM dbo.mjesto;

 
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajMonitor]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UcitajMonitor]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='monitor';
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajProcesor]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UcitajProcesor]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='procesor';
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajRacunare]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UcitajRacunare]
@id_igraonica int	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * from dbo.racunar WHERE id_igraonica=@id_igraonica

END

GO
/****** Object:  StoredProcedure [dbo].[UcitajRam]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UcitajRam]
@id_racunar int
AS
BEGIN
SELECT * from komponente,tip_komponente where id_racunar=@id_racunar and komponente.id_tip_komponente=tip_komponente.id_tip_komponente and tip_komponente.vrsta_komponenta='ram';
END

GO
/****** Object:  StoredProcedure [dbo].[UcitajVrstuKomponente]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UcitajVrstuKomponente]
@id_tip_komponente int
AS
BEGIN
SELECT vrsta_komponenta from dbo.tip_komponente where id_tip_komponente=@id_tip_komponente;
END

GO
/****** Object:  StoredProcedure [dbo].[Vrati_Tip_Komponente]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Vrati_Tip_Komponente]
@vrsta_komponenta varchar(50)
AS
BEGIN
SELECT id_tip_komponente from dbo.tip_komponente where  vrsta_komponenta=@vrsta_komponenta;
END

GO
/****** Object:  StoredProcedure [dbo].[Vrati_Tip_Racunara]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Vrati_Tip_Racunara]
@id_tip_racunara int
	
AS
BEGIN
	SET NOCOUNT ON;
	select tip_racunara from dbo.tip_racunara where id_tip_racunara=@id_tip_racunara;

END

GO
/****** Object:  StoredProcedure [dbo].[VratiIdZaTipRacunara]    Script Date: 12/1/2020 6:58:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[VratiIdZaTipRacunara] 
@tip_racunara varchar(50)
AS
BEGIN
SELECt id_tip_racunara from dbo.tip_racunara where tip_racunara=@tip_racunara;
END

GO
USE [master]
GO
ALTER DATABASE [Igraonica_radnik] SET  READ_WRITE 
GO
