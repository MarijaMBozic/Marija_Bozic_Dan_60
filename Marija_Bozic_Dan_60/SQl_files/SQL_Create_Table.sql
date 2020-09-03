IF DB_ID('Dan_60_Bozic') IS NULL
CREATE DATABASE Dan_60_Bozic
GO
USE Dan_60_Bozic;

drop table if exists tblUser
drop table if exists tblSector 
drop table if exists tblLocation
drop table if exists tblGender

create table tblGender(
   GenderId             int            identity (1,1) primary key,   
   Name                 nvarchar(100)          not null,
)

create table tblSector(
   SectorId             int            identity (1,1) primary key,   
   Name                 nvarchar(100)  unique        not null,
)

create table tblLocation(
   LocationId             int            identity (1,1) primary key,   
   Name                   nvarchar(100)    unique        not null,
)

create table tblUser (
   UserId             int            identity (1,1) primary key,   
   FullName           nvarchar(100)          not null,
   DateOfBirth        date                   default getDate(),
   IDNumber           int             unique not null,
   JMBG               bigint          unique not null,
   PhoneNumber        nvarchar(100)          not null,
   GenderId           int                    not null,
   FOREIGN KEY (GenderId) REFERENCES tblGender(GenderId),
   SectorId           int                    not null,
   FOREIGN KEY (SectorId) REFERENCES tblSector(SectorId),
   LocationId           int                    not null,
   FOREIGN KEY (LocationId) REFERENCES tblLocation(LocationId),
   MenagerId             int                     
   )

   insert into tblGender(Name)
   values('Femail'),
		 ('Male'), 
		 ('Other')