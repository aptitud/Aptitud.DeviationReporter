USE [Aptitud.DeviationReporter]
GO

/****** Object:  Table [dbo].[Deviations]    Script Date: 11/19/2012 20:51:12 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Deviations]') AND type in (N'U'))
DROP TABLE [dbo].[Deviations]
GO

USE [Aptitud.DeviationReporter]
GO

/****** Object:  Table [dbo].[Deviations]    Script Date: 11/19/2012 20:51:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Deviations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Reporter] [varchar](100) NOT NULL,
	[DeviationType] [varchar](30) NOT NULL,
	[ReportDate] [datetime] NOT NULL,
	[DurationTicks] [bigint] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[Reporters]    Script Date: 02/01/2013 13:36:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reporters]') AND type in (N'U'))
DROP TABLE [dbo].[Reporters]
GO

/****** Object:  Table [dbo].[Reporters]    Script Date: 02/01/2013 13:36:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Reporters](
	[Id] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Reporters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

