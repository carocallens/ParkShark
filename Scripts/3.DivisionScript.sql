/*
DivisionTable creation
*/


USE [ParkSharkDb]
go
create schema Div
go

create table Div.Division(
	Division_ID  uniqueidentifier not null default newid(),
	Division_Name varchar (100) not null,
	Division_OrgName varchar(100) not null,
	Division_Director varchar(100) not null
	constraint Division_pk primary key (Division_ID)
)


alter Table div.division 
	add Division_ParentDivisionGuidId uniqueidentifier null


alter table div.division with check
	add constraint fk_subdivision_parentdivision 
	foreign key (Division_ParentDivisionGuidId) references div.Division (Division_ID)


