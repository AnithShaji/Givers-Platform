USE [E-Welfare]
GO

INSERT INTO [dbo].[UserType]
           ([UserTypeName]
           ,[UserTypeDesc]
           ,[UserTypeCode]
           ,[CreatedDate]
           ,[ModifiedDate])
     VALUES
           ('Admin'
           ,'Charity Institution Head'
           ,'ADMN'
           ,GETDATE()
           ,GETDATE())
		   INSERT INTO [dbo].[UserType]
           ([UserTypeName]
           ,[UserTypeDesc]
           ,[UserTypeCode]
           ,[CreatedDate]
           ,[ModifiedDate])
     VALUES
           ('Client'
           ,'User for Education'
           ,'CLED'
           ,GETDATE()
           ,GETDATE())
		   INSERT INTO [dbo].[UserType]
           ([UserTypeName]
           ,[UserTypeDesc]
           ,[UserTypeCode]
           ,[CreatedDate]
           ,[ModifiedDate])
     VALUES
           ('Client'
           ,'User for Medicine'
           ,'CLMD'
           ,GETDATE()
           ,GETDATE())
		   INSERT INTO [dbo].[UserType]
           ([UserTypeName]
           ,[UserTypeDesc]
           ,[UserTypeCode]
           ,[CreatedDate]
           ,[ModifiedDate])
     VALUES
           ('Client'
           ,'User for Food'
           ,'CLFD'
           ,GETDATE()
           ,GETDATE())
GO


