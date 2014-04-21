CREATE TABLE [dbo].[Message]
(
	[msg_id] INT IDENTITY(1,1) PRIMARY KEY, 
    [msg_sEmail] VARCHAR(30) NOT NULL, 
    [msg_rEmail] VARCHAR(30) NOT NULL, 
    [msg_subject] VARCHAR(30) NOT NULL, 
    [msg_content] VARCHAR(MAX) NOT NULL, 
    [msg_dateTime] DATETIME NOT NULL, 
    [msg_isRead] BIT NOT NULL
)