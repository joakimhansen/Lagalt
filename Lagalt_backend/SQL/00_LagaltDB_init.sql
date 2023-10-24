


--CREATE DATABASE [LagaltDB]


CREATE TABLE [User](
	[Username] nvarchar(25) PRIMARY KEY,
	[Info] nvarchar(1000),
	[Image_url] nvarchar(300),
	[Hidden] bit NOT NULL DEFAULT 0
);

CREATE TABLE [Category](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL
);

CREATE TABLE [Project](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Title] nvarchar(40) NOT NULL,
	[Short_Description] nvarchar(250),
	[Full_Description] nvarchar(600),
	[Github_Url] nvarchar(100),
	[Progress] int DEFAULT 0,
	[Category_Id] int FOREIGN KEY REFERENCES [Category]([Id]),
	[Creator_Name] nvarchar(25) FOREIGN KEY REFERENCES [User]([Username]),
	CHECK ([Progress] in (0,1,2,3)) 
);
CREATE TABLE [Skill](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(25) NOT NULL
);
CREATE TABLE [CollaboratorApplication](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Content] nvarchar (800) NOT NULL,
	[User] nvarchar(25) FOREIGN KEY REFERENCES [User]([Username]),
	[Project] int FOREIGN KEY REFERENCES [Project]([Id])
);

CREATE TABLE [UserSkillLink](
[Username] nvarchar(25) FOREIGN KEY REFERENCES [User]([Username]),
[Skill_Id] int FOREIGN KEY REFERENCES [Skill]([Id]),
CONSTRAINT [UserSkillLink_Primary_Key] PRIMARY KEY([Username], [Skill_Id])
);

CREATE TABLE [ProjectSkillLink](
[Project_Id] int FOREIGN KEY REFERENCES [Project]([Id]),
[Skill_Id] int FOREIGN KEY REFERENCES [Skill]([Id]),
CONSTRAINT [ProjectSkillLink_Primary_Key] PRIMARY KEY([Project_Id], [Skill_Id])
);

CREATE TABLE [ProjectCollaboratorLink](
[Project_Id] int FOREIGN KEY REFERENCES [Project]([Id]),
[Username] nvarchar(25) FOREIGN KEY REFERENCES [User]([Username]),
CONSTRAINT [ProjectCollaboratorLink_Primary_Key] PRIMARY KEY([Project_Id], [Username])
);

