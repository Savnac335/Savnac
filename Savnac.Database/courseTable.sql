CREATE TABLE [dbo].[Course]
(
	[courseId] INT NOT NULL , 
    [courseName] VARCHAR(50) NOT NULL, 
    [syllabusName] VARCHAR(50) NULL, 
    [announcementId] INT NULL,
    FOREIGN KEY ([announcementId]) REFERENCES [dbo].[Announcement] ([announcementId]), 
    PRIMARY KEY ([courseId])
)
