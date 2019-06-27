CREATE DATABASE TIDELE_DB
    GO
USE [TIDELE_DB]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Artist] [bigint] NOT NULL,
	[Status] [char](1) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [Albums_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](25) NOT NULL,
	[BlockedAge] [smallint] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [Categories_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genders]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MediaType] [int] NOT NULL,
	[ParentGender] [bigint] NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [Genders_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Artist] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Rating] [decimal](18, 0) NOT NULL,
	[Gender] [bigint] NOT NULL,
	[Category] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
	[Size] [varchar](100) NOT NULL,
	[ReproducedTimes] [bigint] NOT NULL,
	[Source] [varchar](500) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [Media_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media_Books]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media_Books](
	[Id] [bigint] NOT NULL,
	[Pages] [smallint] NOT NULL,
 CONSTRAINT [Media_Books_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media_Images]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media_Images](
	[Id] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media_Musics]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media_Musics](
	[Id] [bigint] NOT NULL,
	[Album] [bigint] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [Media_Musics_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Media_Videos]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Media_Videos](
	[Id] [bigint] NOT NULL,
	[Album] [bigint] NOT NULL,
	[Duration] [int] NOT NULL,
 CONSTRAINT [Media_Videos_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MediaTypes]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MediaTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](6) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [MediaTypes_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nations]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nations](
	[Code] [varchar](3) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PhoneCode] [smallint] NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
	[Status] [char](1) NOT NULL,
 CONSTRAINT [Nations_pk] PRIMARY KEY NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Artist] [bigint] NOT NULL,
	[FinalUser] [bigint] NOT NULL,
	[NotificationType] [int] NOT NULL,
	[wasSeen] [bit] NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [Notifications_pk] PRIMARY KEY NONCLUSTERED 
(
	[Artist] ASC,
	[FinalUser] ASC,
	[RegisterDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationTypes]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [NotificationType_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Creator] [bigint] NOT NULL,
	[MediaType] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
	[ModificationDate] [datetime] NULL,
 CONSTRAINT [Playlists_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists_Media]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists_Media](
	[Playlist] [bigint] NOT NULL,
	[Media] [bigint] NOT NULL,
 CONSTRAINT [Playlist_Media_pk] PRIMARY KEY NONCLUSTERED 
(
	[Playlist] ASC,
	[Media] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists_Users]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists_Users](
	[Playlist] [bigint] NOT NULL,
	[User] [bigint] NOT NULL,
 CONSTRAINT [Playlists_Users_pk] PRIMARY KEY NONCLUSTERED 
(
	[Playlist] ASC,
	[User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Code] [char](1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [Status_pk] PRIMARY KEY NONCLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](32) NOT NULL,
	[BornDate] [datetime] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Nationality] [varchar](3) NOT NULL,
	[Status] [char](1) NOT NULL,
	[LoginTimes] [int] NULL,
	[RegisterDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NULL,
 CONSTRAINT [Users_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Administrators]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Administrators](
	[Id] [bigint] NOT NULL,
 CONSTRAINT [Users_Administrators_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Artists]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Artists](
	[Id] [bigint] NOT NULL,
	[Alias] [varchar](50) NULL,
	[ImageSource] [varchar](500) NULL,
	[Manager] [bigint] NOT NULL,
	[MediaType] [int] NOT NULL,
	[Verified] [bit] NOT NULL,
 CONSTRAINT [Users_Artists_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Finals]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Finals](
	[Id] [bigint] NOT NULL,
	[ImageSource] [varchar](500) NULL,
	[Telephone] [varchar](20) NULL,
	[ParentUser] [bigint] NULL,
 CONSTRAINT [Users_Finals_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Managers]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Managers](
	[Id] [bigint] NOT NULL,
	[CUIT] [varchar](13) NOT NULL,
 CONSTRAINT [Users_Managers_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users_Moderators]    Script Date: 1/5/2019 23:44:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users_Moderators](
	[Id] [bigint] NOT NULL,
	[Administrator] [bigint] NOT NULL,
 CONSTRAINT [Users_Moderators_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Albums] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Albums] ADD  DEFAULT (NULL) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Genders] ADD  DEFAULT (NULL) FOR [ParentGender]
GO
ALTER TABLE [dbo].[Genders] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Media] ADD  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[Media] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Media] ADD  DEFAULT ((0)) FOR [ReproducedTimes]
GO
ALTER TABLE [dbo].[Media] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Media_Books] ADD  DEFAULT ((0)) FOR [Pages]
GO
ALTER TABLE [dbo].[Media_Musics] ADD  DEFAULT ((0)) FOR [Duration]
GO
ALTER TABLE [dbo].[Media_Videos] ADD  DEFAULT ((0)) FOR [Duration]
GO
ALTER TABLE [dbo].[MediaTypes] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[MediaTypes] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Nations] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Nations] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT ((0)) FOR [wasSeen]
GO
ALTER TABLE [dbo].[Notifications] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[NotificationTypes] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Playlists] ADD  DEFAULT (NULL) FOR [ModificationDate]
GO
ALTER TABLE [dbo].[Status] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [LoginTimes]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [RegisterDate]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (NULL) FOR [LastLoginDate]
GO
ALTER TABLE [dbo].[Users_Artists] ADD  DEFAULT (NULL) FOR [Alias]
GO
ALTER TABLE [dbo].[Users_Artists] ADD  DEFAULT ((0)) FOR [Verified]
GO
ALTER TABLE [dbo].[Users_Finals] ADD  DEFAULT (NULL) FOR [ImageSource]
GO
ALTER TABLE [dbo].[Users_Finals] ADD  DEFAULT (NULL) FOR [Telephone]
GO
ALTER TABLE [dbo].[Users_Finals] ADD  DEFAULT (NULL) FOR [ParentUser]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [Albums_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [Albums_Status_Code_fk]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD  CONSTRAINT [Albums_Users_Artists_Id_fk] FOREIGN KEY([Artist])
REFERENCES [dbo].[Users_Artists] ([Id])
GO
ALTER TABLE [dbo].[Albums] CHECK CONSTRAINT [Albums_Users_Artists_Id_fk]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [Categories_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [Categories_Status_Code_fk]
GO
ALTER TABLE [dbo].[Genders]  WITH CHECK ADD  CONSTRAINT [Genders_Genders_Id_fk] FOREIGN KEY([ParentGender])
REFERENCES [dbo].[Genders] ([Id])
GO
ALTER TABLE [dbo].[Genders] CHECK CONSTRAINT [Genders_Genders_Id_fk]
GO
ALTER TABLE [dbo].[Genders]  WITH CHECK ADD  CONSTRAINT [Genders_MediaTypes_Id_fk] FOREIGN KEY([MediaType])
REFERENCES [dbo].[MediaTypes] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Genders] CHECK CONSTRAINT [Genders_MediaTypes_Id_fk]
GO
ALTER TABLE [dbo].[Genders]  WITH CHECK ADD  CONSTRAINT [Genders_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Genders] CHECK CONSTRAINT [Genders_Status_Code_fk]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Categories_Id_fk] FOREIGN KEY([Category])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Categories_Id_fk]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Genders_Id_fk] FOREIGN KEY([Gender])
REFERENCES [dbo].[Genders] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Genders_Id_fk]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Status_Code_fk]
GO
ALTER TABLE [dbo].[Media]  WITH CHECK ADD  CONSTRAINT [Media_Users_Artists_Id_fk] FOREIGN KEY([Artist])
REFERENCES [dbo].[Users_Artists] ([Id])
GO
ALTER TABLE [dbo].[Media] CHECK CONSTRAINT [Media_Users_Artists_Id_fk]
GO
ALTER TABLE [dbo].[Media_Books]  WITH CHECK ADD  CONSTRAINT [Media_Books_Media_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Media] ([Id])
GO
ALTER TABLE [dbo].[Media_Books] CHECK CONSTRAINT [Media_Books_Media_Id_fk]
GO
ALTER TABLE [dbo].[Media_Images]  WITH CHECK ADD  CONSTRAINT [Media_Images_Media_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Media] ([Id])
GO
ALTER TABLE [dbo].[Media_Images] CHECK CONSTRAINT [Media_Images_Media_Id_fk]
GO
ALTER TABLE [dbo].[Media_Musics]  WITH CHECK ADD  CONSTRAINT [Media_Musics_Albums_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Media_Musics] CHECK CONSTRAINT [Media_Musics_Albums_Id_fk]
GO
ALTER TABLE [dbo].[Media_Videos]  WITH CHECK ADD  CONSTRAINT [Media_Videos_Albums_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Albums] ([Id])
GO
ALTER TABLE [dbo].[Media_Videos] CHECK CONSTRAINT [Media_Videos_Albums_Id_fk]
GO
ALTER TABLE [dbo].[MediaTypes]  WITH CHECK ADD  CONSTRAINT [MediaTypes_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[MediaTypes] CHECK CONSTRAINT [MediaTypes_Status_Code_fk]
GO
ALTER TABLE [dbo].[Nations]  WITH CHECK ADD  CONSTRAINT [Nations_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Nations] CHECK CONSTRAINT [Nations_Status_Code_fk]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [Notifications_Users_Artists_Id_fk] FOREIGN KEY([Artist])
REFERENCES [dbo].[Users_Artists] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [Notifications_Users_Artists_Id_fk]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [Notifications_Users_Finals_Id_fk] FOREIGN KEY([FinalUser])
REFERENCES [dbo].[Users_Finals] ([Id])
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [Notifications_Users_Finals_Id_fk]
GO
ALTER TABLE [dbo].[Playlists]  WITH CHECK ADD  CONSTRAINT [Playlists_MediaTypes_Id_fk] FOREIGN KEY([MediaType])
REFERENCES [dbo].[MediaTypes] ([Id])
GO
ALTER TABLE [dbo].[Playlists] CHECK CONSTRAINT [Playlists_MediaTypes_Id_fk]
GO
ALTER TABLE [dbo].[Playlists]  WITH CHECK ADD  CONSTRAINT [Playlists_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Playlists] CHECK CONSTRAINT [Playlists_Status_Code_fk]
GO
ALTER TABLE [dbo].[Playlists]  WITH CHECK ADD  CONSTRAINT [Playlists_Users_Finals_Id_fk] FOREIGN KEY([Creator])
REFERENCES [dbo].[Users_Finals] ([Id])
GO
ALTER TABLE [dbo].[Playlists] CHECK CONSTRAINT [Playlists_Users_Finals_Id_fk]
GO
ALTER TABLE [dbo].[Playlists_Media]  WITH CHECK ADD  CONSTRAINT [Playlists_Media_Media_Id_fk] FOREIGN KEY([Media])
REFERENCES [dbo].[Media] ([Id])
GO
ALTER TABLE [dbo].[Playlists_Media] CHECK CONSTRAINT [Playlists_Media_Media_Id_fk]
GO
ALTER TABLE [dbo].[Playlists_Media]  WITH CHECK ADD  CONSTRAINT [Playlists_Media_Playlists_Id_fk] FOREIGN KEY([Playlist])
REFERENCES [dbo].[Playlists] ([Id])
GO
ALTER TABLE [dbo].[Playlists_Media] CHECK CONSTRAINT [Playlists_Media_Playlists_Id_fk]
GO
ALTER TABLE [dbo].[Playlists_Users]  WITH CHECK ADD  CONSTRAINT [Playlists_Users_Playlists_Id_fk] FOREIGN KEY([Playlist])
REFERENCES [dbo].[Playlists] ([Id])
GO
ALTER TABLE [dbo].[Playlists_Users] CHECK CONSTRAINT [Playlists_Users_Playlists_Id_fk]
GO
ALTER TABLE [dbo].[Playlists_Users]  WITH CHECK ADD  CONSTRAINT [Playlists_Users_Users_Id_fk] FOREIGN KEY([User])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Playlists_Users] CHECK CONSTRAINT [Playlists_Users_Users_Id_fk]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_Nations_Code_fk] FOREIGN KEY([Nationality])
REFERENCES [dbo].[Nations] ([Code])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_Nations_Code_fk]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [Users_Status_Code_fk] FOREIGN KEY([Status])
REFERENCES [dbo].[Status] ([Code])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [Users_Status_Code_fk]
GO
ALTER TABLE [dbo].[Users_Administrators]  WITH CHECK ADD  CONSTRAINT [Users_Administrators_Users_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_Administrators] CHECK CONSTRAINT [Users_Administrators_Users_Id_fk]
GO
ALTER TABLE [dbo].[Users_Artists]  WITH CHECK ADD  CONSTRAINT [Users_Artists_MediaTypes_Id_fk] FOREIGN KEY([MediaType])
REFERENCES [dbo].[MediaTypes] ([Id])
GO
ALTER TABLE [dbo].[Users_Artists] CHECK CONSTRAINT [Users_Artists_MediaTypes_Id_fk]
GO
ALTER TABLE [dbo].[Users_Artists]  WITH CHECK ADD  CONSTRAINT [Users_Artists_Users_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_Artists] CHECK CONSTRAINT [Users_Artists_Users_Id_fk]
GO
ALTER TABLE [dbo].[Users_Artists]  WITH CHECK ADD  CONSTRAINT [Users_Artists_Users_Managers_Id_fk] FOREIGN KEY([Manager])
REFERENCES [dbo].[Users_Managers] ([Id])
GO
ALTER TABLE [dbo].[Users_Artists] CHECK CONSTRAINT [Users_Artists_Users_Managers_Id_fk]
GO
ALTER TABLE [dbo].[Users_Finals]  WITH CHECK ADD  CONSTRAINT [Users_Finals_Users_Finals_Id_fk] FOREIGN KEY([ParentUser])
REFERENCES [dbo].[Users_Finals] ([Id])
GO
ALTER TABLE [dbo].[Users_Finals] CHECK CONSTRAINT [Users_Finals_Users_Finals_Id_fk]
GO
ALTER TABLE [dbo].[Users_Managers]  WITH CHECK ADD  CONSTRAINT [Users_Managers_Users_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_Managers] CHECK CONSTRAINT [Users_Managers_Users_Id_fk]
GO
ALTER TABLE [dbo].[Users_Moderators]  WITH CHECK ADD  CONSTRAINT [Users_Moderators_Users_Administrators_Id_fk] FOREIGN KEY([Administrator])
REFERENCES [dbo].[Users_Administrators] ([Id])
GO
ALTER TABLE [dbo].[Users_Moderators] CHECK CONSTRAINT [Users_Moderators_Users_Administrators_Id_fk]
GO
ALTER TABLE [dbo].[Users_Moderators]  WITH CHECK ADD  CONSTRAINT [Users_Moderators_Users_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Users_Moderators] CHECK CONSTRAINT [Users_Moderators_Users_Id_fk]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del álbum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artista creador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'Artist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del álbum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Álbumes creados por los Artistas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Albums'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre de la categoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Edad minima para ver el contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'BlockedAge'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de la categoria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Categorias aptas para ver contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Categories'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del género' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido digital al que pertenece' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders', @level2type=N'COLUMN',@level2name=N'MediaType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Género padre al que pertenece' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders', @level2type=N'COLUMN',@level2name=N'ParentGender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del Género' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Generos de contenidos digitales' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Genders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Artista que creó el contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Artist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Clasificación del contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Rating'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Genero al que pertenece el contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Categoria a la que pertenece' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tamaño en Bytes del contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'Size'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Veces que se reprodujo el contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media', @level2type=N'COLUMN',@level2name=N'ReproducedTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido Digital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Books', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Libros añadidos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Books'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Images', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Imagenes añadidas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Images'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Musics', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de album' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Musics', @level2type=N'COLUMN',@level2name=N'Album'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Duracion de la musica en segundos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Musics', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Musica añadida' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Musics'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Videos', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de album' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Videos', @level2type=N'COLUMN',@level2name=N'Album'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Duracion del video en segundos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Videos', @level2type=N'COLUMN',@level2name=N'Duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Videos añadidos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Media_Videos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MediaTypes', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Contenido Digital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MediaTypes', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MediaTypes', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado del tipo de contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MediaTypes', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipos de Contenido Digital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MediaTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo del pais (ISO 3166-1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del pais' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo telefonico del pais' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations', @level2type=N'COLUMN',@level2name=N'PhoneCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estado de la nacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Naciones del mundo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Nations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador artista' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications', @level2type=N'COLUMN',@level2name=N'Artist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador usuario final' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications', @level2type=N'COLUMN',@level2name=N'FinalUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de notificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications', @level2type=N'COLUMN',@level2name=N'NotificationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Determina si fue vista' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications', @level2type=N'COLUMN',@level2name=N'wasSeen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Notificaciones del sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Notifications'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotificationTypes', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de notificacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotificationTypes', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotificationTypes', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipos de notificación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'NotificationTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de usuario final creador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de contenido que reproduce la lista de reproduccion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists', @level2type=N'COLUMN',@level2name=N'MediaType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de modificacion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists', @level2type=N'COLUMN',@level2name=N'ModificationDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Listas de reproduccion creadas por los usuarios' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de playlist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists_Media', @level2type=N'COLUMN',@level2name=N'Playlist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de Contenido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists_Media', @level2type=N'COLUMN',@level2name=N'Media'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contenido agregado en cada lista de repoduccion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists_Media'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador de lista de reproduccion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists_Users', @level2type=N'COLUMN',@level2name=N'Playlist'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios asociados a las listas de reproduccion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Playlists_Users'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo de estado interno' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Status', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del estado a mostrar' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Status', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estados para las entidades dentro del sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Apellido del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Mail del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contraseña del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cumpleaños del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'BornDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Genero del usuario (''M'', ''F'', ''O'')' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nacionalidad del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Nationality'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Cantidad de veces que inició sesión' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LoginTimes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de registro del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'RegisterDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha de ultimo ingreso al sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios del sistema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Administrators', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios administradores' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Administrators'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alias del Artista' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'Alias'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Imagen del Artista' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'ImageSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Manager al cual pertenece' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'Manager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tipo de Contenido Principal que ofrece' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'MediaType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Determina si el Artista está verificado por un Moderador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists', @level2type=N'COLUMN',@level2name=N'Verified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios artistas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Artists'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Finals', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Imagen del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Finals', @level2type=N'COLUMN',@level2name=N'ImageSource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Numero de celular del usuario' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Finals', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios Finales de la Aplicación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Finals'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Managers', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CUIT del Manager' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Managers', @level2type=N'COLUMN',@level2name=N'CUIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios Manager' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Managers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Moderators', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Administrador que lo creo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Moderators', @level2type=N'COLUMN',@level2name=N'Administrator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuarios moderadores' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users_Moderators'
GO
alter table Media_Musics drop constraint Media_Musics_Albums_Id_fk
go

alter table Media_Musics
	add constraint Media_Musics_Albums_Id_fk
		foreign key (Album) references Albums
go

alter table Media_Musics
	add constraint Media_Musics_Media_Id_fk
		foreign key (Id) references Media
go

alter table Media_Videos drop constraint Media_Videos_Albums_Id_fk
go

alter table Media_Videos
	add constraint Media_Videos_Albums_Id_fk
		foreign key (Album) references Albums
go

alter table Media_Videos
	add constraint Media_Videos_Media_Id_fk
		foreign key (Id) references Media
go

alter table Users_Artists alter column MediaType int null
go

CREATE TRIGGER AFTER_INSERT_MEDIA_CONTENT ON Media
    AFTER INSERT AS
BEGIN
    BEGIN TRY
        DECLARE @Artist BIGINT;
        DECLARE @MediaType BIGINT;

        SELECT @Artist = Artist
        FROM INSERTED;

        SELECT TOP 1 @MediaType = MT.Id
        FROM Media M
            INNER JOIN Genders G on M.Gender = G.Id
            INNER JOIN MediaTypes MT on G.MediaType = MT.Id
        WHERE Artist = 3
        GROUP BY MT.Id
        ORDER BY COUNT(M.Gender) DESC, MT.Id

        UPDATE Users_Artists
        SET MediaType = @MediaType
        WHERE Id = @Artist
    END TRY
    BEGIN CATCH
        PRINT ERROR_MESSAGE();
    END CATCH
END;

alter table Albums
	add MediaType int default 1 not null
go

exec sp_addextendedproperty 'MS_Description', 'Tipo de contenido almacenado en el album', 'SCHEMA', 'dbo', 'TABLE', 'Albums', 'COLUMN', 'MediaType'
go

alter table Albums
	add constraint Albums_MediaTypes_Id_fk
		foreign key (MediaType) references MediaTypes
go

create table Users_Media_Rating
(
	UserId BIGINT not null
		constraint Users_Media_Rating_Users_Finals_Id_fk
			references Users_Finals,
	MediaId BIGINT not null
		constraint Users_Media_Rating_Media_Id_fk
			references Media,
	MediaRating SMALLINT not null CHECK (MediaRating >= 0 AND MediaRating <= 5),
	RegisterDate DATETIME default GETDATE() not null,
	constraint Users_Media_Rating_pk_2
		primary key nonclustered (UserId, MediaId)
)
go

exec sp_addextendedproperty 'MS_Description', 'Rating de cada usuario', 'SCHEMA', 'dbo', 'TABLE', 'Users_Media_Rating'
go

alter table Albums
	add ImageSource varchar(500) default NULL
go

exec sp_addextendedproperty 'MS_Description', 'Imagen del album', 'SCHEMA', 'dbo', 'TABLE', 'Albums', 'COLUMN', 'ImageSource'
go

CREATE TRIGGER AFTER_INSERT_USERS_MEDIA_RATING ON Users_Media_Rating
AFTER INSERT AS
BEGIN
   BEGIN TRY
       DECLARE @MediaId BIGINT;
       DECLARE @Rating smallint;

       SELECT @MediaId = MediaId
       FROM INSERTED;

       SELECT @Rating = AVG(MediaRating)
       FROM Users_Media_Rating
       WHERE MediaId = @MediaId;

       UPDATE Media
       SET Rating = @Rating
       WHERE Id = @MediaId;
   END TRY
   BEGIN CATCH
       PRINT ERROR_MESSAGE();
   END CATCH
END
GO

CREATE TRIGGER AFTER_UPDATE_USERS_MEDIA_RATING ON Users_Media_Rating
AFTER UPDATE AS
BEGIN
   BEGIN TRY
       DECLARE @MediaId BIGINT;
       DECLARE @Rating smallint;

       SELECT @MediaId = MediaId
       FROM INSERTED;

       SELECT @Rating = AVG(MediaRating)
       FROM Users_Media_Rating
       WHERE MediaId = @MediaId;

       UPDATE Media
       SET Rating = @Rating
       WHERE Id = @MediaId;
   END TRY
   BEGIN CATCH
       PRINT ERROR_MESSAGE();
   END CATCH
END
GO

exec sp_rename 'Media.Artist', Album, 'COLUMN';
GO

alter table Media drop constraint Media_Users_Artists_Id_fk;
GO

alter table Media
			add constraint Media_Albums_Id_fk
			foreign key (Album) references Albums;
GO
