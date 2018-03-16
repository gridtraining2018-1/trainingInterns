USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 03/16/2018 18:18:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeDetails](
	[UserId] [nchar](20) NOT NULL,
	[EmailId] [nchar](20) NOT NULL,
	[Password] [nchar](10) NOT NULL,
	[Activate] [nchar](10) NOT NULL,
	[Dactivate] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


