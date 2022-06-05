USE [master]
GO

IF db_id('dunbar') IS NULL
  CREATE DATABASE dunbar
GO

USE [dunbar]
GO

DROP TABLE IF EXISTS [Item];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [ItemTradeOffer];
DROP TABLE IF EXISTS [Status];
DROP TABLE IF EXISTS [Category];
GO

CREATE TABLE [Users] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] int,
  [Name] nvarchar(255),
  [UserName] nvarchar(255),
  [Email] nvarchar(255)
)
GO

CREATE TABLE [Post] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [ImageUrl] nvarchar(255),
  [Text] nvarchar(255) NOT NULL,
  [UserId] int NOT NULL
)
GO

CREATE TABLE [Friends] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [UserId] int NOT NULL,
  [FriendId] int NOT NULL,
  [RelativityId] int NOT NULL
)
GO

CREATE TABLE [Relativity] (
  [Id] int PRIMARY KEY,
  [Name] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [Post] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [Friends] ADD FOREIGN KEY ([RelativityId]) REFERENCES [Relativity] ([Id])
GO

ALTER TABLE [Friends] ADD FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
GO

ALTER TABLE [Friends] ADD FOREIGN KEY ([FriendId]) REFERENCES [Users] ([Id])
GO
