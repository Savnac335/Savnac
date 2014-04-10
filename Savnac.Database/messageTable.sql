CREATE TABLE [dbo].[Table1]
(
	[msg_id] INT NOT NULL PRIMARY KEY, 
    [msg_sEmail] VARCHAR(30) NOT NULL, 
    [msg_rEmail] VARCHAR(30) NOT NULL, 
    [msg_subject] VARCHAR(30) NOT NULL, 
    [msg_content] VARCHAR(MAX) NOT NULL, 
    [msg_dateTime] DATETIME NOT NULL, 
    [msg_isRead] CHAR(3) NOT NULL
)
