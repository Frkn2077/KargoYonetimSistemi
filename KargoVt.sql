USE [KargoVt]
GO
/****** Object:  Table [dbo].[Adresler]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adresler](
	[AdresID] [int] IDENTITY(1,1) NOT NULL,
	[Sehir] [varchar](50) NULL,
	[İlce] [varchar](50) NULL,
	[Mahalle] [varchar](50) NULL,
	[DetaylıAdres] [text] NULL,
	[KullanıcıID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdresID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GonderiDurumlar]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GonderiDurumlar](
	[GonderiDurumID] [int] IDENTITY(1,1) NOT NULL,
	[DurumAdi] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[GonderiDurumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gonderiler]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gonderiler](
	[GonderiID] [int] IDENTITY(1,1) NOT NULL,
	[Gonderikodu] [varchar](20) NULL,
	[GonderenID] [int] NULL,
	[AliciID] [int] NULL,
	[GonderiDurumID] [int] NULL,
	[OlusturlmaTarihi] [datetime] NULL,
	[TeslimTarihi] [datetime] NULL,
	[TeslimAlanKisi] [varchar](50) NULL,
	[KargoUcreti] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[GonderiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[İstatistikler]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[İstatistikler](
	[IstatıstıkID] [int] IDENTITY(1,1) NOT NULL,
	[GonderiSayısı] [int] NULL,
	[TeslimEdilenSayisi] [int] NULL,
	[IadeSayisi] [int] NULL,
	[ToplamKazanc] [decimal](15, 2) NULL,
	[HAFTA] [date] NULL,
	[AY] [date] NULL,
	[YIL] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IstatıstıkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KargoTakip]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KargoTakip](
	[TakıpID] [int] IDENTITY(1,1) NOT NULL,
	[GonderiID] [int] NULL,
	[Konum] [varchar](100) NULL,
	[TarihSaat] [datetime] NULL,
	[Acıklama] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[TakıpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KargoUcretleri]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KargoUcretleri](
	[KargoUcretID] [int] IDENTITY(1,1) NOT NULL,
	[AgırlıkMin] [decimal](5, 2) NULL,
	[AGIRLIKMAX] [decimal](5, 2) NULL,
	[HassasiyetDurumu] [bit] NULL,
	[Ucret] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[KargoUcretID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanıcılar]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanıcılar](
	[KullanıcıID] [int] IDENTITY(1,1) NOT NULL,
	[AD] [varchar](50) NULL,
	[SOYAD] [varchar](50) NULL,
	[EMAİL] [varchar](100) NULL,
	[TELEFON] [varchar](15) NULL,
	[AdresID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[KullanıcıID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kuryeler]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kuryeler](
	[KuryeID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](100) NULL,
	[Telefon] [varchar](15) NULL,
	[Plaka] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[KuryeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeGonderi]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeGonderi](
	[OdemeGonderiID] [int] IDENTITY(1,1) NOT NULL,
	[GonderiID] [int] NULL,
	[OdemeID] [int] NULL,
	[OdemeTutarı] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[OdemeGonderiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Odemeler]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Odemeler](
	[OdemeID] [int] IDENTITY(1,1) NOT NULL,
	[GonderiID] [int] NULL,
	[OdemeTutari] [decimal](10, 2) NULL,
	[OdemeTarihi] [datetime] NULL,
	[OdemeYontemID] [int] NULL,
	[OdemeDurumu] [varchar](50) NULL,
	[Konum] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[OdemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OdemeYontemleri]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdemeYontemleri](
	[OdemeYontemiID] [int] IDENTITY(1,1) NOT NULL,
	[YontemAdi] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[OdemeYontemiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUBEGonderiİliski]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUBEGonderiİliski](
	[SgID] [int] IDENTITY(1,1) NOT NULL,
	[SubeID] [int] NULL,
	[GonderiID] [int] NULL,
	[Tarihsaat] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[SgID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SUBELER]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SUBELER](
	[SubeID] [int] IDENTITY(1,1) NOT NULL,
	[SubeAdi] [varchar](100) NULL,
	[AdresID] [int] NULL,
	[Telefon] [varchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[SubeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teslimatlar]    Script Date: 1.04.2025 19:09:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teslimatlar](
	[TeslimatID] [int] IDENTITY(1,1) NOT NULL,
	[KuryeID] [int] NULL,
	[GonderiID] [int] NULL,
	[TeslimDurumu] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[TeslimatID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Gonderil__627989EC718FE7E0]    Script Date: 1.04.2025 19:09:54 ******/
ALTER TABLE [dbo].[Gonderiler] ADD UNIQUE NONCLUSTERED 
(
	[Gonderikodu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kullanıc__085A29EFCD24CF6D]    Script Date: 1.04.2025 19:09:54 ******/
ALTER TABLE [dbo].[Kullanıcılar] ADD UNIQUE NONCLUSTERED 
(
	[TELEFON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kullanıc__1286C73CCC94949A]    Script Date: 1.04.2025 19:09:54 ******/
ALTER TABLE [dbo].[Kullanıcılar] ADD UNIQUE NONCLUSTERED 
(
	[EMAİL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kuryeler__830E30F73F01635A]    Script Date: 1.04.2025 19:09:54 ******/
ALTER TABLE [dbo].[Kuryeler] ADD UNIQUE NONCLUSTERED 
(
	[Plaka] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kuryeler__92EB4169EB415683]    Script Date: 1.04.2025 19:09:54 ******/
ALTER TABLE [dbo].[Kuryeler] ADD UNIQUE NONCLUSTERED 
(
	[Telefon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adresler]  WITH CHECK ADD  CONSTRAINT [deneme1] FOREIGN KEY([KullanıcıID])
REFERENCES [dbo].[Kullanıcılar] ([KullanıcıID])
GO
ALTER TABLE [dbo].[Adresler] CHECK CONSTRAINT [deneme1]
GO
ALTER TABLE [dbo].[Gonderiler]  WITH CHECK ADD FOREIGN KEY([AliciID])
REFERENCES [dbo].[Kullanıcılar] ([KullanıcıID])
GO
ALTER TABLE [dbo].[Gonderiler]  WITH CHECK ADD FOREIGN KEY([GonderenID])
REFERENCES [dbo].[Kullanıcılar] ([KullanıcıID])
GO
ALTER TABLE [dbo].[Gonderiler]  WITH CHECK ADD FOREIGN KEY([GonderiDurumID])
REFERENCES [dbo].[GonderiDurumlar] ([GonderiDurumID])
GO
ALTER TABLE [dbo].[KargoTakip]  WITH CHECK ADD FOREIGN KEY([GonderiID])
REFERENCES [dbo].[Gonderiler] ([GonderiID])
GO
ALTER TABLE [dbo].[Kullanıcılar]  WITH CHECK ADD  CONSTRAINT [deneme] FOREIGN KEY([AdresID])
REFERENCES [dbo].[Adresler] ([AdresID])
GO
ALTER TABLE [dbo].[Kullanıcılar] CHECK CONSTRAINT [deneme]
GO
ALTER TABLE [dbo].[OdemeGonderi]  WITH CHECK ADD FOREIGN KEY([GonderiID])
REFERENCES [dbo].[Gonderiler] ([GonderiID])
GO
ALTER TABLE [dbo].[OdemeGonderi]  WITH CHECK ADD FOREIGN KEY([OdemeID])
REFERENCES [dbo].[Odemeler] ([OdemeID])
GO
ALTER TABLE [dbo].[Odemeler]  WITH CHECK ADD FOREIGN KEY([GonderiID])
REFERENCES [dbo].[Gonderiler] ([GonderiID])
GO
ALTER TABLE [dbo].[Odemeler]  WITH CHECK ADD FOREIGN KEY([OdemeYontemID])
REFERENCES [dbo].[OdemeYontemleri] ([OdemeYontemiID])
GO
ALTER TABLE [dbo].[SUBEGonderiİliski]  WITH CHECK ADD FOREIGN KEY([GonderiID])
REFERENCES [dbo].[Gonderiler] ([GonderiID])
GO
ALTER TABLE [dbo].[SUBEGonderiİliski]  WITH CHECK ADD FOREIGN KEY([SubeID])
REFERENCES [dbo].[SUBELER] ([SubeID])
GO
ALTER TABLE [dbo].[SUBELER]  WITH CHECK ADD FOREIGN KEY([AdresID])
REFERENCES [dbo].[Adresler] ([AdresID])
GO
ALTER TABLE [dbo].[Teslimatlar]  WITH CHECK ADD FOREIGN KEY([GonderiID])
REFERENCES [dbo].[Gonderiler] ([GonderiID])
GO
ALTER TABLE [dbo].[Teslimatlar]  WITH CHECK ADD FOREIGN KEY([KuryeID])
REFERENCES [dbo].[Kuryeler] ([KuryeID])
GO
