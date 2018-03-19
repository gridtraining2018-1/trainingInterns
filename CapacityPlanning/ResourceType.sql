USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[ResourseType]    Script Date: 03/19/2018 17:18:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ResourseType](
	[ResourceTypeId] [int] NOT NULL,
	[ResourceType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ResourseType] PRIMARY KEY CLUSTERED 
(
	[ResourceTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

