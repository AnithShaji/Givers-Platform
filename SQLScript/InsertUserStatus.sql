USE [E-Welfare]
GO

INSERT INTO [dbo].[UserStatus_Master]
           ([UserStatus]
           ,[UserStatusCode])
     VALUES
           ('NEW'
           ,'NEW')
INSERT INTO [dbo].[UserStatus_Master]
           ([UserStatus]
           ,[UserStatusCode])
     VALUES
           ('INPROCESS'
           ,'INP')
		   INSERT INTO [dbo].[UserStatus_Master]
           ([UserStatus]
           ,[UserStatusCode])
     VALUES
           ('ACCEPTED'
           ,'ACC')
		   INSERT INTO [dbo].[UserStatus_Master]
           ([UserStatus]
           ,[UserStatusCode])
     VALUES
           ('REJECTED'
           ,'REJ')
GO


