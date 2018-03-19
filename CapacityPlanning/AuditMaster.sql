USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[AuditMaster]    Script Date: 03/19/2018 17:16:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AuditMaster](
	[AuditId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[DateOfCreation] [date] NOT NULL,
	[DateOfModification] [date] NULL,
	[IPAdress] [nvarchar](50) NOT NULL,
	[Browser] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AuditMaster] PRIMARY KEY CLUSTERED 
(
	[AuditId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

