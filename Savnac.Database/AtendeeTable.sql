CREATE TABLE [dbo].[Atendee]
(
	[AtendeeId] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(100) NOT NULL, 
    [courseId] INT NOT NULL,
	[isTeacher] BIT NOT NULL
   
)
