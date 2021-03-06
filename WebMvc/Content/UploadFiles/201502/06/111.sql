USE [lazy]
GO
/****** 对象:  Table [dbo].[News_Article]    脚本日期: 01/28/2015 07:13:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News_Article](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[guid] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ComID] [int] NULL,
	[NewsTitle] [nvarchar](250) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[FilePath] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[Notes] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[TypeID] [int] NULL,
	[CreatorID] [int] NULL,
	[CreatorRealName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[CreatorDepName] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NULL,
	[AddTime] [datetime] NULL,
	[ShareUsers] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[ShareDeps] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
	[namelist] [nvarchar](max) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_News_Article] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
