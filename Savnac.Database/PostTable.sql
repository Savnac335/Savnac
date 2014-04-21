CREATE TABLE [dbo].[Post] (
    [postId]        INT         IDENTITY (1, 1) NOT NULL,
    [postTitle]     NCHAR (100) NOT NULL,
    [postText]      TEXT        NOT NULL,
    [userProfileId] INT         NOT NULL,
    [threadId]      INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([PostId] ASC),
    FOREIGN KEY ([ThreadId]) REFERENCES [dbo].[Thread] ([threadId]),
);