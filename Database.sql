
CREATE TABLE Students (
 Id INT IDENTITY PRIMARY KEY,
 Name NVARCHAR(100),
 Email NVARCHAR(100),
 Age INT,
 Course NVARCHAR(100),
 CreatedDate DATETIME DEFAULT GETDATE()
)

GO

create PROCEDURE [dbo].[usp_AddStudent]
@Id int=null,
 @Name NVARCHAR(100)=null,
 @Email NVARCHAR(100)=null,
 @Age INT=null,
 @Course NVARCHAR(100)=null,
 @Actiont varchar(50) 
AS
BEGIN
  if(@Actiont='Add')
    BEGIN
 INSERT INTO Students(Name,Email,Age,Course)
 VALUES(@Name,@Email,@Age,@Course)
   END
   if(@Actiont='Delete')
    BEGIN
	 Delete from Students Where id=@Id
	END
	 if(@Actiont='Update')
    BEGIN
	 Update Students set Name=@Name,Email=@Email,Age=@Age,Course=@Course Where id=@Id
	END
	 if(@Actiont='Get')
    BEGIN
	 select * from Students Where id=@Id
	END
END