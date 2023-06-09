USE [master]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/19/2023 10:05:18 AM ******/
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
/****** Object:  Table [dbo].[Ports]    Script Date: 5/19/2023 10:05:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ports](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Latitude] [decimal](8, 6) NOT NULL,
	[Longitude] [decimal](9, 6) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Ports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 5/19/2023 10:05:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Latitude] [decimal](8, 6) NOT NULL,
	[Longitude] [decimal](9, 6) NOT NULL,
	[Velocity] [float] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedDate] [datetime2](7) NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230518044510_initial', N'6.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230518044811_update1', N'6.0.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230518144351_add-port', N'6.0.15')
GO
INSERT [dbo].[Ports] ([Id], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'bf5f4cf3-5a9f-4df2-7fc1-08db580b9697', N'Port 1', CAST(88.014906 AS Decimal(8, 6)), CAST(61.692333 AS Decimal(9, 6)), CAST(N'2023-05-19T01:51:39.6836372' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[Ports] ([Id], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'800c4876-1a17-45a6-7fc2-08db580b9697', N'Port 2', CAST(25.088974 AS Decimal(8, 6)), CAST(124.888025 AS Decimal(9, 6)), CAST(N'2023-05-19T01:51:39.8938125' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[Ports] ([Id], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'aeb8cddc-fb3e-4334-7fc3-08db580b9697', N'Port 3', CAST(76.404951 AS Decimal(8, 6)), CAST(-127.259315 AS Decimal(9, 6)), CAST(N'2023-05-19T01:51:39.8943049' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[Ports] ([Id], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'010ccd95-1c5c-477c-7fc4-08db580b9697', N'Port 4', CAST(19.817593 AS Decimal(8, 6)), CAST(-79.306683 AS Decimal(9, 6)), CAST(N'2023-05-19T01:51:39.8943511' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[Ports] ([Id], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'aa98b8b3-0ec3-4956-7fc5-08db580b9697', N'Port 5', CAST(75.083539 AS Decimal(8, 6)), CAST(9.720046 AS Decimal(9, 6)), CAST(N'2023-05-19T01:51:39.8945100' AS DateTime2), 0, NULL, NULL)
GO
INSERT [dbo].[Ships] ([Id], [Name], [Latitude], [Longitude], [Velocity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'9a857c4e-d775-40e0-1deb-08db580b96d8', N'Ship 1', CAST(59.056724 AS Decimal(8, 6)), CAST(36.846666 AS Decimal(9, 6)), 20, CAST(N'2023-05-19T01:51:40.1677494' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[Ships] ([Id], [Name], [Latitude], [Longitude], [Velocity], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (N'c5ffe880-f5c5-4937-1dec-08db580b96d8', N'Ship 2', CAST(72.604473 AS Decimal(8, 6)), CAST(31.528746 AS Decimal(9, 6)), 20, CAST(N'2023-05-19T01:51:40.1916863' AS DateTime2), 0, NULL, NULL)
GO
