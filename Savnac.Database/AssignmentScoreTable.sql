CREATE TABLE [dbo].[AssignmentScore] (
    [assignmentScoresId] INT             IDENTITY (1, 1) NOT NULL,
    [assignmentId]       INT             NOT NULL,
    [studentId]          INT             NOT NULL,
    [score]              INT             DEFAULT ((0)) NOT NULL,
    [submission]         VARBINARY (MAX) NULL,
    PRIMARY KEY CLUSTERED ([assignmentScoresId] ASC),
    FOREIGN KEY ([AssignmentId]) REFERENCES [dbo].[Assignment] ([assignmentId]),
);

