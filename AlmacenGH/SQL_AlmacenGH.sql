USE master
GO
CREATE DATABASE AlmacenGH
GO

USE [AlmacenGH]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[Nif] [nchar](9) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Logo] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[Nif] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familias]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familias](
	[IdFamilia] [nvarchar](10) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Familias] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FamiliasProductos]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FamiliasProductos](
	[IdFamilia] [nvarchar](10) NOT NULL,
	[IdProducto] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_FamiliaProducto] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [nvarchar](10) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Stock] [int] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[IdTicket] [nvarchar](10) NOT NULL,
	[Fecha] [date] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[IdTicket] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketsProductos]    Script Date: 04/01/2021 12:39:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketsProductos](
	[IdTicket] [nvarchar](10) NOT NULL,
	[IdProducto] [nvarchar](10) NOT NULL,
	[Precio] [float] NOT NULL,
	[CantidadVendida] [int] NOT NULL,
 CONSTRAINT [PK_TicketsProductos] PRIMARY KEY CLUSTERED 
(
	[IdTicket] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Empresa] ([Nif], [Nombre], [Logo]) VALUES (N'45961276Z', N'Eroski', N'https://logosandtypes.com/wp-content/uploads/2020/06/eroski.png')
GO
INSERT [dbo].[Familias] ([IdFamilia], [Descripcion]) VALUES (N'1', N'Familia1')
GO
INSERT [dbo].[Familias] ([IdFamilia], [Descripcion]) VALUES (N'2', N'Familia2')
GO
INSERT [dbo].[Familias] ([IdFamilia], [Descripcion]) VALUES (N'3', N'Familia3')
GO
INSERT [dbo].[Familias] ([IdFamilia], [Descripcion]) VALUES (N'4', N'Familia4')
GO
INSERT [dbo].[FamiliasProductos] ([IdFamilia], [IdProducto]) VALUES (N'1', N'3')
GO
INSERT [dbo].[FamiliasProductos] ([IdFamilia], [IdProducto]) VALUES (N'2', N'1')
GO
INSERT [dbo].[FamiliasProductos] ([IdFamilia], [IdProducto]) VALUES (N'3', N'4')
GO
INSERT [dbo].[FamiliasProductos] ([IdFamilia], [IdProducto]) VALUES (N'4', N'2')
GO
INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [Stock], [StockMinimo], [Precio]) VALUES (N'1', N'Manzana', 100, 20, 1)
GO
INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [Stock], [StockMinimo], [Precio]) VALUES (N'2', N'Sandia', 11, 10, 3)
GO
INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [Stock], [StockMinimo], [Precio]) VALUES (N'3', N'Chuleta', 6, 5, 30)
GO
INSERT [dbo].[Productos] ([IdProducto], [Descripcion], [Stock], [StockMinimo], [Precio]) VALUES (N'4', N'Queso', 20, 4, 5.3)
GO
INSERT [dbo].[Tickets] ([IdTicket], [Fecha]) VALUES (N'1', CAST(N'2019-10-10' AS Date))
GO
INSERT [dbo].[Tickets] ([IdTicket], [Fecha]) VALUES (N'2', CAST(N'2020-06-23' AS Date))
GO
INSERT [dbo].[Tickets] ([IdTicket], [Fecha]) VALUES (N'3', CAST(N'2019-02-06' AS Date))
GO
INSERT [dbo].[Tickets] ([IdTicket], [Fecha]) VALUES (N'4', CAST(N'2020-12-22' AS Date))
GO
INSERT [dbo].[TicketsProductos] ([IdTicket], [IdProducto], [Precio], [CantidadVendida]) VALUES (N'1', N'2', 6, 2)
GO
INSERT [dbo].[TicketsProductos] ([IdTicket], [IdProducto], [Precio], [CantidadVendida]) VALUES (N'2', N'4', 15, 3)
GO
INSERT [dbo].[TicketsProductos] ([IdTicket], [IdProducto], [Precio], [CantidadVendida]) VALUES (N'3', N'1', 7, 7)
GO
INSERT [dbo].[TicketsProductos] ([IdTicket], [IdProducto], [Precio], [CantidadVendida]) VALUES (N'4', N'3', 60, 2)
GO
ALTER TABLE [dbo].[FamiliasProductos]  WITH CHECK ADD  CONSTRAINT [FK_FamiliasProductos_Familias] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familias] ([IdFamilia])
GO
ALTER TABLE [dbo].[FamiliasProductos] CHECK CONSTRAINT [FK_FamiliasProductos_Familias]
GO
ALTER TABLE [dbo].[FamiliasProductos]  WITH CHECK ADD  CONSTRAINT [FK_FamiliasProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[FamiliasProductos] CHECK CONSTRAINT [FK_FamiliasProductos_Productos]
GO
ALTER TABLE [dbo].[TicketsProductos]  WITH CHECK ADD  CONSTRAINT [FK_TicketsProductos_Productos] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[TicketsProductos] CHECK CONSTRAINT [FK_TicketsProductos_Productos]
GO
ALTER TABLE [dbo].[TicketsProductos]  WITH CHECK ADD  CONSTRAINT [FK_TicketsProductos_Tickets] FOREIGN KEY([IdTicket])
REFERENCES [dbo].[Tickets] ([IdTicket])
GO
ALTER TABLE [dbo].[TicketsProductos] CHECK CONSTRAINT [FK_TicketsProductos_Tickets]
GO
