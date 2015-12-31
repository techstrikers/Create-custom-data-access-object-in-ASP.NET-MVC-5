--http://www.techstrikers.com--
GO
CREATE TABLE [Employee](  
    [id] [int] IDENTITY(1,1) NOT NULL,  
    [FullName] [varchar](50) NULL,  
    [Designation] [varchar](100) NULL,  
    [Gender] [varchar](10) NULL,  
    [JoinDate] [date] NULL,  
    [Salary] [float] NULL,  
    [City] [varchar](50) NULL,  
    [State] [varchar](50) NULL,  
    [Zip] [int] NULL  
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED   
(  
    [id] ASC  
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF,   
ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]  
) ON [PRIMARY]  
GO

INSERT [Employee]([Name],[Designation],[Gender],[Role],[Salary],[City],[State],[Zip])   
VALUES (N'Devendra S',N'Project Lead',N'Male','Manager',12000,N'Bhopal',N'MP',21323)  
INSERT [dbo].[Employee]([Name],[Designation],[Gender],[Role],[Salary],[City],[State],[Zip])   
VALUES (N'Ram M',N'Engineer IT',N'Male','Developer',8000,N'Indore',N'MP',23333)  
INSERT [dbo].[Employee]([Name],[Designation],[Gender],[Role],[Salary],[City],[State],[Zip])   
VALUES (N'Manish S',N'Manager',N'Male','QA',9000,N'Delhi',N'Delhi',32334)  
INSERT [dbo].[Employee]([Name],[Designation],[Gender],[Role],[Salary],[City],[State],[Zip])   
VALUES (N'Rahul E',N'Software Engineer',N'Male','Tech Lead',12000,N'Indore',N'AP',45654)

GO
GO  
CREATE PROCEDURE [dbo].[uspGetEmployee]  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
    SELECT * from tblEmployee  
      
END  
  
GO  
CREATE PROCEDURE [dbo].[uspDeleteEmployee]  
(@id INT)   
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    DELETE FROM tblEmployee WHERE id = @id  
END  
  
GO  
CREATE PROCEDURE [dbo].[uspEditEmployee]  
(@id INT,  
@fullName varchar(50),  
@designation varchar(50),  
@gender varchar(10),  
@city varchar(50),  
@role varchar(25),  
@state varchar(50),  
@zip int,  
@phone varchar(12)  
)   
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    UPDATE tblEmployee SET Name = @name, Designation = @designation,  
    Gender = @gender,Role = @role, City = @city,State =@state,  
    Zip = @zip, Phone = @phone  WHERE id = @id  
END  
  
GO  
CREATE PROCEDURE [dbo].[uspInsertEmployee]  
(@name varchar(50),  
@designation varchar(50),  
@gender varchar(10),  
@city varchar(50),  
@role varchar(25),  
@state varchar(50),  
@salary float,  
@zip int,  
@phone varchar(12)  
)   
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    INSERT INTO tblEmployee(Name,Designation,Gender,City,Role,State,Salary,Zip,Phone)    
    VALUES (@name,@designation,@gender,@city,@Role,@state,@salary,@zip,@phone)  
END 
GO