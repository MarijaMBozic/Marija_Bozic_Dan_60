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
	select UserId, FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,tblGender.Name, 
	tblSector.Name, tblLocation.Name , 
	MenagerId, tblUser.GenderId, tblUser.SectorId, tblUser.LocationId  from tblUser
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
if @MenagerId=0
begin
	insert into tblUser(FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,GenderId, SectorId, LocationId)
	values(	@FullName,@DateOfBirth,	@IDNumber, @JMBG ,@PhoneNumber, @GenderId ,  @SectorId ,  @LocationId ) 
	select SCOPE_IDENTITY()
end
if @MenagerId!=0
begin
	insert into tblUser(FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,GenderId, SectorId, LocationId, MenagerId)
	values(	@FullName,@DateOfBirth,	@IDNumber, @JMBG ,@PhoneNumber, @GenderId ,  @SectorId ,  @LocationId, @MenagerId ) 
	select SCOPE_IDENTITY()
end
GO

CREATE or alter PROCEDURE Insert_Sector
	@Name nvarchar(100)
AS
	insert into tblSector(Name)
	values(@Name) 
	select SCOPE_IDENTITY()
GO

CREATE or alter PROCEDURE Insert_Location
	@Name nvarchar(100)
AS
	insert into tblLocation(Name)
	values(@Name) 
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
	select UserId, FullName,DateOfBirth,IDNumber, JMBG, PhoneNumber,tblUser.GenderId, 
	tblGender.Name,tblUser.SectorId, tblSector.Name,tblUser.LocationId, tblLocation.Name ,
	 MenagerId, tblUser.GenderId, tblUser.SectorId, tblUser.LocationId  from tblUser
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

CREATE or alter PROCEDURE Check_JMBG
@JMBG bigint
AS
	select FullName from tblUser
	where JMBG=@JMBG
GO

CREATE or alter PROCEDURE Check_SectorName
@SectorName nvarchar(100)
AS
	select SectorId from tblSector
	where Name=@SectorName
GO

insert into tblSector(Name)
values('HR')

CREATE or alter PROCEDURE Check_JMBG_Update
@JMBG bigint, @UserId int
AS
	select FullName from tblUser
	where JMBG=@JMBG and UserId=@UserId
GO

CREATE PROCEDURE Check_IDNumber_Update
@IDNumber int, @UserId int
AS
	select FullName from tblUser
	where IDNumber=@IDNumber and UserId=@UserId
GO