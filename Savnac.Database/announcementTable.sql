CREATE TABLE [dbo].[announcementTable]
(
	[announcementId] INT IDENTITY(1,1) PRIMARY KEY, 
    [username] VARCHAR(50) NULL, 
    [title] VARCHAR(50) NULL, 
    [body] VARCHAR(MAX) NULL, 
    [timePosted] DATETIME NULL
)
