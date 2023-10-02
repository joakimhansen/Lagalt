IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'LagaltDb')
BEGIN
	ALTER DATABASE [LagaltDb] SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE [LagaltDb] SET ONLINE;
	DROP DATABASE [LagaltDb];
END


CREATE DATABASE [LagaltDb]

USE [LagaltDb]

CREATE TABLE [User](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Username] nvarchar(25)	NOT NULL,
	[Info] nvarchar(1000)
);

CREATE TABLE [Category](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL
);

CREATE TABLE [Project](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Title] nvarchar(40) NOT NULL,
	[Short_Description] nvarchar(500),
	[Full_Description] nvarchar(max),
	[Category_Id] int FOREIGN KEY REFERENCES [Category]([Id]),
	[Creator_Id] int FOREIGN KEY REFERENCES [User]([Id])
);

CREATE TABLE [Skill](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL
);

USE [LagaltDb]

CREATE TABLE [UserProjectLink](
[User_Id] int FOREIGN KEY REFERENCES [User]([Id]),
[Project_Id] int FOREIGN KEY REFERENCES [Project]([Id]),
CONSTRAINT [UserProjectLink_Primary_Key] PRIMARY KEY([User_Id], [Project_Id])
);

CREATE TABLE [UserSkillLink](
[User_Id] int FOREIGN KEY REFERENCES [User]([Id]),
[Skill_Id] int FOREIGN KEY REFERENCES [Skill]([Id]),
CONSTRAINT [UserSkillLink_Primary_Key] PRIMARY KEY([User_Id], [Skill_Id])
);

