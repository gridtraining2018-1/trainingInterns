USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[DesignationMaster]    Script Date: 03/19/2018 17:17:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DesignationMaster](
	[DesignationId] [int] NOT NULL,
	[DesignationName] [nvarchar](50) NOT NULL,
	[AuditName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_DesignationMaster] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

