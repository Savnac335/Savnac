CREATE TABLE [dbo].[Attendance] (
    [studentName]  NVARCHAR (100) NOT NULL,
    [isPresent]    BIT            NOT NULL,
    [currentDate]  DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([studentName] ASC)
);