USE [Tienda]
GO
/****** Object:  Table [dbo].[productos]    Script Date: 27/5/2024 20:02:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[codigo_producto] [varchar](50) NOT NULL,
	[nombre_producto] [varchar](100) NULL,
	[marca] [varchar](50) NULL,
	[talla] [varchar](10) NULL,
	[color] [varchar](20) NULL,
	[precio] [decimal](10, 0) NULL,
	[stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[codigo_producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 27/5/2024 20:02:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[id_venta] [int] IDENTITY(1,1) NOT NULL,
	[codigo_producto] [varchar](50) NULL,
	[fecha_venta] [date] NULL,
	[forma_pago] [varchar](20) NULL,
	[nombre_cliente] [varchar](50) NULL,
	[apellido1] [varchar](50) NULL,
	[apellido2] [varchar](50) NULL,
	[direccion_cliente] [varchar](200) NULL,
	[telefono_cliente] [varchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD FOREIGN KEY([codigo_producto])
REFERENCES [dbo].[productos] ([codigo_producto])
GO
