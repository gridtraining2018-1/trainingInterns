USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[ResourceDemandChild]    Script Date: 03/19/2018 17:21:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ResourceDemandChild](
	[ResourceDemandChild] [nvarchar](50) NOT NULL,
	[ResourceDemandId] [int] NOT NULL,
	[ResourceId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Utilization] [int] NOT NULL,
	[Remark] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ResourceDemandChild] PRIMARY KEY CLUSTERED 
(
	[ResourceDemandId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ResourceDemandChild]  WITH CHECK ADD  CONSTRAINT [FK_ResourceDemandChild_ResourseType] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[ResourseType] ([ResourceTypeId])
GO

ALTER TABLE [dbo].[ResourceDemandChild] CHECK CONSTRAINT [FK_ResourceDemandChild_ResourseType]
GO

