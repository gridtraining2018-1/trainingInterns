USE [capacityPalanning]
GO

/****** Object:  Table [dbo].[EmployeeDetail]    Script Date: 03/19/2018 17:17:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EmployeeDetail](
	[EmployeeID] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MIddleName] [nvarchar](30) NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](300) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[PhoneNumber] [numeric](10, 0) NOT NULL,
	[Gender] [nvarchar](10) NOT NULL,
	[Photo] [nvarchar](50) NOT NULL,
	[BaseLocationID] [numeric](18, 0) NOT NULL,
	[DateOfJoining] [date] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[RoleID] [int] NOT NULL,
	[DesignationID] [int] NOT NULL,
	[PreviousExperienceYear] [nvarchar](50) NULL,
	[PreviousExperienceMonth] [nvarchar](max) NULL,
	[Activate] [varbinary](50) NULL,
	[AuditID] [int] NOT NULL,
 CONSTRAINT [PK_Login_1] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmployeeDetail]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDetail_AuditMaster] FOREIGN KEY([AuditID])
REFERENCES [dbo].[AuditMaster] ([AuditId])
GO

ALTER TABLE [dbo].[EmployeeDetail] CHECK CONSTRAINT [FK_EmployeeDetail_AuditMaster]
GO

ALTER TABLE [dbo].[EmployeeDetail]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDetail_RoleMaster] FOREIGN KEY([RoleID])
REFERENCES [dbo].[RoleMaster] ([RoleId])
GO

ALTER TABLE [dbo].[EmployeeDetail] CHECK CONSTRAINT [FK_EmployeeDetail_RoleMaster]
GO

