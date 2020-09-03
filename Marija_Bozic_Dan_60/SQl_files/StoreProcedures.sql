use Dan_60_Bozic

CREATE PROCEDURE Get_AllGender
AS
	select GenderId, Name  from tblGender
GO

CREATE PROCEDURE Get_AllSector
AS
	select SectorId, Name  from tblSector
GO

CREATE PROCEDURE Get_AllLocation
AS
	select LocationId, Name  from tblLocation
GO

CREATE or alter PROCEDURE Get_AllUsers
AS
	select UserId, FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,tblUser.GenderId, tblGender.Name,tblUser.SectorId, tblSector.Name,tblUser.LocationId, tblLocation.Name , MenagerId  from tblUser
	left join tblGender on tblUser.GenderId = tblGender.GenderId
	left join tblSector on tblUser.SectorId = tblSector.SectorId
	left join tblLocation on tblUser.LocationId = tblLocation.LocationId

GO

CREATE or alter PROCEDURE Update_User
	@UserId  int,
	@FullName nvarchar(100),
	@DateOfBirth date,
	@IDNumber int,
    @JMBG bigint,
	@PhoneNumber nvarchar(100),
    @GenderId int,
    @SectorId int,
    @LocationId int,     
    @MenagerId  int   
AS
	update tblUser
	set 
	FullName=@FullName,
	DateOfBirth=@DateOfBirth,
	IDNumber=@IDNumber,
    JMBG=@JMBG ,
	PhoneNumber=@PhoneNumber ,
    GenderId=@GenderId ,
    SectorId=@SectorId ,
    LocationId=@LocationId ,     
    MenagerId=@MenagerId  
	where 
		UserId=@UserId   

GO

CREATE or alter PROCEDURE Insert_User
	@FullName nvarchar(100),
	@DateOfBirth date,
	@IDNumber int,
    @JMBG bigint,
	@PhoneNumber nvarchar(100),
    @GenderId int,
    @SectorId int,
    @LocationId int,     
    @MenagerId  int   
AS
	insert into tblUser(FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,GenderId, SectorId, LocationId, MenagerId)
	values(	@FullName,@DateOfBirth,	@IDNumber, @JMBG ,@PhoneNumber, @GenderId ,  @SectorId ,  @LocationId ,@MenagerId) 
	select SCOPE_IDENTITY()
GO

CREATE OR ALTER PROCEDURE Delete_User
	@UserId int
as
	Delete from tblUser where UserId=@UserId
go

CREATE or alter PROCEDURE Get_UsersById
	@UserId int
AS
	select UserId, FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,tblUser.GenderId, tblGender.Name,tblUser.SectorId, tblSector.Name,tblUser.LocationId, tblLocation.Name , MenagerId  from tblUser
	left join tblGender on tblUser.GenderId = tblGender.GenderId
	left join tblSector on tblUser.SectorId = tblSector.SectorId
	left join tblLocation on tblUser.LocationId = tblLocation.LocationId
	where 
		UserId=@UserId   
GO

CREATE PROCEDURE Check_IDNumber
@IDNumber int
AS
	select FullName from tblUser
	where IDNumber=@IDNumber
GO

CREATE PROCEDURE Check_JMBG
@JMBG int
AS
	select FullName from tblUser
	where JMBG=@JMBG
GO

CREATE PROCEDURE Check_SectorName
@SectorName int
AS
	select Name from tblSector
	where Name=@SectorName
GO