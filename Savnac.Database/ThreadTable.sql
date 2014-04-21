CREATE TABLE [dbo].[Thread] (
    [threadId]       INT         IDENTITY (1, 1) NOT NULL,
    [threadText]     TEXT        NOT NULL,
    [threadTitle]    NCHAR (100) NOT NULL,
    [ownerUserName] VARCHAR(50)         NOT NULL,
    PRIMARY KEY CLUSTERED ([ThreadId] ASC),
);

