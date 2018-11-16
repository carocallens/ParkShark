create schema Div
go

create table Div.Division(
Division_ID  varchar(100) not null,
Division_Name varchar (100) not null,
Division_OrgName varchar(100) not null,
Division_Director varchar(100) not null
constraint Division_pk primary key (Division_ID))

insert into Div.Division
(
Division_ID ,
Division_Name ,
Division_OrgName ,
Division_Director 
)
values
(
'e5b51e36-2159-4a80-8e77-473f516803c7',
'1testdivision',
'1testorgdivision',
'1willem'
),
(
'fedee2ce-8782-479e-990b-b6e3a2536eee',
'2testdivision',
'2testorgdivision',
'2willem'
),
(
'9c23c059-b5ef-4c9a-afec-b308d9b4eb22',
'3testdivision',
'3testorgdivision',
'3willem'
);

alter Table div.division add Division_ParentDivisionGuidId varchar (100) null
go

alter table div.division with check add constraint fk_subdivision_parentdivision 
foreign key (Division_ParentDivisionGuidId) references div.Division (Division_ID)
go

