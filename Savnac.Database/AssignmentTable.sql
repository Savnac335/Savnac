CREATE TABLE [dbo].[Assignment] (
    [assignmentId] INT         IDENTITY (1, 1) NOT NULL,
    [courseId]     INT         NOT NULL,
    [name]         NCHAR (128) NOT NULL,
    [description]  NTEXT       DEFAULT ('No Description Set') NOT NULL,
    [dueDate]     DATETIME    NULL,
    PRIMARY KEY CLUSTERED ([AssignmentId] ASC),
    FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([courseId])
);

