USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[ResourceDemand]    Script Date: 03/19/2018 17:20:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ResourceDemand](
	[RequestId] [int] NOT NULL,
	[RequestedDate] [date] NOT NULL,
	[POStautusId] [int] NOT NULL,
	[RegionId] [int] NOT NULL,
	[OpportunityTypeId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[SalesStageId] [int] NOT NULL,
	[OwnerId] [int] NOT NULL,
	[ProcessName] [nvarchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[NumberOfPosition] [int] NOT NULL,
	[MonthlyRate] [float] NOT NULL,
	[TotalDealValue] [float] NOT NULL,
	[TicketStatusId] [int] NOT NULL,
	[DateOfCreation] [date] NOT NULL,
	[DateOfModification] [date] NOT NULL,
 CONSTRAINT [PK_ResourceDemand] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ResourceDemand]  WITH CHECK ADD  CONSTRAINT [FK_ResourceDemand_City] FOREIGN KEY([CityId])
REFERENCES [dbo].[City] ([CityId])
GO

ALTER TABLE [dbo].[ResourceDemand] CHECK CONSTRAINT [FK_ResourceDemand_City]
GO

