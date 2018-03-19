USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[ResourceDeployment]    Script Date: 03/19/2018 17:27:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ResourceDeployment](
	[ResourceDeploymentId] [int] NOT NULL,
	[ResourceDemandId] [int] NOT NULL,
	[ResourceId] [int] NOT NULL,
 CONSTRAINT [PK_ResourceDeployment] PRIMARY KEY CLUSTERED 
(
	[ResourceDeploymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ResourceDeployment]  WITH CHECK ADD  CONSTRAINT [FK_ResourceDeployment_ResourseType] FOREIGN KEY([ResourceId])
REFERENCES [dbo].[ResourseType] ([ResourceTypeId])
GO

ALTER TABLE [dbo].[ResourceDeployment] CHECK CONSTRAINT [FK_ResourceDeployment_ResourseType]
GO

