create database Mvc5Bank
go
USE [Mvc5Bank]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 09/14/2014 10:00:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [nvarchar](50) NOT NULL,
	[PinCode] [nvarchar](50) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Accounts] ([Id], [PinCode], [Balance]) VALUES (N'nghiem', N'123', 3900)
INSERT [dbo].[Accounts] ([Id], [PinCode], [Balance]) VALUES (N'nn', N'123', 2502.365)
INSERT [dbo].[Accounts] ([Id], [PinCode], [Balance]) VALUES (N'thao', N'123', 2597.635)
