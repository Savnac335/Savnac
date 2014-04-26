CREATE TABLE [dbo].[PostTable]
(
	[postId] INT IDENTITY(1,1) PRIMARY KEY, 
    [postTitle] VARCHAR(50) NOT NULL, 
    [postContent] VARCHAR(MAX) NOT NULL, 
    [postTime] DATETIME NOT NULL, 
    [courseId] INT NOT NULL, 
    [userName] VARCHAR(50) NOT NULL, 
    [post_isRead] BIT NOT NULL, 
    FOREIGN KEY ([courseId]) REFERENCES [dbo].[Course] ([courseId])
);
