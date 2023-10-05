USE [LagaltDB]

INSERT INTO [User]
VALUES ('magnusuttisrud', 'Test1')
,('joakimskaalevik', 'Test2')
,('siljedenise', 'Test3')
,('siljeslettebakk', 'Test4')

INSERT INTO [Category]
VALUES ('Software development')
, ('Music')
, ('Film')
, ('Gaming')

INSERT INTO [Project] ([Title], [Short_Description], [Full_Description], [Category_Id], [Creator_Id])
VALUES ('Project A', 'Short description A', 'Full description A', '1', '1')
,('Project B', 'Short description B', 'Full description B', '2', '2')
,('Project C', 'Short description C', 'Full description C', '3', '3')
,('Project D', 'Short description D', 'Full description D', '4', '4')
,('Project E', 'Short description E', 'Full description E', '1', '2')

INSERT INTO [Skill]
VALUES ('Backend')
,('Frontend')
,('Fullstack')

INSERT INTO [UserSkillLink]
VALUES ('1', '1')
,('1', '2')
,('1', '3')
,('2', '1')
,('2', '2')
,('2', '3')
,('3', '1')
,('3', '2')
,('3', '3')
,('4', '1')
,('4', '2')
,('4', '3')
