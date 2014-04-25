CREATE TABLE [dbo].[ForumTable]
(
	[postId] INT NOT NULL PRIMARY KEY, 
    [postTitle] VARCHAR(50) NOT NULL, 
    [postContent] VARCHAR(MAX) NOT NULL, 
    [postTime] DATETIME NOT NULL, 
    [courseId] INT NOT NULL, 
    [userName] VARCHAR(50) NOT NULL, 
    FOREIGN KEY ([courseId]) REFERENCES [dbo].[course] ([courseId]),
)
