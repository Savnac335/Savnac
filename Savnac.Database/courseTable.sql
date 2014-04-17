CREATE TABLE [dbo].[courseTable]
(
	[courseId] INT IDENTITY(1,1) PRIMARY KEY, 
    [courseName] VARCHAR(50) NULL, 
    [teacherName] VARCHAR(50) NULL, 
    [syllabusName] VARCHAR(50) NULL, 
    [announcementId] INT NULL
)
