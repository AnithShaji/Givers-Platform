USE [E-Welfare]
GO

INSERT INTO [dbo].[Users]
           ([Username]
           ,[Password]
           ,[FirstName]
           ,[MiddleName]
           ,[Lastname]
           ,[EmailAddress]
           ,[Telephone]
           ,[Mobile]
           ,[DOB]
           ,[ProfileImagePath]
           ,[FlatHouseNameNumber]
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[CreatedDate]
           ,[CreatedByID]
           ,[ModifiedByID]
           ,[ModifiedDate]
           ,[UserTypeID]
           ,[UserStatusID])
     VALUES
           ('Admin'
           ,'admin123'
           ,'Sam'
           ,'V'
           ,'George'
           ,'sam@gmail.com'
           ,'009712456788'
           ,'9890998976'
           ,GETDATE()
           ,null
           ,'234'
           ,'Lanwerhweg'
           ,''
           ,'Kamp-Lintfort'
           ,GETDATE()
           ,1
           ,1
           ,GETDATE()
           ,1
           ,1)
GO


