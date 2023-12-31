USE [Taksi]
GO
/****** Object:  Table [dbo].[KorisnickiNalog]    Script Date: 6/27/2023 12:36:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorisnickiNalog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](50) NOT NULL,
	[Prezime] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Sifra] [nvarchar](50) NOT NULL,
	[Kontakt] [nvarchar](50) NULL,
	[Aktivnost] [bit] NOT NULL,
 CONSTRAINT [PK_KorisnickiNalog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ulica]    Script Date: 6/27/2023 12:36:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ulica](
	[ID_Ulice] [int] IDENTITY(1,1) NOT NULL,
	[NazivUlice] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ulica] PRIMARY KEY CLUSTERED 
(
	[ID_Ulice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voznja]    Script Date: 6/27/2023 12:36:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voznja](
	[ID_Voznje] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[VremeVoznjeMin] [nvarchar](50) NOT NULL,
	[ID_Ulice] [int] NOT NULL,
 CONSTRAINT [PK_Voznja] PRIMARY KEY CLUSTERED 
(
	[ID_Voznje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Voznja]  WITH CHECK ADD  CONSTRAINT [FK_Voznja_KorisnickiNalog] FOREIGN KEY([ID])
REFERENCES [dbo].[KorisnickiNalog] ([ID])
GO
ALTER TABLE [dbo].[Voznja] CHECK CONSTRAINT [FK_Voznja_KorisnickiNalog]
GO
ALTER TABLE [dbo].[Voznja]  WITH CHECK ADD  CONSTRAINT [FK_Voznja_Ulica1] FOREIGN KEY([ID_Ulice])
REFERENCES [dbo].[Ulica] ([ID_Ulice])
GO
ALTER TABLE [dbo].[Voznja] CHECK CONSTRAINT [FK_Voznja_Ulica1]
GO
