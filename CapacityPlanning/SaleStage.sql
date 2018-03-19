USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[SaleStage]    Script Date: 03/19/2018 17:19:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SaleStage](
	[SaleId] [int] NOT NULL,
	[SaleStage] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SaleStage] PRIMARY KEY CLUSTERED 
(
	[SaleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

