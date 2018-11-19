USE [ParkSharkDb]
go
create schema Div
go

create table Div.Division(
Division_ID  uniqueidentifier not null default newid(),
Division_Name varchar (100) not null,
Division_OrgName varchar(100) not null,
Division_Director varchar(100) not null
constraint Division_pk primary key (Division_ID))

insert into Div.Division
(
Division_Name ,
Division_OrgName ,
Division_Director 
)
values
(
'1testdivision',
'1testorgdivision',
'1willem'
),
(
'2testdivision',
'2testorgdivision',
'2willem'
),
(
'3testdivision',
'3testorgdivision',
'3willem'
);

alter Table div.division add Division_ParentDivisionGuidId varchar (100) null
go

alter table div.division with check add constraint fk_subdivision_parentdivision 
foreign key (Division_ParentDivisionGuidId) references div.Division (Division_ID)
go

