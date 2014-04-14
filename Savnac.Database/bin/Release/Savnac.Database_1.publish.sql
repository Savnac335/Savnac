﻿/*
Deployment script for Savnac.Database

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Savnac.Database"
:setvar DefaultFilePrefix "Savnac.Database"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The type for column msg_isRead in table [dbo].[messageTable] is currently  CHAR (3) NOT NULL but is being changed to  INT NOT NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Table1])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file 86567561-d645-4899-9a25-5fe2a7661541';

PRINT N'Rename [dbo].[Table1] to messageTable';


GO
EXECUTE sp_rename @objname = N'[dbo].[Table1]', @newname = N'messageTable', @objtype = N'OBJECT';


GO
PRINT N'Starting rebuilding table [dbo].[messageTable]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_messageTable] (
    [msg_id]       INT           IDENTITY (1, 1) NOT NULL,
    [msg_sEmail]   VARCHAR (30)  NOT NULL,
    [msg_rEmail]   VARCHAR (30)  NOT NULL,
    [msg_subject]  VARCHAR (30)  NOT NULL,
    [msg_content]  VARCHAR (MAX) NOT NULL,
    [msg_dateTime] DATETIME      NOT NULL,
    [msg_isRead]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([msg_id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[messageTable])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_messageTable] ON;
        INSERT INTO [dbo].[tmp_ms_xx_messageTable] ([msg_id], [msg_sEmail], [msg_rEmail], [msg_subject], [msg_content], [msg_dateTime], [msg_isRead])
        SELECT   [msg_id],
                 [msg_sEmail],
                 [msg_rEmail],
                 [msg_subject],
                 [msg_content],
                 [msg_dateTime],
                 [msg_isRead]
        FROM     [dbo].[messageTable]
        ORDER BY [msg_id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_messageTable] OFF;
    END

DROP TABLE [dbo].[messageTable];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_messageTable]', N'messageTable';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '86567561-d645-4899-9a25-5fe2a7661541')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('86567561-d645-4899-9a25-5fe2a7661541')

GO

GO
PRINT N'Update complete.';


GO